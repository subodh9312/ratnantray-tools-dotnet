<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Solutions.aspx.cs" Inherits="Footsteps.Solutions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--content -->
    <div class="main">
        <div class="article" id="content">
            <div class="wrapper">
                <div class="solutionsCol1 marg_right_40">
                    <h2>
                        Full Support</h2>
                    <div id="figure" class="pad_bottom_12">
                        <img src='<%= Footsteps.Controller.Library.Constants.CookieLessDomain + "/Styles/images/page3_img1.jpg" %>'
                            alt="" /></div>
                        <div class="clearfix"></div>
                    <p>
                        <span class="color2">Full Dedication to Our Clients’ Success and Post Sales Support</span><br />
                        We view ourselves as a vital part of our Client’s Success and feel that our growth
                        hinges on them being successful. Our High Client-Retention rate has been attributed
                        due to our responsiveness to their marketing needs.</p>
                </div>
                <div class="solutionsCol2">
                    <h2>
                        Why Choose Us</h2>
                    <div class="wrapper">
                        <div class="solutionsCol3 marg_right_40">
                            <div class="wrapper">
                                <span class="dropcap_1">1</span>
                                <p class="color1 no_pad">
                                    Flexible, Reliable and Innovative Vision</p>
                                <div class="clearfix">
                                </div>
                            </div>
                            <p class="pad_bottom_12">
                                We listen and learn and guarantee that you won’t be put into a box, because we encourage
                                innovation and outlook for different ways to look at things.</p>
                            <div class="wrapper">
                                <span class="dropcap_1">2</span>
                                <p class="color1 no_pad">
                                    Our continues pursuit for Excellence</p>
                                <div class="clearfix">
                                </div>
                            </div>
                            <p class="pad_bottom_12">
                                Our proven success is built upon mutual respect and a Result Oriented Approach that
                                lets us consistently accomplish what we promise and exceed our customer’s expectations.</p>
                        </div>
                        <div class="solutionsCol3">
                            <div class="wrapper">
                                <span class="dropcap_1">3</span>
                                <p class="color1 no_pad">
                                    Talented Designers & Expert Developers</p>
                                <div class="clearfix">
                                </div>
                            </div>
                            <p class="pad_bottom_12">
                                Our dedicated team of designers and developers have years of experience creating
                                visually appealing, SEO optimized, and importantly maintainable solutions.</p>
                            <div class="wrapper">
                                <span class="dropcap_1">4</span>
                                <p class="color1 no_pad">
                                    Our Websites are SEO optimized and Easy to Manage</p>
                                <div class="clearfix">
                                </div>
                            </div>
                            <p class="pad_bottom_12">
                                Our scalable and easy to manage framework, builds user friendly and visually appealing
                                websites. We provide you with training on how to manage your site with Maintenance
                                Services, if required.
                            </p>
                        </div>
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
                        Customer Testimonials</h3>
                    <div class="col3 marg_right_40">
                        <div class="figure marg_right_40">
                            <img src='<%= Footsteps.Controller.Library.Constants.CookieLessDomain + "/Styles/images/page3_img2.jpg" %>'
                                alt="" /></div>
                        <p>
                            “We had a great experience working with their skilled and friendly staff. Communication
                            was pro-actively and always excellent and at every stage we were made to feel like
                            we were in the best of hands." <span class="signature"><strong>Ajit Kumar</strong> Director,
                                Indus Infracon Pvt Ltd</span>
                        </p>
                    </div>
                    <div class="col3">
                        <div class="figure marg_right_40">
                            <img src='<%= Footsteps.Controller.Library.Constants.CookieLessDomain + "/Styles/images/page3_img3.jpg" %>'
                                alt="" /></div>
                        <p>
                            “The software you wrote for us has saved us a lot of headaches and time. We needed
                            something that would work quickly, and with minimal chance for error and you did
                            it. I consider it 110% success.” <span class="signature"><strong>Aditya Shah</strong>
                                Proprietor, Aachal Imports</span>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--content end-->
</asp:Content>
