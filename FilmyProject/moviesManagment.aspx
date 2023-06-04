<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="moviesManagment.aspx.cs" Inherits="FilmyProject.moviesManagment" UnobtrusiveValidationMode="None"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/criticsManagment.css" rel="stylesheet" />
    <script src="js/moviesManagementValidator.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="main">
            <div class="main-form">
                <div class="slogan">
                    <h1 class="slogan-text">You are the power!</h1>
                </div>
                <div class="form" action="">
                    <div class="row">
                        <asp:TextBox ID="titleBox" runat="server" class="input2" placeholder="Title" ClientIDMode="Static" ></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="idBox" runat="server" class="input3" placeholder="ID" ClientIDMode="Static"></asp:TextBox>
                        <asp:Button ID="findBtn" runat="server" class="find margin-left" Text="Find" OnClick="findBtn_Click"/>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="dateBox" runat="server" TextMode="Date" class="input2 date" title="Publishing date" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="budgetBox" runat="server" class="input2" placeholder="Budget" ClientIDMode="Static" Title="Valid formats: $100, $100,000.00, 100, 100.00"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="ratingBox" runat="server" TextMode="Number" class="input2" placeholder="Rating" min="1" max="10" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="row textarea">
                        <asp:TextBox ID="genresBox" runat="server" TextMode="MultiLine" Rows="4" class="input2" placeholder="Genres (',' - separator)" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="row textarea">
                        <asp:TextBox ID="actorsBox" runat="server" TextMode="MultiLine" Rows="4" class="input2" placeholder="Actors (',' - separator)" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="row textarea">
                        <asp:TextBox ID="producersBox" runat="server" TextMode="MultiLine" Rows="4" class="input2" placeholder="Producers (',' - separator)" ClientIDMode="Static"></asp:TextBox>
                    </div>
                     <div class="row buttons ">
                        <asp:FileUpload ID="FileUpload1" runat="server" accept=".png,.jpg,.jpeg" style="padding-top: 6px; background-color: white;" title="Recommended resolution: 360x512 "/>
                        <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                                 ControlToValidate="FileUpload1"
                                 ErrorMessage="Only images are allowed" 
                                 ValidationExpression="(.*?)\.(jpg|jpeg|png|JPG|JPEG|PNG)$"
                                 style="display: none" >
                        </asp:RegularExpressionValidator>
                        <asp:Button ID="UploadBtn" runat="server" class="upload input5 " Text="Upload" OnClick="UploadBtn_Click"/>
                    </div>
                    <div class="row textarea">
                        <asp:TextBox ID="descriptionBox" runat="server" TextMode="MultiLine" Rows="4" class="input2" placeholder="Tell about yourself" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="row buttons">
                        <asp:Button ID="addBtn" runat="server" class="input2 add" Text="Add" OnClick="addBtn_Click" OnClientClick="return validateForm();"/>
                        <asp:Button ID="updateBtn" runat="server" class="input2 update" Text="Update" OnClick="updateBtn_Click" OnClientClick="return validateForm();"/>
                        <asp:Button ID="deleteBtn" runat="server" class="input2 delete" Text="Delete" OnClick="deleteBtn_Click"/>
                    </div>
                </div>
            </div>
            <div class="main-table-wrapper">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [movies]"></asp:SqlDataSource>
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" class="table" style="background-color: white;" AutoGenerateColumns="False" DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="movie_name" HeaderText="movie_name" SortExpression="movie_name" />
                        <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
                        <asp:BoundField DataField="genres" HeaderText="genres" SortExpression="genres" />
                        <asp:BoundField DataField="actors" HeaderText="actors" SortExpression="actors" />
                        <asp:BoundField DataField="producers" HeaderText="producers" SortExpression="producers" />
                        <asp:BoundField DataField="rating" HeaderText="rating" SortExpression="rating" />
                        <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                        <asp:BoundField DataField="budget" HeaderText="budget" SortExpression="budget" />
                        <asp:BoundField DataField="image_path" HeaderText="image_path" SortExpression="image_path" />
                    </Columns>
                </asp:GridView> <%--Table--%>
                <div class="main-table-item">
<%--                    <table id="myTable" class="display table">
                    <thead>
                        <tr>
                            <th>Column 1</th>
                            <th>Column 2</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Row 1 Data 1</td>
                            <td>Row 1 Data 2</td>
                        </tr>
                        <tr>
                            <td>Row 2 Data 1</td>
                            <td>Row 2 Data 2</td>
                        </tr>
                    </tbody>
                </table>--%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
