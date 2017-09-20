<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportTKNganHang.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Import.ImportTKNganHang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Import STK Ngân Hàng</title>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <script type="text/javascript">
        function btnImport_Click() {
            var s = "";
            stoMapping.data.items.forEach(function (r) {
                if (r.data.c2 != undefined && r.data.c2 != '') {
                    s += r.data.c1 + ':' + r.data.c2 + ',';
                }
            });
            if (s == "") {
                Ext.Msg.show({ icon: Ext.MessageBox.WARNING, msg:'Lỗi', buttons: Ext.Msg.OK });
                return false;
            }
            h_MappingString.setValue(s);
        }//

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager ID="ResourceManager1" runat="server" />
            <ext:Hidden ID="h_MappingString" runat="server" />
            <ext:Hidden ID="h_FileAttacked" runat="server" />
            <ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout" HideBorders="true" AutoScroll="true">
                <Items>
                    <ext:Panel ID="Panel1" runat="server" Region="North" LabelWidth="65" Border="false" Height="65" Layout="FormLayout" Padding="10">
                        <Items>
                            <ext:CompositeField ID="CompositeField1" runat="server">
                                <Items>
                                    <ext:Label Text="File import:" runat="server" ID="lbFileImport" />
                                    <ext:FileUploadField ID="txtUpFile" runat="server" ButtonText="Choose file" Width="220">
                                        <DirectEvents>
                                            <FileSelected IsUpload="true" OnEvent="txtUploadExcel_DirectUp" />
                                        </DirectEvents>
                                    </ext:FileUploadField>
                                </Items>
                            </ext:CompositeField>
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:Viewport>
            <ext:Window ID="wMapping" runat="server" Layout="FitLayout" Width="450" Height="270" Hidden="true" Title="MAPPING">
                <TopBar>
                    <ext:Toolbar ID="toolbar" runat="server">
                        <Items>
                            <ext:Button runat="server" ID="btnImport" Text="Import" >
                                <DirectEvents >
                                    <Click OnEvent="btnImport_DirectClick" />
                                </DirectEvents>
                               <Listeners>
                                    <Click Fn="btnImport_Click" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Items>
                    <ext:GridPanel ID="grdMapping" runat="server" Border="false">
                        <Store>
                            <ext:Store ID="stoMapping" runat="server">
                                <Reader>
                                    <ext:JsonReader IDProperty="c1">
                                        <Fields>
                                            <ext:RecordField Name="c1" />
                                            <ext:RecordField Name="c1Text" />
                                            <ext:RecordField Name="c2" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <ColumnModel>
                            <Columns>
                                <ext:Column Header="Column" DataIndex="c1Text" Width="200" />
                                <ext:Column Header="Mapping" DataIndex="c2" Width="200">
                                    <Editor>
                                        <ext:ComboBox ID="ComboBox1" runat="server" DisplayField="c1Text" ValueField="c1">
                                            <Store>
                                                <ext:Store ID="stoColMapping" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="c1">
                                                            <Fields>
                                                                <ext:RecordField Name="c1" />
                                                                <ext:RecordField Name="c1Text" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                        </ext:ComboBox>
                                    </Editor>
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                    </ext:GridPanel>
                </Items>
            </ext:Window>
        </div>
    </form>
</body>
</html>
