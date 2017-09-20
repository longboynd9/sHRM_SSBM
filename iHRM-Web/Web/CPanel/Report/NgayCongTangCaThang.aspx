<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NgayCongTangCaThang.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Report.NgayCongTangCaThang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/sHRM/Styles/css/ext.css" rel="stylesheet" />

    <script>
        var converttime = function (value) {

            if (value != null) {
                return value + "h";
            }
            else {
                return "0h";
            }
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:Store ID="Store1" runat="server" OnSubmitData="sto1_SubmitData" GroupField="DepName"  >
<%--            <Proxy>
                <ext:PageProxy />
            </Proxy>--%>
            <DirectEventConfig IsUpload="true" />
            <Reader>
                <ext:JsonReader IDProperty="id">
                    <Fields>
                        <ext:RecordField Name="ngay" Type="Date" />
                        <ext:RecordField Name="SoNgayCong" />
                        <ext:RecordField Name="NghiLe" />
                        <ext:RecordField Name="NghiPhep" />
                        <ext:RecordField Name="NghiKhongPhep" />
                        <ext:RecordField Name="NghiKhongLuong" />
                        <ext:RecordField Name="NghiOm" />
                        <ext:RecordField Name="NghiThaiSan" />
                        <ext:RecordField Name="NghiKhac" />
                        <ext:RecordField Name="NghiCheDo" />
                        <ext:RecordField Name="NghiMaChay" />
                        <ext:RecordField Name="NghiKetHon" />
                        <ext:RecordField Name="NghiPhepNam" />
                        <ext:RecordField Name="NghiVangMat" />
                        <ext:RecordField Name="DChuNhat" />
                        <ext:RecordField Name="NghiKhongLuongVM" />
                        <ext:RecordField Name="TangCa" Type="Float" />
                        <ext:RecordField Name="tenNV" />
                        <ext:RecordField Name="DepName" />
                        <ext:RecordField Name="EmployeeID" />
                        <ext:RecordField Name="PosName" />
                        <ext:RecordField Name="tgTinhTangCa" />
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
          <%--  <AutoLoadParams>
                <ext:Parameter Name="start" Value="0" Mode="Raw" />
                <ext:Parameter Name="limit" Value="100" Mode="Raw" />
            </AutoLoadParams>--%>
        </ext:Store>
        <ext:Hidden runat="server" ID="hdhidde"></ext:Hidden>
        <ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout">
            <Items>
                <ext:GridPanel
                    ID="GridPanel2"
                    runat="server"
                    Border="false" Region="Center"
                    StoreID="Store1"
                    StripeRows="true"
                    AutoScroll="true"
                    Title="#Report_NgayCongTangCaThang.title"
                    AutoExpandColumn="DepName"
                    Collapsible="true"
                    AnimCollapse="true"
                    Icon="ApplicationViewColumns"
                    TrackMouseOver="false">
                    <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:TextField ID="txtSearch" runat="server" AllowBlank="true" EmptyText="Nhập mã NV, số thẻ" Width="120" />
                                <ext:Label runat="server" Text="#Report_NgayCongTangCaThang.lbPhongBan"></ext:Label>
                                <ext:DropDownField EmptyText="#Report_NgayCongTangCaThang.chonPB" ID="cbophong" runat="server" Editable="false" Width="300" TriggerIcon="SimpleArrowDown" HideLabel="true" AnchorHorizontal="100%" NoteAlign="Top">
                                    <Component>
                                        <ext:TreePanel
                                            ID="TreeFunc"
                                            runat="server"
                                            Title="#Report_NgayCongTangCaThang.dsPB"
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
                                <ext:Label runat="server" Text="#Report_NgayCongTangCaThang.tungay" />
                                <ext:DateField ID="txtDate" HideLabel="true" runat="server" Format="dd/MM/yyyy" Width="95">
                                    <%-- <Plugins>
                                        <ext:MonthPicker runat="server" />
                                    </Plugins>--%>
                                </ext:DateField>
                                <ext:Label runat="server" Text="#Report_NgayCongTangCaThang.denngay" />
                                <ext:DateField ID="todate" HideLabel="true" runat="server" Format="dd/MM/yyyy" Width="95">
                                    <%-- <Plugins>
                                        <ext:MonthPicker runat="server" />
                                    </Plugins>--%>
                                </ext:DateField>
                                <ext:Button ID="btnSearch" runat="server" Icon="ArrowRefreshSmall" Text="#common_btn.Find">
                                       <DirectEvents>
                                        <Click OnEvent="Search" IsUpload="true" Timeout="120000">
                                            <EventMask ShowMask="true" />
                                        </Click>
                                    </DirectEvents>
                                
                                </ext:Button>
                                <ext:Button runat="server" Text="Export" Icon="PageExcel">
                                    <DirectEvents>
                                        <Click OnEvent="btnExcel_DirectClick" IsUpload="true" Timeout="120000">
                                            <EventMask ShowMask="false" />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:GroupingSummaryColumn
                                ColumnID="DepName"
                                Header="#Report_NgayCongTangCaThang.pb"
                                Sortable="true"
                                DataIndex="DepName"
                                Hideable="true"
                                SummaryType="Count">
                                <SummaryRenderer Handler="return ((value === 0 || value > 1) ? '(' + value +' phòng ban)' : '(1 Task)');" />
                                <Editor>
                                    <ext:TextField runat="server" AllowBlank="false" />
                                </Editor>
                            </ext:GroupingSummaryColumn>
                            <ext:Column ColumnID="EmployeeName" Header="#Report_NgayCongTangCaThang.tenNV" DataIndex="tenNV" Width="150" Align="Left" />
                            <ext:Column Header="#Report_NgayCongTangCaThang.MaNV" DataIndex="EmployeeID" Width="70"></ext:Column>
                            <ext:Column Header="#Report_NgayCongTangCaThang.chucvu" DataIndex="PosName" Width="70"></ext:Column>
                            <ext:Column Header="1" DataIndex="D1" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="2" DataIndex="D2" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="3" DataIndex="D3" Width="40" Align="Center"></ext:Column>
                            <ext:Column Header="4" DataIndex="D4" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="5" DataIndex="D5" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="6" DataIndex="D6" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="7" DataIndex="D7" Width="40" Align="Center"></ext:Column>
                            <ext:Column Header="8" DataIndex="D8" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="9" DataIndex="D9" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="10" DataIndex="D10" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="11" DataIndex="D11" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="12" DataIndex="D12" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="13" DataIndex="D13" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="14" DataIndex="D14" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="15" DataIndex="D15" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="16" DataIndex="D16" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="17" DataIndex="D17" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="18" DataIndex="D18" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="19" DataIndex="D19" Width="40" Align="Center"></ext:Column>
                            <ext:Column Header="20" DataIndex="D20" Width="40" Align="Center"></ext:Column>
                            <ext:Column Header="21" DataIndex="D21" Width="40" Align="Center"></ext:Column>
                            <ext:Column Header="22" DataIndex="D22" Width="40" Align="Center"></ext:Column>
                            <ext:Column Header="23" DataIndex="D23" Width="40" Align="Center"></ext:Column>
                            <ext:Column Header="24" DataIndex="D24" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="25" DataIndex="D25" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="26" DataIndex="D26" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="27" DataIndex="D27" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="28" DataIndex="D28" Width="40" Align="Center"></ext:Column>
                            <ext:Column Header="29" DataIndex="D29" Width="40" Align="Center"></ext:Column>
                            <ext:Column Header="30" DataIndex="D30" Width="40"  Align="Center"></ext:Column>
                            <ext:Column Header="31" DataIndex="D31" Width="40"  Align="Center"></ext:Column>
                           
                            <ext:Column Header="#Report_NgayCongTangCaThang.nghiLe" DataIndex="NghiLe" Align="Center"></ext:Column>
                            <ext:Column Header="#Report_NgayCongTangCaThang.LamChuNhat" DataIndex="DChuNhat" Align="Center"></ext:Column>    
                            <ext:Column Header="#Report_NgayCongTangCaThang.nghiKoPhep" DataIndex="NghiKhongPhep" Align="Center"></ext:Column>
                            <ext:Column Header="#Report_NgayCongTangCaThang.nghiPhep" DataIndex="NghiPhepNam" Align="Center"></ext:Column>
                            <ext:Column Header="#Report_NgayCongTangCaThang.NghiOm" DataIndex="NghiOm" Align="Center"></ext:Column>
                            <ext:Column Header="#Report_NgayCongTangCaThang.NghiThaiSan" DataIndex="NghiThaiSan" Align="Center"></ext:Column>
                            <ext:Column Header="#Report_NgayCongTangCaThang.NghiKhongLuong" DataIndex="NghiKhongLuongVM" Align="Center"></ext:Column>
                            <ext:Column Header="#Report_NgayCongTangCaThang.NghiCheDo" DataIndex="NghiCheDo" Align="Center"></ext:Column>
                            <ext:Column Header="#Report_NgayCongTangCaThang.NghiKhac" DataIndex="NghiKhac" Align="Center"></ext:Column>
                            <ext:NumberColumn Header="#Report_NgayCongTangCaThang.tongNC" DataIndex="SoNgayCong" Format="0.00" Align="Center"></ext:NumberColumn>
                            <ext:NumberColumn Header="#Report_NgayCongTangCaThang.tgTangCa" DataIndex="TangCa" Format="0.00" Align="Center">
                                <Renderer Fn="converttime" />
                            </ext:NumberColumn>
                        </Columns>
                    </ColumnModel>
                    <View>
                        <ext:GroupingView
                            ID="GroupingView1"
                            runat="server"
                            ForceFit="false"
                            MarkDirty="false"
                            ShowGroupName="false"
                            EnableNoGroups="true"
                            HideGroupedColumn="true" />
                    </View>


                    <%-- <Plugins>
                        <ext:GroupingSummary runat="server">
                            <Calculations>
                                <ext:JFunction Name="totalCost" Handler="return v + (record.data.Estimate * record.data.Rate);" />
                            </Calculations>
                        </ext:GroupingSummary>
                    </Plugins>--%>
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
                            EmptyMsg="#common_btn.Pagging_EmptyMsg">
                            <Items>
                                <ext:Label ID="Label2" runat="server" Text="#common_btn.Pagging_PageSize" />
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
