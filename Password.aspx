<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Password.aspx.cs" Inherits="KBE.Password" Async="true" %>

<!DOCTYPE html>

<html lang="en">
    <!-- BEGIN: Head -->
    <head>
        <meta charset="utf-8">
        <link href="dist/images/logo.svg" rel="shortcut icon">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        
         <title>Kuwait Bahrain International Exchange Company</title>
    <link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico">
        <!-- BEGIN: CSS Assets-->
        <link rel="stylesheet" href="css/app.css" />
        <link rel="stylesheet" href="css/loading.css" />
		<link href="https://fonts.googleapis.com/css2?family=Tajawal&display=swap" rel="stylesheet">
		<link href="https://fonts.googleapis.com/css2?family=Almarai:wght@300&display=swap" rel="stylesheet">
        <!------12-11-2020 Star------->
		<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.1/css/all.css" >
		 <!------12-11-2020 end------->
        <!-- END: CSS Assets-->
        <script type = "text/javascript" >
function disableBackButton()
{
window.history.forward(1);
}
setTimeout("disableBackButton()", 0);
document.oncontextmenu = function() { 
    return false; 
}
</script>
    </head>
    <!-- END: Head -->
    <body class="login">
         <form runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
              <!----08-10-20 strat---->
	<div class="fullpage-loader">
	<div class="fullpage-loader__logo">
		<img src="images/load.gif" />
	</div>
	</div>
	<!----08-10-20 end---->
        <div class="container sm:px-10">
            <div class="block xl:grid grid-cols-2 gap-4">
                <!-- BEGIN: Login Info -->
                <div class="hidden xl:flex flex-col min-h-screen">
                    <!--<a href="" class="-intro-x flex items-center pt-5">
                        <img alt="" class="logo" src="images/logo.svg">
                    </a>-->
                    <div class="my-auto">
                        <img alt="" class="-intro-x logo_login" src="images/logo.svg">
                        <div class="-intro-x text-white font-medium text-4xl leading-tight mt-10">                            
                           <asp:Label ID="Signintolbl" runat="server" Text="Sign in to your account."></asp:Label>
                        </div>
                        <div class="-intro-x text-lg text-white"><asp:Label ID="Manageyourremmilbl" runat="server" Text="Manage all your remittances"></asp:Label> </div>
                    </div>
                </div>
                <!-- END: Login Info -->
                <!-- BEGIN: Login Form -->
                <div class="h-screen xl:h-auto flex py-5 xl:py-0 my-10 xl:my-0">					
                  <%--  <div class="dropdown language">                                        
                        <asp:Label ID="SelLanglbl" runat="server" Text="English" class="dropdown-toggle button inline-block bg-theme-1 text-white"></asp:Label>
                                        <div class="dropdown-box mt-10 absolute top-0 right-0 z-20">
                                            <div class="dropdown-box__content box p-2"> 											
                                                <asp:Button ID="EngBtn" runat="server" Text="English" class="block p-2 transition duration-300 ease-in-out bg-white hover:bg-gray-200 rounded-md" OnClick="EngBtn_Click" UseSubmitBehavior="false" CausesValidation="false"/>
                                                <asp:Button ID="ArbBtn" runat="server" Text="عربى" class="block p-2 transition duration-300 ease-in-out bg-white hover:bg-gray-200 rounded-md arabic" OnClick="ArbBtn_Click" UseSubmitBehavior="false" CausesValidation="false"/>
                                            </div>
                                        </div>
                                    </div>--%>
                       <div class="dropdown language ">
                                        <button type="button" class="dropdown-toggle button inline-block bg-theme-1 text-white language_ar" id="LanguageBtn" runat="server" onserverclick="LanguageBtn_Click" causesvalidation="false">عربى </button>                                        
                                    </div>
				
				
                    <div class="my-auto mx-auto xl:ml-20 bg-white xl:bg-transparent px-5 sm:px-8 py-8 xl:p-0 rounded-md shadow-md xl:shadow-none sm:w-3/4 lg:w-2/4 xl:w-auto">
                    	<img alt="" class="logo_smal " src="images/logo1.png">
						 <img alt="" class="-intro-x logo_login logo_destop_hide" src="images/logo_20.svg">
                        <h2 class="intro-x font-bold text-2xl xl:text-3xl text-center xl:text-left">
                            <asp:Label ID="Signinlbl" runat="server" Text="Sign In"></asp:Label>    
                        </h2>
                        <div class="intro-x mt-2 text-gray-500 xl:hidden text-center">Manage Your all Banking Details</div>
                        <div class="intro-x mt-5 pass_show">                            
                            <asp:TextBox ID="PWDTxt" runat="server" class="intro-x login__input input input--lg border border-gray-300 block mt-4" placeholder="Password" TextMode="Password"></asp:TextBox>
                            <i onclick="show('PWDTxt')" class="fas fa-eye-slash " id="display"></i>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Password Required" ControlToValidate="PWDTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                           
                        </div>
                        <div class="intro-x mt-5">                            
                         <asp:Label ID="Errorlbl" runat="server" Text="" CssClass="Validate-Error"></asp:Label>
                        </div>
                        <div class="intro-x mt-2 xl:mt-2 text-center xl:text-center">
                            <asp:Button ID="LoginBtn" runat="server" Text="Login" class="button button--lg w-full  text-white bg-theme-1 login_btn flot_lft" UseSubmitBehavior="true" CausesValidation="true" OnClick="LoginBtn_Click"/>                                                         
                            <div style="clear:both;"></div>                            
                            <a href="Forgot" class=" w-full text-gray-700 forgotpass"><asp:Label ID="ForgotPwdlbl" runat="server" Text="Forgot Password?"></asp:Label> </a>
                        <div style="clear:both;"></div>
						</div>
						<div style="clear:both;"></div>
						
						
                       
                    </div>
                </div>
                <!-- END: Login Form -->
            </div>
        </div>




              <!--Success--->
 <div class="modal" id="successmsg">
     <div class="modal__content">
         <div class="p-5 text-center "> <i data-feather="check-circle" class="w-16 h-16 text-theme-9 mx-auto mt-3"></i>
             <div class="text-3xl mt-2">Success!</div>
             <div class="text-gray-600 mt-1 mb-2"> <asp:Label ID="SuccessMsglbl" runat="server" Text=""></asp:Label></div>
         </div>
         <!--<div class="px-5 pb-8 text-center"> <button type="button" data-dismiss="modal" class="button w-24 bg-theme-1 text-white">Ok</button> </div>-->
     </div>
 </div>
 <!--Success--->
 
 
 <!--Error--->

 <div class="modal" id="errormsg">
     <div class="modal__content">
         <div class="p-5 text-center "> <i data-feather="alert-triangle" class="w-16 h-16 text-theme-6 mx-auto mt-3"></i>
             <div class="text-3xl mt-2">Error</div>
             <div class="text-gray-600 mt-1 mb-2"><asp:Label ID="ErrorMsglbl" runat="server" Text=""></asp:Label></div>
         </div>
        <!-- <div class="px-5 pb-8 text-center">  <button type="button" class="button w-24 bg-theme-6 text-white">Ok</button> </div>-->
     </div>
 </div>
