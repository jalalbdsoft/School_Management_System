<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Blank.Master" AutoEventWireup="true" CodeBehind="Admission.aspx.cs" Inherits="SchoolManagementSystem.Setup.Admission" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdnStuId" runat="server" />
     <asp:HiddenField ID="hdnRegSl" runat="server"></asp:HiddenField>
    
     <div class="content-wrapper">
        <div class="container">
            <asp:Literal ID="runScript" runat="server"></asp:Literal>
                <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Student Info</h3>
                </div>
                <uc1:ResponseMessage runat="server" ID="rmMsg" />
                    
                    
                <!-- /.card-header -->
                <!-- form start -->
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Student Name</label>
                                
                                <asp:DropDownList ID="ddlStudentName" CssClass="form-control" runat="server" Enabled="False">
                                </asp:DropDownList>
                            </div>
                        </div>
                       <%-- <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Student Name</label>
                                <asp:TextBox ID="txtStudentName" runat="server"  CssClass="form-control" Enabled="False"></asp:TextBox>
                                
                            </div>
                        </div>--%>
                       <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Registration No</label>
                                <asp:TextBox ID="txtRegistration" runat="server" placeholder="Enter Registration No" CssClass="form-control" Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Shift</label>
                                <asp:DropDownList ID="ddlShift" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="0">Select----</asp:ListItem>
                                    <asp:ListItem >Morning</asp:ListItem>
                                    <asp:ListItem >Day</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                                </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Class</label>
                                <asp:DropDownList ID="ddlClass" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                                </div>

                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Roll No</label>
                                <asp:TextBox ID="txtRollNo" runat="server" placeholder="Enter Roll No" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Session Year</label>
                                <asp:DropDownList ID="ddlSession" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged">
                    </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Date Of Admission</label>
                                <asp:TextBox ID="txtDOA" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>
                        </div> 
                        <div class="col-md-2">
                            <div class="form-group ">
                                <label class="form-label">&nbsp;</label>
                                <asp:HiddenField ID="hdnUpdateAdmissionId" runat="server" />
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary form-control" Text="Save" OnClick="btnSave_Click" />
                            </div>
                        </div>
                    </div>


                </div>

               
            </div>


            </div>

        
        <!-- /.card -->
    </div>
</asp:Content>
