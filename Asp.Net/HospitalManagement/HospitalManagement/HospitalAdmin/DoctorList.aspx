<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalAdmin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="DoctorList.aspx.cs" Inherits="HospitalManagement.HospitalAdmin.DoctorList" %>
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
                                                <th>Category Id</th>
                                                <th>Name</th>
                                                <th>Contact</th>
                                                <th>Bank Info</th>
                                                <th>Registration Number</th>
                                                <th>Status</th>
                                                <th>Date</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptDoctor" runat="server" OnItemCommand="rptDoctor_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("DR_Id") %></td>
                                                        <td><%#Eval("C_ID") %></td>
                                                        <td>
                                                            <%#Eval("DR_Name") %>
                                                           
                                                        </td>
                                                        <td><%#Eval("DR_Contact") %><br />
                                                             <%#Eval("DR_Email") %><br />
                                                        </td>
                                                         <td><%#Eval("DR_Bank_Name") %><br />
                                                             <%#Eval("DR_B_Ac") %><br />
                                                             <%#Eval("DR_Ac_Type") %><br />
                                                             <%#Eval("DR_IFCcode") %>
                                                         </td>
                                                        <td><%#Eval("DR_Reg_No") %></td>
                                                        <td><%#Eval("DR_Status") %></td>
                                                        <td><%#Eval("DR_Date") %></td>
                                                        <td>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("DR_Id") %>' CommandName="edit">
                                                                <i class="fa fa-edit"></i>
                                                            </asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("DR_Id") %>' CommandName="delete">
                                                                <i class="fa fa-trash"></i>
                                                            </asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                               <<th>Sr. No.</th>
                                                <th>Category Id</th>
                                                <th>Name</th>
                                                <th>Contact</th>
                                                <th>Bank Info</th>
                                                <th>Registration Number</th>
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
