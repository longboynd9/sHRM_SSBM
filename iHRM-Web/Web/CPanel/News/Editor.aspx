<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Editor.aspx.cs" Inherits="iHRM.WebPC.Cpanel.News.Editor" %>
<%@ Register src="~/Cpanel/UC/ImageUploader.ascx" tagname="ImageUploader" tagprefix="uc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script type="text/javascript" src="/Cpanel/Skins/Js/jquery-1.9.0.js"></script>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />

    <style type="text/css">
        .imgAvatar { max-width:150px; vertical-align:middle; }
        .p10 { padding: 10px; }
        .pl10 { padding-left:10px; }
       
    </style>
    
    <script type="text/javascript">
        function bodau(str) {
            str = str.toLowerCase();
            str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
            str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
            str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
            str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
            str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
            str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
            str = str.replace(/đ/g, "d");
            str = str.replace(/!|@|\$|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\'| |\"|\&|\#|\[|\]|~/g, "-");
            str = str.replace(/-+-/g, "-"); //thay thế 2- thành 1-
            str = str.replace(/^\-+|\-+$/g, "");//cắt bỏ ký tự - ở đầu và cuối chuỗi
            return str;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:Hidden ID="hId" runat="server" />
    
        <ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout" HideBorders="true" AutoScroll="true">
            <Items>
               
                <ext:Panel runat="server" AutoScroll="true" Layout="AnchorLayout">
                    <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:ToolbarFill runat="server" />

                                <ext:Button runat="server" Icon="ArrowLeft" Text="Quay lại">
                                    <Listeners>
                                        <Click Handler="window.location = 'Default.aspx';" />
                                    </Listeners>
                                </ext:Button>
                                <ext:ToolbarSpacer Width="10" />
                                <ext:Button ID="btnOk" Icon="Disk" runat="server" Text="Lưu" OnClick="btnOk_Click" AutoPostBack="true" >
                                    <Listeners>
                                        <Click Handler="if (#{formCT}.getForm().isValid()==false){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: 'Xin vui lòng điền đủ dữ liệu', buttons:Ext.Msg.OK}); return false;}" />
                                    </Listeners>
                                </ext:Button>
                             </Items>
                        </ext:Toolbar>
                    </TopBar>

                    <Items>
                        <ext:Panel runat="server" Border="false" Layout="BorderLayout" AnchorHorizontal="right" Height="220">
                            <Items>
                                <ext:Panel runat="server" Border="false" Region="West" Layout="FitLayout" Width="170" PaddingSummary="10">
                                    <Content>
                                        <uc1:ImageUploader ID="ImageUploader1" runat="server" />
                                    </Content>
                                </ext:Panel>
                                
                                <ext:FormPanel ID="formCT" runat="server" Border="false" Layout="FormLayout" Region="Center" PaddingSummary="10">
                                    <Items>
                                        <ext:TextField AnchorHorizontal="100%" ID="txttitle" DataIndex="tieude" runat="server" FieldLabel="Tiêu đề tin <span class='red'>*</span>" AllowBlank="false" MaxLength="255" MaskRe="[^<>&amp;*]" >
                                            <Listeners>
                                                <Change Handler="#{txtcode}.setValue(bodau(#{txttitle}.getValue()));" />
                                            </Listeners>
                                        </ext:TextField>
                                        <ext:TextField AnchorHorizontal="100%" ID="txttitle_EN" DataIndex="tieude_EN" runat="server" FieldLabel="Tiêu đề EN" MaxLength="255" MaskRe="[^<>&amp;*]" />
                                        <ext:TextField AnchorHorizontal="100%" ID="txttitle_KR" DataIndex="tieude_KR" runat="server" FieldLabel="Tiêu đề KR" MaxLength="255" MaskRe="[^<>&amp;*]" />
                                        <ext:TextField AnchorHorizontal="100%" ID="txtcode" DataIndex="maBV" runat="server" FieldLabel="Mã BV <span class='red'>*</span>" AllowBlank="false" MaxLength="255" MaskRe="[^<>&amp;*]" />

                                        <ext:ComboBox AnchorHorizontal="100%" ID="cmbcategoryId" DataIndex="categoryId" runat="server" FieldLabel="Danh mục" Editable="false" AllowBlank="false">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <Select Handler="this.triggers[0].show();" />
                                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                            </Listeners>
                                        </ext:ComboBox>
                                        <ext:NumberField AnchorHorizontal="100%" ID="txtOrder" runat="server" FieldLabel="Thứ tự"/>
                                        
                                        <ext:ComboBox runat="server" ID="cbostatus" FieldLabel="Trạng thái" />
                                        <ext:TextField AnchorHorizontal="100%" ID="txtTag" DataIndex="tags" runat="server" FieldLabel="Tags" MaxLength="255" MaskRe="[^<>&amp;*]" />
                                    </Items>
                                </ext:FormPanel>
                            </Items>
                        </ext:Panel>
                        
                        <ext:Panel runat="server" Border="false" Layout="FitLayout" AnchorHorizontal="right" Title="Giới thiệu">
                            <Content>
                                <CKEditor:CKEditorControl ID="CKEditor3" runat="server" Height="120" Width="100%" BasePath="/ckeditor" CustomConfig="configrv.js"  FilebrowserBrowseUrl="/ckfinder/ckfinder.html" EnableViewState="false" ViewStateMode="Disabled" />
                            </Content>
                        </ext:Panel>
                        
                        <ext:Panel runat="server" Border="false" Layout="FitLayout" AnchorHorizontal="right" Title="Giới thiệu EN">
                            <Content>
                                <CKEditor:CKEditorControl ID="CKEditor4" runat="server" Height="120" Width="100%" BasePath="/ckeditor" CustomConfig="configrv.js"  FilebrowserBrowseUrl="/ckfinder/ckfinder.html" EnableViewState="false" ViewStateMode="Disabled" />
                            </Content>
                        </ext:Panel>

                        <ext:Panel runat="server" Border="false" Layout="FitLayout" AnchorHorizontal="right" Title="Giới thiệu KR">
                            <Content>
                                <CKEditor:CKEditorControl ID="CKEditor4_2" runat="server" Height="120" Width="100%" BasePath="/ckeditor" CustomConfig="configrv.js"  FilebrowserBrowseUrl="/ckfinder/ckfinder.html" EnableViewState="false" ViewStateMode="Disabled" />
                            </Content>
                        </ext:Panel>

                        <ext:Panel runat="server" Border="false" Layout="FitLayout" AnchorHorizontal="right" Title="Nội dung bài viết">
                            <Content>
                                <CKEditor:CKEditorControl ID="CKEditor1" runat="server" Height="500" Width="100%" BasePath="/ckeditor" CustomConfig="configrv.js"  FilebrowserBrowseUrl="/ckfinder/ckfinder.html" EnableViewState="false" ViewStateMode="Disabled" />
                            </Content>
                        </ext:Panel>
                        
                        <ext:Panel runat="server" Border="false" Layout="FitLayout" AnchorHorizontal="right" Title="Nội dung EN" >
                            <Content>
                                <CKEditor:CKEditorControl ID="CKEditor2" runat="server" Height="500" Width="100%" BasePath="/ckeditor" CustomConfig="configrv.js"  FilebrowserBrowseUrl="/ckfinder/ckfinder.html" EnableViewState="false" ViewStateMode="Disabled" />
                            </Content>
                        </ext:Panel>
                        
                        <ext:Panel runat="server" Border="false" Layout="FitLayout" AnchorHorizontal="right" Title="Nội dung KR">
                            <Content>
                                <CKEditor:CKEditorControl ID="CKEditor2_2" runat="server" Height="500" Width="100%" BasePath="/ckeditor" CustomConfig="configrv.js"  FilebrowserBrowseUrl="/ckfinder/ckfinder.html" EnableViewState="false" ViewStateMode="Disabled" />
                            </Content>
                        </ext:Panel>
                    </Items>
                </ext:Panel>

            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
