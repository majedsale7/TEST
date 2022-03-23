<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Send_Money.aspx.cs" Inherits="KBE.Send_Money" Async="true" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html>

<html lang="en">
    <!-- BEGIN: Head -->
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        
         <title>Kuwait Bahrain International Exchange Company : Send Money</title>
    <link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico">
        <!-- BEGIN: CSS Assets-->
		<link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css" />      
          

	<link href="css/bootstrap.min.css" rel="stylesheet" />
	<link href="css/material-bootstrap-wizard.css" rel="stylesheet" />
        <link rel="stylesheet" href="css/app.css" />
        <link rel="stylesheet" href="css/loading.css" />
		<link href="https://fonts.googleapis.com/css2?family=Tajawal&display=swap" rel="stylesheet">
        <!-- END: CSS Assets-->
        <script type = "text/javascript" >
function disableBackButton()
{
window.history.forward(1);
}
setTimeout("disableBackButton()", 0);
document.oncontextmenu = function() { 
    return false; 
}
</script>

<script type = "text/javascript">
(function() {

    const idleDurationSecs = 600;    // X number of seconds
    const redirectUrl = 'logout';  // Redirect idle users to this URL
    let idleTimeout; // variable to hold the timeout, do not modify

    const resetIdleTimeout = function() {

        // Clears the existing timeout
        if(idleTimeout) clearTimeout(idleTimeout);

        // Set a new idle timeout to load the redirectUrl after idleDurationSecs
        idleTimeout = setTimeout(() => location.href = redirectUrl, idleDurationSecs * 1000);
    };

    // Init on page load
    resetIdleTimeout();

    // Reset the idle timeout on any of the events listed below
    ['click', 'touchstart', 'mousemove'].forEach(evt => 
        document.addEventListener(evt, resetIdleTimeout, false)
    );

})();
</script>

    </head>
    <!-- END: Head -->
    <body class="app">
         <form role="form" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

              <!----08-10-20 strat---->
	<div class="fullpage-loader">
	<div class="fullpage-loader__logo">
		<img src="images/load.gif" />
	</div>
	</div>
	<!----08-10-20 end---->
               
        <!-- BEGIN: Mobile Menu -->
        <div class="mobile-menu md:hidden">
            <div class="mobile-menu-bar">
                <a href="" class="flex mr-auto">
                    <img alt="" class="logo" src="images/logo.svg">
                </a>
				

                <a href="javascript:;" id="mobile-menu-toggler"> <i data-feather="bar-chart-2" class="w-8 h-8 text-white transform -rotate-90"></i> </a>
            </div>
            <ul class="border-t border-theme-24 py-5 hidden">
				<li>
                        <a href="Dashboard" class="menu menu--active">
                            <div class="menu__icon"> <i data-feather="codepen"></i> </div>
                            <div class="menu__title">  <asp:Label ID="Dashboardlbl_M" runat="server" Text="Dashboard"></asp:Label> </div>
                        </a>
                    </li>
                <li>
                    <a href="Sendmoney" class="menu ">
                        <div class="menu__icon"> <i data-feather="refresh-cw"></i> </div>
                        <div class="menu__title"> <asp:Label ID="Remittancelbl_M" runat="server" Text="Remittance"></asp:Label> </div>
                    </a>
                </li>
               
                <li>
                    <a href="Transactions" class="menu">
                        <div class="menu__icon"> <i data-feather="credit-card"></i> </div>
                        <div class="menu__title"> <asp:Label ID="MyTranslbl_M" runat="server" Text="My Transactions"></asp:Label> </div>
                    </a>
                </li>
                  <li>
                    <a href="Beneficiary" class="menu ">
                        <div class="menu__icon"><i data-feather="user-plus"></i></div>
                        <div class="menu__title">
                            <asp:Label ID="BenefAddlbl_M" runat="server" Text="Add Beneficiary"></asp:Label>
                        </div>
                    </a>
                </li>
                <li>
                    <a href="Beneficiaries" class="menu ">
                        <div class="menu__icon"> <i data-feather="users"></i> </div>
                        <div class="menu__title"> <asp:Label ID="Beneflbl_M" runat="server" Text="Beneficiaries"></asp:Label> </div>
                    </a>
                </li>
                <li>
                    <a href="Exchange" class="menu">
                        <div class="menu__icon"> <i data-feather="globe"></i> </div>
                        <div class="menu__title"> <asp:Label ID="ExchnRatelbl_M" runat="server" Text="Exchange Rate"></asp:Label> </div>
                    </a>
                </li>
                  <li>
                    <a href="Branches" class="menu">
                        <div class="menu__icon"> <i data-feather="home"></i> </div>
                        <div class="menu__title"> <asp:Label ID="Brancheslbl_M" runat="server" Text="Branch Details"></asp:Label> </div>
                    </a>
                </li>
				
				<li>
                    <a href="Promotions" class="menu">
                        <div class="menu__icon"> <i data-feather="layers"></i> </div>
                        <div class="menu__title"> <asp:Label ID="Promotionslbl_M" runat="server" Text="Promotions"></asp:Label> </div>
                    </a>
                </li>
				
				<li>
                    <a href="FAQ" class="menu">
                        <div class="menu__icon"> <i data-feather="list"></i> </div>
                        <div class="menu__title"> <asp:Label ID="FAQlbl_M" runat="server" Text="FAQs"></asp:Label> </div>
                    </a>
                </li>
				
				<li>
                    <a href="Contact" class="menu">
                        <div class="menu__icon"> <i data-feather="mail"></i> </div>
                        <div class="menu__title">  <asp:Label ID="Contactuslbl_M" runat="server" Text="Contact Us"></asp:Label> </div>
                    </a>
                </li>

                
                <li>
                    <a href="javascript:;" class="menu">
                        <div class="menu__icon"> <i data-feather="edit"></i> </div>
                        <div class="menu__title"> <asp:Label ID="Language2lbl" runat="server" Text="Language"></asp:Label> <i data-feather="chevron-down" class="menu__sub-icon"></i> </div>
                    </a>
                    <ul class="">
                        <li>
                            <a href="#" class="menu">
                                <div class="menu__icon"> <i data-feather="activity"></i> </div>
                                <div class="menu__title"> 
                                    <%--<asp:Button ID="EngBtn2" runat="server" Text="English" class="block p-2 transition duration-300 ease-in-out bg-white hover:bg-gray-200 rounded-md" OnClick="EngBtn_Click" UseSubmitBehavior="false" CausesValidation="false"/> --%>
                                    <asp:Button ID="EngBtn2" runat="server" Text="English" OnClick="EngBtn_Click" UseSubmitBehavior="false" CausesValidation="false"/> 
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#" class="menu">
                                <div class="menu__icon"> <i data-feather="activity"></i> </div>
                                <div class="menu__title arabic"> 
                                    <%--<asp:Button ID="ArbBtn2" runat="server" Text="عربى" class="block p-2 transition duration-300 ease-in-out bg-white hover:bg-gray-200 rounded-md arabic" OnClick="ArbBtn_Click" UseSubmitBehavior="false" CausesValidation="false"/> --%>
                                    <asp:Button ID="ArbBtn2" runat="server" Text="عربى" OnClick="ArbBtn_Click" UseSubmitBehavior="false" CausesValidation="false"/> 
                                </div>
                            </a>
                        </li>
                    </ul>
                </li>
                
                
                
                
               
               
            </ul>
        </div>
        <!-- END: Mobile Menu -->
        
        <div class=" -mt-10 md:-mt-5 header_main">
            <div class="top-bar-boxed flex items-center">
                <!-- BEGIN: Logo -->
                <a href="" class="-intro-x hidden md:flex">
                    <img alt="" class="top_logo" src="images/logo.svg">
                </a>
                <!-- END: Logo -->
                <!-- BEGIN: Breadcrumb -->
				
				
				
                
                <!-- END: Breadcrumb -->
                <!-- BEGIN: Search -->
				
				<div class="top_icons">
				
				
                
                <!-- END: Search -->
                <!-- BEGIN: Notifications -->
                <div class="intro-x dropdown relative mr-3 sm:mr-3">
                    <div class="dropdown-toggle notification notification--light  cursor-pointer icon_bg tooltip" title="Notifications">
                         <a href="Notifications"><img class="" src="images/bell.png"></a> 
                    </div>
                     <div class="w-5 h-5 flex items-center justify-center absolute cart_number text-xs text-white rounded-full font-medium -mt-1 -mr-1 NonPrintable" id="NotifyDiv" runat="server">                            
                            <asp:Label ID="NotifyCNTlbl" runat="server" Text="" />                                
                        </div>
                   <%-- <div class="notification-content dropdown-box mt-8 absolute top-0 right-0 z-10 -mr-10 sm:mr-0">
                        <div class="notification-content__box dropdown-box__content box">
                            <div class="notification-content__title">Notifications</div>
                            
                            <div class="cursor-pointer relative flex items-center ">
                                    
                                    <div class="ml-2 overflow-hidden">
                                        <div class="flex items-center">
                                            <a href="javascript:;" class="font-medium truncate mr-5">Denzel Washington</a> 
                                            <div class="text-xs text-gray-500 ml-auto whitespace-no-wrap">05:09 AM</div>
                                        </div>
                                        <div class="w-full truncate text-gray-600">It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem </div>
                                    </div>
                                </div>
                            
                        </div>
                    </div>--%>
                </div>
				
				<div class="intro-x dropdown relative mr-3 sm:mr-3">
                    <%--<span class="fa-id-badge font-medium truncate mr-5"><asp:Label ID="CartCNTlbl" runat="server" Text=""/></span>--%>
                    <div class="dropdown-toggle notification notification--light  cursor-pointer icon_bg tooltip" title="Cart"><img class="" src="images/supermarket.png"> </div>
                     
                    <div class="w-5 h-5 flex items-center justify-center absolute cart_number text-xs text-white rounded-full font-medium -mt-1 -mr-1" id="BadgeDiv" runat="server">                        
                        <asp:Label ID="CartCNTlbl" runat="server" Text=""/>
                    </div>
                     
                    <div class="notification-content dropdown-box mt-8 absolute top-0 right-0 z-10 -mr-10 sm:mr-0">
                        <div class="notification-content__box dropdown-box__content box">
                            <div class="notification-content__title"><span id="Remittancecartlbl" runat="server"> Remittance Cart</span></div>
                            
                           <%-- <div class="cursor-pointer relative flex items-center ">
                                <div class="w-12 h-12 flex-none image-fit mr-1">
                                    <img alt="Midone Tailwind HTML Admin Template" class="rounded-full" src="images/profile-5.jpg">
                                </div>
                                <div class="ml-2 overflow-hidden">
                                    <div class="flex items-center">
                                        <a href="javascript:;" class="font-medium truncate mr-5">Product</a> 
                                        <div class="text-xs text-gray-500 ml-auto whitespace-no-wrap">KD 12.000</div>
                                    </div>
                                    <div class="w-full truncate text-gray-600">It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem </div>
                                </div>
                            </div>--%>
                            
                            <%--<div id="CartDiv" runat="server"></div>--%>
							
						<%--	<div class="cursor-pointer relative flex items-center mt-5">
                                <div class="w-12 h-12 flex-none image-fit mr-1">
                                    <img alt="Midone Tailwind HTML Admin Template" class="rounded-full" src="images/profile-5.jpg">
                                </div>
                                <div class="ml-2 overflow-hidden">
                                    <div class="flex items-center">
                                        <a href="javascript:;" class="font-medium truncate mr-5">Product</a> 
                                        <div class="text-xs text-gray-500 ml-auto whitespace-no-wrap">KD 12.000</div>
                                    </div>
                                    <div class="w-full truncate text-gray-600">It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem </div>
                                </div>
                            </div>                --%>
                            <asp:HiddenField ID="PaidKD_HD" runat="server" />
                            
                            <asp:GridView ID="CartDV" runat="server" AutoGenerateColumns="false" ShowHeader="false" ShowFooter="True" class="table table-report " OnRowDataBound="CartDV_RowDataBound" OnRowDeleting="CartDV_RowDeleting"
                                DataKeyNames="CUST_NO,EFT_NUM,FC_AMT,LC_AMT">
                                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sno">
                        <ItemTemplate>
                            <%#Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="BNF_NAME" HeaderText="Name" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LC_AMT" HeaderText="KD" HeaderStyle-HorizontalAlign="Left" DataFormatString="{0:N3}">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
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
                                <FooterStyle BackColor="#FFFF99" Font-Bold="True" ForeColor="Red" />
                            </asp:GridView>                            
                            <asp:Button ID="CartCheckoutBtn" runat="server" Text="Checkout" CausesValidation="False" OnClick="CartCheckoutBtn_Click" UseSubmitBehavior="False" class=" w-26 shadow-md mr-1 mb-2 text-white next_btn_green" />                             
                                
                        </div>
                    </div>
                    
                </div>
				
                <!-- END: Notifications -->
                <!-- BEGIN: Account Menu -->
				<div class="intro-x dropdown relative ">
                    <div class="dropdown-toggle notification notification--light  cursor-pointer icon_bg tooltip" title="Settings">
                
                            <img alt="" src="images/settings.png">
                        </div>
                        <div class="dropdown-box mt-10 absolute w-56 top-0 right-0 z-20">
                            <div class="dropdown-box__content box bg-theme-38 text-white">                                
                                <div class="p-2">
                                    <a href="Profile" class="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 rounded-md"> <i data-feather="user" class="w-4 h-4 mr-2"></i> <span id="ProfileMaslbl" runat="server">Profile</span>  </a>
                                    <a href="Notifications" class="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 rounded-md"> <i data-feather="mail" class="w-4 h-4 mr-2"></i> <span id="MessageMaslbl" runat="server">Message</span> </a>
                                    <a href="Reset" class="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 rounded-md"> <i data-feather="lock" class="w-4 h-4 mr-2"></i> <span id="ResetpwdMaslbl" runat="server">Reset Password</span> </a>
                                    <%--<a href="Profile" class="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 rounded-md"> <i data-feather="settings" class="w-4 h-4 mr-2"></i> Settings </a>--%>
                                </div>
                                <div class="p-2 border-t border-theme-40">
                                    <a href="logout" class="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 rounded-md "> <i data-feather="toggle-right" class="w-4 h-4 mr-2"></i> <span id="LogoutMaslbl" runat="server">Logout</span> </a>
                                </div>
                            </div>
                        </div>
                </div>
                <!-- END: Account Menu -->
				
                     <div class="intro-x dropdown relative ml-3 sm:ml-3 " id="AraDiv" runat="server" visible="false">
                    <a href="" runat="server" onserverclick="ArbBtn_Click" causesvalidation="false"> <div class="dropdown-toggle notification notification--light cursor-pointer icon_bg tooltip" title="Arabic"> <img class="" src="images/ar.png"> </div></a>					
                    
                </div>
                      <div class="intro-x dropdown relative ml-3 sm:ml-3 " id="EngDiv" runat="server" visible="false">
                    <a href="" runat="server" onserverclick="EngBtn_Click" causesvalidation="false"> <div class="dropdown-toggle notification notification--light cursor-pointer icon_bg tooltip" title="English"> <img class="" src="images/en.png"> </div></a>					
                    
                </div>
                    
                    <div class="intro-x dropdown relative ml-3 sm:ml-3 ">
                    <div class="dropdown-toggle notification notification--light cursor-pointer icon_bg tooltip" title="Exit"><a href="logout"><img class="" src="images/arrow.png"></a> </div>
                    
                </div>

				
				</div>
				
				
            </div>
			
			<div class="mobile_user md:hidden">
			
			<div class="name text-center"> <a href="Profile" class="">
                <asp:Label ID="CXNamelbl1" runat="server" Text=""></asp:Label></a></div>
                <div class="log_time text-center">
                    <asp:Label ID="Lastloginlbl1" runat="server" Text=""></asp:Label></div>
				</div>
        </div>
        
        
       <div class="flex main">
            <!-- BEGIN: Side Menu -->
            <nav class="side-nav">
			
				<div class="name text-center"> <a href="Profile" class=""><asp:Label ID="CXNamelbl" runat="server" Text=""></asp:Label></a></div>
                <div class="log_time text-center"><asp:Label ID="Lastloginlbl" runat="server" Text=""></asp:Label></div>
				
				<div class="side-nav__devider my-6"></div>
                <ul>
                    <li>
                        <a href="Dashboard" class="side-menu" >
                            <div class="side-menu__icon"> <i data-feather="codepen"></i> </div>
                            <div class="side-menu__title"> <asp:Label ID="Dashboardlbl_D" runat="server" Text="Dashboard"></asp:Label> </div>
                        </a>
                    </li>
					
					<li>
                        <a href="Sendmoney" class="side-menu side-menu--active" >
                            <div class="side-menu__icon"> <i data-feather="refresh-cw"></i> </div>
                            <div class="side-menu__title"> <asp:Label ID="Remittancelbl_D" runat="server" Text="Remittance"></asp:Label> </div>
                        </a>
                    </li>
                    
                    <li>
                        <a href="Transactions" class="side-menu" >
                            <div class="side-menu__icon"> <i data-feather="credit-card"></i> </div>
                            <div class="side-menu__title"> <asp:Label ID="MyTranslbl_D" runat="server" Text="My Transactions"></asp:Label> </div>
                        </a>
                    </li>
                       <li>
                        <a href="Beneficiary" class="side-menu" id="benefadd_M" runat="server">
                            <div class="side-menu__icon"><i data-feather="user-plus"></i></div>
                            <div class="side-menu__title">
                                <asp:Label ID="BenefAddlbl_D" runat="server" Text="Add Beneficiary"></asp:Label>
                            </div>
                        </a>
                    </li>
                    <li>
                        <a href="Beneficiaries" class="side-menu" >
                            <div class="side-menu__icon"> <i data-feather="users"></i> </div>
                            <div class="side-menu__title"> <asp:Label ID="Beneflbl_D" runat="server" Text="Beneficiaries"></asp:Label> </div>
                        </a>
                    </li>
                    <li>
                        <a href="Exchange" class="side-menu" >
                            <div class="side-menu__icon"> <i data-feather="globe"></i> </div>
                            <div class="side-menu__title"> <asp:Label ID="ExchnRatelbl_D" runat="server" Text="Exchange Rate"></asp:Label> </div>
                        </a>
                    </li>
                      <li>
                    <a href="Branches" class="side-menu" id="branch_M" runat="server">
                        <div class="side-menu__icon"> <i data-feather="home"></i> </div>
                        <div class="side-menu__title"> <asp:Label ID="Brancheslbl_D" runat="server" Text="Branch Details "></asp:Label></div>
                    </a>
                </li>
				
				<li>
                    <a href="Promotions" class="side-menu" id="promo_M" runat="server">
                        <div class="side-menu__icon"> <i data-feather="layers"></i> </div>
                        <div class="side-menu__title"> <asp:Label ID="Promotionslbl_D" runat="server" Text="Promotions"></asp:Label> </div>
                    </a>
                </li>
				
				<li>
                    <a href="FAQ" class="side-menu" id="faq_M" runat="server">
                        <div class="side-menu__icon"> <i data-feather="list"></i> </div>
                        <div class="side-menu__title"> <asp:Label ID="FAQlbl_D" runat="server" Text="FAQs"></asp:Label> </div>
                    </a>
                </li>
				
				<li>
                    <a href="Contact" class="side-menu" id="contact_M" runat="server">
                        <div class="side-menu__icon"> <i data-feather="mail"></i> </div>
                        <div class="side-menu__title"> <asp:Label ID="Contactuslbl_D" runat="server" Text="Contact Us"></asp:Label> </div>
                    </a>
                </li>

                 
               
                    
                   
                   
                    
                    
                </ul>
            </nav>
            <!-- END: Side Menu -->
            <!-- BEGIN: Content -->
            <div class="content">
                <!-- BEGIN: Top Bar -->
                
                <!-- END: Top Bar -->
                
			
			
			<div class="col-span-12 mt-8 ">
			
			<h1 class="main_heading  truncate  text-center"> <asp:Label ID="Sendmoneylbl_M" runat="server" Text="Send  Money"></asp:Label></h1>
			  </div> 
			
			
						
						 
	<div class=" box sendmony">					 
  
 <div class="wizard">
            <div class="wizard-inner">
                <div class="connecting-line"></div>
                <ul class="nav nav-tabs" role="tablist">

                    <li role="presentation" class="active">
                        <a href="#step1" data-toggle="tab" aria-controls="step1" role="tab" class="tooltip" title="Step 1">
                            <span class="round-tab">
                               <i data-feather="align-center" class="w-8 h-8"></i>
                            </span>
                        </a>
                    </li>

                    <li role="presentation" class="disabled">
                        <a href="#step2" data-toggle="tab" aria-controls="step2" role="tab" class="tooltip"  title="Step 2">
                            <span class="round-tab">
                                <i data-feather="layers" class="w-8 h-8"></i>
                            </span>
                        </a>
                    </li>

                    <li role="presentation" class="disabled">
                        <a href="#step3" data-toggle="tab" aria-controls="step3" role="tab" class="tooltip"  title="Step 3">
                            <span class="round-tab">
                                 <i data-feather="credit-card" class="w-8 h-8"></i>
                            </span>
                        </a>
                    </li>
                </ul>
            </div>


           
                <div class="tab-content">
                    <div class="tab-pane active" role="tabpanel" id="step1">
                        <div class="signup_box row">
				
                             <div class="col-sm-12">	
                            <div class="mt-1 form_left"> <label id="beneficiarieslbl" runat="server">Choose Beneficiary*</label>
                                 
                                <asp:DropDownList ID="BenefListDDL" runat="server" class="select2 req " DataSourceID="BenefList_ODS" DataTextField="BEN_NAME" DataValueField="CUST_NO" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="BenefListDDL_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="BenefListDDL_ReqF" runat="server" Display="Dynamic" ErrorMessage="Beneficiary Required" SetFocusOnError="True" ControlToValidate="BenefListDDL" CssClass="Validate-Error" InitialValue="Select Beneficiary"></asp:RequiredFieldValidator>
                                
							 </div>
                                 </div>
                            <div class="clear"></div>	
							<%-- <div class="mt-1 form_right">
							 <label>.</label>							
                                 <asp:TextBox ID="TextBox1" runat="server" class="intro-x  input input--lg border border-gray-300 block " placeholder="" ReadOnly="true" BorderWidth="0"></asp:TextBox>
							</div>--%>
                         <div class="col-sm-12">	
							<div class="mt-1 form_left"> <label id="beneficiarynamelbl" runat="server">Beneficiary Name*</label>							
                                
                                <asp:TextBox ID="BenefNameTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" placeholder="" ReadOnly="true" ForeColor="Black"></asp:TextBox>
                                
							 </div>
                            
							 <div class="mt-1 form_right">
							 <label id="accountnolbl" runat="server">Account Number / IBAN*</label>		
                                 
                                 <asp:TextBox ID="AccountNoTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block cursor-not-allowed " placeholder="" ReadOnly="true" ForeColor="Black"></asp:TextBox>
                                 
							</div>
                                 </div>
							
                             <div class="col-sm-12">	
							<div class="mt-1 form_left"> <label id="banknamelbl" runat="server">Bank*</label>							
                                
                                <asp:TextBox ID="BankNameTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block cursor-not-allowed req" placeholder="" ReadOnly="true" ForeColor="Black"></asp:TextBox>
                                
							 </div>
                                
							 <div class="mt-1 form_right">
							 <label id="bankbranchlbl" runat="server">Branch*</label>
                                 
                                 <asp:TextBox ID="BankBranchTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" placeholder="" ReadOnly="true" ForeColor="Black"></asp:TextBox>							
                                 
							</div>
                                 </div>
							
                             <div class="col-sm-12">	
							<div class="mt-1 form_left"> <label id="benefmobilenolbl" runat="server">Beneficiary Mobile Number*</label>							
                                
                                <asp:TextBox ID="BenefMobileNoTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" placeholder="" ReadOnly="true" ForeColor="Black"></asp:TextBox>
                                
							 </div>
                               
							 <div class="mt-1 form_right">
							 <label id="currencylbl" runat="server">Currency*</label>	
                                 
                                 <asp:TextBox ID="CurrencyTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" placeholder="" ReadOnly="true" ForeColor="Black"></asp:TextBox>
                                 
							</div>
                                 </div>
							
                             <div class="col-sm-12">	
								<div class="mt-1 form_left"> <label id="KDlbl" runat="server">Kuwaiti Dinar*</label>		
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                                <%--<asp:TextBox ID="KuwaitiDinarsTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" placeholder="" onchange="CalculateTotal('SendKWD')" AutoPostBack="true" OnTextChanged="KuwaitiDinarsTxt_TextChanged" ForeColor="Black"></asp:TextBox>--%>
                                    <asp:TextBox ID="KuwaitiDinarsTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" placeholder="" AutoPostBack="true" OnTextChanged="KuwaitiDinarsTxt_TextChanged" ForeColor="Black" onfocus="this.value=''"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="KuwaitiDinarsTxt_FilteredTextBoxExtender" runat="server" BehaviorID="KuwaitiDinarsTxt_FilteredTextBoxExtender" TargetControlID="KuwaitiDinarsTxt" ValidChars="0,1,2,3,4,5,6,7,8,9,." />
                                <asp:RegularExpressionValidator ID="KuwaitiDinarsTxt_RegExp" runat="server" ErrorMessage="Invalid Amount" ValidationExpression="^(\d*\.?\d+|\d{1,3}(,\d{3})*(\.\d+)?)$" SetFocusOnError="True" Display="Dynamic" ControlToValidate="KuwaitiDinarsTxt" CssClass="Validate-Error"></asp:RegularExpressionValidator>
                                                     </ContentTemplate></asp:UpdatePanel>	 
							 </div>
                                
							 <div class="mt-1 form_right">
							 <label id="sendmoneyinnerlbl" runat="server">Send Money*</label>			
                                 <asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate>
                                 <%--<asp:TextBox ID="SendMoneyTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" placeholder="" onchange="CalculateTotal('SendMoney')"  AutoPostBack="true" OnTextChanged="SendMoneyTxt_TextChanged"  ForeColor="Black"></asp:TextBox>--%>
                                     <asp:TextBox ID="SendMoneyTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" placeholder="" AutoPostBack="true" OnTextChanged="SendMoneyTxt_TextChanged"  ForeColor="Black" onfocus="this.value=''"></asp:TextBox>
                                 <ajaxToolkit:FilteredTextBoxExtender ID="SendMoneyTxt_FilteredTextBoxExtender" runat="server" BehaviorID="SendMoneyTxt_FilteredTextBoxExtender" TargetControlID="SendMoneyTxt" ValidChars="0,1,2,3,4,5,6,7,8,9,." />
                                 <asp:RegularExpressionValidator ID="SendMoneyTxt_RegExp" runat="server" ErrorMessage="Invalid Amount" ValidationExpression="^(\d*\.?\d+|\d{1,3}(,\d{3})*(\.\d+)?)$" SetFocusOnError="True" Display="Dynamic" ControlToValidate="SendMoneyTxt" CssClass="Validate-Error"></asp:RegularExpressionValidator>
                                 </ContentTemplate></asp:UpdatePanel>
							</div>
                                 </div>
							
                             <div class="col-sm-12">	
                                 <div class="mt-1 form_left"> <label id="exchratelbl" runat="server">Exch Rate*</label>
							<%--<input type="text" class="intro-x  input input--lg border border-gray-300 block " placeholder="0.004123" disabled>--%>
                                
                                <asp:TextBox ID="ExchRateTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" placeholder="" ReadOnly="true" ForeColor="Black"></asp:TextBox>                                
							 </div>						
                                 
							 <div class="mt-1 form_right">
							 <label id="Commissionlbl" runat="server">Commission*</label>		
                                 <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                                 <asp:TextBox ID="CommissionKDTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block " placeholder="" ReadOnly="true" ForeColor="Black"></asp:TextBox>
                                 </ContentTemplate></asp:UpdatePanel>
							</div>
                                 </div>
							
                             <div class="col-sm-12">	
							<div class="mt-1 form_left"> <label id="Otherchargeslbl" runat="server">Other Charges*</label>	
                                
                                <asp:TextBox ID="OtherChargesTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block " placeholder="" ReadOnly="true" ForeColor="Black"></asp:TextBox>
                                
							 </div>
                                
							 <div class="mt-1 form_right">
							 <label id="totallbl" runat="server">Total*</label>		
                                 <asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate>
                                 <asp:TextBox ID="TotalKDTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block req" placeholder="" ReadOnly="true" ForeColor="Black"></asp:TextBox>
                                  </ContentTemplate></asp:UpdatePanel>
							</div>
                                 </div>
							
													
						
						
				<div class="clear"></div>	
				
				<div class="wizard-footer text-center">
							<button type="button" class="btn btn-previous btn-fill btn-default btn-wd" onclick="location.href='Dashboard'" id="CancelBtn" runat="server" >Cancel</button>
                           <button type="button" class="btn btn-next btn-fill btn-danger btn-wd next-step btn-ok" id="NextBtn" runat="server">Next</button>
                      
