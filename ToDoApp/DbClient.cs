using System.Data.SqlClient;

namespace ToDoApp
{
    internal class DbClient
    {
        public static string ConnStr { get; set; } = "Data Source=DECAGONNET006;Initial Catalog=SQ017;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(ConnStr);
            return conn;
        }

        public static bool ExecuteQuery(string sql)
        {
            SqlConnection conn = null;
            try
            {
                //get connection
                conn = GetConnection();
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);

                //execute the command
                var result = command.ExecuteNonQuery();

                if(result > 0)
                    return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            
            return false;
        }

        public static SqlDataReader ReadData(string sql)
        {
            SqlConnection conn = null;
            try
            {
                //get connection
                conn = GetConnection();
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);

                //execute the command
                var result = command.ExecuteReader();

                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
