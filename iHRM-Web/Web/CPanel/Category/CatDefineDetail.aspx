<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatDefineDetail.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Category.CatDefineDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:Store ID="Store1" runat="server" ShowWarningOnFailure="false" OnBeforeStoreChanged="Store1_BeforeChanged" RefreshAfterSaving="None">
            <Reader>
                <ext:JsonReader />
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

        <ext:Viewport runat="server" Layout="FitLayout">
            <Items>

                <ext:GridPanel ID="GridPanel1" runat="server" Border="false" StoreID="Store1">
                    <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>

                                <ext:ToolbarFill runat="server" />

                                <ext:Button runat="server" Text="Refresh" Icon="ArrowRefresh">
                                    <Listeners>
                                        <Click Handler="#{Store1}.reload();" />
                                    </Listeners>
                                </ext:Button>

                                <ext:ToolbarSeparator runat="server" />
                                <ext:Button runat="server" Text="AddNew" Icon="Add">
                                    <Listeners>
                                        <Click Handler="#{GridPanel1}.insertRecord(0, null);" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button runat="server" Text="Delete" Icon="Delete">
                                    <Listeners>
                                        <Click Handler="#{GridPanel1}.deleteSelected();" />
                                    </Listeners>
                                </ext:Button>

                                <ext:ToolbarSeparator runat="server" />
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
                            <ext:RowNumbererColumn Header="STT" Width="35" />

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

                    <LoadMask ShowMask="true" />
                    <Plugins>
                        <ext:GridFilters runat="server" ID="GridFilters1" Local="true" />
                    </Plugins>

                    <SelectionModel>
                        <ext:RowSelectionModel runat="server" SingleSelect="true" />
                    </SelectionModel>

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
                                <ext:Label ID="Label1" runat="server" Text="#common_btn.Pagging_PageSize" />
                                <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                <ext:ComboBox ID="ComboBox1" runat="server" Width="80" Editable="false">
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
