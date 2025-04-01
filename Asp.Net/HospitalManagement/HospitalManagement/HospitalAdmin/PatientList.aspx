<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalAdmin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="PatientList.aspx.cs" Inherits="HospitalManagement.HospitalAdmin.PatientList" %>
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
                                                <th>Name</th>
                                                <th>Contact</th>
                                                <th>Status</th>
                                                <th>Date</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptPatient" runat="server" OnItemCommand="rptPatient_ItemCommand1">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("P_Id") %> </td>
                                                        <td><%#Eval("P_Name") %></td>
                                                        <td>
                                                            <%#Eval("P_Contact") %><br />
                                                            <%#Eval("P_Email") %> <br /> 
                                                            <%#Eval("P_Address") %> <br />

                                                        </td>
                                                        <td><%#Eval("P_Status") %></td>
                                                        <td><%#Eval("P_Date") %></td>
                                                        <td>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("P_Id") %>' CommandName="edit">
                                                                <i class="fa fa-edit"></i>
                                                            </asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("P_Id") %>' CommandName="delete">
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
                                                <th>Name</th>
                                                <th>Contact</th>
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
