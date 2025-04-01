<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalAdmin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="EditDoctor.aspx.cs" Inherits="HospitalManagement.HospitalAdmin.EditDoctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">Add Doctor</h4>
                    <div class="basic-form">
                        <asp:Panel ID="pnlAlertD" runat="server" CssClass="alert alert-danger" Visible="false">
                            <asp:Label ID="lblMessageD" runat="server" Text="This is a danger alert—check it out!"></asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="pnlAlertS" runat="server" CssClass="alert alert-success" Visible="false">
                            <asp:Label ID="lblMessageS" runat="server" Text="This is a danger alert—check it out!"></asp:Label>
                        </asp:Panel>

                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label>Name</label>
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                                <%--<input type="email" class="form-control" placeholder="Email">--%>
                            </div>
                            <%--<div class="form-group col-md-6">
                                <label></label>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                            </div>--%>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-3">
                                <asp:HiddenField ID="hdfDoctorImagePath" runat="server" />
                                <asp:HiddenField ID="hdfDoctorImageName" runat="server" />
                                <label>Current Iamge</label>
                                <asp:LinkButton ID="lnkbtnDoctorImage" runat="server"></asp:LinkButton>
                            </div>
                            <div class="form-group col-md-9">
                                <label>New Image</label>
                                <asp:FileUpload ID="fuDoctorImage" runat="server" CssClass="form-control" Enabled="true"/>
                            </div>
                            
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>Contact</label>
                                <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" placeholder="Enter Contact No."></asp:TextBox>
                            </div>
                            <div class="form-group col-md-6">
                                <label>Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email Address"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>Doctor Registration Number</label>
                                <asp:TextBox ID="txtDrregnum" runat="server" CssClass="form-control" placeholder="Enter Registration No." Enabled="false"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-6">
                                <label>Category Name</label>
                                <asp:DropDownList ID="ddCategory" runat="server" CssClass="form-control" Enabled="false">
                                    <asp:ListItem Value="sub">Sub-Admin</asp:ListItem>   
                                </asp:DropDownList>
                            </div>
                        </div>
                        
                        
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label>Bank Details</label>
                            </div>
                        </div>

                        
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>Bank Name</label>
                                <asp:TextBox ID="txtBankname" runat="server" CssClass="form-control" placeholder="Enter Bank Name" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-6">
                                <label>Bank Account Number</label>
                                <asp:TextBox ID="txtBankacno" runat="server" CssClass="form-control" placeholder="Enter Bank Account No." TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>Bank IFCCode</label>
                                <asp:TextBox ID="txtBankifccode" runat="server" CssClass="form-control" placeholder="Enter Bank IFCCode" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-6">
                                <label>Bank Account Type</label>
                             
                                <asp:TextBox ID="txtBankactype" runat="server" CssClass="form-control" placeholder="Enter Bank Account TYpe" TextMode="MultiLine"></asp:TextBox>
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
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-dark" OnClick="btnSubmit_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
