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
    public partial class AddOpportunity
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
            opportunity = new ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity();
        }
        protected bool errorVisible;
        protected ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity opportunity;

        protected IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact> contactsForContactId;

        protected IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus> opportunityStatusesForStatusId;


        protected int contactsForContactIdCount;
        protected ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact contactsForContactIdValue;
        protected async Task contactsForContactIdLoadData(LoadDataArgs args)
        {
            try
            {
                var result = await Throttle_Core_WebSiteService.GetContacts(top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null, filter: $"contains(Email, '{(!string.IsNullOrEmpty(args.Filter) ? args.Filter : "")}')", orderby: $"{args.OrderBy}");
                contactsForContactId = result.Value.AsODataEnumerable();
                contactsForContactIdCount = result.Count;

                if (!object.Equals(opportunity.ContactId, null))
                {
                    var valueResult = await Throttle_Core_WebSiteService.GetContacts(filter: $"Id eq {opportunity.ContactId}");
                    var firstItem = valueResult.Value.FirstOrDefault();
                    if (firstItem != null)
                    {
                        contactsForContactIdValue = firstItem;
                    }
                }

            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load Contact" });
            }
        }

        protected int opportunityStatusesForStatusIdCount;
        protected ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus opportunityStatusesForStatusIdValue;
        protected async Task opportunityStatusesForStatusIdLoadData(LoadDataArgs args)
        {
            try
            {
                var result = await Throttle_Core_WebSiteService.GetOpportunityStatuses(top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null, filter: $"contains(Name, '{(!string.IsNullOrEmpty(args.Filter) ? args.Filter : "")}')", orderby: $"{args.OrderBy}");
                opportunityStatusesForStatusId = result.Value.AsODataEnumerable();
                opportunityStatusesForStatusIdCount = result.Count;

                if (!object.Equals(opportunity.StatusId, null))
                {
                    var valueResult = await Throttle_Core_WebSiteService.GetOpportunityStatuses(filter: $"Id eq {opportunity.StatusId}");
                    var firstItem = valueResult.Value.FirstOrDefault();
                    if (firstItem != null)
                    {
                        opportunityStatusesForStatusIdValue = firstItem;
                    }
                }

            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load OpportunityStatus" });
            }
        }
        protected async Task FormSubmit()
        {
            try
            {
                var result = await Throttle_Core_WebSiteService.CreateOpportunity(opportunity);
                DialogService.Close(opportunity);
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