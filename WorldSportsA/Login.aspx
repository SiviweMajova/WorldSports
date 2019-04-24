<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WorldSportsA.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign In</title>

     <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta charset="utf-8"/>
    <meta name="keywords" content="Core Login Form a Responsive Web Template, Bootstrap Web Templates, Flat Web Templates, Android Compatible Web Template, Smartphone Compatible Web Template, Free Webdesigns for Nokia, Samsung, LG, Sony Ericsson, Motorola Web Design"/>
    <script>
        addEventListener("load", function () {
            setTimeout(hideURLbar, 0);
        }, false);

        function hideURLbar() {
            window.scrollTo(0, 1);
        }
    </script>
    <!-- //Meta-Tags -->
    <!-- Index-Page-CSS -->
    
    <link href="Content/Home/css/style.css" rel="stylesheet" type="text/css" media="all"/>
    
    <!--<link href="css/styleab.css" rel="stylesheet" type="text/css" media="all" />-->
    <!-- //Custom-Stylesheet-Links -->
    <!--fonts -->
    <link href="//fonts.googleapis.com/css?family=Mukta+Mahee:200,300,400,500,600,700,800" rel="stylesheet"/>
    <!-- //fonts -->
    <!-- Font-Awesome-File -->
    <link rel="stylesheet" href="content/css/font-awesome.css" type="text/css" media="all"/>
    <!-- Default-JavaScript-File -->
	
    <script type="text/javascript" src="Content/Home/js/jquery-2.1.4.min.js"></script>
    <script  type="text/javascript" src="Content/Home/js/bootstrap.min.js"></script>
    <!-- //Default-JavaScript-File -->
    
    <link href="Content/Home/css/flexslider.css" rel="stylesheet" type="text/css" media="screen" />
    <script src="Content/Home/js/jquery.flexslider.js"></script>
    <!-- gallery -->
    <link href="Content/Home/css/lightGallery.css" rel="stylesheet" type="text/css" media="all"/>
       
    <!-- //gallery -->
    <link href="Content/Home/css/bootstrap.min.css" rel="stylesheet" type="text/css" media="all"/>
    
    <link href="Content/Home/css/font-awesome.css" rel="stylesheet"  type="text/css" media="all" />

<link href="//fonts.googleapis.com/css?family=Oswald:200,300,400,500,600,700" rel="stylesheet"/>
<link href="//fonts.googleapis.com/css?family=Josefin+Sans:100,100i,300,300i,400,400i,600,600i,700,700i" rel="stylesheet"/>
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
              <h1 class="title-agile text-center">WorldSports</h1>
    <div class="content-w3ls">
        <div class="agileits-grid">
            <div class="content-top-agile">
                <h2>Login to WorldSports</h2>
            </div>
            <div class="content-bottom">
                
                    <div class="field_w3ls">
                        <div class="field-group">
                            
                            <asp:textbox ID="login" placeholder="Username" runat="server"></asp:textbox>
                        </div>
                        <div class="field-group">
                            <asp:TextBox ID="password"  placeholder="Password" type="password" runat="server"></asp:TextBox>
                            <span toggle="#password" class="fa fa-fw fa-eye field-icon toggle-password"></span>
                        </div>
                    </div>
                    <div class="wthree-field">
                       
                        <asp:button ID="saveForm" type="submit" runat="server" text="Login" OnClick="saveForm_Click"></asp:button>
                    </div>
                    <ul class="list-login">
                        <li class="switch-agileits">
                            <label class="switch">
                                <input type="checkbox"/>
                                <span class="slider round"></span>
                                keep me signed in
                            </label>
                        </li>
                        <li>
                            <a href="ForgotPassword.aspx" class="text-right">forgot password?</a>
                        </li>
                        <li class="clearfix"></li>
                    </ul>
               
            </div>
            <!-- //content bottom -->
        </div>
    </div>
    <div class="copyright text-center">
        <p>© 2018 WorldSports All rights reserved | Designed by
            <a href="#">Siviwe Majova</a>
        </p>
    </div>
    <!--//copyright-->
   
    <script src="Content/Home/js/jquery-2.2.3.min.js"></script>
    <!-- script for show password -->
    <script>
        $(".toggle-password").click(function () {

            $(this).toggleClass("fa-eye fa-eye-slash");
            var input = $($(this).attr("toggle"));
            if (input.attr("type") == "password") {
                input.attr("type", "text");
            } else {
                input.attr("type", "password");
            }
        });
    </script>
        <script type="text/javascript" src="Content/Home/js/jquery-2.1.4.min.js"></script>
      

        </div>
    </form>
</body>
</html>
