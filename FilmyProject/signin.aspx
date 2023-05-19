<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="FilmyProject.signin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/signin.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="main">
            <div class="main-form">
                <div class="slogan">
                    <h1 class="slogan-text">Critic, fill your credits!</h1>
                </div>
                <div class="form" action="">
                    <div class="row divide">
                        <asp:TextBox ID="emailBox" runat="server" TextMode="Email" class="input1" placeholder="Email"></asp:TextBox>
                        <asp:TextBox ID="passwordBox" runat="server" TextMode="Password" class="input1 margin-left" placeholder="Password"></asp:TextBox>
<%--                        <input type="text" class="input1" placeholder="Email" autofocus>
                        <input type="text" class="input1 margin-left" placeholder="Password">--%>
                    </div>
                    <div class="row divide">
                        <asp:TextBox ID="first_nameBox" runat="server" class="input1" placeholder="First Name"></asp:TextBox>
                        <asp:TextBox ID="last_nameBox" runat="server" class="input1 margin-left" placeholder="Last Name"></asp:TextBox>
<%--                        <input type="text" class="input1" placeholder="First Name">
                        <input type="text" class="input1 margin-left" placeholder="Last Name">--%>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="usernameBox" runat="server" class="input2" placeholder="Username"></asp:TextBox>
                        <%--<input type="text" class="input2" placeholder="Username">--%>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="birth_dateBox" runat="server" TextMode="Date" class="input2 date"></asp:TextBox>
                        <%--<input type="date" class="input2 date">--%>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="countryBox" runat="server" class="input2" placeholder="Country"></asp:TextBox>
                        <%--<input type="text" class="input2" placeholder="Country">--%>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="phoneBox" runat="server" TextMode="Phone" class="input2" placeholder="Phone No"></asp:TextBox>
                        <%--<input type="text" class="input2" placeholder="Phone No">--%>
                    </div>
                    <div class="row textarea">
                        <asp:TextBox ID="descriptionBox" runat="server" TextMode="MultiLine" Rows="4" class="input2" placeholder="Tell about yourself"></asp:TextBox>
                        <%--<input type="text" class="input2" placeholder="Tell about yourself">--%>
                    </div>
                    <div class="row">
                        <asp:Button ID="submitBtn" runat="server" class="input2 submit" Text="Submit"/>
                        <%--<input type="submit" class="input2 submit">--%>
                    </div>
                </div>
            </div>
            <div class="main-image-wrapper">
                <div class="main-image-item"></div>
            </div>
        </div>
    </div>
</asp:Content>
