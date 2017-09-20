using Ext.Net;
using iHRM.WebPC.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;

namespace iHRM.Lng
{
    public class Web_Language
    {
        private static string _currentLng = "vi";
        public static string CurrentLng
        {
            get { return _currentLng; }
        }

        public static void Lng_SetControlTexts(Control c)
        {
            if (c is Field)
            {
                var f = c as Field;
                if (f.FieldLabel.StartsWith("#"))
                {
                    f.FieldLabel = Lng_GetLngText(f.FieldLabel.Substring(1));
                }
            }

            if (c is TextField)
            {
                var tf = c as TextField;
                if (tf.EmptyText.StartsWith("#"))
                    tf.EmptyText = Lng_GetLngText(tf.EmptyText.Substring(1));
                if (tf.Note.StartsWith("#"))
                    tf.Note = Lng_GetLngText(tf.Note.Substring(1));
            }
            else if (c is Button)
            {
                var bt = c as Button;
                if (bt.Text.StartsWith("#"))
                    bt.Text = Lng_GetLngText(bt.Text.Substring(1));

                if (bt.DirectEvents.Click != null)
                {
                    if (bt.DirectEvents.Click.Confirmation.Title.StartsWith("#"))
                        bt.DirectEvents.Click.Confirmation.Title = Lng_GetLngText(bt.DirectEvents.Click.Confirmation.Title.Substring(1));
                    if (bt.DirectEvents.Click.Confirmation.Message.StartsWith("#"))
                        bt.DirectEvents.Click.Confirmation.Message = Lng_GetLngText(bt.DirectEvents.Click.Confirmation.Message.Substring(1));
                }
            }
            else if (c is LiteralControl)
            {
                var lc = c as LiteralControl;
                if (lc.Text.StartsWith("#"))
                    lc.Text = Lng_GetLngText(lc.Text.Substring(1));
            }
            else if (c is DropDownField)
            {
                var it = c as DropDownField;
                if (it.EmptyText.StartsWith("#"))
                    it.EmptyText = Lng_GetLngText(it.EmptyText.Substring(1));

                foreach (Control cc in it.Component)
                    Lng_SetControlTexts(cc);
            }
            else if (c is TreePanel)
            {
                var it = c as TreePanel;
                if (it.Title.StartsWith("#"))
                    it.Title = Lng_GetLngText(it.Title.Substring(1));
            }
            else if (c is Label)
            {
                var lb = c as Label;
                if (lb.Text.StartsWith("#"))
                    lb.Text = Lng_GetLngText(lb.Text.Substring(1));
                if (lb.FieldLabel.StartsWith("#"))
                    lb.FieldLabel = Lng_GetLngText(lb.FieldLabel.Substring(1));
            }
            else if (c is Panel)
            {
                var pnl = c as Panel;
                if (pnl.Title.StartsWith("#"))
                    pnl.Title = Lng_GetLngText(pnl.Title.Substring(1));
            }
            else if (c is TabPanel)
            {
                var pnl = c as TabPanel;
                if (pnl.Title.StartsWith("#"))
                    pnl.Title = Lng_GetLngText(pnl.Title.Substring(1));
            }
            else if (c is ComboBox)
            {
                var pnl = c as ComboBox;
                if (pnl.Title.StartsWith("#"))
                    pnl.Title = Lng_GetLngText(pnl.Title.Substring(1));
                if (pnl.EmptyText.StartsWith("#"))
                    pnl.EmptyText = Lng_GetLngText(pnl.Title.Substring(1));
            }
            else if (c is FormPanel)
            {
                var pnl = c as FormPanel;
                if (pnl.Title.StartsWith("#"))
                    pnl.Title = Lng_GetLngText(pnl.Title.Substring(1));

                foreach (Control cc in pnl.Items)
                    Lng_SetControlTexts(cc);
            }
            else if (c is Window)
            {
                var w = c as Window;
                if (w.Title.StartsWith("#"))
                    w.Title = Lng_GetLngText(w.Title.Substring(1));
            }
            else if (c is GridPanel)
            {
                var gridPnl = c as GridPanel;
                if (gridPnl.Title.StartsWith("#"))
                    gridPnl.Title = Lng_GetLngText(gridPnl.Title.Substring(1));

                foreach (var col in gridPnl.ColumnModel.Columns)
                {
                    if (col.Header.StartsWith("#"))
                        col.Header = Lng_GetLngText(col.Header.Substring(1));

                    if (col is ImageCommandColumn)
                    {
                        var icc = col as ImageCommandColumn;
                        if (icc.Tooltip.StartsWith("#"))
                            icc.Tooltip = Lng_GetLngText(icc.Tooltip.Substring(1));
                    }
                    else if (col is CommandColumn)
                    {
                        var it = col as CommandColumn;
                        if (it.Tooltip.StartsWith("#"))
                            it.Tooltip = Lng_GetLngText(it.Tooltip.Substring(1));

                        foreach (GridCommand itt in it.Commands)
                        {
                            if (itt.Text.StartsWith("#"))
                                itt.Text = Lng_GetLngText(itt.Text.Substring(1));
                            if (itt.ToolTip.Text.StartsWith("#"))
                                itt.ToolTip.Text = Lng_GetLngText(itt.ToolTip.Text.Substring(1));
                        }
                    }
                }
            }
            else if (c is Menu)
            {
                var m = c as Menu;
                foreach (Control cc in m.Items)
                    Lng_SetControlTexts(cc);
            }
            else if (c is MenuItem)
            {
                var mi = c as MenuItem;
                if (mi.Text.StartsWith("#"))
                    mi.Text = Lng_GetLngText(mi.Text.Substring(1));

                foreach(Menu mm in mi.Menu)
                    Lng_SetControlTexts(mm);
            }
            else if (c is PagingToolbar)
            {
                var pt = c as PagingToolbar;
                if (pt.FirstText.StartsWith("#"))
                    pt.FirstText = Lng_GetLngText(pt.FirstText.Substring(1));
                if (pt.PrevText.StartsWith("#"))
                    pt.PrevText = Lng_GetLngText(pt.PrevText.Substring(1));
                if (pt.NextText.StartsWith("#"))
                    pt.NextText = Lng_GetLngText(pt.NextText.Substring(1));
                if (pt.LastText.StartsWith("#"))
                    pt.LastText = Lng_GetLngText(pt.LastText.Substring(1));
                if (pt.RefreshText.StartsWith("#"))
                    pt.RefreshText = Lng_GetLngText(pt.RefreshText.Substring(1));
                if (pt.DisplayMsg.StartsWith("#"))
                    pt.DisplayMsg = Lng_GetLngText(pt.DisplayMsg.Substring(1));
                if (pt.EmptyMsg.StartsWith("#"))
                    pt.EmptyMsg = Lng_GetLngText(pt.EmptyMsg.Substring(1));

            }

            foreach (Control cc in c.Controls)
                Lng_SetControlTexts(cc);
        }

