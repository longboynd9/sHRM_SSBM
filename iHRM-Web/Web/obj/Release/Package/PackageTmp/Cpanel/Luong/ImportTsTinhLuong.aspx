<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportTsTinhLuong.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Luong.ImportTsTinhLuong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>

    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <script type="text/javascript" src="/Cpanel/Lng/language.js"></script>
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
                //OpenEditor(record.id, LngGet('Lng.Luong_ImportTsTinhLuong.msg_js') + record.id);
            }
            else if (cmdName == 'Delete') {
                //Ext.Msg.show({
                //    icon: Ext.MessageBox.QUESTION,
                //    msg: 'Bạn chắc chắn muốn xóa?',
                //    buttons: Ext.Msg.OKCANCEL
                //});

                return confirm(LngGet('Lng.Luong_ImportTsTinhLuong.msg_js2'));
            }
        }

        function btnDangKy_BeforeDirect() {
            var s = "";
            stoPK.data.items.forEach(function (r) { s += r.data.AllowanceID + '~' + r.data.AllowanceName + '~' + r.data.value + '|'; });
            if (s == "") {
                Ext.Msg.show({ icon: Ext.MessageBox.WARNING, msg: LngGet('Lng.Luong_ImportTsTinhLuong.msg_1'), buttons: Ext.Msg.OK });
                return;
            }
            h_Allowance.setValue(s);
        }

        function btnExecImport_Click() {
            var s = "";
            stoMapping.data.items.forEach(function (r) { if(r.data.c2 != undefined && r.data.c2 != ''){ s += r.data.c1 + ':' + r.data.c2 + ','; } });
            if (s == "") {
                Ext.Msg.show({ icon: Ext.MessageBox.WARNING, msg: LngGet('Lng.Luong_ImportTsTinhLuong.msg_1'), buttons: Ext.Msg.OK });
                return false;
            }
            h_MappingString.setValue(s);
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager ID="ResourceManager1" runat="server" />

            <ext:Store ID="Store1" runat="server">
                <Reader>
                    <ext:JsonReader IDProperty="id">
                        <Fields>
                            <ext:RecordField Name="employeeID" />
                            <ext:RecordField Name="thang" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>

            <ext:Store ID="stoPK" runat="server">
                <Reader>
                    <ext:JsonReader IDProperty="AllowanceID">
                        <Fields>
                            <ext:RecordField Name="AllowanceID" />
                            <ext:RecordField Name="AllowanceName" />
                            <ext:RecordField Name="value" Type="Int" />
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
                            <ext:DateField ID="txtThang" runat="server" FieldLabel="#Luong_ImportTsTinhLuong.thang" AnchorHorizontal="100%" Format="MM/yyyy">
                                <Plugins>
                                    <ext:MonthPicker runat="server" />
                                </Plugins>
                            </ext:DateField>
                            <ext:ComboBox ID="txtDonVi" runat="server" FieldLabel="#Luong_ImportTsTinhLuong.pb" AnchorHorizontal="100%"></ext:ComboBox>
                        </Items>
                    </ext:Panel>

                    <ext:GridPanel ID="GridPanel1" runat="server" Border="false" StoreID="Store1" Region="Center">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>

                                    <ext:Button runat="server" Text="#Luong_ImportTsTinhLuong.dkCN" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{editor}.show(); #{txtNhanVien}.setValue(#{txtSearchKey}.getValue());" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button runat="server" Text="#Luong_ImportTsTinhLuong.dkTH" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{WdkTapThe}.show(); #{txtNhanVien}.setValue(#{txtSearchKey}.getValue());" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarSeparator runat="server" />
                                    <ext:FileUploadField ID="txtUploadExcel" runat="server" ButtonOnly="true" ButtonText="Import excel" Icon="PageExcel">
                                        <DirectEvents>
                                            <FileSelected IsUpload="true" OnEvent="txtUploadExcel_DirectUp" />
                                        </DirectEvents>
                                    </ext:FileUploadField>

                                    <ext:ToolbarFill runat="server" />
                                    <ext:Button runat="server" Text="Export" Icon="PageExcel" OnDirectClick="ExportTsTinhLuong_DirectClick">
                                    </ext:Button>

                                </Items>
                            </ext:Toolbar>
                        </TopBar>

                        <ColumnModel>
                            <Columns>
                                <ext:Column Header="#Luong_ImportTsTinhLuong.maNV" DataIndex="employeeID" />
                                <ext:DateColumn Header="#Luong_ImportTsTinhLuong.thang" DataIndex="thang" Format="MM/yyyy" />

                                <ext:ImageCommandColumn Width="60" Align="Center" Header="#">
                                    <Commands>
                                        <ext:ImageCommand CommandName="Edit" Icon="Pencil" Style="margin-left: 7px !important;" />
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

            <ext:Hidden ID="h_Allowance" runat="server" />
            <ext:Window ID="editor" runat="server" Layout="FitLayout" Width="450" Height="380" Title="#Luong_ImportTsTinhLuong.dkCN" Icon="RecordBlue" Hidden="true">
                <Items>
                    <ext:FormPanel ID="frmEditor" runat="server" Layout="FormLayout" Padding="10" Border="false">
                        <Items>
                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:TextField ID="txtNhanVien" runat="server" FieldLabel="#Luong_ImportTsTinhLuong.maNV" Width="120" AllowBlank="false" MaxLength="15" MaskRe="[^<>&amp;*]" IndicatorIcon="Information" IndicatorTip="EmployeeID" EnableKeyEvents="true">
                                        <Listeners>
                                            <KeyDown Fn="txtMa_KeyDown" />
                                        </Listeners>
                                    </ext:TextField>
                                    <ext:DisplayField runat="server" Width="30" />
                                    <ext:Button ID="btnFindMaVN" runat="server" OnDirectClick="btnFindMaVN_DirectClick" Icon="Zoom" Text="#common_btn.FindOne" />
                                </Items>
                            </ext:CompositeField>
                            <ext:TextField ID="txtNhanVien2" runat="server" FieldLabel="#Luong_ImportTsTinhLuong.nhanvien" AnchorHorizontal="100%" ReadOnly="true" />
                            
                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:DateField ID="txtThangImport" runat="server" FieldLabel="#Luong_ImportTsTinhLuong.thang" Width="100" Format="MM/yyyy">
                                        <Plugins>
                                            <ext:MonthPicker runat="server" />
                                        </Plugins>
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:DateField>
                                    <ext:Label runat="server" Text="Nếu để trỗng thì là PC thường xuyên" />
                                </Items>
                            </ext:CompositeField>

                            <ext:GridPanel ID="grdPK" runat="server" AnchorHorizontal="100%" StoreID="stoPK" Height="220" AutoExpandColumn="AllowanceName">
                                <ColumnModel>
                                    <Columns>
                                        <ext:Column Header="#Luong_ImportTsTinhLuong.phucap" DataIndex="AllowanceName" />
                                        <ext:NumberColumn Header="#Luong_ImportTsTinhLuong.giatri" DataIndex="value" Format="0,0">
                                            <Editor>
                                                <ext:NumberField runat="server" />
                                            </Editor>
                                        </ext:NumberColumn>
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel runat="server" />
                                </SelectionModel>
                            </ext:GridPanel>

                        </Items>
                    </ext:FormPanel>
                </Items>
                <Buttons>
                    <ext:Button ID="btnDangKy" runat="server" Text="#Luong_ImportTsTinhLuong.dangky">
                        <Listeners>
                            <Click Handler="if (!#{frmEditor}.getForm().isValid()){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: LngGet('Lng.Luong_ImportTsTinhLuong.msg_js3'), buttons:Ext.Msg.OK}); return false;}" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnDangKy_DirectClick" Before="btnDangKy_BeforeDirect()" />
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:Window>



            <ext:Window ID="WdkTapThe" runat="server" Layout="FitLayout" Width="450" Height="380" Title="#Luong_ImportTsTinhLuong.dkTH" Icon="RecordBlue" Hidden="true">
                <Items>
                    <ext:FormPanel ID="FormPanel1" runat="server" Layout="FormLayout" Padding="10" Border="false">
                        <Items>
                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:TextField ID="txtMaTo" runat="server" FieldLabel="#Luong_ImportTsTinhLuong.maTH" Width="100" AllowBlank="false" MaxLength="15" MaskRe="[^<>&amp;*]" EnableKeyEvents="true">
                                        <Listeners>
                                            <KeyDown Fn="txtMa_KeyDown2" />
                                        </Listeners>
                                    </ext:TextField>
                                    <ext:Button ID="btnTim" runat="server" Text="#common_btn.FindOne" OnDirectClick="btnTim_TapThe" />
                                </Items>
                            </ext:CompositeField>
                            <ext:TextField ID="txtTo" runat="server" FieldLabel="#Luong_ImportTsTinhLuong.to" AnchorHorizontal="100%" AllowBlank="false" MaxLength="100" ReadOnly="true" />

                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:DateField ID="txtThangImport2" runat="server" FieldLabel="#Luong_ImportTsTinhLuong.thang" Width="100" Format="MM/yyyy">
                                        <Plugins>
                                            <ext:MonthPicker runat="server" />
                                        </Plugins>
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:DateField>
                                    <ext:Label runat="server" Text="Nếu để trỗng thì là PC thường xuyên" />
                                </Items>
                            </ext:CompositeField>

                            <ext:GridPanel ID="grdPK2" runat="server" AnchorHorizontal="100%" StoreID="stoPK" Height="220" AutoExpandColumn="AllowanceName">
                                <ColumnModel>
                                    <Columns>
                                        <ext:Column Header="#Luong_ImportTsTinhLuong.phucap" DataIndex="AllowanceName" />
                                        <ext:NumberColumn Header="#Luong_ImportTsTinhLuong.giatri" DataIndex="value" Format="0,0">
                                            <Editor>
                                                <ext:NumberField runat="server" />
                                            </Editor>
                                        </ext:NumberColumn>
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel runat="server" />
                                </SelectionModel>
                            </ext:GridPanel>
                        </Items>
                    </ext:FormPanel>
                </Items>
                <Buttons>
                    <ext:Button ID="Button1" runat="server" Text="#Luong_ImportTsTinhLuong.dangky">
                        <Listeners>
                            <Click Handler="if (!#{FormPanel1}.getForm().isValid()){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: LngGet('Lng.Luong_ImportTsTinhLuong.msg_js3'), buttons:Ext.Msg.OK}); return false;}" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnDangKyTapThe_DirectClick" Before="btnDangKy_BeforeDirect()" >
                                <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="WdkTapThe" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:Window>

            <ext:Window ID="ChooseDep" runat="server" Layout="FitLayout" AutoScroll="true" Width="450" Height="320" Hidden="true">
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
                    <ext:Button ID="btnChooseDep" runat="server" Icon="Tick" Text="#Luong_ImportTsTinhLuong.chon" OnDirectClick="btnChon_DirectClick">
                    </ext:Button>
                </Buttons>
            </ext:Window>


            <ext:Hidden ID="h_FileAttacked" runat="server" />
            <ext:Hidden ID="h_MappingString" runat="server" />
            <ext:Window ID="wMapping" runat="server" Layout="FitLayout" Width="450" Height="270" Hidden="true" Title="MAPPING">
                <Items>
                    <ext:GridPanel ID="grdMapping" runat="server" Border="false">
                        <Store>
                            <ext:Store ID="stoMapping" runat="server">
                                <Reader>
                                    <ext:JsonReader IDProperty="c1">
                                        <Fields>
                                            <ext:RecordField Name="c1" />
                                            <ext:RecordField Name="c1Text" />
                                            <ext:RecordField Name="c2" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <ColumnModel>
                            <Columns>
                                <ext:Column Header="Column" DataIndex="c1Text" Width="200" />
                                <ext:Column Header="Mapping" DataIndex="c2" Width="200">
                                    <Editor>
                                        <ext:ComboBox runat="server" DisplayField="c1Text" ValueField="c1">
                                            <Store>
                                                <ext:Store ID="stoColMapping" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="c1">
                                                            <Fields>
                                                                <ext:RecordField Name="c1" />
                                                                <ext:RecordField Name="c1Text" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                        </ext:ComboBox>
                                    </Editor>
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                    </ext:GridPanel>
                </Items>
                <TopBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:Label runat="server" Text="#Luong_ImportTsTinhLuong.thangimport" StyleSpec="margin-right:7px;" />

                            <ext:DateField ID="txtThangImportExcel" runat="server" Format="MM/yyyy" Width="75">
                                <plugins>
                                    <ext:MonthPicker runat="server" />
                                </plugins>
                            </ext:DateField>

                            <ext:Button ID="btnExecImport" runat="server" Icon="PlayBlue" Text="Do import" OnDirectClick="btnExecImport_DirectClick" StyleSpec="margin-left:7px;">
                                <listeners>
                                    <Click Fn="btnExecImport_Click" />
                                </listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
            </ext:Window>

        </div>

    </form>
</body>
</html>
