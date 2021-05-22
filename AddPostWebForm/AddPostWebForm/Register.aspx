<%@ Page Title="Register" Language="C#" MasterPageFile="~/SiteHeader.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AddPostWebForm.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        
            <div class="row">
                <div class="logincolumn" style="background-color: white; padding-left: 50px; padding-right: 50px; align-content:center">
                         <div style="margin-left: auto; margin-right: auto; text-align: center; padding-top: 50px">
                            <asp:Label runat="server" Font-Bold="true" Font-Size="Large" Text="Register a new user"></asp:Label>
                         </div>
                         <hr />
                         <p>
                            <span style="color:red"><asp:Literal runat="server" ID="StatusMessage" /></span>
                         </p>
                         
                            <div style="margin-bottom: 15px">
                               <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
                               <div>
                                  <asp:TextBox runat="server" ID="UserName" CssClass="login-textbox"/>
                               </div>
                            </div>
                            <div style="margin-bottom: 15px">
                               <asp:Label runat="server" AssociatedControlID="Email">Email</asp:Label>
                               <div>
                                  <asp:TextBox runat="server" ID="Email" CssClass="login-textbox"/>
                               </div>
                            </div>
                            <div style="margin-bottom: 15px">
                               <asp:Label runat="server" AssociatedControlID="PhoneNumber">Contact number</asp:Label>
                               <div>
                                  <asp:TextBox runat="server" ID="PhoneNumber" CssClass="login-textbox"/>
                               </div>
                            </div>
                            <div style="margin-bottom: 15px">
                               <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                               <div>
                                  <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="login-textbox" />
                               </div>
                            </div>
                            <div style="margin-bottom:15px">
                                <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
                                <div>
                                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="login-textbox" />                
                                </div>
                            </div>
                            <div style="margin-bottom:10px">
                                <div>
                                    <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="loginbutton" />
                                </div>
                            </div>

                             <div style="text-align:center;margin-bottom:6px">
                                 <asp:Label runat="server" Text="Already a member?"></asp:Label>
                                 <asp:LinkButton ID="Member" runat="server" OnClick="Member_click">Log in</asp:LinkButton>
                             </div>

                         
                </div>


                <div class="loginpicture">
                    <div style="background-image: url(/images/blog-post3-1-1100x600.jpg); opacity:0.5; position:fixed; width:100%; height:100vh; background-size:auto; background-repeat:no-repeat;">
                    </div>
                </div>
            </div>
        
    </form>
</asp:Content>

