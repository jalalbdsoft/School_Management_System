<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Class.aspx.cs" Inherits="SchoolManagementSystem.Setup.Class" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="content-wrapper">
        <div class="container">
            <!-- general form elements -->
            <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Class Info</h3>
              </div>

                <uc1:ResponseMessage runat="server" ID="rmMsg" />
              <!-- /.card-header -->
              <!-- form start -->

                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">Class Name</label>
                                <asp:TextBox ID="txtClass" runat="server" placeholder="Enter Class" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <div class="col-md-2">
                            <div class="form-group ">
                                <label class="form-label" > &nbsp;</label>
                                <asp:HiddenField ID="hdnUpdateClsId" runat="server" />
                                 <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary form-control" Text="Save" OnClick="btnSave_Click"/>
                            </div>

                        </div>
                    </div>

               
                </div>
              
                <div class="card-header ">
                    <h3 class="card-title text-center">Class List</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group ">
                                <asp:GridView ID="gvClass" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" OnRowCommand="gvClass_RowCommand">
                                    <Columns>
                            <asp:TemplateField HeaderText="Class Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblClass" runat="server" Text='<%# Eval("ClassName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                                      
                                        <asp:TemplateField HeaderText="Action" >
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/assets/site/images/ico_information.png" Width="25px" CommandName="editc" CommandArgument='<%# Container.DataItemIndex %>' />
                                                <asp:ImageButton ID="imgdelete" runat="server" ImageUrl="~/assets/img/cancel.png" Width="25px" CommandName="deletec" CommandArgument='<%# Container.DataItemIndex %>' />
                                                <asp:HiddenField ID="hdnClsId" runat="server" Value='<%# Eval("ClassId") %>' />
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
