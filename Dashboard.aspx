<%@ Page Title="Kuwait Bahrain International Exchange Company : Dash Board" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="KBE.Dashboard"  Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .PromImg
    {
        width:100%;      
      height: auto;
    }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<%-- <div class="content">--%>
                <!-- BEGIN: Top Bar -->
                
                <!-- END: Top Bar -->
                <div class="intro-y grid grid-cols-12 gap-3 sm:gap-6 mt-5">
                        <div class="intro-y col-span-12 sm:col-span-6 md:col-span-3 xxl:col-span-3">
						 <%--<a href="javascript:;" data-toggle="modal" data-target="#large-modal-size-preview" >--%>
                            <a href="Sendmoney">
                            <div class="file box rounded-md px-5 pt-8 pb-5 px-3 sm:px-5 relative zoom-in">                                
                                <div  class="icon_mage"><img src="images/1.png"></div>
                                <div  class="block mt-4 h3 text-center truncate"> <asp:Label ID="Remittancelbl_DB" runat="server" Text="Remittance"></asp:Label> </div> 
 <div class="text-gray-600 h6 text-center"><asp:Label ID="Trustedsecurelbl" runat="server" Text="Trusted. Secure. Fast."></asp:Label> </div>                                
                            </div>
							</a>
                        </div>
						
                         <div class="intro-y col-span-12 sm:col-span-6 md:col-span-3 xxl:col-span-3">
                            <div class="file box rounded-md px-5 pt-8 pb-5 px-3 sm:px-5 relative zoom-in">                                
                                <a href="Transactions"><div class="icon_mage"><img src="images/2.png"></div></a>
                                <a href="Transactions" class="block h3 mt-4 text-center truncate"><asp:Label ID="MyTranslbl_DB" runat="server" Text="My Transactions"></asp:Label> </a> 
 <div class="text-gray-600 h6 text-center"><asp:Label ID="Historypastlbl" runat="server" Text=" History. Past 12 Months."></asp:Label></div>                                
                            </div>
                        </div>
						
						 <div class="intro-y col-span-12 sm:col-span-6 md:col-span-3 xxl:col-span-3">
                            <div class="file box rounded-md px-5 pt-8 pb-5 px-3 sm:px-5 relative zoom-in">                                
                                <a href="Beneficiaries"><div class="icon_mage"><img src="images/3.png"></div></a>
                                <a href="Beneficiaries" class="block h3 mt-4 text-center truncate">
                                    <asp:Label ID="Beneficirieslbl_DB" runat="server" Text="Beneficiaries"></asp:Label> </a>   
 <div class="text-gray-600 h6 text-center"><asp:Label ID="Vieweditlbl" runat="server" Text="View. Edit. Add."></asp:Label> </div>								
                            </div>
                        </div>
						
						 <div class="intro-y col-span-12 sm:col-span-6 md:col-span-3 xxl:col-span-3">
                            <div class="file box rounded-md px-5 pt-8 pb-5 px-3 sm:px-5 relative zoom-in">                                
                               <a href="Exchange"> <div class="icon_mage"><img src="images/4.png"></div></a>
                                <a href="Exchange" class="block h3 mt-4 text-center truncate"> <asp:Label ID="ExchRatelbl_DB" runat="server" Text="Exchange Rate"></asp:Label> </a>  
 <div class="text-gray-600 h6 text-center"><asp:Label ID="Viewrateslbl" runat="server" Text="View Rates. Set Alerts."></asp:Label> </div>								
                            </div>
                        </div>					
						
            </div>
			

   <%-- <div class="intro-y box px-5 pt-5 mt-5 text-center mt-8">
			
			<h3 class="h4 mrg_btm_20">Your history of the past 12 months is used to determine your special rate</h3>
			
			
                     <div class="flex flex-col sm:flex-row lg:flex-row border-b border-gray-200 pb-5 -mx-5">
					
					
					
                        <div class=" flex-1 px-5 mt-6 lg:mt-0 items-center justify-center lg:justify-start pt-5 lg:pt-0 border-t lg:border-0 border-gray-200">
                            
                            <div class="">
								<div href="#" class="icon_mage"><img src="images/tr.png"></div>
                                <div class=" truncate sm:whitespace-normal font-medium text-lg"><asp:Label ID="Transactionslbl" runat="server" Text="Transactions"></asp:Label> </div>
                                <div class="text-green h5"><asp:Label ID="TransNolbl_D" runat="server" Text=""></asp:Label></div>
                            </div>
                        </div>
                        <div class=" mt-6 lg:mt-0 items-center lg:items-start flex-1 flex-col justify-center px-5 border-l border-r border-gray-200 border-t lg:border-t-0 pt-5 lg:pt-0">
                           <div class="">
								<div href="#" class="icon_mage"><img src="images/va.png"></div>
                                <div class="  truncate sm:whitespace-normal font-medium text-lg"><asp:Label ID="Valuelbl" runat="server" Text="Value"></asp:Label> </div>
                                <div class="text-green h5">KWD <span class="text-black"><asp:Label ID="Valuelbl_D" runat="server" Text=""></asp:Label></span></div>
                            </div>
                        </div>
                        <div class="mt-6 lg:mt-0 flex-1 px-5 border-t lg:border-0 border-gray-200 pt-5 lg:pt-0">
                           <div class="">
								<div href="#" class="icon_mage"><img src="images/sa.png"></div>
                                <div class=" truncate sm:whitespace-normal font-medium text-lg"><asp:Label ID="Savingslbl" runat="server" Text="Savings"></asp:Label> </div>
                                <div class="text-green h5">KWD <span class="text-black"><asp:Label ID="Savingslbl_D" runat="server" Text=""></asp:Label> </span></div>
                            </div>
                        </div>
                    </div>
					
			
                    
                </div>--%>
			
			
			
			<div class="col-span-12 mt-8">
                            <div class="intro-y block sm:flex items-center h-10">
                                <h2 class="text-lg font-medium truncate mr-5">
                                    <asp:Label ID="FavBeneflbl" runat="server" Text="Favorite Beneficiaries"></asp:Label> 
                                </h2>
                                
                            </div>

                 <div class="intro-y overflow-auto lg:overflow-visible mt-8 sm:mt-0 mob_mrg_top_0">            

            <asp:GridView ID="BenefGV" runat="server" AutoGenerateColumns="false" class="table table-report " EmptyDataText="No Beneficiary List Available" 
                OnRowDeleting="BenefGV_RowDeleting" OnRowUpdating="BenefGV_RowUpdating" DataKeyNames="CUST_NO,FAV_BNF,ENABLED_BNF,CUST_ID,APPROVAL_STATUS" OnRowDataBound="BenefGV_RowDataBound">
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
                    <asp:BoundField DataField="SYS_DATE" HeaderText="Last Used On" HeaderStyle-HorizontalAlign="Left" DataFormatString="{0:dd-MM-yyyy}">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <%-- <asp:BoundField DataField="APPROVAL_STATUS" HeaderText="Status" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>--%>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action">
                        <ItemTemplate>
                             <div class="flex justify-center items-center">
                                 <asp:LinkButton ID="FavBtn" CommandName="Delete" runat="server" CausesValidation="False" class="flex items-center mr-3 text-theme-9 tooltip" title="Favorite">  
                                     <i data-feather="star" class="icon"></i>                              
                            </asp:LinkButton>                              

                                 <asp:LinkButton ID="SendBtn" CommandName="Update" runat="server" CausesValidation="False" class="flex items-center mr-3 text-theme-9 tooltip" title="Send Money">  
                                     <i data-feather="send" class="icon "></i>
                            </asp:LinkButton>
                         
                        </div>
                           
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"/>                        
                    </asp:TemplateField>
                </Columns>
                <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle CssClass="bg-white" />
                <RowStyle CssClass="intro-x" />
            </asp:GridView>

        </div>
                               
                           
                        </div>
			
			
            <!-- END: Content -->



    <%-- <br />
     <img id="Prom1Img" runat="server" src=""/>
     <img id="Prom2Img" runat="server" src=""/>
     <img id="Prom3Img" runat="server" src=""/>--%>

