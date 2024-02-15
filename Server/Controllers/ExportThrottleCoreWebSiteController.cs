using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using ThrottleCoreCRM.Server.Data;

namespace ThrottleCoreCRM.Server.Controllers
{
    public partial class ExportThrottle_Core_WebSiteController : ExportController
    {
        private readonly Throttle_Core_WebSiteContext context;
        private readonly Throttle_Core_WebSiteService service;

        public ExportThrottle_Core_WebSiteController(Throttle_Core_WebSiteContext context, Throttle_Core_WebSiteService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/Throttle_Core_WebSite/contacts/csv")]
        [HttpGet("/export/Throttle_Core_WebSite/contacts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportContactsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetContacts(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/contacts/excel")]
        [HttpGet("/export/Throttle_Core_WebSite/contacts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportContactsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetContacts(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/departments/csv")]
        [HttpGet("/export/Throttle_Core_WebSite/departments/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDepartmentsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDepartments(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/departments/excel")]
        [HttpGet("/export/Throttle_Core_WebSite/departments/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDepartmentsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDepartments(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/employees/csv")]
        [HttpGet("/export/Throttle_Core_WebSite/employees/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEmployeesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetEmployees(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/employees/excel")]
        [HttpGet("/export/Throttle_Core_WebSite/employees/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEmployeesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetEmployees(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/opportunities/csv")]
        [HttpGet("/export/Throttle_Core_WebSite/opportunities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOpportunitiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetOpportunities(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/opportunities/excel")]
        [HttpGet("/export/Throttle_Core_WebSite/opportunities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOpportunitiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetOpportunities(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/opportunitystatuses/csv")]
        [HttpGet("/export/Throttle_Core_WebSite/opportunitystatuses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOpportunityStatusesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetOpportunityStatuses(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/opportunitystatuses/excel")]
        [HttpGet("/export/Throttle_Core_WebSite/opportunitystatuses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOpportunityStatusesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetOpportunityStatuses(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/tasks/csv")]
        [HttpGet("/export/Throttle_Core_WebSite/tasks/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTasksToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTasks(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/tasks/excel")]
        [HttpGet("/export/Throttle_Core_WebSite/tasks/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTasksToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTasks(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/taskstatuses/csv")]
        [HttpGet("/export/Throttle_Core_WebSite/taskstatuses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTaskStatusesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTaskStatuses(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/taskstatuses/excel")]
        [HttpGet("/export/Throttle_Core_WebSite/taskstatuses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTaskStatusesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTaskStatuses(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/tasktypes/csv")]
        [HttpGet("/export/Throttle_Core_WebSite/tasktypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTaskTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTaskTypes(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/tasktypes/excel")]
        [HttpGet("/export/Throttle_Core_WebSite/tasktypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTaskTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTaskTypes(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/tbldatabases/csv")]
        [HttpGet("/export/Throttle_Core_WebSite/tbldatabases/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDatabasesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblDatabases(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/tbldatabases/excel")]
        [HttpGet("/export/Throttle_Core_WebSite/tbldatabases/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDatabasesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblDatabases(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/tblwebsiteerrordescriptions/csv")]
        [HttpGet("/export/Throttle_Core_WebSite/tblwebsiteerrordescriptions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblWebSiteErrorDescriptionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblWebSiteErrorDescriptions(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/tblwebsiteerrordescriptions/excel")]
        [HttpGet("/export/Throttle_Core_WebSite/tblwebsiteerrordescriptions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblWebSiteErrorDescriptionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblWebSiteErrorDescriptions(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/tblwebsitelanguages/csv")]
        [HttpGet("/export/Throttle_Core_WebSite/tblwebsitelanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblWebSiteLanguagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblWebSiteLanguages(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/tblwebsitelanguages/excel")]
        [HttpGet("/export/Throttle_Core_WebSite/tblwebsitelanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblWebSiteLanguagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblWebSiteLanguages(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/tblwebsitemenus/csv")]
        [HttpGet("/export/Throttle_Core_WebSite/tblwebsitemenus/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblWebSiteMenusToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblWebSiteMenus(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/tblwebsitemenus/excel")]
        [HttpGet("/export/Throttle_Core_WebSite/tblwebsitemenus/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblWebSiteMenusToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblWebSiteMenus(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/tblwebsitesecuritygroups/csv")]
        [HttpGet("/export/Throttle_Core_WebSite/tblwebsitesecuritygroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblWebSiteSecurityGroupsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblWebSiteSecurityGroups(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/tblwebsitesecuritygroups/excel")]
        [HttpGet("/export/Throttle_Core_WebSite/tblwebsitesecuritygroups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblWebSiteSecurityGroupsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblWebSiteSecurityGroups(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/tblwebsitesecuritysettings/csv")]
        [HttpGet("/export/Throttle_Core_WebSite/tblwebsitesecuritysettings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblWebSiteSecuritySettingsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblWebSiteSecuritySettings(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/tblwebsitesecuritysettings/excel")]
        [HttpGet("/export/Throttle_Core_WebSite/tblwebsitesecuritysettings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblWebSiteSecuritySettingsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblWebSiteSecuritySettings(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/tblwebsiteusers/csv")]
        [HttpGet("/export/Throttle_Core_WebSite/tblwebsiteusers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblWebSiteUsersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblWebSiteUsers(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Throttle_Core_WebSite/tblwebsiteusers/excel")]
        [HttpGet("/export/Throttle_Core_WebSite/tblwebsiteusers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblWebSiteUsersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblWebSiteUsers(), Request.Query, false), fileName);
        }
    }
}
