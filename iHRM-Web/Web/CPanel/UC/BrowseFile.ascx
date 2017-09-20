<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BrowseFile.ascx.cs" Inherits="iHRM.WebPC.Cpanel.UC.BrowseFile" %>

<script type="text/javascript">
    function test(p1, p2, p3, p4) {
        console.log(p1, p2, p3, p4);
    }

    $(document).ready(function () {
        Ext.onReady(function () {
            BrowseFile1_stoFile.on('beforeload', function (s) {
                alert(BrowseFile1_grdFolder.getSelectionModel().selections.items[0].data.path);
                s.setBaseParam('path', BrowseFile1_grdFolder.getSelectionModel().selections.items[0].data.path);
            });
        });
    });
</script>

<ext:Store ID="stoFolder" OnRefreshData="stoFolder_RefreshData" runat="server">
    <Reader>
        <ext:JsonReader IDProperty="ID">
            <Fields>
                <ext:RecordField Name="ID" />
                <ext:RecordField Name="ParentID" />
                <ext:RecordField Name="path" />
                <ext:RecordField Name="folder" />
            </Fields>
        </ext:JsonReader>
    </Reader>
</ext:Store>
<ext:Store ID="stoFile" OnRefreshData="stoFile_RefreshData" runat="server">
    <Reader>
        <ext:JsonReader IDProperty="name">
            <Fields>
                <ext:RecordField Name="name" />
            </Fields>
        </ext:JsonReader>
    </Reader>
</ext:Store>

<ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
    <Items>
        <ext:Panel runat="server" Region="West" Width="300" Collapsible="true" Split="true" Layout="FitLayout" Title="Folder">
            <Tools>
                <ext:Tool Type="Refresh" Handler="#{stoFolder}.reload()" />
            </Tools>
            <Items>
                <ext:GridPanel runat="server" ID="grdFolder" Border="false" StoreID="stoFolder" AutoExpandColumn="folder" AutoLoad="true" >
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:Column ColumnID="folder" Header="Folder" DataIndex="folder" />
                        </Columns>
                    </ColumnModel>
                    
                    <SelectionModel>
                        <ext:RowSelectionModel runat="server" SingleSelect="true">
                        </ext:RowSelectionModel>
                    </SelectionModel>
                </ext:GridPanel>
            </Items>
        </ext:Panel>

        <ext:Panel runat="server" Region="Center" Layout="FitLayout">
            <Items>
                <ext:GridPanel runat="server" ID="grdFile" StoreID="stoFile">
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:Column ColumnID="name" Header="Folder" DataIndex="name" />
                        </Columns>
                    </ColumnModel>
                </ext:GridPanel>
            </Items>
        </ext:Panel>
    </Items>
</ext:Viewport>
