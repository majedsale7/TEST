<%@ Page Title="Kuwait Bahrain International Exchange Company : Add Beneficiary" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BeneficiaryNew.aspx.cs" Inherits="KBE.BeneficiaryNew" Async="true" EnableEventValidation="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">     
    
   
<script type="text/javascript">
    function pageLoad(sender, args) {
        $("select.w-full").select2({           
        });              
               
    }
</script>


         

     

    <!-- BEGIN: Content -->
 <%--   <div class="content">--%>
        <!-- BEGIN: Top Bar -->

        <!-- END: Top Bar -->


       <%-- <asp:HiddenField ID="CurrenyID_HD" runat="server" />--%>

        <div class="col-span-12 mt-8 ">

            <h1 class="main_heading  truncate  text-center">
                <asp:Label ID="AddBeneflbl" runat="server" Text="Add Beneficiary"></asp:Label></h1>
        </div>


        <div class="col-span-12 mt-5">          


        </div>



        <div class="col-span-12 sm:col-span-12 xl:col-span-12 intro-y box pading_20">

            <div class="grid grid-cols-12 gap-6 mt-2 form benfisry">


                <div class="intro-y col-span-12 sm:col-span-4 md:col-span-4 xxl:col-span-4">
                    <label id="countrylbl" runat="server">Country*</label>
                       <asp:UpdatePanel ID="UpdatePanel7" runat="server"><ContentTemplate>
                    <asp:DropDownList ID="CountryDDL" runat="server" class="select2 w-full" DataSourceID="CountryBS_ODS" DataTextField="COUN_NAME" DataValueField="COUN_CODE3" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="CountryDDL_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="CountryDDL_ReqF" runat="server" ErrorMessage="Country Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="CountryDDL" InitialValue=""></asp:RequiredFieldValidator>
                           </ContentTemplate></asp:UpdatePanel>
                </div>

                <div class="intro-y col-span-12 sm:col-span-4 md:col-span-4 xxl:col-span-4">
                    <label id="currencylbl" runat="server">Currency*</label>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                    <asp:DropDownList ID="CurrencyDDL" runat="server" class="select2 w-full"  DataSourceID="CurrencyBS_ODS" DataTextField="CURR_NAME_EN" DataValueField="CURR_ID" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="CurrencyDDL_SelectedIndexChanged"></asp:DropDownList>                    
                    <asp:RequiredFieldValidator ID="CurrencyDDL_ReqF" runat="server" ErrorMessage="Currency Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="CurrencyDDL" InitialValue=""></asp:RequiredFieldValidator>
                        </ContentTemplate></asp:UpdatePanel>
                </div>

                <div class="intro-y col-span-12 sm:col-span-4 md:col-span-4 xxl:col-span-4">
                    <label id="benefnamelbl" runat="server">Beneficiary  Name*</label>
                    <asp:TextBox ID="BenefNameTxt" runat="server" class="input w-full border border-gray-300 mt-2" placeholder="" AutoCompleteType="Disabled"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="BenefNameTxt_ReqF" runat="server" ErrorMessage="Beneficiary Name Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="BenefNameTxt" InitialValue=""></asp:RequiredFieldValidator>
                    <%--<ajaxToolkit:FilteredTextBoxExtender ID="BenefNameTxt_FilteredTextBoxExtender" runat="server" BehaviorID="BenefNameTxt_FilteredTextBoxExtender" TargetControlID="BenefNameTxt" FilterMode="ValidChars" FilterType="Custom,LowercaseLetters,UppercaseLetters" ValidChars=" " />--%>
                    <asp:RegularExpressionValidator ID="BenefNameTxt_RegExp" runat="server" ErrorMessage="Invalid Name" Display="Dynamic" ControlToValidate="BenefNameTxt" CssClass="Validate-Error" SetFocusOnError="True" ValidationExpression="^[a-zA-Z \u0621-\u064A ]{4,}$"></asp:RegularExpressionValidator>
                </div>

                <div class="intro-y col-span-12 sm:col-span-4 md:col-span-4 xxl:col-span-4">
                    <label id="transfertypelbl" runat="server">Transfer Type*</label>      
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server"><ContentTemplate>             
                    <asp:DropDownList ID="TransferTypeDDL" runat="server" class="select2 w-full" DataSourceID="TransferTypeBS_ODS" DataTextField="DESC_E" DataValueField="LOOKUP_ID" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="TransferTypeDDL_SelectedIndexChanged" ></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="TransferTypeDDL_ReqF" runat="server" ErrorMessage="Transfer Type Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="TransferTypeDDL" InitialValue=""></asp:RequiredFieldValidator>
                        </ContentTemplate></asp:UpdatePanel>
                </div>


                <div class="intro-y col-span-12 sm:col-span-4 md:col-span-4 xxl:col-span-4">
                    <label id="accountnolbl" runat="server">Account Number / IBAN*</label>
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server"><ContentTemplate>
                    <asp:TextBox ID="AccountNoTxt" runat="server" class="input w-full border border-gray-300 mt-2" placeholder="" AutoCompleteType="Disabled" MaxLength="30"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="AccountNoTxt_FilteredTextBoxExtender" runat="server" BehaviorID="AccountNoTxt_FilteredTextBoxExtender" FilterMode="InvalidChars" InvalidChars="~!@#$%^&amp;*()_+&quot;:&gt;&lt;?/\|[]-+.,'{};" TargetControlID="AccountNoTxt" />
                         </ContentTemplate></asp:UpdatePanel>
                </div>

                <div class="intro-y col-span-12 sm:col-span-4 md:col-span-4 xxl:col-span-4">
                    <label id="accounttypelbl" runat="server">Account Type*</label>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>
                    <asp:DropDownList ID="AccountTypeDDL" runat="server" class="select2 w-full"  DataSourceID="AccountType_ODS" DataTextField="TYPE_DESC" DataValueField="TYPE_ID" AppendDataBoundItems="True"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="AccountTypeDDL_ReqF" runat="server" ErrorMessage="Account Type Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="AccountTypeDDL" InitialValue=""></asp:RequiredFieldValidator>
                         </ContentTemplate></asp:UpdatePanel>
                </div>

                <div class="intro-y col-span-12 sm:col-span-4 md:col-span-4 xxl:col-span-4">
                    <label id="banknamelbl" runat="server">Bank*</label>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                    <asp:DropDownList ID="BankDDL" runat="server" class="select2 w-full" DataSourceID="Banks_ODS" DataTextField="BANK_NAME_EN" DataValueField="BANK_ID" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="BankDDL_SelectedIndexChanged" ></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="BankDDL_ReqF" runat="server" ErrorMessage="Bank Name Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="BankDDL" InitialValue=""></asp:RequiredFieldValidator>
                        </ContentTemplate></asp:UpdatePanel>
                </div>

               <%-- <div class="intro-y col-span-12 sm:col-span-4 md:col-span-4 xxl:col-span-4">
                    <label id="branchlbl" runat="server">Branch*</label>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate>
                    <asp:DropDownList ID="BankBranchDDL" runat="server" class="select2 w-full" DataSourceID="BankBranchs_ODS" DataTextField="BEN_BRN_ADDR1" DataValueField="BEN_BRN_CODE" AppendDataBoundItems="True"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Bank Name Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="BankBranchDDL" InitialValue="Select Branch"></asp:RequiredFieldValidator>
                        </ContentTemplate></asp:UpdatePanel>
                </div>--%>
                 <div class="intro-y col-span-12 sm:col-span-4 md:col-span-4 xxl:col-span-4">
                    <label id="branchlbl" runat="server">Branch*</label>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate>
                    <%--<asp:DropDownList ID="BankBranchDDL" runat="server" class="select2 w-full" DataSourceID="BankBranchs_ODS" DataTextField="BEN_BRN_ADDR1" DataValueField="BEN_BRN_CODE" AppendDataBoundItems="True"></asp:DropDownList>--%>
                        <asp:TextBox ID="BankBranchTxt" runat="server" class="input w-full border border-gray-300 mt-2" placeholder="" onclick="ShowBranchSearch();" ReadOnly="true"></asp:TextBox>                        
                    <asp:RequiredFieldValidator ID="BankBranchTxt_ReqF" runat="server" ErrorMessage="Branch Name Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="BankBranchTxt" InitialValue=""></asp:RequiredFieldValidator>
                        </ContentTemplate></asp:UpdatePanel>

                </div>



                <div class="intro-y col-span-12 sm:col-span-4 md:col-span-4 xxl:col-span-4">
                    <label id="nationalitylbl" runat="server">Nationality*</label>
                    <asp:DropDownList ID="NationalityDDL" runat="server" class="select2 w-full" DataSourceID="Country_ODS" DataTextField="COUN_NAME" DataValueField="COUN_CODE3" AppendDataBoundItems="True"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="NationalityDDL_ReqF" runat="server" ErrorMessage="Nationality Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="NationalityDDL" InitialValue=""></asp:RequiredFieldValidator>
                </div>

                <div class="intro-y col-span-12 sm:col-span-4 md:col-span-4 xxl:col-span-4">
                    <label id="beneifidnolbl" runat="server">Beneficiary ID Number</label>
                    <asp:TextBox ID="BenefIDNoTxt" runat="server" class="input w-full border border-gray-300 mt-2" placeholder="" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="intro-y col-span-12 sm:col-span-4 md:col-span-4 xxl:col-span-4">
                    <label id="mobilenolbl" runat="server">Mobile</label>
                    <asp:TextBox ID="MobileNoTxt" runat="server" class="input w-full border border-gray-300 mt-2" placeholder="" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="intro-y col-span-12 sm:col-span-4 md:col-span-4 xxl:col-span-4">
                    <label id="address1lbl" runat="server">Adddress 1</label>
                    <asp:TextBox ID="Address1Txt" runat="server" class="input w-full border border-gray-300 mt-2" placeholder="" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="intro-y col-span-12 sm:col-span-4 md:col-span-4 xxl:col-span-4">
                    <label id="address2lbl" runat="server">Adddress 2</label>
                    <asp:TextBox ID="Address2Txt" runat="server" class="input w-full border border-gray-300 mt-2" placeholder="" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="intro-y col-span-12 sm:col-span-4 md:col-span-4 xxl:col-span-4">
                    <label id="citylbl" runat="server">City</label>
                    <asp:TextBox ID="CityTxt" runat="server" class="input w-full border border-gray-300 mt-2" placeholder="" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="intro-y col-span-12 sm:col-span-4 md:col-span-4 xxl:col-span-4">
                    <label id="relationshipbeneflbl" runat="server">Relationship to Beneficiary*</label>
                    <asp:DropDownList ID="RelationDDL" runat="server" class="select2 w-full" DataSourceID="Relations_ODS" DataTextField="DESC_E" DataValueField="LOOKUP_ID" AppendDataBoundItems="True"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RelationDDL_ReqF" runat="server" ErrorMessage="Beneficiary Relationship Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="RelationDDL" InitialValue=""></asp:RequiredFieldValidator>

                </div>


                	<!-----OTP----->		
				<div class="intro-y col-span-12 sm:col-span-6 md:col-span-6 xxl:col-span-6 mt-2">
						 
					<div class="forgot_pass mb-2"> 
						<div class="flex flex-col sm:flex-row ">
						<div class="flex items-center text-gray-700 dark:text-gray-500 mr-2"> <input type="radio" class="input border mr-2" id="SMSRad" name="horizontal_radio_button" value="horizontal-radio-chris-evans" runat="server"><label class="cursor-pointer select-none" for="SMSRad" id="SMSRadlbl" runat="server">Send OTP to Mobile</label> </div>
                    <div class="flex items-center text-gray-700 dark:text-gray-500 mr-2 mt-2 sm:mt-0"> <input type="radio" class="input border mr-2" id="EmailRad" name="horizontal_radio_button" value="horizontal-radio-liam-neeson" runat="server"> <label class="cursor-pointer select-none" for="EmailRad" id="EmailRadlbl" runat="server">Send OTP to Email</label> </div>
						</div>
							<div style="clear:both;"></div>
                          <asp:UpdatePanel ID="UpdatePanel10" runat="server"><ContentTemplate>
                        <div class="intro-x pass_show mt-2">    
                            <%--<input type="password" value="" class="w-full login__input input input--lg border border-gray-300 block form-control mt-2" id="otp1" placeholder="Enter the OTP">
							<i onclick="show('otp1')" class="fas fa-eye-slash" id="display"></i>--%>
                            <asp:TextBox ID="OTPTxt" runat="server" class="w-full login__input input input--lg border border-gray-300 block form-control mt-2" placeholder="Enter the OTP" TextMode="Password" AutoCompleteType="Disabled" AutoPostBack="true" OnTextChanged="OTPTxt_TextChanged"></asp:TextBox>
                             <i onclick="show('OTPTxt')" class="fas fa-eye-slash " id="display"></i>
                             <asp:RequiredFieldValidator ID="OTPTxt_ReqF" runat="server" ErrorMessage="Please enter OTP" Display="Dynamic" CssClass="Validate-Error" SetFocusOnError="True" ControlToValidate="OTPTxt"></asp:RequiredFieldValidator>
						</div>	
							<div style="clear:both;"></div>
                          <asp:Label ID="OTPinvalidlbl" runat="server" Text="" CssClass="Validate-Error"></asp:Label>
                               </ContentTemplate></asp:UpdatePanel>       
					</div>
							
						<%--<a href="#" class="w-24 mr-1 mb-2 bg-theme-1 text-white resnd_otp_btn mt-2">Send OTP</a> </span>--%>
						<asp:Button ID="OTPSendBtn" runat="server" Text="Resend OTP" class=" w-24 mr-1 mb-2 bg-theme-1 text-white resnd_otp_btn mt-2" UseSubmitBehavior="false" CausesValidation="false" OnClick="OTPSendBtn_Click" ForeColor="Black"/>
                            <span class="resnd_otp" id="CounterSpan" runat="server"> ( OTP expires in <span id="Counterlbl" runat="server" style="color:red; font-weight:bold"></span> Secs  )</span>
						<asp:HiddenField ID="InitiSecs_HD" runat="server" />
						<div style="clear:both;"></div>
							
                </div>
						
				<!-----OTP----->			


            </div>

            <div class="clear"></div>
            <div class="col-span-12 lg:col-span-12 mt-8 mb-5 text-center mob_l_r_15 ">

                <input type="button" name="clear" id="ClearBtn" value="Clear" class="  shadow-md mr-1 mb-2 next_btn_white" runat="server" onserverclick="ClearBtn_Click" causesvalidation="false" />
                <input type="button" name="submit2" id="SubmitBtn" value="Submit   " class=" w-26 shadow-md mr-1 mb-2 text-white next_btn_green" runat="server" onserverclick="SubmitBtn_Click" />

                <%-- <a href="#" class="  shadow-md mr-1 mb-2 next_btn_white">Clear</a>
			<a href="" class=" w-24 shadow-md mr-1 mb-2 text-white next_btn_green">Submit</a>--%>
            </div>

        </div>


        <asp:HiddenField ID="BankBranchSearchKey_HD" runat="server" />
        <%--<asp:HiddenField ID="BankBranchCode_HD" runat="server" />--%>