</div>

		                            	</div>
                        
                    </div>
                    <div class="tab-pane" role="tabpanel" id="step2">
                        <div class="signup_box row">						

                             <div class="clear"></div>
                             <div class="col-sm-12">	
							 <div class="mt-1 form_left">
							 <label id="Purposeoftranslbl" runat="server">Purpose of Transaction*</label>		
                                  
                                 <asp:DropDownList ID="TransPurposeDDL" runat="server" class="select2 req " DataSourceID="TransPurposeList_ODS" DataTextField="PP_DESC" DataValueField="PP_CODE" AppendDataBoundItems="true"></asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="TransPurposeDDL_ReqF" runat="server" ErrorMessage="Transfer Purpose Required" ControlToValidate="TransPurposeDDL" CssClass="Validate-Error" Display="Dynamic" InitialValue="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                  
							</div>	
                               
							<div class="mt-1 form_right"> <label id="Purposeoftransifanylbl" runat="server">Purpose of Transaction if other</label>	
                                
                                <asp:TextBox ID="TransOtherPurposeTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block " placeholder="" ForeColor="Black"></asp:TextBox>
                                
							 </div>
                                 </div>
                             
                             <div class="col-sm-12">	

                                 <div class="mt-1 form_left"> <label id="sourceofincomelbl" runat="server">Source of Income*</label>	
                                  
                                <asp:DropDownList ID="SourceIncomeDDL" runat="server" class="select2 req " DataSourceID="SourceOfIncome_ODS" DataTextField="DESC_E" DataValueField="LOOKUP_ID" AppendDataBoundItems="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="SourceIncomeDDL_ReqF" runat="server" Display="Dynamic" ControlToValidate="SourceIncomeDDL" CssClass="Validate-Error" ErrorMessage="Income Source Required" SetFocusOnError="True" InitialValue=""></asp:RequiredFieldValidator>
                                  
							 </div>							
                                 		
							 <div class="mt-1 form_right">
							 <label id="Benefmobilelbl" runat="server">Beneficiary Mobile</label>
                                  
                            <asp:TextBox ID="BenefMobileNoSendMTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block " placeholder="" MaxLength="15" ForeColor="Black"></asp:TextBox>	                                 
							     <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" BehaviorID="BenefMobileNoSendMTxt_FilteredTextBoxExtender" FilterType="Numbers" TargetControlID="BenefMobileNoSendMTxt">
                                 </ajaxToolkit:FilteredTextBoxExtender>                                 
                                  
							</div>	
                                 </div>

						
				<div class="clear"></div>	
                    <div class="wizard-footer text-center">
							<button type="button" class="btn btn-previous btn-fill btn-default btn-wd  prev-step " id="BackBtn" runat="server">Back</button>                            
                           <button type="button" class="btn btn-next btn-fill btn-danger btn-wd next-step btn-ok" id="NextBtn2" runat="server" causesvalidation="true">Next</button>    
                       
                        </div>				
						
            </div>
                        
                    </div>
					
                    <div class="tab-pane" role="tabpanel" id="step3">
                        <div class=" signup_box row">
						
						<div class="col-span-12 sm:col-span-4 xxl:col-span-3 box mb-5 p-5 cursor-pointer zoom-in" style="background:#F1F5F8;">
                                <div class="font-medium text-base ">
                                     
                                    <asp:Label ID="BenefDetailslbl" runat="server" Text=""></asp:Label>   
                                     

                                </div>
                            </div>
										 
									 
				
							
							  <div class="col-sm-12">	
							 <div class="mt-1 form_left relative  ">
							 <label id="Youpaylbl" runat="server">You Send</label>          
                                  <asp:UpdatePanel ID="UpdatePanel7" runat="server"><ContentTemplate>
                                 <asp:TextBox ID="YouPayKDReviewTxt" runat="server" class="input pr-12 w-full border border-gray-300 col-span-4" placeholder="" ReadOnly="true" ForeColor="Black"></asp:TextBox>
                                  </ContentTemplate></asp:UpdatePanel>
                                        <div class="absolute right-0 rounded-r w-10  flex items-center justify-center   text-gray-600 gray right_10">KWD</div>

							 </div>
                                
							 <div class="mt-1 form_right relative  ">
							 <label id="Benefreceivedlbl" runat="server">Beneficiary Received</label>    
                                   <asp:UpdatePanel ID="UpdatePanel8" runat="server"><ContentTemplate>
                                 <asp:TextBox ID="BenefReceiveReviewTxt" runat="server" class="input pr-12 w-full border border-gray-300 col-span-4" placeholder="" ReadOnly="true" ForeColor="Black"></asp:TextBox>
                                       </ContentTemplate></asp:UpdatePanel>
                                        <div class="absolute right-0 rounded-r w-10  flex items-center justify-center   text-gray-600 gray right_10">
                                            <asp:Label ID="BenefCurrlbl" runat="server" Text=""></asp:Label>
                                  
                                        </div>
										
							 </div>
                                 </div>
							 
                             <div class="col-sm-12">	
							 <div class="mt-1 form_left relative  ">
							 <label id="exchrate2lbl" runat="server">Exch Rate</label>    
                                   
                                 <asp:TextBox ID="ExchRateReviewTxt" runat="server" class="intro-x  input input--lg border border-gray-300 block " placeholder="" ReadOnly="true" ForeColor="Black"></asp:TextBox>
                                   
							 </div>
                                
							 <div class="mt-1 form_right relative  ">
							 <label id="commission2lbl" runat="server">Transfer Fee/Commission</label>      
                                 <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>
                                 <asp:TextBox ID="CommissionReviewTxt" runat="server" class="input pr-12 w-full border border-gray-300 col-span-4" placeholder=" " ReadOnly="true" ForeColor="Black"></asp:TextBox>
                                 </ContentTemplate></asp:UpdatePanel>
                                        <div class="absolute right-0 rounded-r w-10  flex items-center justify-center   text-gray-600 gray right_10">KWD</div>
										
							 </div>
                                 </div>
							 
                             <div class="col-sm-12">	
							  <div class="mt-1 form_left relative  ">
							 <label id="Otherchargeprevlbl" runat="server">Other Charges</label>         
                                  
                                  <asp:TextBox ID="OtherChargeReviewtxt" runat="server" class="input pr-12 w-full border border-gray-300 col-span-4" placeholder="" ReadOnly="true" ForeColor="Black"></asp:TextBox>
                                  
                                        <div class="absolute right-0 rounded-r w-10  flex items-center justify-center   text-gray-600 gray right_10">KWD</div>

							 </div>
                                
							 <div class="mt-1 form_right relative  ">
							 <label id="Totalpaylbl" runat="server">Total Pay</label>             
                                 <asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate>
                                 <asp:TextBox ID="TotalPayReviewTxt" runat="server" class="input pr-12 w-full border border-gray-300 col-span-4" placeholder="" ReadOnly="true" ForeColor="Black"></asp:TextBox>
                                  </ContentTemplate></asp:UpdatePanel>
                                        <div class="absolute right-0 rounded-r w-10  flex items-center justify-center   text-gray-600 gray right_10">KWD</div>
										
							 </div>
                                 </div>
							
							<div class="clear"></div>                                                     
                           
                            <div class="col-sm-12 check"> 					
                                <label> <input type="checkbox" class="input border mt-1" id="ConfirmCHK" runat="server">
                                <label id="Agreelbl" runat="server" for="ConfirmCHK">I Accept & Agree your Terms & Conditions</label> &nbsp;&nbsp;&nbsp; <a href="javascript:;" data-toggle="modal" data-target="#terms_conditions" runat="server" id="ReadtncAnchor" > Read Terms & Conditions </a> </label>
                                <asp:CustomValidator ID="ConfirmCHK_ReqF" runat="server" ErrorMessage="Terms & Conditions Confirmation Required" CssClass="Validate-Error" ClientValidationFunction = "ValidateCheckBox"></asp:CustomValidator>
                             </div>                  			                          

                            	<div class="col-sm-12 mb-3">							
							 <label id="Chargesatreceiverlbl" runat="server">*The charges at the Receiver's end are not included here if any.</label> 
                            <div class="clear"></div>
							 </div>
						
						
				<div class="clear"></div>	

				<div class="wizard-footer text-center">
                    
							<button type="button" class="btn btn-previous btn-fill btn-default btn-wd prev-step" id="BackBtn2" runat="server" >Back</button>		                    				                       
						  <button type="button" class="btn btn-finish btn-fill btn-danger btn-wd" id="AddToCartBtn" runat="server" causesvalidation="true"  onserverclick="AddToCartBtn_Click">Add to Cart</button>                                           

                        <button type="button" class="btn btn-finish btn-fill btn-danger btn-wd" id="PayNowBtn" runat="server" causesvalidation="true" onserverclick="PayNowBtn_Click"> Pay Now</button>
                        
                    
                    <asp:HiddenField ID="CurrID_HD" runat="server" />
                    <asp:HiddenField ID="CurrRate_HD" runat="server" />
                    <asp:HiddenField ID="FC_ToKWD_HD" runat="server" />
                    <asp:HiddenField ID="PayBankID_HD" runat="server" />                        
                    <asp:HiddenField ID="Benef_Rel_HD" runat="server" />   
                    <asp:HiddenField ID="CUST_TEL_HD" runat="server" />   
                                         

                    
