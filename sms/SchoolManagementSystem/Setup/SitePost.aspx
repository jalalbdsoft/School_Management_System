<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SitePost.aspx.cs" Inherits="SchoolManagementSystem.Setup.SitePost" %>
<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="container">
            <!-- general form elements -->
            <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Website Post management</h3>
              </div>
                <uc1:responsemessage runat="server" id="rmMsg" />
              <!-- /.card-header -->
              <!-- form start -->

                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">Category</label>
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                       <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">Sub Category</label>
                                <asp:DropDownList ID="ddlSubCategory" runat="server" CssClass="form-control"  ></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-md-12">
                            <div class="form-group ">
                                <label class="form-label">Title</label>
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                       <div class="col-md-12">
                            <div class="form-group ">
                                <label class="form-label">Description</label>
                                 <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                         <div class="col-md-12">
                            <div class="form-group ">
                                <label class="form-label">Short Description</label>
                                 <asp:TextBox ID="txtShortDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">Browse</label>
                                <asp:FileUpload ID="fuImg" runat="server" CssClass="form-control-file" />
                            </div>
                        </div>
                       <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">&nbsp;</label>
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary form-control"  Text="Submit" />
                            </div>
                        </div>
                    </div>
                </div>
              
               
                
            </div>
            <!-- /.card -->
    </div>
     </div>
</asp:Content>
