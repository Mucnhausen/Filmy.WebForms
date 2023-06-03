<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="movie.aspx.cs" Inherits="FilmyProject.movie" OnPreRender="Page_PreRender"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/individualPages.css" rel="stylesheet" />
    <link href="css/stars.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/1d5a770b77.js" crossorigin="anonymous"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="content">
            <div class="container" runat="server" id="container">
                <div class="image">
                    <asp:Image ID="Image1" runat="server" width="360px" height="512px"/>
                </div>
                <div class="text-container">
                    <p class="big"><asp:Label ID="title" runat="server" Text="Label"></asp:Label></p>
                    <span class="stars-placeholder" runat="server" id="starsPlaceholder"></span>
                    <p class="text"><span class="bold">Publish date:</span> <asp:Label ID="date" runat="server" Text="Label"></asp:Label> </p>
                    <p class="text"><span class="bold">Budget:</span> <asp:Label ID="budget" runat="server" Text="Label"></asp:Label></p>
                    <p class="text"><span class="bold">Genres:</span> <asp:Label ID="genres" runat="server" Text="Label"></asp:Label></p>
                    <p class="text"><span class="bold">Actors:</span> <asp:Label ID="actors" runat="server" Text="Label"></asp:Label></p>
                    <p class="text"><span class="bold">Producers:</span> <asp:Label ID="producers" runat="server" Text="Label"></asp:Label></p>
                    <h2 class="text medium"><span class="bold">Summary</span></h2>
                    <p class="text"><asp:Label ID="review_text" runat="server" Text="Label"></asp:Label></p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