</div>
						
            </div>
                    </div>
                    
                    <div class="clearfix"></div>
                </div>
           
        </div>
 </div>						
							
							
							
							</div>	
                <!-- END: Pricing Tab -->
                <!-- BEGIN: Pricing Content -->
                
                <!-- END: Pricing Content -->


			
                           
                        </div>
		</div>
		
		
		<div class="footer">
		<ul>
			<li>
                       <a href="https://www.facebook.com/KBEKuwait/" target="_blank"> <i data-feather="facebook" class="mx-auto"></i> 
                        <div class="text-center text-xs mt-1">facebook</div></a>
                    </li>
					
					<li>
                        <a href="https://twitter.com/KBEkw" target="_blank"> <i data-feather="twitter" class="mx-auto"></i> 
                        <div class="text-center text-xs mt-1">twitter</div></a>
                    </li>
		</ul>
		</div>
		
		
		<div class="modal" id="large-modal-size-preview">
            <div class="modal__content modal__content--lg  ">
                <div class="modal-header text-center">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">IDENTITY VERIFICATION</h4>
                </div>

                <div class="modal-body p-5">
                    <div class="relative mt-2 col-span-12 lg:col-span-12">
                        <label id="SecQuestionlbl" runat="server"></label>
                       <%-- <input type="text" class="input pr-12 w-full border col-span-4" placeholder="" id="SecQuestionAnswerTxt" runat="server" />--%>
                        <asp:TextBox ID="SecQuestionAnswerTxt" runat="server" class="input pr-12 w-full border col-span-4" placeholder=""></asp:TextBox>


                        <%--  <div class="relative mt-2 col-span-12 lg:col-span-12 text-right">
	 Forgot Security Answer  <a href="#" class="button w-24 rounded-full mr-1 mb-2 bg-theme-1 text-white">Send OTP</a>                               
      </div>--%>
                    </div>
                </div>

                <div class="modal-footer">
                    <div class="col-span-12 lg:col-span-12 mt-5 mb-5 text-center">
                        <%--<a href="#" class=" w-24 shadow-md mr-1 mb-2  text-white next_btn">Cancel</a>
			<a href="#" class=" w-24 shadow-md mr-1 mb-2  text-white next_btn">Next</a>--%>
                        <%--<asp:Button ID="SecCancelBtn" runat="server" Text="Cancel" class=" w-30 shadow-md mr-1 mb-2  text-white next_btn" />--%>
                        <%--<asp:Button ID="SecValidateBtn" runat="server" Text="Validate" class=" w-30 shadow-md mr-1 mb-2  text-white next_btn" OnClick="SecValidateBtn_Click"/>--%>
                        <input type="button" value="Validate" name="SecValidateBtn" runat="server" class=" w-30 shadow-md mr-1 mb-2  text-white next_btn" onclick="ValidateSecurity();"  />                        

                    </div>
                    <div style="clear: both"></div>
                </div>


            </div>
            <div style="clear: both"></div>

        </div>
		
		
 <asp:HiddenField ID="SecValidatedSts_HD" runat="server" />

          

              <!--Success--->
        <div class="modal" id="successmsg">
            <div class="modal__content">
                <div class="p-5 text-center ">
                    <i data-feather="check-circle" class="w-16 h-16 text-theme-9 mx-auto mt-3"></i>
                    <div class="text-3xl mt-2">Success!</div>
                    <div class="text-gray-600 mt-1 mb-2">
                        <asp:Label ID="SuccessMsglbl" runat="server" Text=""></asp:Label></div>
                </div>
                <!--<div class="px-5 pb-8 text-center"> <button type="button" data-dismiss="modal" class="button w-24 bg-theme-1 text-white">Ok</button> </div>-->
            </div>
        </div>
        <!--Success--->


        <!--Error--->

        <div class="modal" id="errormsg">
            <div class="modal__content">
                <div class="p-5 text-center ">
                    <i data-feather="alert-triangle" class="w-16 h-16 text-theme-6 mx-auto mt-3"></i>
                    <div class="text-3xl mt-2">Error</div>
                    <div class="text-gray-600 mt-1 mb-2">
                        <asp:Label ID="ErrorMsglbl" runat="server" Text=""></asp:Label></div>
                </div>
                <!-- <div class="px-5 pb-8 text-center">  <button type="button" class="button w-24 bg-theme-6 text-white">Ok</button> </div>-->
            </div>
        </div>
        <!--Error--->


             <!------12-11-2020 Star------->
	<div class="modal" id="terms_conditions">
     <div class="modal__content">
         <div class="flex items-center px-5 py-5 sm:py-3 border-b border-gray-200 dark:border-dark-5">
             <h2 class="font-medium text-base mr-auto"> <asp:Label ID="TnClbl" runat="server" Text="Terms & Conditions"></asp:Label></h2> 
            <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="background: #d7dce1;"><span aria-hidden="true" ><i data-feather="x" class="w-8 h-8 " style="color: #000;"></i></span></button>
         </div>
         <div class="p-5 ">
             
             <asp:Label ID="TnCPara" runat="server" Text=""></asp:Label>        
            <%--<h3>Lorem Ipsum is simply dummy text of the printing and typesetting</h3> 
			<p> Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. </p>					
		 --%>
		 </div>
         
     </div>
 </div>
 <!------12-11-2020 end------->
             
		<%-- <script src="js/jquery-2.2.4.min.js" type="text/javascript"></script>	
                         <script src="js/material-bootstrap-wizard.js"></script>--%>

            <script type="text/javascript">       
       
                function SuccessMsg(suc_msg) {
                    $("#SuccessMsglbl").html(suc_msg);
                $("#successmsg").modal('show');                
            }
                function ErrorMsg(err_msg) {
                    $("#ErrorMsglbl").html(err_msg);
                $("#errormsg").modal('show');
                }              
       
    </script>

          
            
           
       </form> 

        
      
         

        <!-- BEGIN: JS Assets-->
        <script src="https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/markerclusterer.js"></script>
        <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBG7gNHAhDzgYmq4-EHvM4bqW1DNj2UCuk&libraries=places"></script>
        <script src="js/app_DDLSearch.js"></script>
		<script src="js/jquery-2.2.4.min.js" type="text/javascript"></script>

           <%--Newly Added - Test--%>
          <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/js/select2.full.js" type="text/javascript"></script>
    <script type="text/javascript">
        function matchStart (term, text) {
        if (text.toUpperCase().indexOf(term.toUpperCase()) == 0) {
                return true;
            } 
        return false;
            }
 
        $.fn.select2.amd.require(['select2/compat/matcher'], function (oldMatcher) {
        $("select").select2({
            matcher: oldMatcher(matchStart)
            })
          });
        </script>
        <%--Newly Added - Test--%>

	<script src="js/bootstrap.min.js" type="text/javascript"></script>
	<script src="js/jquery.bootstrap.js" type="text/javascript"></script>

	<!--  Plugin for the Wizard -->
	<script src="js/material-bootstrap-wizard.js"></script>

	<!--  More information about jquery.validate here: http://jqueryvalidation.org/	 -->
	<script src="js/jquery.validate.min.js"></script>
        <!-- END: JS Assets-->
              

	<script>	
		$(document).ready(function () {
    //Initialize tooltips
    $('.nav-tabs > li a[title]').tooltip();
    
    //Wizard
    $('a[data-toggle="tab"]').on('show.bs.tab', function (e) {

        var $target = $(e.target);
    
        if ($target.parent().hasClass('disabled')) {
            return false;
        }
    });

    $(".next-step").click(function (e) {

        var $active = $('.wizard .nav-tabs li.active');
        $active.next().removeClass('disabled');
        nextTab($active);

    });
    $(".prev-step").click(function (e) {

        var $active = $('.wizard .nav-tabs li.active');
        prevTab($active);

    });  


});

