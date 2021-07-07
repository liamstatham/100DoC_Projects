using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MyClassesTest
{
    public class TestBase
    {
        public TestContext TestContext { get; set; }

        protected string _GoodFileName;
        public DataTable TestDataTable { get; set; }

        public DataTable LoadDataTable(string sql, string connection)
        {
            TestDataTable = null;

            try
            {
                //Create sql conn
                using (SqlConnection ConnectionObject = new SqlConnection(connection))
                {
                    //Create command object
                    using (SqlCommand CommandObject = new SqlCommand(sql, ConnectionObject))
                    {
                        //Create SQL adaptor
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandObject))
                        {
                            //Fill data table using adaptor
                            TestDataTable = new DataTable();
                            da.Fill(TestDataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Error in LoadDataTable Method" + Environment.NewLine);
            }
            return TestDataTable;
        }

        protected void SetGoodFileName()
        {
            _GoodFileName = TestContext.Properties["GoodFileName"].ToString();
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        protected void WriteDescription(Type typ)
        {
            string testName = TestContext.TestName;

            //FInd the test method currently exceuting
            MemberInfo method = typ.GetMethod(testName);
            if (method != null)
            {
                // See if the [Description] Attribute exists on this method
                Attribute attr = method.GetCustomAttribute(typeof(DescriptionAttribute));
                if (attr != null)
                {
                    //Cast the attribute to a description attribute
                    DescriptionAttribute dattr = (DescriptionAttribute)attr;
                    // display the test description
                    TestContext.WriteLine("Test Description: " + dattr.Description);
                }
            }
        }
    }
}
