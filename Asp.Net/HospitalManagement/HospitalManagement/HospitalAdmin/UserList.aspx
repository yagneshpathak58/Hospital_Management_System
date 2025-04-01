<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalAdmin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="HospitalManagement.HospitalAdmin.UserList" %>
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
                                                <th>Username</th>
                                                <th>Status</th>
                                                <th>Date</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptUser" runat="server" OnItemCommand="rptUser_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("A_ID") %></td>
                                                        <td><%#Eval("A_Name") %></td>
                                                        <td>
                                                            <%#Eval("A_Contact") %><br />
                                                            <%#Eval("A_Email") %>
                                                        </td>
                                                        <td>
                                                            <%#Eval("A_UserName") %><br />
                                                            <%#Eval("A_Role") %>

                                                        </td>
                                                        <td><%#Eval("A_Status") %></td>
                                                        <td><%#Eval("A_Date") %></td>
                                                        <td>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("A_ID") %>' CommandName="edit">
                                                                <i class="fa fa-edit"></i>
                                                            </asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("A_ID") %>' CommandName="delete">
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
                                                <th>Username</th>
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
