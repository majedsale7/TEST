<%@ Page Title="Kuwait Bahrain International Exchange Company : OTP" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="OTPValidate.aspx.cs" Inherits="KBE.OTPValidate" Async="true" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
 	<div class="col-span-12 mt-8 ">
			
			<h1 class="main_heading  truncate  text-center"> <span id="OtpHlbl" runat="server">OTP Verification for Payment</span></h1>
			  </div> 
			
    	<div class=" box sendmony">					 
  
 <div class="wizard">
            

            
                <div class="tab-content">
                    <div class="tab-pane " >
                        <div class="signup_box">
				
                        
							<div class="mt-1 form_left pass_show"> 
							<label id="sourceofincomelbl" runat="server">Total Paying Amount KD*</label>							
                            <asp:TextBox ID="PayingAmtTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block" ReadOnly="true" ForeColor="Black"></asp:TextBox> 							 
							 </div>
							 <div class="clear"></div>
							 <div class="forgot_pass mt-2"> 
     <div class="flex flex-col sm:flex-row ">         
         <div class="flex items-center text-gray-700 dark:text-black-500 mr-2"> <input type="radio" class="input border-black mr-2 " id="SMSRad" name="horizontal_radio_button" value="horizontal-radio-chris-evans" runat="server"> <label class="cursor-pointer select-none" for="SMSRad" id="SMSRadlbl" runat="server">Send OTP to Mobile</label> </div>
         <div class="flex items-center text-gray-700 dark:text-black-500 mr-2 mt-2 sm:mt-0"> <input type="radio" class="input border-black mr-2" id="EmailRad" name="horizontal_radio_button" value="horizontal-radio-liam-neeson" runat="server"> <label class="cursor-pointer select-none" for="EmailRad" id="EmailRadlbl" runat="server">Send OTP to Email</label> </div>
     </div>
 </div>
					 <div class="clear"></div>
					 
							 <div class=" mt-2 form_left pass_show">						

                                 <asp:TextBox ID="OTPTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block " placeholder="Enter the received OTP" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                                 <i onclick="show('OTPTxt')" class="fas fa-eye-slash " id="display"></i>
			                   <asp:RequiredFieldValidator ID="OTPTxt_ReqF" runat="server" ErrorMessage="Please enter OTP" Display="Dynamic" Text="*" CssClass="Validate-Error" SetFocusOnError="True" ControlToValidate="OTPTxt"></asp:RequiredFieldValidator>
							
							</div>
							 <div class="clear"></div>							
                            <asp:Button ID="OTPSendBtn" runat="server" Text="Resend OTP" class=" w-24 mr-1 mb-2 bg-theme-1 text-white resnd_otp_btn" UseSubmitBehavior="false" CausesValidation="false" OnClick="OTPSendBtn_Click"/>							
                            <span class="resnd_otp" runat="server" id="CounterSpan" visible="false" style="color:black;"> ( OTP expires in <span id="Counterlbl" runat="server" style="color:red; font-weight:bold"></span> Secs  )</span>
                        <asp:HiddenField ID="InitiSecs_HD" runat="server" />
							 <div class="clear"></div>
							
							
							
						
				<div class="clear"></div>	
						<a href="#" class="button button--lg mt-3 w-full xl:w-32 text-white bg-theme-1 login_btn flot_lft" id="OTPValidateBtn" runat="server" onserverclick="OTPValidateBtn_Click">Submit</a>
						<div style="clear:both;"></div>

		                            	</div>
                        
                    </div>
                    
					
                    
                    </div>
                    
                    <div class="clearfix"></div>
                </div>
            
        </div>	

		

    <script type="text/javascript">
	function show(a) {
  var x=document.getElementById("<%= OTPTxt.ClientID %>");
  var c = x.nextElementSibling
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
      document.getElementById("<%= Counterlbl.ClientID %>").innerText = "0";      
      document.getElementById("<%= OTPSendBtn.ClientID %>").disabled = false;       
      document.getElementById("<%= CounterSpan.ClientID %>").style.display = "none";      
      document.getElementById("<%= InitiSecs_HD.ClientID %>").value = "";  
      
  }
}, 1000);

</script>

</asp:Content>
