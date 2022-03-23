<%@ Page Title="Kuwait Bahrain International Exchange Company : Promotions" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PromotionBanners.aspx.cs" Inherits="KBE.PromotionBanners" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<%--       <div class="content">   --%>            
			
			<div class="col-span-12 mt-8 ">
			
			<h1 class="main_heading  truncate  text-center"><asp:Label ID="PromotionsHeadlbl" runat="server" Text="Promotions"></asp:Label></h1>
			  </div> 
	<div class="grid grid-cols-12 gap-6 mt-5 promotions">		
			
	<div class="intro-y col-span-12 lg:col-span-12">					
						 
	<div class=" box ">					 
  
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
							
		  </div>   </div> 					
							
						<%--	</div>--%>	

</asp:Content>
