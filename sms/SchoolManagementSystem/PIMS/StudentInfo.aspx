<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="StudentInfo.aspx.cs" Inherits="SchoolManagementSystem.Setup.StudentProfile" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="container">
            
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
                                <label class="form-label">Registration No</label>
                                <asp:TextBox ID="txtRegistration" runat="server" placeholder="Enter First Name" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">First Name</label>
                                <asp:TextBox ID="txtFirstName" runat="server" placeholder="Enter First Name" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Last Name</label>
                                <asp:TextBox ID="txtLastName" runat="server" placeholder="Enter Last Name" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Father's Name</label>
                               
                                 <asp:TextBox ID="txtFatherName" runat="server" placeholder="Enter Father's Name" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                         <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Father's Contact Number</label>
                                <asp:TextBox ID="txtFatherContact" runat="server" placeholder="Father's Contact Number" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Father's Occupation</label>
                                <asp:TextBox ID="txtFatherOccupation" runat="server" placeholder="Father's Contact Number" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Mother's Name</label>
                               
                                 <asp:TextBox ID="txtMotherName" runat="server" placeholder="Enter Mother's Name" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                         <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Mother's Contact Number</label>
                                <asp:TextBox ID="txtMotherContact" runat="server" placeholder="Mother's Contact Number" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Mother's Occupation</label>
                                <asp:TextBox ID="txtMotherOccupation" runat="server" placeholder="Mother's Occupation" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        
                        
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Guardian Name</label>
                                <asp:TextBox ID="txtGuardian" runat="server" placeholder="Enter Guardian Name" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Realation with Guardian</label>
                                <asp:TextBox ID="txtRelation" runat="server" placeholder="Enter Guardian Relation" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                         <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Guardian Contact Number</label>
                                <asp:TextBox ID="txtGuardianContact" runat="server" placeholder="Enter Guardian Contact No." CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Date of Birth</label>
                                <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>
                        </div> 
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Nationality</label>
                                <asp:TextBox ID="txtNationality" runat="server" placeholder="Enter Nationality" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Religion</label>
                                <asp:DropDownList ID="ddlReligion" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Gender</label>
                                <asp:DropDownList ID="ddlGender" CssClass="form-control dropdown" runat="server">
                                    <asp:ListItem Value="0">Select Gender...</asp:ListItem>
                                    <asp:ListItem Value="Male">Male</asp:ListItem>
                                    <asp:ListItem Value="Female">Female</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">District</label>
                                
                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control"  AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" ></asp:DropDownList>
                            </div>
                            </div>
                            <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Upazila</label>
                                <asp:DropDownList ID="ddlUpazila" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                                </div>
                        <div class="col-md-8">
                            <div class="form-group ">
                                <label class="form-label">Address</label>
                                <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter Address" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                         <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Email" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Contact Number</label>
                                <asp:TextBox ID="txtPhone" runat="server" placeholder="Enter Contact No." CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group ">
                                <label class="form-label">Blood Group</label>
                                <asp:DropDownList ID="ddlBloodGroup" CssClass="form-control dropdown" runat="server">
                                    <asp:ListItem Value="0">Select...</asp:ListItem>
                                    <asp:ListItem Value="A+">A+</asp:ListItem>
                                    <asp:ListItem Value="B+">B+</asp:ListItem>
                                   
                                </asp:DropDownList>
                            </div>
                        </div> 
                        
                        <div class="col-md-2">
                            <div class="form-group ">
                                <label class="form-label">&nbsp;</label>
                                <asp:HiddenField ID="hdnUpdateStudentId" runat="server" />
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary form-control" Text="Save" OnClick="btnSave_Click"/>
                            </div>
                        </div>
                    </div>


                </div>

               
            </div>


            </div>

        
        <!-- /.card -->
    </div>
</asp:Content>
