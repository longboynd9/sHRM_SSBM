<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThongkedulieuquetheNgay.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Report.ThongkedulieuquetheNgay" %>


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
                        <ext:RecordField Name="trangThai" />
                        <ext:RecordField Name="TT" />
                        <ext:RecordField Name="tgQuetDen" />
                        <ext:RecordField Name="tgDiMuon" />
                        <ext:RecordField Name="tgQuetVe" />
                        <ext:RecordField Name="tgVeSom" />
                        <ext:RecordField Name="tgTangCa" />
                        <ext:RecordField Name="EmployeeName" />
                        <ext:RecordField Name="DepName" />
                        <ext:RecordField Name="SexID" />
                        <ext:RecordField Name="EmployeeCode" />
                        <ext:RecordField Name="ten" />
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
                                <ext:Label runat="server" Text="#Report_ThongkedulieuquetheNgay.lbPhongBan"></ext:Label>
                                <ext:DropDownField EmptyText="#Report_ThongkedulieuquetheNgay.chonPB" ID="cbophong" runat="server" Editable="false" Width="300" TriggerIcon="SimpleArrowDown" HideLabel="true" AnchorHorizontal="100%" NoteAlign="Top">
                                    <Component>
                                        <ext:TreePanel
                                            ID="TreeFunc"
                                            runat="server"
                                            Title="#Report_ThongkedulieuquetheNgay.title"
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
                                <ext:Label runat="server" Text="#Report_ThongkedulieuquetheNgay.tungay" />
                                <ext:DateField ID="txtDate" HideLabel="true" runat="server" Format="dd/MM/yyyy" Width="95">
                                </ext:DateField>
                                 <ext:Label runat="server" Text="#Report_ThongkedulieuquetheNgay.denngay" />
                                <ext:DateField ID="txtoday" HideLabel="true" runat="server" Format="dd/MM/yyyy" Width="95">
                                </ext:DateField>
                                <ext:ToolbarSeparator runat="server"></ext:ToolbarSeparator>
                                <ext:ComboBox runat="server" ID="cboloai" FieldLabel="#Report_ThongkedulieuquetheNgay.loaiquetthe" LabelWidth="80" Width="190">
                                    <Items>
                                        <ext:ListItem Text="No In - no Out" Value="0" />
                                        <ext:ListItem Text="In - no Out" Value="1" />
                                        <ext:ListItem Text="No In - Out" Value="2" />
                                        <%--<ext:ListItem Text="punching card > 2" Value="3" />--%>
                                        <ext:ListItem Text="punching card = 2" Value="4" />
                                        <ext:ListItem Text="In - All out" Value="6" />
                                        <ext:ListItem Text="All of in out" Value="5" /> 
                                    </Items>
                                </ext:ComboBox>
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
                                          <%--  <EventMask ShowMask="true" />--%>
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
                                Header="#Report_ThongkedulieuquetheNgay.pb"
                                Sortable="true"
                                DataIndex="DepName"
                                Hideable="true"
                                SummaryType="Count">
                                <SummaryRenderer Handler="return ((value === 0 || value > 1) ? '(' + value +' phòng ban)' : '(1 Task)');" />
                                <Editor>
                                    <ext:TextField runat="server" AllowBlank="false" />
                                </Editor>
                            </ext:GroupingSummaryColumn>
                            <ext:Column Header="#Report_ThongkedulieuquetheNgay.MaNV" DataIndex="EmployeeCode"></ext:Column>
                            <ext:Column Header="#Report_ThongkedulieuquetheNgay.tenNV" DataIndex="EmployeeName"></ext:Column>
                            <ext:Column Header="#Report_ThongkedulieuquetheNgay.gioitinh" DataIndex="SexID"></ext:Column>
                            <ext:Column Header="#Report_ThongkedulieuquetheNgay.bophan" DataIndex="DepName"></ext:Column>
                            <ext:DateColumn Header="#Report_ThongkedulieuquetheNgay.ngay" DataIndex="ngay" Format="dd/MM/yyyy" />
                            <ext:Column Header="#Report_ThongkedulieuquetheNgay.vaothuc" DataIndex="tgQuetDen" />
                            <ext:Column Header="#Report_ThongkedulieuquetheNgay.rathuc" DataIndex="tgQuetVe" />
                            <ext:Column Header="#Report_ThongkedulieuquetheNgay.ca" DataIndex="ten" />
                            <%--                   <ext:Column Header="Trạng Thai" DataIndex="TT" />
                            <ext:Column Header="Quẹt đến lúc" DataIndex="tgQuetDen">
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                            <ext:Column Header="TG đi muộn" DataIndex="tgDiMuon" />
                            <ext:Column Header="Quẹt về lúc" DataIndex="tgQuetVe">
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                            <ext:Column Header="TG về sớm" DataIndex="tgVeSom" />
                            <ext:Column Header="TG tăng ca" DataIndex="tgTangCa" />--%>
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