function nextTab(elem) {
    $(elem).next().find('a[data-toggle="tab"]').click();
}
function prevTab(elem) {
    $(elem).prev().find('a[data-toggle="tab"]').click();
}
	</script>	

        
        <%--<script type="text/javascript">
            var InputType;
            function CalculateTotal(InputType)
            {
                var FinalTotal = 0;
                var ExchgRate = 0, SendMoneyAmt = 0, SendKwdAmt = 0, TotalKDAmt = 0, CommissionAmt = 0, OtherChargesAmt = 0;
                ExchgRate = parseFloat(document.getElementById('ExchRateTxt').value) || 0;

                if (InputType == 'SendMoney') {
                    SendMoneyAmt = parseFloat(document.getElementById('SendMoneyTxt').value) || 0;
                    SendKwdAmt = 0;                    
                }
                else if (InputType == 'SendKWD') {
                    SendKwdAmt = parseFloat(document.getElementById('KuwaitiDinarsTxt').value) || 0;
                    SendMoneyAmt = 0;                    
                }
               

                CommissionAmt = parseFloat(document.getElementById('CommissionKDTxt').value) || 0;

                OtherChargesAmt = parseFloat(document.getElementById('OtherChargesTxt').value) || 0;

                if (SendMoneyAmt > 0) {
                    //SendKwdAmt = SendMoneyAmt * ExchgRate;
                    var CalculateKD = SendMoneyAmt * ExchgRate;
                    var KDDec;
                    var DeciStr = (String(Number(CalculateKD).toFixed(3)) + "").split(".");

                    var LastVal = DeciStr[1].substring(3, 2); 
                    var LastBeforeVal = DeciStr[1].substring(0, 2);

                    if (Number(LastVal) < 3)
                        KDDec = String(LastBeforeVal) + '0'
                    else if (Number(LastVal) >= 3 && Number(LastVal) <=8)
                        KDDec = String(LastBeforeVal) + '5'
                    else if (Number(LastVal) >= 9)
                        KDDec = Number(KDDec + 1)                                           

                    //alert('Rounded Value::: ' + KDDec);
                    //alert('KDDEc Value '+KDDec+ '  :::LastBeforeVal: ' + LastBeforeVal + '  ====LAst Vale:' + String(LastVal))
                    SendKwdAmt = Number(DeciStr[0] + '.' + KDDec);

                    document.getElementById("KuwaitiDinarsTxt").value = Number(SendKwdAmt).toFixed(3);                    
                }
                else if (SendKwdAmt > 0) {
                    SendMoneyAmt = SendKwdAmt / ExchgRate;                    
                    document.getElementById("SendMoneyTxt").value = Number(SendMoneyAmt).toFixed(0);                    
                }
                TotalKDAmt = SendKwdAmt + CommissionAmt + OtherChargesAmt;


                var SendMoneyAmt_C, SendKwdAmt_C, TotalKDAmt_C;
                SendMoneyAmt_C = numberWithCommas(Number(SendMoneyAmt).toFixed(0));
                SendKwdAmt_C = numberWithCommas(Number(SendKwdAmt).toFixed(3));
                TotalKDAmt_C = numberWithCommas(Number(TotalKDAmt).toFixed(3));

                ////FinalTotal = (Math.round(TotalKDAmt * 100) / 100).toFixed(3);
                //document.getElementById("BenefReceiveReviewTxt").value = Number(SendMoneyAmt).toFixed(0);
                //document.getElementById("YouPayKDReviewTxt").value = Number(SendKwdAmt).toFixed(3);

                //document.getElementById("TotalKDTxt").value = Number(TotalKDAmt).toFixed(3);
                //document.getElementById("TotalPayReviewTxt").value = Number(TotalKDAmt).toFixed(3);                

                document.getElementById("BenefReceiveReviewTxt").value = SendMoneyAmt_C;
                document.getElementById("YouPayKDReviewTxt").value = SendKwdAmt_C;

                document.getElementById("TotalKDTxt").value = TotalKDAmt_C;
                document.getElementById("TotalPayReviewTxt").value = TotalKDAmt_C;

                document.getElementById("KuwaitiDinarsTxt").value = SendKwdAmt_C;
                document.getElementById("SendMoneyTxt").value = SendMoneyAmt_C;

                ////Number(1.3450001).toFixed(2);
            }
            function numberWithCommas(x) {
                return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
            }
            
        </script>		--%>
        
          <script type="text/javascript">
