<%@ Page Title="Kuwait Bahrain International Exchange Company : Contact Us" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Contact_Us.aspx.cs" Inherits="KBE.Contact_Us" EnableEventValidation="false" Async="true" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">      	
	<link href="css/bootstrap2.min.css" rel="stylesheet" />	
   

<%--       <div class="content">--%>
                <!-- BEGIN: Top Bar -->
                
                <!-- END: Top Bar -->
                
			
			
			<div class="col-span-12 mt-8 ">
			
			<h1 class="main_heading  truncate  text-center"><asp:Label ID="ContactusHeadlbl" runat="server" Text="Contact Us"></asp:Label> </h1>
			  </div> 
			
			
			<div class="intro-y chat grid grid-cols-12 gap-5 mt-5 contct">
                    <!-- BEGIN: Chat Side Menu -->
                    <div class="col-span-12 lg:col-span-4 xxl:col-span-4">
                        <div class="intro-y pr-1">
                            <div class="box p-5 address">
							
							
							
                                <h3 class="text-lg font-medium mr-auto"><span id="Corporateaddresslbl" runat="server">Corporate Address</span></h3>
								<p id="CoprAdd" runat="server"></p>

</div>
						</div>
                        
                    </div>

<div class="col-span-12 lg:col-span-4 xxl:col-span-4">
                        <div class="intro-y pr-1">
                            <div class="box p-5 address">

<h3 class="text-lg font-medium mr-auto"><span id="Contactatlbl" runat="server"> Contact@</span></h3>
<p>
<%--Basement/Ground/1st Floor, Eissa Al Othman Building, Abdul Aziz Hamed Al saqer Street, Mirqab, State of Kuwait.<br>--%>

 <i data-feather="phone-call"></i> <asp:Label ID="ContactNolbl" runat="server" Text=""></asp:Label><br/>
<%--To contact any particular Branch please visit Branch locator<br>--%>
 <i data-feather="printer"></i> 00965-22431000<br/>
<%--<i data-feather="home"></i> KBEXKWKF<br>--%>
<i data-feather="globe"></i> <asp:Label ID="emailIDTxt" runat="server" Text=""></asp:Label><br/>
<%--To contact any particular Branch please visit Branch locator--%>

</p>
                           
                        </div>
						</div>
                        
                    </div>


                                    <div class="col-span-12 lg:col-span-4 xxl:col-span-4">
                        <div class="intro-y pr-1">
                            <div class="box p-5 address">
                                <h3 class="text-lg font-medium mr-auto"><span id="Operationofficelbl" runat="server"> Operation Office</span></h3>
								<p id="P1" runat="server">
                                    Basement/Ground/1st Floor,<br /> Eissa Al Othman Building,<br /> Abdul Aziz Hamed Al saqer Street, Mirqab,<br /> State of Kuwait.<br>
								</p></div>
                        </div>                        
                    </div>

<%--                <div class="col-span-12 lg:col-span-6 xxl:col-span-6">
                        <div class="intro-y pr-1">
                            <div class="box p-5 address">

