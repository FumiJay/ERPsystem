<%@ Page Title="" Language="C#" MasterPageFile="~/TopSide.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="ERPsystem.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #Product_List {
            padding: 50px 50px 50px 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Product_List" class="row">
        <table class="table table-striped">
            <thead class="table-info">
                <tr>
                    <th>商品編號</th>
                    <th>分類</th>
                    <th>商品名稱</th>
                    <th>單價</th>
                </tr>
            </thead>
            <asp:Repeater ID="ProductList" runat="server">
                <ItemTemplate>
                    <tbody class="table table-bordered border-info">
                        <tr>
                            <td><%# Eval("Product_ID")%></td>
                            <td><%# Eval("Product_Class")%></td>
                            <td><%# Eval("Product_Name")%></td>
                            <td><%# Eval("Price")%></td>
                        </tr>
                    </tbody>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>
