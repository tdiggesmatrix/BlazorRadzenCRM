using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using ThrottleCoreCRM.Server.Data;

namespace ThrottleCoreCRM.Server.Controllers
{
    public partial class ExportThrottle_Core_SummaryController : ExportController
    {
        private readonly Throttle_Core_SummaryContext context;
        private readonly Throttle_Core_SummaryService service;

        public ExportThrottle_Core_SummaryController(Throttle_Core_SummaryContext context, Throttle_Core_SummaryService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/Throttle_Core_Summary/tbldailytotals/csv")]
        [HttpGet("/export/Throttle_Core_Summary/tbldailytotals/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDailyTotalsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblDailyTotals(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tbldailytotals/excel")]
        [HttpGet("/export/Throttle_Core_Summary/tbldailytotals/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDailyTotalsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblDailyTotals(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tbldailytotalslabors/csv")]
        [HttpGet("/export/Throttle_Core_Summary/tbldailytotalslabors/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDailyTotalsLaborsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblDailyTotalsLabors(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tbldailytotalslabors/excel")]
        [HttpGet("/export/Throttle_Core_Summary/tbldailytotalslabors/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDailyTotalsLaborsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblDailyTotalsLabors(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tbldailytotalsoperators/csv")]
        [HttpGet("/export/Throttle_Core_Summary/tbldailytotalsoperators/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDailyTotalsOperatorsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblDailyTotalsOperators(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tbldailytotalsoperators/excel")]
        [HttpGet("/export/Throttle_Core_Summary/tbldailytotalsoperators/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDailyTotalsOperatorsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblDailyTotalsOperators(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tbldailytotalsparts/csv")]
        [HttpGet("/export/Throttle_Core_Summary/tbldailytotalsparts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDailyTotalsPartsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblDailyTotalsParts(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tbldailytotalsparts/excel")]
        [HttpGet("/export/Throttle_Core_Summary/tbldailytotalsparts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDailyTotalsPartsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblDailyTotalsParts(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tblhelpercoupons/csv")]
        [HttpGet("/export/Throttle_Core_Summary/tblhelpercoupons/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblHelperCouponsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblHelperCoupons(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tblhelpercoupons/excel")]
        [HttpGet("/export/Throttle_Core_Summary/tblhelpercoupons/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblHelperCouponsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblHelperCoupons(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tblhelperemailstatuscodes/csv")]
        [HttpGet("/export/Throttle_Core_Summary/tblhelperemailstatuscodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblHelperEmailStatusCodesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblHelperEmailStatusCodes(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tblhelperemailstatuscodes/excel")]
        [HttpGet("/export/Throttle_Core_Summary/tblhelperemailstatuscodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblHelperEmailStatusCodesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblHelperEmailStatusCodes(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tblhelperlabors/csv")]
        [HttpGet("/export/Throttle_Core_Summary/tblhelperlabors/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblHelperLaborsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblHelperLabors(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tblhelperlabors/excel")]
        [HttpGet("/export/Throttle_Core_Summary/tblhelperlabors/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblHelperLaborsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblHelperLabors(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tblhelpermailaddresserrors/csv")]
        [HttpGet("/export/Throttle_Core_Summary/tblhelpermailaddresserrors/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblHelperMailAddressErrorsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblHelperMailAddressErrors(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tblhelpermailaddresserrors/excel")]
        [HttpGet("/export/Throttle_Core_Summary/tblhelpermailaddresserrors/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblHelperMailAddressErrorsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblHelperMailAddressErrors(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tblhelperparts/csv")]
        [HttpGet("/export/Throttle_Core_Summary/tblhelperparts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblHelperPartsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblHelperParts(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tblhelperparts/excel")]
        [HttpGet("/export/Throttle_Core_Summary/tblhelperparts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblHelperPartsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblHelperParts(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tblsummarycampaigns/csv")]
        [HttpGet("/export/Throttle_Core_Summary/tblsummarycampaigns/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblSummaryCampaignsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblSummaryCampaigns(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tblsummarycampaigns/excel")]
        [HttpGet("/export/Throttle_Core_Summary/tblsummarycampaigns/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblSummaryCampaignsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblSummaryCampaigns(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tblsummarycustomers/csv")]
        [HttpGet("/export/Throttle_Core_Summary/tblsummarycustomers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblSummaryCustomersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblSummaryCustomers(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tblsummarycustomers/excel")]
        [HttpGet("/export/Throttle_Core_Summary/tblsummarycustomers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblSummaryCustomersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblSummaryCustomers(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tblsummarysales/csv")]
        [HttpGet("/export/Throttle_Core_Summary/tblsummarysales/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblSummarySalesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblSummarySales(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tblsummarysales/excel")]
        [HttpGet("/export/Throttle_Core_Summary/tblsummarysales/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblSummarySalesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblSummarySales(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tblsummaryvehicles/csv")]
        [HttpGet("/export/Throttle_Core_Summary/tblsummaryvehicles/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblSummaryVehiclesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblSummaryVehicles(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Summary/tblsummaryvehicles/excel")]
        [HttpGet("/export/Throttle_Core_Summary/tblsummaryvehicles/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblSummaryVehiclesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblSummaryVehicles(), Request.Query, false), fileName);
        }
    }
}
