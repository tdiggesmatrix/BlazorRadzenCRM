
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Radzen;

namespace ThrottleCoreCRM.Client
{
    public partial class Throttle_Core_ActivityService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;

        public Throttle_Core_ActivityService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/Throttle_Core_Activity/");
        }


        public async System.Threading.Tasks.Task ExportTblDataDmSFileActivitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsfileactivities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsfileactivities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblDataDmSFileActivitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsfileactivities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsfileactivities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblDataDmSFileActivities(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity>> GetTblDataDmSFileActivities(Query query)
        {
            return await GetTblDataDmSFileActivities(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity>> GetTblDataDmSFileActivities(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFileActivities");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataDmSFileActivities(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity>>(response);
        }

        partial void OnCreateTblDataDmSFileActivity(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity> CreateTblDataDmSFileActivity(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity tblDataDmSfileActivity = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFileActivities");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataDmSfileActivity), Encoding.UTF8, "application/json");

            OnCreateTblDataDmSFileActivity(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity>(response);
        }

        partial void OnDeleteTblDataDmSFileActivity(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblDataDmSFileActivity(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFileActivities({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblDataDmSFileActivity(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblDataDmSFileActivityByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity> GetTblDataDmSFileActivityByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFileActivities({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataDmSFileActivityByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity>(response);
        }

        partial void OnUpdateTblDataDmSFileActivity(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblDataDmSFileActivity(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity tblDataDmSfileActivity = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFileActivities({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataDmSfileActivity), Encoding.UTF8, "application/json");

            OnUpdateTblDataDmSFileActivity(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblDataDmSFileArchiveActivitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsfilearchiveactivities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsfilearchiveactivities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblDataDmSFileArchiveActivitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsfilearchiveactivities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsfilearchiveactivities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblDataDmSFileArchiveActivities(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity>> GetTblDataDmSFileArchiveActivities(Query query)
        {
            return await GetTblDataDmSFileArchiveActivities(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity>> GetTblDataDmSFileArchiveActivities(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFileArchiveActivities");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataDmSFileArchiveActivities(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity>>(response);
        }

        partial void OnCreateTblDataDmSFileArchiveActivity(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity> CreateTblDataDmSFileArchiveActivity(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity tblDataDmSfileArchiveActivity = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFileArchiveActivities");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataDmSfileArchiveActivity), Encoding.UTF8, "application/json");

            OnCreateTblDataDmSFileArchiveActivity(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity>(response);
        }

        partial void OnDeleteTblDataDmSFileArchiveActivity(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblDataDmSFileArchiveActivity(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFileArchiveActivities({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblDataDmSFileArchiveActivity(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblDataDmSFileArchiveActivityByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity> GetTblDataDmSFileArchiveActivityByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFileArchiveActivities({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataDmSFileArchiveActivityByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity>(response);
        }

        partial void OnUpdateTblDataDmSFileArchiveActivity(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblDataDmSFileArchiveActivity(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity tblDataDmSfileArchiveActivity = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFileArchiveActivities({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataDmSfileArchiveActivity), Encoding.UTF8, "application/json");

            OnUpdateTblDataDmSFileArchiveActivity(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblDataDmSFileArchiveServersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsfilearchiveservers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsfilearchiveservers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblDataDmSFileArchiveServersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsfilearchiveservers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsfilearchiveservers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblDataDmSFileArchiveServers(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer>> GetTblDataDmSFileArchiveServers(Query query)
        {
            return await GetTblDataDmSFileArchiveServers(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer>> GetTblDataDmSFileArchiveServers(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFileArchiveServers");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataDmSFileArchiveServers(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer>>(response);
        }

        partial void OnCreateTblDataDmSFileArchiveServer(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer> CreateTblDataDmSFileArchiveServer(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer tblDataDmSfileArchiveServer = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFileArchiveServers");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataDmSfileArchiveServer), Encoding.UTF8, "application/json");

            OnCreateTblDataDmSFileArchiveServer(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer>(response);
        }

        partial void OnDeleteTblDataDmSFileArchiveServer(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblDataDmSFileArchiveServer(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFileArchiveServers({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblDataDmSFileArchiveServer(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblDataDmSFileArchiveServerByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer> GetTblDataDmSFileArchiveServerByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFileArchiveServers({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataDmSFileArchiveServerByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer>(response);
        }

        partial void OnUpdateTblDataDmSFileArchiveServer(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblDataDmSFileArchiveServer(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer tblDataDmSfileArchiveServer = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFileArchiveServers({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataDmSfileArchiveServer), Encoding.UTF8, "application/json");

            OnUpdateTblDataDmSFileArchiveServer(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblDataDmSFtPActivitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsftpactivities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsftpactivities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblDataDmSFtPActivitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsftpactivities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsftpactivities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblDataDmSFtPActivities(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity>> GetTblDataDmSFtPActivities(Query query)
        {
            return await GetTblDataDmSFtPActivities(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity>> GetTblDataDmSFtPActivities(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFtPActivities");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataDmSFtPActivities(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity>>(response);
        }

        partial void OnCreateTblDataDmSFtPActivity(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity> CreateTblDataDmSFtPActivity(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity tblDataDmSftPactivity = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFtPActivities");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataDmSftPactivity), Encoding.UTF8, "application/json");

            OnCreateTblDataDmSFtPActivity(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity>(response);
        }

        partial void OnDeleteTblDataDmSFtPActivity(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblDataDmSFtPActivity(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFtPActivities({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblDataDmSFtPActivity(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblDataDmSFtPActivityByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity> GetTblDataDmSFtPActivityByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFtPActivities({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataDmSFtPActivityByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity>(response);
        }

        partial void OnUpdateTblDataDmSFtPActivity(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblDataDmSFtPActivity(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity tblDataDmSftPactivity = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity))
        {
            var uri = new Uri(baseUri, $"TblDataDmSFtPActivities({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataDmSftPactivity), Encoding.UTF8, "application/json");

            OnUpdateTblDataDmSFtPActivity(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblDataDmSProvidersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblDataDmSProvidersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblDataDmSProviders(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider>> GetTblDataDmSProviders(Query query)
        {
            return await GetTblDataDmSProviders(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider>> GetTblDataDmSProviders(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblDataDmSProviders");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataDmSProviders(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider>>(response);
        }

        partial void OnCreateTblDataDmSProvider(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider> CreateTblDataDmSProvider(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider tblDataDmSprovider = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider))
        {
            var uri = new Uri(baseUri, $"TblDataDmSProviders");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataDmSprovider), Encoding.UTF8, "application/json");

            OnCreateTblDataDmSProvider(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider>(response);
        }

        partial void OnDeleteTblDataDmSProvider(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblDataDmSProvider(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataDmSProviders({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblDataDmSProvider(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblDataDmSProviderByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider> GetTblDataDmSProviderByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataDmSProviders({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataDmSProviderByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider>(response);
        }

        partial void OnUpdateTblDataDmSProvider(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblDataDmSProvider(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider tblDataDmSprovider = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider))
        {
            var uri = new Uri(baseUri, $"TblDataDmSProviders({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataDmSprovider), Encoding.UTF8, "application/json");

            OnUpdateTblDataDmSProvider(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblDataHelperAcknowledgementTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperacknowledgementtypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperacknowledgementtypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblDataHelperAcknowledgementTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperacknowledgementtypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperacknowledgementtypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblDataHelperAcknowledgementTypes(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType>> GetTblDataHelperAcknowledgementTypes(Query query)
        {
            return await GetTblDataHelperAcknowledgementTypes(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType>> GetTblDataHelperAcknowledgementTypes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblDataHelperAcknowledgementTypes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataHelperAcknowledgementTypes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType>>(response);
        }

        partial void OnCreateTblDataHelperAcknowledgementType(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType> CreateTblDataHelperAcknowledgementType(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType tblDataHelperAcknowledgementType = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType))
        {
            var uri = new Uri(baseUri, $"TblDataHelperAcknowledgementTypes");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataHelperAcknowledgementType), Encoding.UTF8, "application/json");

            OnCreateTblDataHelperAcknowledgementType(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType>(response);
        }

        partial void OnDeleteTblDataHelperAcknowledgementType(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblDataHelperAcknowledgementType(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataHelperAcknowledgementTypes({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblDataHelperAcknowledgementType(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblDataHelperAcknowledgementTypeByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType> GetTblDataHelperAcknowledgementTypeByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataHelperAcknowledgementTypes({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataHelperAcknowledgementTypeByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType>(response);
        }

        partial void OnUpdateTblDataHelperAcknowledgementType(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblDataHelperAcknowledgementType(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType tblDataHelperAcknowledgementType = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType))
        {
            var uri = new Uri(baseUri, $"TblDataHelperAcknowledgementTypes({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataHelperAcknowledgementType), Encoding.UTF8, "application/json");

            OnUpdateTblDataHelperAcknowledgementType(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblDataHelperFileTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperfiletypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperfiletypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblDataHelperFileTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperfiletypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperfiletypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblDataHelperFileTypes(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType>> GetTblDataHelperFileTypes(Query query)
        {
            return await GetTblDataHelperFileTypes(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType>> GetTblDataHelperFileTypes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblDataHelperFileTypes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataHelperFileTypes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType>>(response);
        }

        partial void OnCreateTblDataHelperFileType(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType> CreateTblDataHelperFileType(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType tblDataHelperFileType = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType))
        {
            var uri = new Uri(baseUri, $"TblDataHelperFileTypes");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataHelperFileType), Encoding.UTF8, "application/json");

            OnCreateTblDataHelperFileType(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType>(response);
        }

        partial void OnDeleteTblDataHelperFileType(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblDataHelperFileType(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataHelperFileTypes({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblDataHelperFileType(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblDataHelperFileTypeByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType> GetTblDataHelperFileTypeByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataHelperFileTypes({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataHelperFileTypeByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType>(response);
        }

        partial void OnUpdateTblDataHelperFileType(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblDataHelperFileType(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType tblDataHelperFileType = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType))
        {
            var uri = new Uri(baseUri, $"TblDataHelperFileTypes({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataHelperFileType), Encoding.UTF8, "application/json");

            OnUpdateTblDataHelperFileType(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblDataHelperIntegrationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperintegrations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperintegrations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblDataHelperIntegrationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperintegrations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperintegrations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblDataHelperIntegrations(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration>> GetTblDataHelperIntegrations(Query query)
        {
            return await GetTblDataHelperIntegrations(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration>> GetTblDataHelperIntegrations(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblDataHelperIntegrations");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataHelperIntegrations(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration>>(response);
        }

        partial void OnCreateTblDataHelperIntegration(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration> CreateTblDataHelperIntegration(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration tblDataHelperIntegration = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration))
        {
            var uri = new Uri(baseUri, $"TblDataHelperIntegrations");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataHelperIntegration), Encoding.UTF8, "application/json");

            OnCreateTblDataHelperIntegration(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration>(response);
        }

        partial void OnDeleteTblDataHelperIntegration(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblDataHelperIntegration(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataHelperIntegrations({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblDataHelperIntegration(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblDataHelperIntegrationByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration> GetTblDataHelperIntegrationByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataHelperIntegrations({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataHelperIntegrationByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration>(response);
        }

        partial void OnUpdateTblDataHelperIntegration(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblDataHelperIntegration(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration tblDataHelperIntegration = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration))
        {
            var uri = new Uri(baseUri, $"TblDataHelperIntegrations({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataHelperIntegration), Encoding.UTF8, "application/json");

            OnUpdateTblDataHelperIntegration(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblDataHelperPosTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperpostypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperpostypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblDataHelperPosTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperpostypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperpostypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblDataHelperPosTypes(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType>> GetTblDataHelperPosTypes(Query query)
        {
            return await GetTblDataHelperPosTypes(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType>> GetTblDataHelperPosTypes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblDataHelperPosTypes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataHelperPosTypes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType>>(response);
        }

        partial void OnCreateTblDataHelperPosType(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType> CreateTblDataHelperPosType(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType tblDataHelperPosType = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType))
        {
            var uri = new Uri(baseUri, $"TblDataHelperPosTypes");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataHelperPosType), Encoding.UTF8, "application/json");

            OnCreateTblDataHelperPosType(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType>(response);
        }

        partial void OnDeleteTblDataHelperPosType(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblDataHelperPosType(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataHelperPosTypes({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblDataHelperPosType(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblDataHelperPosTypeByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType> GetTblDataHelperPosTypeByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataHelperPosTypes({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataHelperPosTypeByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType>(response);
        }

        partial void OnUpdateTblDataHelperPosType(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblDataHelperPosType(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType tblDataHelperPosType = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType))
        {
            var uri = new Uri(baseUri, $"TblDataHelperPosTypes({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataHelperPosType), Encoding.UTF8, "application/json");

            OnUpdateTblDataHelperPosType(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblDataHelperProductsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperproducts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperproducts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblDataHelperProductsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperproducts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperproducts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblDataHelperProducts(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct>> GetTblDataHelperProducts(Query query)
        {
            return await GetTblDataHelperProducts(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct>> GetTblDataHelperProducts(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblDataHelperProducts");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataHelperProducts(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct>>(response);
        }

        partial void OnCreateTblDataHelperProduct(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct> CreateTblDataHelperProduct(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct tblDataHelperProduct = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct))
        {
            var uri = new Uri(baseUri, $"TblDataHelperProducts");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataHelperProduct), Encoding.UTF8, "application/json");

            OnCreateTblDataHelperProduct(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct>(response);
        }

        partial void OnDeleteTblDataHelperProduct(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblDataHelperProduct(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataHelperProducts({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblDataHelperProduct(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblDataHelperProductByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct> GetTblDataHelperProductByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataHelperProducts({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataHelperProductByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct>(response);
        }

        partial void OnUpdateTblDataHelperProduct(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblDataHelperProduct(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct tblDataHelperProduct = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct))
        {
            var uri = new Uri(baseUri, $"TblDataHelperProducts({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataHelperProduct), Encoding.UTF8, "application/json");

            OnUpdateTblDataHelperProduct(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblDataImportStoresToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldataimportstores/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldataimportstores/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblDataImportStoresToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldataimportstores/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldataimportstores/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblDataImportStores(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore>> GetTblDataImportStores(Query query)
        {
            return await GetTblDataImportStores(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore>> GetTblDataImportStores(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblDataImportStores");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataImportStores(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore>>(response);
        }

        partial void OnCreateTblDataImportStore(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore> CreateTblDataImportStore(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore tblDataImportStore = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore))
        {
            var uri = new Uri(baseUri, $"TblDataImportStores");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataImportStore), Encoding.UTF8, "application/json");

            OnCreateTblDataImportStore(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore>(response);
        }

        partial void OnDeleteTblDataImportStore(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblDataImportStore(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataImportStores({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblDataImportStore(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblDataImportStoreByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore> GetTblDataImportStoreByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataImportStores({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataImportStoreByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore>(response);
        }

        partial void OnUpdateTblDataImportStore(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblDataImportStore(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore tblDataImportStore = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore))
        {
            var uri = new Uri(baseUri, $"TblDataImportStores({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataImportStore), Encoding.UTF8, "application/json");

            OnUpdateTblDataImportStore(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblDataImportVerificationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldataimportverifications/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldataimportverifications/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblDataImportVerificationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldataimportverifications/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldataimportverifications/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblDataImportVerifications(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification>> GetTblDataImportVerifications(Query query)
        {
            return await GetTblDataImportVerifications(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification>> GetTblDataImportVerifications(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblDataImportVerifications");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataImportVerifications(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification>>(response);
        }

        partial void OnCreateTblDataImportVerification(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification> CreateTblDataImportVerification(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification tblDataImportVerification = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification))
        {
            var uri = new Uri(baseUri, $"TblDataImportVerifications");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataImportVerification), Encoding.UTF8, "application/json");

            OnCreateTblDataImportVerification(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification>(response);
        }

        partial void OnDeleteTblDataImportVerification(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblDataImportVerification(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataImportVerifications({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblDataImportVerification(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblDataImportVerificationByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification> GetTblDataImportVerificationByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDataImportVerifications({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDataImportVerificationByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification>(response);
        }

        partial void OnUpdateTblDataImportVerification(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblDataImportVerification(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification tblDataImportVerification = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification))
        {
            var uri = new Uri(baseUri, $"TblDataImportVerifications({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDataImportVerification), Encoding.UTF8, "application/json");

            OnUpdateTblDataImportVerification(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblMessageActivitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessageactivities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessageactivities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblMessageActivitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessageactivities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessageactivities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblMessageActivities(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity>> GetTblMessageActivities(Query query)
        {
            return await GetTblMessageActivities(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity>> GetTblMessageActivities(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblMessageActivities");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageActivities(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity>>(response);
        }

        partial void OnCreateTblMessageActivity(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity> CreateTblMessageActivity(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity tblMessageActivity = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity))
        {
            var uri = new Uri(baseUri, $"TblMessageActivities");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageActivity), Encoding.UTF8, "application/json");

            OnCreateTblMessageActivity(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity>(response);
        }

        partial void OnDeleteTblMessageActivity(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblMessageActivity(long fldRecordId = default(long))
        {
            var uri = new Uri(baseUri, $"TblMessageActivities({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblMessageActivity(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblMessageActivityByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity> GetTblMessageActivityByFldRecordId(string expand = default(string), long fldRecordId = default(long))
        {
            var uri = new Uri(baseUri, $"TblMessageActivities({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageActivityByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity>(response);
        }

        partial void OnUpdateTblMessageActivity(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblMessageActivity(long fldRecordId = default(long), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity tblMessageActivity = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity))
        {
            var uri = new Uri(baseUri, $"TblMessageActivities({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageActivity), Encoding.UTF8, "application/json");

            OnUpdateTblMessageActivity(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblMessageCommDatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagecommdates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagecommdates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblMessageCommDatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagecommdates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagecommdates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblMessageCommDates(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate>> GetTblMessageCommDates(Query query)
        {
            return await GetTblMessageCommDates(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate>> GetTblMessageCommDates(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblMessageCommDates");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageCommDates(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate>>(response);
        }

        partial void OnCreateTblMessageCommDate(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate> CreateTblMessageCommDate(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate tblMessageCommDate = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate))
        {
            var uri = new Uri(baseUri, $"TblMessageCommDates");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageCommDate), Encoding.UTF8, "application/json");

            OnCreateTblMessageCommDate(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate>(response);
        }

        partial void OnDeleteTblMessageCommDate(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblMessageCommDate(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblMessageCommDates({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblMessageCommDate(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblMessageCommDateByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate> GetTblMessageCommDateByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblMessageCommDates({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageCommDateByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate>(response);
        }

        partial void OnUpdateTblMessageCommDate(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblMessageCommDate(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate tblMessageCommDate = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate))
        {
            var uri = new Uri(baseUri, $"TblMessageCommDates({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageCommDate), Encoding.UTF8, "application/json");

            OnUpdateTblMessageCommDate(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblMessageDirectionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagedirections/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagedirections/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblMessageDirectionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagedirections/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagedirections/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblMessageDirections(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection>> GetTblMessageDirections(Query query)
        {
            return await GetTblMessageDirections(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection>> GetTblMessageDirections(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblMessageDirections");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageDirections(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection>>(response);
        }

        partial void OnCreateTblMessageDirection(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection> CreateTblMessageDirection(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection tblMessageDirection = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection))
        {
            var uri = new Uri(baseUri, $"TblMessageDirections");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageDirection), Encoding.UTF8, "application/json");

            OnCreateTblMessageDirection(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection>(response);
        }

        partial void OnDeleteTblMessageDirection(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblMessageDirection(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblMessageDirections({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblMessageDirection(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblMessageDirectionByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection> GetTblMessageDirectionByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblMessageDirections({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageDirectionByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection>(response);
        }

        partial void OnUpdateTblMessageDirection(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblMessageDirection(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection tblMessageDirection = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection))
        {
            var uri = new Uri(baseUri, $"TblMessageDirections({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageDirection), Encoding.UTF8, "application/json");

            OnUpdateTblMessageDirection(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblMessageErrorCodesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessageerrorcodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessageerrorcodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblMessageErrorCodesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessageerrorcodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessageerrorcodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblMessageErrorCodes(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode>> GetTblMessageErrorCodes(Query query)
        {
            return await GetTblMessageErrorCodes(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode>> GetTblMessageErrorCodes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblMessageErrorCodes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageErrorCodes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode>>(response);
        }

        partial void OnCreateTblMessageErrorCode(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode> CreateTblMessageErrorCode(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode tblMessageErrorCode = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode))
        {
            var uri = new Uri(baseUri, $"TblMessageErrorCodes");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageErrorCode), Encoding.UTF8, "application/json");

            OnCreateTblMessageErrorCode(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode>(response);
        }

        partial void OnDeleteTblMessageErrorCode(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblMessageErrorCode(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblMessageErrorCodes({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblMessageErrorCode(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblMessageErrorCodeByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode> GetTblMessageErrorCodeByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblMessageErrorCodes({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageErrorCodeByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode>(response);
        }

        partial void OnUpdateTblMessageErrorCode(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblMessageErrorCode(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode tblMessageErrorCode = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode))
        {
            var uri = new Uri(baseUri, $"TblMessageErrorCodes({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageErrorCode), Encoding.UTF8, "application/json");

            OnUpdateTblMessageErrorCode(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblMessageGroupingTermsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagegroupingterms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagegroupingterms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblMessageGroupingTermsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagegroupingterms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagegroupingterms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblMessageGroupingTerms(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm>> GetTblMessageGroupingTerms(Query query)
        {
            return await GetTblMessageGroupingTerms(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm>> GetTblMessageGroupingTerms(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblMessageGroupingTerms");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageGroupingTerms(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm>>(response);
        }

        partial void OnCreateTblMessageGroupingTerm(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm> CreateTblMessageGroupingTerm(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm tblMessageGroupingTerm = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm))
        {
            var uri = new Uri(baseUri, $"TblMessageGroupingTerms");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageGroupingTerm), Encoding.UTF8, "application/json");

            OnCreateTblMessageGroupingTerm(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm>(response);
        }

        partial void OnDeleteTblMessageGroupingTerm(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblMessageGroupingTerm(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblMessageGroupingTerms({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblMessageGroupingTerm(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblMessageGroupingTermByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm> GetTblMessageGroupingTermByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblMessageGroupingTerms({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageGroupingTermByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm>(response);
        }

        partial void OnUpdateTblMessageGroupingTerm(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblMessageGroupingTerm(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm tblMessageGroupingTerm = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm))
        {
            var uri = new Uri(baseUri, $"TblMessageGroupingTerms({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageGroupingTerm), Encoding.UTF8, "application/json");

            OnUpdateTblMessageGroupingTerm(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblMessageGroupingTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagegroupingtypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagegroupingtypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblMessageGroupingTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagegroupingtypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagegroupingtypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblMessageGroupingTypes(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType>> GetTblMessageGroupingTypes(Query query)
        {
            return await GetTblMessageGroupingTypes(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType>> GetTblMessageGroupingTypes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblMessageGroupingTypes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageGroupingTypes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType>>(response);
        }

        partial void OnCreateTblMessageGroupingType(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType> CreateTblMessageGroupingType(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType tblMessageGroupingType = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType))
        {
            var uri = new Uri(baseUri, $"TblMessageGroupingTypes");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageGroupingType), Encoding.UTF8, "application/json");

            OnCreateTblMessageGroupingType(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType>(response);
        }

        partial void OnDeleteTblMessageGroupingType(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblMessageGroupingType(short fldRecordId = default(short))
        {
            var uri = new Uri(baseUri, $"TblMessageGroupingTypes({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblMessageGroupingType(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblMessageGroupingTypeByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType> GetTblMessageGroupingTypeByFldRecordId(string expand = default(string), short fldRecordId = default(short))
        {
            var uri = new Uri(baseUri, $"TblMessageGroupingTypes({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageGroupingTypeByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType>(response);
        }

        partial void OnUpdateTblMessageGroupingType(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblMessageGroupingType(short fldRecordId = default(short), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType tblMessageGroupingType = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType))
        {
            var uri = new Uri(baseUri, $"TblMessageGroupingTypes({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageGroupingType), Encoding.UTF8, "application/json");

            OnUpdateTblMessageGroupingType(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblMessageMissedCallsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagemissedcalls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagemissedcalls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblMessageMissedCallsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagemissedcalls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagemissedcalls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblMessageMissedCalls(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall>> GetTblMessageMissedCalls(Query query)
        {
            return await GetTblMessageMissedCalls(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall>> GetTblMessageMissedCalls(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblMessageMissedCalls");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageMissedCalls(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall>>(response);
        }

        partial void OnCreateTblMessageMissedCall(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall> CreateTblMessageMissedCall(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall tblMessageMissedCall = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall))
        {
            var uri = new Uri(baseUri, $"TblMessageMissedCalls");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageMissedCall), Encoding.UTF8, "application/json");

            OnCreateTblMessageMissedCall(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall>(response);
        }

        partial void OnDeleteTblMessageMissedCall(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblMessageMissedCall(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblMessageMissedCalls({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblMessageMissedCall(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblMessageMissedCallByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall> GetTblMessageMissedCallByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblMessageMissedCalls({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageMissedCallByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall>(response);
        }

        partial void OnUpdateTblMessageMissedCall(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblMessageMissedCall(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall tblMessageMissedCall = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall))
        {
            var uri = new Uri(baseUri, $"TblMessageMissedCalls({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageMissedCall), Encoding.UTF8, "application/json");

            OnUpdateTblMessageMissedCall(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblMessageNotificationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagenotifications/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagenotifications/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblMessageNotificationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagenotifications/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagenotifications/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblMessageNotifications(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification>> GetTblMessageNotifications(Query query)
        {
            return await GetTblMessageNotifications(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification>> GetTblMessageNotifications(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblMessageNotifications");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageNotifications(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification>>(response);
        }

        partial void OnCreateTblMessageNotification(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification> CreateTblMessageNotification(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification tblMessageNotification = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification))
        {
            var uri = new Uri(baseUri, $"TblMessageNotifications");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageNotification), Encoding.UTF8, "application/json");

            OnCreateTblMessageNotification(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification>(response);
        }

        partial void OnDeleteTblMessageNotification(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblMessageNotification(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblMessageNotifications({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblMessageNotification(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblMessageNotificationByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification> GetTblMessageNotificationByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblMessageNotifications({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageNotificationByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification>(response);
        }

        partial void OnUpdateTblMessageNotification(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblMessageNotification(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification tblMessageNotification = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification))
        {
            var uri = new Uri(baseUri, $"TblMessageNotifications({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageNotification), Encoding.UTF8, "application/json");

            OnUpdateTblMessageNotification(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblMessagePhoneNumbersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagephonenumbers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagephonenumbers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblMessagePhoneNumbersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagephonenumbers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagephonenumbers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblMessagePhoneNumbers(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber>> GetTblMessagePhoneNumbers(Query query)
        {
            return await GetTblMessagePhoneNumbers(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber>> GetTblMessagePhoneNumbers(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblMessagePhoneNumbers");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessagePhoneNumbers(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber>>(response);
        }

        partial void OnCreateTblMessagePhoneNumber(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber> CreateTblMessagePhoneNumber(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber tblMessagePhoneNumber = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber))
        {
            var uri = new Uri(baseUri, $"TblMessagePhoneNumbers");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessagePhoneNumber), Encoding.UTF8, "application/json");

            OnCreateTblMessagePhoneNumber(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber>(response);
        }

        partial void OnDeleteTblMessagePhoneNumber(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblMessagePhoneNumber(long fldRecordId = default(long))
        {
            var uri = new Uri(baseUri, $"TblMessagePhoneNumbers({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblMessagePhoneNumber(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblMessagePhoneNumberByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber> GetTblMessagePhoneNumberByFldRecordId(string expand = default(string), long fldRecordId = default(long))
        {
            var uri = new Uri(baseUri, $"TblMessagePhoneNumbers({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessagePhoneNumberByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber>(response);
        }

        partial void OnUpdateTblMessagePhoneNumber(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblMessagePhoneNumber(long fldRecordId = default(long), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber tblMessagePhoneNumber = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber))
        {
            var uri = new Uri(baseUri, $"TblMessagePhoneNumbers({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessagePhoneNumber), Encoding.UTF8, "application/json");

            OnUpdateTblMessagePhoneNumber(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblMessageSettingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagesettings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagesettings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblMessageSettingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagesettings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagesettings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblMessageSettings(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting>> GetTblMessageSettings(Query query)
        {
            return await GetTblMessageSettings(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting>> GetTblMessageSettings(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblMessageSettings");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageSettings(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting>>(response);
        }

        partial void OnCreateTblMessageSetting(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting> CreateTblMessageSetting(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting tblMessageSetting = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting))
        {
            var uri = new Uri(baseUri, $"TblMessageSettings");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageSetting), Encoding.UTF8, "application/json");

            OnCreateTblMessageSetting(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting>(response);
        }

        partial void OnDeleteTblMessageSetting(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblMessageSetting(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblMessageSettings({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblMessageSetting(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblMessageSettingByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting> GetTblMessageSettingByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblMessageSettings({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageSettingByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting>(response);
        }

        partial void OnUpdateTblMessageSetting(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblMessageSetting(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting tblMessageSetting = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting))
        {
            var uri = new Uri(baseUri, $"TblMessageSettings({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageSetting), Encoding.UTF8, "application/json");

            OnUpdateTblMessageSetting(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblMessageUsagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessageusages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessageusages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblMessageUsagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessageusages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessageusages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblMessageUsages(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage>> GetTblMessageUsages(Query query)
        {
            return await GetTblMessageUsages(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage>> GetTblMessageUsages(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblMessageUsages");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageUsages(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage>>(response);
        }

        partial void OnCreateTblMessageUsage(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage> CreateTblMessageUsage(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage tblMessageUsage = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage))
        {
            var uri = new Uri(baseUri, $"TblMessageUsages");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageUsage), Encoding.UTF8, "application/json");

            OnCreateTblMessageUsage(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage>(response);
        }

        partial void OnDeleteTblMessageUsage(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblMessageUsage(long fldRecordId = default(long))
        {
            var uri = new Uri(baseUri, $"TblMessageUsages({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblMessageUsage(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblMessageUsageByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage> GetTblMessageUsageByFldRecordId(string expand = default(string), long fldRecordId = default(long))
        {
            var uri = new Uri(baseUri, $"TblMessageUsages({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblMessageUsageByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage>(response);
        }

        partial void OnUpdateTblMessageUsage(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblMessageUsage(long fldRecordId = default(long), ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage tblMessageUsage = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage))
        {
            var uri = new Uri(baseUri, $"TblMessageUsages({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblMessageUsage), Encoding.UTF8, "application/json");

            OnUpdateTblMessageUsage(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportUserdetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/userdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/userdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportUserdetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/userdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/userdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetUserdetails(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.Userdetail>> GetUserdetails(Query query)
        {
            return await GetUserdetails(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.Userdetail>> GetUserdetails(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Userdetails");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetUserdetails(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.Userdetail>>(response);
        }
    }
}