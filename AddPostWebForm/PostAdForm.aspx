<%@ Page  Title="Post Your Ad" Language="C#" MasterPageFile="~/SiteHeader.Master" AutoEventWireup="true" CodeBehind="PostAdForm.aspx.cs" Inherits="AddPostWebForm.PostAdForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container">
        <div class="row">
            <div class="addForm-card">
                <div class="row">
                    <form id="form1" runat="server">
                    <div class="inside-card" style="width: 18rem;align-content:center">
                        
                        <div class="col d-flex justify-content-center">
        
                            <br />
                            <asp:Label ID="lblCategorySelect" runat="server" Text="Select your category" Font-Bold="true"></asp:Label><br />
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="CategoryName" DataValueField="CategoryID" CssClass="posttextbox" Height="62px" Width="1081px">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Categories]"></asp:SqlDataSource>
                            <br />
                            <br />
        
                            <asp:Label ID="lblCondition" runat="server" Text="Condition" Font-Bold="true"></asp:Label><br />
                            <asp:RadioButton ID="rdbUsed" GroupName="Condition" runat="server" />&nbsp;Used
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rdbNew" GroupName="Condition" runat="server" />&nbsp;New
                            <br />
                            <br />
                            
                            <asp:Label ID="lblAdTitle" runat="server" Text="Title" Font-Bold="true"></asp:Label><br />
                            <asp:TextBox ID="txtAdTitle" runat="server" CssClass="posttextbox" Height="32px" Width="1055px"></asp:TextBox><br />
                            <br />
                            <br />
                            
                            <asp:Label ID="lblAdDescription" runat="server" Text="Description" Font-Bold="true"></asp:Label><br />
                            <asp:TextBox ID="txtAdDescription" runat="server" TextMode="MultiLine" CssClass="descriptiontextbox" Height="166px" Width="1040px"></asp:TextBox><br />
                            <br />
                            <br />
                            
                            <asp:Label ID="lblAdPrice" runat="server" Text="Price(Rs)" Font-Bold="true"></asp:Label><br />
                            <asp:TextBox ID="txtAdPrice" runat="server" CssClass="posttextbox" Height="40px" Width="1058px"></asp:TextBox><br />
                            <br />
                            <br />
                            
                            <asp:Label ID="lblUploadImage" runat="server" Text="Upload a photo" Font-Bold="true"></asp:Label><br />
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="addkey_btn"/><br />
                            
                            <br />
                            <br />
                            
                            <asp:Button ID="btnPostAd" runat="server" Text="Post Ad" OnClick="btnPostAd_Click" CssClass="btn btn-primary" />
                            <br />
                            <br />

                        </div>
                   </div>
                        </form>
                </div>
            </div>
        </div>
    </div>    
        
</asp:Content>
