<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="criticsManagment.aspx.cs" Inherits="FilmyProject.criticsManagment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/criticsManagment.css" rel="stylesheet" />
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
                        <asp:TextBox ID="emailBox" runat="server" TextMode="Email" class="input2" placeholder="Email"></asp:TextBox>
                    </div>
                    <div class="row divide">
                        <asp:TextBox ID="first_nameBox" runat="server" class="input1" placeholder="First Name"></asp:TextBox>
                        <asp:TextBox ID="last_nameBox" runat="server" class="input1 margin-left" placeholder="Last Name"></asp:TextBox>
                    </div>
                    
                    <div class="row">
                        <asp:TextBox ID="usernameBox" runat="server" class="input3" placeholder="Username"></asp:TextBox>
                        <asp:Button ID="findBtn" runat="server" class="find margin-left" Text="Find"/>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="birth_dateBox" runat="server" TextMode="Date" class="input2 date"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="countryBox" runat="server" class="input2" placeholder="Country"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="phoneBox" runat="server" TextMode="Phone" class="input2" placeholder="Phone No"></asp:TextBox>
                    </div>
                    <div class="row textarea">
                        <asp:TextBox ID="descriptionBox" runat="server" TextMode="MultiLine" Rows="4" class="input2" placeholder="Tell about yourself"></asp:TextBox>
                    </div>
                    <div class="row buttons">
                        <asp:Button ID="updateBtn" runat="server" class="input2 update" Text="Update"/>
                        <asp:Button ID="deleteBtn" runat="server" class="input2 delete" Text="Delete"/>
                    </div>
                </div>
            </div>
            <div class="main-table-wrapper">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [critics]"></asp:SqlDataSource>
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" class="table"></asp:GridView> <%--Table--%>
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
