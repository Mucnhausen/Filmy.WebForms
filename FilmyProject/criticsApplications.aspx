<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="criticsApplications.aspx.cs" Inherits="FilmyProject.criticsApplications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/criticsManagment.css" rel="stylesheet" />

    <style>
        .readonly {
            background-color: #e7e1e1 !important;
            color: black !important;
        }
        .readonly::placeholder {
            background-color: #e7e1e1 !important;
            color: black !important;
        }
    </style>
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
                        <asp:TextBox ID="emailBox" runat="server" TextMode="Email" class="input2 readonly" placeholder="Email" ReadOnly></asp:TextBox>
                    </div>
                    <div class="row divide">
                        <asp:TextBox ID="first_nameBox" runat="server" class="input1 readonly" placeholder="First Name" ReadOnly></asp:TextBox>
                        <asp:TextBox ID="last_nameBox" runat="server" class="input1 margin-left readonly" placeholder="Last Name" ReadOnly></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="usernameBox" runat="server" class="input3" placeholder="Username"  required="required"></asp:TextBox>
                        <asp:Button ID="findBtn" runat="server" class="find margin-left" Text="Find" OnClick="findBtn_Click"/>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="birth_dateBox" runat="server" TextMode="Date" class="input2 date readonly" ReadOnly></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="countryBox" runat="server" class="input2 readonly" placeholder="Country" ReadOnly></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="phoneBox" runat="server" TextMode="Phone" class="input2 readonly" placeholder="Phone No" ReadOnly></asp:TextBox>
                    </div>
                    <div class="row textarea">
                        <asp:TextBox ID="descriptionBox" runat="server" TextMode="MultiLine" Rows="4" class="input2 readonly" placeholder="Tell about yourself" ReadOnly></asp:TextBox>
                    </div>
                    <div class="row buttons">
                        <asp:Button ID="addBtn" runat="server" class="input2 add" Text="Accept" OnClick="addBtn_Click"/>
                        <asp:Button ID="deleteBtn" runat="server" class="input2 delete" Text="Decline" OnClick="deleteBtn_Click"/>
                    </div>
                </div>
            </div>
            <div class="main-table-wrapper">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [username], [first_name], [last_name], [reg_date], [birth_date], [country], [tel], [email], [description], [image_path], [password] FROM [critics] WHERE pending = 'processing' ">
                </asp:SqlDataSource>
                <asp:GridView ID="GridView1" runat="server" class="table" DataSourceID="SqlDataSource1"></asp:GridView> <%--Table--%>
                <div class="main-table-item"></div>
            </div>
        </div>
    </div>
</asp:Content>
