using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using ThrottleCoreCRM.Server.Data;

namespace ThrottleCoreCRM.Server.Controllers
{
    public partial class ExportThrottle_Core_BillingController : ExportController
    {
        private readonly Throttle_Core_BillingContext context;
        private readonly Throttle_Core_BillingService service;

        public ExportThrottle_Core_BillingController(Throttle_Core_BillingContext context, Throttle_Core_BillingService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/Throttle_Core_Billing/bulkbillings/csv")]
        [HttpGet("/export/Throttle_Core_Billing/bulkbillings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBulkBillingsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBulkBillings(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/bulkbillings/excel")]
        [HttpGet("/export/Throttle_Core_Billing/bulkbillings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBulkBillingsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBulkBillings(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/currentstores/csv")]
        [HttpGet("/export/Throttle_Core_Billing/currentstores/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCurrentStoresToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCurrentStores(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/currentstores/excel")]
        [HttpGet("/export/Throttle_Core_Billing/currentstores/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCurrentStoresToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCurrentStores(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/customerbillings/csv")]
        [HttpGet("/export/Throttle_Core_Billing/customerbillings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCustomerBillingsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCustomerBillings(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/customerbillings/excel")]
        [HttpGet("/export/Throttle_Core_Billing/customerbillings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCustomerBillingsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCustomerBillings(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/customershippings/csv")]
        [HttpGet("/export/Throttle_Core_Billing/customershippings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCustomerShippingsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCustomerShippings(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/customershippings/excel")]
        [HttpGet("/export/Throttle_Core_Billing/customershippings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCustomerShippingsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCustomerShippings(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/jobs/csv")]
        [HttpGet("/export/Throttle_Core_Billing/jobs/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportJobsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetJobs(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/jobs/excel")]
        [HttpGet("/export/Throttle_Core_Billing/jobs/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportJobsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetJobs(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/lineitems/csv")]
        [HttpGet("/export/Throttle_Core_Billing/lineitems/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLineItemsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLineItems(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/lineitems/excel")]
        [HttpGet("/export/Throttle_Core_Billing/lineitems/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLineItemsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLineItems(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/products/csv")]
        [HttpGet("/export/Throttle_Core_Billing/products/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProductsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProducts(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/products/excel")]
        [HttpGet("/export/Throttle_Core_Billing/products/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProductsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProducts(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/productcategories/csv")]
        [HttpGet("/export/Throttle_Core_Billing/productcategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProductCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProductCategories(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/productcategories/excel")]
        [HttpGet("/export/Throttle_Core_Billing/productcategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProductCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProductCategories(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/reminderssettingsadmins/csv")]
        [HttpGet("/export/Throttle_Core_Billing/reminderssettingsadmins/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRemindersSettingsAdminsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRemindersSettingsAdmins(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/reminderssettingsadmins/excel")]
        [HttpGet("/export/Throttle_Core_Billing/reminderssettingsadmins/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRemindersSettingsAdminsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRemindersSettingsAdmins(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/settingsconfigurations/csv")]
        [HttpGet("/export/Throttle_Core_Billing/settingsconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSettingsConfigurationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSettingsConfigurations(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/settingsconfigurations/excel")]
        [HttpGet("/export/Throttle_Core_Billing/settingsconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSettingsConfigurationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSettingsConfigurations(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/settingscontacts/csv")]
        [HttpGet("/export/Throttle_Core_Billing/settingscontacts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSettingsContactsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSettingsContacts(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/settingscontacts/excel")]
        [HttpGet("/export/Throttle_Core_Billing/settingscontacts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSettingsContactsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSettingsContacts(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/tblcrossreferences/csv")]
        [HttpGet("/export/Throttle_Core_Billing/tblcrossreferences/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCrossReferencesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblCrossReferences(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Billing/tblcrossreferences/excel")]
        [HttpGet("/export/Throttle_Core_Billing/tblcrossreferences/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblCrossReferencesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblCrossReferences(), Request.Query, false), fileName);
        }
    }
}
