<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ClassAssign.aspx.cs" Inherits="SchoolManagementSystem.Setup.SubjectAssign" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="container">
            <!-- general form elements -->
            <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Class Assign Info</h3>
              </div>
                <uc1:responsemessage runat="server" id="rmMsg" />
              <!-- /.card-header -->
              <!-- form start -->

                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Class Name</label>
                                <asp:DropDownList ID="ddlClassName" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Subject Name</label>
                                <asp:DropDownList ID="ddlSubjectName" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>

                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Teacher Name</label>
                                <asp:DropDownList ID="ddlTeacherName" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>

                        </div>
                        
                    </div>
                    <div class="row">  
                       <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Start Time</label>
                                <asp:TextBox ID="txtStartTime" runat="server" TextMode="Time" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                         <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">End Time</label>
                         <asp:TextBox ID="txtEndTime" runat="server" TextMode="Time" CssClass="form-control"></asp:TextBox>

                            </div>

                        </div>
                        <div class="col-md-2">
                            <div class="form-group ">
                                <label class="form-label" > &nbsp;</label>
                                <asp:HiddenField ID="hdnUpdateSubCatId" runat="server" />
                                 <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary form-control" Text="Save" OnClick="btnSave_Click" />
                            </div>

                        </div>
                    </div>

               
                </div>
              
                <div class="card-header ">
                    <h3 class="card-title text-center">Class Assign List</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group ">
                                <asp:GridView ID="gvSubCategory" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" OnRowCommand="gvCategory_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="ClassName" HeaderText="Class Name" />
                                        <asp:BoundField DataField="SubjectName" HeaderText="Subject Name" />
                                        <asp:BoundField DataField="TeacherName" HeaderText="Teacher Name" />
                                        <asp:BoundField DataField="UserName" HeaderText="User Name" />
                                        <asp:BoundField DataField="IsActive" HeaderText="Is Active" />
                                        
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>        
                                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/assets/site/images/ico_information.png" Width="25px" CommandName="editc" CommandArgument='<%# Container.DataItemIndex %>' />
                                                <asp:ImageButton ID="imgdelete" runat="server" ImageUrl="~/assets/img/cancel.png" Width="25px" CommandName="deletec" CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="if ( ! ConfirmationMsg()) return false;" meta:resourcekey="imgDelete" />
                                                <asp:HiddenField ID="hdnClassAssignId" runat="server" Value='<%# Eval("ClassAssignId") %>' />
                                                
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
