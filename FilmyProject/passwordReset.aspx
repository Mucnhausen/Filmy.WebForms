<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="passwordReset.aspx.cs" Inherits="FilmyProject.passwordReset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/login.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="main">
            <div class="main-form">
                <div class="preform">
                    <div class="slogan">
                        <h1 class="slogan-text">Critic, remember your password!</h1>
                    </div>
                    <div class="form" action="">
                        <div class="row">
                            <asp:TextBox ID="emailBox" runat="server" class="input1" TextMode="Email" placeholder="Email" autofocus="true"></asp:TextBox>
                        </div>
                        <div class="row">
                            <asp:Button ID="submitBtn" runat="server" class="submit" Text="C'mon send it"/>
                        </div>
                    </div>
                </div>
                

            </div>
            <div class="main-image-wrapper">
                <div class="main-image-item"></div>
            </div>
        </div>
    </div>
</asp:Content>
