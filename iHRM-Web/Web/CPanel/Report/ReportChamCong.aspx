<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportChamCong.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Report.ReportChamCong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/sHRM/Styles/css/ext.css" rel="stylesheet" />

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
                OpenEditor(record.id, '#Report_ReportChamCong.msg_js1' + record.id);
            }
            else if (cmdName == 'Delete') {
                //Ext.Msg.show({
                //    icon: Ext.MessageBox.QUESTION,
                //    msg: 'Bạn chắc chắn muốn xóa?',
                //    buttons: Ext.Msg.OKCANCEL
                //});

                return confirm("#Report_ReportChamCong.msg_js2");
            }
        }

    </script>
    
    <script src="/Assets/js/jquery-1.9.1.js"></script>
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
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Store ID="Store1" runat="server" GroupField="DepName">
            <DirectEventConfig IsUpload="true" />
            <Reader>
                <ext:JsonReader IDProperty="id">
                    <Fields>
                        <ext:RecordField Name="NgayCong" />
                        <ext:RecordField Name="NghiLe" />
                        <ext:RecordField Name="TT" />
                        <ext:RecordField Name="NghiCoLuong" />
                        <ext:RecordField Name="NghiPhepNam" />
                        <ext:RecordField Name="NghiKhongLuong" />
                        <ext:RecordField Name="TangCa" />
                        <ext:RecordField Name="ChuNhat" />
                        <%--<ext:RecordField Name="tgTangCa" />--%>
                        <ext:RecordField Name="tenNV" />
                        <ext:RecordField Name="DepName" />
                        <ext:RecordField Name="SexID" />
                        <ext:RecordField Name="EmployeeID" />
                        <ext:RecordField Name="TangCaLe" />

                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout" HideBorders="true" AutoScroll="true">
            <Items>
                <%--<ext:Panel runat="server" Region="West" Border="false" Collapsible="true" Split="true" Width="170" Layout="FormLayout" Padding="10">
                    <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:ToolbarFill runat="server" />
                                <ext:Button ID="Button1" runat="server" Icon="ArrowRefreshSmall" Text="#common_btn.Find">
                                    <Listeners>
                                        <Click Handler="Store1.reload()" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <Items>
                        <ext:CompositeField runat="server" AnchorHorizontal="100%" HideLabel="true">
                            <Items>
                                <ext:TextField ID="txtNhanVien" Note="#Report_ReportChamCong.MaNV" HideLabel="true" runat="server" AllowBlank="false" MaskRe="[^<>&amp;*]" IndicatorIcon="Information" IndicatorTip="EmployeeID" EnableKeyEvents="true" NoteAlign="Top" AnchorHorizontal="100%">
                                    <Listeners>
                                        <KeyDown Fn="txtMa_KeyDown" />
                                    </Listeners>
                                </ext:TextField>
                                <ext:Label runat="server" AnchorHorizontal="100%" FieldLabel=" "></ext:Label>

                            </Items>

                        </ext:CompositeField>
                        <ext:Button ID="btnFindMaVN" runat="server" NoteAlign="Top" OnDirectClick="btnFindMaVN_DirectClick" Icon="Zoom" Text="#common_btn.FindOne" AnchorHorizontal="100%" />
                        <%--<ext:Label runat="server" Text="&nbsp; Nhân viên: &nbsp;" />
                        <ext:TextField ID="txtNhanVien2" runat="server" ReadOnly="true" NoteAlign="Top" HideLabel="true" Note="#Report_ReportChamCong.nhanvien" AnchorHorizontal="100%"></ext:TextField>

                    </Items>
                </ext:Panel>--%>
                <ext:Hidden runat="server" ID="hdhidde"></ext:Hidden>
                <ext:GridPanel ID="GridPanel1" runat="server" Border="false" Region="Center" StoreID="Store1">
                    <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:TextField ID="txtSearch" runat="server" AllowBlank="true" EmptyText="Nhập mã NV, số thẻ" Width="120" />
                                <ext:Label runat="server" Text="#Report_ReportChamCong.lbPhongBan"></ext:Label>
                                <ext:DropDownField EmptyText="#Report_ReportChamCong.chonPB" ID="cbophong" runat="server" Editable="false" Width="300" TriggerIcon="SimpleArrowDown" HideLabel="true" AnchorHorizontal="100%" NoteAlign="Top">
                                    <Component>
                                        <ext:TreePanel
                                            ID="TreeFunc"
                                            runat="server"
                                            Title="#Report_ReportChamCong.dsPB"
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
                                <ext:Label runat="server" Text="#Report_ReportChamCong.tungay" />
                                <ext:DateField ID="txtDate" HideLabel="true" runat="server" Format="dd/MM/yyyy" Width="95">
                                </ext:DateField>
                                <ext:Label runat="server" Text="#Report_ReportChamCong.denngay" />
                                <ext:DateField ID="txttodate" HideLabel="true" runat="server" Format="dd/MM/yyyy" Width="95">
                                </ext:DateField>
                                <ext:Button ID="btnSearch" runat="server" Icon="ArrowRefreshSmall" Text="#common_btn.Find" >
                                    <DirectEvents>
                                            <Click OnEvent="Search" IsUpload="true" Timeout="120000">
                                                <EventMask ShowMask="true" />
                                            </Click>
                                    </DirectEvents>
                                </ext:Button>
                                <ext:Button runat="server" Text="Export" Icon="PageExcel"  >
                                     <DirectEvents>
                                            <Click OnEvent="btnexcel" IsUpload="true" Timeout="120000">
                                                <EventMask ShowMask="true" />
                                            </Click>
                                        </DirectEvents>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <ColumnModel>
                        <Columns>
                            <ext:GroupingSummaryColumn
                                ColumnID="DepName"
                                Sortable="true"
                                DataIndex="DepName"
                                Hideable="true"
                                SummaryType="Count">
                                <SummaryRenderer Handler="return ((value === 0 || value > 1) ? '(' + value +' Tasks)' : '(1 Task)');" />
                                <Editor>
                                    <ext:TextField runat="server" AllowBlank="false" />
                                </Editor>
                            </ext:GroupingSummaryColumn>
                            <ext:Column Header="#Report_ReportChamCong.MaNV" DataIndex="EmployeeID"></ext:Column>
                            <ext:Column Header="#Report_ReportChamCong.tenNV" DataIndex="tenNV"></ext:Column>
                            
                            <ext:Column Header="#Report_ReportChamCong.tongNC" DataIndex="NgayCong"></ext:Column>
                            <ext:Column Header="#Report_ReportChamCong.nghiLe" DataIndex="NghiLe"></ext:Column>
                            <ext:Column Header="Nghỉ phép năm" DataIndex="NghiPhepNam"></ext:Column>
                            <ext:Column Header="Nghỉ có lương" DataIndex="NghiCoLuong"></ext:Column>
                            <ext:Column Header="Nghỉ không lương" DataIndex="NghiKhongLuong"></ext:Column>
                            <ext:Column Header="#Report_ReportChamCong.tgTangCa" DataIndex="TangCa"/>
                            <ext:Column Header="Chủ nhật(Giờ)" DataIndex="ChuNhat" />
                            <ext:Column Header="Tăng ca lễ(Giờ)" DataIndex="TangCaLe" />
                        </Columns>
                    </ColumnModel>
                     <View>
                        <ext:GroupingView
                            ID="GroupingView1"
                            runat="server"
                            ForceFit="true"
                            MarkDirty="false"
                            ShowGroupName="false"
                            EnableNoGroups="true"
                            HideGroupedColumn="true" />
                    </View>
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
                            EmptyMsg="#common_btn.emptmsg">
                            <Items>
                                <ext:Label ID="Label2" runat="server" Text="Tổng" />
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
    </form>
</body>
</html>
