<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DKCaMacDinh.aspx.cs" Inherits="iHRM.WebPC.Cpanel.QuetThe.DKCaMacDinh" %>

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

        function txtMa_KeyDown3(sender, e) {
            if (e.getKey() == 13)
                btnTim2.fireEvent('click');
        }

        function grd_cmd(cmdName, record, rowIdx, colIdx) {
            if (cmdName == 'Edit') {
                OpenEditor(record.id, LngGet('Lng.QuetThe_DKCaLam.msg_js2') + record.id);
            }
            else if (cmdName == 'Delete') {
                //Ext.Msg.show({
                //    icon: Ext.MessageBox.QUESTION,
                //    msg: 'Bạn chắc chắn muốn xóa?',
                //    buttons: Ext.Msg.OKCANCEL
                //});

                return confirm(LngGet('Lng.QuetThe_DKCaLam.msg_js3'));
            }
        }

    </script>

    <script src="/Assets/js/jquery-1.9.1.js"></script>
    <script src="/Cpanel/Lng/language.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            Ext.onReady(function () {
                Ext.Ajax.timeout = 1000000;
            });
        });
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
            <ext:Store ID="Store1" runat="server">
                <Reader>
                    <ext:JsonReader IDProperty="id">
                        <Fields>
                            <ext:RecordField Name="EmployeeID" />
                            <ext:RecordField Name="IDCard" />
                            <ext:RecordField Name="PosName" />
                            <ext:RecordField Name="DepName" />
                            <ext:RecordField Name="EmployeeName" />

                            <ext:RecordField Name="calam" />
                            <ext:RecordField Name="heSoLuong" Type="Int" />
                            <ext:RecordField Name="chuNhat" Type="Boolean" />
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
                            <ext:TextField ID="txtSearchKey" runat="server" FieldLabel="#QuetThe_DKCaLam.lbTuKhoa" AnchorHorizontal="100%" Note="" NoteAlign="Down"></ext:TextField>
                            
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

                                    <ext:Button runat="server" Text="#QuetThe_DKCaLam.DKCaNhan" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{editor}.show(); #{txtNhanVien}.setValue(#{txtSearchKey}.getValue());" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button runat="server" Text="#QuetThe_DKCaLam.DKTapThe" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{WdkTapThe}.show();" />
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
                                <ext:Column Header="#QuetThe_DKCaLam.lamca" DataIndex="calam" />
                                <ext:NumberColumn Header="HSL" DataIndex="heSoLuong" Format="0.0" />
                                <ext:CheckColumn Header="Chủ nhật" DataIndex="chuNhat" />
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
                                EmptyMsg="#QuetThe_DKCaLam.emptmsg">
                                <Items>
                                    <ext:Label ID="Label1" runat="server" Text="#QuetThe_DKCaLam.kichthuoctrang" />
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

            <ext:Window ID="editor" runat="server" Layout="FitLayout" Width="450" Height="220" Title="#QuetThe_DKCaLam.titleDKCL" Icon="RecordBlue" Hidden="true">
                <Items>
                    <ext:FormPanel ID="frmEditor" runat="server" Layout="FormLayout" Padding="10" Border="false">
                        <Items>
                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:TextField ID="txtNhanVien" runat="server" FieldLabel="#QuetThe_DKCaLam.maNV" Width="120" AllowBlank="false" MaxLength="15" MaskRe="[^<>&amp;*]" IndicatorIcon="Information" IndicatorTip="EmployeeID" EnableKeyEvents="true">
                                        <Listeners>
                                            <KeyDown Fn="txtMa_KeyDown" />
                                        </Listeners>
                                    </ext:TextField>
                                    <ext:DisplayField runat="server" Width="30" />
                                    <ext:Button ID="btnFindMaVN" runat="server" OnDirectClick="btnFindMaVN_DirectClick" Icon="Zoom" Text="#common_btn.FindOne" />
                                </Items>
                            </ext:CompositeField>
                            <ext:TextField ID="txtNhanVien2" runat="server" FieldLabel="#QuetThe_DKCaLam.nv" AnchorHorizontal="100%" ReadOnly="true" />

                            <ext:ComboBox ID="cmbCaLam" runat="server" FieldLabel="#QuetThe_DKCaLam.lamca" DisplayField="ten" ValueField="id" 
                                AnchorHorizontal="100%" AllowBlank="false" StoreID="stoCaLam" Editable="false">
                            </ext:ComboBox>
                            <ext:NumberField ID="txtHSL" runat="server" FieldLabel="HS lương" AnchorHorizontal="100%" />
                            <ext:Checkbox ID="txtCN" runat="server" FieldLabel="là CN" AnchorHorizontal="100%" />
                        </Items>
                    </ext:FormPanel>
                </Items>
                <Buttons>
                    <ext:Button ID="btnDangKy" runat="server" Text="#QuetThe_DKCaLam.dangky">
                        <Listeners>
                            <Click Handler="if (!#{frmEditor}.getForm().isValid()){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: '#QuetThe_DKCaLam.msg_js', buttons:Ext.Msg.OK}); return false;}" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnDangKy_DirectClick">
                                <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="editor" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:Window>



            <ext:Window ID="WdkTapThe" runat="server" Layout="FitLayout" Width="450" Height="220" Title="#QuetThe_DKCaLam.titleDKTapThe" Icon="RecordBlue" Hidden="true">
                <Items>
                    <ext:FormPanel ID="FormPanel1" runat="server" Layout="FormLayout" Padding="10" Border="false">
                        <Items>
                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:TextField ID="txtMaTo" runat="server" FieldLabel="#QuetThe_DKCaLam.CodeTapThe" Width="100" AllowBlank="false" MaxLength="15" MaskRe="[^<>&amp;*]" EnableKeyEvents="true">
                                        <Listeners>
                                            <KeyDown Fn="txtMa_KeyDown2" />
                                        </Listeners>
                                    </ext:TextField>
                                    <ext:Button ID="btnTim" runat="server" Text="#common_btn.FindOne" OnDirectClick="btnTim_TapThe" />
                                </Items>
                            </ext:CompositeField>
                            <ext:Label ID="txtTo" runat="server" FieldLabel="#QuetThe_DKCaLam.to" AnchorHorizontal="100%" />
                            
                            <ext:ComboBox ID="cmbCaLam2" runat="server" FieldLabel="#QuetThe_DKCaLam.lamca" DisplayField="ten" ValueField="id" AnchorHorizontal="100%" 
                                AllowBlank="false" StoreID="stoCaLam" Editable="false">
                            </ext:ComboBox>
                            <ext:NumberField ID="txtHSL2" runat="server" FieldLabel="HS lương" AnchorHorizontal="100%" />
                            <ext:Checkbox ID="txtCN2" runat="server" FieldLabel="là CN" AnchorHorizontal="100%" />
                        </Items>
                    </ext:FormPanel>
                </Items>
                <Buttons>
                    <ext:Button ID="Button1" runat="server" Text="#QuetThe_DKCaLam.dangky">
                        <Listeners>
                            <Click Handler="if (!#{FormPanel1}.getForm().isValid()){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: '#QuetThe_DKCaLam.msg_js', buttons:Ext.Msg.OK}); return false;}" />
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
            <ext:Window ID="ChooseDep" runat="server" Layout="FitLayout" AutoScroll="true" Width="500" Height="350" Hidden="true" Title="Chọn phòng ban">
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
                    <ext:Button ID="btnChooseDep" runat="server" Icon="Tick" Text="#QuetThe_DKCaLam.chon" OnDirectClick="btnChon_DirectClick">
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

                            <ext:ComboBox ID="cmbCaLam3" runat="server" FieldLabel="#QuetThe_DKCaLam.lamca" DisplayField="ten" ValueField="id" AnchorHorizontal="100%" 
                                AllowBlank="false" StoreID="stoCaLam" Editable="false">
                            </ext:ComboBox>
                            <ext:NumberField ID="txtHSL3" runat="server" FieldLabel="HS lương" AnchorHorizontal="100%" />
                            <ext:Checkbox ID="txtCN3" runat="server" FieldLabel="là CN" AnchorHorizontal="100%" />
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
