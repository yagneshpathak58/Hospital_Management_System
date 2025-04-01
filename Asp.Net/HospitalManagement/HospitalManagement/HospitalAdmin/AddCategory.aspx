<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalAdmin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="HospitalManagement.HospitalAdmin.AddCategory" %>
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
                            <%--<div class="form-group col-md-12">
                                <label>Category Image Name</label>
                                <asp:TextBox ID="txtImage" runat="server" CssClass="form-control" placeholder="Enter Category Image Name"></asp:TextBox>
                                <%--<input type="email" class="form-control" placeholder="Email">--%
                            </div>--%>
                            <div class="form-row">
                            <div class="form-group col-md-12">
                                <label>Upload Image</label>
                                <asp:FileUpload ID="fuCategoryImage" runat="server" CssClass="form-control" />
                            </div>
                            
                        </div>
                            <%--<div class="form-group col-md-6">
                                <label></label>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                            </div>--%>
                        </div>
                        

                        <%--<button type="submit" class="btn btn-dark">Sign in</button>--%>
                        <asp:Button ID="btnAddCategory" runat="server" Text="Add Category" CssClass="btn btn-dark" OnClick ="btnAddCategory_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
