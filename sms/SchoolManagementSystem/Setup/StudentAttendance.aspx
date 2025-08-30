<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="StudentAttendance.aspx.cs" Inherits="SchoolManagementSystem.Setup.StudentAttendance" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="container">
          

            <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Teacher Assign</h3>
                </div>
                <uc1:ResponseMessage runat="server" id="rmMsg" />

                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="row">
                     
                         <div class="col-md-6">
                            <label class="form-label">Shift Name</label>
                            <asp:DropDownList ID="ddlShift" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlShift_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Value="0">Select--</asp:ListItem>
                                <asp:ListItem>Morning</asp:ListItem>
                                <asp:ListItem>Day</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                       
                        <div class="col-md-6">
                            <label class="form-label">Class Name</label>
                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>

                         <div class="col-md-6">
                            <label class="form-label">Date</label>
                             <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date" AutoPostBack="True" OnTextChanged="txtDate_TextChanged"></asp:TextBox>

                        </div>

                    </div>
                </div>
            </div>



            <div class="card card-primary">
                <div class="card-header ">
                    <h3 class="card-title text-center">Student Attendance List</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group ">
                                <asp:GridView ID="gvStudentAttendance" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="StudentName" HeaderText="StudentName" />
                                        <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                                        <asp:TemplateField HeaderText="Present">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnStudentId" runat="server" Value='<%# Eval("StudentId") %>' />
 <asp:CheckBox ID="chkPresent" runat="server" Checked='<%#bool.Parse(Eval("AttendanceStatus").ToString())%>' />
                                </ItemTemplate> 
                            </asp:TemplateField>
                                        
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-5">
                        </div>
                        <div class="col-md-5">
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnSubmit" CssClass="btn btn-primary form-control" Enabled="true" runat="server" Text="Save" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
