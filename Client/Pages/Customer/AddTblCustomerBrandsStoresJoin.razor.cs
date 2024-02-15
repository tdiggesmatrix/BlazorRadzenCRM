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
    public partial class AddTblCustomerBrandsStoresJoin
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

        protected override async Task OnInitializedAsync()
        {
            tblCustomerBrandsStoresJoin = new ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin();
        }
        protected bool errorVisible;
        protected ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin tblCustomerBrandsStoresJoin;

        protected async Task FormSubmit()
        {
            try
            {
                var result = await Throttle_Core_CustomerService.CreateTblCustomerBrandsStoresJoin(tblCustomerBrandsStoresJoin);
                DialogService.Close(tblCustomerBrandsStoresJoin);
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
    }
}