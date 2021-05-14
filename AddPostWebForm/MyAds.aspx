<%@ Page Title="My Ads" Language="C#" MasterPageFile="~/SiteHeader.Master" AutoEventWireup="true" CodeBehind="MyAds.aspx.cs" Inherits="AddPostWebForm.MyAds" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <div class="row">
            <div class="logincolumn vr" style="background-color: white; padding-left: 50px; padding-right: 50px; align-content:center">
                <div style="margin-left: auto; margin-right: auto; text-align: center; padding-top: 70px">
                    <asp:Label runat="server" Font-Bold="true" Font-Size="Large" Text=" All Categories"></asp:Label>
                </div>
                <hr />

                <asp:LinkButton ID="AllCategory" runat="server" OnClick="AllCategory_click" Font-Size="Medium" ForeColor="#ff0066">All Categories</asp:LinkButton>
                <br />
                <br />

                <asp:Repeater ID="CategoryRepeat" runat="server">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="false">
                            <i class="glyphicon glyphicon-tag"></i>
                        </asp:LinkButton>
                        &nbsp;&nbsp;
                        <asp:LinkButton ID="Category" runat="server" OnClick="Category_click" CommandArgument='<%# Eval("CategoryID") %>'><%# Eval("CategoryName") %></asp:LinkButton>
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
                
                
                
            </div>

            <div class="loginpicture">

                    <br />
                    <div style="padding-left:20px">
                        <asp:TextBox ID="txtSearchbox" runat="server" CssClass="searchtextbox"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="searchbutton" OnClick="SearchAd_click"/>
                    </div>

                    <div style="padding-top:40px">
            
                        <asp:Repeater id="myAdRep" runat="server" OnItemCommand="myAdRep_ItemCommand">
                            <ItemTemplate>
                                
                                    <div class="row">
                                        <div class="ad-card card-border card-border-success shadow-0 mb-3" style="width: 50rem;">
                                            <div class="container">
                                                <div class="row">
                                                    <div class="col-md-2">   
                                                        <img class="mx-auto d-block" src='/images/<%# Eval("Image") %>' height="100" width="100"/>   
                                                    </div>
                                                    <div class="col-md-2"> 
                                                        <asp:Label ID="lblTitle" runat="server" Font-Bold="true" Font-Size="X-Large"><%# Eval("Title") %></asp:Label>
                                                        <br />
                                                        <%--<asp:Label ID="lblCondition" runat="server"><%# Eval("Condition") %></asp:Label>--%>
                                                        <%--<asp:Label ID="lblDescription" runat="server"><%# Eval("Description") %></asp:Label>--%>
                                                        <asp:Label ID="lblPrice" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="#0066ff">Rs. <%# Eval("Price") %></asp:Label>
                                                        <br />
                                                        <br />

                                                        

                                                        <asp:LinkButton ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure?');" CommandArgument='<%# Eval("PostID") %>' ForeColor="Red" Font-Underline="false">
                                                            <i class="glyphicon glyphicon-trash"></i>
                                                        </asp:LinkButton>
                                                        &nbsp;
                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("PostID") %>' ForeColor="Black" Font-Underline="false">
                                                            <i class="glyphicon glyphicon-edit"></i>
                                                        </asp:LinkButton>
                                                        &nbsp;
                                                        <asp:LinkButton ID="btnDetail" runat="server" CommandArgument='<%# Eval("PostID") %>' Text="More>>" />
                                                        <br />
                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                 
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                
            </div>
        </div>
    </form>

</asp:Content>
