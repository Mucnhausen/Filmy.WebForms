<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="review.aspx.cs" Inherits="FilmyProject.review" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="css/individualPages.css" rel="stylesheet" />
    <link href="css/stars.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/1d5a770b77.js" crossorigin="anonymous"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="content">
            <div class="container" runat="server" id="container">
                <div class="wrapper">
                    <div class="heading">
                        <p class="text big"><asp:Label ID="first_name" runat="server" Text="Label"></asp:Label> <asp:Label ID="last_name" runat="server" Text="Label"></asp:Label></p>
                        <p class="text medium">Given rating</p>
                        <span class="stars-placeholder" runat="server" id="starsPlaceholderREVIEW"></span>
                    </div>
                    <div class="text-container padding">
                        <p class="text medium"><asp:Label ID="username" runat="server" Text="Label"></asp:Label></p>
                        <p class="text"><span class="bold">Date of upload: </span><asp:Label ID="review_publish_date" runat="server" Text="Label"></asp:Label></p>
                        <span class="bold">Review: </span>
                        <p class="text"><asp:Label ID="review_text" runat="server" Text="Label"></asp:Label></p>
                    </div>
                </div>
                
                <div class="wrapper">
                    <div class="heading">
                        <p class="text big"><asp:Label ID="title" runat="server" Text="Label"></asp:Label></p>
                        <p class="text medium">Official rating</p>
                        <span class="stars-placeholder" runat="server" id="starsPlaceholderMOVIE"></span>
                    </div>
                    <div class="text-container padding">
                        <p class="text"><span class="bold">Date: </span><asp:Label ID="movie_publish_date" runat="server" Text="Label"></asp:Label></p>
                        <p class="text"><span class="bold">Budget: </span><asp:Label ID="budget" runat="server" Text="Label"></asp:Label></p>
                        <p class="text"><span class="bold">Genres: </span><asp:Label ID="genres" runat="server" Text="Label"></asp:Label></p>
                        <p class="text"><span class="bold">Actors: </span><asp:Label ID="actors" runat="server" Text="Label"></asp:Label></p>
                        <p class="text"><span class="bold">Producers: </span><asp:Label ID="producers" runat="server" Text="Label"></asp:Label></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
