<%@ Page Title="" Language="C#" MasterPageFile="~/TopSide.Master" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="ERPsystem.Purchase" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #Purchase_List {
            padding: 20px 20px 20px 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h1>銷貨單管理</h1>
    </div>
    <hr />
    <div id="insert_btn" class="d-grid gap-2 d-flex justify-content-end">
        <a href="PurchaseDetail.aspx" class="btn btn-outline-success">新增進貨單</a>&nbsp;
        <asp:Button CssClass="btn btn-success btn-sm" ID="Print" runat="server" Text="輸出" OnClick="Print_Click" />&nbsp;
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    </div>
    <div id="Purchase_List" class="row">
        <table class="table table-striped">
            <thead class="table-info">
                <tr>
                    <th>單據編號</th>
                    <th>貨物種類</th>
                    <th>進貨數量</th>
                    <th>預計進貨時間</th>
                    <th>進貨金額</th>
                    <th>編輯</th>
                </tr>
            </thead>
            <asp:Repeater ID="PurchaseList" runat="server" OnItemCommand="PurchaseList_ItemCommand">
                <ItemTemplate>
                    <tbody class="table table-bordered border-info">
                        <tr>
                            <td><%# Eval("Purchase_ID")%></td>
                            <td><%# Eval("Purchase_Class")%></td>
                            <td><%# Eval("Product_Quantity")%></td>
                            <td><%# Eval("ArriveTime","{0: yyyy-MM-dd}")%></td>
                            <td><%# Eval("Purchase_Price")%></td>
                            <td>
                                <asp:Button CssClass="btn btn-danger btn-sm" ID="Delete" runat="server" Text="刪除" CommandName="DeleteItem" CommandArgument='<%# Eval("Purchase_ID") %>' />
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div class="text-center">
        <asp:Repeater runat="server" ID="repPaging">
            <ItemTemplate>
                <a style="color: <%# Eval("Color") %>" href="<%# Eval("Link") %>" title="<%# Eval("Title") %>">第<%# Eval("Name") %>頁</a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
