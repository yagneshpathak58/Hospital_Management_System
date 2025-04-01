<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalAdmin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="EditPatient.aspx.cs" Inherits="HospitalManagement.HospitalAdmin.EditPatient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">Add Patient</h4>
                    <div class="basic-form">
                        <asp:Panel ID="pnlAlertD" runat="server" CssClass="alert alert-danger" Visible="false">
                            <asp:Label ID="lblMessageD" runat="server" Text="This is a danger alert—check it out!"></asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="pnlAlertS" runat="server" CssClass="alert alert-success" Visible="false">
                            <asp:Label ID="lblMessageS" runat="server" Text="This is a danger alert—check it out!"></asp:Label>
                        </asp:Panel>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label>Name*</label>
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                                <%--<input type="email" class="form-control" placeholder="Email">--%>
                            </div>
                            <%--<div class="form-group col-md-6">
                                <label></label>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                            </div>--%>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>Contact*</label>
                                <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" placeholder="Enter Contact No."></asp:TextBox>
                            </div>
                            <div class="form-group col-md-6">
                                <label>Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email Address"></asp:TextBox>
                            </div>
                        </div>
                        <%--<div class="form-row">
                            <div class="form-group col-md-6">
                                <label>*</label>
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter Username"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-6">
                                <label>Role</label>
                                <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="sub">Sub-Admin</asp:ListItem>
                                    <asp:ListItem>Sub-Admin</asp:ListItem>
                                    <asp:ListItem>Sub-Admin</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>--%>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label>Address</label>
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Username" TextMode="MultiLine"></asp:TextBox>
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
                        <asp:Button ID="btnEditPatient" runat="server" Text="Update Patient" CssClass="btn btn-dark" OnClick="btnEditPatient_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
