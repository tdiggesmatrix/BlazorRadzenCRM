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
    public partial class LineItems
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

        protected IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem> lineItems;

        protected RadzenDataGrid<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem> grid0;
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
                var result = await Throttle_Core_BillingService.GetLineItems(filter: $@"(contains(ITEM_CODE,""{search}"") or contains(TRACKING,""{search}"") or contains(PRODUCT,""{search}"") or contains(PRODUCT_DESC_1,""{search}"") or contains(PRODUCT_DESC_2,""{search}"") or contains(PRODUCT_CATEGORY,""{search}"") or contains(SPEC_REF,""{search}"") or contains(REMARKS,""{search}"") or contains(VENDOR,""{search}"") or contains(VEND_Q_NUM,""{search}"") or contains(VEND_J_NUM,""{search}"") or contains(AP_SEQ,""{search}"") or contains(SELL_UNIT_OF_MEASURE,""{search}"") or contains(BUY_UNIT_OF_MEASURE,""{search}"") or contains(COST_CENTER,""{search}"") or contains(SWITCHES,""{search}"") or contains(TAX_EXEMPT,""{search}"") or contains(SWITCHES2,""{search}"") or contains(ALT_GL_SALE,""{search}"") or contains(JOB_NUMBER,""{search}"") or contains(ALT_SALES_TAX,""{search}"") or contains(GL_DIV,""{search}"") or contains(MANUFACTURE_ID,""{search}"") or contains(IMAGE_ID,""{search}"") or contains(LONGDESC_ID,""{search}"") or contains(VENDORINS_ID,""{search}"") or contains(WAREHOUSEINS_ID,""{search}"") or contains(MASTER_ITEM_CODE,""{search}"") or contains(CUSTOM_SWITCHES,""{search}"") or contains(IMPRINT_TEMPLATE_ID,""{search}"") or contains(SHIP_TO_CONTACT_ID,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby: $"{args.OrderBy}", top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null);
                lineItems = result.Value.AsODataEnumerable();
                count = result.Count;
            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load LineItems" });
            }
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddLineItem>("Add LineItem", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem> args)
        {
            await DialogService.OpenAsync<EditLineItem>("Edit LineItem", new Dictionary<string, object> { {"fldRecordID", args.Data.fldRecordID} });
            await grid0.Reload();
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem lineItem)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await Throttle_Core_BillingService.DeleteLineItem(fldRecordId:lineItem.fldRecordID);

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
                    Detail = $"Unable to delete LineItem"
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Throttle_Core_BillingService.ExportLineItemsToCSV(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "LineItems");
            }

            if (args == null || args.Value == "xlsx")
            {
                await Throttle_Core_BillingService.ExportLineItemsToExcel(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "LineItems");
            }
        }
    }
}