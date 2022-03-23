<%@ Page Title="Kuwait Bahrain International Exchange Company : Branches" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BranchesDetails.aspx.cs" Inherits="KBE.BranchesDetails" Async="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
    function pageLoad() {
        $("select.w-full").select2({
           
        });       
    }
</script>

  <%--   <div class="content">--%>
                <!-- BEGIN: Top Bar -->
                
                <!-- END: Top Bar -->
                
			
			
			<div class="col-span-12 mt-8 ">
			
			<h1 class="main_heading  truncate  text-center"><asp:Label ID="BranchesHeadlbl" runat="server" Text="Branches"></asp:Label></h1>
			  </div> 
			
			
			
			<div class=" intro-y box  send_money pading_20 mt-5">		
							
						 <div class="row">
						
						<div class="mt-1 col-md-6"><asp:Label ID="SelectBranchlbl" runat="server" Text="Select Branch"></asp:Label> 
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                            <asp:DropDownList ID="BranchDDL" runat="server" class="select2 w-full" DataSourceID="Branch_ODS" DataTextField="BRN_NAME" DataValueField="BRN_MAP_INFO" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="BranchDDL_SelectedIndexChanged" ViewStateMode="Enabled"></asp:DropDownList>
                                </ContentTemplate></asp:UpdatePanel>							
							 </div>
							</div>
							
							</div>
			
	<div class="clear"></div>					

			<div class="intro-y chat grid grid-cols-12 gap-5 mt-5 contct">
			
						
                    <div class="col-span-12 lg:col-span-12 xxl:col-span-12">
                        <div class="intro-y pr-1">
                            <div class="box p-5 ">						
							<div class="branch_box">
              <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
      <div class="entry-content-other">	
		 <div class="entry-header mb-5">
			<h1 class="entry-title"><asp:Label ID="MapLoclbl" runat="server" Text=""></asp:Label></h1>			
		  </div>
		  <!-- .entry-header -->
	     <%--<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d26263.545485012455!2d47.6579182198145!3d29.336389296574236!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3fcff410bda463d7%3A0x4dde79d4a62f202b!2sAl%20Jahra%2C%20Kuwait!5e0!3m2!1sen!2sin!4v1598102185075!5m2!1sen!2sin" width="100%" height="450" frameborder="0" style="border:0;" allowfullscreen="" aria-hidden="false" tabindex="0" id="Map" runat="server"></iframe>--%>
          <iframe src="" width="100%" height="450" frameborder="0" style="border:0;" allowfullscreen="" aria-hidden="false" tabindex="0" id="Map" runat="server"></iframe>
  </div>
                  </ContentTemplate></asp:UpdatePanel>
  <!-- .entry-main-content -->





							</div>

							</div>
						</div>
                        
                    </div>			 
						
			 </div>						
							
							
							<%--</div>	--%>

    <asp:ObjectDataSource ID="Branch_ODS" runat="server" SelectMethod="BranchMapList" TypeName="KBE.RESTFull.RESTClass"></asp:ObjectDataSource>
</asp:Content>
