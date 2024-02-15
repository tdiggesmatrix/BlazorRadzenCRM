using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace ThrottleCoreCRM.Client.Pages.Billing
{
    public partial class RemindersSettingsAdmins
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
        public Throttle_Core_BillingService Throttle_Core_BillingService { get; set; }

        protected IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin> remindersSettingsAdmins;

        protected RadzenDataGrid<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin> grid0;
        protected int count;

        protected string search = "";

        [Inject]
        protected SecurityService Security { get; set; }

        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

            await grid0.Reload();
        }

        protected async Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var result = await Throttle_Core_BillingService.GetRemindersSettingsAdmins(filter: $@"(contains(dealercode,""{search}"") or contains(processweeks,""{search}"") or contains(seed_mail,""{search}"") or contains(seed_name,""{search}"") or contains(seed_address,""{search}"") or contains(seed_city,""{search}"") or contains(seed_state,""{search}"") or contains(seed_zip,""{search}"") or contains(seed_email,""{search}"") or contains(seed_emailaddress,""{search}"") or contains(globalcatalogusers,""{search}"") or contains(email_reply_address,""{search}"") or contains(barcode_format,""{search}"") or contains(messaging_accountSID,""{search}"") or contains(messaging_bannerplacements,""{search}"") or contains(servicerecommendations_video_provider,""{search}"") or contains(weekly_budget_apportion,""{search}"") or contains(weekly_budget_priority,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby: $"{args.OrderBy}", top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null);
                remindersSettingsAdmins = result.Value.AsODataEnumerable();
                count = result.Count;
            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load RemindersSettingsAdmins" });
            }
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddRemindersSettingsAdmin>("Add RemindersSettingsAdmin", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin> args)
        {
            await DialogService.OpenAsync<EditRemindersSettingsAdmin>("Edit RemindersSettingsAdmin", new Dictionary<string, object> { {"fldRecordID", args.Data.fldRecordID} });
            await grid0.Reload();
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin remindersSettingsAdmin)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await Throttle_Core_BillingService.DeleteRemindersSettingsAdmin(fldRecordId:remindersSettingsAdmin.fldRecordID);

                    if (deleteResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (Exception ex)
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Summary = $"Error",
                    Detail = $"Unable to delete RemindersSettingsAdmin"
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Throttle_Core_BillingService.ExportRemindersSettingsAdminsToCSV(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "RemindersSettingsAdmins");
            }

            if (args == null || args.Value == "xlsx")
            {
                await Throttle_Core_BillingService.ExportRemindersSettingsAdminsToExcel(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "RemindersSettingsAdmins");
            }
        }
    }
}