<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportMonth.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Luong.ReportMonth" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/sHRM/Styles/css/ext.css" rel="stylesheet" />
    <script type="text/javascript" src="/Cpanel/Lng/language.js"></script>
    
    <script type="text/javascript">

        function grd_cmd(cmdName, record, rowIdx, colIdx) {
            if (cmdName == 'Delete') {
                //Ext.Msg.show({
                //    icon: Ext.MessageBox.QUESTION,
                //    msg: 'Bạn chắc chắn muốn xóa?',
                //    buttons: Ext.Msg.OKCANCEL
                //});
                return confirm("#Luong_ReportMonth.msg_js");
            }
            else if (cmdName == 'print') {
                var d = txtDate1.getValue();
                var d2 = txtDate2.getValue();
                Ext.net.DirectMethods.demngaycong(d,d2,{
                    success: function (result) {
                        kequa = result;
                        wInPhieu.setTitle(LngGet('Lng.Luong_ReportMonth.phieuluong') + record.data.tenNV + ' [' + record.data.empoyeeID + ']');
                        wInPhieu.autoLoad.url = '/Cpanel/Luong/In1PhieuLuong.aspx?id=' + record.id + '&soNC='+kequa;
                        wInPhieu.reload();
                        wInPhieu.show();
                    },
                    failure: function (errorMsg) {
                        Ext.Msg.alert('Failure', errorMsg);
                        kequa = 0;
                    }
                });
                return false;
            }
        }
        var winPrintLuong;
        var kequa;
        function inAllPL()
        {
            var d = txtDate1.getValue();
            var d2 = txtDate2.getValue();
            Ext.net.DirectMethods.demngaycong(d,d2,{
                success: function (result) {
                    kequa = result;
                    var url = '/Cpanel/Luong/InPhieuLuong.aspx?m=' + (d.getMonth() + 1) + '&y=' + d.getFullYear() + '&soNC=' + kequa;
                    if (h_depSelected.value)
                        url += '&dep=' + h_depSelected.value;
                    else if (cmbNhom1.getSelectedIndex() > -1)
                        url += '&group1ID=' + cmbNhom1.getValue();
                    else
                        url += '&empID=' + txtMaNVSearch.getValue();

                    if (winPrintLuong && !winPrintLuong.closed) {
                        winPrintLuong.location.href = url;
                        //winPrintLuong.location.reload();
                    }
                    else {
                        winPrintLuong = window.open(url, '_blank');
                    }
                    winPrintLuong.focus();
                },
                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                    kequa = 0;
                }
            });
            
            return false;
        }
    </script>
     
    <style type="text/css">
        .cmd1 button.x-btn-text { color:#0026ff; font-weight:bold; text-decoration: underline; }
    </style>
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
                                    <ext:Label runat="server" Text="#Luong_ReportMonth.tungay" />
                                    <ext:DateField ID="txtDate1" runat="server" Format="dd/MM/yyyy" Width="80" />
                                    <ext:Label runat="server" Text="#Luong_ReportMonth.denngay" />
                                    <ext:DateField ID="txtDate2" runat="server" Format="dd/MM/yyyy" Width="80" />
                                    
                                    <ext:TriggerField ID="txtMaNVSearch" runat="server" BlankText="Mã nhân viên" EmptyText="Mã nhân viên">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Change Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.setValue(''); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:TriggerField>

                                    <ext:Hidden runat="server" ID="h_depSelected" />
                                    <ext:DropDownField EmptyText="#Luong_ReportMonth.chonPB" ID="cbophong" runat="server" Editable="false" Width="200" TriggerIcon="SimpleArrowDown" HideLabel="true" AnchorHorizontal="100%" NoteAlign="Top">
                                        <Component>
                                            <ext:TreePanel
                                                ID="TreeFunc"
                                                runat="server"
                                                Title="#Luong_ReportMonth.dsPB"
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
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" />
                                        </Triggers>
                                        <Listeners>
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); h_depSelected.setValue(''); }" />
                                            <Expand Handler="this.component.getRootNode().expand(true);" Single="true" Delay="10" />
                                        </Listeners>
                                    </ext:DropDownField>
                                    
                                    <ext:ComboBox ID="cmbNhom1" runat="server" HideLabel="true" Editable="false" Width="125" DisplayField="gName" ValueField="id" EmptyText="Xử theo nhóm 1">
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
                                        
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:ComboBox>

                                    <ext:ToolbarSpacer Width="10" />
                                    <ext:Button ID="btnView" runat="server" Icon="Zoom" Text="#common_btn.Find" ToolTip="#Luong_ReportMonth.tooltip" ToolTipType="Qtip">
                                        <DirectEvents>
                                            <Click OnEvent="btnView_DirectClick">
                                                <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="grd" />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>

                                    <ext:ToolbarFill />
                                    <ext:Button runat="server" Icon="PageExcel" Text="#Luong_ReportMonth.xuatEx" Visible="false">
                                        <Listeners>
                                            <Click Handler="#{sto1}.submitData();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID="btnExcel" runat="server" Icon="PageExcel" Text="#Luong_ReportMonth.bangluongCT" OnDirectClick="btnExcel_DirectClick" />
                                    <ext:Button ID="btnSendApproved" runat="server" Icon="Mail" Text="Send approved">
                                        <Listeners>
                                            <Click Handler="#{wSendApproved}.show()" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button runat="server" Icon="Printer" Text="Print">
                                        <Listeners>
                                            <Click Fn="inAllPL" />
                                        </Listeners>
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
                                                    <ext:RecordField Name="IdCard" />
                                                    <ext:RecordField Name="ngayVao" Type="Date"/>
                                                    <ext:RecordField Name="luongCB" Type="Float" />
                                                    <ext:RecordField Name="luongPC" Type="Float" />
                                                    <ext:RecordField Name="ngaycong_bt" Type="Float" />
                                                    <ext:RecordField Name="ngaycong_phep" Type="Float" />
                                                    <ext:RecordField Name="ngaycong_lt" Type="Float" />
                                                    <ext:RecordField Name="ngaycong_cn" Type="Float" />
                                                    <ext:RecordField Name="tienNC_bt" Type="Float" />
                                                    <ext:RecordField Name="tienNC_phep" Type="Float" />
                                                    <ext:RecordField Name="tienNC_lt" Type="Float" />
                                                    <ext:RecordField Name="tienNC_cn" Type="Float" />
                                                    <ext:RecordField Name="tongNgayCong" Type="Float" />
                                                    <ext:RecordField Name="tienNgayCong" Type="Float" />
                                                    <ext:RecordField Name="tgTangCa_bt" Type="Float" />
                                                    <ext:RecordField Name="tgTangCa_cn" Type="Float" />
                                                    <ext:RecordField Name="tgTangCa_lt" Type="Float" />
                                                    <ext:RecordField Name="tienTangCa_bt" Type="Float" />
                                                    <ext:RecordField Name="tienTangCa_cn" Type="Float" />
                                                    <ext:RecordField Name="tienTangCa_lt" Type="Float" />
                                                    <ext:RecordField Name="tongThoiGianTangCa" Type="Float" />
                                                    <ext:RecordField Name="tienTangCa" Type="Float" />

                                                    <ext:RecordField Name="tongLuong" Type="Float" />
                                                    
                                                    <ext:RecordField Name="tongThuongCalc" Type="Float" />
                                                    <ext:RecordField Name="tongPhuCapKhac" Type="Float" />

                                                    <ext:RecordField Name="luongSP" Type="Float" />
                                                    <ext:RecordField Name="luongTangCaSP" Type="Float" />
                                                    <ext:RecordField Name="luongSP_tong" Type="Float" />
                                                    <ext:RecordField Name="luongThoiGian" Type="Float" />

                                                    <ext:RecordField Name="BH105" Type="Float" />
                                                    <ext:RecordField Name="khoanTruKhac" Type="Float" />
                                                    <ext:RecordField Name="tongKhauTru" Type="Float" />

                                                    <ext:RecordField Name="actualBankTransfer" Type="Float" />
                                                    <ext:RecordField Name="laBangLuongCu" Type="Boolean" />

                                                    <ext:RecordField Name="BankName" />
                                                    <ext:RecordField Name="BankNameAcount" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>

                                <ColumnModel>
                                    <Columns>
                                        <ext:Column DataIndex="tenNV" Header="#Luong_ReportMonth.hoten" Width="130" Fixed="true" />
                                        <ext:Column DataIndex="empoyeeID" Header="#Luong_ReportMonth.maNV" Width="50" />
                                        <ext:Column DataIndex="IdCard" Header="#Luong_ReportMonth.idCard" Width="50" />
                                        <ext:DateColumn DataIndex="ngayVao" Header="#Luong_ReportMonth.ngayvao" Width="65" Format="dd/MM/yyyy"/>
                                        <ext:NumberColumn DataIndex="luongCB" Header="#Luong_ReportMonth.luongCB" Align="Center" Width="90" Format="0,0" />
                                        <ext:NumberColumn DataIndex="luongPC" Header="#Luong_ReportMonth.luongPC" Align="Center" Width="90" Format="0,0" />
                                        <ext:CheckColumn DataIndex="laBangLuongCu" Header="Cũ" Align="Center" Width="30" />

                                        <ext:NumberColumn DataIndex="ngaycong_bt" Header="#Luong_ReportMonth.ngaycong_bt" Align="Center" Width="90" Format="0,0.00" />
                                        <ext:NumberColumn DataIndex="ngaycong_phep" Header="#Luong_ReportMonth.ngaycong_phep" Align="Center" Width="90" Format="0,0.00" />
                                        <ext:NumberColumn DataIndex="ngaycong_lt" Header="#Luong_ReportMonth.ngaycong_lt" Align="Center" Width="90" Format="0,0.00" />
                                        <ext:NumberColumn DataIndex="ngaycong_cn" Header="#Luong_ReportMonth.ngaycong_cn" Align="Center" Width="90" Format="0,0.00" />
                                        <ext:NumberColumn DataIndex="tongNgayCong" Header="#Luong_ReportMonth.ngaycong" Align="Center" Width="90" Format="0,0.00" />
                                        <ext:NumberColumn DataIndex="tienNC_bt" Header="#Luong_ReportMonth.tiencong_bt" Align="Center" Width="90" Format="0,0" />
                                        <ext:NumberColumn DataIndex="tienNC_phep" Header="#Luong_ReportMonth.tiencong_phep" Align="Center" Width="90" Format="0,0" />
                                        <ext:NumberColumn DataIndex="tienNC_lt" Header="#Luong_ReportMonth.tiencong_lt" Align="Center" Width="90" Format="0,0" />
                                        <ext:NumberColumn DataIndex="tienNC_cn" Header="#Luong_ReportMonth.tiencong_cn" Align="Center" Width="90" Format="0,0" />
                                        <ext:NumberColumn DataIndex="tienNgayCong" Header="#Luong_ReportMonth.tiencong" Align="Center" Width="90" Format="0,0" />
                                        <ext:CommandColumn Header="#" Width="50">
                                            <Commands>
                                                <ext:GridCommand Cls="cmd1" Text="#Luong_ReportMonth.chitiet" CommandName="detail_NgayCong" />
                                            </Commands>
                                        </ext:CommandColumn>
                                        <ext:NumberColumn DataIndex="tgTangCa_bt" Header="#Luong_ReportMonth.TGTC_bt" Align="Center" Width="90" Format="0,0.0" />
                                        <ext:NumberColumn DataIndex="tgTangCa_cn" Header="#Luong_ReportMonth.TGTC_cn" Align="Center" Width="90" Format="0,0.0" />
                                        <ext:NumberColumn DataIndex="tgTangCa_lt" Header="#Luong_ReportMonth.TGTC_lt" Align="Center" Width="90" Format="0,0.0" />
                                        <ext:NumberColumn DataIndex="tongThoiGianTangCa" Header="#Luong_ReportMonth.tongTGTC" Align="Center" Width="90" Format="0,0.0" />
                                        <ext:NumberColumn DataIndex="tienTangCa_bt" Header="#Luong_ReportMonth.TienTangCa_bt" Align="Center" Width="90" Format="0,0" />
                                        <ext:NumberColumn DataIndex="tienTangCa_cn" Header="#Luong_ReportMonth.TienTangCa_cn" Align="Center" Width="90" Format="0,0" />
                                        <ext:NumberColumn DataIndex="tienTangCa_lt" Header="#Luong_ReportMonth.TienTangCa_lt" Align="Center" Width="90" Format="0,0" />
                                        <ext:NumberColumn DataIndex="tienTangCa" Header="#Luong_ReportMonth.TienTangCa" Align="Center" Width="90" Format="0,0" />
                                        <ext:CommandColumn Header="#" Width="50">
                                            <Commands>
                                                <ext:GridCommand Cls="cmd1" Text="#Luong_ReportMonth.chitiet" CommandName="detail_TangCa" />
                                            </Commands>
                                        </ext:CommandColumn>

                                        <ext:NumberColumn DataIndex="luongSP" Header="Lương SP" Align="Center" Width="90" Format="0,0" />
                                        <ext:NumberColumn DataIndex="luongTangCaSP" Header="Lương tăng ca SP" Align="Center" Width="90" Format="0,0" />
                                        <ext:NumberColumn DataIndex="luongSP_tong" Header="Tổng lương SP" Align="Center" Width="90" Format="0,0" />
                                        <ext:NumberColumn DataIndex="luongThoiGian" Header="Lương thời gian" Align="Center" Width="90" Format="0,0" />

                                        <ext:NumberColumn DataIndex="tongThuongCalc" Header="Tổng tiền thưởng" Align="Center" Width="90" Format="0,0" />
                                        <ext:NumberColumn DataIndex="tongPhuCapKhac" Header="#Luong_ReportMonth.phucapKhac" Align="Center" Width="90" Format="0,0" />
                                        <ext:CommandColumn Header="#" Width="50">
                                            <Commands>
                                                <ext:GridCommand Cls="cmd1" Text="#Luong_ReportMonth.chitiet" CommandName="detail_PCK" />
                                            </Commands>
                                        </ext:CommandColumn>
                                        <ext:NumberColumn DataIndex="tongLuong" Header="#Luong_ReportMonth.tongluong" Align="Center" Width="90" Format="0,0" Css="color:red;" />


                                        <ext:NumberColumn DataIndex="BH105" Header="Bảo hiểm" Align="Center" Width="90" Format="0,0" />
                                        <ext:NumberColumn DataIndex="khoanTruKhac" Header="Khoản trừ khác" Align="Center" Width="90" Format="0,0" />
                                        <ext:NumberColumn DataIndex="tongKhauTru" Header="Tổng khấu trừ" Align="Center" Width="90" Format="0,0" />

                                        <ext:NumberColumn DataIndex="actualBankTransfer" Header="Thực chuyển" Align="Center" Width="90" Format="0,0" Css="color:red;" />

                                        <ext:CommandColumn Header="#" Width="50">
                                            <Commands>
                                                <ext:GridCommand Cls="cmd1" Text="#Luong_ReportMonth.inphieu" CommandName="print" />
                                            </Commands>
                                        </ext:CommandColumn>

                                        <ext:Column DataIndex="BankNameAcount" Header="TK NH" Width="50" />
                                        <ext:Column DataIndex="BankName" Header="Tại NH" Width="50" />
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
                                    <ext:Button runat="server" Text="Xuất Excel" Icon="PageExcel">
                                        <Listeners>
                                            <Click Handler="#{stoDetail}.submitData();" />
                                        </Listeners>
                                    </ext:Button>

                                </Items>
                            </ext:Toolbar>
                        </TopBar>

                        <ColumnModel>
                            <Columns>
                                <ext:DateColumn Header="#Luong_ReportMonth.ngay" DataIndex="ngay" Format="dd/MM/yyyy" />
                                <ext:Column Header="TT" DataIndex="TT" Width="35" />
                                <ext:NumberColumn Header="#Luong_ReportMonth.tgDiMuon" DataIndex="tgDiMuon" Format="0,0" Width="75" />
                                <ext:NumberColumn Header="#Luong_ReportMonth.tgVeSom" DataIndex="tgVeSom" Format="0,0" Width="75" />
                                <ext:NumberColumn Header="#Luong_ReportMonth.ngaycong" DataIndex="ngayCong" Format="0,0.00" Width="75" />
                                <ext:NumberColumn Header="#Luong_ReportMonth.hsLuong" DataIndex="hsLuong" Format="0" Width="75" />
                                <ext:NumberColumn Header="#Luong_ReportMonth.tiencong" DataIndex="tienCong" Format="0,0.0" Width="95" />
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
                                    <ext:Button runat="server" Text="#Luong_ReportMonth.xuatEx" Icon="PageExcel">
                                        <Listeners>
                                            <Click Handler="#{stoDetail}.submitData();" />
                                        </Listeners>
                                    </ext:Button>

                                </Items>
                            </ext:Toolbar>
                        </TopBar>

                        <ColumnModel>
                            <Columns>
                                <ext:DateColumn Header="#Luong_ReportMonth.ngay" DataIndex="ngay" Format="dd/MM/yyyy" />
                                <ext:Column Header="#Luong_ReportMonth.trangthai" DataIndex="TT" />
                                <ext:NumberColumn Header="#Luong_ReportMonth.tangca" DataIndex="tgTinhTangCa" Format="0.0" />
                                <ext:NumberColumn Header="#Luong_ReportMonth.TienTangCa" DataIndex="tienTangCa" Format="0,0.0" />
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
                                    <ext:Button runat="server" Text="#Luong_ReportMonth.xuatEx" Icon="PageExcel">
                                        <Listeners>
                                            <Click Handler="#{stoDetail}.submitData();" />
                                        </Listeners>
                                    </ext:Button>

                                </Items>
                            </ext:Toolbar>
                        </TopBar>

                        <ColumnModel>
                            <Columns>
                                <ext:Column Header="#Luong_ReportMonth.phucap" DataIndex="PC" />
                                <ext:NumberColumn Header="#Luong_ReportMonth.sotien" DataIndex="TT" Format="0,0" />
                            </Columns>
                        </ColumnModel>

                        <SelectionModel>
                            <ext:RowSelectionModel runat="server" SingleSelect="false" />
                        </SelectionModel>

                    </ext:GridPanel>

                </Items>
            </ext:Window>



            <ext:Window ID="wInPhieu" runat="server" Width="550" Height="350" Hidden="true" Title="#Luong_ReportMonth.phieuluong" Icon="Application">
                <AutoLoad ShowMask="true" Mode="IFrame" />
                <TopBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:ToolbarFill />
                            <ext:Button runat="server" Text="#Luong_ReportMonth.inphieuluong" Icon="Printer">
                                <Listeners>
                                    <Click Handler="wInPhieu.getBody().print();" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
            </ext:Window>

            <ext:Window ID="wSendApproved" runat="server" Width="750" Height="390" Hidden="true" Title="Send Approved" Icon="Email" 
                LabelAlign="Top" Padding="10" Layout="FormLayout">
                <TopBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:ToolbarFill />
                            <ext:Button runat="server" Text="Gửi" Icon="EmailGo">
                                <DirectEvents>
                                    <Click OnEvent="btnSendApproved_DirectClick">
                                        <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="wSendApproved" Msg="#Luong_ReportMonth.sendingmail" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Items>
                    <ext:TextField ID="wSendApproved_sendTo" runat="server" AnchorHorizontal="100%" FieldLabel="To" />
                    <ext:TextField ID="wSendApproved_subject" runat="server" AnchorHorizontal="100%" FieldLabel="Subject" />
                    <ext:HtmlEditor ID="wSendApproved_body" runat="server" AnchorHorizontal="100%" FieldLabel="Body" Height="195" />
                </Items>
            </ext:Window>
            
        </div>
    </form>
</body>
</html>
