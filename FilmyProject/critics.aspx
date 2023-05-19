<%@ Page Title="" Language="C#" MasterPageFile="~/Filmy.Master" AutoEventWireup="true" CodeBehind="critics.aspx.cs" Inherits="FilmyProject.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/movies_critics.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="grid-container">
            <div class="grid-item">
                <div class="content-grid-img">
                    <img class="content-grid-img" src="../images/critics/roger_ebert.jpg" alt="">
                </div>
            </div>
            <div class="grid-item">
                <div class="content-grid-item-main">
                    <div class="content-grid-header">
                        <h1 class="content-grid-header-text">
                            Roger Ebert
                        </h1>
                    </div>
                    <div class="content-grid-body">
                        <ul class="content-grid-body-list">
                            <li>Born: June 18, 1942</li>
                            <li>Died: April 4, 2013 (age 70)</li>
                            <li>Years active: 1967-2013</li>
                            <li>Notable awards: Pulitzer Prize for Criticism</li>
                            <li>Education: <span>University of Illinois, Urbana-Champaign (BA), University of Chicago</span></li>
                            <li>Notable works: Sneak Previews, At the Movies, The Great Movies, Beyond the Valley of the Dolls, Life Itself: A Memoir</li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="grid-item">
                <div class="content-grid-img">
                    <img class="content-grid-img" src="../images/critics/kenneth_turan.jpg" alt="">
                </div>
            </div>
            <div class="grid-item">
                <div class="content-grid-item-main">
                    <div class="content-grid-header">
                        <h1 class="content-grid-header-text">
                            Kenneth Turan
                        </h1>
                    </div>
                    <div class="content-grid-body">
                        <ul class="content-grid-body-list">
                            <li>Born: October 27, 1946</li>
                            <li>Died: Alive (age 76)</li>
                            <li>Years active: 1991-2020</li>
                            <li>Notable awards: 2006: Special Citation. National Society of Film Critics Awards.</li>
                            <li>Education: <span>B.A. Swarthmore College, M.A. Columbia University</span></li>
                            <li>Notable works: Not to Be Missed, Free for All, Now In Theaters Everywhere, Never Coming To A Theater Near You, Sundance to Sarajevo</li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="grid-item">
                <div class="content-grid-img">
                    <img class="content-grid-img" src="../images/critics/mark_kermode.jpg" alt="">
                </div>
            </div>
            <div class="grid-item">
                <div class="content-grid-item-main">
                    <div class="content-grid-header">
                        <h1 class="content-grid-header-text">
                            Mark Kermode
                        </h1>
                    </div>
                    <div class="content-grid-body">
                        <ul class="content-grid-body-list">
                            <li>Born: July 2, 1963</li>
                            <li>Died: Alive (age 59)</li>
                            <li>Years active: 1992-Today</li>
                            <li>Notable awards: Best Specialist Contributor of the Year, Speech Award</li>
                            <li>Education: <span>Haberdashers' Aske's Boys' School</span></li>
                            <li>Notable works: Kermode's best films of the year, Kermode's best films of the decade</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
