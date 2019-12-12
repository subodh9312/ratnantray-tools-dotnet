<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="AboutUs.aspx.cs" Inherits="Footsteps.WebPages.AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <!--content -->
        <div class="article" id="content">
            <div class="wrapper">
                <div class="companyCol2 marg_right_40">
                    <h2>
                        Who We Are</h2>
                    <div class="wrapper">
                        <div id="figure" class="marg_right_40">
                            <img src='<%= Footsteps.Controller.Library.Constants.CookieLessDomain + "/Styles/images/page2_img1.jpg" %>'
                                alt="" /></div>
                        <p class="color2 pad_bottom_12">
                            We are a group of geeks, net surfers, creative and fun loving Wolverine-wannabes.</p>
                        <p>
                            We are Committed to helping our customers bring their products to market quicker;
                            and at the same time reducing overall system development costs.
                        </p>
                    </div>
                    <p>
                        We built on our reputation providing a superior technology, innovative software
                        solutions and most importantly post sales Support. Our engineering and project management
                        support services distinguishes makes us stand out. If you haven’t already had an
                        opportunity to hear about the Footsteps Group, we encourage you to ask someone who
                        has.</p>
                    <%-- <a href="#" class="button1">Read More</a> --%>
                </div>
                <div class="companyCol1">
                    <h2>
                        Why Choose Us</h2>
                    <div class="wrapper">
                        <span class="dropcap_1">1</span>
                        <p class="pad_bottom_12">
                            <span class="color1">Flexible and Reliable</span><br />
                            We encourage innovation and new outlook to look at things.</p>
                    </div>
                    <div class="wrapper">
                        <span class="dropcap_1">2</span>
                        <p class="pad_bottom_12">
                            <span class="color1">Strives For Excellence</span><br />
                            Our thurst lets us consistently exceed Client’s expectations.</p>
                    </div>
                    <div class="wrapper">
                        <span class="dropcap_1">3</span>
                        <p class="pad_bottom_12">
                            <span class="color1">Talented Designers & Developers</span><br />
                            Experienced Experts in building visually appealing solutions.</p>
                    </div>
                    <div class="wrapper">
                        <span class="dropcap_1">4</span>
                        <p class="pad_bottom_12">
                            <span class="color1">Privately Owned</span><br />
                            Enabling us to maintain a non-bureaucratic atmosphere.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="bg1">
        <div class="main">
            <div class="article" id="content2">
                <div class="wrapper">
                    <h3>
                        Our Products</h3>
                    <div class="col1 marg_right_40 pad_bottom_12">
                        <h3 class="color1">
                            My Route Map</h3>
                        <p class="color2">
                            Your personal Travel Guide!</p>
                        <p>
                            Complete Travel Companion with features like customizable driving directions, travel
                            destinations along your way, User reviews, routes options, and Much More!</p>
                        <a href="http://www.myroutemap.com" target="_blank" title="Home - My Route Map" class="button1">
                            Read More</a>
                        <br />
                    </div>
                    <div class="col1 marg_right_40">
                        <h3 class="color1">
                            Cost It</h3>
                        <p class="color2">
                            Production Cost Estimator!</p>
                        <p>
                            Complete Costing solution for manufacturing sector, based on various factors like
                            rejection ratio, price increase, Customer specific discount, Graphical reports,
                            etc.</p>
                        <a href="http://www.costit.in" title="Cost it - Demo" class="button1">Read More</a>
                        <br />
                        <br />
                    </div>
                    <div class="col1 marg_right_40">
                        <h3 class="color1">
                            Aachal Imports</h3>
                        <p class="color2">
                            An Online Store!</p>
                        <p>
                            A Dynamic web protal for helping a Local Business go online, where administrator
                            can add and manage product, images with content staging, etc. and Much More!
                            <%--A
    dynamic eCommerce web-portal where administrator can add products, images, with
    Content Staging, etc. Support Desk, Live Chat and Much more!--%></p>
                        <a href="http://www.aachalimports.com" title="Home - Aachal Imports" class="button1">
                            Read More</a>
                        <br />
                        <br />
                    </div>
                    <div class="col1">
                        <h3 class="color1">
                            Address Book</h3>
                        <p class="color2">
                            Personal Contact Manager</p>
                        <p>
                            A Complete Contacts Manager, where you can print labels in various sizes, Imports
                            Contacts in CSV format, Export in Excel format, Email Contacts, Send Bulk Emails,
                            etc.
                        </p>
                        <a href="/WebPages/ContactUs.aspx" class="button1" title="Request a Demo">Demo Request</a>
                        <br />
                    </div>
                </div>
            </div>
            <div class="clearfix">
                <br />
            </div>
        </div>
    </div>
    <!--content end-->
</asp:Content>
