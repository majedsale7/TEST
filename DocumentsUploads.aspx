<%@ Page Title="Kuwait Bahrain International Exchange Company : Supporting Documents Upload" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DocumentsUploads.aspx.cs" Inherits="KBE.DocumentsUploads" Async="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    	<div class="col-span-12 mt-8 ">			
			<h1 class="main_heading  truncate  text-center"><label id="UploadSupDocHeadlbl" runat="server">Upload Supporting Documents</label> </h1>
			  </div> 

    			<div class="  box  send_money pading_20 mt-5">		
							
						 <div class="row">
						 
						 
						 <div class="intro- grid grid-cols-12 gap-6 sm:gap-6 mt-5">

	<div class="intro-y col-span-12 sm:col-span-6 md:col-span-6 xxl:col-span-6 ">	
	<label id="SuppDocTypelbl" runat="server">Supporting Document Type </label>
        <asp:DropDownList ID="SuppDocDDL" runat="server" class="select2 w-full " DataSourceID="SuppDocList_ODS" DataTextField="DESC_E" DataValueField="LOOKUP_ID" AppendDataBoundItems="True"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="SuppDocDDL_ReqF" runat="server" ErrorMessage="Supporting Document Type Required" CssClass="Validate-Error" SetFocusOnError="True" Display="Dynamic" ControlToValidate="SuppDocDDL" InitialValue="Select"></asp:RequiredFieldValidator>
							
</div>		

<div class="clear"></div>

<div class="intro-y col-span-12 sm:col-span-6 md:col-span-6 xxl:col-span-6 ">
           
		   <div class="form-group">
    <label for="FUSuppDoc" id="ChooseSuppDoclbl" runat="server">Choose Supporting Document</label>    
               <asp:FileUpload ID="FUSuppDoc" runat="server"   onchange="showpreviewDoc(this);" ViewStateMode="Enabled" accept=".png,.jpg,.jpeg,.doc,.pdf,.docx"/> <br />
    <asp:RequiredFieldValidator ID="FUSuppDoc_ReqF" runat="server" ErrorMessage="Supporting Document Required" Display="Dynamic" ControlToValidate="FUSuppDoc" SetFocusOnError="True" CssClass="Validate-Error"></asp:RequiredFieldValidator>
  </div>	
		   
			</div>	
			
			<div class="clear"></div>

<div class="intro-y col-span-12 sm:col-span-6 md:col-span-6 xxl:col-span-6 ">
           
		   <div class="form-group">
    <div>        
          <img id="imgpreviewDoc" height="auto" width="125" src="" style="border-width: 0px; visibility: hidden;" />
    </div>
  </div>	
		   
			</div>	
			
			
			<div style="clear:both;"></div>
			<div class="intro-y col-span-12 sm:col-span-6 md:col-span-6 xxl:col-span-6 ">
						<%--<a href="#" class="button mr-2 mb-5  flex items-center justify-center mr-2 mb-2 flex items-center justify-center text-white bg-theme-1 shadow-md mr-2 add_btn" >Submit</a>--%>
                <asp:Button ID="UploadBtn" runat="server" Text="Upload Document" class="button mr-2 mb-5  flex items-center justify-center mr-2 mb-2 flex items-center justify-center text-white bg-theme-1 shadow-md mr-2 add_btn" CausesValidation="True" OnClick="UploadBtn_Click" UseSubmitBehavior="False" />
						<div style="clear:both;"></div>
			</div>	
			
</div>	
						 							 
							</div>
							<div class="clear"></div>
							</div>

    <asp:ObjectDataSource ID="SuppDocList_ODS" runat="server" SelectMethod="SuppDocumentsList" TypeName="KBE.RESTFull.RESTClass"></asp:ObjectDataSource>

     <script type="text/javascript">
         function showpreviewDoc(input) {

            if (input.files && input.files[0]) {

                var reader = new FileReader();
                reader.onload = function(e) {
                    $('#imgpreviewDoc').css('visibility', 'visible');
                    $('#imgpreviewDoc').attr('src', e.target.result);

                    var extension = input.files[0].type;
                    if (extension != "image/jpeg") {
                        $('#imgpreviewDoc').attr('src', "images/Documents.png");
                    }
                }
                reader.readAsDataURL(input.files[0]);              
            }

          }         
          </script>

</asp:Content>
