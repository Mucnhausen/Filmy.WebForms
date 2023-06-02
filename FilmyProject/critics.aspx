<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="critics.aspx.cs" Inherits="FilmyProject.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/movies_critics.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [username], [first_name], [last_name], [birth_date], [country], [articles], [description], [image_path] FROM [critics]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" class="wrapper table">
            <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="grid-container">
                                <div class="grid-item">
                                    <div class="content-grid-img">
                                        <img class="content-grid-img" src="<%# Eval("image_path") %>" alt="">
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
                                                <li>Username: <%# Eval("username") %></li>
                                                <li>Born: <%# Eval("birth_date") %></li>
                                                <li>Country: <%# Eval("country") %></li>
                                                <li>Articles Number: <%# Eval("articles") %></li>
                                                <li>Description: </li>
                                            </ul>
                                            <p class="description"><%# Eval("description") %></p>
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
