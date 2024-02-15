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
    public partial class EditTblDailyTotalsPart
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

        [Parameter]
        public long fldRecordID { get; set; }

        protected override async Task OnInitializedAsync()
        {
            tblDailyTotalsPart = await Throttle_Core_SummaryService.GetTblDailyTotalsPartByFldRecordId(fldRecordId:fldRecordID);
        }
        protected bool errorVisible;
        protected ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart tblDailyTotalsPart;

        protected async Task FormSubmit()
        {
            try
            {
                var result = await Throttle_Core_SummaryService.UpdateTblDailyTotalsPart(fldRecordId:fldRecordID, tblDailyTotalsPart);
                if (result.StatusCode == System.Net.HttpStatusCode.PreconditionFailed)
                {
                     hasChanges = true;
                     canEdit = false;
                     return;
                }
                DialogService.Close(tblDailyTotalsPart);
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

            tblDailyTotalsPart = await Throttle_Core_SummaryService.GetTblDailyTotalsPartByFldRecordId(fldRecordId:fldRecordID);
        }
    }
}