<%@ Page Title="Login" Language="C#" MasterPageFile="~/SiteHeader.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AddPostWebForm.Login" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <form id="form1" runat="server">
        
            <div class="row">
                <div class="logincolumn" style="background-color: white; padding-left: 50px; padding-right: 50px; align-content:center">
                         <div style="margin-left: auto; margin-right: auto; text-align: center; padding-top: 50px">
                            <asp:Label runat="server" Font-Bold="true" Font-Size="Large" Text="Sign In"></asp:Label>
                         </div>
                         <hr />
                         <asp:PlaceHolder runat="server" ID="LoginStatus" Visible="false">
                            <p>
                               <span style="color:red"><asp:Literal runat="server" ID="StatusText" /></span>
                            </p>
                         </asp:PlaceHolder>
                         <asp:PlaceHolder runat="server" ID="LoginForm" Visible="false">
                            <div style="margin-bottom: 30px">
                               <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
                               <div>
                                  <asp:TextBox runat="server" ID="UserName" CssClass="login-textbox"/>
                               </div>
                            </div>
                            <div style="margin-bottom: 50px">
                               <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                               <div>
                                  <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="login-textbox" />
                               </div>
                            </div>
                            <div style="margin-bottom: 20px">
                               <div>
                                  <asp:Button runat="server" OnClick="SignIn" Text="Log in"  CssClass="loginbutton"/>
                               </div>
                            </div>

                             <div style="text-align:center; margin-bottom: 185px">
                                 <asp:LinkButton ID="NewMember" runat="server" OnClick="NewMember_click">Create a new account</asp:LinkButton>
                             </div>

                         </asp:PlaceHolder>
                </div>


                <div class="loginpicture">
                    <div style="background-image: url(/images/blog-post3-1-1100x600.jpg); opacity:0.5; position:fixed; width:100%; height:100vh; background-size:auto; background-repeat:no-repeat;">
                    </div>
                </div>
            
        </div>        
    </form>
    


</asp:Content>
    


