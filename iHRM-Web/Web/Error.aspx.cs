using System;

namespace iHRM.WebPC
{
    public partial class Error : iTemplate.iParser 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public override void OnGen()
        {
            switch (Request["code"])
            {
                case "no-product":
                    this.PageParser.Parse("MsgError", "Xin lỗi, sản phẩm này không tồn tại hoặc đã hết hàng!");
                    break;
                case "add-cart":
                    this.PageParser.Parse("MsgError", "Xin lỗi, sản phẩm bạn muốn mua chưa sẵn sàng, vui lòng chọn sản phẩm khác");
                    break;
                default:
                    this.PageParser.Parse("MsgError", "Xin lỗi, chúng tôi không tìm thấy thông tin như đã yêu cầu!");
                    break;
            }
        }

    }
}