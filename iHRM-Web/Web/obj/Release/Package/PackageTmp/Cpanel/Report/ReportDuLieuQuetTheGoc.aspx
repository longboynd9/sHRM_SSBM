<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportDuLieuQuetTheGoc.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Report.ReportDuLieuQuetTheGoc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/sHRM/Styles/css/ext.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:Store ID="Store1" runat="server"  GroupField="DepName" AutoLoad="true" RemotePaging="true" >
            <DirectEventConfig IsUpload="true" />
            <Reader>
                <ext:JsonReader IDProperty="id">
                    <Fields>
                        <ext:RecordField Name="thoigian" Type="Date" />
                        <ext:RecordField Name="EmployeeName" />
                        <ext:RecordField Name="DepName" />
                        <ext:RecordField Name="EmployeeCode" />
                        <ext:RecordField Name="CardID" />
                        <ext:RecordField Name="maMay" />
                        <ext:RecordField Name="soMay" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="0" Mode="Raw" />
                <ext:Parameter Name="limit" Value="100" Mode="Raw" />
            </AutoLoadParams>
        </ext:Store>

        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout" HideBorders="true" AutoScroll="true">
            <Items>
                <ext:Hidden runat="server" ID="hdhidde"></ext:Hidden>
                <ext:GridPanel
                    ID="GridPanel2"
                    runat="server"
                    Frame="true"
                    StoreID="Store1"
                    StripeRows="true"
                    Title="#Báo cáo quẹt thẻ gốc"
                    AutoExpandColumn="DepName"
                    Collapsible="false"
                    AnimCollapse="false"
                    Icon="ApplicationViewColumns"
                    TrackMouseOver="false"
                    Border="false" Region="Center"
                    ClicksToEdit="1">
                    <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:TextField ID="txtSearch" runat="server" AllowBlank="true" EmptyText="Nhập mã NV, số thẻ" Width="120" />
                                <ext:Label runat="server" Text="#ReportChiTietVaoRaThang.lbPhongBan"></ext:Label>
                                <ext:DropDownField EmptyText="#ReportChiTietVaoRaThang.chonPB" ID="cbophong" runat="server" Editable="false" Width="300" TriggerIcon="SimpleArrowDown" HideLabel="true" AnchorHorizontal="100%" NoteAlign="Top">
                                    <Component>
                                        <ext:TreePanel
                                            ID="TreeFunc"
                                            runat="server"
                                            Title="#ReportChiTietVaoRaThang.dsPB"
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
                                <ext:Label runat="server" Text="#ReportChiTietVaoRaThang.tungay" />
                                <ext:DateField ID="txtDate" HideLabel="true" runat="server" Format="dd/MM/yyyy" Width="95">
                                    <%-- <Plugins>
                                        <ext:MonthPicker runat="server" />
                                    </Plugins>--%>
                                </ext:DateField>
                                <ext:Label runat="server" Text="#ReportChiTietVaoRaThang.denngay" />
                                <ext:DateField ID="todate" HideLabel="true" runat="server" Format="dd/MM/yyyy" Width="95">
                                    <%-- <Plugins>
                                        <ext:MonthPicker runat="server" />
                                    </Plugins>--%>
                                </ext:DateField>
                                <ext:Button ID="btnSearch" runat="server" Icon="ArrowRefreshSmall" Text="#common_btn.Find">
                                    <DirectEvents>
                                        <Click OnEvent="btnSearch_click" />
                                    </DirectEvents>
                                </ext:Button>
                                 <%--<ext:Button runat="server" Text="Export" Icon="PageExcel">
                                     <DirectEvents>
                                         <Click OnEvent="btnExcel_DirectClick" IsUpload="true" Timeout="120000">
                                             <EventMask ShowMask="false" />
                                         </Click>
                                     </DirectEvents>
                                 </ext:Button>--%>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:GroupingSummaryColumn
                                ColumnID="DepName"
                                Header="#ReportChiTietVaoRaThang.pb"
                                Sortable="true"
                                DataIndex="DepName"
                                Hideable="true"
                                SummaryType="Count">
                                <SummaryRenderer Handler="return ((value === 0 || value > 1) ? '(' + value +' Tasks)' : '(1 Task)');" />
                                <Editor>
                                    <ext:TextField runat="server" AllowBlank="false" />
                                </Editor>
                            </ext:GroupingSummaryColumn>
                            <ext:Column Header="#ReportChiTietVaoRaThang.MaNV" DataIndex="EmployeeCode" Width="70" />
                            <ext:Column ColumnID="EmployeeName" Header="#ReportChiTietVaoRaThang.tenNV" DataIndex="EmployeeName" />
                            <ext:DateColumn Header="#ReportChiTietVaoRaThang.ngay" DataIndex="thoigian" Format="dd/MM/yyyy" Width="70" Align="Center" />
                            <ext:DateColumn Header="Giờ quẹt" DataIndex="thoigian" Format="hh:mm:ss tt" Width="70" Align="Center" />
                            <ext:Column Header="Mã thẻ" DataIndex="CardID" />
                            <ext:Column Header="Số máy" DataIndex="soMay" />
                            <ext:Column Header="Mã máy" DataIndex="maMay" />
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
