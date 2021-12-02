using System;
using System.Collections.Generic;
using ERPsystem.LoginManager;
using ERPsystem.DB;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;

namespace ERPsystem
{
    public partial class Purchase : System.Web.UI.Page
    {
        const int _pageSize = 8;
        //自動生頁數MODEL
        internal class PagingLink
        {
            public string Name { get; set; }
            public string Link { get; set; }
            public string Title { get; set; }
            public string Color { get; set; }
        }

        public class PagingHelper
        {
            //實作分頁的函式
            public static int CalculatePages(int totalSize, int pageSize)
            {
                // 頁 = 總比數 / 單頁資料數
                int pages = totalSize / pageSize;
                //如果有餘數就再+一頁
                if (totalSize % pageSize != 0)
                    pages += 1;
                //回傳給頁
                return pages;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (!LoginHelper.Haslogined())
                {
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                this.LoadPurchaseView();
            }
        }

        private string GetQueryString(bool includePage, int? pageIndex)
        {
            //----- Get Query string parameters -----
            string page = Request.QueryString["Page"];
            //----- Get Query string parameters -----

            List<string> conditions = new List<string>();

            if (!string.IsNullOrEmpty(page) && includePage)
                conditions.Add("Page=" + page);

            if (pageIndex.HasValue)
                conditions.Add("Page=" + pageIndex.Value);

            string retText =
                (conditions.Count > 0)
                    ? "?" + string.Join("&", conditions)
                    : string.Empty;

            return retText;
        }

        //一般:從DB抓總表資料出來根據PAGE進行分頁     搜尋:抓取Keyword資料，進DB後將篩選的資料依據PAGE進行分頁
        private void LoadPurchaseView()
        {
            //----- Get Query string parameters -----
            string page = Request.QueryString["Page"];
            int pIndex = 0;
            //當頁面不為0時,進入預設第一頁
            if (string.IsNullOrEmpty(page))
                pIndex = 1;
            else
            {
                //將PAGE轉為數字，回傳pIndex
                int.TryParse(page, out pIndex);
                //如果回傳值小於0,強制轉成1
                if (pIndex <= 0)
                    pIndex = 1;
            }
            //----- Get Query string parameters -----
            //設定關鍵搜尋網址
            int totalSize = 0;

            var manager = new PurchaseDB();
            var list = manager.ViewGroup(out totalSize, pIndex, _pageSize);
            int pages = PagingHelper.CalculatePages(totalSize, _pageSize);

            List<PagingLink> pagingList = new List<PagingLink>();
            for (var i = 1; i <= pages; i++)
            {
                pagingList.Add(new PagingLink()
                {
                    Link = $"Purchase.aspx{this.GetQueryString(false, i)}",
                    Name = $"{i}",
                    Title = $"前往第 {i} 頁",
                    Color = (i == pIndex) ? "BLACK" : ""
                });
            }

            this.repPaging.DataSource = pagingList;
            this.repPaging.DataBind();

            this.PurchaseList.DataSource = list;
            this.PurchaseList.DataBind();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("PurchaseDetail.aspx");
        }

        protected void PurchaseList_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            string cmdName = e.CommandName;
            string cmdArgu = e.CommandArgument.ToString();

            if ("DeleteItem" == cmdName)
            {
                Response.Write("<script>alert('刪除成功');</script>");
                PurchaseManager.Delete(cmdArgu);
                this.LoadPurchaseView();
            }

            if ("UpdateItem" == cmdName)
            {
                string targetUrl = "~/PurchaseDetail.aspx?Purchase_ID=" + cmdArgu;
                Response.Redirect(targetUrl);
            }
        }

        protected void Print_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = localhost\\SQLExpress; Initial Catalog = ERP; Integrated Security = true");

            string Query = $@"SELECT 
                              [PurchaseDetail].Purchase_ID
                              , COUNT([ProductList].Product_Class) AS 'Purchase_Class'
                              ,SUM([PurchaseDetail].Product_Quantity) AS 'Purchase_Quantity'
                              ,[PurchaseDetail].ArriveTime AS 'ArriveTime'
                              ,SUM([ProductList].Price * [PurchaseDetail].Product_Quantity) AS 'Purchase_Price'
                              ,ROW_NUMBER() OVER(ORDER BY[PurchaseDetail].Purchase_ID DESC) AS ROWNUM
                              ,[PurchaseDetail].Isdelete
                              FROM[PurchaseDetail]
                              JOIN[ProductList] ON[PurchaseDetail].Product_ID = [ProductList].Product_ID
                              WHERE [PurchaseDetail].Isdelete = 'false'
                              GROUP BY[PurchaseDetail].Purchase_ID,[PurchaseDetail].ArriveTime,[PurchaseDetail].Isdelete";

            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            ReportDocument crp = new ReportDocument();
            crp.Load(Server.MapPath("CrystalReport1.rpt"));
            crp.SetDataSource(ds.Tables["table"]);

            CrystalReportViewer1.ReportSource = crp;

            crp.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
        }
    }
}
