<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Services.aspx.cs" Inherits="Footsteps.Services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--content -->
    <div class="main">
        <div class="article" id="content">
            <div class="wrapper">
                <h2>
                    Services Overview</h2>
                <div class="servicesCol1 marg_right_40">
                    <div class="wrapper">
                        <div class="figure marg_right2">
                            <img src='<%= Footsteps.Controller.Library.Constants.CookieLessDomain + "/Styles/images/page4_img1.jpg" %>'
                                alt="" /></div>
                        <p>
                            <span class="color1">Global Solutions</span><br />
                            Offering solutions to various cultures and traditions across the globe.</p>
                    </div>
                    <div class="wrapper">
                        <div class="figure marg_right2">
                            <img src='<%= Footsteps.Controller.Library.Constants.CookieLessDomain + "/Styles/images/page4_img2.jpg" %>'
                                alt="" /></div>
                        <p>
                            <span class="color1">Consulting Services</span><br />
                            Providing Consultancy Services to MnCs for Corporate Banking Solutions
                        </p>
                    </div>
                </div>
                <div class="servicesCol1 marg_right_40">
                    <div class="wrapper">
                        <div class="figure marg_right2">
                            <img src='<%= Footsteps.Controller.Library.Constants.CookieLessDomain + "/Styles/images/page4_img3.jpg" %>'
                                alt="" /></div>
                        <p>
                            <span class="color1">Domain Registrations</span><br />
                            Domain name registration and Email hosting, through trusted Domain registras.</p>
                    </div>
                    <div class="wrapper">
                        <div class="figure marg_right2">
                            <img src='<%= Footsteps.Controller.Library.Constants.CookieLessDomain + "/Styles/images/page4_img4.jpg" %>'
                                alt="" /></div>
                        <p>
                            <span class="color1">Web Hosting Solutions</span><br />
                            Windows and Linux web hosting solutions tailor-made to suit your online traffic.
                        </p>
                    </div>
                </div>
                <div id="last" class="servicesCol1">
                    <div class="wrapper">
                        <div class="figure marg_right2">
                            <img src='<%= Footsteps.Controller.Library.Constants.CookieLessDomain + "/Styles/images/page4_img6.jpg" %>'
                                alt="" /></div>
                        <p>
                            <span class="color1">Mobile Development</span><br />
                            Mobile application development for mobile platforms like Windows, Android, etc.</p>
                    </div>
                    <div class="wrapper">
                        <div class="figure marg_right2">
                            <img src='<%= Footsteps.Controller.Library.Constants.CookieLessDomain + "/Styles/images/page4_img5.jpg" %>'
                                alt="" /></div>
                        <p>
                            <span class="color1">Application Development</span><br />
                            Windows and Web development for Windows and Linux platforms.</p>
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
                        Main Services</h3>
                    <div class="col1 marg_right_40">
                        <div class="wrapper">
                            <span class="dropcap_1">A</span>
                            <p class="color2 pad_bot1">
                                Search Engine Optimisation</p>
                        </div>
                        <p>
                            Our complete keyword research and analysis, makes sure you make your online presence
                            felt with quaranteed increase in online traffic.</p>
                    </div>
                    <div class="col1 marg_right_40">
                        <div class="wrapper">
                            <span class="dropcap_1">B</span>
                            <p class="color2 pad_bot1">
                                Product Development<br />
                                Planning & Execution</p>
                        </div>
                        <p>
                            We constantly aim at making life easier for day to day operations making maximum
                            use of technology. We build our own products making life easier for us and our clients.</p>
                    </div>
                    <div class="col1 marg_right_40">
                        <div class="wrapper">
                            <span class="dropcap_1">C</span>
                            <p class="color2 pad_bot1">
                                Software Consulting<br />
                                Services</p>
                        </div>
                        <p>
                            Providing Software Consulting Services for development of Corporate Banking Solutions
                            for S1 Services Pvt. Ltd and ACI Worldwide Payment Systems, etc.</p>
                    </div>
                    <div class="col1">
                        <div class="wrapper">
                            <span class="dropcap_1">D</span>
                            <p class="color2 pad_bot1">
                                Market<br />
                                Research</p>
                        </div>
                        <p>
                            We do a full market analysis of our client Business including competitor analysis.
                            This enables us to provide competitive solutions to our clients.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--content end-->
</asp:Content>
