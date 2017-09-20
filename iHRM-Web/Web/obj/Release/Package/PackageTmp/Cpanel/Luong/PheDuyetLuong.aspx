<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PheDuyetLuong.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Luong.PheDuyetLuong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    
    <style type="text/css">
        .tt_statusCode { height: 12px; margin-top: -4px; }

        .w1 .x-window-body textarea { background: rgba(255, 255, 255, 0.4); }
        .w1Cls1 .x-window-body { background:white url('/Cpanel/Skins/Style/IMG/bgApproved.png') right bottom no-repeat; }
        .w1Cls2 .x-window-body { background:white url('/Cpanel/Skins/Style/IMG/bgRejected.png') right bottom no-repeat; }
        .w1Cls3 .x-window-body { background:white url('/Cpanel/Skins/Style/IMG/bgRevise.png') right bottom no-repeat; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager ID="ResourceManager1" runat="server" />
                        
            <ext:Store ID="Store1" runat="server">

                <Reader>
                    <ext:JsonReader IDProperty="id">
                        <Fields>
                            <ext:RecordField Name="DateChange" Type="Date" />
                            <ext:RecordField Name="EmployeeName" />
                            <ext:RecordField Name="TitleName" />
                            <ext:RecordField Name="BasicSalary_Ins" Type="Float" />
                            <ext:RecordField Name="BasicSalary" Type="Float" />
                            <ext:RecordField Name="status" Type="Int" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            
            </ext:Store>

            <ext:Viewport runat="server" Layout="BorderLayout" HideBorders="true" AutoScroll="true">
                <Items>

                    <ext:Panel runat="server" Region="West" Border="false" Collapsible="true" Split="true" Width="170" Layout="FormLayout" 
                        Padding="10" LabelAlign="Top">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:ToolbarFill runat="server" />
                                    <ext:Button ID="btnSearch" runat="server" Icon="ArrowRefreshSmall" Text="#common_btn.Find" OnDirectClick="btnSearch_DirectClick" />
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Items>
                            <ext:TextField ID="txtSearchKey" runat="server" FieldLabel="#Luong_PheDuyetLuong.txtSearchKey" AnchorHorizontal="100%" Note="" NoteAlign="Down"></ext:TextField>
                            <ext:DateField ID="txtTuNgay" runat="server" FieldLabel="#Luong_PheDuyetLuong.txtTuNgay" AnchorHorizontal="100%" Format="dd/MM/yyyy"></ext:DateField>
                            <ext:DateField ID="txtDenNgay" runat="server" FieldLabel="#Luong_PheDuyetLuong.txtDenNgay" AnchorHorizontal="100%" Format="dd/MM/yyyy"></ext:DateField>
                            <ext:Checkbox ID="chkOnlyWaiting" runat="server" FieldLabel="#Luong_PheDuyetLuong.chkOnlyWaiting" AnchorHorizontal="100%"></ext:Checkbox>
                        </Items>
                    </ext:Panel>
                    
                    <ext:GridPanel ID="grd" runat="server" Border="false" StoreID="Store1" Region="Center" AutoExpandColumn="EmployeeName">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    
                                    <ext:ToolbarFill runat="server" />                                    
                                    <ext:Button ID="btnApprovedAll" runat="server" Text="#Luong_PheDuyetLuong.btnApprovedAll" Icon="BulletGreen" OnDirectClick="btnApprovedAll_DirectClick">
                                    </ext:Button>
                                    <ext:Button ID="btnRejectAll" runat="server" Text="#Luong_PheDuyetLuong.btnRejectAll" Icon="BulletRed" OnDirectClick="btnApprovedAll_DirectClick">
                                    </ext:Button>
                                    <ext:Button ID="btnReviseAll" runat="server" Text="#Luong_PheDuyetLuong.btnReviseAll" Icon="BulletOrange" OnDirectClick="btnApprovedAll_DirectClick">
                                    </ext:Button>

                                </Items>
                            </ext:Toolbar>
                        </TopBar>
            
                        <ColumnModel>
                            <Columns>
                                <ext:DateColumn Header="#Luong_PheDuyetLuong.grd_DateChange" DataIndex="DateChange" Format="dd/MM/yyyy" Width="65" />
                                <ext:Column Header="#Luong_PheDuyetLuong.grd_EmployeeName" DataIndex="EmployeeName" />
                                <ext:Column Header="#Luong_PheDuyetLuong.grd_TitleName" DataIndex="TitleName" Width="120" />
                                <ext:NumberColumn Header="#Luong_PheDuyetLuong.grd_BasicSalary" DataIndex="BasicSalary" Format="0,0" Width="95" Align="Right" />
                                <ext:NumberColumn Header="#Luong_PheDuyetLuong.grd_BasicSalary_Ins" DataIndex="BasicSalary_Ins" Format="0,0" Width="95" Align="Right" />
                                
                                <ext:TemplateColumn Header="#Luong_PheDuyetLuong.grd_Status" Width="35">
                                    <Template runat="server">
                                        <Html>
                                            <div class="tt_statusCode">
                                            <img alt="{status}" src="/Cpanel/Skins/Style/IMG/TT{status}.png" /></div>
                                        </Html>
                                    </Template>
                                </ext:TemplateColumn>
                            </Columns>
                        </ColumnModel>
            
                        <SelectionModel>
                            <ext:RowSelectionModel runat="server" SingleSelect="false" />
                        </SelectionModel>
                        
                        <DirectEvents>
                            <DblClick OnEvent="btnAp1_DirectClick" />
                        </DirectEvents>

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
                    </ext:GridPanel>

                </Items>
            </ext:Viewport>

            <ext:Hidden ID="h_IDEditor" runat="server" />
            <ext:Window ID="editor" runat="server" Layout="FormLayout" Width="580" Height="330" Title="#Luong_PheDuyetLuong.editor_Title" Icon="RecordBlue" 
                Modal="true" Hidden="true" Cls="w1" Padding="10">
                <TopBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:Button ID="btnApproved" runat="server" Text="#Luong_PheDuyetLuong.editor_btnApproved" Icon="BulletGreen" OnDirectClick="btnApproved_DirectClick">
                            </ext:Button>
                            <ext:Button ID="btnReject" runat="server" Text="#Luong_PheDuyetLuong.editor_btnReject" Icon="BulletRed" OnDirectClick="btnApproved_DirectClick">
                            </ext:Button>
                            <ext:Button ID="btnRevise" runat="server" Text="#Luong_PheDuyetLuong.editor_btnRevise" Icon="BulletOrange" OnDirectClick="btnApproved_DirectClick">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Items>
                    
                    <ext:DateField runat="server" DataIndex="DateChange" FieldLabel="#Luong_PheDuyetLuong.editor_txtDate" Format="dd/MM/yyyy" ReadOnly="true" Width="120">
                    </ext:DateField>
                    <ext:CompositeField runat="server">
                        <Items>
                            <ext:TextField runat="server" FieldLabel="#Luong_PheDuyetLuong.editor_txtEmployeeName" DataIndex="EmployeeName" Flex="7" ReadOnly="true"/>
                            <ext:TextField runat="server" FieldLabel="#Luong_PheDuyetLuong.editor_txtEmployeeCode" DataIndex="EmployeeCode" Flex="3" ReadOnly="true"/>
                        </Items>
                    </ext:CompositeField>
                    <ext:CompositeField runat="server">
                        <Items>
                            <ext:TextField runat="server" FieldLabel="#Luong_PheDuyetLuong.editor_txtDepName" DataIndex="DepName" Flex="7" ReadOnly="true"/>
                            <ext:TextField runat="server" FieldLabel="#Luong_PheDuyetLuong.editor_txtTitleName" DataIndex="TitleName" Flex="3" ReadOnly="true"/>
                        </Items>
                    </ext:CompositeField>
                    <ext:CompositeField runat="server">
                        <Items>
                            <ext:NumberField runat="server" FieldLabel="#Luong_PheDuyetLuong.editor_txtBasicSalary" DataIndex="BasicSalary" Flex="5" ReadOnly="true" />
                            <ext:NumberField runat="server" FieldLabel="#Luong_PheDuyetLuong.editor_txtBasicSalary_Ins" DataIndex="BasicSalary_Ins" Flex="5" ReadOnly="true" />
                        </Items>
                    </ext:CompositeField>
                    <ext:TextArea runat="server" FieldLabel="#Luong_PheDuyetLuong.editor_txtNotes" DataIndex="Notes" ReadOnly="true" AnchorHorizontal="100%" Height="45" />
                    <ext:TextArea ID="txtRemark" runat="server" FieldLabel="#Luong_PheDuyetLuong.editor_txtRemark" DataIndex="statusRemark" AnchorHorizontal="100%" />
              
                </Items>
            </ext:Window>
        </div>

    </form>
</body>
</html>
