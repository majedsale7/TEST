<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Password_Forgot.aspx.cs" Inherits="KBE.Password_Forgot" Async="true" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<!DOCTYPE html>

<html lang="en">
    <!-- BEGIN: Head -->
    <head runat="server">
        <meta charset="utf-8">
        <link href="dist/images/logo.svg" rel="shortcut icon">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        
        <title>Kuwait Bahrain International Exchange Company : Forgot Password</title>
          <link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico">
        <!-- BEGIN: CSS Assets-->
        <link rel="stylesheet" href="css/app.css" />
		<link href="https://fonts.googleapis.com/css2?family=Tajawal&display=swap" rel="stylesheet">
		<link href="https://fonts.googleapis.com/css2?family=Almarai:wght@300&display=swap" rel="stylesheet">
        <!------12-11-2020 Star------->
		<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.1/css/all.css" >
		 <!------12-11-2020 end------->
        <!-- END: CSS Assets-->
    </head>
    <!-- END: Head -->
    <body class="login">
         <form runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                        <div class="-intro-x text-lg text-white"><asp:Label ID="Manageyourremmilbl" runat="server" Text="Manage all your remittances"></asp:Label></div>
                    </div>
                </div>
                <!-- END: Login Info -->
                <!-- BEGIN: Login Form -->
                <div class="h-screen xl:h-auto flex py-5 xl:py-0 my-10 xl:my-0">
					<%--<div class="dropdown language">                                        
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
				
				
                    <div class="my-auto mx-auto xl:ml-20 bg-white xl:bg-transparent px-5 sm:px-8 py-8 xl:p-0 rounded-md shadow-md xl:shadow-none w-full sm:w-3/4 lg:w-2/4 xl:w-auto">
                    	<img alt="" class="logo_smal " src="images/logo1.png">
						 <img alt="" class="-intro-x logo_login logo_destop_hide" src="images/logo_20.svg">
                        <h2 class="intro-x font-bold text-2xl xl:text-3xl text-center xl:text-left">
                            <asp:Label ID="Forgotpwdlbl" runat="server" Text="Forgot Password"></asp:Label>
                        </h2>
                        <div class="intro-x mt-2 text-gray-500 xl:hidden text-center">Manage Your all Banking Details</div>
                        <div class="intro-x mt-5">
                            
                            <%--<input type="password" class="intro-x login__input input input--lg border border-gray-300 block mt-4" placeholder="Login Id">
							 <input type="password" class="intro-x login__input input input--lg border border-gray-300 block mt-4" placeholder="Email Id">--%>
                            <asp:TextBox ID="LoginIDTxt" runat="server" class="intro-x login__input input input--lg border border-gray-300 block" placeholder="Civil Id" MaxLength="12" ReadOnly="true" ForeColor="Black"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="LoginIDTxt" Display="Dynamic" ErrorMessage="Login ID Required" SetFocusOnError="True" CssClass="Validate-Error"></asp:RequiredFieldValidator>                                                     
                            <ajaxToolkit:FilteredTextBoxExtender ID="LoginIDTxt_FilteredTextBoxExtender" runat="server" BehaviorID="LoginIDTxt_FilteredTextBoxExtender" FilterType="Numbers" TargetControlID="LoginIDTxt" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Login ID" Display="Dynamic" ControlToValidate="LoginIDTxt" CssClass="Validate-Error" SetFocusOnError="True" ValidationExpression="[0-9]{12}"></asp:RegularExpressionValidator>
                                                        
                         <%--   <asp:TextBox ID="EmailIDTxt" runat="server" class="intro-x login__input input input--lg border border-gray-300 block" placeholder="Email Id"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="EmailIDTxt" Display="Dynamic" ErrorMessage="Email ID Required" SetFocusOnError="True" CssClass="Validate-Error"></asp:RequiredFieldValidator>                                                     
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Email ID" Display="Dynamic" ControlToValidate="EmailIDTxt" CssClass="Validate-Error" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>

                        </div>

                        <div class="mt-2"> 
     <div class="flex flex-col sm:flex-row ">
         <div class="flex items-center text-gray-700 dark:text-black-500 mr-2"> <input type="radio" class="input mr-2 " id="SMSRad" name="horizontal_radio_button" value="horizontal-radio-chris-evans" runat="server"> <label class="cursor-pointer select-none" for="SMSRad" id="SMSRadlbl" runat="server">Send OTP to Mobile</label> </div>
         <div class="flex items-center text-gray-700 dark:text-black-500 mr-2 mt-2 sm:mt-0"> <input type="radio" class="input mr-2" id="EmailRad" name="horizontal_radio_button" value="horizontal-radio-liam-neeson" runat="server"> <label class="cursor-pointer select-none" for="EmailRad" id="EmailRadlbl" runat="server">Send OTP to Email</label> </div>
     </div>
 </div>
                         <div class="intro-x mt-2 pass_show">
                             <asp:TextBox ID="OTPTxt" runat="server" class="intro-x login__input input input--lg border border-gray-300 block form-control" placeholder="Enter the received OTP" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                             <i onclick="show('OTPTxt')" class="fas fa-eye-slash " id="display"></i>
                             <ajaxToolkit:FilteredTextBoxExtender ID="OTPTxt_FilteredTextBoxExtender" runat="server" BehaviorID="OTPTxt_FilteredTextBoxExtender" FilterType="Numbers" TargetControlID="OTPTxt" />							
                             <asp:RequiredFieldValidator ID="OTPTxt_ReqF" runat="server" ErrorMessage="OTP Required" ControlToValidate="OTPTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                        	<div style="clear:both;"></div>
                         <div class="mt-2"> 
                        <asp:Button ID="OTPSendBtn" runat="server" Text="Resend OTP" class=" text-black " UseSubmitBehavior="false" CausesValidation="false" OnClick="OTPSendBtn_Click" ForeColor="Black"/>
						<span class="resnd_otp" runat="server" id="CounterSpan" visible="false" style="color:black;"> ( OTP expires in <span id="Counterlbl" runat="server" style="color:red; font-weight:bold"></span> Secs  )</span>
                        <asp:HiddenField ID="InitiSecs_HD" runat="server" />
                             </div>

                        <div style="clear:both;"></div>

                          <div class="intro-x mt-5 pass_show">                           
                            <asp:TextBox ID="NewPwdTxt" runat="server" class="intro-x login__input input input--lg border border-gray-300 block" placeholder="New Password" TextMode="Password"></asp:TextBox>
                              <i onclick="showp('NewPwdTxt')" class="fas fa-eye-slash " id="displayp"></i>
                            <asp:RequiredFieldValidator ID="NewPwdTxt_ReqF" runat="server" ErrorMessage="New Password Required" ControlToValidate="NewPwdTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="NewPwdTxt_RegExp" runat="server" ErrorMessage="<br/>Password Required <br/> 8 or more Characters<br/> Minimum 1 Number<br/> 1 Upper Case <br/>1 Lower Case Characters <br/>1 Special Character" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[~!@#$%^&*()_+`=}{|\/?><.,])[a-zA-Z\d~!@#$%^&*()_+`=}{|\/?><.,]{8,}$" ControlToValidate="NewPwdTxt" CssClass="Validate-Error"></asp:RegularExpressionValidator>
                                <ajaxToolkit:PasswordStrength ID="NewPwdTxt_PasswordStrength" runat="server" BehaviorID="NewPwdTxt_PasswordStrength" CalculationWeightings="50;25;25;0" DisplayPosition="BelowLeft" HelpHandlePosition="BelowLeft" PreferredPasswordLength="10" TargetControlID="NewPwdTxt" TextCssClass="Validate-Error" TextStrengthDescriptions="Poor;Weak;Average;Good;Excellent" />
                        </div>

                <div class="intro-x mt-5 pass_show">
                            <asp:TextBox ID="ConfirmPwdTxt" runat="server" class="intro-x login__input input input--lg border border-gray-300 block" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                            <i onclick="showcp('ConfirmPwdTxt')" class="fas fa-eye-slash " id="displaycp"></i>
                            <asp:RequiredFieldValidator ID="ConfirmPwdTxt_ReqF" runat="server" ErrorMessage="Confirm Password Required" ControlToValidate="ConfirmPwdTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>							
							     <asp:CompareValidator ID="ConfirmPwdTxt_CompV" runat="server" ControlToCompare="NewPwdTxt" ControlToValidate="ConfirmPwdTxt" CssClass="Validate-Error" Display="Dynamic" ErrorMessage="Confirm Password Not Matching With New Password" SetFocusOnError="True"></asp:CompareValidator>

                        </div>

                        <div class="intro-x mt-5 xl:mt-3 text-center xl:text-left">
                            <asp:Button ID="SubmitBtn" runat="server" Text="Submit" class="button button--lg w-full xl:w-32 text-white bg-theme-1 login_btn flot_lft" UseSubmitBehavior="false" CausesValidation="True" OnClick="SubmitBtn_Click"/>
                            <%--<div style="clear:both;"></div>--%>
                            <%--<a href="Login" class=" w-full text-gray-700 forgotpass"><asp:Label ID="Loginlbl" runat="server" Text="Login"></asp:Label> </a>--%>
                            <a href="Login" class=" button button--lg w-full xl:w-32 text-gray-700 border border-gray-300 xl:mt-0 login_btn  flot_rit"><asp:Label ID="Loginlbl" runat="server" Text="Login"></asp:Label> </a>
                           
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
        <script src="https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/markerclusterer.js"></script>
        <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBG7gNHAhDzgYmq4-EHvM4bqW1DNj2UCuk&libraries=places"></script>
        <script src="js/app.js"></script>             
        <!-- END: JS Assets-->

		<!------12-11-2020 Star------->
		
		<script type="text/javascript">	$(document).ready(function() {
    $('.dropdown-box__content a').click(function(event) {
        var option = $(event.target).text();
        $(event.target).parents('.language').find('.button').html(option);
    });
});



