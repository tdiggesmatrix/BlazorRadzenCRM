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
    public partial class Products
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

        protected IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product> products;

        protected RadzenDataGrid<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product> grid0;
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
                var result = await Throttle_Core_BillingService.GetProducts(filter: $@"(contains(PRODUCT_CODE,""{search}"") or contains(PRODUCT_DESC_1,""{search}"") or contains(PRODUCT_DESC_2,""{search}"") or contains(SPEC_REF,""{search}"") or contains(CUSTOMER_CODE,""{search}"") or contains(SELL_UNIT_OF_MEASURE,""{search}"") or contains(BUY_UNIT_OF_MEASURE,""{search}"") or contains(CUSTOMER_ITEM_NUMBER,""{search}"") or contains(SUPPLIER_ITEM_NUMBER,""{search}"") or contains(PACK_UNIT_OF_MEASURE,""{search}"") or contains(PER_UNIT_OF_MEASURE,""{search}"") or contains(PRODUCT_CATEGORY,""{search}"") or contains(INV_UNIT_OF_MEASURE,""{search}"") or contains(SIZE_CODE,""{search}"") or contains(ALT_SALES_TAX,""{search}"") or contains(VENDOR_1,""{search}"") or contains(VENDOR_2,""{search}"") or contains(VENDOR_3,""{search}"") or contains(SWITCHES,""{search}"") or contains(TAX_EXEMPT,""{search}"") or contains(GROUP,""{search}"") or contains(MANUFACTURE_ID,""{search}"") or contains(IMAGE_ID,""{search}"") or contains(LONGDESC_ID,""{search}"") or contains(VENDORINS_ID,""{search}"") or contains(WAREHOUSEINS_ID,""{search}"") or contains(ORDERINGINS_ID,""{search}"") or contains(PAPER_STOCK_PRODUCT_CODE,""{search}"") or contains(IMPRINT_TEMPLATE_ID,""{search}"") or contains(REBATE_CODE,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby: $"{args.OrderBy}", top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null);
                products = result.Value.AsODataEnumerable();
                count = result.Count;
            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load Products" });
            }
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddProduct>("Add Product", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product> args)
        {
            await DialogService.OpenAsync<EditProduct>("Edit Product", new Dictionary<string, object> { {"fldRecordID", args.Data.fldRecordID} });
            await grid0.Reload();
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product product)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await Throttle_Core_BillingService.DeleteProduct(fldRecordId:product.fldRecordID);

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
                    Detail = $"Unable to delete Product"
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Throttle_Core_BillingService.ExportProductsToCSV(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "Products");
            }

            if (args == null || args.Value == "xlsx")
            {
                await Throttle_Core_BillingService.ExportProductsToExcel(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "Products");
            }
        }
    }
}