<%@ Page Title="Kuwait Bahrain International Exchange Company : Civil ID Upload" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CivilIDUploads.aspx.cs" Inherits="KBE.CivilIDUploads" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-span-12 mt-8 ">			
			<h1 class="main_heading  truncate  text-center"><label id="UploadCIDHeadlbl" runat="server"> Upload Civil ID </label></h1>
			  </div>
		
		<div class=" box sendmony">					 
  
 <div class="wizard">
            

  <div class="clear"></div>
<div class="rounded-md flex items-center px-5 py-4 mb-5 bg-theme-12 text-white"> <i data-feather="alert-circle" class="w-6 h-6 mr-2"></i> <asp:Label ID="CIDMsglbl" runat="server" Text=""></asp:Label></div>
<div class="clear"></div>

<div class="intro-y col-span-12 sm:col-span-6 md:col-span-6 xxl:col-span-6 p-15">
<div class="form-group">
<label for="FUCID1" id="FrontCIDUploadlbl"  runat="server">Front Civil Id Upload (Only JPG / PNG)</label>
    <asp:FileUpload ID="FUCID1" runat="server"   onchange="showpreviewCID1(this);" ViewStateMode="Enabled" accept=".png,.jpg,.jpeg"/> <br />
    <asp:RequiredFieldValidator ID="FUCID1_ReqF" runat="server" ErrorMessage="Front Civil ID Photo Required" Display="Dynamic" ControlToValidate="FUCID1" SetFocusOnError="True" CssClass="Validate-Error"></asp:RequiredFieldValidator>
<%--<input type="file" id="exampleInputFile1">--%>
     <div class="clear"></div><div class="clear"></div>	
    <br />
     <img id="imgpreviewCID1" height="auto" width="125" src="" style="border-width: 0px; visibility: hidden;" />
    <br />
</div>
</div>

     <div class="intro-y col-span-12 sm:col-span-6 md:col-span-6 xxl:col-span-6 p-15">
<div class="form-group">
<label for="FUCID2" id="BackCIDUplaodlbl" runat="server">Back Civil Id Upload (Only JPG / PNG)</label>
    <asp:FileUpload ID="FUCID2" runat="server"   onchange="showpreviewCID2(this);" ViewStateMode="Enabled" accept=".png,.jpg,.jpeg"/><br /> 
  <asp:RequiredFieldValidator ID="FUCID2_ReqF" runat="server" ErrorMessage="Back Civil ID Photo Required" Display="Dynamic" ControlToValidate="FUCID2" SetFocusOnError="True" CssClass="Validate-Error"></asp:RequiredFieldValidator>        
<%--<input type="file" id="exampleInputFile2">--%>
      <div class="clear"></div><div class="clear"></div>		
    <br />
   <img id="imgpreviewCID2" height="auto" width="125" src="" style="border-width: 0px; visibility: hidden;" />
     <br />
</div>
</div>


<div style="clear:both;"></div>
			<div class="justify-center mb-2 flex items-center text-center">
						<%--<a href="#" class="button  mb-6 mt-2 text-white bg-theme-1 shadow-md add_btn" >Upload Civil ID</a>--%>
                <asp:Button ID="UploadBtn" runat="server" Text="Upload Civil ID" class="button  mb-6 mt-2 text-white bg-theme-1 shadow-md add_btn" CausesValidation="True" OnClick="UploadBtn_Click" UseSubmitBehavior="False" />
						</div>
						<div style="clear:both;"></div>			
						
				
				</div>			
						
							
							</div>	
                <!-- END: Pricing Tab -->
                <!-- BEGIN: Pricing Content -->
                
                <!-- END: Pricing Content -->

    <script type="text/javascript">
          function showpreviewCID1(input) {

            if (input.files && input.files[0]) {

                var reader = new FileReader();
                reader.onload = function(e) {
                    $('#imgpreviewCID1').css('visibility', 'visible');
                    $('#imgpreviewCID1').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }

          }
          function showpreviewCID2(input) {

              if (input.files && input.files[0]) {

                  var reader = new FileReader();
                  reader.onload = function (e) {
                      $('#imgpreviewCID2').css('visibility', 'visible');
                      $('#imgpreviewCID2').attr('src', e.target.result);
                  }
                  reader.readAsDataURL(input.files[0]);
              }

          }
          </script>
</asp:Content>
