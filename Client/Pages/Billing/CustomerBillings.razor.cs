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
    public partial class CustomerBillings
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

        protected IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling> customerBillings;

        protected RadzenDataGrid<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling> grid0;
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
                var result = await Throttle_Core_BillingService.GetCustomerBillings(filter: $@"(contains(BILL_CODE,""{search}"") or contains(COMPANY_NAME,""{search}"") or contains(ADDRESS_LINE_1,""{search}"") or contains(ADDRESS_LINE_2,""{search}"") or contains(CITY,""{search}"") or contains(STATE,""{search}"") or contains(ZIP,""{search}"") or contains(PHONE,""{search}"") or contains(FAX,""{search}"") or contains(EMAIL,""{search}"") or contains(CONTACT,""{search}"") or contains(SALUTATION,""{search}"") or contains(TERMS,""{search}"") or contains(TAX_EXEMPT,""{search}"") or contains(SWITCHES,""{search}"") or contains(TAX_EXEMPT_NUMBER,""{search}"") or contains(SHIPPING_ACCOUNT_NUMBER,""{search}"") or contains(CCD_REF_ID,""{search}"") or contains(EDI_CODE,""{search}"") or contains(DEFAULT_CONTACT_ID,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby: $"{args.OrderBy}", top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null);
                customerBillings = result.Value.AsODataEnumerable();
                count = result.Count;
            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load CustomerBillings" });
            }
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddCustomerBilling>("Add CustomerBilling", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling> args)
        {
            await DialogService.OpenAsync<EditCustomerBilling>("Edit CustomerBilling", new Dictionary<string, object> { {"fldRecordID", args.Data.fldRecordID} });
            await grid0.Reload();
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling customerBilling)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await Throttle_Core_BillingService.DeleteCustomerBilling(fldRecordId:customerBilling.fldRecordID);

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
                    Detail = $"Unable to delete CustomerBilling"
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Throttle_Core_BillingService.ExportCustomerBillingsToCSV(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "CustomerBillings");
            }

            if (args == null || args.Value == "xlsx")
            {
                await Throttle_Core_BillingService.ExportCustomerBillingsToExcel(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "CustomerBillings");
            }
        }
    }
}