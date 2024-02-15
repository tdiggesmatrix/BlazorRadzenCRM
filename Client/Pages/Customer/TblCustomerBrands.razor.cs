using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace ThrottleCoreCRM.Client.Pages.Customer
{
    public partial class TblCustomerBrands
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
        public Throttle_Core_CustomerService Throttle_Core_CustomerService { get; set; }

        protected IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand> tblCustomerBrands;

        protected RadzenDataGrid<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand> grid0;
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
                var result = await Throttle_Core_CustomerService.GetTblCustomerBrands(filter: $@"(contains(fldBrandName,""{search}"") or contains(fldAddress1,""{search}"") or contains(fldAddress2,""{search}"") or contains(fldAddress3,""{search}"") or contains(fldCity,""{search}"") or contains(fldState,""{search}"") or contains(fldZip,""{search}"") or contains(fldCountry,""{search}"") or contains(fldPhone,""{search}"") or contains(fldAlternatePhone,""{search}"") or contains(fldFax,""{search}"") or contains(fldWebsiteUrl,""{search}"") or contains(fldGeneralEmailAddress,""{search}"") or contains(fldCompanyGooglePlacesID,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby: $"{args.OrderBy}", top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null);
                tblCustomerBrands = result.Value.AsODataEnumerable();
                count = result.Count;
            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load TblCustomerBrands" });
            }
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddTblCustomerBrand>("Add TblCustomerBrand", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand> args)
        {
            await DialogService.OpenAsync<EditTblCustomerBrand>("Edit TblCustomerBrand", new Dictionary<string, object> { {"fldRecordID", args.Data.fldRecordID} });
            await grid0.Reload();
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand tblCustomerBrand)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await Throttle_Core_CustomerService.DeleteTblCustomerBrand(fldRecordId:tblCustomerBrand.fldRecordID);

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
                    Detail = $"Unable to delete TblCustomerBrand"
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Throttle_Core_CustomerService.ExportTblCustomerBrandsToCSV(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "TblCustomerBrands");
            }

            if (args == null || args.Value == "xlsx")
            {
                await Throttle_Core_CustomerService.ExportTblCustomerBrandsToExcel(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "TblCustomerBrands");
            }
        }
    }
}