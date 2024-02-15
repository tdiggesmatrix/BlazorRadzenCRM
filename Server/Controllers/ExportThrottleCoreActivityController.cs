using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using ThrottleCoreCRM.Server.Data;

namespace ThrottleCoreCRM.Server.Controllers
{
    public partial class ExportThrottle_Core_ActivityController : ExportController
    {
        private readonly Throttle_Core_ActivityContext context;
        private readonly Throttle_Core_ActivityService service;

        public ExportThrottle_Core_ActivityController(Throttle_Core_ActivityContext context, Throttle_Core_ActivityService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsfileactivities/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsfileactivities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataDmSFileActivitiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblDataDmSFileActivities(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsfileactivities/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsfileactivities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataDmSFileActivitiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblDataDmSFileActivities(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsfilearchiveactivities/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsfilearchiveactivities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataDmSFileArchiveActivitiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblDataDmSFileArchiveActivities(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsfilearchiveactivities/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsfilearchiveactivities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataDmSFileArchiveActivitiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblDataDmSFileArchiveActivities(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsfilearchiveservers/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsfilearchiveservers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataDmSFileArchiveServersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblDataDmSFileArchiveServers(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsfilearchiveservers/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsfilearchiveservers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataDmSFileArchiveServersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblDataDmSFileArchiveServers(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsftpactivities/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsftpactivities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataDmSFtPActivitiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblDataDmSFtPActivities(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsftpactivities/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsftpactivities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataDmSFtPActivitiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblDataDmSFtPActivities(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsproviders/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsproviders/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataDmSProvidersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblDataDmSProviders(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsproviders/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatadmsproviders/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataDmSProvidersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblDataDmSProviders(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperacknowledgementtypes/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperacknowledgementtypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataHelperAcknowledgementTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblDataHelperAcknowledgementTypes(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperacknowledgementtypes/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperacknowledgementtypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataHelperAcknowledgementTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblDataHelperAcknowledgementTypes(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperfiletypes/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperfiletypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataHelperFileTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblDataHelperFileTypes(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperfiletypes/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperfiletypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataHelperFileTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblDataHelperFileTypes(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperintegrations/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperintegrations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataHelperIntegrationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblDataHelperIntegrations(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperintegrations/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperintegrations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataHelperIntegrationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblDataHelperIntegrations(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperpostypes/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperpostypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataHelperPosTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblDataHelperPosTypes(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperpostypes/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperpostypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataHelperPosTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblDataHelperPosTypes(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperproducts/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperproducts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataHelperProductsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblDataHelperProducts(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperproducts/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tbldatahelperproducts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataHelperProductsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblDataHelperProducts(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldataimportstores/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tbldataimportstores/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataImportStoresToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblDataImportStores(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldataimportstores/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tbldataimportstores/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataImportStoresToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblDataImportStores(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldataimportverifications/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tbldataimportverifications/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataImportVerificationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblDataImportVerifications(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tbldataimportverifications/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tbldataimportverifications/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDataImportVerificationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblDataImportVerifications(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessageactivities/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessageactivities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageActivitiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblMessageActivities(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessageactivities/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessageactivities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageActivitiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblMessageActivities(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessagecommdates/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessagecommdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageCommDatesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblMessageCommDates(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessagecommdates/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessagecommdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageCommDatesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblMessageCommDates(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessagedirections/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessagedirections/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageDirectionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblMessageDirections(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessagedirections/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessagedirections/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageDirectionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblMessageDirections(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessageerrorcodes/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessageerrorcodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageErrorCodesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblMessageErrorCodes(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessageerrorcodes/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessageerrorcodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageErrorCodesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblMessageErrorCodes(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessagegroupingterms/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessagegroupingterms/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageGroupingTermsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblMessageGroupingTerms(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessagegroupingterms/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessagegroupingterms/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageGroupingTermsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblMessageGroupingTerms(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessagegroupingtypes/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessagegroupingtypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageGroupingTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblMessageGroupingTypes(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessagegroupingtypes/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessagegroupingtypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageGroupingTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblMessageGroupingTypes(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessagemissedcalls/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessagemissedcalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageMissedCallsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblMessageMissedCalls(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessagemissedcalls/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessagemissedcalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageMissedCallsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblMessageMissedCalls(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessagenotifications/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessagenotifications/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageNotificationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblMessageNotifications(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessagenotifications/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessagenotifications/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageNotificationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblMessageNotifications(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessagephonenumbers/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessagephonenumbers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessagePhoneNumbersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblMessagePhoneNumbers(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessagephonenumbers/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessagephonenumbers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessagePhoneNumbersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblMessagePhoneNumbers(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessagesettings/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessagesettings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageSettingsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblMessageSettings(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessagesettings/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessagesettings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageSettingsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblMessageSettings(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessageusages/csv")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessageusages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageUsagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblMessageUsages(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/tblmessageusages/excel")]
        [HttpGet("/export/Throttle_Core_Activity/tblmessageusages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblMessageUsagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblMessageUsages(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/userdetails/csv")]
        [HttpGet("/export/Throttle_Core_Activity/userdetails/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportUserdetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetUserdetails(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_Activity/userdetails/excel")]
        [HttpGet("/export/Throttle_Core_Activity/userdetails/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportUserdetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetUserdetails(), Request.Query, false), fileName);
        }
    }
}
