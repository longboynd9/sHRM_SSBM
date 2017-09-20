<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoaiNgayLamThem.aspx.cs" Inherits="iHRM.WebPC.Cpanel.QuetThe.LoaiNgayLamThem" %>

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

                return confirm("#QuetThe_LoaiNgayLamThem.msg_js3");
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
                            <ext:RecordField Name="tenLoai" />
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

<%--                                    <ext:Button runat="server" Text="Thêm mới" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{editor}.show(); #{frmEditor}.reset(); #{h_id}.setValue('');" />
                                        </Listeners>
                                    </ext:Button>--%>

                                </Items>
                            </ext:Toolbar>
                        </TopBar>

                        <ColumnModel>
                            <Columns>
                                <ext:Column Header="#QuetThe_LoaiNgayLamThem.tenloai" DataIndex="tenLoai" />
                                <ext:Column Header="#QuetThe_LoaiNgayLamThem.heso" DataIndex="heSoLuong" />

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
            <ext:Window ID="editor" runat="server" Layout="FitLayout" Width="310" Height="140" Title="#QuetThe_LoaiNgayLamThem.title" Icon="RecordBlue" Hidden="true">
                <Items>
                    <ext:FormPanel ID="frmEditor" runat="server" Layout="FormLayout" Padding="10" Border="false" LabelWidth="55">
                        <Items>

                            <ext:TextField runat="server" DataIndex="tenLoai" FieldLabel="#QuetThe_LoaiNgayLamThem.tenloai" AnchorHorizontal="100%" AllowBlank="false" ReadOnly="true" />
                            <ext:NumberField runat="server" DataIndex="heSoLuong" FieldLabel="#QuetThe_LoaiNgayLamThem.hsluong" Format="0.0" AnchorHorizontal="100%" AllowBlank="false" />

                        </Items>
                    </ext:FormPanel>
                </Items>
                <Buttons>
                    <ext:Button ID="btnDangKy" runat="server" Text="#QuetThe_LoaiNgayLamThem.titleMsg">
                        <Listeners>
                            <Click Handler="if (!#{frmEditor}.getForm().isValid()){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: '#QuetThe_LoaiNgayLamThem.msg_js', buttons:Ext.Msg.OK}); return false;}" />
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
