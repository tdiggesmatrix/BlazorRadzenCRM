using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ThrottleCoreCRM.Server.Models.Throttle_Core_Summary;
using ThrottleCoreCRM.Client.Services; // Assuming DataService is in this namespace

namespace ThrottleCoreCRM.Client.Pages
{
    public partial class Dashboard : ComponentBase
    {
        [Inject]
        public DataService DataService { get; set; }

        private IEnumerable<UspDashboardGetStatisticsTopVehiclesServiced> ChartDataList2;

        protected override async Task OnInitializedAsync()
        {
            await LoadChartDataAsync();
        }

        private async Task LoadChartDataAsync()
        {
            // Assuming GetChartDataAsync() returns a DataTable
            DataTable dataTable = await DataService.GetChartDataAsync();

            // Convert DataTable to a collection of UspDashboardGetStatisticsTopVehiclesServiced objects
            ChartDataList2 = ConvertDataTableToList(dataTable);
        }

        private IEnumerable<UspDashboardGetStatisticsTopVehiclesServiced> ConvertDataTableToList(DataTable dataTable)
        {
            var chartDataList = new List<UspDashboardGetStatisticsTopVehiclesServiced>();

            foreach (DataRow row in dataTable.Rows)
            {
                var item = new UspDashboardGetStatisticsTopVehiclesServiced
                {
                    Placement = Convert.ToInt32(row["Placement"]),
                    VehicleMake = row["Vehicle-Make"].ToString(),
                    VehicleModel = row["Vehicle-Model"].ToString(),
                    Vehicle = row["Vehicle"].ToString(),
                    NumberServiced = row["Number-Serviced"].ToString()
                };
                chartDataList.Add(item);
            }

            return chartDataList;
        }
    }
}
