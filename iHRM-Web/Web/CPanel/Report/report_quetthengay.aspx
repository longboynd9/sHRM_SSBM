<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="report_quetthengay.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Report.report_quetthengay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/sHRM/Styles/css/ext.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Store ID="Store1" runat="server" OnSubmitData="sto1_SubmitData" GroupField="DepName">
            <DirectEventConfig IsUpload="true" />
            <Reader>
                <ext:JsonReader IDProperty="id">
                    <Fields>
                        <ext:RecordField Name="ngay" Type="Date" />
                          <ext:RecordField Name="TT" />
                        <ext:RecordField Name="tgQuetDen" />
                        <ext:RecordField Name="tgDiMuon" />
                        <ext:RecordField Name="tgQuetVe" />
                        <ext:RecordField Name="tgVeSom" />
                        <ext:RecordField Name="tgTangCa" />
                        <ext:RecordField Name="tgTinhTangCa" />
                        <ext:RecordField Name="EmployeeName" />
                        <ext:RecordField Name="DepName" />
                        <ext:RecordField Name="SexID" />
                        <ext:RecordField Name="EmployeeCode" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout" HideBorders="true" AutoScroll="true">
            <Items>
                <ext:Hidden runat="server" ID="hdhidde"></ext:Hidden>
                <ext:GridPanel ID="GridPanel1" runat="server" Border="false" Region="Center" StoreID="Store1">
                    <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:TextField ID="txtSearch" runat="server" AllowBlank="true" EmptyText="Nhập mã NV, số thẻ" Width="120" />
                                <ext:Label runat="server" Text="#report_quetthengay.lbPhongBan"></ext:Label>
                                <ext:DropDownField EmptyText="#report_quetthengay.chonPB" ID="cbophong" runat="server" Editable="false" Width="300" TriggerIcon="SimpleArrowDown" HideLabel="true" AnchorHorizontal="100%" NoteAlign="Top">
                                    <Component>
                                        <ext:TreePanel
                                            ID="TreeFunc"
                                            runat="server"
                                            Title="#report_quetthengay.dsPB"
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
                                <ext:Label runat="server" Text="#report_quetthengay.tungay" />
                                <ext:DateField ID="txtDate" HideLabel="true" runat="server" Format="dd/MM/yyyy" Width="95">
                                </ext:DateField>
                                <ext:Label runat="server" Text="#report_quetthengay.denngay" />
                                <ext:DateField ID="txtoday" HideLabel="true" runat="server" Format="dd/MM/yyyy" Width="95">
                                </ext:DateField>
                                <ext:Button ID="btnSearch" runat="server" Icon="ArrowRefreshSmall" Text="#common_btn.Find" >
                                        <DirectEvents>
                                        <Click OnEvent="Search" IsUpload="true" Timeout="120000">
                                            <EventMask ShowMask="true" />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                                <ext:Button runat="server" Text="Export" Icon="PageExcel">
                                    <Listeners>
                                        <Click Handler="#{Store1}.submitData();" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <ColumnModel>
                        <Columns>
                             <ext:GroupingSummaryColumn
                                ColumnID="DepName"
                                Header="#report_quetthengay.bophan"
                                Sortable="true"
                                DataIndex="DepName"
                                Hideable="true"
                                SummaryType="Count">
                                <SummaryRenderer Handler="return ((value === 0 || value > 1) ? '(' + value +' phòng ban)' : '(1 Task)');" />
                                <Editor>
                                    <ext:TextField runat="server" AllowBlank="false" />
                                </Editor>
                            </ext:GroupingSummaryColumn>
                            <ext:Column Header="#report_quetthengay.MaNV" DataIndex="EmployeeCode"></ext:Column>
                            <ext:Column Header="#report_quetthengay.tenNV" DataIndex="EmployeeName"></ext:Column>
                            <ext:Column Header="#report_quetthengay.gioitinh" DataIndex="SexID"></ext:Column>
                    
                            <ext:DateColumn Header="#report_quetthengay.ngay2" DataIndex="ngay" Format="dd/MM/yyyy" />
                            <ext:Column Header="#report_quetthengay.trangthai" DataIndex="TT" />
                            <ext:Column Header="#report_quetthengay.quetDen" DataIndex="tgQuetDen">
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                            <ext:Column Header="#report_quetthengay.tgDiMuon" DataIndex="tgDiMuon" />
                            <ext:Column Header="#report_quetthengay.quetVe" DataIndex="tgQuetVe">
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                            <ext:Column Header="#report_quetthengay.tgVeSom" DataIndex="tgVeSom" />
                            <ext:Column Header="#report_quetthengay.tgTangCa" DataIndex="tgTinhTangCa" />
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
                </ext:GridPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