<h3 class="text-lg font-medium mr-auto">Contact@</h3>
<p>
Basement/Ground/1st Floor,<br /> Eissa Al Othman Building,<br /> Abdul Aziz Hamed Al saqer Street, Mirqab,<br /> State of Kuwait.<br>
</p>
                           
                        </div>
						</div>
                        
                    </div>--%>
                    <!-- END: Chat Side Menu -->
                    <!-- BEGIN: Chat Content -->
                    <div class="intro-y col-span-12 lg:col-span-12 xxl:col-span-12">
                        <div class=" box p-5 ">
                            <!-- BEGIN: Chat Active -->
                            <h4 class="text-lg font-medium mr-auto  mb-5 mt-2 text-center">
                                <asp:Label ID="Contactformlbl" runat="server" Text="Contact Form"></asp:Label></h4>
							
							<div class="signup_box row center-block">
				
                        <div class="col-sm-12">
							<div class="mt-1 form_left"> <asp:Label ID="Namelbl" runat="server" Text="Name*"></asp:Label>							
                                <asp:TextBox ID="NameTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block " placeholder=""></asp:TextBox>
                                <asp:RequiredFieldValidator ID="NameTxt_ReqF" runat="server" ErrorMessage="Name Required" ControlToValidate="NameTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
							 </div>
							 <div class="mt-1 form_right">
							<asp:Label ID="Emaillbl" runat="server" Text="Email"></asp:Label>
                                 <asp:TextBox ID="EmailTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block " placeholder=""></asp:TextBox>		                                 
                                 <asp:RegularExpressionValidator ID="EmailTxt_RegExp" runat="server" ErrorMessage="Invalid Email" ControlToValidate="EmailTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>					
							</div>
                            </div>
							<div class="col-sm-12">
							<div class="mt-1 form_left"><asp:Label ID="PhoneNolbl" runat="server" Text="Phone*"></asp:Label>							
                                <asp:TextBox ID="PhoneNoTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block " placeholder="" MaxLength="8"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="PhoneNoTxt_FilteredTextBoxExtender" runat="server" BehaviorID="PhoneNoTxt_FilteredTextBoxExtender" FilterType="Numbers" TargetControlID="PhoneNoTxt">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator ID="PhoneNoTxt_ReqF" runat="server" ErrorMessage="Phone Number Required" ControlToValidate="PhoneNoTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
							 </div>

							 <div class="mt-1 form_right">
							<asp:Label ID="Subjectlbl" runat="server" Text="Subject*"></asp:Label>
                                 <asp:TextBox ID="SubjectTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block " placeholder=""></asp:TextBox>	
                                 <asp:RequiredFieldValidator ID="SubjectTxt_ReqF" runat="server" ErrorMessage="Subject Required" ControlToValidate="SubjectTxt" CssClass="Validate-Error" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
							</div>                                                  
                             </div>

                                <div class="col-sm-12">
                                <div class="mt-1">                       
                                    <asp:Label ID="Enquirylbl" runat="server" Text="Enquiry For*"></asp:Label>
                    <asp:DropDownList ID="EnquiryDDL" runat="server" class="select2 w-full" DataSourceID="Enquiry_ODS" DataTextField="DESC_E" DataValueField="LOOKUP_ID" AppendDataBoundItems="True" style="width:100%;"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="EnquiryDDL_ReqF" runat="server" ErrorMessage="Enquiry For Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="EnquiryDDL" InitialValue="Select Enquiry Type"></asp:RequiredFieldValidator>                
							</div>
                                    </div>
                                <div class="clear"></div>	
							<div class="col-sm-12">
							<div class="mt-1 ">
							<asp:Label ID="Commentslbl" runat="server" Text="Comments"></asp:Label>							
                                <asp:TextBox ID="CommentsTxt" runat="server" class="input w-full border border-gray-300 " name="comment" placeholder="" Height="150px" TextMode="MultiLine" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="CommentsTxt_ReqF" runat="server" ErrorMessage="Comments Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="CommentsTxt" InitialValue=""></asp:RequiredFieldValidator>
							</div>
                                </div>
							
							
						
			<div class="clear"></div>	
				
				<div class="wizard-footer text-center">
                
                     <asp:Button ID="SubmitBtn" runat="server" Text="Submit" class=" w-26 shadow-md mr-1 mb-2 text-white next_btn_green" OnClick="SubmitBtn_Click" UseSubmitBehavior="False" CausesValidation="true" />
                      
</div>

		                            	</div>
							
							 
                            
                        </div>
                    </div>
                    <!-- END: Chat Content -->
                </div>			
						 
	
	<%--		</div>	--%>											

   

    <asp:ObjectDataSource ID="Enquiry_ODS" runat="server" SelectMethod="EnquiryTypes" TypeName="KBE.RESTFull.RESTClass"></asp:ObjectDataSource>
</asp:Content>
