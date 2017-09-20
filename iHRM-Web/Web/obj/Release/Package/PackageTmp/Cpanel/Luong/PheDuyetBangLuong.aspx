<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PheDuyetBangLuong.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Luong.PheDuyetBangLuong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/sHRM/Styles/css/ext.css" rel="stylesheet" />
    
    <style type="text/css">
        .tt_statusCode { height: 12px; margin-top: -4px; }
    </style>

    <script type="text/javascript">

        function grd_cmd(cmdName, record, rowIdx, colIdx) {
            if (cmdName == 'Delete') {
                //Ext.Msg.show({
                //    icon: Ext.MessageBox.QUESTION,
                //    msg: 'Bạn chắc chắn muốn xóa?',
                //    buttons: Ext.Msg.OKCANCEL
                //});

                return confirm("#Luong_PheDuyetBangLuong.msg_js");
            }
            else if (cmdName == 'print') {
                wInPhieu.setTitle('Phiếu lương ' + record.data.tenNV + ' [' + record.data.empoyeeID + ']');
                wInPhieu.autoLoad.url = '/Cpanel/Luong/InPhieuLuong.aspx?id=' + record.id;
                wInPhieu.reload();
                wInPhieu.show();
                return false;
            }
        }

        function RendTT(v) {
            return '<div class="tt_statusCode"><img src="/Cpanel/Skins/Style/IMG/TT' + v + '.png" /></div>';
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>

            <ext:ResourceManager runat="server" ID="ResourceManager1" />

            <ext:Viewport runat="server" Layout="FitLayout">
                <Items>

                    <ext:Panel runat="server" Border="false" Layout="FitLayout">
                        
                        <TopBar>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Label runat="server" Text="#Luong_PheDuyetBangLuong.thang" />
                                    <ext:DateField ID="txtDate" HideLabel="true" runat="server" Format="MM/yyyy" Width="75">
                                        <Plugins>
                                            <ext:MonthPicker runat="server" />
                                        </Plugins>
                                    </ext:DateField>
                                    
                                    <ext:Hidden runat="server" ID="h_depSelected" />
                                    <ext:DropDownField EmptyText="#Luong_PheDuyetBangLuong.chonPB" ID="cbophong" runat="server" Editable="false" Width="300" TriggerIcon="SimpleArrowDown" HideLabel="true" AnchorHorizontal="100%" NoteAlign="Top">
                                        <Component>
                                            <ext:TreePanel
                                                ID="TreeFunc"
                                                runat="server"
                                                Title="#Luong_PheDuyetBangLuong.dsPB"
                                                Icon="Accept"
                                                Height="300"
                                                Shadow="None"
                                                UseArrows="true"
                                                AutoScroll="true"
                                                Animate="true"
                                                EnableDD="true"
                                                ContainerScroll="true"
                                                RootVisible="false">
                                                <SelectionModel>
                                                    <ext:DefaultSelectionModel />
                                                </SelectionModel>
                                                <LoadMask ShowMask="true" />
                                                <DirectEvents>
                                                    <DblClick OnEvent="btnEdit_DirectClick" />
                                                </DirectEvents>

                                            </ext:TreePanel>
                                        </Component>
                                        <Listeners>
                                            <Expand Handler="this.component.getRootNode().expand(true);" Single="true" Delay="10" />
                                        </Listeners>
                                    </ext:DropDownField>

                                    <ext:ToolbarSpacer Width="10" />
                                    <ext:Button ID="btnView" runat="server" Icon="Zoom" Text="#common_btn.Find" ToolTip="#Luong_PheDuyetBangLuong.tooltip" ToolTipType="Qtip">
                                        <DirectEvents>
                                            <Click OnEvent="btnView_DirectClick">
                                                <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="grd" />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:Button ID="btnExcel" runat="server" Icon="PageExcel" Text="#Luong_PheDuyetBangLuong.bangluongCT" OnDirectClick="btnExcel_DirectClick" />

                                    <ext:ToolbarFill />
                                                                   
                                    <ext:Button ID="btnApprovedAll" runat="server" Text="#Luong_PheDuyetLuong.btnApprovedAll" Icon="BulletGreen" OnDirectClick="btnApprovedAll_DirectClick">
                                    </ext:Button>
                                    <ext:Button ID="btnRejectAll" runat="server" Text="#Luong_PheDuyetLuong.btnRejectAll" Icon="BulletRed" OnDirectClick="btnApprovedAll_DirectClick">
                                    </ext:Button>
                                    <ext:Button ID="btnReviseAll" runat="server" Text="#Luong_PheDuyetLuong.btnReviseAll" Icon="BulletOrange" OnDirectClick="btnApprovedAll_DirectClick">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>

                        <Items>
                            <ext:GridPanel ID="grd" runat="server" Border="false">
                                <Store>
                                    <ext:Store ID="sto1" runat="server" OnSubmitData="sto_SubmitData4Excel">
                                        <DirectEventConfig IsUpload="true" />
                                        <Reader>
                                            <ext:JsonReader IDProperty="id">
                                                <Fields>
                                                    <ext:RecordField Name="empoyeeID" />
                                                    <ext:RecordField Name="tenNV" />
                                                    <ext:RecordField Name="IdCard"></ext:RecordField>
                                                    <ext:RecordField Name="ngayVao" Type="Date" />
                                                    <ext:RecordField Name="luongCB" Type="Float" />
                                                    <ext:RecordField Name="luongPC" Type="Float" />
                                                    <ext:RecordField Name="tongNgayCong" Type="Float" />
                                                    <ext:RecordField Name="tienNgayCong" Type="Float" />
                                                    <ext:RecordField Name="tongThoiGianTangCa" Type="Float" />
                                                    <ext:RecordField Name="tienTangCa" Type="Float" />
                                                    <ext:RecordField Name="tongPhuCapKhac" Type="Float" />
                                                    <ext:RecordField Name="tongLuong" Type="Float" />
                                                    <ext:RecordField Name="approved" Type="Int" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>

                                <ColumnModel>
                                    <Columns>
                                        <ext:Column DataIndex="tenNV" Header="Họ và tên" Width="130" Fixed="true" />
                                        <ext:Column DataIndex="empoyeeID" Header="Mã NV" Width="50" />
                                        <ext:Column DataIndex="IdCard" Header="CMND" Width="50" />
                                        <ext:DateColumn DataIndex="ngayVao" Header="#Luong_PheDuyetBangLuong.ngayvao" Width="65" />
                                        <ext:NumberColumn DataIndex="luongCB" Header="#Luong_PheDuyetBangLuong.luongCB" Align="Center" Width="90" Format="0,0" />
                                        <ext:NumberColumn DataIndex="luongPC" Header="#Luong_PheDuyetBangLuong.luongPC" Align="Center" Width="90" Format="0,0" />
                                        <ext:NumberColumn DataIndex="tongNgayCong" Header="#Luong_PheDuyetBangLuong.ngaycong" Align="Center" Width="90" Format="0,0.00" />
                                        <ext:NumberColumn DataIndex="tienNgayCong" Header="#Luong_PheDuyetBangLuong.tiencong" Align="Center" Width="90" Format="0,0" />
                                        <ext:CommandColumn Header="#" Width="50">
                                            <Commands>
                                                <ext:GridCommand Text="#Luong_PheDuyetBangLuong.chitiet" CommandName="detail_NgayCong" />
                                            </Commands>
                                        </ext:CommandColumn>
                                        <ext:NumberColumn DataIndex="tongThoiGianTangCa" Header="#Luong_PheDuyetBangLuong.tongTGTC" Align="Center" Width="90" Format="0,0.0" />
                                        <ext:NumberColumn DataIndex="tienTangCa" Header="#Luong_PheDuyetBangLuong.TienTangCa" Align="Center" Width="90" Format="0,0" />
                                        <ext:CommandColumn Header="#" Width="50">
                                            <Commands>
                                                <ext:GridCommand Text="#Luong_PheDuyetBangLuong.chitiet" CommandName="detail_TangCa" />
                                            </Commands>
                                        </ext:CommandColumn>
                                        <ext:NumberColumn DataIndex="tongPhuCapKhac" Header="#Luong_PheDuyetBangLuong.phucapKhac" Align="Center" Width="90" Format="0,0" />
                                        <ext:CommandColumn Header="#" Width="50">
                                            <Commands>
                                                <ext:GridCommand Text="#Luong_PheDuyetBangLuong.chitiet" CommandName="detail_PCK" />
                                            </Commands>
                                        </ext:CommandColumn>
                                        <ext:NumberColumn DataIndex="tongLuong" Header="#Luong_PheDuyetBangLuong.tongluong" Align="Center" Width="90" Format="0,0" />
                                                    
                                        <ext:Column DataIndex="approved" Header="TT" Width="35">
                                            <Renderer Fn="RendTT" />
                                        </ext:Column>
                                    </Columns>
                                </ColumnModel>

                                <SelectionModel>
                                    <ext:RowSelectionModel runat="server" />
                                </SelectionModel>
                                
                                <Listeners>
                                    <Command Fn="grd_cmd" />
                                </Listeners>

                                <DirectEvents>
                                    <Command OnEvent="grd_OnCommand">
                                        <ExtraParams>
                                            <ext:Parameter Name="id" Value="record.id" Mode="Raw" />
                                            <ext:Parameter Name="empoyeeID" Value="record.data.empoyeeID" Mode="Raw" />
                                            <ext:Parameter Name="tenNV" Value="record.data.tenNV" Mode="Raw" />
                                            <ext:Parameter Name="command" Value="command" Mode="Raw" />
                                        </ExtraParams>
                                    </Command>
                                </DirectEvents>
                            </ext:GridPanel>
                        </Items>

                    </ext:Panel>

                </Items>
            </ext:Viewport>

            <ext:Window ID="wDetail" runat="server" Width="700" Height="350" Layout="FitLayout" Hidden="true">
                <Items>
                    
                    <ext:GridPanel ID="grdDetail" runat="server" Border="false" Region="Center">
                        <Store>
                            <ext:Store ID="stoDetail" runat="server" OnSubmitData="sto_SubmitData4Excel">
                                <DirectEventConfig IsUpload="true" />
                                <Reader>
                                    <ext:JsonReader IDProperty="id">
                                        <Fields>
                                            <ext:RecordField Name="ngay" Type="Date" />
                                            <ext:RecordField Name="TT" />
                                            <ext:RecordField Name="tgDiMuon" />
                                            <ext:RecordField Name="tgVeSom" />
                                            <ext:RecordField Name="ngayCong" />
                                            <ext:RecordField Name="hsLuong" />
                                            <ext:RecordField Name="tienCong" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>

                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>

                                    <ext:ToolbarFill />
                                    <ext:Button runat="server" Text="#Luong_PheDuyetBangLuong.xuatEx" Icon="PageExcel">
                                        <Listeners>
                                            <Click Handler="#{stoDetail}.submitData();" />
                                        </Listeners>
                                    </ext:Button>

                                </Items>
                            </ext:Toolbar>
                        </TopBar>

                        <ColumnModel>
                            <Columns>
                                <ext:DateColumn Header="#Luong_PheDuyetBangLuong.ngay" DataIndex="ngay" Format="dd/MM/yyyy" />
                                <ext:Column Header="#Luong_PheDuyetBangLuong.grd_Status" DataIndex="TT" Width="35" />
                                <ext:NumberColumn Header="#Luong_PheDuyetBangLuong.tgDiMuon" DataIndex="tgDiMuon" Format="0,0" Width="75" />
                                <ext:NumberColumn Header="#Luong_PheDuyetBangLuong.tgVeSom" DataIndex="tgVeSom" Format="0,0" Width="75" />
                                <ext:NumberColumn Header="#Luong_PheDuyetBangLuong.ngaycong" DataIndex="ngayCong" Format="0,0.00" Width="75" />
                                <ext:NumberColumn Header="#Luong_PheDuyetBangLuong.hsLuong" DataIndex="hsLuong" Format="0" Width="75" />
                                <ext:NumberColumn Header="#Luong_PheDuyetBangLuong.tiencong" DataIndex="tienCong" Format="0,0.0" Width="95" />
                            </Columns>
                        </ColumnModel>

                        <SelectionModel>
                            <ext:RowSelectionModel runat="server" SingleSelect="false" />
                        </SelectionModel>

                    </ext:GridPanel>

                </Items>
            </ext:Window>

            <ext:Window ID="wDetail_TC" runat="server" Width="500" Height="350" Layout="FitLayout" Hidden="true">
                <Items>
                    
                    <ext:GridPanel ID="grdDetail_TC" runat="server" Border="false" Region="Center">
                        <Store>
                            <ext:Store ID="stoDetail_TC" runat="server" OnSubmitData="sto_SubmitData4Excel">
                                <DirectEventConfig IsUpload="true" />
                                <Reader>
                                    <ext:JsonReader IDProperty="id">
                                        <Fields>
                                            <ext:RecordField Name="ngay" Type="Date" />
                                            <ext:RecordField Name="TT" />
                                            <ext:RecordField Name="tgTinhTangCa" Type="Float" />
                                            <ext:RecordField Name="tienTangCa" Type="Float" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>

                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>

                                    <ext:ToolbarFill />
                                    <ext:Button runat="server" Text="#Luong_PheDuyetBangLuong.xuatEx" Icon="PageExcel">
                                        <Listeners>
                                            <Click Handler="#{stoDetail}.submitData();" />
                                        </Listeners>
                                    </ext:Button>

                                </Items>
                            </ext:Toolbar>
                        </TopBar>

                        <ColumnModel>
                            <Columns>
                                <ext:DateColumn Header="#Luong_PheDuyetBangLuong.ngay" DataIndex="ngay" Format="dd/MM/yyyy" />
                                <ext:Column Header="#Luong_PheDuyetBangLuong.trangthai" DataIndex="TT" />
                                <ext:NumberColumn Header="#Luong_PheDuyetBangLuong.tangca" DataIndex="tgTinhTangCa" Format="0.0" />
                                <ext:NumberColumn Header="#Luong_PheDuyetBangLuong.TienTangCa" DataIndex="tienTangCa" Format="0,0.0" />
                            </Columns>
                        </ColumnModel>

                        <SelectionModel>
                            <ext:RowSelectionModel runat="server" SingleSelect="false" />
                        </SelectionModel>

                    </ext:GridPanel>

                </Items>
            </ext:Window>

            <ext:Window ID="wDetail_PK" runat="server" Width="300" Height="350" Layout="FitLayout" Hidden="true">
                <Items>
                    
                    <ext:GridPanel ID="grdDetail_PK" runat="server" Border="false" Region="Center">
                        <Store>
                            <ext:Store ID="stoDetail_PK" runat="server" OnSubmitData="sto_SubmitData4Excel">
                                <DirectEventConfig IsUpload="true" />
                                <Reader>
                                    <ext:JsonReader IDProperty="id">
                                        <Fields>
                                            <ext:RecordField Name="PC" />
                                            <ext:RecordField Name="TT" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>

                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>

                                    <ext:ToolbarFill />
                                    <ext:Button runat="server" Text="#Luong_PheDuyetBangLuong.XuatEx" Icon="PageExcel">
                                        <Listeners>
                                            <Click Handler="#{stoDetail}.submitData();" />
                                        </Listeners>
                                    </ext:Button>

                                </Items>
                            </ext:Toolbar>
                        </TopBar>

                        <ColumnModel>
                            <Columns>
                                <ext:Column Header="#Luong_PheDuyetBangLuong.phucap" DataIndex="PC" />
                                <ext:NumberColumn Header="#Luong_PheDuyetBangLuong.sotien" DataIndex="TT" Format="0,0" />
                            </Columns>
                        </ColumnModel>

                        <SelectionModel>
                            <ext:RowSelectionModel runat="server" SingleSelect="false" />
                        </SelectionModel>

                    </ext:GridPanel>

                </Items>
            </ext:Window>



            <ext:Window ID="wInPhieu" runat="server" Width="550" Height="350" Hidden="true" Title="#Luong_PheDuyetBangLuong.phieuluong" Icon="Application">
                <AutoLoad ShowMask="true" Mode="IFrame" />
                <TopBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:ToolbarFill />
                            <ext:Button runat="server" Text="#Luong_PheDuyetBangLuong.inphieuluong" Icon="Printer">
                                <Listeners>
                                    <Click Handler="wInPhieu.getBody().print();" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
            </ext:Window>

        </div>
    </form>
</body>
</html>
