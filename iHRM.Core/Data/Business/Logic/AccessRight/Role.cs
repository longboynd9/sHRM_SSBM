using iHRM.Common.Code;
using iHRM.Core.Business.DbObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.AccessRight
{
    public class Role : LogicBase
    {
        public class ruleAlias
        {
            public ruleAlias(w5sysRule r)
            {
                if (r == null)
                    throw new ArgumentNullException("rule");

                id = r.functionID;
                parentID = r.w5sysFunction == null ? 0 : r.w5sysFunction.parentId.Value;
                funcName = r.w5sysFunction == null ? "-" : string.Format("{0} - {1}", r.w5sysFunction.code, r.w5sysFunction.caption);
                rule = r.rules;
                Find = BitHelper.Has(rule, (int)Enums.eFunction.Find);
                New = BitHelper.Has(rule, (int)Enums.eFunction.New);
                Edit = BitHelper.Has(rule, (int)Enums.eFunction.Edit);
                Delete = BitHelper.Has(rule, (int)Enums.eFunction.Delete);
                Import = BitHelper.Has(rule, (int)Enums.eFunction.Import);
                Export = BitHelper.Has(rule, (int)Enums.eFunction.Export);
                Print = BitHelper.Has(rule, (int)Enums.eFunction.Print);
                Choose = BitHelper.Has(rule, (int)Enums.eFunction.Choose);
                Save = BitHelper.Has(rule, (int)Enums.eFunction.Save);
                Exit = BitHelper.Has(rule, (int)Enums.eFunction.Exit);
            }
            public ruleAlias(w5sysFunction func, long rules)
            {
                id = func.id;
                parentID = func.parentId ?? 0;
                funcName = func.caption;
                rule = rules;
                Find = BitHelper.Has(rule, (int)Enums.eFunction.Find);
                New = BitHelper.Has(rule, (int)Enums.eFunction.New);
                Edit = BitHelper.Has(rule, (int)Enums.eFunction.Edit);
                Delete = BitHelper.Has(rule, (int)Enums.eFunction.Delete);
                Import = BitHelper.Has(rule, (int)Enums.eFunction.Import);
                Export = BitHelper.Has(rule, (int)Enums.eFunction.Export);
                Print = BitHelper.Has(rule, (int)Enums.eFunction.Print);
                Choose = BitHelper.Has(rule, (int)Enums.eFunction.Choose);
                Save = BitHelper.Has(rule, (int)Enums.eFunction.Save);
                Exit = BitHelper.Has(rule, (int)Enums.eFunction.Exit);
            }

            public long parentID { get; set; }

            public long id { get; set; }
            public string funcName { get; set; }

            public long rule { get; set; }

            public bool Find { get; set; }
            public bool New { get; set; }
            public bool Edit { get; set; }
            public bool Delete { get; set; }
            public bool Import { get; set; }
            public bool Export { get; set; }
            public bool Print { get; set; }
            public bool Choose { get; set; }
            public bool Save { get; set; }
            public bool Exit { get; set; }

            public w5sysRule getw5_sysRule(long roleID)
            {
                w5sysRule f = new w5sysRule();
                f.functionID = id;
                f.roleID = roleID;
                f.rules = rule;
                f.status = 1;

                return f;
            }
        }

        public Role() : base("w5sysRoles") { }

        public List<Role.ruleAlias> BuildTreeFunction(IQueryable<w5sysRule> lst, int flatForm)
        {
            List<Role.ruleAlias> lstRA = new List<Role.ruleAlias>();
            var lstFunc = BuildFunctionTree(1, flatForm);
            foreach (var func in lstFunc)
            {
                w5sysRule r = lst.FirstOrDefault(i => i.functionID == func.id);
                if (r == null)
                    lstRA.Add(new Role.ruleAlias(func, 0));
                else
                    lstRA.Add(new Role.ruleAlias(func, r.rules));
            }

            return lstRA;
        }

        public List<w5sysFunction> BuildFunctionTree(long parentId = 1, int flatForm = 0)
        {
            List<w5sysFunction> lst = new List<w5sysFunction>();

            using (var db = new dcDatabaseDataContext(Provider.ConnectionString))
            {
                var lst2 = (from i in db.w5sysFunctions where i.parentId == parentId select i).ToList();
                foreach (var item in lst2)
                {
                    item.caption = Function.GetFunctionHtmlCaption(item, flatForm: flatForm);
                    lst.Add(item);
                    lst.AddRange(BuildFunctionTree2(item.id, db, 1, flatForm));
                }
            }

            return lst;
        }
        private List<w5sysFunction> BuildFunctionTree2(long parentId, dcDatabaseDataContext db, int lv, int flatForm)
        {
            List<w5sysFunction> lst = new List<w5sysFunction>();
            var lst2 = (from i in db.w5sysFunctions where i.parentId == parentId select i).ToList();
            foreach (var item in lst2)
            {
                item.caption = Function.GetFunctionHtmlCaption(item, lv, eLanguage.VN, flatForm);
                lst.Add(item);
                lst.AddRange(BuildFunctionTree2(item.id, db, lv + 1, flatForm));
            }
            return lst;
        }

    }
}
