using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace ThrottleCoreCRM.Client.Pages._Original
{
    public partial class AddEmployee
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
        public Throttle_Core_WebSiteService Throttle_Core_WebSiteService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            employee = new ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee();
        }
        protected bool errorVisible;
        protected ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee employee;

        protected IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department> departmentsForDepartmentID;


        protected int departmentsForDepartmentIDCount;
        protected ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department departmentsForDepartmentIDValue;
        protected async Task departmentsForDepartmentIDLoadData(LoadDataArgs args)
        {
            try
            {
                var result = await Throttle_Core_WebSiteService.GetDepartments(top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null, filter: $"contains(Name, '{(!string.IsNullOrEmpty(args.Filter) ? args.Filter : "")}')", orderby: $"{args.OrderBy}");
                departmentsForDepartmentID = result.Value.AsODataEnumerable();
                departmentsForDepartmentIDCount = result.Count;

                if (!object.Equals(employee.DepartmentID, null))
                {
                    var valueResult = await Throttle_Core_WebSiteService.GetDepartments(filter: $"Id eq {employee.DepartmentID}");
                    var firstItem = valueResult.Value.FirstOrDefault();
                    if (firstItem != null)
                    {
                        departmentsForDepartmentIDValue = firstItem;
                    }
                }

            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load Department" });
            }
        }
        protected async Task FormSubmit()
        {
            try
            {
                var result = await Throttle_Core_WebSiteService.CreateEmployee(employee);
                DialogService.Close(employee);
            }
            catch (Exception ex)
            {
                errorVisible = true;
            }
        }

        protected async Task CancelButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }


        protected bool hasChanges = false;
        protected bool canEdit = true;

        [Inject]
        protected SecurityService Security { get; set; }
    }
}