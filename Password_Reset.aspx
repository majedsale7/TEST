<%@ Page Title="Kuwait Bahrain International Exchange Company : Reset Password" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Password_Reset.aspx.cs" Inherits="KBE.Password_Reset" Async="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
       <!-- BEGIN: Content -->
       <%--     <div class="content">--%>
                <!-- BEGIN: Top Bar -->
                
                <!-- END: Top Bar -->
                
			
			
			<div class="col-span-12 mt-8 ">
			
			<h1 class="main_heading  truncate  text-center"><asp:Label ID="Resetpasswordlbl" runat="server" Text="Reset Password"></asp:Label> </h1>
			  </div> 
			
			
						
						 
	<div class=" box sendmony">					 
  
 <div class="wizard pb-5">
            
            
                <div class="tab-content">
                    <div class="tab-pane active" role="tabpanel" id="step1">
                        <div class="signup_box">
				
                        
							<div class="mt-1 form_left"><asp:Label ID="LoginIDlbl" runat="server" Text="Login Id"></asp:Label> 
                                <asp:TextBox ID="LoginIDTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block " placeholder="" ReadOnly="true"></asp:TextBox>							
							 </div>
                            <div class="clear"></div>	
							<%-- <div class="mt-1 form_right">
                                 <asp:Label ID="OldPasswordlbl" runat="server" Text="Old Password*"></asp:Label>							 
                               <asp:TextBox ID="OldPWDTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block " placeholder="" TextMode="Password"></asp:TextBox>	
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Old Password Required" ControlToValidate="OldPWDTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>						
							</div>--%>
							
							<div class="mt-1 form_left"><asp:Label ID="NewPasswordlbl" runat="server" Text="New Password*"></asp:Label>
                                <div class="pass_show">
                                <asp:TextBox ID="NewPwdTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block " placeholder="" TextMode="Password"></asp:TextBox>		                                
                                <i onclick="show('NewPwdTxt')" class="fas fa-eye-slash " id="display"></i>
                                <asp:RequiredFieldValidator ID="NewPwdTxt_ReqF" runat="server" ErrorMessage="New Password Required" ControlToValidate="NewPwdTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="NewPwdTxt_RegExp" runat="server" ErrorMessage="<br/>Password Required <br/> 8 or more Characters<br/> Minimum 1 Number<br/> 1 Upper Case <br/>1 Lower Case Characters <br/>1 Special Character" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[~!@#$%^&*()_+`=}{|\/?><.,])[a-zA-Z\d~!@#$%^&*()_+`=}{|\/?><.,]{8,}$" ControlToValidate="NewPwdTxt" CssClass="Validate-Error"></asp:RegularExpressionValidator>
                                <ajaxToolkit:PasswordStrength ID="NewPwdTxt_PasswordStrength" runat="server" BehaviorID="NewPwdTxt_PasswordStrength" CalculationWeightings="50;25;25;0" DisplayPosition="BelowLeft" HelpHandlePosition="BelowLeft" PreferredPasswordLength="10" TargetControlID="NewPwdTxt" TextCssClass="Validate-Error" TextStrengthDescriptions="Poor;Weak;Average;Good;Excellent" />
                                    </div>
							 </div>
							 <div class="mt-1 form_right">
                                 <asp:Label ID="ConfirmPwdlbl" runat="server" Text="Confirm Password*"></asp:Label>	
                                 <div class="pass_show">
                                 <asp:TextBox ID="ConfirmPwdTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block " placeholder="" TextMode="Password"></asp:TextBox>
                                 <i onclick="show2('ConfirmPwdTxt')" class="fas fa-eye-slash" id="display1"></i>
                                 <asp:RequiredFieldValidator ID="ConfirmPwdTxt_ReqF" runat="server" ErrorMessage="Confirm Password Required" ControlToValidate="ConfirmPwdTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>							
							     <asp:CompareValidator ID="ConfirmPwdTxt_CompV" runat="server" ControlToCompare="NewPwdTxt" ControlToValidate="ConfirmPwdTxt" CssClass="Validate-Error" Display="Dynamic" ErrorMessage="Confirm Password Not Matching With New Password" SetFocusOnError="True"></asp:CompareValidator>
                                     </div>						 
							</div>
							
							
						
				<div class="clear"></div>	
				
				<div class="mt-1 form_left">                       
                    <asp:Button ID="CancelBtn" runat="server" Text="Cancel" class="  shadow-md mr-1 mb-2 next_btn_white" UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelBtn_Click" />                    

				</div>
                            <div class="mt-1 form_right">
                                <asp:Button ID="SubmitBtn" runat="server" Text="Submit" class="w-26 shadow-md mr-1 mb-2 text-white next_btn_green" UseSubmitBehavior="false" CausesValidation="True" OnClick="SubmitBtn_Click"/>
                                </div>

		                            	</div>
                        
                    </div>
                    
					
                    
                    </div>
                    
                    <div class="clearfix"></div>
                </div>
           
        </div>
<%-- </div>	--%>		
    
        <script type="text/javascript">
	function show(a) {
  var x=document.getElementById("<%= NewPwdTxt.ClientID %>");
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

          function show2(a) {
  var x=document.getElementById("<%= ConfirmPwdTxt.ClientID %>");
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
    
</asp:Content>
