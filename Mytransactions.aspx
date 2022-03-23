<%@ Page Title="Kuwait Bahrain International Exchange Company : My Transactions" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Mytransactions.aspx.cs" Inherits="KBE.Mytransactions" EnableEventValidation="false" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">     
<%--            <div class="content">	--%>	
    

			
			<div class="col-span-12 mt-8 ">
			
			<h1 class="main_heading  truncate  text-center"><asp:Label ID="Mytranslbl" runat="server" Text="My Transactions"></asp:Label> </h1>
			  </div> 
			 
			
					<div class="col-span-12 mt-5">						
							
							
							</div>
							
							<div class="col-span-12 sm:col-span-12 xl:col-span-12 intro-y box pading_20 send_money">		
							
						 <div class="col-span-12">
						
						<div class="grid grid-cols-12 gap-6 form">
                            <div class="col-span-12 sm:col-span-6 xl:col-span-3 intro-y">	
<label id="beneficiarynamelbl" runat="server">Beneficiary Name</label>							
                               <%--<input type="text" class="input  border col-span-4" placeholder="">--%>
                                <asp:TextBox ID="BeneficiaryNameTxt" runat="server" class="input  border col-span-4" placeholder="Enter Searching Name"></asp:TextBox>
							</div>
                            <div class="col-span-12 sm:col-span-6 xl:col-span-3 intro-y">
                              <label id="Fromdatelbl" runat="server">From Date*</label>
     <div class="absolute rounded-l  h-full flex items-center justify-center  text-gray-600 clndr"> <i data-feather="calendar" class="w-4 h-4"></i> </div> 
                                <asp:TextBox ID="FromDateTxt" runat="server" class="datepicker1 input pl-12 border" ></asp:TextBox>
                                <%--<input type="text" class="datepicker input pl-12 border">--%>

                            </div>
                            <div class="col-span-12 sm:col-span-6 xl:col-span-3 intro-y">
                              <label id="Todatelbl" runat="server">To Date*</label> 
     <div class="absolute rounded-l  h-full flex items-center justify-center  text-gray-600 clndr"> <i data-feather="calendar" class="w-4 h-4"></i> </div> 
                                <asp:TextBox ID="ToDateTxt" runat="server" class="datepicker1 input pl-12 border" ></asp:TextBox>
                                <%--<input type="text" class="datepicker input pl-12 border">--%>

                            </div>
							
							
							<div class="col-span-12 sm:col-span-6 xl:col-span-3 intro-y">
                              <%--<button class="button mr-1  flot_lft shadow-md text-white next_btn_green" id="SubmitBtn" runat="server" onserverclick="SubmitBtn_Click">Submit</button>--%>
                                <asp:Button ID="SubmitBtn" runat="server" Text="Submit" class="button mr-1  flot_lft shadow-md text-white next_btn_green" CausesValidation="true" UseSubmitBehavior="false" OnClick="SubmitBtn_Click"  />
							 <%--<a href="my-transfers.html" class="button mr-2 mb-5 mt-8  items-center justify-center mr-2 mb-2 items-center bg-theme-1 text-white icon_btn shadow-md"> <span class="w-5 h-5 flex items-center justify-center "> <i data-feather="columns" class="w-8 h-8"></i> </span> </a> --%>
                                <%--<button class="button mr-1  flot_lft shadow-md text-white next_btn_green" id="ExportBtn" runat="server" onserverclick="ExportBtn_Click">Export</button>  --%>
                                <%--<asp:Button ID="PDFPrint" runat="server" Text="PDF Click" OnClick="PDFPrint_Click" />--%>
                            </div>
							
							</div>
                             <div class="clear"></div>

                             <!------12-11-2020 Star------->
							<div class="grid grid-cols-12 gap-6 form">
                            <div class="col-span-8 sm:col-span-8 xl:col-span-4 intro-y exportfile">
     <div class="flex sm:flex-row mt-2">
         <div class="flex items-center text-gray-700 dark:text-gray-500 mr-2 export_sec"> <input type="radio" class="input border mr-2" id="ExcelRad" name="horizontal_radio_button" value="horizontal-radio-chris-evans" runat="server"> <label class="cursor-pointer select-none" for="horizontal-radio-chris-evans" id="Excellbl" runat="server">Excel</label> </div>
         <div class="flex items-center text-gray-700 dark:text-gray-500 mr-2  sm:mt-0 export_sec"> <input type="radio" class="input border mr-2" id="PDFRad" name="horizontal_radio_button" value="horizontal-radio-liam-neeson" runat="server"> <label class="cursor-pointer select-none" for="horizontal-radio-liam-neeson" id="PDFlbl" runat="server">PDF</label> </div>
     
	  <div class="flex items-center text-gray-700 dark:text-gray-500 mr-2  sm:mt-0 export_sec">
          <%--<button class="button mr-1  flot_lft shadow-md text-white next_btn_green" id="ExportBtn" runat="server" onserverclick="ExportBtn_Click">Export</button>--%>
          <asp:Button ID="ExportBtn" runat="server" Text="Export" class="button mr-1  flot_lft shadow-md text-white next_btn_green" CausesValidation="false" UseSubmitBehavior="false" OnClick="ExportBtn_Click" />
	  </div> 
	 
	 </div>
 </div>                           
							
                         
							  
							</div>
							<!------12-11-2020 end------->

							</div>
							<div class="clear"></div>
							</div>
							
							<div class="clear"></div>

                     <%--   <div class="clear"> <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo.png" /></div>--%>
							
							<div class="intro-y overflow-auto lg:overflow-visible mt-8 sm:mt-0 mob_mrg_top_0">

                                 <asp:GridView ID="TransGV" runat="server" AutoGenerateColumns="false" class="table table-report " EmptyDataText="No Transactions History Available" 
                DataKeyNames="EFT#,TRAN_ID,TRAN_DATE,CURR_CODE,TRF_AMOUNT,LC_AMOUNT,COMMISSION,LC_AMOUNT_TOTAL,BEN_NAME,BEN_ACT,BEN_BANK,BEN_BRN_CODE,BEN_BRN_NAME,CURR_RATE,BEN_BANK_BRN_ADDR1,BEN_TEL1,CUST_ID,CUST_NAME,CUST_TEL,DEST_COUNTRY_NAME,PAYMENT_METHOD,PAID_STATUS,DISCOUNT" OnRowDeleting="TransGV_RowDeleting" OnRowDataBound="TransGV_RowDataBound" >
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sno">
                        <ItemTemplate>
                            <%#Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                     <asp:BoundField DataField="TRAN_DATE" HeaderText="Date" HeaderStyle-HorizontalAlign="Left" DataFormatString="{0:dd-MM-yyyy}">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>    
                     <asp:BoundField DataField="EFT#" HeaderText="EFT#" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                      <asp:BoundField DataField="BEN_NAME" HeaderText="Beneficiary Name" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                      <asp:BoundField DataField="BEN_ACT" HeaderText="Account#" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                      <asp:BoundField DataField="BEN_BANK" HeaderText="Bank" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>     
                      <asp:BoundField DataField="TRF_AMOUNT" HeaderText="Foreign Amount" HeaderStyle-HorizontalAlign="Left" DataFormatString="{0:N2}">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                         <asp:BoundField DataField="CURR_CODE" HeaderText="CUR" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                      <asp:BoundField DataField="LC_AMOUNT" HeaderText="KD" HeaderStyle-HorizontalAlign="Left" DataFormatString="{0:N3}">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>    
                  <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action">
                        <ItemTemplate>
                             <div class="flex justify-center items-center">
                                 <asp:LinkButton ID="DownBtn" CommandName="Delete" runat="server" CausesValidation="False" class="flex items-center mr-3 text-theme-9 tooltip" title="Download">  
                                     <i data-feather="download" class="icon"></i>                              
                            </asp:LinkButton>
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
						
						
									
						
							
							<%--</div>	--%>


   

</asp:Content>