<%--    </div>--%>
    <!-- END: Pricing Tab -->
    <!-- BEGIN: Pricing Content -->

    <!-- END: Pricing Content -->



    
     <div class="modal" id="large-modal-size-previewBRN">
            <div class="modal__content modal__content--lg  ">
                <div class="modal-header text-center">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title"> <asp:Label ID="Searchbankbranchlbl" runat="server" Text="SEARCH BANK BRANCH"></asp:Label> </h4>
                </div>

                <div class="modal-body p-5">
                    <div class="relative mt-2 col-span-12 lg:col-span-12">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate>
                        <label id="AnyBranchlbl" runat="server"></label>        
                        <input type="text" class="input pr-12 w-full border col-span-4" placeholder="" id="AnyBranchTxt" runat="server" />               
                      <%--  <asp:TextBox ID="AnyBranchTxt" runat="server" class="input pr-12 w-full border col-span-4" AutoPostBack="true"></asp:TextBox>  --%>                      
                        <asp:Button ID="BranchSearchBtn" runat="server" Text="Search" class=" w-30 shadow-md mr-1 mb-2  text-white next_btn" CausesValidation="false" UseSubmitBehavior="false" OnClick="BranchSearchBtn_Click" OnClientClick="SetSearchKey();" />                            
                        </ContentTemplate></asp:UpdatePanel>
                        <%--  <div class="relative mt-2 col-span-12 lg:col-span-12 text-right">
	 Forgot Security Answer  <a href="#" class="button w-24 rounded-full mr-1 mb-2 bg-theme-1 text-white">Send OTP</a>                               
      </div>--%>
                    </div>
                </div>

                 <div class="modal-body p-5">
                    <div class="relative mt-2 col-span-12 lg:col-span-12">
                         <asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Width="100%" Height="200px" ScrollBars="Vertical">
                        <asp:GridView ID="BranchListGV" runat="server" AutoGenerateColumns="false" DataKeyNames="BEN_BRN_CODE,BRN_NAME,BEN_BRN_ADDR1" 
                            OnRowDeleting="BranchListGV_RowDeleting" class="table table-report ">
                              <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action">
                        <ItemTemplate>
                             <div class="flex justify-center items-center">
                                 <asp:LinkButton ID="SelBtn" CommandName="Delete" runat="server" CausesValidation="False" class="flex items-center mr-3 text-theme-9 tooltip" title="Select">  
                                     SELECT<i data-feather="send" class="icon"></i>                              
                            </asp:LinkButton>                              
                        </div>                           
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"/>                        
                    </asp:TemplateField>
                    <asp:BoundField DataField="BRN_NAME" HeaderText="Branch" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BEN_BRN_ADDR1" HeaderText="Address" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BEN_BRN_CITY" HeaderText="City" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BEN_BRN_STATE" HeaderText="State" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>                 
                  
                </Columns>
               <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle CssClass="bg-white" />
                <RowStyle CssClass="intro-x" />
                        </asp:GridView>
                         </asp:Panel>                              
                              </ContentTemplate></asp:UpdatePanel>
                    </div>
                </div>

                <div class="modal-footer">
                    <div class="col-span-12 lg:col-span-12 mt-5 mb-5 text-center">
                        <%--<a href="#" class=" w-24 shadow-md mr-1 mb-2  text-white next_btn">Cancel</a>
			<a href="#" class=" w-24 shadow-md mr-1 mb-2  text-white next_btn">Next</a>--%>
                        <%--<asp:Button ID="SecCancelBtn" runat="server" Text="Cancel" class=" w-30 shadow-md mr-1 mb-2  text-white next_btn" />--%>
                    <%--    <asp:Button ID="BranchCancelBtn" runat="server" Text="Cancel" class=" w-24 shadow-md mr-1 mb-2  text-white next_btn" />
                        <input type="button" value="Validate" name="SecValidateBtn" runat="server" class=" w-30 shadow-md mr-1 mb-2  text-white next_btn"   />   --%>                     

                    </div>
                    <div style="clear: both"></div>
                </div>


            </div>
            <div style="clear: both"></div>

        </div>

    
     <script type="text/javascript">              

        function ShowBranchSearch() {

             var control = document.getElementById('<%= BankDDL.ClientID %>');
            var selectedvalue = control.options[control.selectedIndex].value;                         
            
            if (selectedvalue != '')             
                $("#large-modal-size-previewBRN").modal('show');               
            
         }
          function HideBranchSearch() {
                $("#large-modal-size-previewBRN").modal('hide');
         }          
        
        function SetSearchKey()
         {
             var SearchTxt = document.getElementById('<%= AnyBranchTxt.ClientID %>').value;
             document.getElementById('<%= BankBranchSearchKey_HD.ClientID %>').value = SearchTxt;
             //alert(document.getElementById('<%= BankBranchSearchKey_HD.ClientID %>').value);
         }
        </script>    
         
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
    
      document.getElementById("<%= Counterlbl.ClientID %>").innerText = "0"
     document.getElementById("<%= OTPSendBtn.ClientID %>").disabled = false;
    document.getElementById("<%= CounterSpan.ClientID %>").style.display = "none";
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


}, 1000);

