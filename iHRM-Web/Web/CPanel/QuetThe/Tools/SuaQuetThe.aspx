<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuaQuetThe.aspx.cs" Inherits="iHRM.WebPC.Cpanel.QuetThe.QTTools.SuaQuetThe" %>

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



    </script>

    <style type="text/css">
        .cc1 {
            width: 55px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager ID="ResourceManager1" runat="server" />

            <ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout" HideBorders="true" AutoScroll="true">
                <Items>

                    <ext:Panel runat="server" Border="false" Layout="FitLayout">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>

                                    <ext:Button runat="server" Text="Sửa giờ cá nhân" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{editor}.show(); #{txtNhanVien}.setValue(#{txtSearchKey}.getValue());" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button runat="server" Text="Sửa giờ hàng loạt tập thể" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{WdkTapThe}.show(); #{txtNhanVien}.setValue(#{txtSearchKey}.getValue());" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button runat="server" Text="Sửa giờ hàng loạt theo nhóm" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{WdkNhom1}.show();" />
                                        </Listeners>
                                    </ext:Button>

                                    <ext:ToolbarFill runat="server" />
                                    <ext:Button runat="server" Text="Export" Icon="PageWhite">
                                        <Listeners>
                                            <Click Handler="#{txtLog}.setValue('')" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>

                        <Items>
                            <ext:TextArea ID="txtLog" runat="server" ReadOnly="true" />
                        </Items>
                    </ext:Panel>

                </Items>
            </ext:Viewport>



            <ext:Window ID="editor" runat="server" Layout="FitLayout" Width="450" Height="290" Title="Sửa giờ cá nhân" Icon="RecordBlue" Hidden="true">
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
                                    <ext:TimeField ID="txtTuGio" runat="server" FieldLabel="Quẹt vào" Format="HH:mm" Flex="1">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:TimeField>
                                    <ext:Label runat="server" Text="Quẹt ra" Cls="cc1" />
                                    <ext:TimeField ID="txtDenGio" runat="server" FieldLabel="" Format="HH:mm" Flex="1">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:TimeField>
                                </Items>
                            </ext:CompositeField>

                            <ext:Checkbox ID="chkOnlyNoData" runat="server" FieldLabel="Edit when no data" Checked="true" />

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



            <ext:Window ID="WdkTapThe" runat="server" Layout="FitLayout" Width="450" Height="290" Title="Sửa giờ hàng loạt tập thể" Icon="RecordBlue" Hidden="true">
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
                            <ext:TextField ID="txtTo" runat="server" FieldLabel="#QuetThe_DKVangMat.to" AnchorHorizontal="100%" AllowBlank="false" MaxLength="100" ReadOnly="true" />

                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:DateField ID="txtNgayDK2" runat="server" FieldLabel="#QuetThe_DKVangMat.ngay" Format="dd/MM/yyyy" Flex="1" AllowBlank="false" />
                                    <ext:Label runat="server" Text="#QuetThe_DKVangMat.denNgay" Cls="cc1" />
                                    <ext:DateField ID="txtDenNgayDK2" runat="server" Format="dd/MM/yyyy" Flex="1" />
                                </Items>
                            </ext:CompositeField>

                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:TimeField ID="txtTuGio2" runat="server" FieldLabel="Quẹt vào" Format="HH:mm" Flex="1">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:TimeField>
                                    <ext:Label runat="server" Text="Quẹt ra" Cls="cc1" />
                                    <ext:TimeField ID="txtDenGio2" runat="server" FieldLabel="" Format="HH:mm" Flex="1">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:TimeField>
                                </Items>
                            </ext:CompositeField>

                            <ext:Checkbox ID="chkOnlyNoData2" runat="server" FieldLabel="Edit when no data" Checked="true" />
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



            <ext:Window ID="WdkNhom1" runat="server" Layout="FitLayout" Width="450" Height="240" Title="Sửa giờ hàng loạt theo nhóm" Icon="RecordGreen" Hidden="true">
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
                                    <ext:TimeField ID="txtTuGio3" runat="server" FieldLabel="Quẹt vào" Format="HH:mm" Flex="1">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:TimeField>
                                    <ext:Label runat="server" Text="Quẹt ra" Cls="cc1" />
                                    <ext:TimeField ID="txtDenGio3" runat="server" FieldLabel="" Format="HH:mm" Flex="1">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:TimeField>
                                </Items>
                            </ext:CompositeField>

                            <ext:Checkbox ID="chkOnlyNoData3" runat="server" FieldLabel="Edit when no data" Checked="true" />
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
