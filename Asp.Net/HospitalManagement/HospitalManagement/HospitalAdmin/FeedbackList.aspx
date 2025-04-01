<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalAdmin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="FeedbackList.aspx.cs" Inherits="HospitalManagement.HospitalAdmin.FeedbackList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Feedback list</h4>
                                <div class="table-responsive">
                                    <table class="table table-striped table-bordered zero-configuration">
                                        <thead>
                                            <tr>
                                                <th>Feedback Id</th>
                                               
                                                <th>User Id</th>
                                                <th>User Type</th>
                                                <th>Feedback Subject</th>
                                                <th>Feedback Message</th>
                                                <%--<th>Status</th>--%>
                                                <th>Date</th>
                                                
                                           </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptFeedback" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("F_Id") %></td>
                                                        <td><%#Eval("U_Id") %></td>
                                                        <td><%#Eval("U_Type") %></td>

                                                        
                                                        <td><%#Eval("F_Subject") %></td>
                                                        <td><%#Eval("F_Message") %></td
                                                        <%--<td><%#Eval("F_Status")%></td>--%>
                                                        <td><%#Eval("F_Date")%> </td>
                                                        
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                               <th>Feedback Id</th>
                                               
                                                <th>User Id</th>
                                                <th>User Type</th>
                                                <th>Feedback Subject</th>
                                                <th>Feedback Message</th>
                                                <%--<th>Status</th>--%>
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
