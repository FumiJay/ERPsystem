<%@ Page Title="" Language="C#" MasterPageFile="~/TopSide.Master" AutoEventWireup="true" CodeBehind="PurchaseDetail.aspx.cs" Inherits="ERPsystem.PurchaseDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #Purchase_List {
            padding: 20px 20px 20px 20px;
        }

        #dialog {
            background-color: white;
        }
    </style>

    <script>
        $(document).ready(function () {
            $("#dialog").dialog({
                closeOnEscape: false,
                autoOpen: false,
                modal: true,
                draggable: false,
                height: 500,
                width: 500

            }).parent().appendTo("form");

            $("#Plus").click(function (evt) {
                evt.preventDefault();

                $("#dialog").dialog("open");
            });


            $("#Minus").click(function (evt) {
                evt.preventDefault();

                $('#dialog').dialog("close");
            });
            
        });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h1>銷貨單管理</h1>
    </div>
    <hr />
    <div style="padding: 10px 10px 10px 10px">
        <font color="red">* 號為必填項目</font>
        <br />
        <font>進貨編號和到貨日期必須先行輸入才可輸入商品</font>
        <br />
        <font color="red">*</font>
        單據編號 :
        <asp:TextBox ID="PurchaseID" runat="server" MaxLength="8"></asp:TextBox><br />
        <font color="red">*</font>
        進貨時間 :
        <asp:TextBox ID="dateinpu" runat="server" TextMode="Date" Style="width: 220px" AutoPostBack="true"></asp:TextBox>
        <br />
    </div>
    <div>
        <button class="btn btn-outline-success" id="Plus">新增</button>
        <asp:Button CssClass="btn btn-danger btn-sm" ID="Delete" runat="server" Text="清除" OnClick="Delete_Click" />
    </div>
    <div id="Purchase_List" class="row">
        <table class="table table-striped">
            <thead class="table-info">
                <tr>
                    <th>商品編號</th>
                    <th>商品名稱</th>
                    <th>單價</th>
                    <th>數量</th>
                    <th>小計</th>
                </tr>
            </thead>
            <asp:Repeater ID="Purchase_Detail" runat="server">
                <ItemTemplate>
                    <tbody class="table table-bordered border-info">
                        <tr>
                            <td><%# Eval("Product_ID")%></td>
                            <td><%# Eval("Product_Name")%></td>
                            <td><%# Eval("Price")%></td>
                            <td><%# Eval("Product_Quantity")%></td>
                            <td><%# Convert.ToInt32(Eval("Price")) * Convert.ToInt32(Eval("Product_Quantity")) %></td>
                        </tr>
                    </tbody>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <asp:Label ID="Price" runat="server" Text=""></asp:Label><br /><br />
        <asp:Label ID="ErrMess" runat="server" ForeColor="Red" Text=""></asp:Label><br />
        <asp:Button ID="Insert_btn" runat="server" CssClass="btn btn-primary" Text="建立表單" OnClick="Insert_btn_Click" />
    </div>
    <div id="dialog" title="商品列表">
        <div id="ProductList" class="row">
            <table class="table table-striped">
                <thead class="table-info">
                    <tr>
                        <th>商品編號</th>
                        <th>商品名稱</th>
                        <th>單價</th>
                    </tr>
                </thead>
                <asp:Repeater ID="Product_List" runat="server">
                    <ItemTemplate>
                        <tbody class="table table-bordered border-info">
                            <tr>
                                <td><%# Eval("Product_ID")%></td>
                                <td><%# Eval("Product_Name")%></td>
                                <td><%# Eval("Price")%></td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div>
            請選擇要進貨的產品:&nbsp;
            <asp:DropDownList ID="ProducrSelect" runat="server"></asp:DropDownList><br />
            請輸入要進貨的數量:&nbsp;
            <asp:TextBox ID="ProductQTY" runat="server" MaxLength="4"></asp:TextBox><br />
            <asp:Button ID="btnInsert" CssClass="btn btn-outline-primary" runat="server" Text="確定" OnClick="btnInsert_Click" />&nbsp;
            <button id="Minus" class="btn btn-outline-success">取消</button>
        </div>
    </div>
</asp:Content>
