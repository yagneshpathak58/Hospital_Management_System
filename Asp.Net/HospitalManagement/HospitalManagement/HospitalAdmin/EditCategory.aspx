<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalAdmin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="EditCategory.aspx.cs" Inherits="HospitalManagement.HospitalAdmin.EditCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">Add Category</h4>
                    <div class="basic-form">
                        <asp:Panel ID="pnlAlertD" runat="server" CssClass="alert alert-danger" Visible="false">
                            <asp:Label ID="lblMessageD" runat="server" Text="This is a danger alert—check it out!"></asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="pnlAlertS" runat="server" CssClass="alert alert-success" Visible="false">
                            <asp:Label ID="lblMessageS" runat="server" Text="This is a danger alert—check it out!"></asp:Label>
                        </asp:Panel>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label>Category Title</label>
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" placeholder="Enter Category Title"></asp:TextBox>
                                <%--<input type="email" class="form-control" placeholder="Email">--%>
                            </div>
                            <%--<div class="form-group col-md-6">
                                <label></label>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                            </div>--%>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-3">
                                <asp:HiddenField ID="hdfCategoryImagePath" runat="server" />
                                <asp:HiddenField ID="hdfCategoryImageName" runat="server" />
                                <label>Current Iamge</label>
                                <asp:LinkButton ID="lnkbtnCategoryImage" runat="server"></asp:LinkButton>
                            </div>
                            <div class="form-group col-md-9">
                                <label>New Image</label>
                                <asp:FileUpload ID="fuCategoryImage" runat="server" CssClass="form-control" Enabled="true"/>
                            </div>
                            
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>Status</label>
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="Active">Active</asp:ListItem>
                                    <asp:ListItem Value="DeActive">De-Active</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        

                        <%--<button type="submit" class="btn btn-dark">Sign in</button>--%>
                        <asp:Button ID="btnSaveChange" runat="server" Text="Save Changes" CssClass="btn btn-dark" OnClick="btnSaveChange_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
