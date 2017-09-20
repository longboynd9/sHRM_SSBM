<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DKVangMat.aspx.cs" Inherits="iHRM.WebPC.Cpanel.QuetThe.DKVangMat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <script type="text/javascript">

        function txtMa_KeyDown(sender, e) {
            if (e.getKey() == 13)
                btnFindMaVN.fireEvent('click');
        }

        function txtMa_KeyDown2(sender, e) {
            if (e.getKey() == 13)
                btnTim.fireEvent('click');
        }

        function grd_cmd(cmdName, record, rowIdx, colIdx) {
            if (cmdName == 'Edit') {
                OpenEditor(record.id, '#QuetThe_DKVangMat.msg_js2' + record.id);
            }
            else if (cmdName == 'Delete') {
                //Ext.Msg.show({
                //    icon: Ext.MessageBox.QUESTION,
                //    msg: 'Bạn chắc chắn muốn xóa?',
                //    buttons: Ext.Msg.OKCANCEL
                //});

                return confirm("#QuetThe_DKVangMat.msg_js3");
            }
        }

        function GenLyDo(value) {
            var x = stoLyDo.getById(value);
            return x == undefined ? "-" : x.get("ten");
        }

        function GenXinNghiBuoi(value) {
            if (value == 1)
                return "Buổi sáng";

            if (value == 2)
                return "Buổi Chiều";

            if (value == 3)
                return "Cả ngày";

            return "-";
        }
    </script>

    <style type="text/css">
        .cc1 { width:55px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager ID="ResourceManager1" runat="server" />
            <ext:Store ID="stoLyDo" runat="server">
                <Reader>
                    <ext:ArrayReader IDProperty="id">
                        <Fields>
                            <ext:RecordField Name="id" />
                            <ext:RecordField Name="ten" />
                        </Fields>
                    </ext:ArrayReader>
                </Reader>
            </ext:Store>
            <ext:Store ID="Store1" runat="server">
                <Reader>
                    <ext:JsonReader IDProperty="id">
                        <Fields>
                            <ext:RecordField Name="ngay" Type="Date" />
                            <ext:RecordField Name="tuGio" />
                            <ext:RecordField Name="denGio" />
                            <ext:RecordField Name="lydo" />
                            <ext:RecordField Name="ghiChu" />
                            <ext:RecordField Name="EmployeeID" />
                            <ext:RecordField Name="coHuongLuong" />
                            <ext:RecordField Name="nghiCaNgay" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>

            <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout" HideBorders="true" AutoScroll="true">
                <Items>

                    <ext:Panel runat="server" Region="West" Border="false" Collapsible="true" Split="true" Width="170" Layout="FormLayout"
                        Padding="10" LabelAlign="Top">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:ToolbarFill runat="server" />
                                    <ext:Button ID="btnSearch" runat="server" Icon="ArrowRefreshSmall" Text="#common_btn.Find">
                                        <DirectEvents>
                                            <Click OnEvent="btnSearch_DirectClick">
                                                <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="GridPanel1" />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Items>
                            <ext:TextField ID="txtSearchKey" runat="server" FieldLabel="#common_btn.lbTuKhoa" AnchorHorizontal="100%" Note="" NoteAlign="Down"></ext:TextField>
                            <ext:DateField ID="txtTuNgay" runat="server" FieldLabel="#common_btn.lbTuNgay" AnchorHorizontal="100%" Format="dd/MM/yyyy">
                            </ext:DateField>
                            <ext:DateField ID="txtDenNgay" runat="server" FieldLabel="#common_btn.lbDenNgay" AnchorHorizontal="100%" Format="dd/MM/yyyy"></ext:DateField>
                            </Items>
                    </ext:Panel>

                    <ext:GridPanel ID="GridPanel1" runat="server" Border="false" StoreID="Store1" Region="Center" AutoExpandColumn="ghiChu">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>

                                    <ext:Button runat="server" Text="#QuetThe_DKVangMat.DKCaNhan" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{editor}.show(); #{txtNhanVien}.setValue(#{txtSearchKey}.getValue());" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button runat="server" Text="#QuetThe_DKVangMat.DKTapThe" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{WdkTapThe}.show(); #{txtNhanVien}.setValue(#{txtSearchKey}.getValue());" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button runat="server" Text="Đăng ký theo nhóm 1" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{WdkNhom1}.show();" />
                                        </Listeners>
                                    </ext:Button>

                                    <ext:ToolbarFill runat="server" />
                                    <ext:Button runat="server" Text="Export" Icon="PageExcel">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>

                        <ColumnModel>
                            <Columns>
                                <ext:Column Header="Mã NV" DataIndex="EmployeeID" Width="50" />
                                <ext:DateColumn Header="Ngày" DataIndex="ngay" Width="100" Format="dd/MM/yyyy" />
                                <ext:Column Header="Xin nghỉ" DataIndex="nghiCaNgay" Width="120"><Renderer Fn="GenXinNghiBuoi" /></ext:Column>
                                <ext:Column Header="Từ giờ" DataIndex="tuGio" Width="70" />
                                <ext:Column Header="Đến giờ" DataIndex="denGio" Width="70" />
                                <ext:Column Header="Lý do" DataIndex="lydo" Width="120"><Renderer Fn="GenLyDo" /></ext:Column>
                                <ext:Column Header="Ghi chú" DataIndex="ghiChu" Width="100" />
                                <ext:Column Header="Có hưởng lương" DataIndex="coHuongLuong" Hidden="true" />
                                <ext:ImageCommandColumn Width="60" Align="Center" Header="#">
                                    <Commands>
                                        <ext:ImageCommand CommandName="Delete" Icon="Delete" Style="margin-left: 7px !important;" />
                                    </Commands>
                                </ext:ImageCommandColumn>
                            </Columns>
                        </ColumnModel>

                        <SelectionModel>
                            <ext:RowSelectionModel runat="server" SingleSelect="false" />
                        </SelectionModel>

                        <Listeners>
                            <Command Fn="grd_cmd" />
                        </Listeners>

                        <DirectEvents>
                            <Command OnEvent="grd_OnCommand">
                                <ExtraParams>
                                    <ext:Parameter Name="id" Value="record.id" Mode="Raw" />
                                    <ext:Parameter Name="command" Value="command" Mode="Raw" />
                                </ExtraParams>
                            </Command>
                        </DirectEvents>
                        <BottomBar>
                            <ext:PagingToolbar ID="pgToolbar" StoreID="Store1"
                                runat="server"
                                PageSize="100"
                                DisplayInfo="true"
                                FirstText="#common_btn.Pagging_FirstText"
                                PrevText="#common_btn.Pagging_PrevText"
                                NextText="#common_btn.Pagging_NextText"
                                LastText="#common_btn.Pagging_LastText"
                                RefreshText="#common_btn.Pagging_RefreshText"
                                HideRefresh="true"
                                DisplayMsg="#common_btn.Pagging_DisplayMsg"
                                EmptyMsg="#common_btn.Pagging_EmptyMsg">
                                <Items>
                                    <ext:Label ID="Label2" runat="server" Text="#common_btn.Pagging_PageSize" />
                                    <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                    <ext:ComboBox runat="server" Width="80" Editable="false">
                                        <Items>
                                            <ext:ListItem Text="10" />
                                            <ext:ListItem Text="50" />
                                            <ext:ListItem Text="100" />
                                            <ext:ListItem Text="500" />
                                        </Items>
                                        <SelectedItem Value="100" />
                                        <Listeners>
                                            <Select Handler="#{pgToolbar}.pageSize = parseInt(this.getValue()); #{pgToolbar}.doLoad();" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Items>
                            </ext:PagingToolbar>
                        </BottomBar>
                    </ext:GridPanel>

                </Items>
            </ext:Viewport>

            <ext:Window ID="editor" runat="server" Layout="FitLayout" Width="450" Height="290" Title="#QuetThe_DKVangMat.DKCaNhan" Icon="RecordBlue" Hidden="true">
                <Items>
                    <ext:FormPanel ID="frmEditor" runat="server" Layout="FormLayout" Padding="10" Border="false">
                        <Items>
                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:TextField ID="txtNhanVien" runat="server" FieldLabel="#QuetThe_DKVangMat.maNV" Width="120" AllowBlank="false" MaxLength="15" MaskRe="[^<>&amp;*]" IndicatorIcon="Information" IndicatorTip="EmployeeID" EnableKeyEvents="true">
                                        <Listeners>
                                            <KeyDown Fn="txtMa_KeyDown" />
                                        </Listeners>
                                    </ext:TextField>
                                    <ext:DisplayField runat="server" Width="30" />
                                    <ext:Button ID="btnFindMaVN" runat="server" OnDirectClick="btnFindMaVN_DirectClick" Icon="Zoom" Text="#common_btn.FindOne" />
                                </Items>
                            </ext:CompositeField>
                            <ext:TextField ID="txtNhanVien2" runat="server" FieldLabel="#QuetThe_DKVangMat.nv" AnchorHorizontal="100%" ReadOnly="true" />
                            
                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:DateField ID="txtNgayDK" runat="server" FieldLabel="#QuetThe_DKVangMat.ngay" Format="dd/MM/yyyy" Flex="1" AllowBlank="false">
                                        <DirectEvents>
                                            <Change OnEvent="txtNgayDK_DirectSelect" />
                                        </DirectEvents>
                                    </ext:DateField>
                                    <ext:Label runat="server" Text="#QuetThe_DKVangMat.denNgay" Cls="cc1" />
                                    <ext:DateField ID="txtDenNgayDK" runat="server" Format="dd/MM/yyyy" Flex="1">
                                        <DirectEvents>
                                            <Change OnEvent="settotalNgayNghi" />
                                        </DirectEvents>
                                    </ext:DateField>
                                </Items>
                            </ext:CompositeField>
                            <ext:TextField FieldLabel="Tổng số ngày" runat="server" ID="txttotalNgayNghi" ReadOnly="true" Width="120" />

                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:ComboBox FieldLabel="Xin nghỉ" runat="server" ID="cmbXinNghi" Editable="false" Width="120">
                                        <Items>
                                            <ext:ListItem Text="Buổi sáng" Value="1" />
                                            <ext:ListItem Text="Buổi Chiều" Value="2" />
                                            <ext:ListItem Text="Cả ngày" Value="3" />
                                        </Items>
                                    </ext:ComboBox>
                                    <ext:Checkbox runat="server" ID="chkTinhChuyenCan" Checked="true" />
                                    <ext:Label runat="server" Text="Có tính chuyên cần" />
                                </Items>
                            </ext:CompositeField>
                            <ext:ComboBox ID="cmbLyDo" runat="server" FieldLabel="Lý do" DisplayField="ten" ValueField="id" AnchorHorizontal="100%" 
                                AllowBlank="false" StoreID="stoLyDo" Editable="false">
                            </ext:ComboBox>
                            <ext:TextArea ID="txtGhiChu" runat="server" FieldLabel="#QuetThe_DKVangMat.lbGhiChu" AnchorHorizontal="100%" Height="45" />
                        </Items>
                    </ext:FormPanel>
                </Items>
                <Buttons>
                    <ext:Button ID="btnDangKy" runat="server" Text="#QuetThe_DKVangMat.dangky">
                        <Listeners>
                            <Click Handler="if (!#{frmEditor}.getForm().isValid()){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: '#QuetThe_DKVangMat.msg_js', buttons:Ext.Msg.OK}); return false;}" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnDangKy_DirectClick">
                                <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="editor" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:Window>

            <ext:Window ID="WdkTapThe" runat="server" Layout="FitLayout" Width="450" Height="290" Title="#QuetThe_DKVangMat.DKTapThe" Icon="RecordBlue" Hidden="true">
                <Items>
                    <ext:FormPanel ID="FormPanel1" runat="server" Layout="FormLayout" Padding="10" Border="false">
                        <Items>
                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:TextField ID="txtMaTo" runat="server" FieldLabel="#QuetThe_DKVangMat.CodeTapThe" Width="100" AllowBlank="false" MaxLength="15" MaskRe="[^<>&amp;*]" EnableKeyEvents="true">
                                        <Listeners>
                                            <KeyDown Fn="txtMa_KeyDown2" />
                                        </Listeners>
                                    </ext:TextField>
                                    <ext:Button ID="btnTim" runat="server" Text="#common_btn.FindOne" OnDirectClick="btnTim_TapThe" />
                                </Items>
                            </ext:CompositeField>
                            <ext:TextField ID="txtTo" runat="server" FieldLabel="#QuetThe_DKVangMat.to" AnchorHorizontal="100%" AllowBlank="false" MaxLength="100" ReadOnly="true"/>

                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:DateField ID="txtNgayDK2" runat="server" FieldLabel="#QuetThe_DKVangMat.ngay" Format="dd/MM/yyyy" Flex="1" AllowBlank="false" />
                                    <ext:Label runat="server" Text="#QuetThe_DKVangMat.denNgay" Cls="cc1" />
                                    <ext:DateField ID="txtDenNgayDK2" runat="server" Format="dd/MM/yyyy" Flex="1" />
                                </Items>
                            </ext:CompositeField>
                            
                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:ComboBox FieldLabel="Xin nghỉ" runat="server" ID="cmbXinNghi2" Editable="false" Width="120">
                                        <Items>
                                            <ext:ListItem Text="Buổi sáng" Value="1" />
                                            <ext:ListItem Text="Buổi Chiều" Value="2" />
                                            <ext:ListItem Text="Cả ngày" Value="3" />
                                        </Items>
                                    </ext:ComboBox>
                                    <ext:Checkbox runat="server" ID="chkTinhChuyenCan2" Checked="true" />
                                    <ext:Label runat="server" Text="Có tính chuyên cần" />
                                </Items>
                            </ext:CompositeField>
                            <ext:ComboBox ID="cmbLyDo2" runat="server" FieldLabel="Lý do" DisplayField="ten" ValueField="id" AnchorHorizontal="100%" 
                                AllowBlank="false" StoreID="stoLyDo" Editable="false">
                            </ext:ComboBox>
                            <ext:TextArea ID="txtGhiChu2" runat="server" FieldLabel="#QuetThe_DKVangMat.lbGhiChu" AnchorHorizontal="100%" Height="45" />
                        </Items>
                    </ext:FormPanel>
                </Items>
                <Buttons>
                    <ext:Button ID="Button1" runat="server" Text="#QuetThe_DKVangMat.dangky">
                        <Listeners>
                            <Click Handler="if (!#{FormPanel1}.getForm().isValid()){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: '#QuetThe_DKVangMat.msg_js', buttons:Ext.Msg.OK}); return false;}" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnDangKyTapThe_DirectClick">
                                <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="WdkTapThe" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:Window>

            <ext:Window ID="ChooseDep" runat="server" Layout="FitLayout" AutoScroll="true" Width="600" Height="450" Hidden="true">
                <Items>
                    <ext:TreePanel ID="TreeFunc" runat="server" Border="false" RootVisible="true" AutoScroll="true">
                        <SelectionModel>
                            <ext:DefaultSelectionModel />
                        </SelectionModel>
                        <LoadMask ShowMask="true" />
                        <DirectEvents>
                            <DblClick OnEvent="btnChon_DirectClick" />
                        </DirectEvents>
                    </ext:TreePanel>
                </Items>
                <Buttons>
                    <ext:Button ID="btnChooseDep" runat="server" Icon="Tick" Text="#QuetThe_DKVangMat.chon" OnDirectClick="btnChon_DirectClick">
                    </ext:Button>
                </Buttons>
            </ext:Window>

            <ext:Window ID="WdkNhom1" runat="server" Layout="FitLayout" Width="450" Height="240" Title="Đăng ký theo nhóm 1" Icon="RecordGreen" Hidden="true">
                <Items>
                    <ext:FormPanel ID="FormPanel2" runat="server" Layout="FormLayout" Padding="10" Border="false">
                        <Items>
                            <ext:ComboBox ID="cmbNhom1" runat="server" FieldLabel="Nhóm 1" Editable="false" DisplayField="gName" ValueField="id">
                                <Store>
                                    <ext:Store ID="StoInGroup1" runat="server">
                                        <Reader>
                                            <ext:JsonReader IDProperty="id">
                                                <Fields>
                                                    <ext:RecordField Name="id" />
                                                    <ext:RecordField Name="gName" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                            </ext:ComboBox>
                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:DateField ID="txtNgayDK3" runat="server" FieldLabel="#QuetThe_DKVangMat.ngay" Format="dd/MM/yyyy" Flex="1" AllowBlank="false" />
                                    <ext:Label runat="server" Text="#QuetThe_DKVangMat.denNgay" Cls="cc1" />
                                    <ext:DateField ID="txtDenNgayDK3" runat="server" Format="dd/MM/yyyy" Flex="1" />
                                </Items>
                            </ext:CompositeField>
                            
                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:ComboBox FieldLabel="Xin nghỉ" runat="server" ID="cmbXinNghi3" Editable="false" Width="120" AllowBlank="false">
                                        <Items>
                                            <ext:ListItem Text="Buổi sáng" Value="1" />
                                            <ext:ListItem Text="Buổi Chiều" Value="2" />
                                            <ext:ListItem Text="Cả ngày" Value="3" />
                                        </Items>
                                    </ext:ComboBox>
                                    <ext:Checkbox runat="server" ID="chkTinhChuyenCan3" Checked="true" />
                                    <ext:Label runat="server" Text="Có tính chuyên cần" />
                                </Items>
                            </ext:CompositeField>

                            <ext:ComboBox ID="cmbLyDo3" runat="server" FieldLabel="Lý do" DisplayField="ten" ValueField="id" AnchorHorizontal="100%" 
                                AllowBlank="false" StoreID="stoLyDo" Editable="false">
                            </ext:ComboBox>
                            <ext:TextArea ID="txtGhiChu3" runat="server" FieldLabel="#QuetThe_DKVangMat.lbGhiChu" AnchorHorizontal="100%" Height="45" />
                        </Items>
                    </ext:FormPanel>
                </Items>
                <Buttons>
                    <ext:Button runat="server" Text="#QuetThe_DKCaLam.dangky">
                        <Listeners>
                            <Click Handler="if (!#{FormPanel2}.getForm().isValid()){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: '#QuetThe_DKCaLam.msg_js', buttons:Ext.Msg.OK}); return false;}" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnDangKyNhom1_DirectClick">
                                <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="WdkNhom1" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:Window>

        </div>

    </form>
</body>
</html>
