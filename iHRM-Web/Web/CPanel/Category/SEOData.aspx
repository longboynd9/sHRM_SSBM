<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SEOData.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Category.SEOData" %>
<%@ Register src="~/Cpanel/UC/ImageUploader.ascx" tagname="ImageUploader" tagprefix="uc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script type="text/javascript" src="/Cpanel/Skins/Js/jquery-1.9.0.js"></script>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
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

                                <ext:Button runat="server" Icon="ArrowLeft" Text="#Category_SEOData.quaylai">
                                    <Listeners>
                                        <Click Handler="history.back();" />
                                    </Listeners>
                                </ext:Button>

                                <ext:ToolbarSpacer Width="10" />
                                <ext:Button ID="btnOk" Icon="Disk" runat="server" Text="#Category_SEOData.luu" OnClick="btnOk_Click" AutoPostBack="true" >
                                    <Listeners>
                                        <Click Handler="if (#{formCT}.getForm().isValid()==false){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: '#Category_SEOData.msg', buttons:Ext.Msg.OK}); return false;}" />
                                    </Listeners>
                                </ext:Button>

                             </Items>
                        </ext:Toolbar>
                    </TopBar>

                    <Items>

                        <ext:FormPanel ID="formCT" runat="server" Border="false" Layout="FormLayout" Region="Center" PaddingSummary="10">
                            <Items>
                                <ext:TextField AnchorHorizontal="100%" ID="txttitle" DataIndex="title" runat="server" FieldLabel="#Category_SEOData.tieudetin" MaxLength="255" MaskRe="[^<>&amp;*]" />
                                <ext:TextField AnchorHorizontal="100%" ID="txttitle_EN" DataIndex="title_EN" runat="server" FieldLabel="#Category_SEOData.tieudeEN" MaxLength="255" MaskRe="[^<>&amp;*]" />
                                <ext:TextField AnchorHorizontal="100%" ID="txttitle_KR" DataIndex="title_KR" runat="server" FieldLabel="#Category_SEOData.tieudeKR" MaxLength="255" MaskRe="[^<>&amp;*]" />

                                <ext:TextField AnchorHorizontal="100%" ID="txtKeyword" DataIndex="keyword" runat="server" FieldLabel="keyword" MaxLength="255" MaskRe="[^<>&amp;*]" />
                                <ext:TextField AnchorHorizontal="100%" ID="txtKeyword_EN" DataIndex="keyword_EN" runat="server" FieldLabel="keyword EN" MaxLength="255" MaskRe="[^<>&amp;*]" />
                                <ext:TextField AnchorHorizontal="100%" ID="txtKeyword_KR" DataIndex="keyword_KR" runat="server" FieldLabel="keyword KR" MaxLength="255" MaskRe="[^<>&amp;*]" />
                                    
                                <ext:TextArea AnchorHorizontal="100%" ID="txtshortStory" DataIndex="description" runat="server" FieldLabel="description" MaxLength="1000" MaskRe="[^<>&amp;*]" />
                                <ext:TextArea AnchorHorizontal="100%" ID="txtshortStory_EN" DataIndex="description_EN" runat="server" FieldLabel="description EN" MaxLength="1000" MaskRe="[^<>&amp;*]" />
                                <ext:TextArea AnchorHorizontal="100%" ID="txtshortStory_KR" DataIndex="description_KR" runat="server" FieldLabel="description KR" MaxLength="1000" MaskRe="[^<>&amp;*]" />
                                
                                <ext:TextField AnchorHorizontal="100%" ID="txtImg" DataIndex="og_image" runat="server" FieldLabel="og_image" MaxLength="255" MaskRe="[^<>&amp;*]" />
                            </Items>
                        </ext:FormPanel>

                    </Items>
                </ext:Panel>

            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
