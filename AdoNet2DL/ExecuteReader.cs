using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet2DL
{
    class ExecuteReader
    {
        public ExecuteReader()
        {

        }
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        public void SetFacultyDetails(string Name, string Email, int PSNo)
        {
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["In"].ToString());
                sqlCmdObj = new SqlCommand(@"insert into dbo.Faculty (@FacultyName,@EmailID,@PSNo)", sqlConObj);
                sqlCmdObj.Parameters.AddWithValue("@FacultyName", Name);
                sqlCmdObj.Parameters.AddWithValue("@EmailID", Email);
                sqlCmdObj.Parameters.AddWithValue("@PSNo", PSNo);
                sqlConObj.Open();
                sqlCmdObj.ExecuteReader();
                Console.WriteLine("Data Insterted Successfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops!!! Something Happened!");
                Console.WriteLine(ex.Message);

            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}
