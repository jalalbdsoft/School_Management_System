<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="InstituteType.aspx.cs" Inherits="SchoolManagementSystem.Setup.InstituteType" %>

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
                <h3 class="card-title">InstituteType Info</h3>
              </div>
                <uc1:responsemessage runat="server" id="rmMsg" />
               
              <!-- /.card-header -->
              <!-- form start -->

                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">Institute Type Name</label>
                                <asp:TextBox ID="txtInstituteTypeName" runat="server" placeholder="Enter InstituteType" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                         <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Is Active</label>
                                <asp:DropDownList ID="ddlIsActive" runat="server" CssClass="form-control">
                                    <asp:ListItem>Select--</asp:ListItem>
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">Inactive</asp:ListItem>
                                </asp:DropDownList>
                               
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group ">
                                <label class="form-label" > &nbsp;</label>
                                <asp:HiddenField ID="hdnUpdateInstituteTypeId" runat="server" />
                                 <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary form-control" Text="Save" OnClick="btnSave_Click" />
                            </div>

                        </div>
                    </div>

               
                </div>
              
                <div class="card-header ">
                    <h3 class="card-title text-center">InstituteType List</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group ">
                                <asp:GridView ID="gvInstituteType" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" OnRowCommand="gvInstituteType_RowCommand" >
                                    <Columns>
                            <asp:TemplateField HeaderText="Institute Type Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblInstituteType" runat="server" Text='<%# Eval("InstituteTypeName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                        <asp:BoundField DataField="UserName" HeaderText="User Name" />
                                        <asp:BoundField DataField="IsActive" HeaderText="Is Active" />
                                        <asp:TemplateField HeaderText="Action" >
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/assets/site/images/ico_information.png" Width="25px" CommandName="editc" CommandArgument='<%# Container.DataItemIndex %>' />
                                                <asp:ImageButton ID="imgdelete" runat="server" ImageUrl="~/assets/img/cancel.png" Width="25px" CommandName="deletec" CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="if ( ! ConfirmationMsg()) return false;" meta:resourcekey="imgDelete"  />
                                                <asp:HiddenField ID="hdnInstituteTypeId" runat="server" Value='<%# Eval("InstituteTypeId") %>' />
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
