<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="FilmyProject.about" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/about.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="slogan">
            <h1 class="slogan-text">We know if you should watch the movie</h1>
        </div>
        <div class="main">
            <div class="main-text">
                <div class="main-text-about-wrapper">
                    <div class="main-text-about">We provide easy to search reviews of movies</div>
                    <div class="main-text-about">Articles are written by trusted critics</div>
                </div>
                <div class="main-text-contact-wrapper">
                    <div class="main-text-contact" style="margin-bottom: 60px;">Want to join our critics team?</div>
                    <asp:LinkButton ID="LinkButton1" runat="server" class="main-text-contact-button" OnClick="LinkButton1_Click">Join Us</asp:LinkButton>
                    <div class="main-text-contact" style="margin-top: 60px;">Have suggestions?</div>
                    <div class="main-text-contact">Contact us at filmycommunity@gmail.com</div>
                </div>
            </div>
            <div class="main-wrapper">
                <div class="main-wrapper-image">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