<%--        </div> --%>
		
  
   <%--  <div class="modal" id="slick-modal-preview">
     <div class="modal__content modal__content--lg">  
         
        <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="background: #d7dce1;"><span aria-hidden="true" ><i data-feather="x" class="w-8 h-8 " style="color: #000;"></i></span></button>     	 
		 
		 <div class="p-5">
             <div class="slider mx-6 single-item">  
     <div class=" px-2 ">         
         <div class="h-full bg-gray-200 dark:bg-dark-1 rounded-md">
            <img id="Prom1Img" runat="server" src=""/>
         </div>
     </div>
     <div class=" px-2 ">
         <div class="h-full bg-gray-200 dark:bg-dark-1 rounded-md">
             <img id="Prom2Img" runat="server" src="" />
         </div>
     </div>
     <div class=" px-2 ">
         <div class="h-full bg-gray-200 dark:bg-dark-1 rounded-md">
             <img id="Prom3Img" runat="server" src="" />
         </div>
     </div>
    
 </div> 
         </div>
		 
     </div>
 </div>--%>

   <!----08-10-20 strat---->
 <div class="modal" id="slick-modal-preview">
     <div class="modal__content promotion_popup">          
        <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="background: #d7dce1;"><span aria-hidden="true" ><i data-feather="x" class="w-8 h-8 " style="color: #000;"></i></span></button>		 
		 <div class="p-5">
             <div class="slider mx-6 single-item">
     <div class=" px-2">
         <div class=" bg-gray-200 dark:bg-dark-1 rounded-md">
               <img id="Prom1Img" runat="server" src=""/>
         </div>
     </div>
     <div class=" px-2">
        <div class=" bg-gray-200 dark:bg-dark-1 rounded-md">
              <img id="Prom2Img" runat="server" src="" />
         </div>
     </div>
     <div class=" px-2">
        <div class=" bg-gray-200 dark:bg-dark-1 rounded-md">
              <img id="Prom3Img" runat="server" src="" />
         </div>
     </div>    
 </div>
 
         </div>
		 
     </div>
 </div>
 
 <!----08-10-20 end---->

        <div class="modal fade bs-example-modal-lg"  id="civil_id_expir" role="dialog">
     <div class="modal__content modal__content--lg  "> 
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
	  
	  <div class="modal-body p-5 text-center">
        <div class="rounded-md flex items-center px-5 py-4 mb-2 bg-theme-12 text-white"> <i data-feather="alert-circle" class="w-6 h-6 mr-2"></i> <asp:Label ID="PopupMsglbl" runat="server" Text=""></asp:Label></div>
      
	 <p><a href="CIDUpload" class="underline" id="UploadLinkBtn" runat="server">Click here to upload new Civil ID</a></p>
	  </div>   


	 </div>
	  <div style="clear:both"></div>
	 
 </div>
              
     <script type="text/javascript">              
              
                function ShowPromotions() {                    
                    $("#slick-modal-preview").modal('show');
                }
                function CID_Message() {                    
                    $("#civil_id_expir").modal('show');
                }               
    </script>
   

</asp:Content>