<!--Error--->		
		
            <script type="text/javascript">       
       
                function SuccessMsg(suc_msg) {
                    $("#SuccessMsglbl").html(suc_msg);
                $("#successmsg").modal('show');                
            }
                function ErrorMsg(err_msg) {
                    $("#ErrorMsglbl").html(err_msg);
                $("#errormsg").modal('show');
            }              
       
    </script>


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

               <!----08-10-20 strat---->	
		<script type="text/javascript">
			const loaderEl = document.getElementsByClassName('fullpage-loader')[0];
document.addEventListener('readystatechange', (event) => {
	// const readyState = "interactive";
	const readyState = "complete";
    
	if(document.readyState == readyState) {
		// when document ready add lass to fadeout loader
		loaderEl.classList.add('fullpage-loader--invisible');
		
		// when loader is invisible remove it from the DOM
		setTimeout(()=>{
			loaderEl.parentNode.removeChild(loaderEl);
		}, 2000)
	}
});

	</script>
             <!------12-11-2020 Star------->
		<script type="text/javascript">	$(document).ready(function() {
    $('.dropdown-box__content a').click(function(event) {
        var option = $(event.target).text();
        $(event.target).parents('.language').find('.button').html(option);
    });
});

function show(a) {
  var x=document.getElementById(a);
  var c=x.nextElementSibling
  if (x.getAttribute('type') == "password") {
  c.removeAttribute("class");
  c.setAttribute("class","fas fa-eye");
  x.removeAttribute("type");
    x.setAttribute("type","text");
  } else {
  x.removeAttribute("type");
    x.setAttribute('type','password');
 c.removeAttribute("class");
  c.setAttribute("class","fas fa-eye-slash");
  }
} 
	</script>
	<!------12-11-2020 end------->
             </form>
    </body>
</html>