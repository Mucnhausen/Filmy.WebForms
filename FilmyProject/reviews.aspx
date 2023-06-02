<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="reviews.aspx.cs" Inherits="FilmyProject.reviews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/reviews.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/1d5a770b77.js" crossorigin="anonymous"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT m.movie_name AS movie_name, m.genres AS genres, m.actors AS actors, m.producers AS producers, r.review_text AS review_text, r.rating AS rating, r.date AS review_date, c.username AS username, c.first_name AS first_name, c.last_name AS last_name FROM reviews r JOIN movies m ON r.movie_id = m.ID JOIN critics c ON r.critic_username = c.username"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False" class="wrapper table">
            <Columns> 
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="grid-container">
                                <div class="grid-item">
                                    <div class="content-grid-big">
                                        <h1 class="content-grid-big-text"><%# Eval("movie_name") %>
                                        <div class="content-grid-big-rating">
                                            <span class="stars-placeholder" runat="server" id="starsPlaceholder"></span>
                                        </div>
                                        <h1 class="content-grid-big-number"><%# Eval("rating") %></h1>
                                    </div>
                                </div>
                                <div class="grid-item">
                                    <div class="content-grid-item-main">
                                        <div class="content-grid-header">
                                            <h1 class="content-grid-header-text">
                                                <%# Eval("first_name") %> <%# Eval("last_name") %>
                                            </h1>
                                        </div>
                                        <div class="content-grid-body">
                                            <ul class="content-grid-body-list">
                                                <li>Review published date: <%# Eval("review_date") %></li>
                                                <li>Genres: <%# Eval("genres") %></li>
                                                <li>Actors: <%# Eval("actors") %></li>
                                                <li>Producers: <%# Eval("producers") %></li>
                                            </ul>
                                            <div class="content-grid-body-review">
                                                <h2>Review: </h2>
                                                <p class="description"><%# Eval("review_text") %></p> 
                                            </div>
                                        </div>
                                    </div>
                                </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
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
