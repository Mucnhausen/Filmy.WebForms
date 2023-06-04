<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="critic.aspx.cs" Inherits="FilmyProject.critic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/individualPages.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
<div>
    <div class="content">
        <div class="container">
            <div class="image">
                <asp:Image ID="Image1" runat="server" width="360px" height="512px"/>
            </div>
            <div class="text-container">
                <p class="text big"><asp:Label ID="first_name" runat="server" Text="Label"></asp:Label> <asp:Label ID="last_name" runat="server" Text="Label"></asp:Label></p>
                <p class="text medium"><asp:Label ID="username" runat="server" Text="Label"></asp:Label></p>
                <p class="text"><span class="bold">Telephone: </span><asp:Label ID="phone" runat="server" Text="Label"></asp:Label></p>
                <p class="text"><span class="bold">Email: </span><asp:Label ID="email" runat="server" Text="Label"></asp:Label></p>
                <p class="text"><span class="bold">Country: </span><asp:Label ID="country" runat="server" Text="Label"></asp:Label></p>
                <p class="text"><span class="bold">Born on: </span><asp:Label ID="birth_date" runat="server" Text="Label"></asp:Label> | <span class="bold">Joined on: </span><asp:Label ID="reg_date" runat="server" Text="Label"></asp:Label></p>
                <p class="text"><span class="bold">Articles: </span><asp:Label ID="articles" runat="server" Text="Label"></asp:Label></p>
                <p class="text"><span class="bold">Pending: </span><asp:Label ID="pending" runat="server" Text="Label"></asp:Label></p>
                <h2 class="text medium"><span class="bold">About me</span></h2>
                <p class="text"><asp:Label ID="description" runat="server" Text="Label"></asp:Label></p>
            </div>
        </div>
    </div>
</div>

</asp:Content>
