﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="FilmyProject.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/login.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="main">
            <div class="main-form">
                <div class="preform">
                    <div class="slogan">
                        <h1 class="slogan-text">Critic, fill your credits!</h1>
                    </div>
                    <div class="form" action="">
                        <div class="row divide">
                            <asp:TextBox ID="usernameBox" runat="server" class="input1" placeholder="Username" autofocus="true"></asp:TextBox>
                            <asp:TextBox ID="passwordBox" runat="server" class="input1 margin-left" TextMode="Password" placeholder="Password"></asp:TextBox>
                        </div>
                        <div class="row">
                            <asp:Button ID="submitBtn" runat="server" class="submit" Text="Submit" OnClick="submitBtn_Click"/>
                        </div>
                    </div>
                    <div class="password-reset">
                        <asp:LinkButton ID="password_resetLink" runat="server" Font-Underline="false" OnClick="password_resetLink_Click">Forgot Password?</asp:LinkButton>
                    </div>
                </div>
                

            </div>
            <div class="main-image-wrapper">
                <div class="main-image-item"></div>
            </div>
        </div>
    </div>
</asp:Content>
