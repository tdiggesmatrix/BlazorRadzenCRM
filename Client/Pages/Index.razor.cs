using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace ThrottleCoreCRM.Client.Pages
{
    public partial class Index
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }
    }
}

//using System.Diagnostics;
//using System.Net.Http;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Authorization;
//using Microsoft.AspNetCore.Components.Forms;
//using Microsoft.AspNetCore.Components.Routing;
//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.AspNetCore.Components.Web.Virtualization;
//using Microsoft.JSInterop;
//using Radzen;
//using Radzen.Blazor;
//using ThrottleCoreCRM.Server.Models;
//using ThrottleCoreCRM.Shared.Models;
//using ThrottleCoreCRM.Client;



//namespace Throttle_Core_CRM.Client.Pages
//{
//    public partial class Index
//    {
//        [Inject]
//        protected IJSRuntime JSRuntime { get; set; }

//        [Inject]
//        protected NavigationManager NavigationManager { get; set; }

//        [Inject]
//        protected DialogService DialogService { get; set; }

//        [Inject]
//        protected TooltipService TooltipService { get; set; }

//        [Inject]
//        protected ContextMenuService ContextMenuService { get; set; }

//        [Inject]
//        protected NotificationService NotificationService { get; set; }

//        [Inject]
//        protected SecurityService Security { get; set; }

//        [Inject]
//        HttpClient Http { get; set; }

//        [Inject]
//        Throttle_Core_WebSiteService Throttle_Core_WebSiteService { get; set; }

//        public async Task<IEnumerable<clsRevenueByCompany>> tskRevenueByCompany()
//        {
//            var response = await Http.SendAsync(new HttpRequestMessage(HttpMethod.Get, new Uri($"{NavigationManager.BaseUri}api/servermethods/Iact_RevenueByCompany")));
//            return await response.ReadAsync<IEnumerable<clsRevenueByCompany>>();
//        }
//        public async Task<IEnumerable<clsRevenueByEmployee>> tskRevenueByEmployee()
//        {
//            var response = await Http.SendAsync(new HttpRequestMessage(HttpMethod.Get, new Uri($"{NavigationManager.BaseUri}api/servermethods/Iact_RevenueByEmployee")));
//            return await response.ReadAsync<IEnumerable<clsRevenueByEmployee>>();
//        }
//        public async Task<IEnumerable<clsRevenueByMonth>> tskRevenueByMonth()
//        {
//            var response = await Http.SendAsync(new HttpRequestMessage(HttpMethod.Get, new Uri($"{NavigationManager.BaseUri}api/servermethods/Iact_RevenueByMonth")));
//            return await response.ReadAsync<IEnumerable<clsRevenueByMonth>>();
//        }
//        public async Task<clsStats> tskMonthlyStats()
//        {
//            var response = await Http.SendAsync(new HttpRequestMessage(HttpMethod.Get, new Uri($"{NavigationManager.BaseUri}api/servermethods/Iact_monthlystats")));
//            return await response.ReadAsync<clsStats>();
//        }

//        //Shane - New section to call Daily Sales States function 
//        public async Task<GetEmployeesWithDepartment_Result> tskGetEmployeesWithDepartment()
//        {
//            var response = await Http.SendAsync(new HttpRequestMessage(HttpMethod.Get, new Uri($"{NavigationManager.BaseUri}api/servermethods/IAct_GetEmployeesWithDepartment")));
//            return await response.ReadAsync<GetEmployeesWithDepartment_Result>();
//        }

//        protected override async Task OnInitializedAsync()
//        {
//            //Shane put in new line here
//            varGetEmployeesWithDepartment = await tskGetEmployeesWithDepartment();
//            varStats = await tskMonthlyStats();
//            varRevenueByCompany = await tskRevenueByCompany();
//            varRevenueByMonth = await tskRevenueByMonth();
//            varRevenueByEmployee = await tskRevenueByEmployee();
//        }

//        protected async Task getOpportunitiesResultLoadData(LoadDataArgs args)
//        {
//            try
//            {
//                var result = await Throttle_Core_WebSiteService.GetOpportunities(expand: "Contact,OpportunityStatus", top: args.Top, skip: args.Skip, count: args.Top != null && args.Skip != null, filter: args.Filter, orderby: args.OrderBy);
//                getOpportunitiesResult = result.Value.AsODataEnumerable();

//                getOpportunitiesResultCount = result.Count;
//            }
//            catch (Exception e)
//            {
//                NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "Unable to load Opportunities" });
//                Console.WriteLine(e.Message);
//            }
//        }

//        protected async Task getTasksResultLoadData(LoadDataArgs args)
//        {
//            try
//            {
//                var result = await Throttle_Core_WebSiteService.GetTasks(expand: "Opportunity($expand=User,Contact)", top: args.Top, skip: args.Skip, count: args.Top != null && args.Skip != null, filter: args.Filter, orderby: args.OrderBy);
//                getTasksResult = result.Value.AsODataEnumerable();

//                getTasksResultCount = result.Count;
//            }
//            catch (Exception e)
//            {
//                NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "Unable to load Tasks" });
//                Console.WriteLine(e.Message);
//            }
//        }

//        clsStats varStats { get; set; }

//        //Shane - new line in here
//        GetEmployeesWithDepartment_Result varGetEmployeesWithDepartment { get; set; }
//        IEnumerable<clsRevenueByCompany> varRevenueByCompany { get; set; }
//        IEnumerable<clsRevenueByMonth> varRevenueByMonth { get; set; }
//        IEnumerable<clsRevenueByEmployee> varRevenueByEmployee { get; set; }

//        IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity> getOpportunitiesResult { get; set; }
//        IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task> getTasksResult { get; set; }

//        protected int getOpportunitiesResultCount;

//        protected int getTasksResultCount;

//    }

//}
