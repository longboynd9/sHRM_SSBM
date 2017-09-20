<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageUploader.ascx.cs" Inherits="iHRM.WebPC.Cpanel.UC.ImageUploader" %>

<script type="text/javascript">
    function showpreview(file, img) {
        var input = file.fileInput.dom;
        if (input.files[0].type.indexOf("image/") == -1) {
            alert("Invalid Image Extn.");
            return;
        }

        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                img.setImageUrl(e.target.result);
            }
            reader.readAsDataURL(input.files[0]);
        }
    }
</script>
<style type="text/css">
    .imguploader_container {  }
    .imguploader_container table { margin-bottom:0; }
    .imguploader_img { text-align:center; vertical-align:middle; width:150px; height:150px; border-bottom:solid 1px #99bbe8; padding:0 0 5px 0; }
    .imguploader_btn { padding:5px 0; }
</style>

<ext:Panel runat="server" Width="150" Layout="FitLayout" Cls="imguploader_container">
    <Items>
        <ext:TableLayout runat="server" Columns="2" StyleSpec="margin-bottom:0;">
            <Cells>
                <ext:Cell ColSpan="2" CellCls="imguploader_img">
                    <ext:Image ID="Image1" runat="server" style="max-width:150px;max-height:150px;" />
                </ext:Cell>
                <ext:Cell CellCls="imguploader_btn">
                    <ext:FileUploadField ID="FileUpload1" runat="server" EnableViewState="false" Width="80" ButtonOnly="true" ButtonText="Chọn ảnh" Icon="ImageAdd">
                        <Listeners>
                            <FileSelected Handler="showpreview(#{FileUpload1}, #{Image1})" />
                        </Listeners>
                    </ext:FileUploadField>
                </ext:Cell>
                <ext:Cell CellCls="imguploader_btn">
                    <ext:Button runat="server" Icon="ImageDelete" ID="btnDelImageUpload" Text="Xóa">
                        <Listeners>
                            <Click Handler="#{Image1}.setImageUrl('/Site/Images/noimg.jpg'); #{FileUpload1}.reset();" />
                        </Listeners>
                    </ext:Button>
                </ext:Cell>
            </Cells>
        </ext:TableLayout>
    </Items>
</ext:Panel>