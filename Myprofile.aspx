<%@ Page Title="Kuwait Bahrain International Exchange Company : My Profile" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Myprofile.aspx.cs" Inherits="KBE.Myprofile" Async="true" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--    <link href="https://fonts.googleapis.com/css2?family=Almarai:wght@300&display=swap" rel="stylesheet">--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <%--    <div class="content">--%>
                <!-- BEGIN: Top Bar -->             
    			
			<div class="col-span-12 mt-8 ">
			
			<h1 class="main_heading  truncate  text-center"> <asp:Label ID="MyProfilelbl_P" runat="server" Text="My Profile"></asp:Label></h1>
			  </div> 
			 
			
			
			
			<div class="grid grid-cols-12 gap-6 mt-5 form profile">
						
                            <div class="col-span-12 mt-2 sm:col-span-6 xl:col-span-4 intro-y benficalry ">	
							<div class="box p-5 ">                                    
									<div class="flex flex-1 items-center justify-center lg:justify-start">
                            <div class="w-20 h-20 sm:w-24 sm:h-24 flex-none lg:w-24 lg:h-24 image-fit relative">
                                <img alt="" class="icon_mage" src="images/3.png">
                                
                            </div>
                            <div class="ml-2">
                                 <div class="w-34 sm:w-42 truncate sm:whitespace-normal main_txt"><asp:Label ID="CXNamelbl" runat="server" Text=""></asp:Label></div>
                                <div class="text-gray-600"><asp:Label ID="EmailIDlbl" runat="server" Text=""></asp:Label></div>
								<div class="text-gray-600"><asp:Label ID="MobileNolbl" runat="server" Text=""></asp:Label></div>
								<div class="text-gray-600"><asp:Label ID="Sponsorlbl" runat="server" Text=""></asp:Label></div>
								<div class="text-gray-600"><asp:Label ID="Salarylbl" runat="server" Text=""></asp:Label></div>
                            </div>
							</div>																
							</div>								
							</div>
							
							
							<div class="col-span-12 mt-2 sm:col-span-6 xl:col-span-4 intro-y benficalry">	
							<div class="box p-5 ">                                    
									<div class="flex flex-1 items-center justify-center lg:justify-start">
                            <div class="w-20 h-20 sm:w-24 sm:h-24 flex-none lg:w-24 lg:h-24 image-fit relative">
                                <img alt="" class="icon_mage" src="images/idcard.png">                                
                            </div>
                            <div class="ml-2">
                                <div class="w-34 sm:w-42 truncate sm:whitespace-normal main_txt">
                                    <asp:Label ID="civilidlbl" runat="server" Text="Civil ID"></asp:Label> </div>
                                <div class="text-gray-600">
                                    <asp:Label ID="CIDTxt" runat="server" Text=""></asp:Label></div>
                                <div class="text-gray-600" id="CIVDUDiv" runat="server" visible="false">
                                    <a href="CivilIDUploads.aspx" style="color:blue; text-decoration:underline" runat="server" id="UploadCIDlbl">Upload Civil ID</a></div>
                            </div>
							</div>																
							</div>								
							</div>
							
							
							<div class="col-span-12 mt-2 sm:col-span-6 xl:col-span-4 intro-y benficalry">	
							<div class="box p-5 ">                                    
									<div class="flex flex-1 items-center justify-center lg:justify-start">
                            <div class="w-20 h-20 sm:w-24 sm:h-24 flex-none lg:w-24 lg:h-24 image-fit relative">
                                <img alt="" class="icon_mage" src="images/address.png">                                
                            </div>
                            <div class="ml-2">
                                <div class="w-34 sm:w-42 truncate sm:whitespace-normal main_txt">
                                    <asp:Label ID="addresslbl_P" runat="server" Text="Address"></asp:Label></div>
                                <div class="text-gray-600">
                                    <asp:Label ID="Addresslbl" runat="server" Text=""></asp:Label></div>
                            </div>
							</div>																
							</div>								
							</div>
							
							<div class="col-span-12 mt-2 sm:col-span-6 xl:col-span-4 intro-y benficalry">	
							<div class="box p-5 ">                                    
									<div class="flex flex-1 items-center justify-center lg:justify-start">
                            <div class="w-20 h-20 sm:w-24 sm:h-24 flex-none lg:w-24 lg:h-24 image-fit relative">
                                <img alt="" class="icon_mage" src="images/4.png">                                
                            </div>
                            <div class="ml-2">
                                <div class="w-34 sm:w-42 truncate sm:whitespace-normal main_txt">
                                    <asp:Label ID="favoritebeneflbl_P" runat="server" Text="Favourite Beneficiary"></asp:Label></div>
                                <div class="text-gray-600">
                                    <asp:Label ID="FavBenfNamelbl" runat="server" Text=""></asp:Label></div>
                            </div>
							</div>																
							</div>								
							</div>
							
							<div class="col-span-12 mt-2 sm:col-span-6 xl:col-span-4 intro-y benficalry">	
							<div class="box p-5 ">                                    
									<div class="flex flex-1 items-center justify-center lg:justify-start">
                            <div class="w-20 h-20 sm:w-24 sm:h-24 flex-none lg:w-24 lg:h-24 image-fit relative">
                                <img alt="" class="icon_mage" src="images/bday.png">                                
                            </div>
                            <div class="ml-2">
                                <div class="w-34 sm:w-42 truncate sm:whitespace-normal main_txt"> <asp:Label ID="dateofbirthlbl" runat="server" Text="Date Of Birth"></asp:Label></div>
                                <div class="text-gray-600">
                                    <asp:Label ID="DOBlbl" runat="server" Text=""></asp:Label></div>
                            </div>
							</div>																
							</div>								
							</div>
							
							<div class="col-span-12 mt-2 sm:col-span-6 xl:col-span-4 intro-y benficalry">	
							<div class="box p-5 ">                                    
									<div class="flex flex-1 items-center justify-center lg:justify-start">
                            <div class="w-20 h-20 sm:w-24 sm:h-24 flex-none lg:w-24 lg:h-24 image-fit relative">
                                <img alt="" class="icon_mage" src="images/point.png">                                
                            </div>
                            <div class="ml-2">
                                <div class="w-34 sm:w-42 truncate sm:whitespace-normal main_txt">
                                    <asp:Label ID="Loyalitypointslbl" runat="server" Text="Balance Loyalty Points"></asp:Label></div>
                                <div class="text-gray-600"> <asp:Label ID="LoyalityNolbl" runat="server" Text=""></asp:Label></div>
                            </div>
							</div>																
							</div>								
							</div>
							
							
							
							
							
							</div>



    	            <div style="clear:both;"></div>
						<a href="Documents" class="button mr-2 mb-5 mt-5 flex items-center justify-center mr-2 mb-2 flex items-center justify-center text-white bg-theme-1 shadow-md mr-2 add_btn" id="SupDocBtn" runat="server" visible="false" >Upload Supporting Documents</a>
						<div style="clear:both;"></div>				
							
						<div class="clear-fix"></div>	


         	<div class="col-span-12 mt-8 ">
			
			<h1 class="main_heading  truncate  text-center"><asp:Label ID="SecQHeadlbl" runat="server" Text="Security Questions"></asp:Label></h1>
			  </div>
					
					
         <div class=" box sendmony">	
              <div class="wizard mt-0">
        
                <div class="tab-content marg_t_15">
                    <div class="tab-pane " >
                        <div class="signup_box">
						
						
                        
							<div class="mt-1 "> <%--<label id="SecQuestionlbl1" runat="server"></label>   --%>
                                <asp:DropDownList ID="SecQ1DDL" runat="server" class="select2 " DataSourceID="SecQ1_ODS" DataTextField="QUESTION" DataValueField="QUES_ID" AppendDataBoundItems="True"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="SecQ1DDL_ReqF" runat="server" ErrorMessage="Security Question Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="SecQ1DDL" InitialValue="Select Question"></asp:RequiredFieldValidator>
                                <%--<asp:TextBox ID="TextBox1" runat="server" class="input pr-12 w-full border col-span-4" placeholder=""></asp:TextBox>                                  
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Answer 1 Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="SecQuestionAnswer1Txt"></asp:RequiredFieldValidator>--%>
							
							 </div>
                            <div class="mt-1 pass_show"> 							
                                <asp:TextBox ID="SecQuestionAnswer1Txt" runat="server" class="intro-x  input input--lg border border-gray-300 block" placeholder="" TextMode="Password"></asp:TextBox>  
                                <i onclick="show1('SecQuestionAnswer1Txt')" class="fas fa-eye-slash" id="display1"></i>
                                <asp:RequiredFieldValidator ID="SecQ1Txt_ReqF" runat="server" ErrorMessage="Answer 1 Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="SecQuestionAnswer1Txt"></asp:RequiredFieldValidator>                                
							 </div>
							 <div class="mt-1 ">
							 <%-- <label id="SecQuestionlbl2" runat="server"></label>        --%> 
                                 <asp:DropDownList ID="SecQ2DDL" runat="server" class="select2 " DataSourceID="SecQ1_ODS" DataTextField="QUESTION" DataValueField="QUES_ID" AppendDataBoundItems="True"></asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="SecQ2DDL_ReqF" runat="server" ErrorMessage="Security Question Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="SecQ2DDL" InitialValue="Select Question"></asp:RequiredFieldValidator>              
                                 <asp:CompareValidator ID="SecQ2DDL_CompV" runat="server" ErrorMessage="Security questions 1 & 2 should not be same" Display="Dynamic" CssClass="Validate-Error" SetFocusOnError="True" ControlToCompare="SecQ1DDL" ControlToValidate="SecQ2DDL" Operator="NotEqual"></asp:CompareValidator>
                        <%--<asp:TextBox ID="SecQuestionAnswer2Txt" runat="server" class="input pr-12 w-full border col-span-4" placeholder=""></asp:TextBox>   
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Answer 2 Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="SecQuestionAnswer2Txt"></asp:RequiredFieldValidator>--%>
							</div>
                              <div class="mt-1 pass_show"> 	
                                  <asp:TextBox ID="SecQuestionAnswer2Txt" runat="server" class="intro-x  input input--lg border border-gray-300 block" placeholder="" TextMode="Password"></asp:TextBox>   
                                  <i onclick="show2('SecQuestionAnswer2Txt')" class="fas fa-eye-slash" id="display2"></i>
                                 <asp:RequiredFieldValidator ID="SecQ2Txt_ReqF" runat="server" ErrorMessage="Answer 2 Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="SecQuestionAnswer2Txt"></asp:RequiredFieldValidator>
                                  </div>
							
							<div class="mt-1 ">   <%--<label id="SecQuestionlbl3" runat="server"></label>      --%>
                                <asp:DropDownList ID="SecQ3DDL" runat="server" class="select2 " DataSourceID="SecQ2_ODS" DataTextField="QUESTION" DataValueField="QUES_ID" AppendDataBoundItems="True"></asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="SecQ3DDL_ReqF" runat="server" ErrorMessage="Security Question Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="SecQ3DDL" InitialValue="Select Question"></asp:RequiredFieldValidator>                 
                        <%--<asp:TextBox ID="SecQuestionAnswer3Txt" runat="server" class="input pr-12 w-full border col-span-4" placeholder=""></asp:TextBox>    
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Answer 3 Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="SecQuestionAnswer3Txt"></asp:RequiredFieldValidator>  --%>
							 </div>
                            <div class="mt-1 pass_show"> 	
                                <asp:TextBox ID="SecQuestionAnswer3Txt" runat="server" class="intro-x  input input--lg border border-gray-300 block" placeholder="" TextMode="Password"></asp:TextBox>    
                                <i onclick="show3('SecQuestionAnswer3Txt')" class="fas fa-eye-slash" id="display3"></i>
                                <asp:RequiredFieldValidator ID="SecQ3Txt_ReqF" runat="server" ErrorMessage="Answer 3 Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="SecQuestionAnswer3Txt"></asp:RequiredFieldValidator>  
                                </div>
							
							<div class="mt-1 ">   
                                <asp:DropDownList ID="SecQ4DDL" runat="server" class="select2 " DataSourceID="SecQ2_ODS" DataTextField="QUESTION" DataValueField="QUES_ID" AppendDataBoundItems="True"></asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="SecQ4DDL_ReqF" runat="server" ErrorMessage="Security Question Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="SecQ4DDL" InitialValue="Select Question"></asp:RequiredFieldValidator>         
                                <asp:CompareValidator ID="SecQ4DDL_CompV" runat="server" ErrorMessage="Security questions 3 & 4 should not be same" CultureInvariantValues="False" Display="Dynamic" SetFocusOnError="True" CssClass="Validate-Error" ControlToCompare="SecQ3DDL" ControlToValidate="SecQ4DDL" Operator="NotEqual"></asp:CompareValidator>
							 </div>
                            <div class="mt-1 pass_show"> 	
                                <asp:TextBox ID="SecQuestionAnswer4Txt" runat="server" class="intro-x  input input--lg border border-gray-300 block" placeholder="" TextMode="Password"></asp:TextBox>    
                                <i onclick="show4('SecQuestionAnswer4Txt')" class="fas fa-eye-slash" id="display4"></i>
                                <asp:RequiredFieldValidator ID="SecQ4Txt_ReqF" runat="server" ErrorMessage="Answer 4 Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="SecQuestionAnswer4Txt"></asp:RequiredFieldValidator>  
                              </div>
							
