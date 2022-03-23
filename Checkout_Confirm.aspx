<%@ Page Title="Kuwait Bahrain International Exchange Company : Checkout" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Checkout_Confirm.aspx.cs" Inherits="KBE.Checkout_Confirm" Async="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
    function pageLoad() {
        $(".icon").flex({
           
        });       
    }
</script>
         

    <asp:HiddenField ID="PaidKD_HD" runat="server" />
      <!-- BEGIN: Content -->
   <%-- <div class="content">--%>

         <div class="col-span-12 mt-8 ">

            <h1 class="main_heading  truncate  text-center"><asp:Label ID="Checkoutlbl" runat="server" Text="CHEKOUT"></asp:Label></h1>
        </div>


        <div class="col-span-12 mt-5">

        </div>

       <div class="intro-y overflow-auto lg:overflow-visible mt-8 sm:mt-0 mob_mrg_top_0">  
             
            <asp:GridView ID="CheckGV" runat="server" class="table table-report " AutoGenerateColumns="false" OnRowDataBound="CheckGV_RowDataBound" OnRowDeleting="CheckGV_RowDeleting"
                 DataKeyNames="CUST_NO,EFT_NUM,FC_AMT,LC_AMT" ShowFooter="True">
                <Columns>
                     <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sno">
                        <ItemTemplate>
                            <%#Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>                  
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Account">
                        <ItemTemplate>                         
                            <div>
                                <asp:Label ID="EFTNumlbl" runat="server" Text='<%#Eval("EFT_NUM","EFT#: {0}") %>'></asp:Label><br />
                                <asp:Label ID="BFNlbl" runat="server" Text='<%#Eval("BNF_NAME") %>'></asp:Label><br />
                                <asp:Label ID="ACClbl" runat="server" Text='<%#Eval("BNF_ACC_NUM") %>'></asp:Label><br />
                                <asp:Label ID="BNamelbl" runat="server" Text='<%#Eval("BEN_BANK") %>'></asp:Label><br />
                                <asp:Label ID="LCAmtlbl" runat="server" Text='<%#Eval("LC_AMT","KD: {0:N3}") %>'></asp:Label><br />
                                <asp:Label ID="Commlbl" runat="server" Text='<%#Eval("COMMISSION","Commision: {0:F3}") %>'></asp:Label><br />
                                <asp:Label ID="Otherlbl" runat="server" Text='<%#Eval("OTHER_CHARGES","Other Charge: {0:F3}") %>'></asp:Label><br />                                                                
                            </div>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Receive">
                        <ItemTemplate>                         
                            <div>                                
                                <asp:Label ID="FCAmtlbl" runat="server" Text='<%#Eval("FC_AMT","{0:N0}") %>'></asp:Label> <asp:Label ID="Label7" runat="server" Text='<%#Eval("CURR_CODE") %>'></asp:Label> 
                            </div>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                     <%-- <asp:BoundField DataField="FC_AMT" HeaderText="Receive" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>--%>
                     <asp:BoundField DataField="LC_AMT" HeaderText="Total KD" HeaderStyle-HorizontalAlign="Right">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </asp:BoundField>
                      <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Remove">
                        <ItemTemplate>
                             <div class="flex justify-center items-center">                                 
                                 <asp:LinkButton ID="FavBtn" CommandName="Delete" runat="server" CausesValidation="False" class="flex items-center mr-3 text-theme-9 tooltip" title="Remove" OnClientClick="return confirm('Are you sure to DELETE this from Cart ?');">  
                                     <i data-feather="minus-circle" class="icon"></i>                              
                            </asp:LinkButton>                                 
                        </div>
                           
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"/>                        
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#FFFF99" Font-Size="Medium" ForeColor="Red" />
            </asp:GridView>
                  
        </div>     
		
         <div class="col-span-12 lg:col-span-12 mt-8 mb-5 text-center mob_l_r_15 ">              
                <input type="button" name="clear" id="ClearBtn" value="Back" class="  shadow-md mr-1 mb-2 next_btn_white" runat="server" onserverclick="BackBtn_Click" causesvalidation="false" />
                <input type="button" name="submit2" id="SubmitBtn" value="Proceed to Pay   " class=" w-26 shadow-md mr-1 mb-2 text-white next_btn_green" runat="server" onserverclick="PayBtn_Click" causesvalidation="false"/>
              
            </div>		
        		
<%--    </div>--%>
</asp:Content>
