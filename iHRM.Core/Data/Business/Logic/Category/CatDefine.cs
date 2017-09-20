using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.Category
{
    public class CatDefine
    {
        public DataTable GetAllCatDefine()
        {
            return Provider.ExecuteDataTable("p_CatDefine_GetAll");
        }
        public DataRow Get1CatDefine(Guid? id)
        {
            return Provider.ExecuteDataRow("p_CatDefine_Get1", new SqlParameter("id", id));
        }
        public DataTable GetCatDefineInfo(Guid? catDefID)
        {
            return Provider.ExecuteDataTable("p_CatDefine_GetInfo", new SqlParameter("catDefID", catDefID));
        }



        public DataTable GetDataOfTable(string tableName, string[] columnName)
        {
            return Provider.ExecuteDataTable("p_CatDefine_GetDataOfTable", 
                new SqlParameter("tableName", tableName),
                Provider.CreateParameter_StringArray("columnName", columnName)
            );
        }
    }
}
