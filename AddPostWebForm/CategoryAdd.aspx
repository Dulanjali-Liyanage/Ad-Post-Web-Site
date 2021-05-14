<%@ Page Title="CategoryAdd" Language="C#" MasterPageFile="~/SiteHeader.Master" AutoEventWireup="true" CodeBehind="CategoryAdd.aspx.cs" Inherits="AddPostWebForm.CategoryAdd" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        
            <div class="row">

                <div class="logincolumn vr" style="background-color: white; padding-left: 50px; padding-right: 50px; align-content:center">
                    <div style="margin-left: auto; margin-right: auto; text-align: center; padding-top: 50px">
                        <asp:Label runat="server" Font-Bold="true" Font-Size="Large" Text=" All Categories"></asp:Label>
                    </div>
                    <hr />

                <asp:Repeater ID="CategoryRepeat" runat="server">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="false">
                            <i class="glyphicon glyphicon-tag"></i>
                        </asp:LinkButton>
                        &nbsp;&nbsp;
                        <asp:LinkButton ID="Category" runat="server"><%# Eval("CategoryName") %></asp:LinkButton>
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
                </div>

                <div class="loginpicture">
                    
                    <div style="padding-top:50px; padding-left:50px;padding-right:50px">
                        <div style="text-align:center">
                            <asp:Label ID="lblCategory" runat="server" Text="Add a new category" Font-Bold="true" Font-Size="Larger"></asp:Label>
                        </div>
                        <hr />
                        <br />
                        <asp:TextBox ID="txtCategory" runat="server" Width="100%" CssClass="posttextbox"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="btnAddCategory" runat="server" Text="Add Category" OnClick="btnAddCategory_Click" CssClass="btn btn-primary" />
                        <br />
                    </div>
                </div>

            </div>
        
        

    </form>
</asp:Content>
