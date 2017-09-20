<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rep_BaoCaoGioiTinh.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Report.rep_BaoCaoGioiTinh" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" />
        <ext:Store ID="Store1" runat="server" OnSubmitData="sto1_SubmitData">
            <Reader>
                <ext:JsonReader IDProperty="id">
                    <Fields>
                        <ext:RecordField Name="EmployeeName" />
                        <ext:RecordField Name="DepName" />
                        <ext:RecordField Name="EmployeeID" />
                        <ext:RecordField Name="IDCard" />
                        <ext:RecordField Name="PosName" />
                        <ext:RecordField Name="Birthday" Type="Date" />
                        <ext:RecordField Name="CardID" />
                        <ext:RecordField Name="AppliedDate" Type="Date" />
                        <ext:RecordField Name="LeftDate" Type="Date" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Hidden runat="server" ID="hdhidde"></ext:Hidden>
        <ext:Viewport ID="viewport" runat="server">
            <Items>
                <ext:Toolbar ID="toolBar" runat="server">
                    <Items>
                        <ext:DropDownField ID="dropdownPB" runat="server">
                            <Component>
                                <ext:TreePanel ID="treePB" runat="server" ContainerScroll="true" Height="500px" Width="300px" AutoScroll="true">
                                    <SelectionModel>
                                        <ext:DefaultSelectionModel />
                                    </SelectionModel>
                                    <DirectEvents>
                                        <DblClick OnEvent="btnChoose_PB_DblClick" />
                                    </DirectEvents>
                                </ext:TreePanel>
                            </Component>
                        </ext:DropDownField>
                        <ext:Button ID="btnSearch" Icon="ArrowRefreshSmall" runat="server" Text="Search">
                            <DirectEvents>
                                <Click OnEvent="btnSearch_Click">
                                    <EventMask ShowMask="true" MinDelay="1000" />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
                <ext:GridPanel ID="gridNhanVien" runat="server">
                    <ColumnModel ID="ColumnModel1" runat="server">
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
                                    <ext:TextField ID="TextField1" runat="server" AllowBlank="false" />
                                </Editor>
                            </ext:GroupingSummaryColumn>--%>
                            <ext:Column Header="Mã NV" DataIndex="EmployeeID" Width="70"></ext:Column>
                            <ext:Column ColumnID="EmployeeName" Header="Tên NV" DataIndex="EmployeeName" Width="150" Align="Left" />
                            <ext:DateColumn Header="Ngày sinh" DataIndex="Birthday" Width="70" Format="dd/MM/yyyy"></ext:DateColumn>
                            <ext:Column Header="Số CMND" DataIndex="IDCard" Width="70"></ext:Column>
                            <ext:Column Header="Mã thẻ chấm công" DataIndex="CardID" Width="100"></ext:Column>
                            <ext:Column Header="#Report_NgayCongTangCaThang.chucvu" DataIndex="PosName" Width="150"></ext:Column>
                            <ext:Column Header="Phòng Ban" DataIndex="DepName" Width="200"></ext:Column>
                            <ext:DateColumn Header="Ngày vào làm" DataIndex="AppliedDate" Width="100" Format="dd/MM/yyyy"></ext:DateColumn>
                            <ext:DateColumn Header="Ngày nghỉ làm" DataIndex="LeftDate" Width="100" Format="dd/MM/yyyy"></ext:DateColumn>
                        </Columns>
                    </ColumnModel>
                </ext:GridPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
