﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="adminLogin.aspx.cs" Inherits="FilmyProject.adminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/login.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="content">
        <div class="main">
            <div class="main-form">
                <div class="preform">
                    <div class="slogan">
                        <h1 class="slogan-text">Welcome, your majesty!</h1>
                    </div>
                    <div class="form" action="">
                        <div class="row divide">
                            <asp:TextBox ID="emailBox" runat="server" class="input1" TextMode="Email" placeholder="Email" autofocus="true"></asp:TextBox>
                            <asp:TextBox ID="passwordBox" runat="server" class="input1 margin-left" TextMode="Password" placeholder="Password"></asp:TextBox>
<%--                            <input type="text" class="input1" placeholder="Email" autofocus>
                            <input type="text" class="input1 margin-left" placeholder="Password">--%>
                        </div>
                        <div class="row">
                            <asp:Button ID="submitBtn" runat="server" class="submit" Text="Submit"/>
                            <%--<input type="submit" class="submit">--%>
                        </div>
                    </div>
                    <div class="password-reset">
                        <asp:LinkButton ID="password_resetLink" runat="server" Font-Underline="false">Forgot Password?</asp:LinkButton>
                    </div>
                </div>
                

            </div>
            <div class="main-image-wrapper">
                <div class="main-image-item"></div>
            </div>
        </div>
    </div>
</asp:Content>