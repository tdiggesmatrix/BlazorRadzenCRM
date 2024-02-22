using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ThrottleCoreCRM.Client.Services
{
    public class DataService
    {
        private readonly string _connectionString;

        public DataService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Throttle_Core_DashboardConnection");
        }

        public async Task<DataTable> GetChartDataAsync()
        {
            DataTable chartData = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_Dashboard_Get_Statistics_TopVehiclesServiced", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@WebUserID", 1);
                    command.Parameters.AddWithValue("@CustomerID", 1);
                    command.Parameters.AddWithValue("@Stores", 1);
                    command.Parameters.AddWithValue("@Groups", "1,2,3");
                    command.Parameters.AddWithValue("@StartDate", "11/13/2023");
                    command.Parameters.AddWithValue("@EndDate", "11/13/2023");
                    command.Parameters.AddWithValue("@OnlyActiveStores", 0);
                    command.Parameters.AddWithValue("@ext_TopXNumberofVehicles", 5);
                    command.Parameters.AddWithValue("@ext_IncludeVehicleYear", 0);

                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        chartData = new DataTable();
                        chartData.Load(reader);
                    }
                }
            }

            return chartData;
        }
    }
}
