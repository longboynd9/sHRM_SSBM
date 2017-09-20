<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User2Roles.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Account.User2Roles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    
    <script type="text/javascript" src="/Cpanel/Skins/Js/jquery-1.9.0.js"></script>
    <script type="text/javascript" src="/Cpanel/Skins/Js/BitHelper.js"></script>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <script type="text/javascript">

        function test(p1, p2, p3) {
            console.log(p1);
            console.log(p2);
            console.log(p3);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        

        <ext:Store ID="stoRole" runat="server" OnRefreshData="stoRole_RefreshData">
            <Reader>
                <ext:JsonReader IDProperty="id">
                    <Fields>
                        <ext:RecordField Name="id" Type="Int" />
                        <ext:RecordField Name="code" />
                        <ext:RecordField Name="caption" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>

        <ext:Store ID="stoUser" runat="server" OnRefreshData="stoUser_RefreshData">
            <Reader>
                <ext:JsonReader IDProperty="id">
                    <Fields>
                        <ext:RecordField Name="id" />
                        <ext:RecordField Name="loginID" />
                        <ext:RecordField Name="caption" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>



        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout" HideBorders="true" AutoScroll="true">
            <Items>

                <ext:Panel ID="Panel1" runat="server" Region="West" Width="200" Layout="FitLayout" Border="false" Title="Nhóm quyền" Icon="Table" Split="true">
                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <ext:Button ID="Button1" Icon="ArrowRefresh" runat="server" Text="Lấy dl mới nhất">
                                    <Listeners>
                                        <Click Handler="#{grdRoles}.reload();" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <Items>
                        <ext:GridPanel ID="grdRoles" runat="server" ColumnLines="true" StoreID="stoRole" AutoScroll="true" Border="false" AutoExpandColumn="caption">
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:Column Header="Tên" DataIndex="code" Width="60" />
                                    <ext:Column Header="Tên hiện thị" DataIndex="caption" />
                                </Columns>
                            </ColumnModel>
                            <Listeners>
                                <CellClick Handler="#{grdUser}.reload()" />
                            </Listeners>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                            </SelectionModel>
                            <LoadMask ShowMask="true" />
                        </ext:GridPanel>
                    </Items>
                </ext:Panel>

                <ext:Panel ID="Panel2" runat="server" Region="Center" Layout="FitLayout" Border="false" Title="Danh sách người dùng thuộc nhóm" Icon="User">
                    <TopBar>
                        <ext:Toolbar ID="toolbarGrid" runat="server">
                            <Items>
                                <ext:Button ID="btnAdd" Icon="Add" runat="server" Text="Thêm người dùng" OnDirectClick="btnAdd_DirectClick" />
                                <ext:Button ID="btnDel" Icon="Delete" runat="server" Text="Bỏ người dùng" OnDirectClick="btnDel_DirectClick">
                                    <DirectEvents>
                                        <Click>
                                            <Confirmation BeforeConfirm="if (grdUser.selModel.getSelected() == undefined) { return false; } return true;" ConfirmRequest="true" Title="Confirm" Message="Bạn có chắc chắn xóa người dùng này khỏi nhóm quyền?" />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                                <ext:ToolbarSeparator Width="10" />
                                <ext:Button ID="Button2" Icon="ArrowRefresh" runat="server" Text="Lấy dữ liệu mới nhất">
                                    <Listeners>
                                        <Click Handler="#{grdUser}.reload();" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>

                    <Items>
                        <ext:GridPanel ID="grdUser" runat="server" ColumnLines="true" StoreID="stoUser" AutoScroll="true" Border="false" AutoExpandColumn="caption" >
                            <ColumnModel ID="ColumnModel2" runat="server">
                                <Columns>
                                    <ext:Column Header="Tên đăng nhập" DataIndex="loginID" Editable="false" />
                                    <ext:Column Header="Tên hiện thị" DataIndex="caption" Editable="false" />
                                </Columns>
                            </ColumnModel>

                            <SelectionModel>
                                <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" />
                            </SelectionModel>
                            <LoadMask ShowMask="true" />
                        </ext:GridPanel>      
                    </Items>
                </ext:Panel>
                
            </Items>
        </ext:Viewport>

        <ext:Hidden ID="hId" runat="server" />
        <ext:Window ID="wEditor" runat="server" Title="Thêm người dùng" Icon="UserAdd" Layout="FitLayout" Width="340" Height="180" Resizable="true" Closable="true" Hidden="true">
            <Items>
                <ext:GridPanel ID="grd_addUser" runat="server" AutoExpandColumn="caption" Border="false">
                    <ColumnModel>
                        <Columns>
                            <ext:Column Header="Tên đăng nhập" DataIndex="loginid" Width="70" Editable="false" />
                            <ext:Column Header="Tên hiện thị" DataIndex="caption" Editable="false" />
                            <ext:Column Header="Đang thuộc nhóm quyền" DataIndex="role" Width="80" Editable="false" />
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:CheckboxSelectionModel ID="CheckboxSelectionModel2" runat="server" />
                    </SelectionModel>
                    <Store>
                        <ext:Store ID="stoAddUser" runat="server">
                            <Reader>
                                <ext:JsonReader IDProperty="id">
                                    <Fields>
                                        <ext:RecordField Name="id" />
                                        <ext:RecordField Name="loginid" />
                                        <ext:RecordField Name="caption" />
                                        <ext:RecordField Name="role" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:GridPanel>
            </Items>
            <Buttons>
                <ext:Button ID="btnOk" Icon="Add" runat="server" Text="Xác nhận" OnDirectClick="btnOk_DirectClick" />
                <ext:Button ID="Button3" runat="server" Text="Đóng" Icon="Cancel">
                    <Listeners>
                        <Click Handler="#{wEditor}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
    </div>
    </form>
</body>
</html>