</script>

    <asp:ObjectDataSource ID="Country_ODS" runat="server" SelectMethod="Country_BS" TypeName="KBE.RESTFull.RESTClass"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="Relations_ODS" runat="server" SelectMethod="Relations_Benef" TypeName="KBE.RESTFull.RESTClass"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="Currency_ODS" runat="server" SelectMethod="CurrencyList" TypeName="KBE.RESTFull.RESTClass"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="AccountType_ODS" runat="server" SelectMethod="AccountTypesList" TypeName="KBE.RESTFull.RESTClass">
        <SelectParameters>
            <asp:Parameter Name="CurrencyID" Type="String" DefaultValue="0" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="Banks_ODS" runat="server" SelectMethod="BanksList_Benef" TypeName="KBE.RESTFull.RESTClass">
        <SelectParameters>
            <asp:Parameter Name="CountryCodeStr" Type="String" DefaultValue="0" />
            <asp:Parameter Name="CurrencyID" Type="String" DefaultValue="0" />
            <asp:Parameter Name="TransferTypeID" Type="String" DefaultValue="0" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="BankBranchs_ODS" runat="server" SelectMethod="BanksBranchList_Benef" TypeName="KBE.RESTFull.RESTClass">
        <SelectParameters>
            <asp:Parameter Name="BankID" Type="String" DefaultValue="0" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="TransferType_ODS" runat="server" SelectMethod="TransferTypesList" TypeName="KBE.RESTFull.RESTClass"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="CountryBS_ODS" runat="server" SelectMethod="Country_BS" TypeName="KBE.RESTFull.RESTClass"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="CurrencyBS_ODS" runat="server" SelectMethod="CurrencyList_BS" TypeName="KBE.RESTFull.RESTClass">
        <SelectParameters>
            <asp:Parameter Name="CountryCodeStr" Type="String" DefaultValue="0" />
        </SelectParameters>
    </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="TransferTypeBS_ODS" runat="server" SelectMethod="TransferTypesList_BS" TypeName="KBE.RESTFull.RESTClass">
        <SelectParameters>
            <asp:Parameter Name="CountryStr" Type="String" DefaultValue="0" />
            <asp:Parameter Name="CurrencyStr" Type="String" DefaultValue="0" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
