﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="criticsManagment.aspx.cs" Inherits="FilmyProject.criticsManagment" UnobtrusiveValidationMode="None"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/criticsManagment.css" rel="stylesheet" />
    <script src="js/criticsManagementValidation.js"></script>
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
                        <asp:TextBox ID="emailBox" runat="server" TextMode="Email" class="input2" placeholder="Email" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="row divide">
                        <asp:TextBox ID="first_nameBox" runat="server" class="input1" placeholder="First Name" ClientIDMode="Static"></asp:TextBox>
                        <asp:TextBox ID="last_nameBox" runat="server" class="input1 margin-left" placeholder="Last Name" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="usernameBox" runat="server" class="input3" placeholder="Username" ClientIDMode="Static" required="required"></asp:TextBox>
                        <asp:Button ID="findBtn" runat="server" class="find margin-left" Text="Find" OnClick="findBtn_Click"/>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="birth_dateBox" runat="server" TextMode="Date" class="input2 date" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="countryBox" runat="server" class="input2" placeholder="Country" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="phoneBox" runat="server" TextMode="Phone" class="input2" placeholder="Phone No" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="pendingBox" runat="server" class="input2" placeholder="Pending" ClientIDMode="Static"></asp:TextBox>
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
                        <asp:Button ID="updateBtn" runat="server" class="input2 update" Text="Update" OnClick="updateBtn_Click"  OnClientClick="return validateForm();"/>
                        <asp:Button ID="deleteBtn" runat="server" class="input2 delete" Text="Delete" OnClick="deleteBtn_Click"/>
                    </div>

                </div>
            </div>
            <div class="main-table-wrapper">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [critics]"></asp:SqlDataSource>
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" class="table" style="background-color: white;"></asp:GridView> <%--Table--%>
                <div class="main-table-item">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
