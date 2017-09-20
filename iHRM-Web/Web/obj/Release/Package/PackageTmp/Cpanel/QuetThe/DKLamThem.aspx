<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DKLamThem.aspx.cs" Inherits="iHRM.WebPC.Cpanel.QuetThe.DKLamThem" %>

<%@ Register Src="../UC/ImageUploader.ascx" TagName="ImageUploader" TagPrefix="uc1" %>

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

        function cmbLoaiNgay_change(sender, e, idx) {
            txtHsLuong.setValue(e.data.heSoLuong);
        }

        function txtMa_KeyDown2(sender, e) {
            if (e.getKey() == 13)
                btnTim.fireEvent('click');
        }

        function cmbLoaiNgay_change2(sender, e, idx) {
            txtHsLuong2.setValue(e.data.heSoLuong);
        }

        function cmbLoaiNgay_change3(sender, e, idx) {
            txtHsLuong3.setValue(e.data.heSoLuong);
        }

        function grd_cmd(cmdName, record, rowIdx, colIdx) {
            if (cmdName == 'Edit') {
                OpenEditor(record.id, '#QuetThe_DKLamThem.msg_js2' + record.id);
            }
            else if (cmdName == 'Delete') {
                //Ext.Msg.show({
                //    icon: Ext.MessageBox.QUESTION,
                //    msg: 'Bạn chắc chắn muốn xóa?',
                //    buttons: Ext.Msg.OKCANCEL
                //});

                return confirm("QuetThe_DKLamThem.msg_js3");
            }
        }

        function txtMa_KeyDown3(sender, e) {
            if (e.getKey() == 13)
                btnTim2.fireEvent('click');
        }

        function GenLyDo(value) {
            var x = stoLoaiNgay.getById(value);
            return x == undefined ? "-" : x.get("tenLoai");
        }
        function GenCaLam(value) {
            var x = stoCaLam.getById(value);
            return x == undefined ? "-" : x.get("ten");
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager ID="ResourceManager1" runat="server" />

            <ext:Store ID="stoCaLam" runat="server">
                <Reader>
                    <ext:JsonReader IDProperty="id">
                        <Fields>
                            <ext:RecordField Name="id" />
                            <ext:RecordField Name="ten" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>

            <ext:Store ID="stoLoaiNgay" runat="server">
                <Reader>
                    <ext:JsonReader IDProperty="id">
                        <Fields>
                            <ext:RecordField Name="id" />
                            <ext:RecordField Name="tenLoai" />
                            <ext:RecordField Name="heSoLuong" Type="Int" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>

            <ext:Store ID="Store1" runat="server">
                <Reader>
                    <ext:JsonReader IDProperty="id">
                        <Fields>
                            <ext:RecordField Name="ngay" Type="Date" />
                            <ext:RecordField Name="calam" />
                            <ext:RecordField Name="EmployeeID" />
                            <ext:RecordField Name="IDCard" />
                            <ext:RecordField Name="PosName" />
                            <ext:RecordField Name="DepName" />
                            <ext:RecordField Name="EmployeeName" />
                            <ext:RecordField Name="dkLamThem" />
                            <ext:RecordField Name="heSoLuong" />
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
                                    <ext:Button ID="btnSearch" runat="server" Icon="ArrowRefreshSmall" Text="#common_btn.Find" OnDirectClick="btnSearch_DirectClick" />
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Items>
                            <ext:TextField ID="txtSearchKey" runat="server" FieldLabel="#common_btn.lbTuKhoa" AnchorHorizontal="100%" Note="" NoteAlign="Down"></ext:TextField>
                            <ext:DateField ID="txtTuNgay" runat="server" FieldLabel="#common_btn.lbTuNgay" AnchorHorizontal="100%" Format="dd/MM/yyyy"></ext:DateField>
                            <ext:DateField ID="txtDenNgay" runat="server" FieldLabel="#common_btn.lbDenNgay" AnchorHorizontal="100%" Format="dd/MM/yyyy"></ext:DateField>
                            
                            <ext:CompositeField runat="server" AnchorHorizontal="100%">
                                <Items>
                                    <ext:TextField ID="txtDeptCodeSearch" runat="server" FieldLabel="#QuetThe_DKCaLam.CodeTapThe" Flex="1" AllowBlank="false" MaxLength="15" MaskRe="[^<>&amp;*]" EnableKeyEvents="true">
                                        <Listeners>
                                            <KeyDown Fn="txtMa_KeyDown3" />
                                        </Listeners>
                                    </ext:TextField>
                                    <ext:Button ID="btnTim2" runat="server" Text="#common_btn.FindOne" OnDirectClick="btnTim2_TapThe" />
                                </Items>
                            </ext:CompositeField>
                            <ext:Label ID="txtDeptNameSearch" runat="server" AnchorHorizontal="100%" HideLabel="true" />
                        </Items>
                    </ext:Panel>

                    <ext:GridPanel ID="GridPanel1" runat="server" Border="false" StoreID="Store1" Region="Center">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>

                                    <ext:Button runat="server" Text="#common_btn.DKCaNhan" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{editor}.show(); #{txtNhanVien}.setValue(#{txtSearchKey}.getValue());" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button runat="server" Text="#common_btn.DKTapThe" Icon="Add">
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
                                <ext:Column Header="Tên NV" DataIndex="EmployeeName" Width="100" />
                                <ext:Column Header="Số CMND" DataIndex="IDCard" Width="70" />
                                <ext:Column Header="Phòng Ban" DataIndex="DepName" Width="120" />
                                <ext:Column Header="Chức vụ" DataIndex="PosName" Width="100" />
                                <ext:DateColumn Header="Ngày đăng ký" DataIndex="ngay" Format="dd/MM/yyyy" />
                                <ext:Column Header="#QuetThe_DKCaLam.lamca" DataIndex="calam" />

                                <ext:Column Header="Lý do" DataIndex="dkLamThem"><Renderer Fn="GenLyDo" /></ext:Column>
                                <ext:NumberColumn Header="HS Lương" DataIndex="heSoLuong" Format="0.0" />

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
                                    <ext:Label ID="Label1" runat="server" Text="#common_btn.Pagging_PageSize" />
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

            <ext:Window ID="editor" runat="server" Layout="FitLayout" Width="420" Height="250" Title="#QuetThe_DKLamThem.titleDKLT" Icon="RecordBlue" Hidden="true">
                <Items>
                    <ext:FormPanel ID="frmEditor" runat="server" Layout="FormLayout" Padding="10" Border="false">
                        <Items>
                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:TextField ID="txtNhanVien" runat="server" FieldLabel="#QuetThe_DKLamThem.maNV" Width="120" AllowBlank="false" MaxLength="15" MaskRe="[^<>&amp;*]" 
                                        IndicatorIcon="Information" IndicatorTip="EmployeeID" EnableKeyEvents="true">
                                        <Listeners>
                                            <KeyDown Fn="txtMa_KeyDown" />
                                        </Listeners>
                                    </ext:TextField>
                                    <ext:DisplayField runat="server" Width="30" />
                                    <ext:Button ID="btnFindMaVN" runat="server" OnDirectClick="btnFindMaVN_DirectClick" Icon="Zoom" Text="#common_btn.FindOne" />
                                </Items>
                            </ext:CompositeField>
                            <ext:TextField ID="txtNhanVien2" runat="server" FieldLabel="#QuetThe_DKLamThem.nv" AnchorHorizontal="100%" ReadOnly="true" />

                            <ext:DateField ID="txtNgayDK" runat="server" FieldLabel="#QuetThe_DKLamThem.ngay" Format="dd/MM/yyyy" AnchorHorizontal="100%" AllowBlank="false" />
                            <ext:ComboBox ID="cmbLoaiNgay" runat="server" FieldLabel="#QuetThe_DKLamThem.loaingay" DisplayField="tenLoai" ValueField="id" AnchorHorizontal="100%" AllowBlank="false" StoreID="stoLoaiNgay" Editable="false">
                                <Listeners>
                                    <Select Fn="cmbLoaiNgay_change" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:NumberField ID="txtHsLuong" runat="server" FieldLabel="#QuetThe_DKLamThem.hsluong" Width="100" AllowBlank="false" />
                            <ext:ComboBox ID="cmbCaLam" runat="server" FieldLabel="#QuetThe_DKLamThem.lamca" DisplayField="ten" ValueField="id" AnchorHorizontal="100%" AllowBlank="false" StoreID="stoCaLam" Editable="false">
                            </ext:ComboBox>
                        </Items>
                    </ext:FormPanel>
                </Items>
                <Buttons>
                    <ext:Button ID="btnDangKy" runat="server" Text="#QuetThe_DKLamThem.dangky">
                        <Listeners>
                            <Click Handler="if (!#{frmEditor}.getForm().isValid()){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: '#QuetThe_DKLamThem.msg_js', buttons:Ext.Msg.OK}); return false;}" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnDangKy_DirectClick">
                                <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="editor" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:Window>



            <ext:Window ID="WdkTapThe" runat="server" Layout="FitLayout" Width="450" Height="250" Title="#QuetThe_DKLamThem.DKTapThe" Icon="RecordBlue" Hidden="true">
                <Items>
                    <ext:FormPanel ID="FormPanel1" runat="server" Layout="FormLayout" Padding="10" Border="false">
                        <Items>
                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:TextField ID="txtMaTo" runat="server" FieldLabel="#QuetThe_DKLamThem.CodeTapThe" Width="100" AllowBlank="false" MaxLength="15" MaskRe="[^<>&amp;*]" EnableKeyEvents="true">
                                        <Listeners>
                                            <KeyDown Fn="txtMa_KeyDown2" />
                                        </Listeners>
                                    </ext:TextField>
                                    <ext:Button ID="btnTim" runat="server" Text="#common_btn.FindOne" OnDirectClick="btnTim_TapThe" />
                                </Items>
                            </ext:CompositeField>
                            <ext:TextField ID="txtTo" runat="server" FieldLabel="#QuetThe_DKLamThem.to" AnchorHorizontal="100%" AllowBlank="false" MaxLength="100" ReadOnly="true"/>

                            <ext:DateField ID="txtNgayDK2" runat="server" FieldLabel="#QuetThe_DKLamThem.ngay" Format="dd/MM/yyyy" AnchorHorizontal="100%" AllowBlank="false" />
                            <ext:ComboBox ID="cmbLoaiNgay2" runat="server" FieldLabel="#QuetThe_DKLamThem.loaingay" DisplayField="tenLoai" ValueField="id" AnchorHorizontal="100%" AllowBlank="false" StoreID="stoLoaiNgay" Editable="false">
                                <Listeners>
                                    <Select Fn="cmbLoaiNgay_change2" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:NumberField ID="txtHsLuong2" runat="server" FieldLabel="#QuetThe_DKLamThem.hsluong" Width="100" AllowBlank="false" />
                            <ext:ComboBox ID="cmbCaLam2" runat="server" FieldLabel="#QuetThe_DKLamThem.lamca" DisplayField="ten" ValueField="id" AnchorHorizontal="100%" AllowBlank="false" StoreID="stoCaLam" Editable="false">
                            </ext:ComboBox>
                        </Items>
                    </ext:FormPanel>
                </Items>
                <Buttons>
                    <ext:Button ID="Button1" runat="server" Text="#QuetThe_DKLamThem.dangky">
                        <Listeners>
                            <Click Handler="if (!#{FormPanel1}.getForm().isValid()){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: '#QuetThe_DKLamThem.msg_js', buttons:Ext.Msg.OK}); return false;}" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnDangKyTapThe_DirectClick">
                                <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="WdkTapThe" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            
            <ext:Hidden ID="ChooseDep_showFor" runat="server" />
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
                    <ext:Button ID="btnChooseDep" runat="server" Icon="Tick" Text="Chọn" OnDirectClick="btnChon_DirectClick">
                    </ext:Button>
                </Buttons>
            </ext:Window>



            <ext:Window ID="WdkNhom1" runat="server" Layout="FitLayout" Width="450" Height="220" Title="Đăng ký theo nhóm 1" Icon="RecordGreen" Hidden="true">
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
                            <ext:DateField ID="txtNgayDK3" runat="server" FieldLabel="#QuetThe_DKLamThem.ngay" Format="dd/MM/yyyy" AnchorHorizontal="100%" AllowBlank="false" />
                            <ext:ComboBox ID="cmbLoaiNgay3" runat="server" FieldLabel="#QuetThe_DKLamThem.loaingay" DisplayField="tenLoai" ValueField="id" AnchorHorizontal="100%" AllowBlank="false" StoreID="stoLoaiNgay" Editable="false">
                                <Listeners>
                                    <Select Fn="cmbLoaiNgay_change3" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:NumberField ID="txtHsLuong3" runat="server" FieldLabel="#QuetThe_DKLamThem.hsluong" Width="100" AllowBlank="false" />
                            <ext:ComboBox ID="cmbCaLam3" runat="server" FieldLabel="#QuetThe_DKLamThem.lamca" DisplayField="ten" ValueField="id" AnchorHorizontal="100%" AllowBlank="false" StoreID="stoCaLam" Editable="false">
                            </ext:ComboBox>
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