        static Assembly assemLng = null;
        static Assembly AssemLng
        {
            get
            {
                if (assemLng == null)
                {
                    string binPath = HttpContext.Current.Server.MapPath("~/bin");
                    assemLng = Assembly.LoadFrom(System.IO.Path.Combine(binPath, "iHRM.Core.dll"));
                }
                return assemLng;
            }
        }
        public static string Lng_GetLngText(string key)
        {
            //Type t = Type.GetType(key);
            //var obj = Activator.CreateInstance(t);
            //return iHRM.WebPC.Classes.PropertyExtension1.GetPropValue();

            try
            {
                int idx = key.LastIndexOf('.');
                if (idx > 0)
                {
                    string className = key.Substring(0, idx);
                    
                    Type CT = AssemLng.GetType("iHRM.Lng." + className, true);
                    var FI = CT.GetField(key.Substring(idx + 1));
                    if (FI != null)
                        return (FI.GetValue(null) as string).Replace("&nbsp;"," ");
                }
            }
            catch { }
            return key;
        }

        public static void Load(string folder)
        {
            string fPath = HttpContext.Current.Server.MapPath("/Cpanel/Lng/" + folder);
            if (!fPath.EndsWith("\\"))
                fPath += "\\";

            LoadInFolder(fPath);

            _currentLng = folder;
            iHRM.WebPC.Classes.Helper.Cookies.WriteCookie("_currentLng", _currentLng);

            SaveJs();
        }
        static void LoadInFolder(string fPath)
        {
            if (!Directory.Exists(fPath))
                throw new Exception("Language not found!");

            var di = new DirectoryInfo(fPath);
            foreach (FileInfo fi in di.GetFiles("*.xml"))
            {
                string fName = Path.GetFileNameWithoutExtension(fi.Name);

                try
                {
                    Type t = AssemLng.GetType("iHRM.Lng." + fName);
                    iSerializeStatic.Deserialize(t, fi.FullName);
                }
                catch { throw; }
            }

            foreach (var fd in di.GetDirectories())
                LoadInFolder(fd.FullName);
        }



