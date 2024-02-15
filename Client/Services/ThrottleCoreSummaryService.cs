
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
    public partial class Throttle_Core_SummaryService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;

        public Throttle_Core_SummaryService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/Throttle_Core_Summary/");
        }


        public async System.Threading.Tasks.Task ExportTblDailyTotalsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tbldailytotals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tbldailytotals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblDailyTotalsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tbldailytotals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tbldailytotals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblDailyTotals(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal>> GetTblDailyTotals(Query query)
        {
            return await GetTblDailyTotals(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal>> GetTblDailyTotals(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblDailyTotals");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDailyTotals(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal>>(response);
        }

        partial void OnCreateTblDailyTotal(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal> CreateTblDailyTotal(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal tblDailyTotal = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal))
        {
            var uri = new Uri(baseUri, $"TblDailyTotals");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDailyTotal), Encoding.UTF8, "application/json");

            OnCreateTblDailyTotal(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal>(response);
        }

        partial void OnDeleteTblDailyTotal(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblDailyTotal(long fldRecordId = default(long))
        {
            var uri = new Uri(baseUri, $"TblDailyTotals({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblDailyTotal(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblDailyTotalByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal> GetTblDailyTotalByFldRecordId(string expand = default(string), long fldRecordId = default(long))
        {
            var uri = new Uri(baseUri, $"TblDailyTotals({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDailyTotalByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal>(response);
        }

        partial void OnUpdateTblDailyTotal(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblDailyTotal(long fldRecordId = default(long), ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal tblDailyTotal = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal))
        {
            var uri = new Uri(baseUri, $"TblDailyTotals({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDailyTotal), Encoding.UTF8, "application/json");

            OnUpdateTblDailyTotal(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblDailyTotalsLaborsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tbldailytotalslabors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tbldailytotalslabors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblDailyTotalsLaborsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tbldailytotalslabors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tbldailytotalslabors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblDailyTotalsLabors(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsLabor>> GetTblDailyTotalsLabors(Query query)
        {
            return await GetTblDailyTotalsLabors(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsLabor>> GetTblDailyTotalsLabors(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblDailyTotalsLabors");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDailyTotalsLabors(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsLabor>>(response);
        }

        public async System.Threading.Tasks.Task ExportTblDailyTotalsOperatorsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tbldailytotalsoperators/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tbldailytotalsoperators/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblDailyTotalsOperatorsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tbldailytotalsoperators/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tbldailytotalsoperators/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblDailyTotalsOperators(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator>> GetTblDailyTotalsOperators(Query query)
        {
            return await GetTblDailyTotalsOperators(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator>> GetTblDailyTotalsOperators(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblDailyTotalsOperators");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDailyTotalsOperators(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator>>(response);
        }

        partial void OnCreateTblDailyTotalsOperator(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator> CreateTblDailyTotalsOperator(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator tblDailyTotalsOperator = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator))
        {
            var uri = new Uri(baseUri, $"TblDailyTotalsOperators");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDailyTotalsOperator), Encoding.UTF8, "application/json");

            OnCreateTblDailyTotalsOperator(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator>(response);
        }

        partial void OnDeleteTblDailyTotalsOperator(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblDailyTotalsOperator(long fldRecordId = default(long))
        {
            var uri = new Uri(baseUri, $"TblDailyTotalsOperators({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblDailyTotalsOperator(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblDailyTotalsOperatorByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator> GetTblDailyTotalsOperatorByFldRecordId(string expand = default(string), long fldRecordId = default(long))
        {
            var uri = new Uri(baseUri, $"TblDailyTotalsOperators({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDailyTotalsOperatorByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator>(response);
        }

        partial void OnUpdateTblDailyTotalsOperator(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblDailyTotalsOperator(long fldRecordId = default(long), ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator tblDailyTotalsOperator = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator))
        {
            var uri = new Uri(baseUri, $"TblDailyTotalsOperators({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDailyTotalsOperator), Encoding.UTF8, "application/json");

            OnUpdateTblDailyTotalsOperator(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblDailyTotalsPartsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tbldailytotalsparts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tbldailytotalsparts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblDailyTotalsPartsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tbldailytotalsparts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tbldailytotalsparts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblDailyTotalsParts(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart>> GetTblDailyTotalsParts(Query query)
        {
            return await GetTblDailyTotalsParts(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart>> GetTblDailyTotalsParts(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblDailyTotalsParts");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDailyTotalsParts(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart>>(response);
        }

        partial void OnCreateTblDailyTotalsPart(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart> CreateTblDailyTotalsPart(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart tblDailyTotalsPart = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart))
        {
            var uri = new Uri(baseUri, $"TblDailyTotalsParts");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDailyTotalsPart), Encoding.UTF8, "application/json");

            OnCreateTblDailyTotalsPart(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart>(response);
        }

        partial void OnDeleteTblDailyTotalsPart(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblDailyTotalsPart(long fldRecordId = default(long))
        {
            var uri = new Uri(baseUri, $"TblDailyTotalsParts({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblDailyTotalsPart(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblDailyTotalsPartByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart> GetTblDailyTotalsPartByFldRecordId(string expand = default(string), long fldRecordId = default(long))
        {
            var uri = new Uri(baseUri, $"TblDailyTotalsParts({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDailyTotalsPartByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart>(response);
        }

        partial void OnUpdateTblDailyTotalsPart(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblDailyTotalsPart(long fldRecordId = default(long), ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart tblDailyTotalsPart = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart))
        {
            var uri = new Uri(baseUri, $"TblDailyTotalsParts({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDailyTotalsPart), Encoding.UTF8, "application/json");

            OnUpdateTblDailyTotalsPart(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblHelperCouponsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelpercoupons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelpercoupons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblHelperCouponsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelpercoupons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelpercoupons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblHelperCoupons(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon>> GetTblHelperCoupons(Query query)
        {
            return await GetTblHelperCoupons(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon>> GetTblHelperCoupons(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblHelperCoupons");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblHelperCoupons(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon>>(response);
        }

        partial void OnCreateTblHelperCoupon(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon> CreateTblHelperCoupon(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon tblHelperCoupon = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon))
        {
            var uri = new Uri(baseUri, $"TblHelperCoupons");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblHelperCoupon), Encoding.UTF8, "application/json");

            OnCreateTblHelperCoupon(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon>(response);
        }

        partial void OnDeleteTblHelperCoupon(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblHelperCoupon(long fldRecordId = default(long))
        {
            var uri = new Uri(baseUri, $"TblHelperCoupons({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblHelperCoupon(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblHelperCouponByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon> GetTblHelperCouponByFldRecordId(string expand = default(string), long fldRecordId = default(long))
        {
            var uri = new Uri(baseUri, $"TblHelperCoupons({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblHelperCouponByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon>(response);
        }

        partial void OnUpdateTblHelperCoupon(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblHelperCoupon(long fldRecordId = default(long), ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon tblHelperCoupon = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon))
        {
            var uri = new Uri(baseUri, $"TblHelperCoupons({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblHelperCoupon), Encoding.UTF8, "application/json");

            OnUpdateTblHelperCoupon(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblHelperEmailStatusCodesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelperemailstatuscodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelperemailstatuscodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblHelperEmailStatusCodesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelperemailstatuscodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelperemailstatuscodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblHelperEmailStatusCodes(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode>> GetTblHelperEmailStatusCodes(Query query)
        {
            return await GetTblHelperEmailStatusCodes(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode>> GetTblHelperEmailStatusCodes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblHelperEmailStatusCodes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblHelperEmailStatusCodes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode>>(response);
        }

        partial void OnCreateTblHelperEmailStatusCode(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode> CreateTblHelperEmailStatusCode(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode tblHelperEmailStatusCode = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode))
        {
            var uri = new Uri(baseUri, $"TblHelperEmailStatusCodes");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblHelperEmailStatusCode), Encoding.UTF8, "application/json");

            OnCreateTblHelperEmailStatusCode(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode>(response);
        }

        partial void OnDeleteTblHelperEmailStatusCode(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblHelperEmailStatusCode(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblHelperEmailStatusCodes({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblHelperEmailStatusCode(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblHelperEmailStatusCodeByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode> GetTblHelperEmailStatusCodeByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblHelperEmailStatusCodes({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblHelperEmailStatusCodeByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode>(response);
        }

        partial void OnUpdateTblHelperEmailStatusCode(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblHelperEmailStatusCode(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode tblHelperEmailStatusCode = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode))
        {
            var uri = new Uri(baseUri, $"TblHelperEmailStatusCodes({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblHelperEmailStatusCode), Encoding.UTF8, "application/json");

            OnUpdateTblHelperEmailStatusCode(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblHelperLaborsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelperlabors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelperlabors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblHelperLaborsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelperlabors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelperlabors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblHelperLabors(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor>> GetTblHelperLabors(Query query)
        {
            return await GetTblHelperLabors(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor>> GetTblHelperLabors(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblHelperLabors");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblHelperLabors(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor>>(response);
        }

        partial void OnCreateTblHelperLabor(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor> CreateTblHelperLabor(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor tblHelperLabor = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor))
        {
            var uri = new Uri(baseUri, $"TblHelperLabors");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblHelperLabor), Encoding.UTF8, "application/json");

            OnCreateTblHelperLabor(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor>(response);
        }

        partial void OnDeleteTblHelperLabor(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblHelperLabor(long fldRecordId = default(long))
        {
            var uri = new Uri(baseUri, $"TblHelperLabors({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblHelperLabor(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblHelperLaborByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor> GetTblHelperLaborByFldRecordId(string expand = default(string), long fldRecordId = default(long))
        {
            var uri = new Uri(baseUri, $"TblHelperLabors({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblHelperLaborByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor>(response);
        }

        partial void OnUpdateTblHelperLabor(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblHelperLabor(long fldRecordId = default(long), ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor tblHelperLabor = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor))
        {
            var uri = new Uri(baseUri, $"TblHelperLabors({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblHelperLabor), Encoding.UTF8, "application/json");

            OnUpdateTblHelperLabor(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblHelperMailAddressErrorsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelpermailaddresserrors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelpermailaddresserrors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblHelperMailAddressErrorsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelpermailaddresserrors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelpermailaddresserrors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblHelperMailAddressErrors(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError>> GetTblHelperMailAddressErrors(Query query)
        {
            return await GetTblHelperMailAddressErrors(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError>> GetTblHelperMailAddressErrors(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblHelperMailAddressErrors");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblHelperMailAddressErrors(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError>>(response);
        }

        partial void OnCreateTblHelperMailAddressError(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError> CreateTblHelperMailAddressError(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError tblHelperMailAddressError = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError))
        {
            var uri = new Uri(baseUri, $"TblHelperMailAddressErrors");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblHelperMailAddressError), Encoding.UTF8, "application/json");

            OnCreateTblHelperMailAddressError(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError>(response);
        }

        partial void OnDeleteTblHelperMailAddressError(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblHelperMailAddressError(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblHelperMailAddressErrors({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblHelperMailAddressError(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblHelperMailAddressErrorByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError> GetTblHelperMailAddressErrorByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblHelperMailAddressErrors({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblHelperMailAddressErrorByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError>(response);
        }

        partial void OnUpdateTblHelperMailAddressError(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblHelperMailAddressError(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError tblHelperMailAddressError = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError))
        {
            var uri = new Uri(baseUri, $"TblHelperMailAddressErrors({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblHelperMailAddressError), Encoding.UTF8, "application/json");

            OnUpdateTblHelperMailAddressError(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblHelperPartsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelperparts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelperparts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblHelperPartsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelperparts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelperparts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblHelperParts(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart>> GetTblHelperParts(Query query)
        {
            return await GetTblHelperParts(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart>> GetTblHelperParts(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblHelperParts");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblHelperParts(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart>>(response);
        }

        partial void OnCreateTblHelperPart(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart> CreateTblHelperPart(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart tblHelperPart = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart))
        {
            var uri = new Uri(baseUri, $"TblHelperParts");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblHelperPart), Encoding.UTF8, "application/json");

            OnCreateTblHelperPart(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart>(response);
        }

        partial void OnDeleteTblHelperPart(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblHelperPart(long fldRecordId = default(long))
        {
            var uri = new Uri(baseUri, $"TblHelperParts({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblHelperPart(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblHelperPartByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart> GetTblHelperPartByFldRecordId(string expand = default(string), long fldRecordId = default(long))
        {
            var uri = new Uri(baseUri, $"TblHelperParts({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblHelperPartByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart>(response);
        }

        partial void OnUpdateTblHelperPart(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblHelperPart(long fldRecordId = default(long), ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart tblHelperPart = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart))
        {
            var uri = new Uri(baseUri, $"TblHelperParts({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblHelperPart), Encoding.UTF8, "application/json");

            OnUpdateTblHelperPart(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblSummaryCampaignsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblsummarycampaigns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblsummarycampaigns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblSummaryCampaignsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblsummarycampaigns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblsummarycampaigns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblSummaryCampaigns(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign>> GetTblSummaryCampaigns(Query query)
        {
            return await GetTblSummaryCampaigns(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign>> GetTblSummaryCampaigns(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblSummaryCampaigns");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblSummaryCampaigns(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign>>(response);
        }

        partial void OnCreateTblSummaryCampaign(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign> CreateTblSummaryCampaign(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign tblSummaryCampaign = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign))
        {
            var uri = new Uri(baseUri, $"TblSummaryCampaigns");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblSummaryCampaign), Encoding.UTF8, "application/json");

            OnCreateTblSummaryCampaign(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign>(response);
        }

        partial void OnDeleteTblSummaryCampaign(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblSummaryCampaign(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblSummaryCampaigns({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblSummaryCampaign(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblSummaryCampaignByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign> GetTblSummaryCampaignByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblSummaryCampaigns({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblSummaryCampaignByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign>(response);
        }

        partial void OnUpdateTblSummaryCampaign(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblSummaryCampaign(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign tblSummaryCampaign = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign))
        {
            var uri = new Uri(baseUri, $"TblSummaryCampaigns({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblSummaryCampaign), Encoding.UTF8, "application/json");

            OnUpdateTblSummaryCampaign(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblSummaryCustomersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblsummarycustomers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblsummarycustomers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblSummaryCustomersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblsummarycustomers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblsummarycustomers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblSummaryCustomers(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer>> GetTblSummaryCustomers(Query query)
        {
            return await GetTblSummaryCustomers(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer>> GetTblSummaryCustomers(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblSummaryCustomers");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblSummaryCustomers(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer>>(response);
        }

        partial void OnCreateTblSummaryCustomer(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer> CreateTblSummaryCustomer(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer tblSummaryCustomer = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer))
        {
            var uri = new Uri(baseUri, $"TblSummaryCustomers");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblSummaryCustomer), Encoding.UTF8, "application/json");

            OnCreateTblSummaryCustomer(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer>(response);
        }

        partial void OnDeleteTblSummaryCustomer(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblSummaryCustomer(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblSummaryCustomers({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblSummaryCustomer(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblSummaryCustomerByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer> GetTblSummaryCustomerByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblSummaryCustomers({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblSummaryCustomerByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer>(response);
        }

        partial void OnUpdateTblSummaryCustomer(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblSummaryCustomer(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer tblSummaryCustomer = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer))
        {
            var uri = new Uri(baseUri, $"TblSummaryCustomers({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblSummaryCustomer), Encoding.UTF8, "application/json");

            OnUpdateTblSummaryCustomer(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblSummarySalesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblsummarysales/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblsummarysales/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblSummarySalesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblsummarysales/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblsummarysales/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblSummarySales(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale>> GetTblSummarySales(Query query)
        {
            return await GetTblSummarySales(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale>> GetTblSummarySales(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblSummarySales");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblSummarySales(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale>>(response);
        }

        partial void OnCreateTblSummarySale(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale> CreateTblSummarySale(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale tblSummarySale = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale))
        {
            var uri = new Uri(baseUri, $"TblSummarySales");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblSummarySale), Encoding.UTF8, "application/json");

            OnCreateTblSummarySale(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale>(response);
        }

        partial void OnDeleteTblSummarySale(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblSummarySale(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblSummarySales({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblSummarySale(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblSummarySaleByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale> GetTblSummarySaleByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblSummarySales({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblSummarySaleByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale>(response);
        }

        partial void OnUpdateTblSummarySale(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblSummarySale(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale tblSummarySale = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale))
        {
            var uri = new Uri(baseUri, $"TblSummarySales({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblSummarySale), Encoding.UTF8, "application/json");

            OnUpdateTblSummarySale(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblSummaryVehiclesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblsummaryvehicles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblsummaryvehicles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblSummaryVehiclesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblsummaryvehicles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblsummaryvehicles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblSummaryVehicles(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle>> GetTblSummaryVehicles(Query query)
        {
            return await GetTblSummaryVehicles(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle>> GetTblSummaryVehicles(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblSummaryVehicles");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblSummaryVehicles(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle>>(response);
        }

        partial void OnCreateTblSummaryVehicle(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle> CreateTblSummaryVehicle(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle tblSummaryVehicle = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle))
        {
            var uri = new Uri(baseUri, $"TblSummaryVehicles");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblSummaryVehicle), Encoding.UTF8, "application/json");

            OnCreateTblSummaryVehicle(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle>(response);
        }

        partial void OnDeleteTblSummaryVehicle(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblSummaryVehicle(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblSummaryVehicles({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblSummaryVehicle(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblSummaryVehicleByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle> GetTblSummaryVehicleByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblSummaryVehicles({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblSummaryVehicleByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle>(response);
        }

        partial void OnUpdateTblSummaryVehicle(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblSummaryVehicle(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle tblSummaryVehicle = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle))
        {
            var uri = new Uri(baseUri, $"TblSummaryVehicles({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblSummaryVehicle), Encoding.UTF8, "application/json");

            OnUpdateTblSummaryVehicle(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetDashboardValuesOriginals(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> GetDashboardValuesOriginals(int? webUserId = default(int?), int? customerId = default(int?), string startDate = default(string), string endDate = default(string), string stores = default(string), string groups = default(string), int? startOfWeekDay = default(int?), bool? activeOnly = default(bool?))
        {
            var uri = new Uri(baseUri, $"GetDashboardValuesOriginalsFunc(WebUserID={webUserId},CustomerID={customerId},StartDate='{Uri.EscapeDataString(startDate.Trim().Replace("'", "''"))}',EndDate='{Uri.EscapeDataString(endDate.Trim().Replace("'", "''"))}',Stores='{Uri.EscapeDataString(stores.Trim().Replace("'", "''"))}',Groups='{Uri.EscapeDataString(groups.Trim().Replace("'", "''"))}',StartOfWeekDay={startOfWeekDay},ActiveOnly={activeOnly?.ToString().ToLower()})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDashboardValuesOriginals(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetEmployeesWithDepartments(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> GetEmployeesWithDepartments(int? id = default(int?))
        {
            var uri = new Uri(baseUri, $"GetEmployeesWithDepartmentsFunc(id={id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEmployeesWithDepartments(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnUspDashboardGetStatisticsCustomers(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> UspDashboardGetStatisticsCustomers(int? webUserId = default(int?), int? customerId = default(int?), string stores = default(string), string groups = default(string), string startDate = default(string), string endDate = default(string), bool? onlyActiveStores = default(bool?), bool? extDaily = default(bool?), bool? extWtd = default(bool?), bool? extMtd = default(bool?), bool? extYtd = default(bool?), bool? extDod = default(bool?), bool? extWow = default(bool?), bool? extMom = default(bool?), bool? extYoy = default(bool?))
        {
            var uri = new Uri(baseUri, $"UspDashboardGetStatisticsCustomersFunc(WebUserID={webUserId},CustomerID={customerId},Stores='{Uri.EscapeDataString(stores.Trim().Replace("'", "''"))}',Groups='{Uri.EscapeDataString(groups.Trim().Replace("'", "''"))}',StartDate='{Uri.EscapeDataString(startDate.Trim().Replace("'", "''"))}',EndDate='{Uri.EscapeDataString(endDate.Trim().Replace("'", "''"))}',OnlyActiveStores={onlyActiveStores?.ToString().ToLower()},ext_Daily={extDaily?.ToString().ToLower()},ext_WTD={extWtd?.ToString().ToLower()},ext_MTD={extMtd?.ToString().ToLower()},ext_YTD={extYtd?.ToString().ToLower()},ext_DOD={extDod?.ToString().ToLower()},ext_WOW={extWow?.ToString().ToLower()},ext_MOM={extMom?.ToString().ToLower()},ext_YOY={extYoy?.ToString().ToLower()})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnUspDashboardGetStatisticsCustomers(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnUspDashboardGetStatisticsTopVehiclesServiceds(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> UspDashboardGetStatisticsTopVehiclesServiceds(int? webUserId = default(int?), int? customerId = default(int?), string stores = default(string), string groups = default(string), string startDate = default(string), string endDate = default(string), bool? onlyActiveStores = default(bool?), int? extTopXnumberofVehicles = default(int?), bool? extIncludeVehicleYear = default(bool?))
        {
            var uri = new Uri(baseUri, $"UspDashboardGetStatisticsTopVehiclesServicedsFunc(WebUserID={webUserId},CustomerID={customerId},Stores='{Uri.EscapeDataString(stores.Trim().Replace("'", "''"))}',Groups='{Uri.EscapeDataString(groups.Trim().Replace("'", "''"))}',StartDate='{Uri.EscapeDataString(startDate.Trim().Replace("'", "''"))}',EndDate='{Uri.EscapeDataString(endDate.Trim().Replace("'", "''"))}',OnlyActiveStores={onlyActiveStores?.ToString().ToLower()},ext_TopXNumberofVehicles={extTopXnumberofVehicles},ext_IncludeVehicleYear={extIncludeVehicleYear?.ToString().ToLower()})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnUspDashboardGetStatisticsTopVehiclesServiceds(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnUspDashboardGetValuesCampaigns(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> UspDashboardGetValuesCampaigns(int? webUserId = default(int?), int? customerId = default(int?), string stores = default(string), string groups = default(string), string startDate = default(string), string endDate = default(string), bool? onlyActiveStores = default(bool?), bool? extDaily = default(bool?), bool? extWtd = default(bool?), bool? extMtd = default(bool?), bool? extYtd = default(bool?), bool? extDod = default(bool?), bool? extWow = default(bool?), bool? extMom = default(bool?), bool? extYoy = default(bool?))
        {
            var uri = new Uri(baseUri, $"UspDashboardGetValuesCampaignsFunc(WebUserID={webUserId},CustomerID={customerId},Stores='{Uri.EscapeDataString(stores.Trim().Replace("'", "''"))}',Groups='{Uri.EscapeDataString(groups.Trim().Replace("'", "''"))}',StartDate='{Uri.EscapeDataString(startDate.Trim().Replace("'", "''"))}',EndDate='{Uri.EscapeDataString(endDate.Trim().Replace("'", "''"))}',OnlyActiveStores={onlyActiveStores?.ToString().ToLower()},ext_Daily={extDaily?.ToString().ToLower()},ext_WTD={extWtd?.ToString().ToLower()},ext_MTD={extMtd?.ToString().ToLower()},ext_YTD={extYtd?.ToString().ToLower()},ext_DOD={extDod?.ToString().ToLower()},ext_WOW={extWow?.ToString().ToLower()},ext_MOM={extMom?.ToString().ToLower()},ext_YOY={extYoy?.ToString().ToLower()})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnUspDashboardGetValuesCampaigns(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnUspDashboardGetValuesSales(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> UspDashboardGetValuesSales(int? webUserId = default(int?), int? customerId = default(int?), string stores = default(string), string groups = default(string), string startDate = default(string), string endDate = default(string), bool? onlyActiveStores = default(bool?), bool? extDaily = default(bool?), bool? extWtd = default(bool?), bool? extMtd = default(bool?), bool? extYtd = default(bool?), bool? extDod = default(bool?), bool? extWow = default(bool?), bool? extMom = default(bool?), bool? extYoy = default(bool?))
        {
            var uri = new Uri(baseUri, $"UspDashboardGetValuesSalesFunc(WebUserID={webUserId},CustomerID={customerId},Stores='{Uri.EscapeDataString(stores.Trim().Replace("'", "''"))}',Groups='{Uri.EscapeDataString(groups.Trim().Replace("'", "''"))}',StartDate='{Uri.EscapeDataString(startDate.Trim().Replace("'", "''"))}',EndDate='{Uri.EscapeDataString(endDate.Trim().Replace("'", "''"))}',OnlyActiveStores={onlyActiveStores?.ToString().ToLower()},ext_Daily={extDaily?.ToString().ToLower()},ext_WTD={extWtd?.ToString().ToLower()},ext_MTD={extMtd?.ToString().ToLower()},ext_YTD={extYtd?.ToString().ToLower()},ext_DOD={extDod?.ToString().ToLower()},ext_WOW={extWow?.ToString().ToLower()},ext_MOM={extMom?.ToString().ToLower()},ext_YOY={extYoy?.ToString().ToLower()})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnUspDashboardGetValuesSales(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnUspDataCreateVehicleSummaryData(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> UspDataCreateVehicleSummaryData()
        {
            var uri = new Uri(baseUri, $"UspDataCreateVehicleSummaryDataFunc()");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnUspDataCreateVehicleSummaryData(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}