using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace ThrottleCoreCRM.Client.Pages.Activity
{
    public partial class EditTblDataDmSFileArchiveServer
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
        public Throttle_Core_ActivityService Throttle_Core_ActivityService { get; set; }

        [Parameter]
        public int fldRecordID { get; set; }

        protected override async Task OnInitializedAsync()
        {
            tblDataDmSFileArchiveServer = await Throttle_Core_ActivityService.GetTblDataDmSFileArchiveServerByFldRecordId(fldRecordId:fldRecordID);
        }
        protected bool errorVisible;
        protected ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer tblDataDmSFileArchiveServer;

        protected async Task FormSubmit()
        {
            try
            {
                var result = await Throttle_Core_ActivityService.UpdateTblDataDmSFileArchiveServer(fldRecordId:fldRecordID, tblDataDmSFileArchiveServer);
                if (result.StatusCode == System.Net.HttpStatusCode.PreconditionFailed)
                {
                     hasChanges = true;
                     canEdit = false;
                     return;
                }
                DialogService.Close(tblDataDmSFileArchiveServer);
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

            tblDataDmSFileArchiveServer = await Throttle_Core_ActivityService.GetTblDataDmSFileArchiveServerByFldRecordId(fldRecordId:fldRecordID);
        }
    }
}