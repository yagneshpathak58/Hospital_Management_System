<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalAdmin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="DoctorDocumentList.aspx.cs" Inherits="HospitalManagement.HospitalAdmin.DoctorDocumentList" %>
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
                                                <th>Doctor Id</th>
                                                <th>Title</th>
                                                <th>Document Name</th>
                                                <th>Documet Path</th>
                                                <th>Status</th>
                                                <th>Date</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptDrDocument" runat="server" OnItemCommand="rptDrDocument_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("Dd_Id") %></td>
                                                        <td><%#Eval("D_Id") %></td>
                                                        <td>
                                                            <%#Eval("Dd_Title") %></td>
                                                        <td><%#Eval("Dd_DocumentName") %></td>
                                                        <td>
                                                            <%#Eval("Dd_DocumentPath") %>
                                                            

                                                        </td>
                                                        <td><%#Eval("Dd_Status") %></td>
                                                        <td><%#Eval("Dd_date") %></td>
                                                        <td>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("Dd_Id") %>' CommandName="edit">
                                                                <i class="fa fa-edit"></i>
                                                            </asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("Dd_Id") %>' CommandName="delete">
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
                                                <th>Doctor Id</th>
                                                <th>Title</th>
                                                <th>Document Name</th>
                                                <th>Documet Path</th>
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
