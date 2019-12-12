<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Careers.aspx.cs" Inherits="Footsteps.Careers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--content -->
    <div class="main">
        <div class="article" id="content">
            <div class="wrapper">
                <div class="careersCol1">
                    <h2>
                        Work with Us</h2>
                    <div class="wrapper">
                        <div class="careersCol3 marg_right_40">
                            <div class="wrapper">
                                <span class="dropcap_1">1</span>
                                <p class="color1 no_pad">
                                    Love Challenges? Come On! Test yourself.
                                </p>
                            </div>
                            <p class="pad_bottom_12">
                                Footsteps Infotech is one of the perfect places to start your career from. You are
                                responsible for what you deliver giving you the freedom to choose the way to work.
                            </p>
                            <div class="wrapper">
                                <span class="dropcap_1">2</span>
                                <p class="color1 no_pad">
                                    Friendly Environment and Work Culture</p>
                            </div>
                            <p class="pad_bottom_12">
                                With don't want you to work for us; but we certainly want you to work with us. None
                                of us are seniors and juniors; we believe in working together as a team for a common
                                goal, Customer Satisfaction!</p>
                        </div>
                        <div class="careersCol3">
                            <div class="wrapper">
                                <span class="dropcap_1">3</span>
                                <p class="color1 no_pad">
                                    Be a Growing fish in a Growing pond.</p>
                            </div>
                            <p class="pad_bottom_12">
                                The trends have changed. Nobody wants to be a Big fish in a small pond or a Small
                                fish in a Big pond. Everyone now wants to be a Growing Fish in a Growing Pond.</p>
                            <div class="wrapper">
                                <span class="dropcap_1">4</span>
                                <p class="color1 no_pad">
                                    Process Automation and No Manual Efforts.</p>
                            </div>
                            <p class="pad_bottom_12">
                                We believe in freedom for employees with no restrictions. With minimum hassels,
                                we aim at automizing most of processes, reducing manual efforts, so that the primary
                                focus is on doing what you Love.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="careersCol2 marg_left1">
                    <h2>
                        Work Life Balance</h2>
                    <div class="figure pad_bottom_12">
                        <img src='<%= Footsteps.Controller.Library.Constants.CookieLessDomain + "/Styles/images/careers.png" %>'
                            alt="" /></div>
                    <p>
                        <span class="color2">Maintain the Perfect Work Life Balance That you always Dreamt Of.</span><br />
                        Interested in working with Footsteps Infotech? <a href="/Account/Register.aspx" title="Apply here"
                            rel="nofollow">Apply Here</a>.
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="bg1">
        <div class="main">
            <div class="article" id="content2">
                <div class="wrapper">
                    <h3>
                        Team Members Speak</h3>
                    <div class="col3 marg_right_40">
                        <div class="figure marg_right2">
                            <img src='<%= Footsteps.Controller.Library.Constants.CookieLessDomain + "/Styles/images/male.jpg" %>'
                                alt="" /></div>
                        <p>
                            “It’s been almost 2 years that I have been working here and it has been an excellent
                            journey. It has helped me develop myself both personally and professionally. An
                            excellent Work environment and equal work culture where every one is just eager
                            to help and provide their support with all guidance from like Corporate Culture,
                            Time Management, Goal Setting, Email Writing Skills and Much more!" <span class="signature">
                                <strong>Sujeet Kumar</strong> Sr. Designer</span>
                        </p>
                    </div>
                    <div class="col3">
                        <div class="figure marg_right2">
                            <img src='<%= Footsteps.Controller.Library.Constants.CookieLessDomain + "/Styles/images/mithil.png" %>'
                                alt="" /></div>
                        <p>
                            "A highly focused company, very clear about its vision and mission has always provided
                            me with the opportunities and challenges beyond my current role to prove myself
                            and achieve greater heights, each and every time. An Open culture, Great work environment,
                            and most importantly a sense of belonging towards the Employees has formed a perfect
                            combination for my Future Growth." <span class="signature"><strong>Mithil Shah</strong>
                                Sr. Engineer</span>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
