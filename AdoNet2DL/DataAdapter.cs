using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet2DL
{
    class DataAdapter
    {
        SqlConnection SqlConObj;
        SqlCommand SqlCmdObj;

        public int InsertFaculty(int IpId, string IpEmail, string IpName, out int rowAffected)
        {
            SqlDataAdapter da = new SqlDataAdapter(); ;
            DataTable dt = new DataTable();
            SqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["MPConStr"].ToString());
            SqlCmdObj = new SqlCommand("dbo.uspInsertFaculty", SqlConObj);
            SqlCmdObj.CommandType = CommandType.StoredProcedure;
            SqlCmdObj.Parameters.AddWithValue("@PSNo", IpId);
            SqlCmdObj.Parameters.AddWithValue("@EmailId", IpEmail);
            SqlCmdObj.Parameters.AddWithValue("@NAME", IpName);
            try
            {
                SqlParameter rm = SqlCmdObj.Parameters.Add("RetVal", SqlDbType.Int);
                rm.Direction = ParameterDirection.ReturnValue;
                da.SelectCommand = SqlCmdObj;
                da.Fill(dt);
                int returnValue = (int)rm.Value;
                rowAffected = da.Update(dt);
                return returnValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oopppss, Something went Wrong !");
                rowAffected = 0;
                return 0;
            }

        }
        public int UpdateFaculty(int IpId, string IpName, out int rowAffected)
        {
            SqlDataAdapter da = new SqlDataAdapter(); ;
            DataTable dt = new DataTable();
            SqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["MPConStr"].ToString());
            SqlCmdObj = new SqlCommand("dbo.uspUpdateFaculty", SqlConObj);
            SqlCmdObj.CommandType = CommandType.StoredProcedure;
            SqlCmdObj.Parameters.AddWithValue("@PSNo", IpId);
            SqlCmdObj.Parameters.AddWithValue("@NAME", IpName);
            try
            {
                SqlParameter rm = SqlCmdObj.Parameters.Add("RetVal", SqlDbType.Int);
                rm.Direction = ParameterDirection.ReturnValue;
                da.SelectCommand = SqlCmdObj;
                da.Fill(dt);
                int returnValue = (int)rm.Value;
                rowAffected = da.Update(dt);
                return returnValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Oopppss, Something went Wrong !");
                rowAffected = 0;
                return 0;
            }

        }
        public int DeleteFaculty(int IpId, out int rowAffected)
        {
            SqlDataAdapter da = new SqlDataAdapter(); ;
            DataTable dt = new DataTable();
            SqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["MPConStr"].ToString());
            SqlCmdObj = new SqlCommand("dbo.uspDeleteFaculty", SqlConObj);
            SqlCmdObj.CommandType = CommandType.StoredProcedure;
            SqlCmdObj.Parameters.AddWithValue("@PSNo", IpId);
            try
            {
                SqlParameter rm = SqlCmdObj.Parameters.Add("RetVal", SqlDbType.Int);
                rm.Direction = ParameterDirection.ReturnValue;
                da.SelectCommand = SqlCmdObj;
                da.Fill(dt);
                int returnValue = (int)rm.Value;
                int status = SqlCmdObj.ExecuteNonQuery();
                Console.WriteLine("Status" + status);
                rowAffected = status;
                return returnValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oopppss, Something went Wrong !");
                rowAffected = 0;
                return 0;
            }
        }
    }
}