//        $(document).ready(function () {
//    $('.dropdown-box__content a').click(function(event) {
//        var option = $(event.target).text();
//        $(event.target).parents('.language').find('.button').html(option);
//    });
//});
$('[data-toggle=tab]').click(function () {
  return false;}
).addClass("text-muted");

var validated = function(tab1){

  tab1.unbind('click').removeClass('text-muted');
 tab1.tab('show');
}

//validate inputs on click of button
$('.btn-ok').click(function(){
  
    var allValid = true;
	count=0;
	count1=0;
    // get each input in this tab pane and validate
    $(this).parents('.tab-pane').find('.req').each(function(i,e){
         
        // some condition(s) to validate each input
        var len = $(e).val().length;
        if (len>0){
		
            // validation passed
            allValid = true;
			count++;
        } else {
            // validation failed
            allValid = false;
            count1++;

			Page_ClientValidate("");
        }
       
    });
 
    if (count1==0) {
	
        var tabIndex = $(this).parents('.tab-pane').index();
		id=$(this).parents('.tab-pane').attr('id');
        validated($('[data-toggle=tab]').eq(tabIndex+1));	
		
		
    }
    
});

// always validate first tab
validated($('[data-toggle]').eq(0));
    
        </script> 


         <!----08-10-20 strat---->	
		<script>
			const loaderEl = document.getElementsByClassName('fullpage-loader')[0];
