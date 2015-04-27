<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Decode Agency | A Global Media and Communications Research Firm Primarily Servicing the African Markets.</title>
    <link href='http://fonts.googleapis.com/css?family=PT+Sans' rel='stylesheet' type='text/css'>
    <link href="styling/css/decode.css" rel="stylesheet"/>
    <link href="styling/css/reset.css" rel="stylesheet"/> 
    <meta charset="UTF-8" />
    <meta name="author" content="for Codrops" />
    <link rel="shortcut icon" href="../favicon.ico">
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link rel="stylesheet" type="text/css" href="css/style_alt.css" />
    <!--[if lt IE 9]>
    <link rel="stylesheet" type="text/css" href="css/style_ie.css" />
    <![endif]-->
    <!-- jQuery -->
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <!-- jmpress plugin -->
    <script type="text/javascript" src="js/jmpress.min.js"></script>
    <!-- jmslideshow plugin : extends the jmpress plugin -->
    <script type="text/javascript" src="js/jquery.jmslideshow.js"></script>
    <script type="text/javascript" src="js/modernizr.custom.48780.js"></script>
    <noscript>
        <style>
            .step {
                width: 100%;
                position: relative;
            }

                .step:not(.active) {
                    opacity: 1;
                    filter: alpha(opacity=99);
                    -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(opacity=99)";
                }

                    .step:not(.active) a.jms-link {
                        opacity: 1;
                        margin-top: 40px;
                    }

            .jms-arrows {
                display:none !Important;
            }
            
        </style>
    </noscript>
    <style>
        .divDecodeItemDescription ul, .divServices ul {
            margin-left:80px;
            margin-top:10px;
            float:left; 
            width:500px;           
        }
        .signupbtn {
            display:none !important
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="divTopBlackBar">
            <div class="Width960">
                <div class="divContent"><%--000 000 0000&nbsp;&nbsp;&nbsp;&nbsp;--%>+27 11 057 6764&nbsp;&nbsp;&nbsp;&nbsp;hello@decode.co.za</div>
            </div>
        </div>
        <div class="divMainMenu">
            <div class="Width960">                
                <div class="NavigationMenu navbar-default">
                    <ul>
                        <li><a id="aHome" href="#home">Home</a></li>
                        <li><a id="aAboutUs" href="#aboutus">About Us</a></li>
                        <li><a id="aServices" href="#services">Services</a></li>
                        <li><a id="aProduct" href="#product">Product</a></li>
                        <li style="display:none">Media List</li>
                        <li style="margin-right:0"><a id="aContactUs2" href="#contactus">Contact Us</a></li>
                    </ul>
                </div>
                <img src="styling/images/logo.jpg" style="  width: 185px;margin-top: 5px;" />
            </div>
        </div>
        <div class="divBannerImage" id="home">
            <div class="BannerContainer">
                <div class="container">
                    <section id="jms-slideshow" class="jms-slideshow">
                        <div class="step" data-color="color-1" data-x="2000" data-y="1000" <%--<%--data-z="3000"--%> data-rotate="20">
                            <div class="jms-content">
                                <h3>Say goodbye Media Monitoring and hello Media Intelligence</h3>
                                <p>We Decode your media coverage with real-time media tracking, analytics and human intelligence reporting – to, help businesses make sense of the impact of coverage, make informed decisions and manage risk.</p>
                                <a class="jms-link" id="aServices2" href="#services">Read more</a>&nbsp;&nbsp;<a class="jms-link signupbtn" href="#" style="display:none">Sign Up</a>
                            </div>
                            <img src="images/1.png" />
                        </div>
                        <div class="step" data-color="color-2" data-x="1000" <%--data-z="2000"--%> data-rotate="20">
                            <div class="jms-content">
                                <h3>For PR Professionals, Marketers and Companies</h3>
                                <p>Find and Connect with thousands of journalists & bloggers using social media in South Africa. Discover Decode’s FREE and up-to-date media directory.</p>
                                <a class="jms-link" id="aProduct2" href="#product">Read more</a>&nbsp;&nbsp;<a class="jms-link signupbtn" href="app/default.aspx">Sign Up</a>
                            </div>
                            <img src="images/2.png" />
                        </div>
                        <div class="step" data-color="color-3" data-x="2000" data-y="1500" <%--data-z="1000"--%> data-rotate="20">
                            <div class="jms-content">
                                <h3>Looking to create a buzz about your product or service</h3>
                                <p>Let Decode help you find journalists & bloggers covering topics relevant to you, your company, clients and campaigns. Decode distributes and explodes’ news.</p>
                                <a class="jms-link" id="aProduct3" href="#product">Read more</a>&nbsp;&nbsp;<a class="jms-link signupbtn" href="app/default.aspx">Sign Up</a>
                            </div>
                            <img src="images/3.png" />
                        </div>
                        <div class="step" data-color="color-4" data-x="3000" data-y="2000">
                            <div class="jms-content">
                                <h3>Connect with Media Influencers</h3>
                                <p>An up-to-date media list with correct and accurate journalist information is the foundation of any publicity and media relations’ effort. Discover Decode’s FREE and up-to-date media directory.</p>
                                <a class="jms-link" id="aProduct4" href="#product">Read more</a>&nbsp;&nbsp;<a class="jms-link signupbtn" href="app/default.aspx">Sign Up</a>
                            </div>
                            <img src="images/4.png" />
                        </div>
                        <div class="step" data-color="color-5" data-x="4000" data-y="1500" <%--data-z="1000"--%> data-rotate="-20">
                            <div class="jms-content">
                                <h3>Decode is your online PR sidekick</h3>
                                <p>Measure sentiment from your audiences, actively listen to social media conversations and increase message reach and impact. Decode PR software connects the dots between content, media and brands.</p>
                                <a class="jms-link" id="aServices3" href="#">Read more</a>
                            </div>
                            <img src="images/5.png" />
                        </div>
                    </section>
                </div>
                <script type="text/javascript">
                    $(function () {
                        var jmpressOpts = {
                            animation: { transitionDuration: '0.8s' }
                        };

                        $('#jms-slideshow').jmslideshow($.extend(true, { jmpressOpts: jmpressOpts }, {
                            autoplay: true,
                            bgColorSpeed: '0.8s',
                            arrows: false
                        }));

                    });
                </script>
                <%--<script src="http://tympanus.net/codrops/adpacks/demoad.js"></script>--%>
            </div> 
        </div>
        <div class="divConnect" id="aboutus">
            <div class="Width960">
                <h2>About Us</h2>
                <div class="HeaderDescription">Decode is a media intelligence agency that measures and analyses the media’s impact on public perception and behavior.</div>
                <div style="margin:0 auto;width: 871px">    
                    <div class="squareConnect"><div class="bigLetterC">C</div><div class="theRest">onnect</div><div class="Clear" style="margin-top:-20px"></div><div class="squareDescription">Decode will help you build and maintain media lists so you can find the right journalist to connect with and pitch media stories. Our media profiles include deep intelligence including pictures, biographies, media coverage, social media updates and recent activity.</div><div style="display:none" class="LearnMoreButton LearnMoreButtonC">Learn More</div></div>
                    <div class="squareConnect"><div class="bigLetterE">E</div><div class="theRest">ngage</div><div class="Clear"></div><div class="squareDescription">Create and deliver media rich press releases directly to the media influencers in your industry and amplify your messaged with your own online newsroom. Target your message effectively with our recommended contact lists based on your areas of interests and who has been writing about you.</div><div style="display:none" class="LearnMoreButton LearnMoreButtonE">Learn More</div></div>
                    <div class="squareConnect" style="margin-right:0"><div class="bigLetterM">M</div><div class="theRest">easure</div><div class="Clear"></div><div class="squareDescription">Our analytics make it possible to measure and report on the effectiveness of your communication and across all media. The interactive dashboards provide fast and intuitive access to metrics, topics, competitor tracking, share of voice using charts, visuals and reports</div><div style="display:none" class="LearnMoreButton LearnMoreButtonM">Learn More</div></div>
                </div>
            </div>            
        </div>
        <div class="divWhoWeAre">
            <div class="Width960">
                <h2>Who We Are</h2>
                <div class="HeaderDescription">Decode is an African media and communications research firm.</div>
                <div class="WhoWeAreItems">
                    <div class="WhoWeAreItem">
                        <div class="WhoWeAreItemImage"><img src="styling/images/WhoIcon1.png" /></div>
                        <div class="WhoWeAreItemDescription">As a technology-driven company, we optimise the use of media monitoring, tracking and analysis technologies to offer its clients clear understanding of the impact of media coverage.</div>
                    </div>
                    <div class="WhoWeAreItem">
                        <div class="WhoWeAreItemImage"><img src="styling/images/WhoIcon2.png" /></div>
                        <div class="WhoWeAreItemDescription">With our media analysis, we provide insights and strategic advice on effective approaches to media relations, corporate communications, brand reputation management and crisis communications management.</div>
                    </div>
                    <div class="WhoWeAreItem" style="margin-right:0;">
                        <div class="WhoWeAreItemImage"><img src="styling/images/WhoIcon3.png" /></div>
                        <div class="WhoWeAreItemDescription">Decode is uniquely positioned to offer clients’ strategic counsel and media strategies with effective rapid response systems that are <b>evidence-based; audience focused and tied to the clients’ priorities.</b></div>
                    </div>
                </div>
            </div>
        </div>
        <div id="services"  class="divServices">
            <div class="Width960">
                <h2>Our Services</h2>
                <div class="HeaderDescription">We believe that negative perceptions about a product, service or actions of an organisation have the power to influence a particular stakeholder group so strongly that their actions can place severe limitations on an organisation’s ability to achieve its goals.</div>
                <div class="divServiceItem">
                    <div class="divServiceItemIcon"><img src="styling/images/ServiceIcon2.png" /></div>
                    <div class="divServiceItemName">Media Contact Directory</div>
                    <div class="divServiceItemDescription">We help PR Professionals, Marketers and Companies find and connect with thousands of journalists & bloggers using social media in South Africa with our FREE and up-to-date media directory. Our up-to-date media list with correct and accurate journalist information includes topics relevant to you, your company, clients and campaigns</div>
                </div>
                <div class="divServiceItem">
                    <div class="divServiceItemIcon"><img src="styling/images/ServiceIcon3.png" /></div>
                    <div class="divServiceItemName">Real-time Media Monitoring, Tracking & Reporting</div>
                    <div class="divServiceItemDescription">We help clients stay informed on what is being said about them in the media. Our comprehensive real-time media monitoring covers national and international outlets including: Broadcast (TV and Radio), Print (Newspapers, Magazines, Trade Publications and Journals), Online – global (news sites, blogs and forums) and Social media – global. <%--We also offer 
                        <ul>
                            <li>Brand Launch Monitoring</li>
                            <li>Event Monitoring</li>
                            <li>Key Influencer Monitoring</li>
                            <li>Competitive Monitoring</li>
                        </ul>--%>
                    </div>
                </div>
                <div class="divServiceItem">
                    <div class="divServiceItemIcon"><img src="styling/images/ServiceIcon5.png" /></div>
                    <div class="divServiceItemName">Media Content Analysis</div>
                    <div class="divServiceItemDescription">We help clients effectively assess trends in coverage in the media, analyse national and international print, broadcast and online media coverage in particular the programmes and activities of the clients. We provide clients with market intelligence and Competitor analysis to inform their communications strategies and assess effectiveness of the communication messages </div>
                </div>
                <div class="divServiceItem">
                    <div class="divServiceItemIcon"><img src="styling/images/ServiceIcon4.png" /></div>
                    <div class="divServiceItemName">Risk & Crisis Communication Management</div>
                    <div class="divServiceItemDescription">We develop crises communication strategies and plans for effective reputation risk mitigation. We also train management teams for crises communications and issues management to improve anticipation</div>
                </div>
                <div class="divServiceItem">
                    <div class="divServiceItemIcon"><img src="styling/images/ServiceIcon8.png" /></div>
                    <div class="divServiceItemName">Media Training</div>
                    <div class="divServiceItemDescription">We provide media training for executive and communication specialists.</div>
                </div>
                <div class="divServiceItem">
                    <div class="divServiceItemIcon"><img src="styling/images/icon1.png" /></div>
                    <div class="divServiceItemName">Media Research</div>
                    <div class="divServiceItemDescription">We provide media research, analysis and insights to PR and communication companies. <%--Our offering consist of: 
                        <ul>
                            <li>Traditional Media Measurement</li>
                            <li>Event Measurement</li>
                            <li>PR Efficacy Measurement</li>
                            <li>Virality measurement</li>
                            <li>Launch/Event Media Measurement</li>
                            <li>Outreach Measurement</li>
                            <li>Influencers Assessment</li>
                            <li>Brand Assessment</li>
                            <li>Customer Segment Assessment</li>
                            <li>Reputation Assessment</li>
                            <li>On-going Brand Tracker</li>
                            <li>PR Effort Assessment</li>
                        </ul>--%>
                    </div>
                </div>
                <div class="divServiceItem">
                    <div class="divServiceItemIcon"><img src="styling/images/ServiceIcon7.png" /></div>
                    <div class="divServiceItemName">Strategy</div>
                    <div class="divServiceItemDescription">We develop media relations strategies and detailed plans for execution based on detailed trends analysis, research of client needs and background</div>
                </div>
                <div class="divServiceItem">
                    <div class="divServiceItemIcon"><img src="styling/images/ServiceIcon6.png" /></div>
                    <div class="divServiceItemName">Stakeholder Surveys</div>
                    <div class="divServiceItemDescription">We help clients measure stakeholder sentiment with our Stakeholders analysis and Category landscape assessment.</div>
                </div>
            </div>
        </div>
        <div class="divDecode" id="product">
            <div class="Width960">
                <h2><span style="text-transform:lowercase">i</span>Decode</h2>
                <div class="HeaderDescription" style="text-align:center">Africa’s first cloud-based PR software – Public access from 1st of May 2015!
                </div>
                <div class="divDecodeItems">
                    <div class="divDecodeItem">
                        <div class="divDecodeItemImage"><img src="styling/images/DecodeIcon1.png" /></div>
                        <div class="divDecodeItemName">Media Contact Directory</div>
                        <div class="divDecodeItemDescription">Decode provides the easiest way to build and maintain media lists. You're provided with hundreds of ways to query our database and then you can easily create lists that can even automatically update. Our media profiles include deep intelligence including pictures, biographies, media coverage, social media updates and recent activity. And we time-stamp the last time each contact was checked, so you know you're dealing with up-to-date data.
                            <ul style="display: inline-block;">
                                <li>Most accurate and comprehensive database</li>
                                <li>Deep profiles and intelligence</li>
                                <li>Track all your media interactions</li>
                                <li>Sophisticated search options</li>
                                <li>Automatic updating of media lists</li>
                            </ul>
                        </div>
                    </div>
                    <div class="Clear"></div>
                    <div class="divDecodeItem">
                        <div class="divDecodeItemImage" style="float:right;margin-right:0px;margin-left:20px"><img src="styling/images/DecodeIcon0.png" /></div>
                        <div class="divDecodeItemName">News Distribution</div>
                        <div class="divDecodeItemDescription">It's hard to believe that so many PR professionals are still sending press releases by BCC'ing emails from Outlook. Decode brings your news distribution processes into the modern-day allowing you to send personalised, measurable news distributions that easily incorporate images and rich formatting.
                            <ul>
                                <li>Send personalised emails</li>
                                <li>Tailor the message for every recipient</li>
                                <li>Track who opens and clicks on what</li>
                                <li>Generate reports and analytics</li>
                                <li>Easily adhere to spam regulations</li>
                            </ul>
                        </div>
                    </div>
                    <div class="Clear"></div>
                    <div class="divDecodeItem">
                        <div class="divDecodeItemImage"><img src="styling/images/DecodeIcon3.png" /></div>
                        <div class="divDecodeItemName">Editorial Opportunities</div>
                        <div class="divDecodeItemDescription">Calling around hundreds of publications to get features lists is a fate you wouldn't want to bestow on your worst enemy. Thankfully, with Decode you don't have to. Our research teams collects, enters and categorises features lists and editorial calendars from hundreds of outlets in South Africa. 
                            <ul style="display: inline-block;">
                                <li>Save time and money</li>
                                <li>Opportunities categorised and searchable</li>
                                <li>Tag opportunities for later reference</li>
                                <li>Exclusive 'media requests' on some beats</li>
                            </ul>
                        </div>
                    </div>
                    <div class="Clear"></div>
                    <div class="divDecodeItem">
                        <div class="divDecodeItemImage" style="float:right;margin-right:0px;margin-left:20px"><img src="styling/images/DecodeIcon2.png" /></div>
                        <div class="divDecodeItemName">Media Monitoring</div>
                        <div class="divDecodeItemDescription">Decode comes with online media monitoring built in it, at no additional cost. Our monitoring engine extracts coverage from thousands of South African websites and blogs to ensure you're on top of what is being said about your brand and products. Additionally, upgrade to a Premium Newsroom and you can add your own clips (online, print or broadcast) to your monitoring library and make use of our powerful analytics, charting and reporting.
                            <ul>
                                <li>Free online monitoring</li>
                                <li>Powerful charting and reporting</li>
                                <li>Advanced analytics and analysis</li>
                            </ul>
                        </div>
                    </div>
                    <div class="Clear"></div>
                    <div class="divDecodeItem">
                        <div class="divDecodeItemImage"><img src="styling/images/DecodeIcon3.png" /></div>
                        <div class="divDecodeItemName">Reporting & Analytics</div>
                        <div class="divDecodeItemDescription">Decode boasts the industry's most powerful and flexible reporting engine. We understand that every company has its own reporting needs, so our reporting engine has been built to enable simple template creation so even the most complex reports can be created at the click of a button.
                            <ul style="display: inline-block;">
                                <li>Coverage reports</li>
                                <li>Coverage summaries & alerts</li>
                                <li>Activity reporting</li>
                                <li>Release reports and statistics</li>
                            </ul>
                        </div>
                    </div>
                    <div class="Clear"></div>
                    <div class="divDecodeItem">
                        <div class="divDecodeItemImage" style="float:right;margin-right:0px;margin-left:20px"><img src="styling/images/DecodeIcon2.png" /></div>
                        <div class="divDecodeItemName">Collaboration</div>
                        <div class="divDecodeItemDescription">Most PR professionals suffer from chronic inbox overload. Get your workflow out of your inbox and into a single "team stream" that lets all members of a department or agency share their experiences and insight. It's like having your own private Facebook.
                            <ul>
                                <li>Team collaboration</li>
                                <li>Contact management</li>
                                <li>Task and project management</li>
                                <li>Timesheet</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="divFooter" id="contactus">
            <div class="Width960">
                <h2>Contact Us</h2>
                <div class="HeaderDescription">Use one of the contact information below to speak to one of us.</div>
                <div style="margin-top:20px">
                    <div style="float:left">
                        <asp:Literal runat="server" ID="litContactFormResult" Text="Feedback sent successfully." Visible="false" /><br />
                        <br />
                        <asp:TextBox runat="server" ID="txtFullName" Text="Full Name" onfocus='if (this.value == "Full Name"){this.value = "";}' onblur='if (this.value == ""){this.value = "Full Name"}' /><br />
                        <asp:TextBox runat="server" ID="txtContactNumber" Text="Contact Number" TextMode="Phone" onfocus='if (this.value == "Contact Number"){this.value = "";}' onblur='if (this.value == ""){this.value = "Contact Number"}' /><br />
                        <asp:TextBox runat="server" ID="txtEmailAddress" Text="Email Address" onfocus='if (this.value == "Email Address"){this.value = "";}' onblur='if (this.value == ""){this.value = "Email Address"}' />
                    </div>
                    <div style="float:left"><br />
                        <br />                       
                        <asp:TextBox runat="server" ID="txtMessage" Text="Message" TextMode="MultiLine" onfocus='if (this.value == "Message"){this.value = "";}' onblur='if (this.value == ""){this.value = "Message"}' /><br />
                        <asp:Button runat="server" ID="btnSend" Text="Send" CssClass="ContactUsButton" OnClick="btnSend_Click" />
                    </div>
                    <div style="float:left; font-size:17px;margin-left:40px;">
                        +27 11 057 6764<br />
                        hello@decode.co.za<br />
                        <br />
                        Buffalo Park<br />
                        The Oval Office Park<br />
                        Cnr Sloane & Meadowbrook<br />
                        Bryanston<br />
                        Johannesburg
                    </div>
                    <div class="Clear"></div>
                    <div class="divMap">
                        <div id="map-canvas"></div>
                    </div>
                    <div class="divFooterContent">
                        <div class="divSubscriptionForm">
                            <h3>Stay informed! Subscribe to our weekly newsletter.</h3><br />
                            <asp:Literal runat="server" ID="litSubscriberResult" Text="Thank you for subscribing to our mailing list." Visible="false" /><br />
                            <br />
                            <asp:TextBox runat="server" ID="txtSubFirstName" Text="First Name" onfocus='if (this.value == "First Name"){this.value = "";}' onblur='if (this.value == ""){this.value = "First Name"}' /><br />
                            <asp:TextBox runat="server" ID="txtSubEmailAddress" Text="Email Address" onfocus='if (this.value == "Email Address"){this.value = "";}' onblur='if (this.value == ""){this.value = "Email Address"}' /><br />
                            <asp:Button runat="server" ID="btnSubscribe" Text="Subscribe" OnClick="btnSubscribe_Click" />
                        </div>
                        <div class="divFooterMenu">
                            <h3>Site Navigation.</h3><br />
                            <ul>
                                <li><a id="aHome2">Home</a></li>
                                <li><a id="aAboutUs2">About Us</a></li>
                                <li><a id="aServices4">Services</a></li>
                                <li><a id="aProduct5">Product</a></li>
                                <li><a id="aContactUs3">Contact Us</a></li>
                            </ul>
                        </div>
                        <div class="divSocialLinks">
                            <h3>Stay Connected.</h3><br />
                            <ul>
                                <li><a target="_blank" href="mailto:hello@decode.co.za">hello@decode.co.za</a></li>
                                <li><a target="_blank" href="https://twitter.com/Decode_Agency">Twitter</a></li>
                                <li><a target="_blank" href="https://www.facebook.com/DecodeAgency?fref=ts">Facebook</a></li>
                                <li><a target="_blank" href="https://www.linkedin.com/company/5186543?trk=tyah&trkInfo=idx%3A1-1-1%2CtarId%3A1425554047810%2Ctas%3Adecode+africa">LinkedIn</a></li>
                                <li>&nbsp;</li> 
                                <li><a>Copyright &copy; 2015 Decode Agency (Pty) Ltd</a></li>
                            </ul>
                        </div>
                        <div class="Clear"></div>
                    </div>                     
                </div>
            </div>
        </div>
    </form>
</body>
</html>

    <!-- JavaScript -->
    <script src="js/bootstrap.js"></script>
	<script src="js/owl.carousel.js"></script>
	<script src="js/script.js"></script>
	<!-- StikyMenu -->
	<script src="js/stickUp.min.js"></script>
	<script type="text/javascript">
	    jQuery(function ($) {
	        $(document).ready(function () {
	            $('.navbar-default').stickUp();
	        });
	    });
	</script>
	<!-- Smoothscroll -->
	<script type="text/javascript" src="js/jquery.corner.js"></script> 
	<%--<script src="js/wow.min.js"></script>--%>
    <script src="https://maps.googleapis.com/maps/api/js"></script>
    <script>
        function initialize() {
            var myLatlng = new google.maps.LatLng(-26.044272, 28.012966);
            var mapCanvas = document.getElementById('map-canvas');
            var mapOptions = {
                center: myLatlng,
                mapTypeId: google.maps.MapTypeId.ROADMAP,
                zoom: 14
            }
            var map = new google.maps.Map(mapCanvas, mapOptions);
            var marker = new google.maps.Marker({
                position: myLatlng,
                map: map
            });
        }
        google.maps.event.addDomListener(window, 'load', initialize);
    </script>    
	<script>
	    new WOW().init();
	</script>
	<script src="js/classie.js"></script>
	<script src="js/uiMorphingButton_inflow.js"></script>
	<!-- Magnific Popup core JS file -->
	<script src="js/jquery.magnific-popup.js"></script> 


<script>
    // Calling the function
    setFixMenu('.divMainMenu', 'fixedMenu');

    function setFixMenu(element, stickyCssClass) {
        // get the top offset of the menu element
        var menuTop = $(element).offset().top;
        // trigger the function when the windows scroll
        $(window).scroll(function () {
            // get total scrolling
            var htmlTop = $(window).scrollTop();
            
            // check if the scrolling is less than top offset of menu
            // then stick the menu on top by adding the stickyCssClass
            // If not then set the menu at it's default position by removing the stickyCssClass
            if (htmlTop > menuTop) {
                // add the class to stick on top
                $(element).addClass(stickyCssClass);
            } else {
                // remove the stick on top class
                $(element).removeClass(stickyCssClass);
            }
        });
    }
</script>
<script>
    $('#aHome').click(function () {
        $("html, body").animate({ scrollTop: 0 }, 400);
        return false;
    })
    $('#aHome2').click(function () {
        $("html, body").animate({ scrollTop: 0 }, 400);
        return false;
    })
    $('#aAboutUs').click(function () {
        $("html, body").animate({ scrollTop: 495 }, 400);
        return false;
    })
    $('#aAboutUs2').click(function () {
        $("html, body").animate({ scrollTop: 495 }, 400);
        return false;
    })
    $('#aServices').click(function () {
        $("html, body").animate({ scrollTop: 1600 }, 400);
        return false;
    })
    $('#aServices2').click(function () {
        $("html, body").animate({ scrollTop: 1600 }, 400);
        return false;
    })
    $('#aServices3').click(function () {
        $("html, body").animate({ scrollTop: 1600 }, 400);
        return false;
    })
    $('#aServices4').click(function () {
        $("html, body").animate({ scrollTop: 1600 }, 400);
        return false;
    })
    $('#aProduct').click(function () {
        $("html, body").animate({ scrollTop: 2596 }, 400);
        return false;
    })
    $('#aProduct2').click(function () {
        $("html, body").animate({ scrollTop: 2596 }, 400);
        return false;
    })
    $('#aProduct3').click(function () {
        $("html, body").animate({ scrollTop: 2596 }, 400);
        return false;
    })
    $('#aProduct4').click(function () {
        $("html, body").animate({ scrollTop: 2596 }, 400);
        return false;
    })
    $('#aProduct5').click(function () {
        $("html, body").animate({ scrollTop: 2596 }, 400);
        return false;
    })
    $('#aContactUs').click(function () {
        $("html, body").animate({ scrollTop: 4582 }, 400);
        return false;
    })
    $('#aContactUs2').click(function () {
        $("html, body").animate({ scrollTop: 4582 }, 400);
        return false;
    })
    $('#aContactUs3').click(function () {
        $("html, body").animate({ scrollTop: 4640 }, 400);
        return false;
    })
</script>
<script>
    (function (i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
        m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

    ga('create', 'UA-51925950-1', 'auto');
    ga('send', 'pageview');
</script>
<style type="text/css">
    .fixedMenu { position:fixed; top:0px; right:0px; left:0px; z-index:999; }
</style>

