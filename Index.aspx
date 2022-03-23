<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="KBE.Index" Async="true" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>


<!DOCTYPE html>

<html lang="en">
    <!-- BEGIN: Head -->
    <head runat="server">
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
        <!-- END: CSS Assets-->
        <script type = "text/javascript" >
//function disableBackButton()
//{
//window.history.forward(1);
//}
//setTimeout("disableBackButton()", 0);
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
					
                    <div class="dropdown language ">                        
                                        <button type="button" class="dropdown-toggle button inline-block bg-theme-1 text-white language_ar" id="LanguageBtn" runat="server" onserverclick="LanguageBtn_Click" causesvalidation="false">عربى </button>
                                        
                                    </div>
				
				
                    <div class="my-auto mx-auto xl:ml-20 bg-white xl:bg-transparent px-5 sm:px-8 py-8 xl:p-0 rounded-md shadow-md xl:shadow-none sm:w-3/4 lg:w-2/4 xl:w-auto">
                    	<img alt="" class="logo_smal " src="images/logo1.png">
						 <img alt="" class="-intro-x logo_login logo_destop_hide" src="images/logo_20.svg">
                        <h2 class=" font-bold text-2xl xl:text-3xl text-center xl:text-left">
                            <asp:Label ID="Signinlbl" runat="server" Text="Sign In"></asp:Label>    
                        </h2>
                        <div class="intro-x mt-2 text-gray-500 xl:hidden text-center"><asp:Label ID="Manageyourlbl" runat="server" Text="Manage Your all Banking Details"></asp:Label></div>
                        <div class="intro-x mt-5">
                            <asp:TextBox ID="CIDTxt" runat="server" class="intro-x login__input input input--lg border border-gray-300 block" placeholder="Civil Id" MaxLength="12" AutoCompleteType="Disabled"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CIDTxt" Display="Dynamic" ErrorMessage="Civil ID Required" SetFocusOnError="True" CssClass="Validate-Error"></asp:RequiredFieldValidator>                                                     
                            <ajaxToolkit:FilteredTextBoxExtender ID="CIDTxt_FilteredTextBoxExtender" runat="server" BehaviorID="CIDTxt_FilteredTextBoxExtender" FilterType="Numbers" TargetControlID="CIDTxt" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Civil ID" Display="Dynamic" ControlToValidate="CIDTxt" CssClass="Validate-Error" SetFocusOnError="True" ValidationExpression="[0-9]{12}"></asp:RegularExpressionValidator>
                            <asp:Label ID="Errorlbl" runat="server" Text="" CssClass="Validate-Error"></asp:Label>
                        </div>                          

                        <div class="intro-x mt-2 xl:mt-2 text-center xl:text-left">
                            <asp:Button ID="SignupBtn" runat="server" Text="Sign up" class="button button--lg w-full xl:w-32 text-gray-700 border border-gray-300 xl:mt-0 login_btn flot_lft" CausesValidation="False" UseSubmitBehavior="False" OnClick="SignupBtn_Click"/>
                            <asp:Button ID="NextBtn" runat="server" Text="Next" class="button button--lg w-full xl:w-32 text-white bg-theme-1 login_btn flot_rit" OnClick="NextBtn_Click" CausesValidation="true"/>                                                                
                        </div>					
					
                       
                    </div>
                </div>
                <!-- END: Login Form -->
            </div>
        </div>




            	<!----------7-9-20------->	
		
		<div id="supportSidebar" class="support" runat="server">
			<a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
			 <div class="support_box">
			 
		  <div class="support_icon">
			<img alt="" src="images/support.png">
		  </div>
		   <div class="chat-window">
		  <h1><asp:Label ID="Needhelplbl" runat="server" Text="Need Help ?"></asp:Label> </h1>
		  <div class="address">

<%--<h5>In case of any questions,<br> do reach out to us:</h5>--%>
              <h5><asp:Label ID="Incaseanylbl" runat="server" Text="In case of any questions,<br> do reach out to us:"></asp:Label></h5>
<p>
 <i data-feather="phone-call"></i> 00965-22281501 Ext.211, 312<br>
 <i data-feather="printer"></i> <a href="tel:0096522431000">00965-22431000</a>
<i data-feather="globe"></i> kbexchange@kbe.com.kw<br></p>
                           
                        </div>
						 </div>
		  
		  </div>
		</div>

<div id="supportmain">
  <a class="support_openbtn" onclick="openNav()"> <asp:Label ID="Supportlbl" runat="server" Text="Support"></asp:Label> </a>
  
</div>
		
	<!----------7-9-20------->	


            
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

            
            	<!----------7-9-20------->
	<script type="text/javascript">
	function openNav() {
  document.getElementById("supportSidebar").style.width = "400px";
  document.getElementById("supportmain").style.marginRight = "400px";
}

/* Set the width of the sidebar to 0 and the left margin of the page content to 0 */
function closeNav() {
  document.getElementById("supportSidebar").style.width = "0";
  document.getElementById("supportmain").style.marginRight = "0";
}
</script>	

	<!----------7-9-20------->

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
	
	<!----08-10-20 end---->

	<%--	
		<script type="text/javascript">	$(document).ready(function() {
    $('.dropdown-box__content a').click(function(event) {
        var option = $(event.target).text();
        $(event.target).parents('.language').find('.button').html(option);
    });
});

	</script>--%>
            </form>
    </body>
</html>