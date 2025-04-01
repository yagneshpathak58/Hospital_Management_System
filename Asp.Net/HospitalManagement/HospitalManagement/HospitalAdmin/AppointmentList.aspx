<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalAdmin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AppointmentList.aspx.cs" Inherits="HospitalManagement.HospitalAdmin.AppointmentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Data Table</h4>
                                <div class="table-responsive">
                                    <table class="table table-striped table-bordered zero-configuration">
                                        <thead>
                                            <tr>
                                                <th>Sr. No.</th>
                                                <th>Dr Id</th>
                                                <th>Patient Id</th>
                                                <th>Patient Name</th>
                                                <th>Contact </th>
                                                
                                                <th>OPD Date & Time</th>
                                                <th>Status</th>
                                                <th>Date</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptAppointment" runat="server" OnItemCommand="rptAppointment_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("P_A_Id") %></td>
                                                        <td><%#Eval("P_ID") %></td>
                                                        <td><%#Eval("D_ID") %></td>

                                                        
                                                        <td><%#Eval("P_A_Name") %></td>
                                                        <td>
                                                            <%#Eval("P_A_Contact") %><br />
                                                            <%#Eval("P_A_Address") %>
                                                        </td>
                                                        
                                                        <td>
                                                            <%#Eval("P_A_OPD_Date") %><br />
                                                            <%#Eval("P_A_OPD_Time") %>

                                                        </td>
                                                        <td><%#Eval("P_A_Status") %></td>
                                                        <td><%#Eval("P_A_Date") %></td>
                                                        <td>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("P_A_Id") %>' CommandName="edit">
                                                                <i class="fa fa-edit"></i>
                                                            </asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("P_A_Id") %>' CommandName="delete">
                                                                <i class="fa fa-trash"></i>
                                                            </asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                               <th>Sr. No.</th>
                                                <th>Dr Id</th>
                                                <th>Patient Id</th>
                                                <th>Patient Name</th>
                                                <th>Contact </th>
                                                
                                                <th>OPD Date & Time</th>
                                                <th>Status</th>
                                                <th>Date</th>
                                                <th>Action</th>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
</asp:Content>
