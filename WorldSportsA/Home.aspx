<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WorldSportsA.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WorldSports</title>

    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta charset="utf-8" />
    <meta name="keywords" content="Business Apt a Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template,
    Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
    <!-- Default-JavaScript-File -->
    <script type="text/javascript" src="Content/Home/js/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="Content/Homejs/bootstrap.min.js"></script>
    <!-- //Default-JavaScript-File -->
    <link rel="stylesheet" href="Content/Home/css/flexslider.css" type="text/css" media="screen" />
    <script defer src="Content/Home/js/jquery.flexslider.js"></script>
    <!-- gallery -->
    <link rel="stylesheet" href=Content/Home/css/lightGallery.css" type="text/css" media="all" />
    <!-- //gallery -->
    <link href="Content/Home/css/bootstrap.min.css" rel="stylesheet" type="text/css" media="all" />
    <link href="Content/Home/css/styleab.css" rel="stylesheet" type="text/css" media="all" />
    <link href="Content/Homecss/font-awesome.min.css" rel="stylesheet" type="text/css" media="all" />
    <link href="//fonts.googleapis.com/css?family=Oswald:200,300,400,500,600,700" rel="stylesheet" />
    <link href="//fonts.googleapis.com/css?family=Josefin+Sans:100,100i,300,300i,400,400i,600,600i,700,700i" rel="stylesheet" />

    <!--Start-slider-script-->
    <script type="text/javascript">

		$(window).load(function(){
		  $('.flexslider').flexslider({
			animation: "slide",
			start: function(slider){
			  $('body').removeClass('loading');
			}
		  });
		});
    </script>
    <!--End-slider-script-->

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="banner">
                <!-- <div class="container"> -->
                <nav class="navbar navbar-default">
                    <div class="navbar-header navbar-left">
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <h1><a class="navbar-brand" href="home.aspx">WorldSports</a></h1>
                    </div>
                    <!-- Collect the nav links, forms, and other content for toggling -->
                    <div class="collapse navbar-collapse navbar-right" id="bs-example-navbar-collapse-1">
                        <ul class="nav navbar-nav">
                            <li><a href="~/Home.aspx">Home</a></li>
                            <li><a href="about.aspx">About</a></li>
                            <li><a href="#">Help Center</a></li>
                            <li><a href="Login.aspx">Sign In</a></li>
                            <li><a href="Registration.aspx">Sign Up</a></li>
                        </ul>
                    </div>
                    <!-- /.navbar-collapse -->
                </nav>
                <!-- </div> -->

                <ul class="top-links">
                    <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                    <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                    <li><a href="#"><i class="fa fa-google-plus"></i></a></li>
                    <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                </ul>
            </div>

            <!-- //banner -->
            <!-- Slider -->
            <div class="slider w3layouts agileits">
                <ul class="rslides w3layouts agileits" id="slider">
                    <li>
                        <img src="Content/images/b1.jpg" alt="Affiliation" />
                        <div class="layer w3layouts agileits">
                            <h3>Run your league from anywhere in one simple place online..</h3>                          
                        </div>
                    </li>

                    <li>
                        <img src="Content/images/b3.jpg" alt="Affiliation" />
                        <div class="layer w3layouts agileits">
                            <h3>We've got your football league covered.</h3>
                        </div>
                    </li>

                    <li>
                        <img src="Content/images/b4.jpg" alt="Affiliation" />
                        <div class="layer w3layouts agileits">
                            <h3>Easily manage scheduling, results, statistics and players.</h3>
                        </div>
                    </li>

                    <li>
                        <img src="Content/images/b6.jpg" alt="Affiliation" />
                        <div class="layer w3layouts agileits">
                            <h3>Reach your league members with one click on your website, by email, Facebook and Twitter.</h3>
                        </div>
                    </li>
                </ul>
                <!-- banner bottom -->
                <div class="banner-grids">
                    <div class="container">
                        <div class="col-md-4 banner-grid1">
                            <a href="#" data-toggle="modal" data-target="#myModal"><h3> “Many people say I'm the best women's soccer player in the world. I don't think so. And because of that, someday I just might be.” </h3></a>
                            <h4>― Mia Hamm.</h4>
                            <div class="clearfix"></div>
                        </div>
                        <div class="col-md-4 banner-grid2">
                            <a href="#" data-toggle="modal" data-target="#myModal"><h3> “Everything I know about morality and the obligations of men, I owe it to football (soccer).” </h3></a>
                            <h4>― Albert Camus.</h4>
                            <div class="clearfix"></div>
                        </div>
                        <div class="col-md-4 banner-grid3">
                            <a href="#" data-toggle="modal" data-target="#myModal"><h3> “The thing about football - the important thing about football - is that it is not just about football.”</h3></a>
                            <h4>― Terry Pratchett</h4>
                            <div class="clearfix"></div>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
                <!-- banner bottom -->
                 <div class="copyright w3layouts agileits">
                <p>&copy; 2018 WorldSports. All Rights Reserved | Design by <a href="#"> Siviwe Majova </a></p>
            </div>
            </div>
            <!-- //Slider -->

           
            <!-- copyright -->
            <!-- Slider-JavaScript -->
            <script src="Content/Home/js/responsiveslides.min.js"></script>
            <script>
		$(function () {
			$("#slider, #slider1").responsiveSlides({
				auto: true,
				nav: true,
				speed: 1000,
				namespace: "callbacks",
				pager: true,
			});
		});
            </script>
            <!-- //Slider-JavaScript -->
            <!-- Slide-To-Top JavaScript -->
            <script type="text/javascript">
			$(document).ready(function() {
				var defaults = {
					containerID: 'toTop',
					containerHoverID: 'toTopHover',
					scrollSpeed: 100,
					easingType: 'linear',
				};
				$().UItoTop({ easingType: 'easeOutQuart' });
			});
            </script>
            <a href="home.aspx" id="toTop" class="stuoyal3w scroll stieliga" style="display: block;"> <span id="toTopHover" style="opacity: 0;"> </span></a>
            <!-- //Slide-To-Top JavaScript -->
            <!-- here stars scrolling icon -->
            <script type="text/javascript">
			$(document).ready(function() {
				/*
					var defaults = {
					containerID: 'toTop', // fading element id
					containerHoverID: 'toTopHover', // fading element hover id
					scrollSpeed: 1200,
					easingType: 'linear'
					};
				*/

				$().UItoTop({ easingType: 'easeOutQuart' });

				});
            </script>
            <!-- start-smoth-scrolling -->
            <script type="text/javascript" src="Content/Home/js/move-top.js"></script>
            <script type="text/javascript" src="Content/Home/js/easing.js"></script>
            <script src="Content/Home/js/SmoothScroll.min.js"></script>
            <script type="text/javascript">
			jQuery(document).ready(function($) {
			$(".scroll").click(function(event){
			event.preventDefault();
			$('html,body').animate({scrollTop:$(this.hash).offset().top},1000);
			});
			});
            </script>
            <!-- start-smoth-scrolling -->
            <!-- //here ends scrolling icon -->
            <!-- js files for contact from validation -->
            <script src="Content/Home/js/jqBootstrapValidation.js"></script>
            <script src="Content/Home/js/contact_me.js"></script>
            <!-- //js files for contact from validation -->
            <!-- Skills-why-Scroller-Effect-JavaScript -->
            <script type="text/javascript" src="Content/Home/js/numscroller-1.0.js"></script>
            <!-- //Skills-why-Scroller-Effect-JavaScript -->
        </div>
    </form>
</body>
</html>
