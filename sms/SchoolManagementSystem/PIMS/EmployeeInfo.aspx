<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeInfo.aspx.cs" Inherits="SchoolManagementSystem.Setup.Employee" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        /*for validating salary*/
        function chkNumber(cntId)
        {
            var val = document.getElementById(cntId).value;
            var mainC = document.getElementById(cntId);
            var chkDigit = /([1-9][0-9]*(\.[0-9]*[1-9])?|0\.[0-9]*[1-9])/;
            if (chkDigit.test(val)) {
                mainC.style.backgroundColor = "white";
            }
            else {
                alert("invalid number");
                mainC.value = "";
                mainC.style.backgroundColor = "red";
            }
        }

        /*confirm to delete*/
        function ConfirmationMsg() {
            return confirm("Are u sure to Delete");
        }

        

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="container">
            
                <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Employee Info</h3>
                </div>
                <uc1:ResponseMessage runat="server" ID="rmMsg" />
                <!-- /.card-header -->
                <!-- form start -->
                <div class="card-body">
                    <div class="row">
                       <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Employee Type</label>
                                <asp:DropDownList ID="ddlEmployeeType" CssClass="form-control dropdown" runat="server">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="Teacher">Teacher</asp:ListItem>
                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                </asp:DropDownList>
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
                                <label class="form-label">Designation</label>
                               
                                <asp:DropDownList ID="ddlDesignation" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">StartingSalary</label>
                                <asp:TextBox ID="txtStartingSalary" runat="server" placeholder="Enter Starting Salary" CssClass="form-control"></asp:TextBox>
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
                                <label class="form-label">NID</label>
                                <asp:TextBox ID="txtNID" runat="server" placeholder="Enter NID" CssClass="form-control"></asp:TextBox>
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
                                <label class="form-label">Date of Joining</label>
                                <asp:TextBox ID="txtDOJ" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>

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
                                <asp:HiddenField ID="hdnUpdateEmployeeId" runat="server" />
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary form-control" Text="Save" OnClick="btnSave_Click"/>
                            </div>
                        </div>
                    </div>


                </div>

                <div class="card-header">
                    <h3 class="card-title text-center">Employee List</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12" style="overflow:scroll">
                            <div class="form-group ">
                                
                                <asp:GridView ID="gvEmployee" runat="server" CssClass="table table-bordered table-striped" Width="100%" OnRowCommand="gvEmployee_RowCommand" AutoGenerateColumns="False" >  
                                    <Columns>

                                        <asp:BoundField DataField="EmployeeType" HeaderText="Employee Type"/>
                                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                        <asp:BoundField DataField="LastName" HeaderText="Last Name"/>
                                        <asp:BoundField DataField="DesignationName" HeaderText="Designation"/>
                                        <asp:BoundField DataField="StartingSalary" HeaderText="Starting Salary"/>
                                        <asp:BoundField DataField="ContactNo" HeaderText="Contact No"/>
                                        <asp:BoundField DataField="Nationality" HeaderText="Nationality"/>
                                        <asp:BoundField DataField="NID" HeaderText="NID"/>
                                        <asp:BoundField DataField="DOB" HeaderText="DOB"/>
                                        <asp:BoundField DataField="JoiningDate" HeaderText="Joining Date"/>
                                        <asp:BoundField DataField="ReligionName" HeaderText="Religion"/>
                                        <asp:BoundField DataField="Gender" HeaderText="Gender"/>
                                        <asp:BoundField DataField="DistrictName" HeaderText="District Name"/>
                                        <asp:BoundField DataField="UpazilaName" HeaderText="Upazila Name"/>
                                        <asp:BoundField DataField="Address" HeaderText="Address"/>
                                        <asp:BoundField DataField="ContactNo" HeaderText="Contact No"/>
                                        <asp:BoundField DataField="BloodGroup" HeaderText="Blood Group"/>
                                        <asp:BoundField DataField="IsActive" HeaderText="Is Active"/>

                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>

                                                
                                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/assets/site/images/ico_information.png" CommandName="editc" CommandArgument='<%# Container.DataItemIndex %>' Width="25px" />
                                                <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/assets/img/cancel.png" CommandName="deletec" CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="if ( ! ConfirmationMsg()) return false;" meta:resourcekey="imgDelete" Width="25px" />
                                                <asp:HiddenField ID="hdnEmployeeId" runat="server" Value='<%# Eval("EmployeeId") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            </div>

        
        <!-- /.card -->
    </div>
</asp:Content>
