
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
    public partial class Throttle_Core_BillingService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;

        public Throttle_Core_BillingService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/Throttle_Core_Billing/");
        }


        public async System.Threading.Tasks.Task ExportBulkBillingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/bulkbillings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/bulkbillings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportBulkBillingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/bulkbillings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/bulkbillings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetBulkBillings(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling>> GetBulkBillings(Query query)
        {
            return await GetBulkBillings(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling>> GetBulkBillings(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"BulkBillings");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetBulkBillings(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling>>(response);
        }

        partial void OnCreateBulkBilling(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling> CreateBulkBilling(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling bulkBilling = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling))
        {
            var uri = new Uri(baseUri, $"BulkBillings");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(bulkBilling), Encoding.UTF8, "application/json");

            OnCreateBulkBilling(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling>(response);
        }

        partial void OnDeleteBulkBilling(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteBulkBilling(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"BulkBillings({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteBulkBilling(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetBulkBillingByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling> GetBulkBillingByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"BulkBillings({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetBulkBillingByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling>(response);
        }

        partial void OnUpdateBulkBilling(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateBulkBilling(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling bulkBilling = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling))
        {
            var uri = new Uri(baseUri, $"BulkBillings({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(bulkBilling), Encoding.UTF8, "application/json");

            OnUpdateBulkBilling(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportCurrentStoresToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/currentstores/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/currentstores/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportCurrentStoresToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/currentstores/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/currentstores/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetCurrentStores(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore>> GetCurrentStores(Query query)
        {
            return await GetCurrentStores(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore>> GetCurrentStores(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"CurrentStores");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetCurrentStores(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore>>(response);
        }

        partial void OnCreateCurrentStore(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore> CreateCurrentStore(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore currentStore = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore))
        {
            var uri = new Uri(baseUri, $"CurrentStores");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(currentStore), Encoding.UTF8, "application/json");

            OnCreateCurrentStore(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore>(response);
        }

        partial void OnDeleteCurrentStore(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteCurrentStore(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"CurrentStores({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteCurrentStore(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetCurrentStoreByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore> GetCurrentStoreByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"CurrentStores({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetCurrentStoreByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore>(response);
        }

        partial void OnUpdateCurrentStore(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateCurrentStore(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore currentStore = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore))
        {
            var uri = new Uri(baseUri, $"CurrentStores({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(currentStore), Encoding.UTF8, "application/json");

            OnUpdateCurrentStore(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportCustomerBillingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/customerbillings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/customerbillings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportCustomerBillingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/customerbillings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/customerbillings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetCustomerBillings(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling>> GetCustomerBillings(Query query)
        {
            return await GetCustomerBillings(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling>> GetCustomerBillings(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"CustomerBillings");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetCustomerBillings(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling>>(response);
        }

        partial void OnCreateCustomerBilling(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling> CreateCustomerBilling(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling customerBilling = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling))
        {
            var uri = new Uri(baseUri, $"CustomerBillings");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(customerBilling), Encoding.UTF8, "application/json");

            OnCreateCustomerBilling(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling>(response);
        }

        partial void OnDeleteCustomerBilling(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteCustomerBilling(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"CustomerBillings({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteCustomerBilling(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetCustomerBillingByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling> GetCustomerBillingByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"CustomerBillings({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetCustomerBillingByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling>(response);
        }

        partial void OnUpdateCustomerBilling(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateCustomerBilling(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling customerBilling = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling))
        {
            var uri = new Uri(baseUri, $"CustomerBillings({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(customerBilling), Encoding.UTF8, "application/json");

            OnUpdateCustomerBilling(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportCustomerShippingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/customershippings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/customershippings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportCustomerShippingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/customershippings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/customershippings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetCustomerShippings(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping>> GetCustomerShippings(Query query)
        {
            return await GetCustomerShippings(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping>> GetCustomerShippings(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"CustomerShippings");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetCustomerShippings(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping>>(response);
        }

        partial void OnCreateCustomerShipping(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping> CreateCustomerShipping(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping customerShipping = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping))
        {
            var uri = new Uri(baseUri, $"CustomerShippings");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(customerShipping), Encoding.UTF8, "application/json");

            OnCreateCustomerShipping(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping>(response);
        }

        partial void OnDeleteCustomerShipping(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteCustomerShipping(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"CustomerShippings({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteCustomerShipping(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetCustomerShippingByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping> GetCustomerShippingByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"CustomerShippings({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetCustomerShippingByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping>(response);
        }

        partial void OnUpdateCustomerShipping(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateCustomerShipping(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping customerShipping = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping))
        {
            var uri = new Uri(baseUri, $"CustomerShippings({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(customerShipping), Encoding.UTF8, "application/json");

            OnUpdateCustomerShipping(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportJobsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/jobs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/jobs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportJobsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/jobs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/jobs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetJobs(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>> GetJobs(Query query)
        {
            return await GetJobs(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>> GetJobs(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Jobs");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetJobs(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>>(response);
        }

        partial void OnCreateJob(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job> CreateJob(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job job = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job))
        {
            var uri = new Uri(baseUri, $"Jobs");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(job), Encoding.UTF8, "application/json");

            OnCreateJob(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>(response);
        }

        partial void OnDeleteJob(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteJob(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"Jobs({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteJob(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetJobByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job> GetJobByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"Jobs({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetJobByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>(response);
        }

        partial void OnUpdateJob(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateJob(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job job = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job))
        {
            var uri = new Uri(baseUri, $"Jobs({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(job), Encoding.UTF8, "application/json");

            OnUpdateJob(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportLineItemsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/lineitems/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/lineitems/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportLineItemsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/lineitems/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/lineitems/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetLineItems(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>> GetLineItems(Query query)
        {
            return await GetLineItems(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>> GetLineItems(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"LineItems");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetLineItems(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>>(response);
        }

        partial void OnCreateLineItem(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem> CreateLineItem(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem lineItem = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem))
        {
            var uri = new Uri(baseUri, $"LineItems");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(lineItem), Encoding.UTF8, "application/json");

            OnCreateLineItem(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>(response);
        }

        partial void OnDeleteLineItem(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteLineItem(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"LineItems({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteLineItem(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetLineItemByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem> GetLineItemByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"LineItems({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetLineItemByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>(response);
        }

        partial void OnUpdateLineItem(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateLineItem(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem lineItem = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem))
        {
            var uri = new Uri(baseUri, $"LineItems({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(lineItem), Encoding.UTF8, "application/json");

            OnUpdateLineItem(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportProductsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/products/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/products/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProductsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/products/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/products/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetProducts(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product>> GetProducts(Query query)
        {
            return await GetProducts(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product>> GetProducts(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Products");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProducts(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product>>(response);
        }

        partial void OnCreateProduct(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product> CreateProduct(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product product = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product))
        {
            var uri = new Uri(baseUri, $"Products");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

            OnCreateProduct(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product>(response);
        }

        partial void OnDeleteProduct(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteProduct(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"Products({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProduct(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetProductByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product> GetProductByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"Products({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProductByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product>(response);
        }

        partial void OnUpdateProduct(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateProduct(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product product = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product))
        {
            var uri = new Uri(baseUri, $"Products({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

            OnUpdateProduct(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportProductCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/productcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/productcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProductCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/productcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/productcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetProductCategories(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory>> GetProductCategories(Query query)
        {
            return await GetProductCategories(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory>> GetProductCategories(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ProductCategories");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProductCategories(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory>>(response);
        }

        partial void OnCreateProductCategory(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory> CreateProductCategory(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory productCategory = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory))
        {
            var uri = new Uri(baseUri, $"ProductCategories");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(productCategory), Encoding.UTF8, "application/json");

            OnCreateProductCategory(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory>(response);
        }

        partial void OnDeleteProductCategory(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteProductCategory(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"ProductCategories({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProductCategory(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetProductCategoryByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory> GetProductCategoryByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"ProductCategories({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProductCategoryByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory>(response);
        }

        partial void OnUpdateProductCategory(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateProductCategory(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory productCategory = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory))
        {
            var uri = new Uri(baseUri, $"ProductCategories({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(productCategory), Encoding.UTF8, "application/json");

            OnUpdateProductCategory(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportRemindersSettingsAdminsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/reminderssettingsadmins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/reminderssettingsadmins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportRemindersSettingsAdminsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/reminderssettingsadmins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/reminderssettingsadmins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetRemindersSettingsAdmins(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin>> GetRemindersSettingsAdmins(Query query)
        {
            return await GetRemindersSettingsAdmins(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin>> GetRemindersSettingsAdmins(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"RemindersSettingsAdmins");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetRemindersSettingsAdmins(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin>>(response);
        }

        partial void OnCreateRemindersSettingsAdmin(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin> CreateRemindersSettingsAdmin(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin remindersSettingsAdmin = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin))
        {
            var uri = new Uri(baseUri, $"RemindersSettingsAdmins");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(remindersSettingsAdmin), Encoding.UTF8, "application/json");

            OnCreateRemindersSettingsAdmin(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin>(response);
        }

        partial void OnDeleteRemindersSettingsAdmin(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteRemindersSettingsAdmin(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"RemindersSettingsAdmins({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteRemindersSettingsAdmin(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetRemindersSettingsAdminByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin> GetRemindersSettingsAdminByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"RemindersSettingsAdmins({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetRemindersSettingsAdminByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin>(response);
        }

        partial void OnUpdateRemindersSettingsAdmin(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateRemindersSettingsAdmin(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin remindersSettingsAdmin = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin))
        {
            var uri = new Uri(baseUri, $"RemindersSettingsAdmins({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(remindersSettingsAdmin), Encoding.UTF8, "application/json");

            OnUpdateRemindersSettingsAdmin(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportSettingsConfigurationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/settingsconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/settingsconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportSettingsConfigurationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/settingsconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/settingsconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetSettingsConfigurations(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration>> GetSettingsConfigurations(Query query)
        {
            return await GetSettingsConfigurations(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration>> GetSettingsConfigurations(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"SettingsConfigurations");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSettingsConfigurations(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration>>(response);
        }

        partial void OnCreateSettingsConfiguration(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration> CreateSettingsConfiguration(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration settingsConfiguration = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration))
        {
            var uri = new Uri(baseUri, $"SettingsConfigurations");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(settingsConfiguration), Encoding.UTF8, "application/json");

            OnCreateSettingsConfiguration(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration>(response);
        }

        partial void OnDeleteSettingsConfiguration(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteSettingsConfiguration(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"SettingsConfigurations({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteSettingsConfiguration(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetSettingsConfigurationByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration> GetSettingsConfigurationByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"SettingsConfigurations({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSettingsConfigurationByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration>(response);
        }

        partial void OnUpdateSettingsConfiguration(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateSettingsConfiguration(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration settingsConfiguration = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration))
        {
            var uri = new Uri(baseUri, $"SettingsConfigurations({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(settingsConfiguration), Encoding.UTF8, "application/json");

            OnUpdateSettingsConfiguration(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportSettingsContactsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/settingscontacts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/settingscontacts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportSettingsContactsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/settingscontacts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/settingscontacts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetSettingsContacts(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact>> GetSettingsContacts(Query query)
        {
            return await GetSettingsContacts(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact>> GetSettingsContacts(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"SettingsContacts");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSettingsContacts(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact>>(response);
        }

        partial void OnCreateSettingsContact(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact> CreateSettingsContact(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact settingsContact = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact))
        {
            var uri = new Uri(baseUri, $"SettingsContacts");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(settingsContact), Encoding.UTF8, "application/json");

            OnCreateSettingsContact(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact>(response);
        }

        partial void OnDeleteSettingsContact(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteSettingsContact(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"SettingsContacts({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteSettingsContact(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetSettingsContactByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact> GetSettingsContactByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"SettingsContacts({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSettingsContactByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact>(response);
        }

        partial void OnUpdateSettingsContact(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateSettingsContact(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact settingsContact = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact))
        {
            var uri = new Uri(baseUri, $"SettingsContacts({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(settingsContact), Encoding.UTF8, "application/json");

            OnUpdateSettingsContact(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblCrossReferencesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/tblcrossreferences/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/tblcrossreferences/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblCrossReferencesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/tblcrossreferences/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/tblcrossreferences/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblCrossReferences(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference>> GetTblCrossReferences(Query query)
        {
            return await GetTblCrossReferences(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference>> GetTblCrossReferences(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblCrossReferences");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCrossReferences(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference>>(response);
        }

        partial void OnCreateTblCrossReference(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference> CreateTblCrossReference(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference tblCrossReference = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference))
        {
            var uri = new Uri(baseUri, $"TblCrossReferences");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCrossReference), Encoding.UTF8, "application/json");

            OnCreateTblCrossReference(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference>(response);
        }

        partial void OnDeleteTblCrossReference(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblCrossReference(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCrossReferences({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblCrossReference(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblCrossReferenceByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference> GetTblCrossReferenceByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCrossReferences({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCrossReferenceByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference>(response);
        }

        partial void OnUpdateTblCrossReference(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblCrossReference(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference tblCrossReference = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference))
        {
            var uri = new Uri(baseUri, $"TblCrossReferences({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCrossReference), Encoding.UTF8, "application/json");

            OnUpdateTblCrossReference(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnSpGetBillingDetailsByDateByAccounts(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> SpGetBillingDetailsByDateByAccounts(string startDate = default(string), string endDate = default(string), string dealerCloud = default(string), string brand = default(string), string subBrand = default(string), bool? forPublication = default(bool?), bool? showZeroPriceTrans = default(bool?), bool? showDetails = default(bool?), bool? saveDatatoTemporaryTable = default(bool?))
        {
            var uri = new Uri(baseUri, $"SpGetBillingDetailsByDateByAccountsFunc(StartDate='{Uri.EscapeDataString(startDate.Trim().Replace("'", "''"))}',EndDate='{Uri.EscapeDataString(endDate.Trim().Replace("'", "''"))}',DealerCloud='{Uri.EscapeDataString(dealerCloud.Trim().Replace("'", "''"))}',Brand='{Uri.EscapeDataString(brand.Trim().Replace("'", "''"))}',SubBrand='{Uri.EscapeDataString(subBrand.Trim().Replace("'", "''"))}',ForPublication={forPublication?.ToString().ToLower()},ShowZeroPriceTrans={showZeroPriceTrans?.ToString().ToLower()},ShowDetails={showDetails?.ToString().ToLower()},SaveDatatoTemporaryTable={saveDatatoTemporaryTable?.ToString().ToLower()})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnSpGetBillingDetailsByDateByAccounts(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnSpGetGeocodeByAddressOrPlaces(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> SpGetGeocodeByAddressOrPlaces(string apikey = default(string), string address = default(string), string city = default(string), string state = default(string), string country = default(string), string postalCode = default(string), string county = default(string), decimal? gpslatitude = default(decimal?), decimal? gpslongitude = default(decimal?), string mapUrl = default(string), string placeId = default(string))
        {
            var uri = new Uri(baseUri, $"SpGetGeocodeByAddressOrPlacesFunc(APIkey='{Uri.EscapeDataString(apikey.Trim().Replace("'", "''"))}',Address='{Uri.EscapeDataString(address.Trim().Replace("'", "''"))}',City='{Uri.EscapeDataString(city.Trim().Replace("'", "''"))}',State='{Uri.EscapeDataString(state.Trim().Replace("'", "''"))}',Country='{Uri.EscapeDataString(country.Trim().Replace("'", "''"))}',PostalCode='{Uri.EscapeDataString(postalCode.Trim().Replace("'", "''"))}',County='{Uri.EscapeDataString(county.Trim().Replace("'", "''"))}',GPSLatitude={gpslatitude},GPSLongitude={gpslongitude},MapURL='{Uri.EscapeDataString(mapUrl.Trim().Replace("'", "''"))}',PlaceID='{Uri.EscapeDataString(placeId.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnSpGetGeocodeByAddressOrPlaces(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnSpInsertDataFromXebras(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> SpInsertDataFromXebras()
        {
            var uri = new Uri(baseUri, $"SpInsertDataFromXebrasFunc()");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnSpInsertDataFromXebras(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}