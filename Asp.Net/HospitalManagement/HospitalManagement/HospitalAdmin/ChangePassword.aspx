<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalAdmin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="HospitalManagement.HospitalAdmin.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-6 offset-3">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">Change Password</h4>
                    <div class="basic-form">
                        <asp:Panel ID="pnlAlertD" runat="server" CssClass="alert alert-danger" Visible="false">
                            <asp:Label ID="lblMessageD" runat="server" Text="This is a danger alert—check it out!"></asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="pnlAlertS" runat="server" CssClass="alert alert-success" Visible="false">
                            <asp:Label ID="lblMessageS" runat="server" Text="This is a danger alert—check it out!"></asp:Label>
                        </asp:Panel>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label>Old Password*</label>
                                <asp:TextBox ID="txtOldPass" runat="server" CssClass="form-control" placeholder="Enter Old Password" TextMode="Password"></asp:TextBox>
                                <%--<input type="email" class="form-control" placeholder="Email">--%>
                            </div>
                            <%--<div class="form-group col-md-6">
                                <label></label>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                            </div>--%>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label>New Password*</label>
                                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" placeholder="Enter New Password" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label>Confirm Password*</label>
                                <asp:TextBox ID="txtConfirmpass" runat="server" CssClass="form-control" placeholder="Enter Confirm Password" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        

                        <%--<button type="submit" class="btn btn-dark">Sign in</button>--%>
                        <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" CssClass="btn btn-dark" OnClick="btnChangePassword_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
