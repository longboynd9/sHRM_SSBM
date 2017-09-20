<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TinhTangCa.aspx.cs" Inherits="iHRM.WebPC.Cpanel.QuetThe.TinhTangCa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <link href="/sHRM/Styles/css/ext.css" rel="stylesheet" />
    <script src="/Cpanel/Lng/language.js"></script>

    <script type="text/javascript">

        function OpenEditor(id, title) {
            parent.CreateWin('Employee_Editor', "/Cpanel/Employee/Editor.aspx" + (id == '' ? '' : ('?id=' + id)), title, 800, 500);
        }

        function grd_cmd(cmdName, record, rowIdx, colIdx) {
            if (cmdName == 'Delete') {
                //Ext.Msg.show({
                //    icon: Ext.MessageBox.QUESTION,
                //    msg: 'Bạn chắc chắn muốn xóa?',
                //    buttons: Ext.Msg.OKCANCEL
                //});

                return confirm(LngGet("Lng.QuetThe_TinhTangCa.msg_js3"));
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
                            <ext:RecordField Name="idx" />
                            <ext:RecordField Name="thoiGian" />
                            <ext:RecordField Name="heSoLuong" />
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
                                <ext:Column Header="#QuetThe_TinhTangCa.tt" DataIndex="idx" />
                                <ext:Column Header="#QuetThe_TinhTangCa.tg" DataIndex="thoiGian" />
                                <ext:Column Header="#QuetThe_TinhTangCa.heso" DataIndex="heSoLuong" />

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
            <ext:Window ID="editor" runat="server" Layout="FitLayout" Width="310" Height="140" Title="#QuetThe_TinhTangCa.title" Icon="RecordBlue" Hidden="true">
                <Items>
                    <ext:FormPanel ID="frmEditor" runat="server" Layout="FormLayout" Padding="10" Border="false" LabelWidth="55">
                        <Items>
                            <ext:NumberField runat="server" DataIndex="idx" FieldLabel="#QuetThe_TinhTangCa.thutu" Width="70" AllowBlank="false" />
                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:TimeField runat="server" DataIndex="thoiGian" FieldLabel="#QuetThe_TinhTangCa.tugio" Format="HH:mm" Flex="1" AllowBlank="false" />
                                    <ext:Label runat="server" Text="Hệ số (%): " />
                                    <ext:NumberField runat="server" DataIndex="heSoLuong" Format="0.0" Flex="1" AllowBlank="false" />
                                </Items>
                            </ext:CompositeField>

                        </Items>
                    </ext:FormPanel>
                </Items>
                <Buttons>
                    <ext:Button ID="btnDangKy" runat="server" Text="#QuetThe_TinhTangCa.xacnhan">
                        <Listeners>
                            <Click Handler="if (!#{frmEditor}.getForm().isValid()){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: '#QuetThe_TinhTangCa.msg_js', buttons:Ext.Msg.OK}); return false;}" />
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
