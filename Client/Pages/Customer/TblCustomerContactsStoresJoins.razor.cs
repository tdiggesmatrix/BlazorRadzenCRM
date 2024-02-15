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
    public partial class TblCustomerContactsStoresJoins
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

        protected IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin> tblCustomerContactsStoresJoins;

        protected RadzenDataGrid<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin> grid0;
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
                var result = await Throttle_Core_CustomerService.GetTblCustomerContactsStoresJoins(filter: $"{args.Filter}", orderby: $"{args.OrderBy}", top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null);
                tblCustomerContactsStoresJoins = result.Value.AsODataEnumerable();
                count = result.Count;
            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load TblCustomerContactsStoresJoins" });
            }
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddTblCustomerContactsStoresJoin>("Add TblCustomerContactsStoresJoin", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin> args)
        {
            await DialogService.OpenAsync<EditTblCustomerContactsStoresJoin>("Edit TblCustomerContactsStoresJoin", new Dictionary<string, object> { {"fldRecordID", args.Data.fldRecordID} });
            await grid0.Reload();
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin tblCustomerContactsStoresJoin)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await Throttle_Core_CustomerService.DeleteTblCustomerContactsStoresJoin(fldRecordId:tblCustomerContactsStoresJoin.fldRecordID);

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
                    Detail = $"Unable to delete TblCustomerContactsStoresJoin"
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Throttle_Core_CustomerService.ExportTblCustomerContactsStoresJoinsToCSV(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "TblCustomerContactsStoresJoins");
            }

            if (args == null || args.Value == "xlsx")
            {
                await Throttle_Core_CustomerService.ExportTblCustomerContactsStoresJoinsToExcel(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "TblCustomerContactsStoresJoins");
            }
        }
    }
}