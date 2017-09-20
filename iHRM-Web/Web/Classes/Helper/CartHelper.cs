using iHRM.WebPC.Classes.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iHRM.WebPC
{
    public class CartHelper
    {
        public class CartItem
        {
            public int    ID;
            public long   Product_ShopID;
            public long   Product_ID;
            public string Product_Title;
            public string Product_Alias;
            public string Product_Url;
            public string Product_Image;
            public double Product_Price;
            public int    Product_PriceDisplayType;
            public string Product_Promotion;
            public double Product_Discount;

            public double Price;
            public float  Quantity;
            public Guid?  Rule_ID;
            public string Rule_Text;
        }

        public const string SessionKey = "___CartHelper";

        public static int Count
        {
            get { return Items.Count; }
        }

        public static double Total
        {
            get { return Items.Sum(i => i.Price * i.Quantity); }
        }

        public static double Total_PMH
        {
            get { return Items.Where(i => i.Product_PriceDisplayType == 1).Sum(i => (i.Product_Price - i.Price) * i.Quantity); }
        }

        public static double TotalDiscount
        {
            get { return Items.Sum(i => i.Product_Discount * i.Quantity); }
        }

        public static List<CartItem> Items
        {
            get
            {
                List<CartItem> lst = HttpContext.Current.Session[SessionKey + "_Items"] as List<CartItem>;
                if (lst == null)
                {
                    lst = new List<CartItem>();
                    HttpContext.Current.Session[SessionKey + "_Items"] = lst;
                }

                return lst;
            }
            private set
            {
                HttpContext.Current.Session[SessionKey + "_Items"] = value;
            }
        }

        public static bool Add(long Product_ID, Guid? Rule_ID, double price, float quantity)
        {
            try
            {
                //string Rule_Text = "";
                //if (Rule_ID != null)
                //{
                //    var dt1 = LHT.DataEngine.Provider.ExeProcedure("spf_GetRuleById", new SqlParameter("ruleId", Rule_ID));
                //    if (dt1 != null || dt1.Rows.Count > 0)
                //        Rule_Text = dt1.Rows[0]["RuleName"] as string;
                //}

                //CartItem item1 = Items.SingleOrDefault(i => i.Product_ID == Product_ID && i.Rule_ID == Rule_ID);
                //if (item1 != null)
                //{
                //    item1.Quantity += quantity;
                //    return true;
                //}

                //var dt = LHT.DataEngine.Provider.ExeProcedure("spBE_Product_GetByID", new SqlParameter("ID", Product_ID));
                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    CartItem item = new CartItem();
                //    DataRow dr = dt.Rows[0];

                //    item.Product_ShopID = WebHelper.DbGetLong(dr, LHT.DataEngine.TableConst.i_Products.Shop_ID);
                //    item.Product_ID = WebHelper.DbGetLong(dr, LHT.DataEngine.TableConst.i_Products.Product_ID);
                //    item.Product_Title = WebHelper.DbGetString(dr, LHT.DataEngine.TableConst.i_Products.Title);
                //    item.Product_Alias = WebHelper.DbGetString(dr, LHT.DataEngine.TableConst.i_Products.Alias);
                //    item.Product_Url = UrlRewrite.Build_Product_Detail_Link(dr);
                //    item.Product_Price = WebHelper.DbGetFloat(dr, LHT.DataEngine.TableConst.i_Products.Price);
                //    item.Product_PriceDisplayType = WebHelper.DbGetInt(dr, LHT.DataEngine.TableConst.i_Products.PriceDisplayType);
                //    item.Product_Image = WebHelper.DbGetString(dr, LHT.DataEngine.TableConst.i_Products.ImageFile);

                //    LHT.DataEngine.Provider.ExeProcedureReader("spf_ProductRealTimeInfo", (reader) =>
                //    {
                //        item.Product_Promotion = WebHelper.DbGetString(reader, "Promotion");
                //        item.Product_Discount = WebHelper.DbGetFloat(reader, "Discount");
                //    }, new SqlParameter("productId", Product_ID), new SqlParameter("ruleId", Rule_ID));


                //    item.Price = price;
                //    if (item.Price == 0)
                //        item.Price = WebHelper.DbGetFloat(dr, LHT.DataEngine.TableConst.i_Products.SellPrice);
                //    if (item.Price == 0)
                //        item.Price = item.Product_Price;
                //    item.Quantity = quantity;
                //    item.Rule_ID = Rule_ID;
                //    item.Rule_Text = Rule_Text;

                //    item.ID = Items.Count;

                //    Items.Add(item);
                //    return true;
                //}
            }
            catch { }
            return false;
        }

        public static bool Remove(long Cart_ID)
        {
            try
            {
                CartItem item = Items.SingleOrDefault(i => i.ID == Cart_ID);
                if (item != null)
                {
                    Items.Remove(item);
                    return true;
                }
            }
            catch { }
            return false;
        }

        public static bool Update(long Cart_ID, float quantity)
        {
            try
            {
                CartItem item = Items.SingleOrDefault(i => i.ID == Cart_ID);
                if (item != null)
                {
                    item.Quantity = quantity;
                    return true;
                }
            }
            catch { }
            return false;
        }

        public static void Clear()
        {
            HttpContext.Current.Session[SessionKey + "_Items"] = null;
        }

        #region cookie
        public static void CheckCookie()
        {
            if (HttpContext.Current.Session[SessionKey + "_CheckCookie"] == null)
            {
                try
                {
                    string s1 = Classes.Helper.Cookies.ReadCookie(SessionKey + "_CheckCookie");
                    if (string.IsNullOrWhiteSpace(s1))
                        return;

                    var Cart_Save_State = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(s1));
                    if (string.IsNullOrWhiteSpace(Cart_Save_State))
                        return;

                    foreach (string s in Cart_Save_State.Split('#'))
                    {
                        try
                        {
                            string[] a = s.Split('|');
                            Add(long.Parse(a[0]), string.IsNullOrWhiteSpace(a[1]) ? null : (Guid?)(new Guid(a[1])), double.Parse(a[2]), float.Parse(a[3]));
                        }
                        catch { }
                    }
                }
                catch { }

                HttpContext.Current.Session[SessionKey + "_CheckCookie"] = 1;
            }
        }
        public static string SaveToCookie()
        {
            string s = string.Join("#", Items.Select(i => string.Format("{0}|{1}|{2}|{3}", i.Product_ID, i.Rule_ID, i.Price, i.Quantity)));
            string base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(s));
            return base64;
        }
        #endregion
    }
}