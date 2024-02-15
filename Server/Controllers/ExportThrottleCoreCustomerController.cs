using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using ThrottleCoreCRM.Server.Data;

namespace ThrottleCoreCRM.Server.Controllers
{
    public partial class ExportThrottle_Core_CustomerController : ExportController
    {
        private readonly Throttle_Core_CustomerContext context;
        private readonly Throttle_Core_CustomerService service;

        public ExportThrottle_Core_CustomerController(Throttle_Core_CustomerContext context, Throttle_Core_CustomerService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomers/csv")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblCustomers(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomers/excel")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblCustomers(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomerbrands/csv")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomerbrands/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerBrandsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblCustomerBrands(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomerbrands/excel")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomerbrands/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerBrandsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblCustomerBrands(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomerbrandsstoresjoins/csv")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomerbrandsstoresjoins/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerBrandsStoresJoinsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblCustomerBrandsStoresJoins(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomerbrandsstoresjoins/excel")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomerbrandsstoresjoins/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerBrandsStoresJoinsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblCustomerBrandsStoresJoins(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomercontacts/csv")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomercontacts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerContactsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblCustomerContacts(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomercontacts/excel")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomercontacts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerContactsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblCustomerContacts(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomercontactsstoresjoins/csv")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomercontactsstoresjoins/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerContactsStoresJoinsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblCustomerContactsStoresJoins(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomercontactsstoresjoins/excel")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomercontactsstoresjoins/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerContactsStoresJoinsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblCustomerContactsStoresJoins(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomerfranchises/csv")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomerfranchises/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerFranchisesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblCustomerFranchises(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomerfranchises/excel")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomerfranchises/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerFranchisesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblCustomerFranchises(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomerfranchisesstoresjoins/csv")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomerfranchisesstoresjoins/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerFranchisesStoresJoinsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblCustomerFranchisesStoresJoins(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomerfranchisesstoresjoins/excel")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomerfranchisesstoresjoins/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerFranchisesStoresJoinsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblCustomerFranchisesStoresJoins(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomergroups/csv")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomergroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerGroupsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblCustomerGroups(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomergroups/excel")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomergroups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerGroupsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblCustomerGroups(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomergroupsstoresjoins/csv")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomergroupsstoresjoins/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerGroupsStoresJoinsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblCustomerGroupsStoresJoins(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomergroupsstoresjoins/excel")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomergroupsstoresjoins/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerGroupsStoresJoinsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblCustomerGroupsStoresJoins(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomerindustries/csv")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomerindustries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerIndustriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblCustomerIndustries(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomerindustries/excel")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomerindustries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerIndustriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblCustomerIndustries(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomerindustrystoresjoins/csv")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomerindustrystoresjoins/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerIndustryStoresJoinsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblCustomerIndustryStoresJoins(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomerindustrystoresjoins/excel")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomerindustrystoresjoins/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerIndustryStoresJoinsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblCustomerIndustryStoresJoins(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomerproductandservices/csv")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomerproductandservices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerProductandServicesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblCustomerProductandServices(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomerproductandservices/excel")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomerproductandservices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerProductandServicesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblCustomerProductandServices(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomerproductandservicesstoresjoins/csv")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomerproductandservicesstoresjoins/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerProductandServicesStoresJoinsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblCustomerProductandServicesStoresJoins(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomerproductandservicesstoresjoins/excel")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomerproductandservicesstoresjoins/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerProductandServicesStoresJoinsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblCustomerProductandServicesStoresJoins(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomerstores/csv")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomerstores/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerStoresToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblCustomerStores(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Customer/tblcustomerstores/excel")]
        [HttpGet("/export/Throttle_Core_Customer/tblcustomerstores/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCustomerStoresToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblCustomerStores(), Request.Query, false), fileName);
        }
    }
}
