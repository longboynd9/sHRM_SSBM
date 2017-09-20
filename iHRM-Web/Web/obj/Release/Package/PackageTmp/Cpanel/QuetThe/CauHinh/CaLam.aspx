<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaLam.aspx.cs" Inherits="iHRM.WebPC.Cpanel.QuetThe.CaLam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
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

                return confirm("Bạn chắn chắn muốn xóa?");
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
                            <ext:RecordField Name="ten" />
                            <ext:RecordField Name="tuGio" />
                            <ext:RecordField Name="denGio" />
                            <ext:RecordField Name="soTiengTinhCa" Type="Float" />
                            <ext:RecordField Name="soTiengTangCaTrachNhiem" Type="Float" />
                            <ext:RecordField Name="soTiengTinhTangCa" Type="Float" />
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

                                    <ext:Button runat="server" Text="Thêm mới" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{editor}.show(); #{frmEditor}.reset(); #{h_id}.setValue('');" />
                                        </Listeners>
                                    </ext:Button>

                                </Items>
                            </ext:Toolbar>
                        </TopBar>

                        <ColumnModel>
                            <Columns>
                                <ext:Column Header="Ca làm" DataIndex="ten" />
                                <ext:Column Header="Từ giờ" DataIndex="tuGio" />
                                <ext:Column Header="Số tiếng" DataIndex="denGio" />
                                <ext:Column Header="Số tiếng tính ca" DataIndex="soTiengTinhCa" />
                                <ext:Column Header="Số tiếng trách nhiệm" DataIndex="soTiengTangCaTrachNhiem" />
                                <ext:Column Header="Số tiếng tăng ca" DataIndex="soTiengTinhTangCa" />

                                <ext:ImageCommandColumn Width="60" Align="Center" Header="#">
                                    <Commands>
                                        <ext:ImageCommand CommandName="Edit" Icon="Pencil" Style="margin-left: 7px !important;" />
                                        <ext:ImageCommand CommandName="Delete" Icon="Delete" Style="margin-left: 7px !important;" />
                                    </Commands>
                                </ext:ImageCommandColumn>
                                <ext:ImageCommandColumn Width="70" Align="Center" Header="#">
                                    <Commands>
                                        <ext:ImageCommand CommandName="Ca" Icon="Table" Text="Tăng ca" Style="margin-left: 7px !important;" />
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
                                    <ext:Parameter Name="name" Value="record.data.ten" Mode="Raw" />
                                </ExtraParams>
                            </Command>
                        </DirectEvents>

                    </ext:GridPanel>

                </Items>
            </ext:Viewport>

            <ext:Hidden ID="h_id" runat="server" />
            <ext:Window ID="editor" runat="server" Layout="FitLayout" Width="450" Height="280" Title="Ca làm" Icon="RecordBlue" Hidden="true">
                <Items>
                    <ext:FormPanel ID="frmEditor" runat="server" Layout="FormLayout" Padding="10" Border="false">
                        <Items>
                            <ext:TextField runat="server" DataIndex="ten" FieldLabel="Ca làm" AnchorHorizontal="100%" AllowBlank="false" MaxLength="20" MaskRe="[^<>&amp;*]" />
                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:TimeField runat="server" DataIndex="tuGio" FieldLabel="Từ Giờ" Format="HH:mm" Flex="1" AllowBlank="false" />
                                    <ext:Label runat="server" Text="Số tiếng: " />
                                    <ext:TimeField runat="server" DataIndex="denGio" Format="HH:mm" Flex="1" AllowBlank="false" />
                                </Items>
                            </ext:CompositeField>

                            <ext:CompositeField runat="server" FieldLabel="TG tính quẹt vào">
                                <Items>
                                    <ext:NumberField runat="server" DataIndex="tgQuetTruoc_Vao" Format="0.0" Flex="1" AllowBlank="false" />
                                    <ext:NumberField runat="server" DataIndex="tgQuetSau_Vao" Format="0.0" Flex="1" AllowBlank="false" />
                                </Items>
                            </ext:CompositeField>

                            <ext:CompositeField runat="server" FieldLabel="TG tính quẹt ra">
                                <Items>
                                    <ext:NumberField runat="server" DataIndex="tgQuetTruoc_Ra" Format="0.0" Flex="1" AllowBlank="false" />
                                    <ext:NumberField runat="server" DataIndex="tgQuetSau_Ra" Format="0.0" Flex="1" AllowBlank="false" />
                                </Items>
                            </ext:CompositeField>
                            
                            <ext:CompositeField runat="server" FieldLabel="Số h tính ca">
                                <Items>
                                    <ext:NumberField runat="server" DataIndex="soTiengTinhCa" Format="0.0" AllowBlank="false" Flex="1" />
                                    <ext:Label runat="server" Text="Tăng ca trách nhiệm" />
                                    <ext:NumberField runat="server" DataIndex="soTiengTangCaTrachNhiem" Format="0.0" AllowBlank="false" Flex="1" />
                                </Items>
                            </ext:CompositeField>
                            <ext:Panel runat="server" FormGroup="true" HideLabel="true" Collapsible="true" Title="Giờ theo buổi">
                                <Items>
                                    <ext:CompositeField runat="server" FieldLabel="Buổi sáng từ giờ">
                                        <Items>
                                            <ext:TimeField runat="server" DataIndex="caSang_tuGio" Format="HH:mm" Flex="1" />
                                            <ext:Label runat="server" Text="Đến giờ" />
                                            <ext:TimeField runat="server" DataIndex="caSang_denGio" Format="HH:mm" Flex="1" />
                                        </Items>
                                    </ext:CompositeField>
                                    <ext:CompositeField runat="server" FieldLabel="Buổi Chiều từ giờ">
                                        <Items>
                                            <ext:TimeField runat="server" DataIndex="caChieu_tuGio" Format="HH:mm" Flex="1" />
                                            <ext:Label runat="server" Text="Đến giờ" />
                                            <ext:TimeField runat="server" DataIndex="caChieu_denGio" Format="HH:mm" Flex="1" />
                                        </Items>
                                    </ext:CompositeField>
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:FormPanel>
                </Items>
                <Buttons>
                    <ext:Button ID="btnDangKy" runat="server" Text="Đăng ký">
                        <Listeners>
                            <Click Handler="if (!#{frmEditor}.getForm().isValid()){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: 'Xin vui lòng điền đủ dữ liệu', buttons:Ext.Msg.OK}); return false;}" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnDangKy_DirectClick">
                                <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="editor" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            
            <ext:Window ID="wTangCa" runat="server" Layout="FitLayout" Width="550" Height="320" Title="Tính tăng ca" Icon="RecordGreen" Hidden="true">
                <AutoLoad ShowMask="true" Mode="IFrame" NoCache="true" />
            </ext:Window>
        </div>

    </form>
</body>
</html>
