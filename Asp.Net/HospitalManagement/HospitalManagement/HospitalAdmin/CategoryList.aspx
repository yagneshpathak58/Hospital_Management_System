    <%@ Page Title="" Language="C#" MasterPageFile="~/HospitalAdmin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="HospitalManagement.HospitalAdmin.CategoryList" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                      
                                                <th>Title</th>
                                                <th>Status</th>
                                                <th>Date</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptCategory" runat="server" OnItemCommand="rptCategory_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("C_ID") %></td>
                                                        <td><%#Eval("C_Title") %></td>
                                                        
                                                        </td>
                                                        <td><%#Eval("C_Status") %></td>
                                                        <td><%#Eval("C_Date") %></td>
                                                        <td>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("C_ID") %>' CommandName="edit">
                                                                <i class="fa fa-edit"></i>
                                                            </asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("C_ID") %>' CommandName="delete">
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
                                               
                                                <th>Title</th>
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

