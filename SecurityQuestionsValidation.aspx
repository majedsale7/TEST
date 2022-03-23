<%@ Page Title="Kuwait Bahrain International Exchange Company : Validate" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SecurityQuestionsValidation.aspx.cs" Inherits="KBE.SecurityQuestionsValidation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
			
			<div class="col-span-12 mt-8 ">
			
			<h1 class="main_heading  truncate  text-center"><span id="IdentifyHlbl" runat="server">IDENTITY VERIFICATION</span></h1>
			  </div> 
						
			
			<div class="col-span-12 sm:col-span-12 xl:col-span-12 intro-y box validate  pading_20  mt-4">		
							
						 <div class="col-span-12">
						
						<div class="grid grid-cols-12 gap-6 form">

                            <div class=" col-span-12 sm:col-span-12 xl:col-span-12 intro-y"><label id="SecurityLevellbl" runat="server" style="color:black"></label></div>

                           <div class="col-span-12 sm:col-span-8 xl:col-span-8 intro-y ">                                                                
                              <label id="SecQuestionlbl" runat="server" style="color:black"></label> 	
                               <div class="clear"></div>	
                               	<div class="mt-1 pass_show"> 
                                 <asp:TextBox ID="SecQuestionAnswerTxt" runat="server" class="input mt-1 border col-span-4" placeholder="" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>                                
                                  <i onclick="show('SecQuestionAnswerTxt')" class="fas fa-eye-slash" id="display"></i>	
                        <asp:requiredfieldvalidator runat="server" errormessage="Security Question Answer Required" ControlToValidate="SecQuestionAnswerTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:requiredfieldvalidator>						
                               </div>
							</div>
                            
							
							
							<div class="col-span-12 sm:col-span-4 xl:col-span-4 intro-y">                              
							  <asp:button runat="server" text="Validate" class=" button flot_lft shadow-md text-white next_btn" id="SecValidateBtn" CausesValidation="true" OnClick="SecValidateBtn_Click" UseSubmitBehavior="true" />
                            </div>
							
							</div>
							</div>

							<div class="clear"></div>
							</div>
			
					
						
	<script type="text/javascript">
	    function show(a) {
	        var x=document.getElementById("<%= SecQuestionAnswerTxt.ClientID %>");
	        var c = x.nextElementSibling
	        if (x.getAttribute('type') == "password") {
	            c.removeAttribute("class");
	            c.setAttribute("class", "fas fa-eye");
	            x.removeAttribute("type");
	            x.setAttribute("type", "text");
	        } else {
	            x.removeAttribute("type");
	            x.setAttribute('type', 'password');
	            c.removeAttribute("class");
	            c.setAttribute("class", "fas fa-eye-slash");
	        }
	    }
   </script>
							
</asp:Content>
