<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ConInstitute.aspx.cs" Inherits="SchoolManagementSystem.Setup.ConInstitute" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ConfirmationMsg() {
            return confirm("Are u sure to Delete");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="container">
            <!-- general form elements -->
            <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Institute Info</h3>
              </div>
                <uc1:responsemessage runat="server" id="rmMsg" />
               
              <!-- /.card-header -->
              <!-- form start -->

                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">EIIN / Registration No.</label>
                                <asp:TextBox ID="txtEIIN" CssClass="form-control"  placeholder="Enter EIIN / Registration No." runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group ">
                                <label class="form-label">Institute Name</label>
                                <asp:TextBox ID="txtInstituteName" runat="server" placeholder="Enter Institute Name" CssClass="form-control"></asp:TextBox>
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
                                <label class="form-label">Phone</label>
                                <asp:TextBox ID="txtPhone" runat="server" placeholder="Enter Phone" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Fax</label>
                                <asp:TextBox ID="txtFax" runat="server" placeholder="Enter Fax" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">District</label>
                                <asp:DropDownList ID="ddlDistrict" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            </div>
                            <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Upazila</label>
                                <asp:DropDownList ID="ddlUpazila" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                                </div>
                                <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Address</label>
                                <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter Address" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                       

                    <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Institution Type</label>
                                <asp:DropDownList ID="ddlInstitutionType" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                                </div>
                        <div class="col-md-2">
                            <div class="form-group ">
                                <label class="form-label" > &nbsp;</label>
                                <asp:HiddenField ID="hdnUpdateInstituteId" runat="server" />
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary form-control" Text="Save" OnClick="btnSave_Click" />
                            </div>
                        </div>

                    </div> 
                
                    </div>
               
               
              
                <div class="card-header ">
                    <h3 class="card-title text-center">Institute List</h3>
                </div>
               <div class="card-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group ">
                                <asp:GridView ID="gvInstitute" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" OnRowCommand="gvInstitute_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="InstituteName" HeaderText="Institute Name" /> 
                                        <asp:BoundField DataField="EIIN_RegistrationNo" HeaderText="EIIN / Registration No" />
                                        <asp:BoundField DataField="Phone" HeaderText="Phone" /> 
                                        <asp:BoundField DataField="DistrictName" HeaderText="District Name" /> 
                                        <asp:BoundField DataField="UpazilaName" HeaderText="Upazila Name" /> 
                                        <asp:BoundField DataField="InstituteTypeName" HeaderText="Institute Type Name" /> 

                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/assets/site/images/ico_information.png" Width="25px" CommandName="editc" CommandArgument='<%# Container.DataItemIndex %>' />
                                                <asp:ImageButton ID="imgdelete" runat="server" ImageUrl="~/assets/img/cancel.png" Width="25px" CommandName="deletec" CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="if ( ! ConfirmationMsg()) return false;" meta:resourcekey="imgDelete" />
                                                <asp:HiddenField ID="hdnInstituteId" runat="server" Value='<%# Eval("InstituteId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.card -->
    </div>
    </div>
     
</asp:Content>
