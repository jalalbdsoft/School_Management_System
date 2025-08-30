<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ClassSchedule.aspx.cs" Inherits="SchoolManagementSystem.Setup.ClassSchedule" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="container">
            <!-- general form elements -->
            <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Class Schedule</h3>
                </div>

                <uc1:ResponseMessage runat="server" ID="rmMsg" />

                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="row">


                        <div class="col-md-3">
                            <div class="form-group ">
                                <label class="form-label">Shift</label>
                                <asp:DropDownList ID="ddlShift" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">Select--</asp:ListItem>
                                    <asp:ListItem>Morning</asp:ListItem>
                                    <asp:ListItem>Day</asp:ListItem>

                                </asp:DropDownList>
                            </div>

                        </div>
                        <div class="col-md-3">
                            <div class="form-group ">
                                <label class="form-label">Class Name</label>
                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                        </div>

                        <div class="col-md-3">
                            <div class="form-group ">
                                <label class="form-label">Week Day</label>
                                <asp:DropDownList ID="ddlWeek" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">Select--</asp:ListItem>
                                    <asp:ListItem>Saturday</asp:ListItem>
                                    <asp:ListItem>Sunday</asp:ListItem>
                                    <asp:ListItem>Monday</asp:ListItem>
                                    <asp:ListItem>Tuesday</asp:ListItem>
                                    <asp:ListItem>Wednesday</asp:ListItem>
                                    <asp:ListItem>Thursday</asp:ListItem>
                                    <asp:ListItem>Friday</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>
                        <div class="col-md-3">
                            <div class="form-group ">
                                <label class="form-label">Subject Name</label>
                                <asp:DropDownList ID="ddlSubject" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>

                        </div>
                        <div class="col-md-5">
                            <div class="form-group ">
                                <label class="form-label">Start Time</label>
                                <asp:TextBox ID="txtStart" runat="server" TextMode="time" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <div class="col-md-5">
                            <div class="form-group ">
                                <label class="form-label">End Time</label>
                                <asp:TextBox ID="txtEnd" runat="server" TextMode="time" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>

                        <div class="col-md-2">
                            <div class="form-group ">
                                <label class="form-label">&nbsp;</label>
                                <asp:HiddenField ID="hdnUpdateClassScheduleId" runat="server" />
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary form-control" Text="Add" OnClick="btnSave_Click" />
                            </div>

                        </div>
                    </div>


                </div>


            </div>

            <div class="card card-primary">
                <div class="card-header ">
                    <h3 class="card-title text-center">Class Schedule List</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group ">
                                <asp:GridView ID="gvClassSchedule" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped">
                                    <Columns>



                                        <asp:BoundField DataField="Shift" HeaderText="Shift" />
                                        <asp:BoundField DataField="Class" HeaderText="Class Name" />
                                        <asp:BoundField DataField="WeekDay" HeaderText="Week Day" />
                                        <asp:BoundField DataField="Subject" HeaderText="Subject Name" />
                                        <asp:BoundField DataField="StartTime" HeaderText="Start Time" />
                                        <asp:BoundField DataField="EndTime" HeaderText="End Time" />



                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/assets/site/images/ico_information.png" Width="25px" CommandName="editc" CommandArgument='<%# Container.DataItemIndex %>' />
                                                <asp:ImageButton ID="imgdelete" runat="server" ImageUrl="~/assets/img/cancel.png" Width="25px" CommandName="deletec" CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="if ( ! ConfirmationMsg()) return false;" meta:resourcekey="imgDelete" />

                                                <%--<asp:HiddenField ID="hdnShiftId" runat="server" Value='<%# Eval("ShiftId") %>' />--%>
                                                <%--<asp:HiddenField ID="hdnClassId" runat="server" Value='<%# Eval("ClassId") %>' />
                                                <asp:HiddenField ID="hdnSubjectId" runat="server" Value='<%# Eval("SubjectId") %>' />--%>

                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-5">
                        </div>
                        <div class="col-md-5">
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary form-control" Text="Submit" OnClick="btnSubmit_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