function show(a) {
    //var x = document.getElementById(a);
    var x=document.getElementById("<%= OTPTxt.ClientID %>");
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

            function showp(a) {    
    var x=document.getElementById("<%= NewPwdTxt.ClientID %>");
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

            function showcp(a) {    
    var x=document.getElementById("<%= ConfirmPwdTxt.ClientID %>");
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

           <%--  <script type="text/javascript">
    
                 var CounterValue = parseInt(document.getElementById("<%= InitiSecs_HD.ClientID %>").value);
                 document.getElementById("ResendBtn").disabled = true;
                 document.getElementById("SubmitBtn").disabled = false;
var x = setInterval(function() {
              
    document.getElementById('Counterlbl').innerText = CounterValue;
    CounterValue = CounterValue - 1;        
    document.getElementById("<%= InitiSecs_HD.ClientID %>").value = CounterValue;  

  if (CounterValue < 0) {
      clearInterval(x);      
      document.getElementById('Counterlbl').innerText = "0";
      document.getElementById("ResendBtn").disabled = false;      
      document.getElementById('CounterSpan').style.display = 'none';
      document.getElementById("SubmitBtn").disabled = true;     
      
  }
}, 1000);

</script>--%>

              <script type="text/javascript">
    
          var CounterValue = parseInt(document.getElementById("<%= InitiSecs_HD.ClientID %>").value);              

var x = setInterval(function() {
              
    if (CounterValue > 0) 
        document.getElementById("<%= OTPSendBtn.ClientID %>").disabled = true;       
       
    document.getElementById("<%= Counterlbl.ClientID %>").innerText = CounterValue;
    CounterValue = CounterValue - 1;        
    document.getElementById("<%= InitiSecs_HD.ClientID %>").value = CounterValue;  

    if (CounterValue < 0) {
      clearInterval(x);      
    
      document.getElementById("<%= Counterlbl.ClientID %>").innerText = "0"
     document.getElementById("<%= OTPSendBtn.ClientID %>").disabled = false;
    document.getElementById("<%= CounterSpan.ClientID %>").style.display = "none";
    document.getElementById("<%= InitiSecs_HD.ClientID %>").value = "";  
      
  }
}, 1000);

</script>



          

		<%--<script type="text/javascript">	$(document).ready(function() {
    $('.dropdown-box__content a').click(function(event) {
        var option = $(event.target).text();
        $(event.target).parents('.language').find('.button').html(option);
    });
});

	</script>--%>

        </form>
    </body>
</html>
