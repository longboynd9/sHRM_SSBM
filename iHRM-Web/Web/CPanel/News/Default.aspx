<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="iHRM.WebPC.Cpanel.News.Default" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    
    <script type="text/javascript" src="/Cpanel/Skins/Js/jquery-1.9.0.js"></script>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />

    <style type="text/css">
        .imgAvatar { max-width:150px; vertical-align:middle; }
        .x-form-item-label {width:50px !important}
        .x-form-element {padding-left:58px !important}
    </style>
     <script type="text/javascript">
         var ar = {};
         function RenTrangThai(value) { return ar["k" + value]; }
         $(document).ready(function () {
             setTimeout('Store1.reload()', 1000);
         });

         function OpenEditor(id, title) {
             parent.CreateWin('news_BvEditor', "/Cpanel/News/Editor.aspx" + (id == '' ? '' : ('?id=' + id)), title, 800, 500);
         }

         function grd_DbClick(e) {
             OpenEditor(grp.getSelectionModel().selections.items[0].id, 'Chỉnh sửa bài viết');
         }
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Store ID="Store1" runat="server" OnRefreshData="Store1_OnRefresh" AutoLoad="true" RemotePaging="true">
            <Proxy>
                <ext:PageProxy />
            </Proxy>
            <Reader>
                <ext:JsonReader IDProperty="idBaiViet">
                    <Fields>
                        <ext:RecordField Name="idBaiViet"/>
                        <ext:RecordField Name="idx" Type="Int" />
                        <ext:RecordField Name="maBV" />
                        <ext:RecordField Name="tieude" />
                        <ext:RecordField Name="linklink" />
                        <ext:RecordField Name="tenDanhMuc" />
                        <ext:RecordField Name="anhDaiDien" />
                        <ext:RecordField Name="ngaytao" />
                        <ext:RecordField Name="sapxep" />
                        <ext:RecordField Name="luotxem" />
                        <ext:RecordField Name="status" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="0" Mode="Raw" />
                <ext:Parameter Name="limit" Value="10" Mode="Raw" />
            </AutoLoadParams>
        </ext:Store>
        <ext:Store ID="Store2" runat="server">
            <Reader>
                <ext:JsonReader IDProperty="id">
                    <Fields>
                        <ext:RecordField Name="id" Type="Int" />
                        <ext:RecordField Name="TenVN" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout" HideBorders="true" AutoScroll="true">
            <Items>
                
                <%-- Danh sách --%>
                <ext:GridPanel ID="grp" runat="server" Icon="User" StripeRows="true" ColumnLines="true" TrackMouseOver="true" StoreID="Store1" AutoExpandColumn="tieude">
                    <TopBar>
                        <ext:Toolbar ID="toolbarGrid" runat="server">
                            <Items>
                                <ext:Button ID="btnAdd" Icon="Add" runat="server" Text="Thêm" OnClientClick="OpenEditor('', 'Thêm mới bài viết')" />
                                <ext:ToolbarSpacer Width="20" />
                                <ext:ComboBox runat="server" ID="cbostatus" FieldLabel="Trạng thái" EmptyText="Chọn trạng thái"  Width="200" >
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:ToolbarSpacer Width="20" />
                                <ext:ComboBox runat="server" ID="cbodanhmuc" FieldLabel="Danh mục" EmptyText="Chọn danh mục"    Width="300" >
                                    <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:ToolbarSpacer Width="20" />
                                <ext:TextField runat="server"  ID="txtSearch" EmptyText="Tìm kiếm theo tên,giới thiệu ngắn" Width="220"/>
                                <ext:Button ID="btnSearch" ClientIDMode="Static" Icon="Zoom" runat="server" Text="Tìm kiếm">
                                    <Listeners>
                                        <Click Handler="#{Store1}.reload()" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <ColumnModel runat="server" ID="ctl432">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="35" />
                            <ext:TemplateColumn Header="Tiêu đề" DataIndex="tieude">
                                <Template runat="server">
                                    <Html>
                                        <a href="{linklink}" target="_blank">{tieude}</a>
                                    </Html>
                                </Template>
                            </ext:TemplateColumn>

                            <ext:Column Header="Danh mục" DataIndex="tenDanhMuc" Width="120"/>
                            <ext:DateColumn Header="Ngày viết bài" DataIndex="ngaytao" Width="120" Format="dd/MM/yyyy hh:mm" />
                            <ext:Column Header="Lượt xem" DataIndex="luotxem" Width="120"/>
                            <ext:Column Header="Sắp xếp" DataIndex="sapxep" Width="120"/>
                            <ext:Column Header="Trạng thái" DataIndex="status" >
                                <Renderer Fn="RenTrangThai" />
                             </ext:Column>
                            <ext:ImageCommandColumn ColumnID="commandbutton" Width="60" Align="Center" >
                                <Commands>
                                    <ext:ImageCommand CommandName="Edit" Icon="BulletEdit" Style="margin-left:7px !important;"  />
                                    <ext:ImageCommand CommandName="Delete" Icon="Delete" Style="margin-left:7px !important;" />
                                </Commands>
                            </ext:ImageCommandColumn>
                        </Columns>
                    </ColumnModel>
                    <DirectEvents>
                        <Command OnEvent="OnCommand">
                            <EventMask ShowMask="true"></EventMask>
                            <Confirmation BeforeConfirm="if(!(command == 'Delete')) return false;" ConfirmRequest="true"
                                Message="Bạn chắc chắn muốn xóa?" Title="Xác nhận xóa" />
                            <ExtraParams>
                                <ext:Parameter Name="id" Value="record.id" Mode="Raw" />
                                <ext:Parameter Name="command" Value="command" Mode="Raw" />
                            </ExtraParams>
                        </Command>
                    </DirectEvents>
                    <Listeners>
                        <DblClick Fn="grd_DbClick" />
                    </Listeners>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                    </SelectionModel>
                    <BottomBar>
                        <ext:PagingToolbar ID="pgToolbar" StoreID="Store1"
                            runat="server"
                            PageSize="10"
                            DisplayInfo="true"
                            FirstText="Trang đầu"
                            PrevText="Trang trước"
                            NextText="Trang sau"
                            LastText="Trang cuối"
                            RefreshText="Nạp lại"
                            HideRefresh="true"
                            DisplayMsg="Hiển thị {0} - {1} / {2}"
                            EmptyMsg="Không có bản ghi nào để hiển thị">
                            <Items>
                                <ext:Label ID="Label1" runat="server" Text="Kích thước trang:" />
                                <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                <ext:ComboBox ID="ComboBox1" runat="server" Width="80" Editable="false">
                                    <Items>
                                        <ext:ListItem Text="10" />
                                        <ext:ListItem Text="50" />
                                        <ext:ListItem Text="100" />
                                        <ext:ListItem Text="500" />
                                    </Items>
                                    <SelectedItem Value="10" />
                                    <Listeners>
                                        <Select Handler="#{pgToolbar}.pageSize = parseInt(this.getValue()); #{pgToolbar}.doLoad();" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:PagingToolbar>
                    </BottomBar>
                    <LoadMask ShowMask="true" />
                </ext:GridPanel>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
