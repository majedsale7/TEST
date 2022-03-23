<%@ Page Title="Kuwait Bahrain International Exchange Company : Receipt" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PaymentResult.aspx.cs" Inherits="KBE.PaymentResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css" />
	<link href="css/bootstrap.min.css" rel="stylesheet" />
	<link href="css/material-bootstrap-wizard.css" rel="stylesheet" />



<%--<div class="content">--%>
<div class="col-span-12 mt-8 ">
<h1 class="main_heading  truncate  text-center "><label id="Payreceiptheadlbl" runat="server">Payment Receipt</label></h1>
</div>
<div class="intro-y col-span-12 lg:col-span-12 xl:col-span-12 mt-2">
<div class="intro-y box lg:mt-5">
<div class="box paymentreceipt p-5 mt-5">
<div class="print_logo  text-center">
     
<img alt="" class="" src="images/logo.svg">        
     
</div>
    <div class="recept_box">
<div class="flex pt-3">
<div class="mr-auto"><asp:Label ID="PaymentIDlbl1" runat="server" Text="Payment ID"></asp:Label> </div>
<div><asp:Label ID="PaymentIDlbl2" runat="server" Text=""></asp:Label></div>
</div>
<div class="flex mt-2 pt-3 ">
<div class="mr-auto"><asp:Label ID="PostDatelbl1" runat="server" Text="Post Date"></asp:Label> </div>
<div><asp:Label ID="PostDatelbl2" runat="server" Text=""></asp:Label></div>
</div>
<div class="flex mt-2 pt-3 ">
<div class="mr-auto"><asp:Label ID="TransNolbl1" runat="server" Text="Transaction#"></asp:Label> </div>
<div><asp:Label ID="TransNolbl2" runat="server" Text=""></asp:Label></div>
</div>
<div class="flex mt-2 pt-3 ">
<div class="mr-auto"><asp:Label ID="AuthNolbl1" runat="server" Text="Authorization#"></asp:Label> </div>
<div><asp:Label ID="AuthNolbl2" runat="server" Text=""></asp:Label></div>
</div>
<div class="flex mt-2 pt-3 ">
<div class="mr-auto"><asp:Label ID="TrackIDlbl1" runat="server" Text="TrackID"></asp:Label> </div>
<div><asp:Label ID="TrackIDlbl2" runat="server" Text=""></asp:Label></div>
</div>
<div class="flex mt-2 pt-3 ">
<div class="mr-auto"><asp:Label ID="ReferenceNolbl1" runat="server" Text="Reference#"></asp:Label> </div>
<div><asp:Label ID="ReferenceNolbl2" runat="server" Text=""></asp:Label></div>
</div>
<div class="flex mt-2  pb-3 pt-3 border-t border-gray-200 dark:border-dark-5 grandtotal">
<div class="mr-auto font-medium text-base"><asp:Label ID="PaidAmtlbl1" runat="server" Text="Paid Amount"></asp:Label> </div>
<div class="font-medium text-base"><asp:Label ID="PaidAmtlbl2" runat="server" Text=""></asp:Label></div>
</div> 
  <div class="flex mt-2  pb-3 pt-3 border-t border-gray-200 dark:border-dark-5 grandtotal">
<div class="mr-auto font-medium text-base"><asp:Label ID="PaidAtlbl1" runat="server" Text="Paid@"></asp:Label> </div>
<div class="font-medium text-base"><asp:Label ID="PaidAtlbl2" runat="server" Text=""></asp:Label></div>
</div>  
<%--<div class="flex mt-4">
<div class="mr-auto">Discount</div>
<div class="text-theme-6">-KD 20</div>
</div>
<div class="flex mt-4">
<div class="mr-auto">Tax</div>
<div>15%</div>
</div>--%>
 <div class="flex mt-4 pt-4 border-t border-gray-200 dark:border-dark-5">
<div class="mr-auto font-medium text-base"> <asp:Label ID="PayResultlbl1" runat="server" Text="Result"></asp:Label> </div>
<div class="font-medium text-base"><asp:Label ID="PayResultlbl2" runat="server" Text="" Font-Size="Medium"></asp:Label></div>
</div>

