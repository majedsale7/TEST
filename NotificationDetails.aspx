<%@ Page Title="Kuwait Bahrain International Exchange Company : Notifications" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NotificationDetails.aspx.cs" Inherits="KBE.NotificationDetails" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--  <div class="content">--%>
                <!-- BEGIN: Top Bar -->
                
                <!-- END: Top Bar -->
                
			
			
			<div class="col-span-12 mt-8 ">
			
			<h1 class="main_heading  truncate  text-center"> <asp:Label ID="Notificationslbl" runat="server" Text="Notifications"></asp:Label></h1>

                <div style="clear:both;"></div>
                <asp:Button ID="ClearBtn" runat="server" Text="Clear All Notifications" class="button items-center justify-center mr-2 mt-2 flex text-white bg-theme-1 shadow-md add_btn float-right" CausesValidation="False" OnClick="ClearBtn_Click" UseSubmitBehavior="False" />
						<%--<a href="upload-document.html" class="button items-center justify-center mr-2 mt-2 flex text-white bg-theme-1 shadow-md add_btn float-right" >Clear All Notifications</a>--%>
						<div style="clear:both;"></div>

			  </div> 
	
    <div id="MainDiv" runat="server">
    			

        </div>

							
							<%--</div>	--%>
</asp:Content>
