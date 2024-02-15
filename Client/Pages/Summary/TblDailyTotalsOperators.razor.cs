using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace ThrottleCoreCRM.Client.Pages.Summary
{
    public partial class TblDailyTotalsOperators
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
        public Throttle_Core_SummaryService Throttle_Core_SummaryService { get; set; }

        protected IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator> tblDailyTotalsOperators;

        protected RadzenDataGrid<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator> grid0;
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
                var result = await Throttle_Core_SummaryService.GetTblDailyTotalsOperators(filter: $"{args.Filter}", orderby: $"{args.OrderBy}", top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null);
                tblDailyTotalsOperators = result.Value.AsODataEnumerable();
                count = result.Count;
            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load TblDailyTotalsOperators" });
            }
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddTblDailyTotalsOperator>("Add TblDailyTotalsOperator", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator> args)
        {
            await DialogService.OpenAsync<EditTblDailyTotalsOperator>("Edit TblDailyTotalsOperator", new Dictionary<string, object> { {"fldRecordID", args.Data.fldRecordID} });
            await grid0.Reload();
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator tblDailyTotalsOperator)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await Throttle_Core_SummaryService.DeleteTblDailyTotalsOperator(fldRecordId:tblDailyTotalsOperator.fldRecordID);

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
                    Detail = $"Unable to delete TblDailyTotalsOperator"
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Throttle_Core_SummaryService.ExportTblDailyTotalsOperatorsToCSV(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "TblDailyTotalsOperators");
            }

            if (args == null || args.Value == "xlsx")
            {
                await Throttle_Core_SummaryService.ExportTblDailyTotalsOperatorsToExcel(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "TblDailyTotalsOperators");
            }
        }
    }
}