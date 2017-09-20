using Ext.Net;
using iHRM.WebPC.Code;
using iHRM.Common.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iHRM.Core.Business;
using System.Data;
using iHRM.Core.Business.DbObject;
using System.Xml;
using System.Data.SqlClient;
using iHRM.Core.Business.Helper;
using System.Text.RegularExpressions;

namespace iHRM.WebPC.Cpanel.Employee
{
    public partial class Editor : BackEndPageBase
    {
        private const string URL_IMG = "~/Uploads/images/";
        global::iHRM.Core.Business.DbObject.dcDatabaseDataContext db;
        global::iHRM.Core.Business.Logic.Employee.Emp logic = new global::iHRM.Core.Business.Logic.Employee.Emp();

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);

            if (!IsPostBack)
            {
                LoadPreData();
                if (Request["id"] == null)
                {
                    grdKCB.Disabled = frmTTK.Disabled = true;
                    txtCode.Text = global::iHRM.Core.Business.Logic.AllLogic.GenNextMa("tblEmployee", "EmployeeID", "", false);

                }
                else
                {
                    try
                    {
                        string a = Request["id"];
                        var emp = db.tblEmployees.SingleOrDefault(i => i.EmployeeID == Request["id"]);
                        FormSetDataContext(frmTT, emp);
                        FormSetDataContext(frmBH, emp);
                        FormSetDataContext(frmTTK, emp);
                        FormSetDataContext(frmBHYT, emp);
                        FormSetDataContext(frmThoiViec, emp);
                        imgProfile.ImageUrl = ResolveUrl("~/") + "uploads/images" + "/" + emp.LinkImage;
                        txtimage.Value = ResolveUrl("~/") + "uploads/images" + "/" + emp.LinkImage;
                        LoadNextData();
                        grdKCB.Disabled = frmTTK.Disabled = false;
                        StoreAutoSave_RefreshData(stoLoaiNV, null);
                        StoreAutoSave_RefreshData(stoKCB, null);
                        StoreAutoSave_RefreshData(stoPhongBan, null);
                        StoreAutoSave_RefreshData(stoSalary, null);
                        StoreAutoSave_RefreshData(stoPhuCap, null);
                        StoreAutoSave_RefreshData(stoHopDong, null);
                        //StoreAutoSave_RefreshData(stoChucVu, null);
                    }
                    catch (Exception)
                    {


                    }

                }

                if (Request["tab"] != null)
                    tab1.Items[int.Parse(Request["tab"])].Show();
                Lng.Web_Language.Lng_SetControlTexts(this);
            }

            SetupStoreAutoSave(stoKCB);

            SetupStoreAutoSave(stoLoaiNV);

            SetupStoreAutoSave(stoPhongBan);

            SetupStoreAutoSave(stoSalary);

            SetupStoreAutoSave(stoPhuCap);

            SetupStoreAutoSave(stoHopDong);

