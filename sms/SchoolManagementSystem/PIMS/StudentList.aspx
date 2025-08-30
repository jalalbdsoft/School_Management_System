<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="SchoolManagementSystem.Setup.StudentList" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="content-wrapper">
        <div class="container">
              <script type="text/javascript" >
                    function ParentRefrash() {
                        return document.getElementById('<%=hdnUpdategrid.ClientID %>');
                    }
              </script>

              <asp:HiddenField ID="hdnUpdategrid" runat="server" />
                <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Student List</h3>
                </div>
                <uc1:ResponseMessage runat="server" ID="rmMsg" />
                <!-- /.card-header -->
                <!-- form start -->
                <div class="card-body">
                    <div class="row">

                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Student Name</label>
                                <asp:TextBox ID="txtFirstName" runat="server" placeholder="Search...." CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">District</label>
                                
                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control"  AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"  ></asp:DropDownList>
                            </div>
                            </div>
                            <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Upazila</label>
                                <asp:DropDownList ID="ddlUpazila" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                                </div>
                        
                        
                        <div class="col-md-2">
                            <div class="form-group ">
                                <label class="form-label">&nbsp;</label>
                               
                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary form-control" Text="Search" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                    </div>


                </div>

                
                    <div class="row">
                        <div class="col-md-12" style="overflow:scroll">
                            <div class="form-group ">
                                
                                <asp:GridView ID="gvStudent" runat="server" CssClass="table table-bordered table-striped" Width="100%" AutoGenerateColumns="False" OnRowCommand="gvStudent_RowCommand" OnRowDataBound="gvStudent_RowDataBound"   >  
                                    <Columns>

                                        <asp:BoundField DataField="RegistrationNo" HeaderText="Registration No" />
                                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                        <asp:BoundField DataField="LastName" HeaderText="Last Name"/>
                                        <asp:BoundField DataField="DistrictName" HeaderText="District Name"/>
                                        <asp:BoundField DataField="UpazilaName" HeaderText="Upazila Name"/>
                                        <asp:BoundField DataField="Address" HeaderText="Address"/>
                                        <asp:BoundField DataField="ContactNo" HeaderText="Contact No"/>

                                       
                                        <asp:TemplateField>
                                            <HeaderTemplate>Admission Class</HeaderTemplate>
                                            <ItemTemplate>
                                            <asp:Label ID="lblClass" runat="server" Text='<%# Eval("ClassName") %>'></asp:Label><br />
                                                <asp:LinkButton ID="lbAdCancel" runat="server" CommandName="adcancel" CommandArgument="<%# Container.DataItemIndex %>" >Admission Cancel</asp:LinkButton>
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       

                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgAdmission" runat="server" ImageUrl="~/assets/img/users/admission.png" CommandName="admission" CommandArgument='<%# Container.DataItemIndex %>' Width="93px" Height="25px" />
                                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/assets/site/images/ico_information.png" CommandName="admission" CommandArgument='<%# Container.DataItemIndex %>' Width="25px" />
                                                <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/assets/img/cancel.png" CommandName="deletec" CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="if ( ! ConfirmationMsg()) return false;" meta:resourcekey="imgDelete" Width="25px" />
                                                <asp:HiddenField ID="hdnStudentId" runat="server" Value='<%# Eval("StudentId") %>' />
                                                
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

        
        <!-- /.card -->
    </div>
</asp:Content>
