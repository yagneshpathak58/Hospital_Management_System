<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalAdmin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddAppointment.aspx.cs" Inherits="HospitalManagement.HospitalAdmin.AddAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">Add Appointment</h4>
                    <div class="basic-form">
                        <asp:Panel ID="pnlAlertD" runat="server" CssClass="alert alert-danger" Visible="false">
                            <asp:Label ID="lblMessageD" runat="server" Text="This is a danger alert—check it out!"></asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="pnlAlertS" runat="server" CssClass="alert alert-success" Visible="false">
                            <asp:Label ID="lblMessageS" runat="server" Text="This is a danger alert—check it out!"></asp:Label>
                        </asp:Panel>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>Patient</label>
                                <asp:DropDownList ID="ddPatientid" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddPatientid_SelectedIndexChanged">
                                    
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-md-6">
                                <label>OPD Date</label>
                                <asp:TextBox ID="txtOpddate" runat="server" CssClass="form-control" placeholder="Enter OPDDate"></asp:TextBox>
                            </div>
                            
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label>Patient Name</label>
                                <asp:TextBox ID="txtPName" runat="server" CssClass="form-control" placeholder="Enter Patient Name"></asp:TextBox>
                                <%--<input type="email" class="form-control" placeholder="Email">--%>
                            </div>
                            <%--<div class="form-group col-md-6">
                                <label></label>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                            </div>--%>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>Contact</label>
                                <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" placeholder="Enter Contact No."></asp:TextBox>
                            </div>
                            <div class="form-group col-md-6">
                                <label>Address</label>
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Address"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                        <div class="form-group col-md-6">
                                <label>Doctor</label>
                                <asp:DropDownList ID="ddDoctorid" runat="server" CssClass="form-control"  AutoPostBack="True" OnSelectedIndexChanged="ddDoctorid_SelectedIndexChanged">
                                    
                                </asp:DropDownList>
                            </div>
                            </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label>OPD Time</label>
                                <asp:DropDownList ID="ddOPDTime" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-md-6">
                                <label>Doctor Fee</label>
                                <asp:TextBox ID="DoctorFee" runat="server" CssClass="form-control" placeholder="Fee" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label>Diseases</label>
                                <asp:TextBox ID="txtDiseases" runat="server" CssClass="form-control" placeholder="Enter Diseases" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <label>Medicines</label>
                                <asp:TextBox ID="txtMedicines" runat="server" CssClass="form-control" placeholder="Enter Medicines" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <%--<div class="form-group col-md-6">
                                <label>Payment Mode</label>
                                <asp:DropDownList ID="PaymentMode" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="Card-Payment">Card-Payment</asp:ListItem>
                                    <asp:ListItem Value="Net-Banking">Net-Banking</asp:ListItem>
                                    <asp:ListItem Value="UPI">UPI</asp:ListItem>
                                    <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                </asp:DropDownList>
                            </div>--%>
                        </div>
                        

                        <%--<button type="submit" class="btn btn-dark">Sign in</button>--%>
                        <asp:Button ID="btnAddAppointment" runat="server" Text="Add Appointment" CssClass="btn btn-dark"  OnClick="btnAddAppointment_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
