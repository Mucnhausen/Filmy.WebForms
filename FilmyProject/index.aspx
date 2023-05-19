<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FilmyProject.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/index.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="main">
            <div class="main-text">
                <div class="main-text-about-wrapper">
                    <p class="main-text-about-wrapper-paragraph">Your time is priceless,<br> be sure in the movie you watch!</p>
                    <blockquote class="main-text-about-wrapper-quote">
                        <cite title="Source Title">Confucius</cite>, many years ago
                    </blockquote>
                </div>
            </div>
            <div class="main-wrapper">
                <div class="main-wrapper-image">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
