<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="criticsProfile.aspx.cs" Inherits="FilmyProject.criticsProfile" UnobtrusiveValidationMode="None"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/criticsProfile.css" rel="stylesheet" />
    <script src="js/criticsProfileValidator.js"></script>
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
                        <asp:TextBox ID="emailBox" runat="server" TextMode="Email" class="input2" placeholder="Email" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="row divide">
                        <asp:TextBox ID="first_nameBox" runat="server" class="input1" placeholder="First Name" ClientIDMode="Static"></asp:TextBox>
                        <asp:TextBox ID="last_nameBox" runat="server" class="input1 margin-left" placeholder="Last Name" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    
                    <div class="row">
                        <asp:TextBox ID="usernameBox" runat="server" class="input2" placeholder="Username" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="passwordBox" runat="server" TextMode="Password" class="input3" placeholder="Password" ClientIDMode="Static"></asp:TextBox>
                        <asp:Button ID="savePasswordBtn" runat="server" class="savePassword margin-left" Text="Save" OnClick="savePasswordBtn_Click" OnClientClick="return validatePassword();"/>
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
                    <div class="row textarea">
                        <asp:TextBox ID="descriptionBox" runat="server" TextMode="MultiLine" Rows="4" class="input2" placeholder="Tell about yourself" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="row buttons">
                        <asp:Button ID="updateBtn" runat="server" class="input2 update" Text="Update" OnClick="updateBtn_Click" OnClientClick="return validateForm();"/>
                    </div>
                </div>
            </div>
            <div class="main-picture bottom">
                <div class="image-wrapper">
                    <asp:Image ID="Image1" runat="server" ImageUrl="images\main_content\critic_default.png" Width="360px" Height="512px" class="image"/>
                </div>
                <div class="row buttons ">
                    <asp:FileUpload ID="FileUpload1" runat="server" accept=".png,.jpg,.jpeg" style="padding-top: 6px;" class=""/>
                    <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                             ControlToValidate="FileUpload1"
                             ErrorMessage="Only images are allowed" 
                             ValidationExpression="(.*?)\.(jpg|jpeg|png|JPG|JPEG|PNG)$"
                             style="display: none" >
                    </asp:RegularExpressionValidator>
                    <asp:Button ID="UploadBtn" runat="server" class="upload input5 " Text="Upload" OnClick="UploadBtn_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
