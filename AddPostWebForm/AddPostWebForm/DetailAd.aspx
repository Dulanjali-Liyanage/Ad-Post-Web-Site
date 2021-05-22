<%@ Page Title="More Details" Language="C#" MasterPageFile="~/SiteHeader.Master" AutoEventWireup="true" CodeBehind="DetailAd.aspx.cs" Inherits="AddPostWebForm.DetailAd" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <br />
            <br />
            <div style="text-align:center">
                <asp:Label ID="txtTitle" runat="server" Text="" Font-Bold="true" Font-Size="X-Large"></asp:Label>
            </div>
            <br />
            <br />

            <img class="mx-auto d-block" src='/images/<%= imageName %>'/>   
            <br />
            <br />
            <%--<asp:Label ID="lblTtitle" runat="server" Text="Title : "></asp:Label>--%>
            
            <asp:Label ID="lblCondition" runat="server" Text="Condition : " Font-Bold="true"></asp:Label><br />
            <asp:Label ID="txtCondition" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblDescription" runat="server" Text="Description : " Font-Bold="true"></asp:Label><br />
            <asp:Label ID="txtDescription" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblPrice" runat="server" Text="Price : " Font-Bold="true"></asp:Label><br />
            <asp:Label ID="txtPrice" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <hr />
            <asp:Label ID="lblContact" runat="server" Text="Contact Details" Font-Bold="true" Font-Size="Large" ForeColor="#333333"></asp:Label>
            <hr />
            <asp:Label ID="lblUserName" runat="server" Text="Name : " Font-Bold="true"></asp:Label>
            <asp:Label ID="txtName" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblEmail" runat="server"><i class="glyphicon glyphicon-envelope"></i></asp:Label>&nbsp;
            <asp:Label ID="txtEmail" runat="server" Text=""></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblPhoneNumber" runat="server"><i class="glyphicon glyphicon-earphone"></i></asp:Label>&nbsp;
            <asp:Label ID="txtPhoneNumber" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </form>
</asp:Content>
