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
    public partial class EditTask
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

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            task = await Throttle_Core_WebSiteService.GetTaskById(id:Id);
        }
        protected bool errorVisible;
        protected ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task task;

        protected IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity> opportunitiesForOpportunityId;

        protected IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType> taskTypesForTypeId;

        protected IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus> taskStatusesForStatusId;


        protected int opportunitiesForOpportunityIdCount;
        protected ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity opportunitiesForOpportunityIdValue;
        protected async Task opportunitiesForOpportunityIdLoadData(LoadDataArgs args)
        {
            try
            {
                var result = await Throttle_Core_WebSiteService.GetOpportunities(top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null, filter: $"contains(Name, '{(!string.IsNullOrEmpty(args.Filter) ? args.Filter : "")}')", orderby: $"{args.OrderBy}");
                opportunitiesForOpportunityId = result.Value.AsODataEnumerable();
                opportunitiesForOpportunityIdCount = result.Count;

                if (!object.Equals(task.OpportunityId, null))
                {
                    var valueResult = await Throttle_Core_WebSiteService.GetOpportunities(filter: $"Id eq {task.OpportunityId}");
                    var firstItem = valueResult.Value.FirstOrDefault();
                    if (firstItem != null)
                    {
                        opportunitiesForOpportunityIdValue = firstItem;
                    }
                }

            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load Opportunity" });
            }
        }

        protected int taskTypesForTypeIdCount;
        protected ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType taskTypesForTypeIdValue;
        protected async Task taskTypesForTypeIdLoadData(LoadDataArgs args)
        {
            try
            {
                var result = await Throttle_Core_WebSiteService.GetTaskTypes(top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null, filter: $"contains(Name, '{(!string.IsNullOrEmpty(args.Filter) ? args.Filter : "")}')", orderby: $"{args.OrderBy}");
                taskTypesForTypeId = result.Value.AsODataEnumerable();
                taskTypesForTypeIdCount = result.Count;

                if (!object.Equals(task.TypeId, null))
                {
                    var valueResult = await Throttle_Core_WebSiteService.GetTaskTypes(filter: $"Id eq {task.TypeId}");
                    var firstItem = valueResult.Value.FirstOrDefault();
                    if (firstItem != null)
                    {
                        taskTypesForTypeIdValue = firstItem;
                    }
                }

            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load TaskType" });
            }
        }

        protected int taskStatusesForStatusIdCount;
        protected ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus taskStatusesForStatusIdValue;
        protected async Task taskStatusesForStatusIdLoadData(LoadDataArgs args)
        {
            try
            {
                var result = await Throttle_Core_WebSiteService.GetTaskStatuses(top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null, filter: $"contains(Name, '{(!string.IsNullOrEmpty(args.Filter) ? args.Filter : "")}')", orderby: $"{args.OrderBy}");
                taskStatusesForStatusId = result.Value.AsODataEnumerable();
                taskStatusesForStatusIdCount = result.Count;

                if (!object.Equals(task.StatusId, null))
                {
                    var valueResult = await Throttle_Core_WebSiteService.GetTaskStatuses(filter: $"Id eq {task.StatusId}");
                    var firstItem = valueResult.Value.FirstOrDefault();
                    if (firstItem != null)
                    {
                        taskStatusesForStatusIdValue = firstItem;
                    }
                }

            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load TaskStatus" });
            }
        }
        protected async Task FormSubmit()
        {
            try
            {
                var result = await Throttle_Core_WebSiteService.UpdateTask(id:Id, task);
                if (result.StatusCode == System.Net.HttpStatusCode.PreconditionFailed)
                {
                     hasChanges = true;
                     canEdit = false;
                     return;
                }
                DialogService.Close(task);
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


        protected async Task ReloadButtonClick(MouseEventArgs args)
        {
            hasChanges = false;
            canEdit = true;

            task = await Throttle_Core_WebSiteService.GetTaskById(id:Id);
        }
    }
}