<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Role.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Account.Role1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script type="text/javascript" src="/Cpanel/Skins/Js/jquery-1.9.0.js"></script>
    <script type="text/javascript" src="/Cpanel/Skins/Js/BitHelper.js"></script>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />

    <style type="text/css">
        .nodecode {
            font-weight:bold;
        }
        .nodecaption {
            color:#838383 !important;
        }
        .spacelv1 { width:20px; display:inline-block; }
        .spacelv2 { width:40px; display:inline-block; }
        .spacelv3 { width:60px; display:inline-block; }
        .spacelv4 { width:80px; display:inline-block; }
        .spacelv5 { width:100px; display:inline-block; }
    </style>
    
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <script type="text/javascript">
        function hasFunction(value, col, data) {
            return "<input type='checkbox' value=" + BitHelper.Has(parseInt(value), parseInt(col.id)) + " />";
        }

        var eFunction = { "Custom": 0, "Find": 1, "New": 2, "Edit": 4, "Delete": 8, "Import": 16, "Export": 32, "Print": 64, "Choose": 128, "Save": 256, "Exit": 512 };
        function grid_AfterEdit(d) {
            //console.log(d);

            var record = stoRule.getById(d.record.id);
            switch (d.field) {
                case "rule":
                    record.set('Find', BitHelper.bit_has(d.value, 1));
                    record.set('New', BitHelper.bit_has(d.value, 2));
                    record.set('Edit', BitHelper.bit_has(d.value, 4));
                    record.set('Delete', BitHelper.bit_has(d.value, 8));
                    record.set('Import', BitHelper.bit_has(d.value, 16));
                    record.set('Export', BitHelper.bit_has(d.value, 32));
                    record.set('Print', BitHelper.bit_has(d.value, 64));
                    record.set('Choose', BitHelper.bit_has(d.value, 128));
                    record.set('Save', BitHelper.bit_has(d.value, 256));
                    record.set('Exit', BitHelper.bit_has(d.value, 512));

                    gridRule_changeCel(record, 'Find', d.value);
                    gridRule_changeCel(record, 'New', d.value);
                    gridRule_changeCel(record, 'Edit', d.value);
                    gridRule_changeCel(record, 'Delete', d.value);
                    gridRule_changeCel(record, 'Import', d.value);
                    gridRule_changeCel(record, 'Export', d.value);
                    gridRule_changeCel(record, 'Print', d.value);
                    gridRule_changeCel(record, 'Choose', d.value);
                    gridRule_changeCel(record, 'Save', d.value);
                    gridRule_changeCel(record, 'Exit', d.value);
                    return;
            }

            gridRule_changeCel(record, d.field, d.value);
        }

        function gridRule_changeCel(record, field, value) {
            var v = eFunction[field];
            if (v != undefined && v > 0) {
                record.set('rule', value ? BitHelper.bit_set(record.get('rule'), v) : BitHelper.bit_clear(record.get('rule'), v));

                stoRule.each(function (r) {
                    if (r.get('parentID') == record.get('id')) {
                        r.set(field, value);
                        gridRule_changeCel(r, field, value);
                    }
                });
            }
        }

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
        
        

        <ext:Store ID="stoRole" runat="server">
            <Reader>
                <ext:JsonReader IDProperty="id">
                    <Fields>
                        <ext:RecordField Name="id" Type="Int" />
                        <ext:RecordField Name="code" />
                        <ext:RecordField Name="caption" />
                        <ext:RecordField Name="description" />
                        <ext:RecordField Name="status" Type="Int" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>

        <ext:Store ID="stoRule" runat="server" OnSubmitData="stoRule_SubmitData" OnRefreshData="stoRule_RefreshData">
            <Reader>
                <ext:JsonReader IDProperty="id">
                    <Fields>
                        <ext:RecordField Name="id" />
                        <ext:RecordField Name="parentID" Type="Int" />
                        <ext:RecordField Name="funcName" />
                        <ext:RecordField Name="rule" Type="Int" />

                        <ext:RecordField Name="Find" Type="Boolean" />
                        <ext:RecordField Name="New" Type="Boolean" />
                        <ext:RecordField Name="Edit" Type="Boolean" />
                        <ext:RecordField Name="Delete" Type="Boolean" />
                        <ext:RecordField Name="Import" Type="Boolean" />
                        <ext:RecordField Name="Export" Type="Boolean" />
                        <ext:RecordField Name="Print" Type="Boolean" />
                        <ext:RecordField Name="Choose" Type="Boolean" />
                        <ext:RecordField Name="Save" Type="Boolean" />
                        <ext:RecordField Name="Exit" Type="Boolean" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>



        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout" HideBorders="true" AutoScroll="true">
            <Items>

                <ext:Panel ID="Panel1" runat="server" Region="West" Width="200" Layout="FitLayout" Border="false" Title="Các nhóm quyền" Icon="Table" Split="true">
                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <ext:Button ID="btnAdd" Icon="Add" runat="server" Text="Thêm mới" OnDirectClick="btnAdd_DirectClick" />
                                <ext:Button ID="btnEdit" Icon="Pencil" runat="server" Text="Chỉnh sửa" OnDirectClick="btnEdit_DirectClick" />
                                <ext:Button ID="btnDel" Icon="Delete" runat="server" Text="Xóa">
                                    <DirectEvents>
                                        <Click OnEvent="btnDel_DirectClick">
                                            <Confirmation ConfirmRequest="true" Title="Xác nhận lại" Message="Bạn chắc chắn muốn xóa?" />
                                        </Click>
                                    </DirectEvents>
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

                            <DirectEvents>
                                <Click OnEvent="grdRoles_OnClick" Before="grdRule.loadMask.show();" Complete="grdRule.loadMask.hide();">
                                    <ExtraParams>
                                        <ext:Parameter Name="id" Value="this.selModel.getSelected().id" Mode="Raw" />
                                    </ExtraParams>
                                </Click>
                            </DirectEvents>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                            </SelectionModel>
                            <LoadMask ShowMask="true" />
                        </ext:GridPanel>
                    </Items>
                </ext:Panel>

                <ext:Panel ID="Panel2" runat="server" Region="Center" Layout="FitLayout" Border="false" Title="Các quyền" Icon="TableRow">
                    <TopBar>
                        <ext:Toolbar ID="toolbarGrid" runat="server">
                            <Items>
                                <ext:Button ID="btnAddFunc" Icon="Add" runat="server" Text="Thêm mới" Hidden="true">
                                    <Listeners>
                                        <Click Handler="if (grdRule.selModel.getSelected() == undefined) Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: 'Xin vui lòng chọn rule', buttons:Ext.Msg.OK}); else #{wAddFunc}.show();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="btnDelFunc" Icon="Delete" runat="server" Text="Xóa" Hidden="true">
                                    <DirectEvents>
                                        <Click OnEvent="btnDelFunc_DirectClick">
                                            <Confirmation ConfirmRequest="true" Title="Xác nhận lại" Message="Bạn chắc chắn muốn xóa?" />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>

                                <ext:ToolbarSeparator Width="10" />
                                <ext:Button ID="btnSave" Icon="Disk" runat="server" Text="Lưu">
                                    <Listeners>
                                        <Click Handler="stoRule.each(function(r){ r.set('funcName', ''); }); grdRule.submitData();" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>

                    <Items>
                        <ext:GridPanel ID="grdRule" runat="server" ColumnLines="true" StoreID="stoRule" AutoScroll="true" Border="false" AutoExpandColumn="funcName" Layout="FitLayout" >
                            <ColumnModel ID="ColumnModel2" runat="server">
                                <Columns>
                                    <ext:Column Header="Chức năng" DataIndex="funcName" Editable="false" />
                                    <ext:NumberColumn Header="Rule" Format="0,0" Align="Right" DataIndex="rule" Editable="true" Width="70">
                                        <Editor>
                                            <ext:NumberField ID="NumberField1" runat="server" />
                                        </Editor>
                                    </ext:NumberColumn>
                                    
                                    <ext:CheckColumn Header="Find"   DataIndex="Find"   ColumnID="1"   Editable="true" Width="40" Tooltip="Quyền truy cập" />
                                    <ext:CheckColumn Header="New"    DataIndex="New"    ColumnID="2"   Editable="true" Width="40" Tooltip="Quyền thêm mới" />
                                    <ext:CheckColumn Header="Edit"   DataIndex="Edit"   ColumnID="4"   Editable="true" Width="40" Tooltip="Quyền chỉnh sửa bản ghi" />
                                    <ext:CheckColumn Header="Delete" DataIndex="Delete" ColumnID="8"   Editable="true" Width="40" Tooltip="Quyền xóa" />
                                    <ext:CheckColumn Header="Import" DataIndex="Import" ColumnID="16"  Editable="true" Width="40" Tooltip="Quyền nhập dữ liệu từ file vào" />
                                    <ext:CheckColumn Header="Export" DataIndex="Export" ColumnID="32"  Editable="true" Width="40" Tooltip="Quyền xuất dữ liệu ra các định dạng file" />
                                    <ext:CheckColumn Header="Print"  DataIndex="Print"  ColumnID="64"  Editable="true" Width="40" Tooltip="Quyền in" />
                                    <ext:CheckColumn Header="Choose" DataIndex="Choose" ColumnID="128" Editable="true" Width="40" Tooltip="Quyền tìm kiếm" />
                                    <ext:CheckColumn Header="Save"  DataIndex="Save"    ColumnID="256" Editable="true" Width="40" Tooltip="Lưu" />
                                    <ext:CheckColumn Header="Exit"  DataIndex="Exit"    ColumnID="512" Editable="true" Width="40" Tooltip="Thoát" />
                                </Columns>
                            </ColumnModel>

                            <Listeners>
                                <AfterEdit Fn="grid_AfterEdit" />
                            </Listeners>

                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" SingleSelect="true" />
                            </SelectionModel>
                            <LoadMask ShowMask="true" />
                        </ext:GridPanel>      
                    </Items>
                </ext:Panel>
                
            </Items>
        </ext:Viewport>

        <ext:Hidden ID="hId" runat="server" />
        <ext:Window ID="wEditor" runat="server" Layout="FitLayout" Width="340" Height="180" Resizable="false" Closable="true" Hidden="true">
            <Items>
                <ext:FormPanel ID="formCT" runat="server" Padding="5" Border="false">
                    <Items>
                        <ext:TextField ID="txtCode" runat="server" Width="200" FieldLabel="Tên <span class='red'>*</span>" MaxLength="50" AllowBlank="false" MaskRe="[^<>&amp;*]" />
                        <ext:TextField ID="txtCaption" runat="server" Width="200" FieldLabel="Tên hiện thị <span class='red'>*</span>" MaxLength="255" AllowBlank="false" MaskRe="[^<>&amp;*]" />
                        <ext:TextArea ID="txtDesc" runat="server" Width="200" Height="50" FieldLabel="Ghi chú" MaxLength="1000" MaskRe="[^<>&amp;*]" />
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

        <ext:Window ID="wAddFunc" runat="server" Title="Thêm chức năng" Layout="FitLayout" Width="440" Height="280" Resizable="true" Closable="true" Hidden="true">
            <Items>
                <ext:TreePanel ID="TreeFunc" runat="server" Border="false" AutoScroll="true" RootVisible="false">
                    <SelectionModel>
                        <ext:MultiSelectionModel runat="server" />
                    </SelectionModel>
                    <LoadMask ShowMask="true" />
                </ext:TreePanel>  
            </Items>
            <Buttons>
                <ext:Button ID="btnAddFunc1" Icon="Disk" runat="server" Text="Thêm chức năng" OnDirectClick="btnAddFunc_DirectClick" >
                </ext:Button>
                <ext:Button ID="Button2" runat="server" Text="Đóng" Icon="Cancel">
                    <Listeners>
                        <Click Handler="#{wAddFunc}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
    </div>
    </form>
</body>
</html>
