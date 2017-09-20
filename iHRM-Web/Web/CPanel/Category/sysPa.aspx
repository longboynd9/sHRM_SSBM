<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sysPa.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Category.sysPa" %>

<%@ Register Src="../UC/ImageUploader.ascx" TagName="ImageUploader" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager ID="ResourceManager1" runat="server" />
                        
            <ext:Store ID="Store1" runat="server" ShowWarningOnFailure="false" OnBeforeStoreChanged="Store1_BeforeChanged" RefreshAfterSaving="None">
                <Reader>
                    <ext:JsonReader IDProperty="Id">
                        <Fields>
                            <ext:RecordField Name="id" />
                            <ext:RecordField Name="code" />
                            <ext:RecordField Name="caption" />
                            <ext:RecordField Name="value" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            
                <Listeners>
                    <Exception Handler="
                        Ext.net.Notification.show({
                            iconCls    : 'icon-exclamation', 
                            html       : e.message, 
                            title      : 'EXCEPTION', 
                            autoScroll : true, 
                            hideDelay  : 5000, 
                            width      : 300, 
                            height     : 200
                        });" />
                    <BeforeSave Handler="var valid = true; this.each(function(r){if(r.dirty && !r.isValid()){valid=false;}}); return valid;" />
                </Listeners>
            </ext:Store>

            <ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout" HideBorders="true" AutoScroll="true">
                <Items>
                    
                    <ext:GridPanel ID="GridPanel1"  runat="server" Border="false" StoreID="Store1">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>

                                    <ext:ToolbarFill runat="server" />
                                    <ext:Button runat="server" Text="Save" Icon="Disk">
                                        <Listeners>
                                            <Click Handler="#{GridPanel1}.save();" />
                                        </Listeners>
                                    </ext:Button>

                                </Items>
                            </ext:Toolbar>
                        </TopBar>
            
                        <ColumnModel>
                            <Columns>
                                <ext:Column Header="Tên" DataIndex="code" />
                                <ext:Column Header="Mô tả" DataIndex="caption" />
                    
                                <ext:Column Header="Giá trị" DataIndex="value">
                                    <Editor>
                                        <ext:TextField runat="server" />    
                                    </Editor>
                                </ext:Column>
                    
                                <ext:CommandColumn Width="40">
                                    <Commands>
                                        <ext:GridCommand Text="Reject" ToolTip-Text="Reject row changes" CommandName="reject" Icon="ArrowUndo" />
                                    </Commands>
                                    <PrepareToolbar Handler="toolbar.items.get(0).setVisible(record.dirty);" />
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
            
                        <Listeners>
                            <Command Handler="record.reject();" />
                        </Listeners>
            
                        <View>
                            <ext:GridView runat="server" ForceFit="true" />
                        </View>
            
                        <SelectionModel>
                            <ext:RowSelectionModel runat="server" SingleSelect="true" />
                        </SelectionModel>
                    </ext:GridPanel>
                </Items>
            </ext:Viewport>
        </div>

    </form>
</body>
</html>
