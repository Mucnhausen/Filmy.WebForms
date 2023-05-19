<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="reviews.aspx.cs" Inherits="FilmyProject.reviews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/reviews.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/1d5a770b77.js" crossorigin="anonymous"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="grid-container">
            <div class="grid-item">
                <div class="content-grid-big">
                    <h1 class="content-grid-big-text">Star Wars IV:<br> A New Hope</h1>
                    <div class="content-grid-big-rating">
                        <span class="fa fa-star checked"></span>
                        <span class="fa fa-star checked"></span>
                        <span class="fa fa-star checked"></span>
                        <span class="fa fa-star"></span>
                        <span class="fa fa-star"></span>
                    </div>
                    <h1 class="content-grid-big-number">3/5</h1>
                </div>
            </div>
            <div class="grid-item">
                <div class="content-grid-item-main">
                    <div class="content-grid-header">
                        <h1 class="content-grid-header-text">
                            Roger Ebert
                        </h1>
                    </div>
                    <div class="content-grid-body">
                        <ul class="content-grid-body-list">
                            <li>Date: May 25, 1977</li>
                            <li>Genres: Science Fiction, Adventure</li>
                            <li>Actors: <span>Mark Hamill, Harrison Ford, Carrie Fisher, Peter Cushing, Alec Guinness</span></li>
                            <li>Producers: Gary Kurtz</li>
                        </ul>
                        <div class="content-grid-body-review">
                            <h2>Review: </h2>
                            <p class="description">The fate of the galaxy is forever changed when Luke Skywalker discovers his powerful connection to a mysterious Force, and blasts into space to rescue Princess Leia. Mentored by a wise Jedi Master, and opposed by the menacing Darth Vader, Luke takes his first steps on a hero's journey.</p> 
                        </div>
                    </div>
                </div>
            </div>
            <div class="grid-item">
                <div class="content-grid-big">
                    <h1 class="content-grid-big-text">Star Wars IV:<br> A New Hope</h1>
                    <div class="content-grid-big-rating">
                        <span class="fa fa-star checked"></span>
                        <span class="fa fa-star checked"></span>
                        <span class="fa fa-star checked"></span>
                        <span class="fa fa-star"></span>
                        <span class="fa fa-star"></span>
                    </div>
                    <h1 class="content-grid-big-number">3/5</h1>
                </div>
            </div>
            <div class="grid-item">
                <div class="content-grid-item-main">
                    <div class="content-grid-header">
                        <h1 class="content-grid-header-text">
                            Roger Ebert
                        </h1>
                    </div>
                    <div class="content-grid-body">
                        <ul class="content-grid-body-list">
                            <li>Date: May 25, 1977</li>
                            <li>Genres: Science Fiction, Adventure</li>
                            <li>Actors: <span>Mark Hamill, Harrison Ford, Carrie Fisher, Peter Cushing, Alec Guinness</span></li>
                            <li>Producers: Gary Kurtz</li>
                        </ul>
                        <div class="content-grid-body-review">
                            <h2>Review: </h2>
                            <p class="description">The fate of the galaxy is forever changed when Luke Skywalker discovers his powerful connection to a mysterious Force, and blasts into space to rescue Princess Leia. Mentored by a wise Jedi Master, and opposed by the menacing Darth Vader, Luke takes his first steps on a hero's journey.</p> 
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