document.addEventListener('readystatechange', (event) => {
	// const readyState = "interactive";
	const readyState = "complete";
    
	if(document.readyState == readyState) {
		// when document ready add lass to fadeout loader
		loaderEl.classList.add('fullpage-loader--invisible');
		
		// when loader is invisible remove it from the DOM
		setTimeout(()=>{
			loaderEl.parentNode.removeChild(loaderEl);
		}, 2000)
	}
});

	</script>
	
	<!----08-10-20 end---->
        <script>
             function ValidateCheckBox(sender, args) {
     if (document.getElementById("<%=ConfirmCHK.ClientID %>").checked == true) {         
                args.IsValid = true;
     } else {
         args.IsValid = false;
            }
 }
        </script>

        <%--  <!--Success--->
 <div class="modal" id="successmsg">
     <div class="modal__content">
         <div class="p-5 text-center "> <i data-feather="check-circle" class="w-16 h-16 text-theme-9 mx-auto mt-3"></i>
             <div class="text-3xl mt-2">Success!</div>
             <div class="text-gray-600 mt-1 mb-2"> <asp:Label ID="SuccessMsglbl" runat="server" Text=""></asp:Label></div>
         </div>
         <!--<div class="px-5 pb-8 text-center"> <button type="button" data-dismiss="modal" class="button w-24 bg-theme-1 text-white">Ok</button> </div>-->
     </div>
 </div>
 <!--Success--->
 
 
 <!--Error--->

 <div class="modal" id="errormsg">
     <div class="modal__content">
         <div class="p-5 text-center "> <i data-feather="alert-triangle" class="w-16 h-16 text-theme-6 mx-auto mt-3"></i>
             <div class="text-3xl mt-2">Error</div>
             <div class="text-gray-600 mt-1 mb-2"><asp:Label ID="ErrorMsglbl" runat="server" Text=""></asp:Label></div>
         </div>
        <!-- <div class="px-5 pb-8 text-center">  <button type="button" class="button w-24 bg-theme-6 text-white">Ok</button> </div>-->
     </div>
 </div>
