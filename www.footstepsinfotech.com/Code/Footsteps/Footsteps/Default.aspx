<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Footsteps.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#slider')._TMS({
                banners: true,
                waitBannerAnimation: false,
                preset: 'diagonalFade',
                easing: 'easeOutQuad',
                pagination: false,
                duration: 400,
                slideshow: 8000,
                bannerShow: function (banner) {
                    banner.css({ marginRight: -500 }).stop().animate({ marginRight: 0 }, 600)
                },
                bannerHide: function (banner) {
                    banner.stop().animate({ marginRight: -500 }, 600)
                }
            })
        });
    </script>
    <div class="main">
        <div id="slider">
            <ul class="items">
                <li>
                    <img src='<%= Footsteps.Controller.Library.Constants.CookieLessDomain + "/Styles/images/1.png" %>'
                        alt="Slider Image 1" />
                    <div class="banner">
                        <span class="title"><span class="color2">We Have</span> <span class="color1">Propositions</span>
                            <span>For Everybody</span></span>
                        <p>
                        </p>
                        <!-- <a href="#" class="button1">Read More</a> -->
                    </div>
                </li>
                <li>
                    <img src='<%= Footsteps.Controller.Library.Constants.CookieLessDomain + "/Styles/images/2.png" %>'
                        alt="Slider Image 2" />
                    <div class="banner">
                        <span class="title"><span class="color2">Fresh Ideas</span> <span class="color1">For&nbsp;
                            Growing</span><span>Your Business</span></span>
                        <p>
                        </p>
                        <!-- <a href="#" class="button1">Read More</a> -->
                    </div>
                </li>
                <li>
                    <img src='<%= Footsteps.Controller.Library.Constants.CookieLessDomain + "/Styles/images/3.png" %>'
                        alt="Slider Image 3" />
                    <div class="banner">
                        <span class="title"><span class="color2">The Best</span> <span class="color1">You Can&nbsp;
                            Find</span> <span>On The Web</span></span>
                        <p>
                        </p>
                        <!-- <a href="#" class="button1">Read More</a> -->
                    </div>
                </li>
            </ul>
        </div>
        <div class="article" id="HomeContent">
            <div class="wrapper">
                <div class="col1 marg_right_40">
                    <h2>
                        Consulting</h2>
                    <p>
                        Providing Software Consulting, Development Services and designing Software solutions
                        to <a href="http://www.aciworldwide.com" target="_blank">ACI Worldwide Inc.</a>
                    </p>
                </div>
                <div class="col1 marg_right_40">
                    <h2>
                        Solutions</h2>
                    <p>
                        Aimed at providing end to end solutions for automation and avoiding repetitive work
                        in the Manufacturing sector.
                    </p>
                </div>
                <div class="col1 marg_right_40">
                    <h2>
                        SEO & SMO</h2>
                    <p>
                        Using Google Maps in travel industry, we've build a custom build framework generate
                        web traffic currently 2 million monthly page views.
                    </p>
                </div>
                <div class="col1">
                    <h2>
                        Services</h2>
                    <ul class="servicesList">
                        <li>Web Development</li>
                        <li>Mobile Development</li>
                        <li>Technical Consulting</li>
                        <li>Open Source Frameworks</li>
                        <li>Microsoft Technologies</li>
                    </ul>
                </div>
                <div class="clearfix">
                </div>
            </div>
        </div>
    </div>
    <div class="bg1">
        <div class="main">
            <div class="article">
                <div class="wrapper">
                    <div class="col2 marg_right_40">
                        <h3>
                            Welcome to Our Company!</h3>
                        <div class="wrapper">
                            <div id="figure" class="marg_right_40">
                                <img src='<%= Footsteps.Controller.Library.Constants.CookieLessDomain + "/Styles/images/page1_img1.jpg" %>'
                                    alt="hand shake image" />
                            </div>
                            <p class="color2 pad_bottom_12">
                                At Footsteps Infotech Inc., we aim at providing powerful, IT solutions for small
                                to mid-sized businesses – and make our products user friendly and easy to use.</p>
                            <p>
                                It’s our business to help you succeed, overcoming the day to day challenges. We
                                understand these challenges and opportunities and help you grow saving you of time
                                and money. We believe in keeping things simple; offering you expert help and resources
                                should you need them.</p>
                        </div>
                        <p>
                            We believe in the power of creativity; hence we take a creative approach to address
                            the needs of our customers for a better tomorrow, helping our customers Grow making
                            day to day operations smoother. Perfect Combination of Strong Management focus,
                            Breath of Capabilities, and Flexibility is what makes our Customer Relationships
                            a Success story.</p>
                        <!-- <a href="#" class="button1">Read More</a> -->
                    </div>
                    <div id="productsColumn" class="col1">
                        <h3>
                            Products</h3>
                        <ul class="productsList">
                            <li><span class="color1">Global solutions</span><br />
                                Providing Global Solutions in the travel industry.</li>
                            <li><span class="color1">Product Development</span><br />
                                Our Qualified teams aim at building resuable frameworks.</li>
                            <li><span class="color1">Progressive Research</span><br />
                                Our research of Web trends is with SEO centric approach.</li>
                            <li><span class="color1">New Technologies</span><br />
                                With ever changing Market trends, new technologies are a must.</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
