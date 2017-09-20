<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportNhanVienNghiPhepNam.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Report.ReportNhanVienNghiPhepNam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/sHRM/Styles/css/ext.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Store ID="Store1" runat="server" OnSubmitData="sto1_SubmitData">
            <Reader>
                <ext:JsonReader IDProperty="id">
                    <Fields>
                        <ext:RecordField Name="EmployeeName" />
                        <ext:RecordField Name="DepName" />
                        <ext:RecordField Name="EmployeeID" />
                        <ext:RecordField Name="IDCard" />
                        <ext:RecordField Name="PosName" />
                        <ext:RecordField Name="Birthday"/>
                        <ext:RecordField Name="CardID" />
                        <ext:RecordField Name="AppliedDate"/>
                        <ext:RecordField Name="LeftDate"/>
                        <ext:RecordField Name="ngay" Type="Date" />
                        <ext:RecordField Name="songay"/>
                        <ext:RecordField Name="t1"/>
                        <ext:RecordField Name="t2"/>
                        <ext:RecordField Name="t3"/>
                        <ext:RecordField Name="t4"/>
                        <ext:RecordField Name="t5"/>
                        <ext:RecordField Name="t6"/>
                        <ext:RecordField Name="t7"/>
                        <ext:RecordField Name="t8"/>
                        <ext:RecordField Name="t9"/>
                        <ext:RecordField Name="t10"/>
                        <ext:RecordField Name="t11"/>
                        <ext:RecordField Name="t12"/>
                        <ext:RecordField Name="sophepdasudung"/>
                        <ext:RecordField Name="sophepconlai"/>
                        <ext:RecordField Name="tongsophep"/>
                    </Fields>
                </ext:JsonReader>
            </Reader>
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
                    Title="Thống kê nghỉ phép năm"
                    Collapsible="true"
                    AnimCollapse="true"
                    Icon="ApplicationViewColumns"
                    TrackMouseOver="false">
                    <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:Label ID="Label1" runat="server" Text="#Report_NgayCongTangCaThang.lbPhongBan"></ext:Label>
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
                                <ext:Button ID="btnSearch" runat="server" Icon="ArrowRefreshSmall" Text="#common_btn.Find">
                                    <DirectEvents>
                                        <Click OnEvent="Search" Timeout="120000">
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
                            <%--<ext:GroupingSummaryColumn
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
                            </ext:GroupingSummaryColumn>--%>
                            <ext:Column Header="Mã NV" DataIndex="EmployeeID" Width="50"></ext:Column>
                            <ext:Column Header="Tên NV" ColumnID="EmployeeName" DataIndex="EmployeeName" Width="120" Align="Left" />
                            <ext:Column Header="Ngày sinh" DataIndex="Birthday" Width="70" Align="Center"></ext:Column>
                            <ext:Column Header="Số CMND" DataIndex="IDCard" Width="70"  Align="Center"></ext:Column>
                            <ext:Column Header="Mã thẻ chấm công" DataIndex="CardID" Width="100"></ext:Column>
                            <ext:Column Header="#Report_NgayCongTangCaThang.chucvu" DataIndex="PosName" Width="120"></ext:Column>
                            <ext:Column Header="Phòng Ban" DataIndex="DepName" Width="120"></ext:Column>
                            <ext:Column Header="Ngày vào" DataIndex="AppliedDate" Width="70"   Align="Center"></ext:Column>
                            <ext:Column Header="Ngày nghỉ làm" DataIndex="LeftDate" Width="80"  Align="Center"></ext:Column>
                            <ext:Column Header="Tổng phép năm" DataIndex="tongsophep" Width="90"  Align="Center"></ext:Column>
                            <ext:Column Header="1" DataIndex="t1" Width="45" Align="Center"></ext:Column>
                            <ext:Column Header="2" DataIndex="t2" Width="45" Align="Center"></ext:Column>
                            <ext:Column Header="3" DataIndex="t3" Width="45" Align="Center"></ext:Column>
                            <ext:Column Header="4" DataIndex="t4" Width="45" Align="Center"></ext:Column>
                            <ext:Column Header="5" DataIndex="t5" Width="45" Align="Center"></ext:Column>
                            <ext:Column Header="6" DataIndex="t6" Width="45" Align="Center"></ext:Column>
                            <ext:Column Header="7" DataIndex="t7" Width="45" Align="Center"></ext:Column>
                            <ext:Column Header="8" DataIndex="t8" Width="45" Align="Center"></ext:Column>
                            <ext:Column Header="9" DataIndex="t9" Width="45" Align="Center"></ext:Column>
                            <ext:Column Header="10" DataIndex="t10" Width="45" Align="Center"></ext:Column>
                            <ext:Column Header="11" DataIndex="t11" Width="45" Align="Center"></ext:Column>
                            <ext:Column Header="12" DataIndex="t12" Width="45" Align="Center"></ext:Column>
                            <ext:Column Header="Tổng phép năm sử dụng" DataIndex="sophepdasudung" Width="130"  Align="Center"></ext:Column>
                            <ext:Column Header="Số phép năm còn lại" DataIndex="sophepconlai" Width="130"  Align="Center"></ext:Column>
                        </Columns>
                    </ColumnModel>
                    <%--<View>
                        <ext:GroupingView
                            ID="GroupingView1"
                            runat="server"
                            ForceFit="false"
                            MarkDirty="false"
                            ShowGroupName="false"
                            EnableNoGroups="true"
                            HideGroupedColumn="true" />
                    </View>--%>

                    <%--<BottomBar>
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
                    </BottomBar>--%>
                </ext:GridPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
