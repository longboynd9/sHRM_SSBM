<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NgayNghiNam.aspx.cs" Inherits="iHRM.WebPC.Cpanel.QuetThe.NgayNghiNam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <link href="/sHRM/Styles/css/ext.css" rel="stylesheet" />

    <script type="text/javascript">

        function grd_cmd(cmdName, record, rowIdx, colIdx) {
            if (cmdName == 'Delete') {
                //Ext.Msg.show({
                //    icon: Ext.MessageBox.QUESTION,
                //    msg: 'Bạn chắc chắn muốn xóa?',
                //    buttons: Ext.Msg.OKCANCEL
                //});

                return confirm("#QuetThe_NgayNghiNam.msg_js3");
            }
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
                            <ext:RecordField Name="ngay" />
                            <ext:RecordField Name="ten" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>

            <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout" HideBorders="true" AutoScroll="true">
                <Items>

                    <ext:GridPanel ID="GridPanel1" runat="server" Border="false" StoreID="Store1" Region="Center">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>

                                    <ext:Button runat="server" Text="#common_btn.AddNew" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{editor}.show(); #{frmEditor}.reset(); #{h_id}.setValue('');" />
                                        </Listeners>
                                    </ext:Button>

                                </Items>
                            </ext:Toolbar>
                        </TopBar>

                        <ColumnModel>
                            <Columns>
                                <ext:Column Header="#QuetThe_NgayNghiNam.ngay" DataIndex="ngay" />
                                <ext:Column Header="#QuetThe_NgayNghiNam.ten" DataIndex="ten" />

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

                    </ext:GridPanel>

                </Items>
            </ext:Viewport>

            <ext:Hidden ID="h_id" runat="server" />
            <ext:Window ID="editor" runat="server" Layout="FitLayout" Width="310" Height="140" Title="#QuetThe_NgayNghiNam.ngaynghinam" Icon="RecordBlue" Hidden="true">
                <Items>
                    <ext:FormPanel ID="frmEditor" runat="server" Layout="FormLayout" Padding="10" Border="false" LabelWidth="55">
                        <Items>

                            <ext:CompositeField runat="server" AnchorHorizontal="100%">
                                <Items>
                                    <ext:ComboBox runat="server" DataIndex="ngay" FieldLabel="Ngày" AllowBlank="false" Flex="1">
                                        <Items>
                                            <ext:ListItem Text="1" Value="1" />
                                            <ext:ListItem Text="2" Value="2" />
                                            <ext:ListItem Text="3" Value="3" />
                                            <ext:ListItem Text="4" Value="4" />
                                            <ext:ListItem Text="5" Value="5" />
                                            <ext:ListItem Text="6" Value="6" />
                                            <ext:ListItem Text="7" Value="7" />
                                            <ext:ListItem Text="8" Value="8" />
                                            <ext:ListItem Text="9" Value="9" />
                                            <ext:ListItem Text="10" Value="10" />
                                            <ext:ListItem Text="11" Value="11" />
                                            <ext:ListItem Text="12" Value="12" />
                                            <ext:ListItem Text="13" Value="13" />
                                            <ext:ListItem Text="14" Value="14" />
                                            <ext:ListItem Text="15" Value="15" />
                                            <ext:ListItem Text="16" Value="16" />
                                            <ext:ListItem Text="17" Value="17" />
                                            <ext:ListItem Text="18" Value="18" />
                                            <ext:ListItem Text="19" Value="19" />
                                            <ext:ListItem Text="20" Value="20" />
                                            <ext:ListItem Text="21" Value="21" />
                                            <ext:ListItem Text="22" Value="22" />
                                            <ext:ListItem Text="23" Value="23" />
                                            <ext:ListItem Text="24" Value="24" />
                                            <ext:ListItem Text="25" Value="25" />
                                            <ext:ListItem Text="26" Value="26" />
                                            <ext:ListItem Text="27" Value="27" />
                                            <ext:ListItem Text="28" Value="28" />
                                            <ext:ListItem Text="29" Value="29" />
                                            <ext:ListItem Text="30" Value="30" />
                                            <ext:ListItem Text="31" Value="31" />
                                        </Items>
                                    </ext:ComboBox>
                                    <ext:Label runat="server" Text="#QuetThe_NgayNghiNam.thang" />
                                    <ext:ComboBox runat="server" DataIndex="thang" FieldLabel="" AllowBlank="false" Flex="1">
                                        <Items>
                                            <ext:ListItem Text="1" Value="1" />
                                            <ext:ListItem Text="2" Value="2" />
                                            <ext:ListItem Text="3" Value="3" />
                                            <ext:ListItem Text="4" Value="4" />
                                            <ext:ListItem Text="5" Value="5" />
                                            <ext:ListItem Text="6" Value="6" />
                                            <ext:ListItem Text="7" Value="7" />
                                            <ext:ListItem Text="8" Value="8" />
                                            <ext:ListItem Text="9" Value="9" />
                                            <ext:ListItem Text="10" Value="10" />
                                            <ext:ListItem Text="11" Value="11" />
                                            <ext:ListItem Text="12" Value="12" />
                                        </Items>
                                    </ext:ComboBox>
                                    <ext:Label runat="server" Text="#QuetThe_NgayNghiNam.nam" />
                                    <ext:NumberField runat="server" DataIndex="nam" FieldLabel="" Flex="1" />
                                </Items>
                            </ext:CompositeField>

                            <ext:TextField runat="server" DataIndex="ten" FieldLabel="#QuetThe_NgayNghiNam.ten" Format="0.0" AnchorHorizontal="100%" AllowBlank="false" />

                        </Items>
                    </ext:FormPanel>
                </Items>
                <Buttons>
                    <ext:Button ID="btnDangKy" runat="server" Text="#QuetThe_NgayNghiNam.xacnhan">
                        <Listeners>
                            <Click Handler="if (!#{frmEditor}.getForm().isValid()){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: '#QuetThe_NgayNghiNam.msg_js', buttons:Ext.Msg.OK}); return false;}" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnDangKy_DirectClick">
                                <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="editor" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:Window>

        </div>

    </form>
</body>
</html>
