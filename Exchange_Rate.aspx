<%@ Page Title="Kuwait Bahrain International Exchange Company : Exchange Rate" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Exchange_Rate.aspx.cs" Inherits="KBE.Exchange_Rate" Async="true" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
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
           <%-- <div class="content">--%>
                <!-- BEGIN: Top Bar -->
                
                <!-- END: Top Bar -->
                			
			<div class="col-span-12 mt-8 ">
			
			<h1 class="main_heading  truncate  text-center">
                <asp:Label ID="ExchRatelbl_P" runat="server" Text="Exchange Rate"></asp:Label></h1>
			  </div> 
			 				
							
							<div class="col-span-12 sm:col-span-12 xl:col-span-12 intro-y box  send_money pading_20 mt-5">		
							
						 <div class="col-span-12">
						
						<div class="grid grid-cols-12 gap-6 form">
                            <div class="col-span-12 sm:col-span-6 xl:col-span-3 intro-y">	
                              <label id="selectcurrencylbl" runat="server">Select Currency</label>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ExRateDDL" runat="server" class="select2 w-full" DataSourceID="ExRate_ODS" DataTextField="CURR_CODE" DataValueField="CURR_RATE"  style="width:100%;" AutoPostBack="True" OnSelectedIndexChanged="ExRateDDL_SelectedIndexChanged"></asp:DropDownList>					
                             </ContentTemplate></asp:UpdatePanel>
							</div>
                            <div class="col-span-12 sm:col-span-6 xl:col-span-3 intro-y">
     <div class="relative  col-span-4 lg:col-span-4">
  <label id="yousendlbl" runat="server">You Send</label>         
                                         <asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate>
                                        <asp:TextBox ID="KDAmtTxt" runat="server" class="input pr-12 w-full border col-span-4" placeholder="" AutoPostBack="True" OnTextChanged="KDAmtTxt_TextChanged" onfocus="this.value=''"></asp:TextBox>
                                             <ajaxToolkit:FilteredTextBoxExtender ID="KDAmtTxt_FilteredTextBoxExtender" runat="server" BehaviorID="KDAmtTxt_FilteredTextBoxExtender" TargetControlID="KDAmtTxt" ValidChars="0,1,2,3,4,5,6,7,8,9,." />
                                        <div class="absolute right-0 rounded-r w-10  flex items-center justify-center   text-gray-600 gray right_10">KWD</div>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Amount" Display="Dynamic" SetFocusOnError="True" ControlToValidate="KDAmtTxt" ValidationExpression="\d*.\d{0,3}" CssClass="Validate-Error"></asp:RegularExpressionValidator>
                                               </ContentTemplate></asp:UpdatePanel>
                                    </div>  
                                            
                            </div>
                            <div class="col-span-12 sm:col-span-6 xl:col-span-3 intro-y">
    <div class="relative  col-span-4 lg:col-span-4">
  <label id="youreceivelbl" runat="server">You Receive</label>        
        <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>                                            
                                        <asp:TextBox ID="FMoneyTxt" runat="server" class="input pr-12 w-full border col-span-4" placeholder="" AutoPostBack="True" OnTextChanged="FMoneyTxt_TextChanged" onfocus="this.value=''"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FMoneyTxt_FilteredTextBoxExtender" runat="server" BehaviorID="FMoneyTxt_FilteredTextBoxExtender" TargetControlID="FMoneyTxt" ValidChars="0,1,2,3,4,5,6,7,8,9,." />
                                        <div class="absolute right-0 rounded-r w-10  flex items-center justify-center   text-gray-600 gray right_10">
                                            <asp:Label ID="FMoneylbl" runat="server" Text=""></asp:Label></div>
            <asp:DropDownList ID="ExRateDDLTEMP" runat="server" Width="0" DataSourceID="ExRate_ODS" DataTextField="CURR_RATE" DataValueField="CURR_CODE" AutoPostBack="True" style="visibility:hidden"></asp:DropDownList>

             </ContentTemplate></asp:UpdatePanel>
                                    </div>  

                            </div>


                            <div class="col-span-12 sm:col-span-6 xl:col-span-3 intro-y">
    <div class="relative  col-span-4 lg:col-span-4">
  <label id="Exchangeratelbl" runat="server">Exchange Rate</label>        
        <asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate>                                            
                                        <asp:TextBox ID="ExchangeTxt" runat="server" class="input pr-12 w-full border col-span-4" placeholder="" ReadOnly="true" ForeColor="Black"></asp:TextBox>

             </ContentTemplate></asp:UpdatePanel>
                                    </div>  

                            </div>
							
							
					
							</div>
							</div>
							<div class="clear"></div>
							</div>
							
							
						
						
								
							
						
							
						<%--	</div>	--%>
                <!-- END: Pricing Tab -->
                <!-- BEGIN: Pricing Content -->
                
                <!-- END: Pricing Content -->

     
    


     <asp:ObjectDataSource ID="ExRate_ODS" runat="server" SelectMethod="DailyRates" TypeName="KBE.RESTFull.RESTClass"></asp:ObjectDataSource>
</asp:Content>
