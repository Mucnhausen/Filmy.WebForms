<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="movies.aspx.cs" Inherits="FilmyProject.movies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/movies_critics.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="content">
        <div class="grid-container">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" class="">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="grid-item">
                                <div class="content-grid-img">
                                    <img class="content-grid-img" src=" <%# Eval("image_path") %>" alt="">
                                </div>
                            </div>
                            <div class="grid-item">
                                <div class="content-grid-item-main">
                                    <div class="content-grid-header">
                                        <h1 class="content-grid-header-text">
                                            <%# Eval("movie_name") %>
                                        </h1>
                                    </div>
                                    <div class="content-grid-body">
                                        <ul class="content-grid-body-list">
                                            <li>Date: <%# Eval("date") %></li>
                                            <li>Budget: <%# Eval("budget") %></li>
                                            <li>Genres: <%# Eval("genres") %></li>
                                            <li>Actors: <span><%# Eval("actors") %></span></li>
                                            <li>Producers: <%# Eval("producers") %></li>
                                            <li>Rating: <%# Eval("rating") %></li>
                                            <li>Description: </li>
                                        </ul>
                                        <p class="description">
                                            <%# Eval("description") %>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
             
        </div>
    </div>
</asp:Content>
