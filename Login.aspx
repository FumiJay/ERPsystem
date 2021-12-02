<%@ Page Title="" Language="C#" MasterPageFile="~/TopSide.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ERPsystem.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="container text-center" style="padding-top: 20%;">
            <div class="align-items-center">
                <asp:Label Text="登入系統" runat="server" /><br />
                帳號:<asp:TextBox Text="" ID="Accouunt" runat="server" Style="width: 200px"></asp:TextBox><br />
                密碼:<asp:TextBox Text="" ID="password" TextMode="Password" runat="server" Style="width: 200px"></asp:TextBox><br />
            </div>
            <div class="row justify-content-center align-items-center">
                <asp:Button ID="Button1" Style="padding-top: 5px" class="btn btn-success offset-2" runat="server" Text="登入" OnClick="Button1_Click" />
            </div>
        </div>
    </div>
</asp:Content>
