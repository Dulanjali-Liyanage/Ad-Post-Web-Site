<%@ Page Title="Edit Details" Language="C#" MasterPageFile="~/SiteHeader.Master" AutoEventWireup="true" CodeBehind="EditMyAd.aspx.cs" Inherits="AddPostWebForm.EditMyAd" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
            <div class="addForm-card">
                    
                    <div class="inside-card" style="width: 18rem;">
                        <form id="form1" runat="server">

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
                            <img class="mx-auto d-block" src='/images/<%= imageName %>' height="100" width="100"/>   
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="addkey_btn"/><br />
                            <br />
                            <br />
                            
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn btn-primary"/>
                            <br />
                            <br />
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

                        </form>
                    </div>
            </div>
        </div>
</asp:Content>
