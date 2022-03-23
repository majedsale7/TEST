<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="KBE.Signup" Async="true" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!doctype html>
<html lang="en">
<head>
	<meta charset="utf-8" />
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
	 <title>Kuwait Bahrain International Exchange Company : Signup</title>
    <link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico">

	<meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0' name='viewport' />
    <meta name="viewport" content="width=device-width" />

	<link rel="apple-touch-icon" sizes="76x76" href="img/apple-icon.png" />
	<link rel="icon" type="image/png" href="img/favicon.png" />

	<!--     Fonts and icons     -->
	<link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css" />
	<link href="https://fonts.googleapis.com/css2?family=Almarai:wght@300&display=swap" rel="stylesheet">

    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.1/css/all.css" >

	<!-- CSS Files -->
	<link href="css/bootstrap.min.css" rel="stylesheet" />
	<link href="css/material-bootstrap-wizard.css" rel="stylesheet" />

	<!-- CSS Just for demo purpose, don't include it in your project -->
	<link href="css/app.css" rel="stylesheet" />
	<style>
	html{
	background-color: #97d700;}
	 .ImageAutoSize{
	 width:350px; 
    height: auto;
	  }    
     input[type=checkbox] {
  transform: scale(1.5);
  border-color:forestgreen;
}
	</style>


</head>

<body>
	<div class="image-container set-full-height" >
	    <!--   Creative Tim Branding   -->
	    <!-- <a href="#">
	         <div class="logo-container">
	            <div class="brand">
	                Creative Tim
	            </div>
	        </div>
	    </a>-->

		<!--  Made With Material Kit  -->
		
		<%--<div class="dropdown language">
                                        <button class="dropdown-toggle button inline-block bg-theme-1 text-white">English </button>
                                        <div class="dropdown-box mt-10 absolute top-0 right-0 z-20">
                                            <div class="dropdown-box__content box p-2"> 
											<a href="#" class="block p-2 transition duration-300 ease-in-out bg-white hover:bg-gray-200 rounded-md">English </a> 
											<a href="#" class="block p-2 transition duration-300 ease-in-out bg-white hover:bg-gray-200 rounded-md arabic">عربى</a> </div>
                                        </div>
                                    </div>--%>
		

	    <!--   Big container   -->
	    <div class="container ">
		
		        <div class="col-sm-12  col-lg-6 col-lg-offset-3">
		            <!--      Wizard container        -->
		            <div class="wizard-container">
		                <div class="card wizard-card" data-color="red" id="wizard">
		                    <form runat="server" action="" method="">
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

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>    
		                <!--        You can switch " data-color="blue" "  with one of the next bright colors: "green", "orange", "red", "purple"             -->

		                    	<div class="wizard-header">
								
									<div class="signup_logo"><a href="#" >
                    <img alt="" class="top_logo" src="images/logo_20.svg">
                </a></div>
								
		                        	<h2>
                                        <asp:Label ID="CreateNewAcctlbl" runat="server" Text="CREATE NEW ACCOUNT"></asp:Label>
		                        	</h2>
									
		                    	</div>
                                <div class="wizard-navigation" id="ArabicWZ" runat="server" visible="false">
									<ul>
                                        <li><a href="#validate" data-toggle="tab"> التحقق من صحة المحمول </a></li>
			                            <li><a href="#details" data-toggle="tab">معلومات شخصية </a></li>
			                            <li><a href="#captain" data-toggle="tab"> معلومات للتواصل </a></li>
			                            <li><a href="#description" data-toggle="tab"> حماية المعلومات </a></li>
			                        </ul>
								</div>
								<div class="wizard-navigation" id="EnglishWZ" runat="server" visible="true">
									<ul>
                                        <li><a href="#validate" data-toggle="tab">Mobile Validation</a></li>
			                            <li><a href="#details" data-toggle="tab">Personal Information</a></li>
			                            <li><a href="#captain" data-toggle="tab">Contact Information</a></li>
			                            <li><a href="#description" data-toggle="tab">Security Information</a></li>
			                        </ul>
								</div>

		                        <div class="tab-content">
                                     <div class="tab-pane" id="validate">
                                         <div class="signup_box row">
                                              <div class="col-sm-12">
                       <div class="mt-3"> <label id="civilidlbl" runat="server">Civil Id*</label>    
                                      <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>             
                            <asp:TextBox ID="CIDTxt" runat="server" class="intro-x login__input input input--lg border border-gray-300 block req" MaxLength="12" AutoCompleteType="Disabled" onkeyup="sync()" AutoPostBack="true" OnTextChanged="CIDTxt_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="CIDTxt_ReqF" runat="server" ControlToValidate="CIDTxt" Display="Dynamic" ErrorMessage="Civil ID Required" SetFocusOnError="True" CssClass="Validate-Error"></asp:RequiredFieldValidator>                                                     
                            <ajaxToolkit:FilteredTextBoxExtender ID="CIDTxt_FilteredTextBoxExtender" runat="server" BehaviorID="CIDTxt_FilteredTextBoxExtender" FilterType="Numbers" TargetControlID="CIDTxt" />
                            <asp:RegularExpressionValidator ID="CIDTxt_RegExp" runat="server" ErrorMessage="Invalid Civil ID" Display="Dynamic" ControlToValidate="CIDTxt" CssClass="Validate-Error" SetFocusOnError="True" ValidationExpression="[0-9]{12}"></asp:RegularExpressionValidator>
                                          <div class="clear"></div>	
                                          <asp:Label ID="CIDErrorlbl" runat="server" Text="" CssClass="Validate-Error"></asp:Label>
                                          </ContentTemplate></asp:UpdatePanel>
							 </div>
                               </div>
                                              <div class="col-sm-12">
							<div class="mt-1 form_left"> <label id="mobilenolbl" runat="server">Mobile*</label>
							<div class="clear"></div>		
							 <div class="absolute rounded-l flex items-center justify-center bg-gray-100 border border-gray-300 text-gray-600 mob_code">+965</div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                                <asp:TextBox ID="MobileTxt" runat="server" class="input w-full border border-gray-300 col-span-4 phone req" AutoCompleteType="Disabled" MaxLength="8"></asp:TextBox>                                      
                                <asp:RequiredFieldValidator ID="MobileTxt_ReqF" runat="server" ErrorMessage="Mobile No Required" ControlToValidate="MobileTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>                              
                                 <ajaxToolkit:FilteredTextBoxExtender ID="MobileTxt_FilteredTextBoxExtender" runat="server" BehaviorID="MobileTxt_FilteredTextBoxExtender" FilterType="Numbers" TargetControlID="MobileTxt" />
                                <asp:RegularExpressionValidator ID="MobileTxt_RegExp" runat="server" ErrorMessage="Invalid Mobile No" Display="Dynamic" ControlToValidate="MobileTxt" CssClass="Validate-Error" SetFocusOnError="True" ValidationExpression="^[569]\d{7}$"></asp:RegularExpressionValidator>
                                    </ContentTemplate></asp:UpdatePanel>
							 </div>

							 <div class="mt-1 form_right">
							 <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate> --%>
                                 <label id="enterOTPlbl" runat="server">Enter OTP*</label>

							                                                   <%--</ContentTemplate></asp:UpdatePanel>--%>
							<div class="clear"></div>									 
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                                    <div class="clear"></div>
                                <div class="pass_show">
                                <asp:TextBox ID="OTPTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" AutoCompleteType="Disabled" AutoPostBack="true" OnTextChanged="OTPTxt_TextChanged" TextMode="Password"></asp:TextBox>  
                                    <i onclick="showotp('OTPTxt')" class="fas fa-eye-slash" id="displayotp"></i>
                                <asp:RequiredFieldValidator ID="OTPTxt_ReqF" runat="server" ErrorMessage="OTP Required" ControlToValidate="OTPTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                     </div>
                                    <div class="clear"></div>	
                                    <asp:Label ID="OTPinvalidlbl" runat="server" Text="" CssClass="Validate-Error"></asp:Label>
                                    </ContentTemplate></asp:UpdatePanel>                                    
							</div>	
                                                  	<div class="clear"></div>		
                            </div>	
                                             <div class="col-sm-12">
                                                 <div class="mt-3">                                                      
                           <asp:Button ID="OTPSendBtn" runat="server" Text="Resend OTP" class=" w-24 mr-1 mb-2 bg-theme-1 text-white resnd_otp_btn" UseSubmitBehavior="false" CausesValidation="false" OnClick="OTPSendBtn_Click" ForeColor="Black"/>
                            <span class="resnd_otp" id="CounterSpan" runat="server"> ( OTP expires in <span id="Counterlbl" runat="server" style="color:red; font-weight:bold"></span> Secs  )</span>
						<asp:HiddenField ID="InitiSecs_HD" runat="server" />                                                        
                                                     </div>
                                                 </div>
                                               <%--<div style="clear:both;"></div>
                         <div class="mt-2"> 
                        <asp:Button ID="ResendBtn" runat="server" Text="Resend OTP" class=" text-black " UseSubmitBehavior="false" CausesValidation="True" OnClick="ResendBtn_Click" Visible="false" ForeColor="Black"/>
						<span class="resnd_otp" runat="server" id="CounterSpan" visible="false" style="color:black;"> ( OTP expires in <span id="Counterlbl" runat="server" style="color:red; font-weight:bold"></span> Secs  )</span>
                        <asp:HiddenField ID="InitiSecs_HD" runat="server" />
                             </div>--%>

                                              <div class="wizard-footer">
	                            	<div class="">								
										
	                                    <input type="button" class="btn  btn-fill btn-danger btn-wd btn-ok" name="next" value="Next" id="NextBtn0" runat="server" />                               
	                                    
										
	                                </div>
									</div>

                                         <div class="clear"></div>	
		                            	</div>
                                     </div>

		                            <div class="tab-pane" id="details">
		                            	<div class="signup_box row">
				
                       <%-- <div class="col-sm-12">
                       <div class="mt-3"> <label id="civilidlbl" runat="server">Civil Id*</label>                            
                            <asp:TextBox ID="CIDTxt" runat="server" class="intro-x login__input input input--lg border border-gray-300 block req" MaxLength="12"  onkeyup="sync()"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CIDTxt" Display="Dynamic" ErrorMessage="Civil ID Required" SetFocusOnError="True" CssClass="Validate-Error"></asp:RequiredFieldValidator>                                                     
                            <ajaxToolkit:FilteredTextBoxExtender ID="CIDTxt_FilteredTextBoxExtender" runat="server" BehaviorID="CIDTxt_FilteredTextBoxExtender" FilterType="Numbers" TargetControlID="CIDTxt" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Civil ID" Display="Dynamic" ControlToValidate="CIDTxt" CssClass="Validate-Error" SetFocusOnError="True" ValidationExpression="[0-9]{12}"></asp:RegularExpressionValidator>
							 </div>
                               </div>--%>
                             <div class="col-sm-12">
							<div class="mt-1 form_left"> <label id="firstnamelbl" runat="server">First Name*</label>
                                <asp:TextBox ID="FNameTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" AutoCompleteType="Disabled" ></asp:TextBox>			
                                <asp:RequiredFieldValidator ID="FNameTxt_ReqF" runat="server" ErrorMessage="First Name Required" ControlToValidate="FNameTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="FNameTxt_RegExp" runat="server" ErrorMessage="Invalid First Name" Display="Dynamic" ControlToValidate="FNameTxt" CssClass="Validate-Error" SetFocusOnError="True" ValidationExpression="^[a-zA-Z \u0621-\u064A ]{4,}$"></asp:RegularExpressionValidator>
							 </div>
                                 <div class="mt-1 form_right">
							 <label id="middlenamelbl" runat="server">Middle Name</label>
                                 <asp:TextBox ID="MNameTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block " AutoCompleteType="Disabled" ></asp:TextBox>						                                 			
                                 <asp:RegularExpressionValidator ID="MNameTxt_RegExp" runat="server" ErrorMessage="Invalid Middle Name" Display="Dynamic" ControlToValidate="MNameTxt" CssClass="Validate-Error" SetFocusOnError="True" ValidationExpression="^[a-zA-Z \u0621-\u064A ]{4,}$"></asp:RegularExpressionValidator>
							</div>							
                                 </div>
                            <div class="col-sm-12">
                                 <div class="mt-1 form_left">
							 <label id="lastnamelbl" runat="server">Last Name*</label>
                                 <asp:TextBox ID="LNameTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" AutoCompleteType="Disabled" ></asp:TextBox>							
                                 <asp:RequiredFieldValidator ID="LNameTxt_ReqF" runat="server" ErrorMessage="Last Name Required" ControlToValidate="LNameTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>				
                                 <asp:RegularExpressionValidator ID="LNameTxt_RegExp" runat="server" ErrorMessage="Invalid Last Name" Display="Dynamic" ControlToValidate="LNameTxt" CssClass="Validate-Error" SetFocusOnError="True" ValidationExpression="^[a-zA-Z \u0621-\u064A ]*$"></asp:RegularExpressionValidator>
							</div>
                                <div class="mt-1 form_right">
							 <label id="salarylbl" runat="server">Salary*</label>							
                                 <asp:DropDownList ID="SalaryDDL" runat="server" class="select2  req" DataSourceID="Salary_ODS" DataTextField="DESC_E" DataValueField="LOOKUP_ID" AppendDataBoundItems="True"></asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="SalaryDDL_ReqF" runat="server" ErrorMessage="Salary Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="SalaryDDL" InitialValue=""></asp:RequiredFieldValidator>
							</div>
                                <div class="clear"></div>	
                                </div>
                                             <div class="col-sm-12">
                       <div class="mt-3"> <label id="sponsorlbl" runat="server">Sponsor (Company) Name*</label>                            
                            <asp:TextBox ID="SponsorTxt" runat="server" class="intro-x login__input input input--lg border border-gray-300 block req" AutoCompleteType="Disabled" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="SponsorTxt_ReqF" runat="server" ControlToValidate="SponsorTxt" Display="Dynamic" ErrorMessage="Sponsor Name Required" SetFocusOnError="True" CssClass="Validate-Error"></asp:RequiredFieldValidator>                                                     
                            <asp:RegularExpressionValidator ID="SponsorTxt_RegExp" runat="server" ErrorMessage="Invalid Sponsor Name" Display="Dynamic" ControlToValidate="SponsorTxt" CssClass="Validate-Error" SetFocusOnError="True" ValidationExpression="^[a-zA-Z \u0621-\u064A ]*$"></asp:RegularExpressionValidator>
							 </div>
                               </div>
                                            <div class="col-sm-12">
							<div class="mt-1 form_left"> <label id="genderlbl" runat="server">Gender*</label>							
                                <asp:DropDownList ID="GenderDDL" runat="server" class="select2 ">
                                    <asp:ListItem Selected="True" Value="M">Male</asp:ListItem>
                                    <asp:ListItem Value="F">Female</asp:ListItem>
                                </asp:DropDownList>
							 </div>
							 <div class="mt-1 form_right">
							 <label id="nationalitylbl" runat="server">Nationality*</label>							
                                 <asp:DropDownList ID="CountryDDL" runat="server" class="select2  req" DataSourceID="Country_ODS" DataTextField="COUN_NAME" DataValueField="COUN_CODE3" AppendDataBoundItems="True"></asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="CountryDDL_ReqF" runat="server" ErrorMessage="Nationality Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="CountryDDL" InitialValue=""></asp:RequiredFieldValidator>
							</div>
                                                <div class="clear"></div>
                                                </div>
							
							
							<div class="col-sm-12">
							<div class="mt-1 form_left"> <label id="dateofbirthlbl" runat="server">Date Of Birth*</label>
                               <asp:TextBox ID="DOBTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block datepickerDOB req" ></asp:TextBox>		
                                <asp:RequiredFieldValidator ID="DOBTxt_ReqF" runat="server" ErrorMessage="Date Of Birth Required" ControlToValidate="DOBTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="DOBTxt_RegExp" runat="server" ErrorMessage="Invalid Date Of Birth" ControlToValidate="DOBTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator>
							 </div>
							 <div class="mt-1 form_right">                                 
							 <label id="CivilIDExpirylbl" runat="server">Civil Id Expiry*</label>
                                 <asp:TextBox ID="CIDExpTxt" runat="server" class="intro-x input input--lg border border-gray-300 block datepickerCID req" ></asp:TextBox>	                                 
                                 <asp:RequiredFieldValidator ID="CIDExpTxt_ReqF" runat="server" ErrorMessage="Civil ID Expiry Required" ControlToValidate="CIDExpTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="CIDExpTxt_RegExp" runat="server" ErrorMessage="Invalid Civil ID Expiry" ControlToValidate="CIDExpTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator>
							</div>
							</div>
                              <div class="col-sm-12">
							<div class="mt-1"> <label id="occupationlbl" runat="server">Occupation</label>							
                                <asp:DropDownList ID="OccupDDL" runat="server" class="select2 " DataSourceID="Occup_ODS" DataTextField="DESC_E" DataValueField="LOOKUP_ID" AppendDataBoundItems="True"></asp:DropDownList>
							 </div>
						</div>
						
                                             <div class="wizard-footer">
	                            	<div class="">								
										<input type="button" class="btn  btn-previous btn-fill btn-danger btn-wd" name="back" value="Back" id="BackBtn1" runat="server" />
	                                    <input type="button" class="btn  btn-fill btn-danger btn-wd btn-ok" name="next" value="Next" id="NextBtn1" runat="server" />                               
	                                    

										
	                                </div>
									</div>
						
				<div class="clear"></div>	


		                            	</div>
		                            </div>
		                            <div class="tab-pane" id="captain" runat="server">
									
									<div class="signup_box row">
				
                       <%-- <div class="col-sm-12">
							<div class="mt-1 form_left"> <label id="mobilenolbl" runat="server">Mobile*</label>
							<div class="clear"></div>		
							 <div class="absolute rounded-l flex items-center justify-center bg-gray-100 border border-gray-300 text-gray-600 mob_code">+965</div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                                <asp:TextBox ID="MobileTxt" runat="server" class="input w-full border border-gray-300 col-span-4 phone req" AutoPostBack="true" OnTextChanged="MobileTxt_TextChanged"></asp:TextBox>  
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Mobile No Required" ControlToValidate="MobileTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>                              
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Mobile No" Display="Dynamic" ControlToValidate="MobileTxt" CssClass="Validate-Error" SetFocusOnError="True" ValidationExpression="^[569]\d{7}$"></asp:RegularExpressionValidator>
                                    </ContentTemplate></asp:UpdatePanel>
							 </div>
							 <div class="mt-1 form_right">
							 <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate> <label id="enterOTPlbl" runat="server" visible="false">Enter OTP*</label></ContentTemplate></asp:UpdatePanel>
							<div class="clear"></div>									 
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                                <asp:TextBox ID="OTPTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" Visible="false" AutoPostBack="true" OnTextChanged="OTPTxt_TextChanged"></asp:TextBox>  
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="OTP Required" ControlToValidate="OTPTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <div class="clear"></div>	
                                    <asp:Label ID="OTPinvalidlbl" runat="server" Text="" CssClass="Validate-Error"></asp:Label>
                                    </ContentTemplate></asp:UpdatePanel>
							</div>	
                            </div>	--%>
                         
                          <div class="col-sm-12" >
							<div class="mt-3">
                                 <label id="emaillbl" runat="server">Email</label>
                                 <asp:TextBox ID="EmailTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block " AutoCompleteType="Disabled"></asp:TextBox>		
                                 <asp:RegularExpressionValidator ID="EmailTxt_RegExp" runat="server" ErrorMessage="Invalid Email ID" ControlToValidate="EmailTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>	
							 </div>
                            </div>						
							
                                        <div class="col-sm-12">
							<div class="mt-1 form_left"> <label id="areainkuwaitlbl" runat="server">Area in Kuwait*</label>
                                <asp:TextBox ID="AreaTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" AutoCompleteType="Disabled"></asp:TextBox>		
                                <asp:RequiredFieldValidator ID="AreaTxt_ReqF" runat="server" ErrorMessage="Area Required" ControlToValidate="AreaTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
							 </div>
							 <div class="mt-1 form_right">
							 <label id="blocklbl" runat="server">Block*</label>
                                 <asp:TextBox ID="BlockTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" AutoCompleteType="Disabled"></asp:TextBox>	
                                <asp:RequiredFieldValidator ID="BlockTxt_ReqF" runat="server" ErrorMessage="Block Required" ControlToValidate="BlockTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
							</div>
                                            </div>
							<div class="col-sm-12">
							<div class="mt-1 form_left"> <label id="streetlbl" runat="server">Street*</label>
                                <asp:TextBox ID="StreetTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" AutoCompleteType="Disabled"></asp:TextBox>	
                                <asp:RequiredFieldValidator ID="StreetTxt_ReqF" runat="server" ErrorMessage="Street Required" ControlToValidate="StreetTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
							 </div>
							 <div class="mt-1 form_right">
							 <label id="buildingnolbl" runat="server">Building No*</label>
                                 <asp:TextBox ID="BuildingTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" AutoCompleteType="Disabled"></asp:TextBox>	
                                 <asp:RequiredFieldValidator ID="BuildingTxt_ReqF" runat="server" ErrorMessage="Building Required" ControlToValidate="BuildingTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
							</div>
                                </div>
                                        <div class="col-sm-12">
							<div class="mt-1 form_left"> <label id="floornolbl" runat="server">Floor No*</label>
                                <asp:TextBox ID="FloorTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" AutoCompleteType="Disabled"></asp:TextBox>	
                                <asp:RequiredFieldValidator ID="FloorTxt_ReqF" runat="server" ErrorMessage="Floor No Required" ControlToValidate="FloorTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
							 </div>
							 <div class="mt-1 form_right">
							 <label id="flatnolbl" runat="server">Flat No*</label>
                                 <asp:TextBox ID="FlatTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" AutoCompleteType="Disabled"></asp:TextBox>	
                                 <asp:RequiredFieldValidator ID="FlatTxt_ReqF" runat="server" ErrorMessage="Flat No Required" ControlToValidate="FlatTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
							</div>
                                            </div>
						
						
								<div class="wizard-footer">
	                            	<div class="">
									
										<input type="button" class="btn  btn-previous btn-fill btn-danger btn-wd" name="back" value="Back" id="BackBtn2" runat="server" />
	                                    <input type="button" class="btn  btn-fill btn-danger btn-wd btn-ok" name="next" value="Next" id="NextBtn2" runat="server" />                                    

										
	                                </div>
									</div>
							                       
						
						
				<div class="clear"></div>		
						
            </div>
		                                
		                            </div>
									
									
		                            <div class="tab-pane" id="description" runat="server">
		                                
										 <div class="signup_box row">
				
                                             <div class="col-sm-12">
                        <div class="mt-3"> <label id="loginidlbl" runat="server">Login Id</label>
                            <asp:TextBox ID="LoginIDTxt" runat="server" class="intro-x login__input input input--lg border border-gray-300 block req" ReadOnly="True"></asp:TextBox>                                                        
							 </div>
                                                 </div>
                                             <div class="col-sm-12">
							<div class="mt-1 form_left"> <label id="passwordlbl" runat="server">Password*</label>
                                <div class="clear"></div>
                                <div class="pass_show">
                                <asp:TextBox ID="PWDTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" TextMode="Password"></asp:TextBox>	
                                <i onclick="showp('PWDTxt')" class="fas fa-eye-slash" id="displayp"></i>
                                <asp:RequiredFieldValidator ID="PWDTxt_ReqF" runat="server" ErrorMessage="Password Required" ControlToValidate="PWDTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="PWDTxt_RegExp" runat="server" ErrorMessage="<br/>Password Required <br/> Total 8 or more Characters<br/> Minimum 1 Number<br/> 1 Upper Case <br/>1 Lower Case Characters <br/>1 Special Character" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[~!@#$%^&*()_+`=}{|\/?><.,])[a-zA-Z\d~!@#$%^&*()_+`=}{|\/?><.,]{8,}$" ControlToValidate="PWDTxt" CssClass="Validate-Error"></asp:RegularExpressionValidator>
                                <ajaxToolkit:PasswordStrength ID="PWDTxt_PasswordStrength" runat="server" BehaviorID="PWDTxt_PasswordStrength" CalculationWeightings="50;25;25;0" DisplayPosition="BelowLeft" HelpHandlePosition="BelowLeft" PreferredPasswordLength="10" TargetControlID="PWDTxt" TextCssClass="Validate-Error" TextStrengthDescriptions="Poor;Weak;Average;Good;Excellent" />
                                    </div>
							 </div>
							 <div class="mt-1 form_right">
							 <label id="confirmpasswordlbl" runat="server">Confirm Password*</label>
                                  <div class="clear"></div>
                                 <div class="pass_show">
                                 <asp:TextBox ID="CPWDTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" TextMode="Password"></asp:TextBox>	
                                     <i onclick="showcp('CPWDTxt')" class="fas fa-eye-slash" id="displaycp"></i>
                                <asp:RequiredFieldValidator ID="CPWDTxt_ReqF" runat="server" ErrorMessage="Confirm Password Required" ControlToValidate="CPWDTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                 <asp:CompareValidator ID="CPWDTxt_CompV" runat="server" ControlToCompare="PWDTxt" ControlToValidate="CPWDTxt" CssClass="Validate-Error" Display="Dynamic" ErrorMessage="Confirm Password Not Matching With New Password" SetFocusOnError="True"></asp:CompareValidator>
                                     </div>
							</div>
                                                 </div>
							<div class="col-sm-12">
							<div class="mt-3"> <label id="securityquestion1lbl" runat="server"> Security Questions1*</label>
							
                                <asp:DropDownList ID="SecQ1DDL" runat="server" class="select2 req" DataSourceID="SecQ1_ODS" DataTextField="QUESTION" DataValueField="QUES_ID" AppendDataBoundItems="True"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="SecQ1DDL_ReqF" runat="server" ErrorMessage="Security Question Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="SecQ1DDL" InitialValue="Select Question"></asp:RequiredFieldValidator>
 </div>
                                </div>
                                             <div class="col-sm-12">
 <div class="mt-3"> <label id="answer1lbl" runat="server"> Answer*</label>       
                                <div class="clear"></div>
                                 <div class="pass_show">                     
                            <asp:TextBox ID="SecQ1Txt" runat="server" class="intro-x login__input input input--lg border border-gray-300 block req" TextMode="Password"></asp:TextBox>
                                <i onclick="shows1('SecQ1Txt')" class="fas fa-eye-slash" id="displays1"></i>
                            <asp:RequiredFieldValidator ID="SecQ1Txt_ReqF" runat="server" ErrorMessage="Security Answer Required" ControlToValidate="SecQ1Txt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                     </div>
							 </div>
                                                 </div>
							 <div class="col-sm-12">
							 <div class="mt-3"> <label id="securityquestion2lbl" runat="server"> Security Questions2*</label>
							
                                 <asp:DropDownList ID="SecQ2DDL" runat="server" class="select2 req" DataSourceID="SecQ1_ODS" DataTextField="QUESTION" DataValueField="QUES_ID" AppendDataBoundItems="True"></asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="SecQ2DDL_ReqF" runat="server" ErrorMessage="Security Question Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="SecQ2DDL" InitialValue="Select Question"></asp:RequiredFieldValidator>
                                 <asp:CompareValidator ID="SecQ2DDL_CompV" runat="server" ErrorMessage="Security questions 1 & 2 should not be same" Display="Dynamic" CssClass="Validate-Error" SetFocusOnError="True" ControlToCompare="SecQ1DDL" ControlToValidate="SecQ2DDL" Operator="NotEqual"></asp:CompareValidator>
 </div>
                                 </div>
                                             <div class="col-sm-12">
 <div class="mt-3"> <label id="answer2lbl" runat="server"> Answer*</label>
                            <div class="clear"></div>
                                 <div class="pass_show">                     
          <asp:TextBox ID="SecQ2Txt" runat="server" class="intro-x login__input input input--lg border border-gray-300 block req" TextMode="Password"></asp:TextBox>
                                     <i onclick="shows2('SecQ2Txt')" class="fas fa-eye-slash" id="displays2"></i>
     <asp:RequiredFieldValidator ID="SecQ2Txt_ReqF" runat="server" ErrorMessage="Security Answer Required" ControlToValidate="SecQ2Txt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                     </div>
							 </div>
                                                 </div>
							 <div class="col-sm-12">
							 <div class="mt-3"> <label id="securityquestion3lbl" runat="server"> Security Questions3</label>
							
                                 <asp:DropDownList ID="SecQ3DDL" runat="server" class="select2 req" DataSourceID="SecQ2_ODS" DataTextField="QUESTION" DataValueField="QUES_ID" AppendDataBoundItems="True"></asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="SecQ3DDL_ReqF" runat="server" ErrorMessage="Security Question Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="SecQ3DDL" InitialValue="Select Question"></asp:RequiredFieldValidator>
 </div>
                                 </div>
<div class="col-sm-12">
 <div class="mt-3"> <label id="answer3lbl" runat="server"> Answer*</label>
     <div class="clear"></div>
                                 <div class="pass_show">
          <asp:TextBox ID="SecQ3Txt" runat="server" class="intro-x login__input input input--lg border border-gray-300 block req" TextMode="Password"></asp:TextBox>
                                     <i onclick="shows3('SecQ3Txt')" class="fas fa-eye-slash" id="displays3"></i>
     <asp:RequiredFieldValidator ID="SecQ3Txt_ReqF" runat="server" ErrorMessage="Security Answer Required" ControlToValidate="SecQ3Txt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                     </div>
							 </div>
    </div>

                                             							 <div class="col-sm-12">
							 <div class="mt-3"> <label id="securityquestion4lbl" runat="server"> Security Questions4</label>
							
                                 <asp:DropDownList ID="SecQ4DDL" runat="server" class="select2 req" DataSourceID="SecQ2_ODS" DataTextField="QUESTION" DataValueField="QUES_ID" AppendDataBoundItems="True"></asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="SecQ4DDL_ReqF" runat="server" ErrorMessage="Security Question Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="SecQ4DDL" InitialValue="Select Question"></asp:RequiredFieldValidator>
                                 <asp:CompareValidator ID="SecQ4DDL_CompV" runat="server" ErrorMessage="Security questions 3 & 4 should not be same" CultureInvariantValues="False" Display="Dynamic" SetFocusOnError="True" CssClass="Validate-Error" ControlToCompare="SecQ3DDL" ControlToValidate="SecQ4DDL" Operator="NotEqual"></asp:CompareValidator>
 </div>
                                 </div>
<div class="col-sm-12">
 <div class="mt-3"> <label id="answer4lbl" runat="server"> Answer*</label>
     <div class="clear"></div>
                                 <div class="pass_show">
          <asp:TextBox ID="SecQ4Txt" runat="server" class="intro-x login__input input input--lg border border-gray-300 block req" TextMode="Password"></asp:TextBox>
                                     <i onclick="shows4('SecQ4Txt')" class="fas fa-eye-slash" id="displays4"></i>
     <asp:RequiredFieldValidator ID="SecQ4Txt_ReqF" runat="server" ErrorMessage="Security Answer Required" ControlToValidate="SecQ4Txt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                     </div>
							 </div>
    </div>

							 <div class="col-sm-12">
							 <div class="mt-3"> <label id="FrontCIDUploadlbl" runat="server">Front Civil Id Upload (Only JPG / PNG)</label>
                                 <div class="clear"></div>	
                             <%--<input type="file" id="exampleInputFile">--%>
                                 <asp:FileUpload ID="FUCID" runat="server" onchange="showpreviewCID(this);" ViewStateMode="Enabled" accept=".png,.jpg,.jpeg"/> 
                                 <asp:RequiredFieldValidator ID="FUCID_ReqF" runat="server" ErrorMessage="Front Civil ID Photo Required" Display="Dynamic" ControlToValidate="FUCID" SetFocusOnError="True" CssClass="Validate-Error"></asp:RequiredFieldValidator>
                                <div class="clear"></div>	
                                 <label id="Imagesizelbl" runat="server">(Image Size Should be less than 2MB)</label>
                                <div class="clear"></div>	
                                 <img id="imgpreviewCID" height="auto" width="100" src="" style="border-width: 0px; visibility: hidden;" />
                                 <br />
							 </div>
                                 </div>
							
                           <div class="clear"></div>
                            <div class="clear"></div>	

                                             <div class="col-sm-12">
                            <div class="mt-3"> <label id="BackCIDUplaodlbl" runat="server">Back Civil Id Upload (Only JPG / PNG)</label>      
                                <div class="clear"></div>	                       
                                 <asp:FileUpload ID="FUCID2" runat="server" onchange="showpreviewCID2(this);" ViewStateMode="Enabled" accept=".png,.jpg,.jpeg"/>
                                <asp:RequiredFieldValidator ID="FUCID2_ReqF" runat="server" ErrorMessage="Back Civil ID Photo Required" Display="Dynamic" ControlToValidate="FUCID2" SetFocusOnError="True" CssClass="Validate-Error"></asp:RequiredFieldValidator>
                                <div class="clear"></div>	
                                <label id="Imagesizelbl2" runat="server">(Image Size Should be less than 2MB)</label>                                 
                                <div class="clear"></div>	
                                 <img id="imgpreviewCID2" height="auto" width="100" src="" style="border-width: 0px; visibility: hidden;" />
							 </div>
                                                 </div>

                                              <div class="clear"></div>            

                                          <div class="col-sm-12 check"> 					
                                <label> <input type="checkbox" class="input border mt-1" id="ConfirmCHK" runat="server">
                                <label id="Agreelbl" runat="server" for="ConfirmCHK">I Accept & Agree your Terms & Conditions</label> &nbsp;&nbsp;&nbsp; <a href="javascript:;" data-toggle="modal" data-target="#terms_conditions" runat="server" id="ReadtncAnchor" > Read Terms & Conditions </a> </label>
                                <asp:CustomValidator ID="ConfirmCHK_ReqF" runat="server" ErrorMessage="Terms & Conditions Confirmation Required" CssClass="Validate-Error" ClientValidationFunction = "ValidateCheckBox"></asp:CustomValidator>
                             </div>        

                           
                            <div class="clear"></div>                          

						
						
				<div class="clear"></div>		

                                           
						
            </div>
										
		                            </div>
									
									
									
									
		                        </div>
	                        	<div class="wizard-footer">
	                            	<div class="">
									
									<%--	<input type='button' class='btn btn-previous btn-fill btn-default btn-wd' name='back' runat="server" id="BackBtn" value='Back' />
	                                    <input type='button' class='btn btn-next btn-fill btn-danger btn-wd' name='next' runat="server" id="NextBtn" value='Next' />--%> <%--onclick="ValidatePage();"--%>
	                                    <%--<input type='button' class='btn btn-finish btn-fill btn-danger btn-wd' name='submit' value='Submit' />--%>
                                        <input type="button" name="submit" id="btnSubmit" value="Submit" class='btn btn-finish btn-fill btn-danger btn-wd' runat="server" onserverclick="SubmitBtn_Click"/>
                                                                            

										
	                                </div>
	                                <div class="clearfix"></div>

                                    		<!----------7-9-20------->
									<div class="signup_signin">
					<p><a href="login"><span id="Signinlbl" runat="server">Sign in instead</span> </a></p>
					</div>
					
					<div class="clearfix"></div>
					
						<!----------7-9-20------->

	                        	</div>

     <asp:ObjectDataSource ID="Country_ODS" runat="server" SelectMethod="Country_BS" TypeName="KBE.RESTFull.RESTClass"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="Occup_ODS" runat="server" SelectMethod="Occupations" TypeName="KBE.RESTFull.RESTClass"></asp:ObjectDataSource>
     <asp:ObjectDataSource ID="Salary_ODS" runat="server" SelectMethod="SalaryRange" TypeName="KBE.RESTFull.RESTClass"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="SecQ1_ODS" runat="server" SelectMethod="SecurityQ1" TypeName="KBE.RESTFull.RESTClass"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="SecQ2_ODS" runat="server" SelectMethod="SecurityQ2" TypeName="KBE.RESTFull.RESTClass"></asp:ObjectDataSource>
    <%--<asp:ObjectDataSource ID="SecQ3_ODS" runat="server" SelectMethod="SecurityQ3" TypeName="KBE.RESTFull.RESTClass"></asp:ObjectDataSource>--%>
                                  
                                                       

		                    </form>
		                </div>
		            </div> <!-- wizard container -->
                    

		        </div>
		</div> <!--  big container -->

	   
	</div>


  <!--Success--->
 <div class="modal" id="successmsg" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
     <div class="modal__content">
         <div class="p-5 text-center "> <i data-feather="check-circle" class="w-16 h-16 text-theme-9 mx-auto mt-3"></i>
             <div class="text-3xl mt-2">Success!</div>
             <div class="text-gray-600 mt-1 mb-2"> <asp:Label ID="SuccessMsglbl" runat="server" Text=""></asp:Label></div>
         </div>
         <!--<div class="px-5 pb-8 text-center"> <button type="button" data-dismiss="modal" class="button w-24 bg-theme-1 text-white">Ok</button> </div>-->
     </div>
 </div>
 <!--Success--->

      <!------12-11-2020 Star------->
	<div class="modal" id="terms_conditions">
     <div class="modal__content">
         <div class="flex items-center px-5 py-5 sm:py-3 border-b border-gray-200 dark:border-dark-5">
             <h2 class="font-medium text-base mr-auto"> <asp:Label ID="TnClbl" runat="server" Text="Terms & Conditions"></asp:Label></h2> 
            <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="background: #d7dce1;"><span aria-hidden="true" ><i data-feather="x" class="w-8 h-8 " style="color: #000;"></i></span></button>
         </div>
         <div class="p-5 ">
             
             <asp:Label ID="TnCPara" runat="server" Text=""></asp:Label>        
            <%--<h3>Lorem Ipsum is simply dummy text of the printing and typesetting</h3> 
			<p> Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. </p>					
		 --%>
		 </div>
         
     </div>
 </div>
 <!------12-11-2020 end------->
 
 
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


    
   
       
  
 <script>
function sync()
{
    var n1 = document.getElementById('CIDTxt');
    var n2 = document.getElementById('LoginIDTxt');
  n2.value = n1.value;
}

 function ValidateCheckBox(sender, args) {
     if (document.getElementById("<%=ConfirmCHK.ClientID %>").checked == true) {         
                args.IsValid = true;
     } else {
         args.IsValid = false;
            }
 }
 
</script>

      <script type="text/javascript">
          function showpreviewCID(input) {

            if (input.files && input.files[0]) {

                var reader = new FileReader();
                reader.onload = function(e) {
                    $('#imgpreviewCID').css('visibility', 'visible');
                    $('#imgpreviewCID').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }

          }
          function showpreviewCID2(input) {

              if (input.files && input.files[0]) {

                  var reader = new FileReader();
                  reader.onload = function (e) {
                      $('#imgpreviewCID2').css('visibility', 'visible');
                      $('#imgpreviewCID2').attr('src', e.target.result);
                  }
                  reader.readAsDataURL(input.files[0]);
              }

          }
          </script>
    	
        <script>
            window.onload = function () {
                document.getElementById("CIDTxt").focus();

                    //if (Page_ClientValidate("")) {
                    //    //alert('its valid');
                    //}
                    //else {
                    //    //alert('Please Input Valid Information')
                    //}
            };

            //function ValidatePage()
            //{
            //    var wizard = $('#rootwizard').bootstrapWizard();
            //    alert('Validation test')
                
            //}
    </script>
    
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

	<!--   Core JS Files   -->
	<script src="js/app_DDLSearch.js"></script>
	<script src="js/jquery-2.2.4.min.js" type="text/javascript"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/js/select2.full.js" type="text/javascript"></script>
    <script type="text/javascript">
        function matchStart (term, text) {
        if (text.toUpperCase().indexOf(term.toUpperCase()) == 0) {
                return true;
            } 
        return false;
            }
 
        $.fn.select2.amd.require(['select2/compat/matcher'], function (oldMatcher) {
        $("select").select2({
            matcher: oldMatcher(matchStart)
            })
          });
        </script>

	<script src="js/bootstrap.min.js" type="text/javascript"></script>
	<script src="js/jquery.bootstrap.js" type="text/javascript"></script>



	<!--  Plugin for the Wizard -->
	<script src="js/material-bootstrap-wizard.js"></script>

	<!--  More information about jquery.validate here: http://jqueryvalidation.org/	 -->
	<script src="js/jquery.validate.min.js"></script>
 

      <script type="text/javascript">
//        $(document).ready(function () {
//    $('.dropdown-box__content a').click(function(event) {
//        var option = $(event.target).text();
//        $(event.target).parents('.language').find('.button').html(option);
//    });
//});
$('[data-toggle=tab]').click(function () {
  return false;}
).addClass("text-muted");

var validated = function(tab1){

  tab1.unbind('click').removeClass('text-muted');
 tab1.tab('show');
}

//validate inputs on click of button
$('.btn-ok').click(function(){
  
    var allValid = true;
	count=0;
	count1=0;
    // get each input in this tab pane and validate
    $(this).parents('.tab-pane').find('.req').each(function(i,e){
         
        // some condition(s) to validate each input
        var len = $(e).val().length;
        if (len>0){
		
            // validation passed
            allValid = true;
			count++;
        } else {
            // validation failed
            allValid = false;
            count1++;

			Page_ClientValidate("");
        }
       
    });
 
    if (count1==0) {
	
        var tabIndex = $(this).parents('.tab-pane').index();
		id=$(this).parents('.tab-pane').attr('id');
        validated($('[data-toggle=tab]').eq(tabIndex+1));	
		
		
    }
    
});

// always validate first tab
validated($('[data-toggle]').eq(0));
    

function showotp(a) {
    var x = document.getElementById("<%= OTPTxt.ClientID %>");
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
function showp(a) {
    var x = document.getElementById("<%= PWDTxt.ClientID %>");
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
          function showcp(a) {
    var x = document.getElementById("<%= CPWDTxt.ClientID %>");
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

           function shows1(a) {
    var x = document.getElementById("<%= SecQ1Txt.ClientID %>");
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

           function shows2(a) {
    var x = document.getElementById("<%= SecQ2Txt.ClientID %>");
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

           function shows3(a) {
    var x = document.getElementById("<%= SecQ3Txt.ClientID %>");
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

           function shows4(a) {
    var x = document.getElementById("<%= SecQ4Txt.ClientID %>");
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


    <script type="text/javascript">
    
          var CounterValue = parseInt(document.getElementById("<%= InitiSecs_HD.ClientID %>").value);              
        

var x = setInterval(function() {
              
    if (CounterValue > 0)
        document.getElementById("OTPSendBtn").disabled = true;       
   
    document.getElementById('Counterlbl').innerText = CounterValue;
    <%--document.getElementById("<%= Counterlbl.ClientID %>").innerText = CounterValue;  --%>
    CounterValue = CounterValue - 1;        
    document.getElementById("<%= InitiSecs_HD.ClientID %>").value = CounterValue;  

    isHidden(document.getElementById('CounterSpan'));

    if (CounterValue < 0) {
      clearInterval(x);         
    
      document.getElementById('Counterlbl').innerText = "0";
      <%--document.getElementById("<%= Counterlbl.ClientID %>").innerText = "0";  --%>
        document.getElementById("OTPSendBtn").disabled = false;     
        document.getElementById('CounterSpan').style.display = "none";
        document.getElementById("<%= InitiSecs_HD.ClientID %>").value = "";  
      
    }

    if (document.getElementById("OTPTxt").disabled)
    {
        document.getElementById('Counterlbl').innerText = "0";
        <%--document.getElementById("<%= Counterlbl.ClientID %>").innerText = "0";  --%>
        document.getElementById("OTPSendBtn").disabled = true;     
        document.getElementById('CounterSpan').style.display = "none";
        document.getElementById("<%= InitiSecs_HD.ClientID %>").value = "";         
    }

    function isHidden(el) {
        document.getElementById("NextBtn0").disabled = false;
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


  

	</body>

</html>
