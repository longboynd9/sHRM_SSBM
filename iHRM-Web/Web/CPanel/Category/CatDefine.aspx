<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatDefine.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Category.CatDefine" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
        function cmbTableName_Select(sender, e, idx) {

            Panel1.autoLoad.url = "CatDefineDetail.aspx?catDefID=" + cmbTableName.value +
                "&tableName=" + stoCatDef.getById(cmbTableName.value).data.tableName +
                "&idColumnName=" + stoCatDef.getById(cmbTableName.value).data.idColumnName;
            Panel1.reload();

        }
    </script>
    
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
    
<ext:ResourceManager ID="ResourceManager1" runat="server" />
    
<ext:Store ID="stoCatDef" runat="server" OnRefreshData="stoCatDef_RefreshData">
    <Reader>
        <ext:JsonReader IDProperty="id">
            <Fields>
                <ext:RecordField Name="id" />
                <ext:RecordField Name="caption" />
                <ext:RecordField Name="tableName" />
                <ext:RecordField Name="idColumnName" />
            </Fields>
        </ext:JsonReader>
    </Reader>
</ext:Store>
    
<ext:Viewport runat="server" Layout="FitLayout">
    <Items>

        <ext:Panel ID="Panel1"  runat="server" Border="false" >
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>

                        <ext:ComboBox ID="cmbTableName" runat="server" StoreID="stoCatDef" DisplayField="caption" ValueField="id" Editable="false">
                            <Listeners>
                                <Select Fn="cmbTableName_Select" />
                            </Listeners>
                        </ext:ComboBox>

                    </Items>
                </ext:Toolbar>
            </TopBar>

            <AutoLoad Url="" Mode="IFrame" ShowMask="true" />

        </ext:Panel>

    </Items>
</ext:Viewport>

</form>
</body>
</html>