            //SetupStoreAutoSave(stoChucVu);

        }

        private void LoadPreData()
        {
            stoHIPlace.DataSource = db.tblRef_HIPlaces;
            stoHIPlace.DataBind();

            stoLeftType.DataSource = db.tblRef_LeftTypes;
            stoLeftType.DataBind();

            stoEmpStatus.DataSource = db.tblRef_StatusEmployees;
            stoEmpStatus.DataBind();

            stoMaritalStatus.DataSource = db.tblRef_MaritalStatus;
            stoMaritalStatus.DataBind();

            StoInGroup1.DataSource = db.tblEmp_Group1s;
            StoInGroup1.DataBind();

            Store1.DataSource = db.tblRef_Banks;
            Store1.DataBind();
        }
        private void LoadNextData()
        {
            stoEmpType.DataSource = db.tblRef_EmployeeTypes;
            stoEmpType.DataBind();

            stoEmpDep.DataSource = db.tblRef_Departments;
            stoEmpDep.DataBind();

            //stoTitle.DataSource = db.tblRef_Titles;
            //stoTitle.DataBind();

            stoAllowance.DataSource = db.tblRef_Allowances.Where(i => i.Regular);
            stoAllowance.DataBind();

            stoContractType.DataSource = db.tblRef_ContractTypes;
            stoContractType.DataBind();

            stoPostion.DataSource = db.tblRef_Positions;
            stoPostion.DataBind();

            StoreAutoSave_RefreshData(stoKCB, null);
        }

        protected void btnOk_DirectClick(object sender, DirectEventArgs e)
        {

            try
            {
                if (Request["id"] == null) //new
                {
                    var emp = new tblEmployee();
                    FormGetDataContext(frmTT, emp);
                    FormGetDataContext(frmBH, emp);

                    emp.EmployeeID = emp.EmployeeCode;
                    emp.NameSearch = ConvertUnicode.RemoveUnicode(emp.EmployeeName);
                    string tenanh = txtFileImage.PostedFile.FileName;
                    if (tenanh != null)
                    {
                        if (IsImage(txtFileImage.PostedFile))
                        {
                            string duoianh = tenanh.Split('.')[1];

                            string renametenanh = emp.EmployeeCode + "." + duoianh;
                            //Cập nhật ảnh nhân viên và xóa ảnh cũ

                            // Xóa file ảnh nếu đã tồn tại trong thư mục
                            String strPathNew = ResolveUrl("~/") + "uploads/images" + "/" + renametenanh;
                            string filePatch = Server.MapPath(strPathNew);
                            txtFileImage.PostedFile.SaveAs(Server.MapPath(URL_IMG + renametenanh));
                            emp.LinkImage = renametenanh;
                        }
                    }
                    emp.LinkImage = txtimage.Value.ToString();
                    try
                    {
                        List<tblEmployee> lst = (from c in db.tblEmployees where c.IDCard == emp.IDCard && c.LeftDate == null select c).ToList<tblEmployee>();
                        if (lst.Count > 0)
                        {
                            Tools.message("Chứng minh thư này đã tồn tại trong hệ thống", "Thông báo");
                        }
                        else
                        {
                            db.tblEmployees.InsertOnSubmit(emp);
                            db.SubmitChanges();
                            Tools.message(Lng.common_msg.Add_Success);
                            Response.Redirect("Editor.aspx?id=" + emp.EmployeeID + "&tab=2");
                        }
                    }
                    catch (Exception ex)
                    {
                        Tools.messageEx(ex);
                    }
                }
                else
                {
                    var emp = db.tblEmployees.SingleOrDefault(i => i.EmployeeID == Request["id"]);
                    FormGetDataContext(frmTT, emp);
                    FormGetDataContext(frmBH, emp);
                    string tenanh = txtFileImage.PostedFile.FileName;
                    if (tenanh != null)
                    {
                        if (IsImage(txtFileImage.PostedFile))
                        {
                            string duoianh = tenanh.Split('.')[1];

                            string renametenanh = emp.EmployeeCode + "." + duoianh;
                            //Cập nhật ảnh nhân viên và xóa ảnh cũ

                            // Xóa file ảnh nếu đã tồn tại trong thư mục
                            String strPathNew = ResolveUrl("~/") + "uploads/images" + "/" + renametenanh;
                            string filePatch = Server.MapPath(strPathNew);
                            DeleteFile(filePatch);
                            txtFileImage.PostedFile.SaveAs(Server.MapPath(URL_IMG + renametenanh));
                            emp.LinkImage = renametenanh;
                        }
                    }
                    emp.NameSearch = ConvertUnicode.RemoveUnicode(emp.EmployeeName);

                    try
                    {
                        db.SubmitChanges();
                        Tools.message(Lng.common_msg.Edit_Success);
                    }
                    catch (Exception ex)
                    {
                        Tools.messageEx(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Tools.messageConfirmErr(string.Format(Lng.common_msg.Error_While_Exec, ex));
            }
        }
        public bool IsImage(HttpPostedFile file)
        {
            // This checks for image type... you could also do filename extension checks and other things
            // but this is just an example to get you on your way
            return ((file != null) && Regex.IsMatch(file.ContentType, "image/\\S+") && (file.ContentLength > 0));
        }
        protected void DeleteFile(string Filename)
        {
            try
            {
                FileInfo fi;
                if (System.IO.File.Exists(Filename) == true)
                {
                    fi = new FileInfo(Filename);
                    fi.Delete();
                }
            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }
        }
        protected void EmployeeCode_Validation(object sender, RemoteValidationEventArgs e)
        {
            TextField txt = (TextField)sender;

            if (txt.Text == Request["id"] || logic.EmployeeCode_Validate(txt.Text.Trim(' ', '\r', '\n', '\t')))
            {
                e.Success = true;
            }
            else
            {
                e.Success = false;
                e.ErrorMessage = Lng.Employee_Editor.msg_1;
            }
        }
        #region sto auto save
        void SetupStoreAutoSave(Store sto)
        {
            sto.RefreshData += StoreAutoSave_RefreshData;
            sto.BeforeStoreChanged += StoreAutoSave_BeforeStoreChanged;
        }
        protected void StoreAutoSave_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            var sto = sender as Store;
            sto.DataSource = logic.GetStoreData(sto.DataMember, Request["id"]);
            sto.DataBind();
        }
        protected void StoreAutoSave_BeforeStoreChanged(object sender, BeforeStoreChangedEventArgs e)
        {
            var sto = sender as Store;
            XmlDocument doc = e.DataHandler.XmlData;
            buildInsert(sto.DataMember, sto, doc);
            buildDelete(sto.DataMember, sto, doc);
            buildUpdate(sto.DataMember, sto, doc);

            e.Cancel = true;
            Tools.message("Cập nhật thành công");
        }

        SqlCommand CreateSqlCommand(string sqlText, JsonReader jr)
        {
            SqlCommand cmd = new SqlCommand(sqlText, Provider.CreateConnection());
            foreach (var f in jr.Fields.Where(i => !Equals(i.Name, jr.IDProperty)))
            {
                SqlParameter pa = new SqlParameter();
                pa.ParameterName = f.Name;

                switch (f.Type)
                {
                    case RecordFieldType.Boolean:
                        pa.SqlDbType = SqlDbType.Bit;
                        break;
                    case RecordFieldType.Date:
                        pa.SqlDbType = SqlDbType.DateTime;
                        break;
                    case RecordFieldType.Float:
                        pa.SqlDbType = SqlDbType.Float;
                        break;
                    case RecordFieldType.Int:
                        pa.SqlDbType = SqlDbType.Int;
                        break;
                    default:
                        pa.SqlDbType = SqlDbType.NVarChar;
                        break;
                }

                cmd.Parameters.Add(pa);
            }

            return cmd;
        }
        void buildInsert(string tableName, Store sto, XmlDocument doc, bool autoEmployeeID = true)
        {
            var jr = sto.Reader[0] as JsonReader;
            string sql = string.Format("INSERT INTO [{0}] ({1}) VALUES ({2})",
                tableName,
                string.Join(",", jr.Fields.Where(i => !Equals(i.Name, jr.IDProperty)).Select(i => "[" + i.Name + "]")) + (autoEmployeeID ? ",[EmployeeID]" : ""),
                string.Join(",", jr.Fields.Where(i => !Equals(i.Name, jr.IDProperty)).Select(i => "@" + i.Name)) + (autoEmployeeID ? ",@EmployeeID" : "")
            );

            SqlCommand cmd = CreateSqlCommand(sql, jr);
            if (autoEmployeeID)
                cmd.Parameters.Add(new SqlParameter("EmployeeID", Request["id"]));

            try
            {
                cmd.Connection.Open();

                foreach (XmlNode n in doc.SelectNodes("/records/Created/record"))
                {
                    foreach (SqlParameter pa in cmd.Parameters)
                    {
                        if (autoEmployeeID && pa.ParameterName == "EmployeeID")
                            continue;
                        string v = n.SelectSingleNode(pa.ParameterName).InnerText;
                        if (pa.SqlDbType == SqlDbType.Bit && string.IsNullOrWhiteSpace(v))
                            pa.Value = false;
                        else
                            pa.Value = v;
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        void buildDelete(string tableName, Store sto, XmlDocument doc)
        {
            string sql = string.Format("DELETE FROM [{0}] WHERE [{1}] = @{1}",
                tableName,
                (sto.Reader[0] as JsonReader).IDProperty
            );

            SqlCommand cmd = new SqlCommand(sql, Provider.CreateConnection());
            cmd.Parameters.Add(new SqlParameter((sto.Reader[0] as JsonReader).IDProperty, DBNull.Value));

            try
            {
                cmd.Connection.Open();
                foreach (XmlNode n in doc.SelectNodes("/records/Deleted/record"))
                {
                    foreach (SqlParameter pa in cmd.Parameters)
                        pa.Value = n.SelectSingleNode(pa.ParameterName).InnerText;

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        void buildUpdate(string tableName, Store sto, XmlDocument doc)
        {
            var jr = sto.Reader[0] as JsonReader;
            string sql = string.Format("UPDATE [{0}] SET {1} WHERE id = @id",
                tableName,
                string.Join(",", jr.Fields.Where(i => !Equals(i.Name, jr.IDProperty)).Select(i => "[" + i.Name + "] = @" + i.Name))
            );

            SqlCommand cmd = CreateSqlCommand(sql, jr);
            cmd.Parameters.Add(new SqlParameter("id", new Guid()));

            try
            {
                cmd.Connection.Open();
                foreach (XmlNode n in doc.SelectNodes("/records/Updated/record"))
                {
                    foreach (SqlParameter pa in cmd.Parameters)
                        pa.Value = n.SelectSingleNode(pa.ParameterName).InnerText;

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        #endregion
        protected void CheckField(object sender, RemoteValidationEventArgs e)
        {
            TextField field = (TextField)sender;

            if (field.Text != "")
            {
                var emp = db.tblEmployees.Where(i => i.IDCard == field.Text && i.LeftDate == null);
                if (emp.Count() > 0)
                {
                    e.Success = false;
                    Tools.messageConfirmErr("Đã có " + emp.Count() + " nhân viên đang sử dụng CMND " + field.Text);
                    
                }
                else 
                    e.Success = true;
            }
            else
            {
                e.Success = false;
                e.ErrorMessage = "Chưa nhập giá trị";
            }
            System.Threading.Thread.Sleep(500);
        }
    }
}