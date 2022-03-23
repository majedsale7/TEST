<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageNotFound.aspx.cs" Inherits="KBE.PageNotFound" %>

<!DOCTYPE html>

<html lang="en">
    <!-- BEGIN: Head -->
    <head>
        <meta charset="utf-8">
        <link href="dist/images/logo.svg" rel="shortcut icon">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        
        <title>Welcome...</title>
        <!-- BEGIN: CSS Assets-->
        <link rel="stylesheet" href="css/app.css" />
		<link href="https://fonts.googleapis.com/css2?family=Tajawal&display=swap" rel="stylesheet">
		<link href="https://fonts.googleapis.com/css2?family=Almarai:wght@300&display=swap" rel="stylesheet">
        <!-- END: CSS Assets-->
    </head>
    <!-- END: Head -->
    <body class="login">
       
	   
	   <div class="container sm:px-10">
            <div class="block xl:grid grid-cols-2 gap-4">
                <!-- BEGIN: Login Info -->
                <div class="hidden xl:flex flex-col min-h-screen">
                    <!--<a href="" class="-intro-x flex items-center pt-5">
                        <img alt="" class="logo" src="images/logo.svg">
                    </a>-->
                    <div class="my-auto">
                        <img alt="" class="-intro-x logo_login" src="images/logo.svg">
                        
                    </div>
                </div>
                <!-- END: Login Info -->
                <!-- BEGIN: Login Form -->
                <div class="h-screen xl:h-auto flex py-5 xl:py-0 my-10 xl:my-0">
					<div class="dropdown language">
                                        <button class="dropdown-toggle button inline-block bg-theme-1 text-white">English </button>
                                        <div class="dropdown-box mt-10 absolute top-0 right-0 z-20">
                                            <div class="dropdown-box__content box p-2"> 
											<a href="#" class="block p-2 transition duration-300 ease-in-out bg-white hover:bg-gray-200 rounded-md">English </a> 
											<a href="#" class="block p-2 transition duration-300 ease-in-out bg-white hover:bg-gray-200 rounded-md arabic">عربى</a> </div>
                                        </div>
                                    </div>
				
				
                    <div class="my-auto mx-auto xl:ml-20 bg-white xl:bg-transparent px-5 sm:px-8 py-8 xl:p-0 rounded-md shadow-md xl:shadow-none w-full sm:w-3/4 lg:w-2/4 xl:w-auto error404">
                    	<div class="text-white mt-10 lg:mt-0">
						<img alt="" class="-intro-x logo_login logo_destop_hide" src="images/logo_20.svg">
                    <div class="intro-x text-6xl font-medium color_black">404</div>
                    <div class="intro-x text-xl lg:text-3xl font-medium color_black">Oops. This page has gone missing.</div>
                    <div class="intro-x text-lg mt-3 color_black">Sorry, an error has occured, Requested page not found!</div>
                    <button class="intro-x button button--lg border border-black dark:border-dark-5 dark:text-gray-300 mt-5 color_black"><a href="https://onlinekbe.com">Back to Home</a></button>
                </div>
                       
                    </div>
                </div>
                <!-- END: Login Form -->
            </div>
        </div>
	   
	
	   
	   
        <!-- BEGIN: JS Assets-->
        <script src="js/app.js"></script>
        <!-- END: JS Assets-->
		
		<script type="text/javascript">	$(document).ready(function() {
    $('.dropdown-box__content a').click(function(event) {
        var option = $(event.target).text();
        $(event.target).parents('.language').find('.button').html(option);
    });
});

	</script>
    </body>
</html>