<%@ Page Title="Kuwait Bahrain International Exchange Company : My Beneficiaries" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BeneficiaryFormView.aspx.cs" Inherits="KBE.BeneficiaryFormView" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    		
			
			<div class="col-span-12 mt-8 ">
			
			<h1 class="main_heading  truncate  text-center"> <asp:Label ID="BenefListlbl" runat="server" Text="Beneficiary List"></asp:Label> </h1>
			  </div> 
			 
			
					<div class="col-span-12  mob_mrg_top_0">					
					
							
							<div class="grid grid-cols-12 gap-6 mt-5 form">

							<div class="col-span-12 sm:col-span-6 xl:col-span-4 intro-y ">	
                                <a href="Beneficiary" class="button mr-2 mb-5 mt-10 flex items-center justify-center mr-2 mb-2 flex items-center justify-center text-white bg-theme-1 shadow-md mr-2 add_btn" style="float:left">  <i data-feather="plus" class="w-4 h-4 mr-2"></i> <asp:Label ID="AddNewBeneflbl" runat="server" Text="Add New Beneficiary"></asp:Label>  </a>
                             <a href="Beneficiaries" class="button mr-2 mb-5 mt-10  items-center justify-center mr-2 mb-2 items-center bg-theme-1 text-white icon_btn shadow-md"> <span class="w-5 h-5 flex items-center justify-center "> <i data-feather="menu" class="w-8 h-8"></i> </span> </a>
							</div>												

                        <div class="col-span-12 sm:col-span-5 xl:col-span-5">	</div>
							
                        <div class="col-span-12 sm:col-span-3 xl:col-span-3 mt-5 filter_btn  right">
                            <asp:DropDownList ID="FilterDDL" runat="server" CssClass="bg-theme-1 select2 w-full" AutoPostBack="True" OnSelectedIndexChanged="FilterDDL_SelectedIndexChanged"></asp:DropDownList>							  
							</div>

                                </div>

							</div>


							<div class="clear"></div>
							
							
							
							
						<div class="grid grid-cols-12 gap-6 form " id="MainDiv" runat="server">

                            <asp:repeater runat="server" id="BenefRepeat" OnItemCommand="BenefRepeat_ItemCommand" OnItemDataBound="BenefRepeat_ItemDataBound">
                                <ItemTemplate>
                                    <div class="col-span-12 mt-5 sm:col-span-6 xl:col-span-4 intro-y benficalry">	
							<div class="box p-5 ">
                                    <div class="flex items-center border-b pb-3">
                                        <div class="">
                                            <div class="text-green"> <asp:Label ID="BenfNamelbl_H" runat="server" Text="Beneficiary Name"/></div>
                                            <div> <asp:Label ID="BenfNamelbl" runat="server" Text='<%#Eval("BEN_NAME") %>'/>   </div>
                                        </div>                                        
                                    </div>
									<div class="flex items-center border-b py-3">
                                        <div class="">
                                            <div class="text-green"><asp:Label ID="TransTypelbl_H" runat="server" Text="Transfer Type"/> </div>
                                            <div><asp:Label runat="server" ID="TransTypelbl" Text='<%#Eval("TRANSFER_TYPE") %>'></asp:Label></div>
                                        </div>
									</div>
                                    <div class="flex items-center border-b py-3">
                                        <div class="">
                                            <div class="text-green"><asp:Label ID="AcctNolbl_H" runat="server" Text="Account Number"/></div>
                                            <div><asp:Label runat="server" ID="AcctNolbl" Text='<%#Eval("BEN_ACT") %>'></asp:Label></div>
                                        </div>
									</div>
                                    <div class="flex items-center border-b py-3">
                                        <div class="">
                                            <div class="text-green"><asp:Label ID="BankNamelbl_H" runat="server" Text="Bank"/></div>
                                            <div><asp:Label runat="server" ID="BankNamelbl" Text='<%#Eval("BNF_BANK_CODE_EN") %>'></asp:Label></div>
                                        </div>
                                        </div>
                                    <div class="flex items-center border-b py-3">
                                        <div class="">
                                            <div class="text-green"><asp:Label ID="BranchNamelbl_H" runat="server" Text="Bank Branch"/></div>
                                            <div><asp:Label runat="server" ID="BranchNamelbl" Text='<%#Eval("BRN_NAME") %>'></asp:Label></div>
                                        </div>
                                    </div>							
									<div class="flex items-center border-b py-3">
                                        <div class="">
                                            <div class="text-green"><asp:Label ID="Lastusedlbl_H" runat="server" Text="Last Used On"/></div>
                                            <div><asp:Label runat="server" ID="Lastusedlbl" Text='<%#Eval("SYS_DATE","{0:dd-MM-yyyy}") %>'></asp:Label></div>
                                        </div>
                                    </div>
									<%-- <div class="flex items-center border-b py-3">
                                        <div class="">
                                            <div class="text-green">Status</div>
                                            <div><asp:Label runat="server" ID="Label1" Text='<%#Eval("APPROVAL_STATUS") %>'></asp:Label></div>
                                        </div>
                                    </div>	--%>
									<div class=" items-center  text-center">
                                        <div class="block text-center truncate mt-3 font_18"><asp:Label runat="server" ID="Currenylbl" Text='<%#Eval("CURR_CODE") %>'></asp:Label></div>
                                    </div>								
								</div>
<div class="action">
<div>
<div class="action-wrapper">
    <asp:LinkButton ID="FavBtn" CommandName="Delete" runat="server" CausesValidation="False" class="tooltip "  title="Favorite" CommandArgument='<%#Eval("CUST_NO")+","+Eval("CUST_ID")+","+Eval("FAV_BNF")%>'> 
         <i data-feather="star" class="icon"></i></asp:LinkButton>
       <asp:LinkButton ID="EnableBtn" CommandName="Edit" runat="server" CausesValidation="False" class="tooltip"  title="Disable" CommandArgument='<%#Eval("ENABLED_BNF")+","+Eval("CUST_NO")+","+Eval("CUST_ID")+","+Eval("FAV_BNF")%>'>  
                                     <i data-feather="toggle-left" class="icon"></i>                        
                            </asp:LinkButton>
     <asp:LinkButton ID="SendBtn" CommandName="Update" runat="server" CausesValidation="False"  class="tooltip" title="Send Money" CommandArgument='<%#Eval("CUST_NO")+","+Eval("APPROVAL_STATUS") %>'>  
                                     <i data-feather="send" class="icon "></i>
                            </asp:LinkButton>
    <asp:Label ID="Benef_Statuslbl" runat="server" Text="" ForeColor="White" Font-Bold="true"></asp:Label>
</div>
</div></div>								
							</div>
                                </ItemTemplate>
                            </asp:repeater>

                       				
							
							
							
							
							
							
							
							
							
							
							
						</div>	
													
							
</asp:Content>
