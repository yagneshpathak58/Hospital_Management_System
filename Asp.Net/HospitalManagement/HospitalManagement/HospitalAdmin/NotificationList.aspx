<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalAdmin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="NotificationList.aspx.cs" Inherits="HospitalManagement.HospitalAdmin.NotificationList" %>
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
                                                
                                                
                                                <th>User Type</th>
                                                <th>Notification Type</th>
                                                <th>Notification Title</th>
                                                <th>Notification Message</th>
                                                <th>Status</th>
                                                <th>Date</th>
                                           </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptNotificationpatient" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("N_Id") %></td>
                                                        
                                                        <td><%#Eval("N_U_Type") %></td>
                                                        <td><%#Eval("N_Type") %></td>
                                                        <td><%#Eval("N_Title") %></td>
                                                        <td><%#Eval("N_Message") %></td>
                                                        <td>
                                                            <%#Eval("N_Status") %><br />
                                                            <%#Eval("N_Date") %>
                                                        </td>
                                                        
                                                        
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                               <th>Sr. No.</th>
                                                
                                                
                                                <th>User Type</th>
                                                <th>Notification Type</th>
                                                <th>Notification Title</th>
                                                <th>Notification Message</th>
                                                <th>Status</th>
                                                <th>Date</th>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
</asp:Content>
