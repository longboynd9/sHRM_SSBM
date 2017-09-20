<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Viewer.aspx.cs" Inherits="iHRM.WebPC.Cpanel.i_Report.Viewer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/sHRM/Styles/css/ext.css" rel="stylesheet" />
    <script type="text/javascript" src="/Cpanel/Lng/language.js"></script>
    
    <script type="text/javascript">

        function printGrid(grid, window) {
            //window.show();
            var bd = window.getBody();

            bd.document.body.innerHTML = grid.body.dom.innerHTML;
            bd.document.getElementById(grid.view.el.id).style.height = "auto";
            bd.document.getElementById(grid.view.scroller.id).style.height = "auto";

            bd.print();
        }

        var ShowChoiceDept_txtCalling;
        function ShowChoiceDept(id) {
            ShowChoiceDept_txtCalling = id;
            w_DeptChoicer.show();
        }
        function DeptChoicer_OnChoice(n) {
            console.log(n);
            w_DeptChoicer.hide();
            var txt = eval(ShowChoiceDept_txtCalling);
            if (txt != undefined)
                txt.setValue(n.nodeID);
        }

    </script>

    <style type="text/css">
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <ext:ResourceManager runat="server" ID="ResourceManager1" />
            
            <ext:Store ID="sto1" runat="server" OnRefreshData="sto1_RefreshData">           
                <Proxy>
                    <ext:PageProxy />
                </Proxy>
                <Reader>
                    <ext:JsonReader IDProperty="id">
                    </ext:JsonReader>
                </Reader>
                <AutoLoadParams>
                    <ext:Parameter Name="start" Value="0" Mode="Raw" />
                    <ext:Parameter Name="limit" Value="100" Mode="Raw" />
                </AutoLoadParams>
            </ext:Store>

            <ext:Viewport runat="server" Layout="FitLayout">
                <Items>

                    <ext:Panel runat="server" Border="false" Layout="FitLayout">
                        
                        <TopBar>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="btnShowFilter" runat="server" Text="Show Filter" Icon="Find">
                                        <Listeners>
                                            <Click Handler="#{w_Filter}.show()" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID="btnRefresh" runat="server" Text="Refresh" Icon="ArrowRefresh">
                                        <Listeners>
                                            <Click Handler="#{sto1}.reload()" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarFill />

                                    <ext:Button ID="btnExcel" runat="server" Icon="PageExcel" Text="Excel">
                                        <DirectEvents>
                                            <Click OnEvent="btnExcel_DirectClick">
                                                <EventMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:Button runat="server" Icon="Printer" Text="Print" OnClientClick="printGrid(#{grd}, #{PrintWindow});" />
                                </Items>
                            </ext:Toolbar>
                        </TopBar>

                        <Items>
                            <ext:GridPanel ID="grd" runat="server" Border="false" StoreID="sto1">

                                <SelectionModel>
                                    <ext:RowSelectionModel runat="server" />
                                </SelectionModel>
                                
                                <LoadMask ShowMask="true" />

                            </ext:GridPanel>
                        </Items>
                        
                        <BottomBar>
                            <ext:PagingToolbar ID="pgToolbar" StoreID="sto1"
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
                                    <ext:Label runat="server" Text="#common_btn.Pagging_PageSize" />
                                    <ext:ToolbarSpacer runat="server" Width="10" />
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

                    </ext:Panel>

                </Items>
            </ext:Viewport>

            <ext:Window ID="w_Filter" runat="server" Layout="FitLayout" Width="420" Height="220" Icon="Find" Title="Filter" Hidden="true">
                <Items>
                    <ext:FormPanel ID="frmFilter" runat="server" Border="false" Padding="10" Layout="FormLayout" AutoScroll="true">
                    </ext:FormPanel>
                </Items>
                <Buttons>
                    <ext:Button ID="btnClear_Filter" runat="server" Text="Reset" Icon="PageWhite">
                        <Listeners>
                            <Click Handler="#{frmFilter}.getForm().reset();" />
                        </Listeners>
                    </ext:Button>
                    <ext:Button ID="btnOk_Filter" runat="server" Text="Filter" Icon="Tick">
                        <Listeners>
                            <Click Handler="#{btnRefresh}.fireEvent('click');" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            
            <ext:Window ID="PrintWindow" runat="server" Width="700" Height="400" Hidden="true">
                <TopBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:Button runat="server" Text="Print" Icon="Printer" OnClientClick="#{PrintWindow}.getBody().print();" />
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <AutoLoad Url="Printer.aspx" Mode="IFrame">        
                </AutoLoad>
            </ext:Window>

            <ext:Window ID="w_DeptChoicer" runat="server" Width="400" Height="270" Hidden="true" Title="Chọn phòng ban" Modal="true">
                <AutoLoad Url="DeptChoicer.aspx" Mode="IFrame">
                </AutoLoad>
            </ext:Window>

        </div>
    </form>
</body>
</html>
