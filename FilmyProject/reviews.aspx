<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="reviews.aspx.cs" Inherits="FilmyProject.reviews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/reviews.css" rel="stylesheet" />
    <link href="css/stars.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/1d5a770b77.js" crossorigin="anonymous"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT m.movie_name AS movie_name, m.genres AS genres, m.actors AS actors, m.producers AS producers, r.id AS review_id, r.review_text AS review_text, r.rating AS rating, r.date AS review_date, c.username AS username, c.first_name AS first_name, c.last_name AS last_name FROM reviews r JOIN movies m ON r.movie_id = m.ID JOIN critics c ON r.critic_username = c.username"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False" class="wrapper table">
            <Columns> 
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a class="grid-container" href="review.aspx?id=<%# Eval("review_id") %>" style="text-decoration: none; color: black;">
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
    </div>
</asp:Content>
