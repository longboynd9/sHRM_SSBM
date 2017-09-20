<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportMonth.aspx.cs" Inherits="iHRM.WebPC.Cpanel.QuetThe.ReportMonth" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/sHRM/Styles/css/ext.css" rel="stylesheet" />
    <style type="text/css">
        .KP { color:red; }
        .VS, .DM, .In, .Out { color:orange; }
        .NP { color:#808080; }
        .tenNV { display:block; padding:5px 0; }

        .er { display:block; background-color:red; text-align: center;}
    </style>

    <script type="text/javascript">
        function rendD(value) {
            if (value == null || value == undefined)
                return '';

            var cls = value;
            if (cls.indexOf('<') > -1)
                cls = cls.substr(0, cls.indexOf('<'));
            return '<span class="' + cls + '">' + value + '</span>';
        }
        function GenEr(value) {
            if (value) {
                var er = parseInt(value);
                if (er > 0)
                    return '<span class="er er' + er + '">ᴥ</span>';
            }

            return '';
        }

        function GenXinNghiBuoi(value) {
            if (value == 1)
                return "Buổi sáng";

            if (value == 2)
                return "Buổi Chiều";

            if (value == 3)
                return "Cả ngày";

            return "";
        }
        function rendLock(value) {
            if (value == 1)
                return "<img alt='lock' src='/icons/lock-png/ext.axd' />";
            return "";
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
                                    <ext:Label runat="server" Text="#QuetThe_ReportMonth.lbTuNgay" />
                                    <ext:DateField ID="txtDate1" runat="server" Format="dd/MM/yyyy" />
                                    <ext:Label runat="server" Text="#QuetThe_ReportMonth.lbDenNgay" />
                                    <ext:DateField ID="txtDate2" runat="server" Format="dd/MM/yyyy" />
                                    
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
                                    <ext:DropDownField EmptyText="#QuetThe_ReportMonth.chonPB" ID="cbophong" runat="server" Editable="false" Width="300" TriggerIcon="SimpleArrowDown" HideLabel="true" AnchorHorizontal="100%" NoteAlign="Top">
                                        <Component>
                                            <ext:TreePanel
                                                ID="TreeFunc"
                                                runat="server"
                                                Title="#QuetThe_ReportMonth.title"
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

                                    <ext:ToolbarSpacer Width="10" />
                                    <ext:Button ID="btnView" runat="server" Icon="Zoom" Text="#common_btn.Find" ToolTip="#QuetThe_ReportMonth.tooltip" ToolTipType="Qtip">
                                        <DirectEvents>
                                            <Click OnEvent="btnView_DirectClick">
                                                <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="grd" />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>

                                    <ext:ToolbarFill />
                                    <ext:Button ID="btnExcel" runat="server" Icon="PageExcel" Text="#QuetThe_ReportMonth.xuatEx" ClientIDMode="Static">
                                        <Listeners>
                                            <Click Handler="#{sto1}.submitData();" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>

                        <Items>
                            <ext:GridPanel ID="grd" runat="server" Border="false">
                                <Store>
                                    <ext:Store ID="sto1" runat="server" OnSubmitData="sto1_SubmitData">
                                        <DirectEventConfig IsUpload="true" />
                                        <Reader>
                                            <ext:JsonReader IDProperty="EmployeeID">
                                                <Fields>
                                                    <ext:RecordField Name="tenNV" />
                                                    <ext:RecordField Name="EmployeeID" />
                                                    <ext:RecordField Name="ngayVao" Type="Date" />
                                                    <ext:RecordField Name="D1" />
                                                    <ext:RecordField Name="D2" />
                                                    <ext:RecordField Name="D3" />
                                                    <ext:RecordField Name="D4" />
                                                    <ext:RecordField Name="D5" />
                                                    <ext:RecordField Name="D6" />
                                                    <ext:RecordField Name="D7" />
                                                    <ext:RecordField Name="D8" />
                                                    <ext:RecordField Name="D9" />
                                                    <ext:RecordField Name="D10" />
                                                    <ext:RecordField Name="D11" />
                                                    <ext:RecordField Name="D12" />
                                                    <ext:RecordField Name="D13" />
                                                    <ext:RecordField Name="D14" />
                                                    <ext:RecordField Name="D15" />
                                                    <ext:RecordField Name="D16" />
                                                    <ext:RecordField Name="D17" />
                                                    <ext:RecordField Name="D18" />
                                                    <ext:RecordField Name="D19" />
                                                    <ext:RecordField Name="D20" />
                                                    <ext:RecordField Name="D21" />
                                                    <ext:RecordField Name="D22" />
                                                    <ext:RecordField Name="D23" />
                                                    <ext:RecordField Name="D24" />
                                                    <ext:RecordField Name="D25" />
                                                    <ext:RecordField Name="D26" />
                                                    <ext:RecordField Name="D27" />
                                                    <ext:RecordField Name="D28" />
                                                    <ext:RecordField Name="D29" />
                                                    <ext:RecordField Name="D30" />
                                                    <ext:RecordField Name="D31" />
                                                    <ext:RecordField Name="Total" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>

                                <ColumnModel>
                                    <Columns>
                                        <ext:Column DataIndex="EmployeeID" Header="#QuetThe_ReportMonth.manv" Width="50" Fixed="true" />
                                        <ext:Column DataIndex="tenNV" Header="#QuetThe_ReportMonth.hoten" Width="130" />
                                        <ext:DateColumn DataIndex="ngayVao" Header="#QuetThe_ReportMonth.ngayvao" Width="65" />
                                        <ext:Column DataIndex="D17" Header="17" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D18" Header="18" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D19" Header="19" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D20" Header="20" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D21" Header="21" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D22" Header="22" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D23" Header="23" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D24" Header="24" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D25" Header="25" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D26" Header="26" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D27" Header="27" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D28" Header="28" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D29" Header="29" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D30" Header="30" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D31" Header="31" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D1" Header="1" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D2" Header="2" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D3" Header="3" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D4" Header="4" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D5" Header="5" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D6" Header="6" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D7" Header="7" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D8" Header="8" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D9" Header="9" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D10" Header="10" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D11" Header="11" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D12" Header="12" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D13" Header="13" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D14" Header="14" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D15" Header="15" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:Column DataIndex="D16" Header="16" Align="Center" Width="40"><Renderer Fn="rendD" /></ext:Column>
                                        <ext:NumberColumn DataIndex="Total" Header="#QuetThe_ReportMonth.tong" Align="Center" Width="50" Format="0.00" />

                                        <ext:CommandColumn Header="#" Width="50" ColumnID="cmd">
                                            <Commands>
                                                <ext:GridCommand Text="#QuetThe_ReportMonth.chitiet" CommandName="detail" />
                                            </Commands>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>

                                <SelectionModel>
                                    <ext:CellSelectionModel runat="server" />
                                </SelectionModel>

                                <DirectEvents>
                                    <Command OnEvent="grd_OnCommand">
                                        <ExtraParams>
                                            <ext:Parameter Name="id" Value="record.id" Mode="Raw" />
                                            <ext:Parameter Name="tenNV" Value="record.data.tenNV" Mode="Raw" />
                                            <ext:Parameter Name="command" Value="command" Mode="Raw" />
                                        </ExtraParams>
                                    </Command>
                                    <DblClick OnEvent="grd_OnDblClick" />
                                </DirectEvents>
                            </ext:GridPanel>
                        </Items>

                    </ext:Panel>

                </Items>
            </ext:Viewport>

            <ext:Hidden ID="h_detaiID" runat="server" />
            <ext:Window ID="wDetail" runat="server" Width="800" Height="350" Layout="FitLayout" Hidden="true">
                <Items>
                    
                    <ext:GridPanel ID="grdDetail" runat="server" Border="false" Region="Center">
                        <Store>
                            <ext:Store ID="stoDetail" runat="server" OnBeforeStoreChanged="stoDetail_BeforeStoreChanged" OnSubmitData="stoDetail_SubmitData">
                                <DirectEventConfig IsUpload="true" />
                                <Reader>
                                    <ext:JsonReader IDProperty="id">
                                        <Fields>
                                            <ext:RecordField Name="ngay" Type="Date" />
                                            <ext:RecordField Name="trangThai" />
                                            <ext:RecordField Name="TT" />
                                            <ext:RecordField Name="tgQuetDen" />
                                            <ext:RecordField Name="tgDiMuon" />
                                            <ext:RecordField Name="tgQuetVe" />
                                            <ext:RecordField Name="tgVeSom" />
                                            <ext:RecordField Name="tgTangCa" />
                                            <ext:RecordField Name="tgTinhTangCa" />
                                            <ext:RecordField Name="nghiCaNgay" />
                                            <ext:RecordField Name="lydo" />
                                            <ext:RecordField Name="tt_error" />
                                            <ext:RecordField Name="isLocked" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>

                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:Button runat="server" Text="#QuetThe_ReportMonth.luulai" Icon="Disk">
                                        <Listeners>
                                            <Click Handler="stoDetail.save();" />
                                        </Listeners>
                                    </ext:Button>

                                    <ext:Button ID="btnReloadDetail" runat="server" Text="#QuetThe_ReportMonth.tailai" Icon="Reload" OnDirectClick="btnReloadDetail_DirectClick" />

                                    <ext:ToolbarFill />
                                    <ext:Button runat="server" Text="#QuetThe_ReportMonth.xuatEx" Icon="PageExcel">
                                        <Listeners>
                                            <Click Handler="#{stoDetail}.submitData();" />
                                        </Listeners>
                                    </ext:Button>

                                </Items>
                            </ext:Toolbar>
                        </TopBar>

                        <ColumnModel>
                            <Columns>
                                <ext:Column Header="L" Fixed="true" Width="30" DataIndex="isLocked" Sortable="false">
                                    <Renderer Fn="rendLock" />
                                </ext:Column>

                                <ext:DateColumn Header="#QuetThe_ReportMonth.ngay" DataIndex="ngay" Format="dd/MM/yyyy" Width="70" />
                                <ext:Column Header="#QuetThe_ReportMonth.trangthai" DataIndex="TT" Width="50" />
                                <ext:Column Header="#QuetThe_ReportMonth.tgQuetDen" DataIndex="tgQuetDen" Width="55" >
                                    <Editor>
                                        <ext:TextField runat="server" />
                                    </Editor>
                                    <EditorOptions>
                                        <Listeners>
                                            <StartEdit Handler="this.field.setReadOnly(this.record.data.isLocked == 1);" />
                                        </Listeners>
                                    </EditorOptions>
                                </ext:Column>
                                <ext:Column Header="#QuetThe_ReportMonth.tgDiMuon" DataIndex="tgDiMuon" Width="50" />
                                <ext:Column Header="#QuetThe_ReportMonth.tgQuetVe" DataIndex="tgQuetVe" Width="55">
                                    <Editor>
                                        <ext:TextField runat="server" />
                                    </Editor>
                                    <EditorOptions>
                                        <Listeners>
                                            <StartEdit Handler="this.field.setReadOnly(this.record.data.isLocked == 1);" />
                                        </Listeners>
                                    </EditorOptions>
                                </ext:Column>
                                <ext:Column Header="#QuetThe_ReportMonth.tgVeSom" DataIndex="tgVeSom" Width="50" />
                                <ext:Column Header="#QuetThe_ReportMonth.tgTangCa" DataIndex="tgTangCa" Width="50" />
                                <ext:Column Header="TG tính TC (h)" DataIndex="tgTinhTangCa" Width="50" />
                                <ext:Column Header="Xin nghỉ" DataIndex="nghiCaNgay" Width="70"><Renderer Fn="GenXinNghiBuoi" /></ext:Column>
                                <ext:Column Header="Lý do nghỉ" DataIndex="lydo" Width="50" />
                                <ext:Column Header="ER" DataIndex="tt_error" Width="30"><Renderer Fn="GenEr" /></ext:Column>
                            </Columns>
                        </ColumnModel>

                        <BottomBar>
                            <ext:StatusBar runat="server" StatusAlign="Right">
                                <Items>
                                    <ext:Label ID="stt_Ngay" runat="server" Text="Tổng: 0" />
                                    <ext:ToolbarSeparator runat="server" />
                                    <ext:Label ID="stt_CongWD" runat="server" Text="WD: 0" />
                                    <ext:ToolbarSeparator runat="server" />
                                    <ext:Label ID="stt_CongCN" runat="server" Text="CN: 0" />
                                    <ext:ToolbarSeparator runat="server" />
                                    <ext:Label ID="stt_DSVM" runat="server" Text="DM: 0" />
                                </Items>
                            </ext:StatusBar>
                        </BottomBar>

                        <SelectionModel>
                            <ext:RowSelectionModel runat="server" SingleSelect="false" />
                        </SelectionModel>

                    </ext:GridPanel>

                </Items>
            </ext:Window>
        </div>
    </form>
</body>
</html>
