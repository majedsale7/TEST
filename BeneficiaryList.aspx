<%@ Page Title="Kuwait Bahrain International Exchange Company : My Beneficiaries" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BeneficiaryList.aspx.cs" Inherits="KBE.BeneficiaryList" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- BEGIN: Content -->
<%--    <div class="content">--%>
        <!-- BEGIN: Top Bar -->

        <!-- END: Top Bar -->






        <div class="col-span-12 mt-8">

            <h1 class="main_heading  truncate  text-center">
                <asp:Label ID="BenefListlbl" runat="server" Text="Beneficiary List"></asp:Label></h1>
        </div>


        <div class="col-span-12  mob_mrg_top_0">          

            <div class="grid grid-cols-12 gap-6 mt-5 form">

            <div class="col-span-12 sm:col-span-6 xl:col-span-4 intro-y ">
                <a href="Beneficiary" class="button mr-2 mb-5 mt-10 flex items-center justify-center mr-2 mb-2 flex items-center justify-center text-white bg-theme-1 shadow-md mr-2 add_btn" style="float: left"><i data-feather="plus" class="w-4 h-4 mr-2"></i>
                    <asp:Label ID="AddNewBeneflbl" runat="server" Text="Add New Beneficiary"></asp:Label></a>
                <a href="Beneficiarries" class="button mr-2 mb-5 mt-10  items-center justify-center mr-2 mb-2 items-center bg-theme-1 text-white icon_btn shadow-md"><span class="w-5 h-5 flex items-center justify-center "><i data-feather="columns" class="w-8 h-8"></i></span></a>
            </div>

                <div class="col-span-12 sm:col-span-5 xl:col-span-5  ">	</div>
                	<div class="col-span-12 sm:col-span-3 xl:col-span-3 mt-5 filter_btn  right">	
                        <asp:DropDownList ID="FilterDDL" runat="server" CssClass="bg-theme-1 select2 w-full" AutoPostBack="True" OnSelectedIndexChanged="FilterDDL_SelectedIndexChanged"></asp:DropDownList>						                             
 
							</div>
                </div>

        </div>

    <div class="clear"></div>

        <div class="intro-y overflow-auto mt-8 sm:mt-0 mob_mrg_top_0">            

            <asp:GridView ID="BenefGV" runat="server" AutoGenerateColumns="false" class="table table-report " EmptyDataText="No Beneficiary List Available" 
                OnRowDeleting="BenefGV_RowDeleting" OnRowEditing="BenefGV_RowEditing" OnRowUpdating="BenefGV_RowUpdating" DataKeyNames="CUST_NO,FAV_BNF,ENABLED_BNF,CUST_ID,APPROVAL_STATUS" OnRowDataBound="BenefGV_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sno">
                        <ItemTemplate>
                            <%#Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="BEN_NAME" HeaderText="Beneficiary Name" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TRANSFER_TYPE" HeaderText="Transfer Type" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BEN_ACT" HeaderText="Account Number" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BNF_BANK_CODE_EN" HeaderText="Bank Name" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BRN_NAME" HeaderText="Bank Branch" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SYS_DATE" HeaderText="Last Used" HeaderStyle-HorizontalAlign="Left" DataFormatString="{0:dd-MM-yyyy}">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                   <%--  <asp:BoundField DataField="APPROVAL_STATUS" HeaderText="Status" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>--%>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action">
                        <ItemTemplate>
                             <div class="flex justify-center items-center">
                                 <asp:LinkButton ID="FavBtn" CommandName="Delete" runat="server" CausesValidation="False" class="flex items-center mr-3 text-theme-9 tooltip" title="Favorite">  
                                     <i data-feather="star" class="icon"></i>                              
                            </asp:LinkButton>

                                 <asp:LinkButton ID="EnableBtn" CommandName="Edit" runat="server" CausesValidation="False" class="flex items-center mr-3 text-theme-9 tooltip" title="Disable">  
                                     <i data-feather="toggle-left" class="icon"></i>                        
                            </asp:LinkButton>

                               <%--  <asp:LinkButton ID="ViewBtn" CommandName="Delete" runat="server" CausesValidation="False" class="flex items-center mr-3 text-theme-9 tooltip" title="View">  
                                     <i data-feather="eye" class="icon"></i>
                            </asp:LinkButton>--%>

                                 <asp:LinkButton ID="SendBtn" CommandName="Update" runat="server" CausesValidation="False" class="flex items-center mr-3 text-theme-9 tooltip" title="Send Money">  
                                     <i data-feather="send" class="icon "></i>
                            </asp:LinkButton>

                                 <asp:Label ID="Benef_Statuslbl" runat="server" Text=""></asp:Label>
                        </div>
                           
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"/>                        
                    </asp:TemplateField>
                </Columns>
                <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle CssClass="bg-gray-700 text-white" />
                <RowStyle CssClass="intro-x" />
            </asp:GridView>

        </div>

        
  <%--  </div>--%>
    <!-- END: Pricing Tab -->
    <!-- BEGIN: Pricing Content -->

    <!-- END: Pricing Content -->
</asp:Content>
