<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalAdmin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="BillList.aspx.cs" Inherits="HospitalManagement.HospitalAdmin.BillList" %>
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
                                                
                                                <th>Bill Patient No</th>
                                                
                                                
                                                
                                                <th>Paid Amount</th>
                                                <th>Payment Mode</th>
                                                
                                                <th>Status</th>
                                                <th>Date</th>
                                           </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptBillpatient" runat="server" >
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("B_P_Id") %></td>
                                                        <td><%#Eval("B_P_No") %></td>
                                                        <td><%#Eval("B_P_Paid_Amount") %></td>
                                                        <td><%#Eval("B_P_PaymentMode") %></td>
                                                        <td><%#Eval("B_P_Status") %></td>
                                                        <td><%#Eval("B_P_Date") %></td>
                                                        
                                                        </td>
                                                        
                                                        
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                               <th>Sr. No.</th>
                                                
                                                <th>Bill Patient No</th>
                                                
                                                
                                                
                                                <th>Paid Amount</th>
                                                <th>Payment Mode</th>
                                                
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