<!--Error--->		--%>
		 
           <%-- <script type="text/javascript">       
       
                function SuccessMsg(suc_msg) {
                    $("#SuccessMsglbl").html(suc_msg);
                $("#successmsg").modal('show');                
            }
                function ErrorMsg(err_msg) {
                    $("#ErrorMsglbl").html(err_msg);
                $("#errormsg").modal('show');
                }              
       
    </script>--%>

         <%-- <script type="text/javascript">
                 function ShowSecQuestion() {
                     $("#large-modal-size-preview").modal('show');
                 }
             </script>

            <script type="text/javascript">
                function ValidateSecurity()
                {                  

                   var SecAnswerTxt = document.getElementById('SecQuestionAnswerTxt').value;
                    var APISecAnswer = '<%= Session["SecQuestionAnswer2Validate_S"] %>';                                      

                    if(SecAnswerTxt=='')
                        ErrorMsg("Security Answer Required")
                    else if (SecAnswerTxt == APISecAnswer && SecAnswerTxt != '' && APISecAnswer!='') {
                        $("#large-modal-size-preview").modal('hide');
                        document.getElementById('SecValidatedSts_HD').value = 'Validated';
                        __doPostBack();                        
                    }
                    else
                        ErrorMsg("Incorrect Security Answer")
                }
          
        </script>--%>

                 

         <asp:ObjectDataSource ID="BenefList_ODS" runat="server" SelectMethod="BeneficiaryList_Appr" TypeName="KBE.RESTFull.RESTClass">
              <SelectParameters>
            <asp:Parameter Name="LoginIDStr" Type="String" DefaultValue="0" />
        </SelectParameters>
         </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="TransPurposeList_ODS" runat="server" SelectMethod="TransactionPurposeList" TypeName="KBE.RESTFull.RESTClass">
           <SelectParameters>
            <asp:Parameter Name="BankIDStr" Type="String" DefaultValue="0" />
        </SelectParameters>
    </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="SourceOfIncome_ODS" runat="server" SelectMethod="SourceOfIncomeList" TypeName="KBE.RESTFull.RESTClass"></asp:ObjectDataSource>

             

    </body>
</html>