        public static void Save()
        {
            string fPath = HttpContext.Current.Server.MapPath("/Cpanel/Lng/vi");
            if (!fPath.EndsWith("\\"))
                fPath += "\\";

            string p = HttpContext.Current.Server.MapPath("/Cpanel/Lng");

            SaveInFolder(fPath, p);
        }

        static void SaveInFolder(string lngPath, string csPath)
        {
            if (!Directory.Exists(lngPath))
                Directory.CreateDirectory(lngPath);

            var di = (new DirectoryInfo(csPath));
            foreach (FileInfo fi in di.GetFiles("*.cs"))
            {
                if (fi.Name == "Language.cs")
                    continue;

                string fName = fi.Name.Substring(0, fi.Name.Length - 3);
                Type t = AssemLng.GetType("iHRM.Lng." + fName);
                iSerializeStatic.Serialize(t, lngPath + fName + ".xml");
            }

            foreach (var fd in di.GetDirectories())
                SaveInFolder(lngPath + Path.GetDirectoryName(fd.Name) + "\\", fd.FullName);
        }



        public static void SaveJs()
        {
            string fPath = HttpContext.Current.Server.MapPath("/Cpanel/Lng/" + _currentLng);
            if (!fPath.EndsWith("\\"))
                fPath += "\\";

            string js = SaveJsInFolder(fPath);
            File.WriteAllText(HttpContext.Current.Server.MapPath("/Cpanel/Lng/language.js"), "var Lng = { " + js + @" }; function LngGet(key) {
                try { var s = eval(key); if (s == undefined) return key; } catch(ex){}
                return s;
            }", System.Text.Encoding.UTF8);
        }
        static string SaveJsInFolder(string fPath)
        {
            if (!Directory.Exists(fPath))
                return "";

            StringBuilder sb = new StringBuilder();
            var di = new DirectoryInfo(fPath);

            foreach (FileInfo fi in di.GetFiles("*.xml"))
            {
                string fName = Path.GetFileNameWithoutExtension(fi.Name);
                sb.AppendLine(fName + " : { ");
                try
                {
                    Type t = AssemLng.GetType("iHRM.Lng." + fName);
                    
                    FieldInfo[] fieldArray = t.GetFields(BindingFlags.Static | BindingFlags.Public);

                    sb.AppendLine(string.Join(",\n", fieldArray.Select(i => string.Format("{0}:'{1}'", i.Name, i.GetValue(i.FieldType).ToString().Replace("'", "\\'")))));
                }
                catch { throw; }

                sb.AppendLine(" },");
            }

            foreach (var fd in di.GetDirectories())
                sb.AppendLine("\n\n\n" + SaveJsInFolder(fd.FullName));

            string s = sb.ToString();
            if (s.EndsWith(","))
                s = s.Substring(0, s.Length - 1);
            return s;
        }

    }
}