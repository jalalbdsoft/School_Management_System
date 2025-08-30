<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Designation.aspx.cs" Inherits="SchoolManagementSystem.Setup.Designation" %>

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
                <h3 class="card-title">Designation Info</h3>
              </div>
                
                <uc1:ResponseMessage runat="server" ID="rmMsg" />
              <!-- /.card-header -->
              <!-- form start -->

                <div class="card-body">
                    <div class="row">
                        
                        <div class="col-md-5">
                            <div class="form-group ">
                                <label class="form-label">Designation Name</label>
                                <asp:TextBox ID="txtDesignaiton" runat="server" placeholder="Enter category" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <div class="col-md-5">
                            <div class="form-group ">
                                <label class="form-label">Position</label>
                                <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">Select--</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>
                        <div class="col-md-5">
                            <div class="form-group ">
                                <label class="form-label">Is Active</label>
                                <asp:CheckBox ID="chkIsActive" CssClass="form-control" runat="server" />
                                   
                                
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group ">
                                <label class="form-label" > &nbsp;</label>
                                <asp:HiddenField ID="hdnUpdateDesignationId" runat="server" />
                                 <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary form-control" Text="Save" OnClick="btnSave_Click"  />
                            </div>

                        </div>
                    </div>

               
                </div>
              
                
            </div>

            <div class="card card-primary">
             <div class="card-header ">
                    <h3 class="card-title text-center">Designation List</h3>
                </div>
               <div class="card-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group ">
                                <asp:GridView ID="gvDesignation" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" OnRowCommand="gvDesignation_RowCommand" >
                                    <Columns>
                                        
                                         
                            <asp:TemplateField HeaderText="Designation Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignationName" runat="server" Text='<%# Eval("DesignationName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Position">
                                <ItemTemplate>
                                    <asp:Label ID="lblPosition" runat="server" Text='<%# Eval("Position") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Is Active">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkIsActive1" runat="server"  Checked='True' />
                                </ItemTemplate> 
                            </asp:TemplateField>

                                      
                                        <asp:BoundField DataField="UserName" HeaderText="User Name" />
                                        <asp:TemplateField HeaderText="Action" >
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/assets/site/images/ico_information.png" Width="25px" CommandName="editc" CommandArgument='<%# Container.DataItemIndex %>' />
                                                <asp:ImageButton ID="imgdelete" runat="server" ImageUrl="~/assets/img/cancel.png" Width="25px" CommandName="deletec" CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="if ( ! ConfirmationMsg()) return false;" meta:resourcekey="imgDelete"  />
                                                <asp:HiddenField ID="hdnDesignationId" runat="server" Value='<%# Eval("DesignationId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                   
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>    
    </div>
    </div>
     
</asp:Content>
