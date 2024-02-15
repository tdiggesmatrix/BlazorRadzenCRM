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
    public partial class CustomerShippings
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

        protected IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping> customerShippings;

        protected RadzenDataGrid<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping> grid0;
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
                var result = await Throttle_Core_BillingService.GetCustomerShippings(filter: $@"(contains(CUSTOMER_CODE,""{search}"") or contains(COMPANY_NAME,""{search}"") or contains(ADDRESS_LINE_1,""{search}"") or contains(ADDRESS_LINE_2,""{search}"") or contains(CITY,""{search}"") or contains(STATE,""{search}"") or contains(ZIP_CODE,""{search}"") or contains(PHONE_NUMBER,""{search}"") or contains(FAX_NUMBER,""{search}"") or contains(EMAIL_ADDRESS,""{search}"") or contains(BILL_REFERENCE,""{search}"") or contains(MASTER_CUSTOMER,""{search}"") or contains(COST_CENTER,""{search}"") or contains(CONTACT,""{search}"") or contains(SALUTATION,""{search}"") or contains(SALES_REP,""{search}"") or contains(TAX_LOCATION,""{search}"") or contains(CATEGORY,""{search}"") or contains(NOTES,""{search}"") or contains(SWITCHES,""{search}"") or contains(OPERATOR_CODE,""{search}"") or contains(HTML_CODE,""{search}"") or contains(DUNS,""{search}"") or contains(SHARED_SECRET,""{search}"") or contains(EDI_CODE,""{search}"") or contains(FEDEX_ACCOUNT,""{search}"") or contains(FEDEX_METER_NUM,""{search}"") or contains(FEDEX_KEY,""{search}"") or contains(FEDEX_PASSWORD,""{search}"") or contains(DEFAULT_CONTACT_ID,""{search}"") or contains(REBATE_CODE,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby: $"{args.OrderBy}", top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null);
                customerShippings = result.Value.AsODataEnumerable();
                count = result.Count;
            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load CustomerShippings" });
            }
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddCustomerShipping>("Add CustomerShipping", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping> args)
        {
            await DialogService.OpenAsync<EditCustomerShipping>("Edit CustomerShipping", new Dictionary<string, object> { {"fldRecordID", args.Data.fldRecordID} });
            await grid0.Reload();
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping customerShipping)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await Throttle_Core_BillingService.DeleteCustomerShipping(fldRecordId:customerShipping.fldRecordID);

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
                    Detail = $"Unable to delete CustomerShipping"
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Throttle_Core_BillingService.ExportCustomerShippingsToCSV(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "CustomerShippings");
            }

            if (args == null || args.Value == "xlsx")
            {
                await Throttle_Core_BillingService.ExportCustomerShippingsToExcel(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "CustomerShippings");
            }
        }
    }
}