</div>

<div class="wizard-footer text-center mt-8 ">
<button type="button" class="btn btn-previous btn-fill btn-default btn-wd" id="CloseBtn" runat="server" onserverclick="CloseBtn_Click">Close<div class="ripple-container"></div></button>
<button type="button" class="btn btn-next btn-fill btn-danger btn-wd next-step" id="PrintBtn" runat="server"><i data-feather="printer" style="float:left;"></i>Print</button>
<button type="button" class="btn btn-next btn-fill btn-danger btn-wd next-step" id="EmailBtn" runat="server" onserverclick="EmailBtn_Click"><i data-feather="mail" style="float:left;"></i> Email Receipt</button>    

   <%-- <input type="button" name="clear" id="CloseBtn" value="Close" class="  shadow-md mr-1 mb-2 next_btn_white" runat="server" causesvalidation="false" onserverclick="CloseBtn_Click" />
    <input type="button" name="submit2" id="PrintBtn" value="Print " class=" w-26 shadow-md mr-1 mb-2 text-white next_btn_green" runat="server" />--%>

    
</div>
     <div class="clear"></div>
    <div class="clear"></div>
    <asp:Label ID="Msglbl" runat="server" Text="" ForeColor="Red"></asp:Label>
</div>
</div>
</div>
<%--</div>--%>


     <!-- BEGIN: JS Assets-->
        <script src="https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/markerclusterer.js"></script>
        <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBG7gNHAhDzgYmq4-EHvM4bqW1DNj2UCuk&libraries=places"></script>
        <script src="js/app.js"></script>
		<script src="js/jquery-2.2.4.min.js" type="text/javascript"></script>
	<script src="js/bootstrap.min.js" type="text/javascript"></script>
	<script src="js/jquery.bootstrap.js" type="text/javascript"></script>

	<!--  Plugin for the Wizard -->
	<script src="js/material-bootstrap-wizard.js"></script>

	<!--  More information about jquery.validate here: http://jqueryvalidation.org/	 -->
	<script src="js/jquery.validate.min.js"></script>
        <!-- END: JS Assets-->


    <div class="modal" id="payment_receipt">
     <div class="modal__content modal__content--lg  "> 
		<div class="modal-header text-center">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title">Payment Receipt</h4>
      </div>
	  
	  <div class="modal-body p-5">
        <div class="intro-y col-span-12 lg:col-span-12 xl:col-span-12 mt-2">
                        <div class="intro-y box ">
						
						
						<div class="box p-5">
						
									<div class="print_logo  text-center">
                    <img alt="" class="" src="images/logo.svg">
                                    </div>
									
									<div class="recept_box">
						
                                    <div class="flex pt-3">
                                        <div class="mr-auto">Subtotal</div>
                                        <div>KD 250</div>
                                    </div>
                                    <div class="flex mt-2 pt-3 ">
                                        <div class="mr-auto">Discount</div>
                                        <div class="text-theme-6">-KD 20</div>
                                    </div> 
                                    <div class="flex mt-2 pt-3 pb-2">
                                        <div class="mr-auto">Tax</div>
                                        <div>15%</div>
                                    </div>
                                    <div class="flex mt-2  pb-3 pt-3 border-t border-gray-200 dark:border-dark-5 grandtotal">
                                        <div class="mr-auto font-medium text-base">Grand Total</div>
                                        <div class="font-medium text-base">KD 220</div>
                                    </div>
									
									
									</div>	
									
									<div class="wizard-footer text-center mt-8 ">
							<button type="button" class="btn btn-previous btn-fill btn-default btn-wd">Cancel<div class="ripple-container"></div></button>
                           <button type="button" class="btn btn-next btn-fill btn-danger btn-wd next-step"><i data-feather="printer" style="float:left;"></i>  Print</button>
                      
</div>
									
								 
								 <div class="clear"></div>	
                                </div>
                            
                            
                        </div>
                       
                       <div class="clear"></div>	
					   
                    </div>
      </div>
	  
     


	 </div>
	  <div style="clear:both"></div>
	 
 </div>

</asp:Content>
