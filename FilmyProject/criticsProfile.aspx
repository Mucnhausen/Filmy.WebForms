﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="criticsProfile.aspx.cs" Inherits="FilmyProject.criticsProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/criticsProfile.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="main">
            <div class="main-form">
                <div class="slogan">
                    <h1 class="slogan-text">Hee, it's you!</h1>
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
                        <asp:TextBox ID="usernameBox" runat="server" class="input2" placeholder="Username"></asp:TextBox>
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
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>