<%--                            <div class="mt-1"> 
     <div class="flex flex-col sm:flex-row ">
         <div class="flex items-center text-gray-700 dark:text-black-500 mr-2"> <input type="radio" class="input border-black mr-2 " id="SMSRad" name="horizontal_radio_button" value="horizontal-radio-chris-evans" runat="server"> <label class="cursor-pointer select-none" for="SMSRad">Send OTP to SMS</label> </div>
         <div class="flex items-center text-gray-700 dark:text-black-500 mr-2 mt-2 sm:mt-0"> <input type="radio" class="input border-black mr-2" id="EmailRad" name="horizontal_radio_button" value="horizontal-radio-liam-neeson" runat="server"> <label class="cursor-pointer select-none" for="EmailRad">Send OTP to Email Id</label> </div>
     </div>
 </div>--%>

                            <div style="clear:both;"></div>
                    <div class="forgot_pass mt-8">
                    <div class="flex flex-col sm:flex-row ">
                    <div class="flex items-center text-gray-700 dark:text-gray-500 mr-2"> <input type="radio" class="input border mr-2" id="SMSRad" name="horizontal_radio_button" value="horizontal-radio-chris-evans" runat="server"><label class="cursor-pointer select-none" for="SMSRad" id="SMSRadlbl" runat="server">Send OTP to Mobile</label> </div>
                    <div class="flex items-center text-gray-700 dark:text-gray-500 mr-2 mt-2 sm:mt-0"> <input type="radio" class="input border mr-2" id="EmailRad" name="horizontal_radio_button" value="horizontal-radio-liam-neeson" runat="server"> <label class="cursor-pointer select-none" for="EmailRad" id="EmailRadlbl" runat="server">Send OTP to Email</label> </div>
                       </div>
                        </div>
                            
                    <div style="clear:both;"></div>

                             <div class="intro-x  pass_show mt-2">
                                 <asp:TextBox ID="OTPTxt" runat="server" class="intro-x login__input input input--lg border border-gray-300 block form-control" placeholder="Enter the OTP" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                                 <i onclick="show('OTPTxt')" class="fas fa-eye-slash " id="display"></i>
                                 <asp:RequiredFieldValidator ID="OTPTxt_ReqF" runat="server" ErrorMessage="Please enter OTP" Display="Dynamic" CssClass="Validate-Error" SetFocusOnError="True" ControlToValidate="OTPTxt"></asp:RequiredFieldValidator>
                            <%--<input type="password" value="" class="intro-x login__input input input--lg border border-gray-300 block form-control" placeholder="Enter the OTP">--%>							
                        </div>
							<div style="clear:both;"></div>
						<%--<a href="#" class="  w-24 mr-1 mb-2 bg-theme-1 text-white resnd_otp_btn">Resend OTP</a> --%>
                            <asp:Button ID="OTPSendBtn" runat="server" Text="Resend OTP" class=" w-24 mr-1 mb-2 bg-theme-1 text-white resnd_otp_btn" UseSubmitBehavior="false" CausesValidation="false" OnClick="OTPSendBtn_Click" ForeColor="Black"/>
                            <span class="resnd_otp" id="CounterSpan" runat="server"> ( OTP expires in <span id="Counterlbl" runat="server" style="color:red; font-weight:bold"></span> Secs  )</span>
						<asp:HiddenField ID="InitiSecs_HD" runat="server" />
						<div style="clear:both;"></div>
                            

						
				<div class="clear"></div>	
				
				
                           <div class="col-span-12 lg:col-span-12 mt-8 mb-5 text-center mob_l_r_15 ">                
                <%--<input type="button" name="submit" id="SubmitBtn" value="Update   " class=" w-26 shadow-md mr-1 mb-2 text-white next_btn_green" runat="server" onserverclick="SubmitBtn_Click" causesvalidation="true" />--%>
                               <asp:Button ID="SubmitBtn" runat="server" Text="Update" class=" w-26 shadow-md mr-1 mb-2 text-white next_btn_green" OnClick="SubmitBtn_Click" UseSubmitBehavior="False" CausesValidation="true" />
            </div>		

		                            	</div>
                        
                    </div>
                    
					
                    
                    </div>
                    
                    <div class="clearfix"></div>
                </div>
           
        </div>	
         
         		
							
						
											
						
						
						
						
							
						<%--	</div>	--%>

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

	function show1(a) {
  var x=document.getElementById("<%= SecQuestionAnswer1Txt.ClientID %>");
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
  var x=document.getElementById("<%= SecQuestionAnswer2Txt.ClientID %>");
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

        function show3(a) {
  var x=document.getElementById("<%= SecQuestionAnswer3Txt.ClientID %>");
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

                function show4(a) {
  var x=document.getElementById("<%= SecQuestionAnswer4Txt.ClientID %>");
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
    
      document.getElementById("<%= Counterlbl.ClientID %>").innerText = "0"
     document.getElementById("<%= OTPSendBtn.ClientID %>").disabled = false;
    document.getElementById("<%= CounterSpan.ClientID %>").style.display = "none";
    document.getElementById("<%= InitiSecs_HD.ClientID %>").value = "";  
      
  }
}, 1000);

</script>

     <asp:ObjectDataSource ID="SecQ1_ODS" runat="server" SelectMethod="SecurityQ1" TypeName="KBE.RESTFull.RESTClass"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="SecQ2_ODS" runat="server" SelectMethod="SecurityQ2" TypeName="KBE.RESTFull.RESTClass"></asp:ObjectDataSource>
    <%--<asp:ObjectDataSource ID="SecQ3_ODS" runat="server" SelectMethod="SecurityQ3" TypeName="KBE.RESTFull.RESTClass"></asp:ObjectDataSource>--%>
</asp:Content>
