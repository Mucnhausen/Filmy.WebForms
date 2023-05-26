<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="reviewsManagment.aspx.cs" Inherits="FilmyProject.reviewsManagment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/reviewsManagment.css" rel="stylesheet" />
    <link href="css/dropdownlist.css" rel="stylesheet" />

    <script src="ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js"></script>

    <script>
        $(document).ready(function ()
        {
            $(".dropdownlist").select2();
            $('.dropdownlist').one('select2:open', function (e) {
                $('input.select2-search__field').prop('placeholder', 'Type to search');
                $('input.select2-search__field').addClass('placeholder-class');
            });
            
        });
    </script>
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
                        <asp:TextBox ID="idBox" runat="server" class="input3" placeholder="Review ID"></asp:TextBox>
                        <asp:Button ID="findBtn" runat="server" class="find margin-left" Text="Find" OnClick="findBtn_Click"/>
                    </div>
                    <div class="row">
                        <asp:SqlDataSource ID="DropDownList_SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [movie_name] FROM [movies]"></asp:SqlDataSource>
                        <asp:DropDownList ID="DropDownList1"  runat="server" class="input2 dropdownlist" DataSourceID="DropDownList_SqlDataSource" DataTextField="movie_name" DataValueField="movie_name" AppendDataBoundItems="true">
                            <asp:ListItem Value="-1">Movie Title</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="ratingBox" runat="server" TextMode="Number" class="input2" placeholder="Rating (1 - min, 10 - max)"></asp:TextBox>
                    </div>
                    <div class="row textarea">
                        <asp:TextBox ID="reviewBox" runat="server" TextMode="MultiLine" Rows="4" class="input2" placeholder="Review text"></asp:TextBox>
                    </div>
                    <div class="row buttons">
                        <asp:Button ID="updateBtn" runat="server" class="input2 update" Text="Update" OnClick="updateBtn_Click"/>
                        <asp:Button ID="deleteBtn" runat="server" class="input2 delete" Text="Delete" OnClick="deleteBtn_Click"/>
                    </div>
                </div>
            </div>
            <div class="main-table-wrapper">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [reviews]"></asp:SqlDataSource>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" class="table">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="movie_id" HeaderText="movie_id" SortExpression="movie_id" />
                        <asp:BoundField DataField="critic_username" HeaderText="critic_username" SortExpression="critic_username" />
                        <asp:BoundField DataField="review_text" HeaderText="review_text" SortExpression="review_text" />
                        <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
                        <asp:BoundField DataField="rating" HeaderText="rating" SortExpression="rating" />
                    </Columns>
                </asp:GridView> <%--Table--%>
                <div class="main-table-item"></div>
            </div>
        </div>
    </div>
</asp:Content>
