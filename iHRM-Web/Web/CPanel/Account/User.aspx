<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Account.User" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    
    <script type="text/javascript" src="/Cpanel/Skins/Js/jquery-1.9.0.js"></script>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />

    <style type="text/css">

    </style>
    
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <script type="text/javascript">
        function Store1_UpdateRecord(id, record) {
            record = JSON.parse(record);
            var r = Store1.getById(id);
            if (r == undefined) {
                alert("Can't find record [" + id + "]");
                return;
            }
            r.set('linkID', record.linkID);
            r.set('roleID', record.roleID);
            r.set('loginID', record.loginID);
            r.set('caption', record.caption);
            r.set('isAdmin', record.isAdmin);

            Store1.commitChanges();
        }

        function grp_RendRole(value) { var x = stoRoles.getById(value); return x == undefined ? "-" : x.get("caption"); }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <ext:Store ID="stoRoles" runat="server">
            <Reader>
                <ext:JsonReader IDProperty="id">
                    <Fields>
                        <ext:RecordField Name="id" Type="Int" />
                        <ext:RecordField Name="caption" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        
        <ext:Store ID="Store1" runat="server" OnRefreshData="Store1_OnRefreshData">
            <Reader>
                <ext:JsonReader IDProperty="id">
                    <Fields>

                        <ext:RecordField Name="id" Type="Int" />
                        <ext:RecordField Name="linkID" />
                        <ext:RecordField Name="roleID" />
                        <ext:RecordField Name="loginID" />
                        <ext:RecordField Name="caption" />
                        <ext:RecordField Name="isAdmin" />

                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        
        <ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout" HideBorders="true" AutoScroll="true">
            <Items>
                
                <%-- Danh sách --%>
                <ext:GridPanel ID="grp" runat="server" Icon="User" StripeRows="true" ColumnLines="true" TrackMouseOver="true" StoreID="Store1" AutoExpandColumn="caption">
                    <TopBar>
                        <ext:Toolbar ID="toolbarGrid" runat="server">
                            <Items>

                                <ext:Button ID="btnAdd" Icon="Add" runat="server" Text="Thêm" OnDirectClick="btnAdd_DirectClick" />
                                <ext:ToolbarSpacer Width="20" />
                                <ext:TextField ID="txtSearch" runat="server"  Width="300" EmptyText="Tìm kiếm theo tên đăng nhập, tên hiển thị, Nhóm quyền"></ext:TextField>
                                <ext:Button ID="btnSearch" ClientIDMode="Static" Icon="Zoom" runat="server" Text="Tìm kiếm" OnDirectClick="btnSearch_DirectClick">
                                </ext:Button>

                                
                            </Items>
                        </ext:Toolbar>
                    </TopBar>

                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="40" />
                            <ext:Column Header="Tên đăng nhập" DataIndex="loginID" Width="170" />
                            <ext:Column Header="Tên hiện thị" DataIndex="caption" Width="220" />
                            <ext:Column Header="Nhóm quyền" DataIndex="roleID" Width="170"><Renderer Fn="grp_RendRole" /></ext:Column>
                            <ext:ImageCommandColumn Width="60" Align="Center" Header="#">
                                <Commands>
                                    <ext:ImageCommand CommandName="Edit" Icon="BulletEdit" Style="margin-left:7px !important;" />
                                    <ext:ImageCommand CommandName="Delete" Icon="Delete" Style="margin-left:7px !important;" />
                                </Commands>
                            </ext:ImageCommandColumn>
                        </Columns>
                    </ColumnModel>
                                        
                    <DirectEvents>
                        <Command OnEvent="OnCommand">
                            <EventMask ShowMask="true"></EventMask>
                            <Confirmation BeforeConfirm="if(!(command == 'Delete')) return false;" ConfirmRequest="true"
                                Message="Bạn chắc chắn muốn xóa?" Title="Xác nhận xóa" />
                            <ExtraParams>
                                <ext:Parameter Name="id" Value="record.data.id" Mode="Raw" />
                                <ext:Parameter Name="command123" Value="command" Mode="Raw" />
                            </ExtraParams>
                        </Command>
                        <RowDblClick OnEvent="OnDblClick" >
                            <ExtraParams>
                                <ext:Parameter Name="id" Value="this.selModel.getSelected().id" Mode="Raw" />
                            </ExtraParams>
                        </RowDblClick>
                    </DirectEvents>

                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                    </SelectionModel>

                    <BottomBar>
                        <ext:PagingToolbar ID="pgToolbar"
                            runat="server"
                            PageSize="50"
                            DisplayInfo="true"
                            FirstText="Trang đầu"
                            PrevText="Trang trước"
                            NextText="Trang sau"
                            LastText="Trang cuối"
                            RefreshText="Nạp lại"
                            HideRefresh="true"
                            DisplayMsg="Hiển thị {0} - {1} / {2}"
                            EmptyMsg="Không có bản ghi nào để hiển thị">
                            <Items>
                                <ext:Label ID="Label1" runat="server" Text="Kích thước trang:" />
                                <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                <ext:ComboBox ID="ComboBox1" runat="server" Width="80" Editable="false">
                                    <Items>
                                        <ext:ListItem Text="50" />
                                        <ext:ListItem Text="100" />
                                        <ext:ListItem Text="200" />
                                        <ext:ListItem Text="1000" />
                                    </Items>
                                    <SelectedItem Value="50" />
                                    <Listeners>
                                        <Select Handler="#{pgToolbar}.pageSize = parseInt(this.getValue()); #{pgToolbar}.doLoad();" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:PagingToolbar>
                    </BottomBar>

                    <LoadMask ShowMask="true" />
                </ext:GridPanel>
                
            </Items>
        </ext:Viewport>

        <ext:Hidden ID="hId" runat="server" />
        <ext:Window ID="wEditor" runat="server" Title="User" Icon="Add" Layout="FitLayout"
            Height="300" Width="500"
            ButtonAlign="Right"
            Hidden="true"
            Resizable="true"
            Modal="true">
            <Items>
                <ext:FormPanel ID="formCT" runat="server" ButtonAlign="Right" AutoWidth="true" Border="false" StyleSpec="padding:5px 10px; background: white;">
                    <Defaults>
                        <ext:Parameter Name="Width" Value="350" />
                    </Defaults>
                    <Items>
                        <ext:TextField ID="txtLoginID" DataIndex="loginID" runat="server" FieldLabel="Tên đăng nhập <span class='red'>*</span>" AllowBlank="false" MaxLength="50" MaskRe="[^<>&amp;*]" />
                        <ext:CompositeField ID="CompositeField1" runat="server">
                            <Items>
                                <ext:TextField ID="txtLoginPW" DataIndex="loginPW" runat="server" FieldLabel="Mật khẩu" MaxLength="50" MaskRe="[^<>&amp;*]" InputType="Password" />
                                <ext:Checkbox ID="chkChangePW" runat="server" HideLabel="true" />
                                <ext:DisplayField ID="chkChangePW_text" runat="server" Text="Tick để đổi mật khẩu" />
                            </Items>
                        </ext:CompositeField>
                        <ext:TextField ID="txtCaption" DataIndex="caption" runat="server" FieldLabel="Tên hiển thị" MaxLength="255" MaskRe="[^<>&amp;*]" AllowBlank="false" />
                        <ext:TextField ID="txtEmail" DataIndex="caption" runat="server" FieldLabel="Email" MaxLength="255" MaskRe="[^<>&amp;*]"  AllowBlank="false"  Vtype="email"/>
                        <ext:Checkbox ID="chkIsAdmin" runat="server" FieldLabel="Là quản trị viên" Hidden="true"  ReadOnly="true" />
                        <ext:ComboBox ID="cmbRole" Width="358" DataIndex="roleID" runat="server" FieldLabel="Nhóm quyền" DisplayField="caption" ValueField="id" StoreID="stoRoles">
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Listeners>
                                <Select Handler="this.triggers[0].show();" />
                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:TextArea ID="txtDescription" DataIndex="description" runat="server" FieldLabel="Ghi chú" MaxLength="1000" MaskRe="[^<>&amp;*]" />
                    </Items>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button ID="btnOk" Icon="Disk" runat="server" Text="Lưu" OnDirectClick="btnOk_DirectClick" >
                    <Listeners>
                        <Click Handler="if (#{formCT}.getForm().isValid()==false){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: 'Xin vui lòng điền đủ dữ liệu', buttons:Ext.Msg.OK}); return false;}" />
                    </Listeners>
                </ext:Button>
                <ext:Button ID="btnClear" runat="server" Text="Xóa trắng" Icon="PageWhite">
                    <Listeners>
                        <Click Handler="#{formCT}.getForm().reset();" />
                    </Listeners>
                </ext:Button>
                <ext:Button ID="Button1" runat="server" Text="Đóng" Icon="Cancel">
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
