
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
    public partial class Throttle_Core_CustomerService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;

        public Throttle_Core_CustomerService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/Throttle_Core_Customer/");
        }


        public async System.Threading.Tasks.Task ExportTblCustomersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblCustomersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblCustomers(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer>> GetTblCustomers(Query query)
        {
            return await GetTblCustomers(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer>> GetTblCustomers(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblCustomers");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomers(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer>>(response);
        }

        partial void OnCreateTblCustomer(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer> CreateTblCustomer(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer tblCustomer = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer))
        {
            var uri = new Uri(baseUri, $"TblCustomers");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomer), Encoding.UTF8, "application/json");

            OnCreateTblCustomer(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer>(response);
        }

        partial void OnDeleteTblCustomer(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblCustomer(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomers({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblCustomer(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblCustomerByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer> GetTblCustomerByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomers({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer>(response);
        }

        partial void OnUpdateTblCustomer(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblCustomer(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer tblCustomer = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer))
        {
            var uri = new Uri(baseUri, $"TblCustomers({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomer), Encoding.UTF8, "application/json");

            OnUpdateTblCustomer(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerBrandsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerbrands/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerbrands/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerBrandsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerbrands/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerbrands/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblCustomerBrands(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand>> GetTblCustomerBrands(Query query)
        {
            return await GetTblCustomerBrands(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand>> GetTblCustomerBrands(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblCustomerBrands");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerBrands(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand>>(response);
        }

        partial void OnCreateTblCustomerBrand(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand> CreateTblCustomerBrand(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand tblCustomerBrand = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand))
        {
            var uri = new Uri(baseUri, $"TblCustomerBrands");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerBrand), Encoding.UTF8, "application/json");

            OnCreateTblCustomerBrand(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand>(response);
        }

        partial void OnDeleteTblCustomerBrand(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblCustomerBrand(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerBrands({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblCustomerBrand(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblCustomerBrandByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand> GetTblCustomerBrandByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerBrands({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerBrandByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand>(response);
        }

        partial void OnUpdateTblCustomerBrand(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblCustomerBrand(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand tblCustomerBrand = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand))
        {
            var uri = new Uri(baseUri, $"TblCustomerBrands({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerBrand), Encoding.UTF8, "application/json");

            OnUpdateTblCustomerBrand(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerBrandsStoresJoinsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerbrandsstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerbrandsstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerBrandsStoresJoinsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerbrandsstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerbrandsstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblCustomerBrandsStoresJoins(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin>> GetTblCustomerBrandsStoresJoins(Query query)
        {
            return await GetTblCustomerBrandsStoresJoins(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin>> GetTblCustomerBrandsStoresJoins(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblCustomerBrandsStoresJoins");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerBrandsStoresJoins(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin>>(response);
        }

        partial void OnCreateTblCustomerBrandsStoresJoin(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin> CreateTblCustomerBrandsStoresJoin(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin tblCustomerBrandsStoresJoin = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin))
        {
            var uri = new Uri(baseUri, $"TblCustomerBrandsStoresJoins");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerBrandsStoresJoin), Encoding.UTF8, "application/json");

            OnCreateTblCustomerBrandsStoresJoin(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin>(response);
        }

        partial void OnDeleteTblCustomerBrandsStoresJoin(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblCustomerBrandsStoresJoin(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerBrandsStoresJoins({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblCustomerBrandsStoresJoin(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblCustomerBrandsStoresJoinByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin> GetTblCustomerBrandsStoresJoinByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerBrandsStoresJoins({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerBrandsStoresJoinByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin>(response);
        }

        partial void OnUpdateTblCustomerBrandsStoresJoin(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblCustomerBrandsStoresJoin(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin tblCustomerBrandsStoresJoin = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin))
        {
            var uri = new Uri(baseUri, $"TblCustomerBrandsStoresJoins({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerBrandsStoresJoin), Encoding.UTF8, "application/json");

            OnUpdateTblCustomerBrandsStoresJoin(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerContactsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomercontacts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomercontacts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerContactsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomercontacts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomercontacts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblCustomerContacts(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact>> GetTblCustomerContacts(Query query)
        {
            return await GetTblCustomerContacts(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact>> GetTblCustomerContacts(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblCustomerContacts");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerContacts(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact>>(response);
        }

        partial void OnCreateTblCustomerContact(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact> CreateTblCustomerContact(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact tblCustomerContact = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact))
        {
            var uri = new Uri(baseUri, $"TblCustomerContacts");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerContact), Encoding.UTF8, "application/json");

            OnCreateTblCustomerContact(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact>(response);
        }

        partial void OnDeleteTblCustomerContact(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblCustomerContact(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerContacts({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblCustomerContact(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblCustomerContactByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact> GetTblCustomerContactByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerContacts({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerContactByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact>(response);
        }

        partial void OnUpdateTblCustomerContact(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblCustomerContact(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact tblCustomerContact = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact))
        {
            var uri = new Uri(baseUri, $"TblCustomerContacts({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerContact), Encoding.UTF8, "application/json");

            OnUpdateTblCustomerContact(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerContactsStoresJoinsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomercontactsstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomercontactsstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerContactsStoresJoinsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomercontactsstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomercontactsstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblCustomerContactsStoresJoins(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin>> GetTblCustomerContactsStoresJoins(Query query)
        {
            return await GetTblCustomerContactsStoresJoins(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin>> GetTblCustomerContactsStoresJoins(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblCustomerContactsStoresJoins");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerContactsStoresJoins(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin>>(response);
        }

        partial void OnCreateTblCustomerContactsStoresJoin(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin> CreateTblCustomerContactsStoresJoin(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin tblCustomerContactsStoresJoin = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin))
        {
            var uri = new Uri(baseUri, $"TblCustomerContactsStoresJoins");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerContactsStoresJoin), Encoding.UTF8, "application/json");

            OnCreateTblCustomerContactsStoresJoin(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin>(response);
        }

        partial void OnDeleteTblCustomerContactsStoresJoin(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblCustomerContactsStoresJoin(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerContactsStoresJoins({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblCustomerContactsStoresJoin(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblCustomerContactsStoresJoinByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin> GetTblCustomerContactsStoresJoinByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerContactsStoresJoins({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerContactsStoresJoinByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin>(response);
        }

        partial void OnUpdateTblCustomerContactsStoresJoin(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblCustomerContactsStoresJoin(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin tblCustomerContactsStoresJoin = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin))
        {
            var uri = new Uri(baseUri, $"TblCustomerContactsStoresJoins({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerContactsStoresJoin), Encoding.UTF8, "application/json");

            OnUpdateTblCustomerContactsStoresJoin(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerFranchisesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerfranchises/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerfranchises/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerFranchisesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerfranchises/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerfranchises/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblCustomerFranchises(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise>> GetTblCustomerFranchises(Query query)
        {
            return await GetTblCustomerFranchises(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise>> GetTblCustomerFranchises(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblCustomerFranchises");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerFranchises(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise>>(response);
        }

        partial void OnCreateTblCustomerFranchise(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise> CreateTblCustomerFranchise(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise tblCustomerFranchise = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise))
        {
            var uri = new Uri(baseUri, $"TblCustomerFranchises");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerFranchise), Encoding.UTF8, "application/json");

            OnCreateTblCustomerFranchise(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise>(response);
        }

        partial void OnDeleteTblCustomerFranchise(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblCustomerFranchise(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerFranchises({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblCustomerFranchise(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblCustomerFranchiseByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise> GetTblCustomerFranchiseByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerFranchises({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerFranchiseByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise>(response);
        }

        partial void OnUpdateTblCustomerFranchise(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblCustomerFranchise(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise tblCustomerFranchise = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise))
        {
            var uri = new Uri(baseUri, $"TblCustomerFranchises({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerFranchise), Encoding.UTF8, "application/json");

            OnUpdateTblCustomerFranchise(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerFranchisesStoresJoinsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerfranchisesstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerfranchisesstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerFranchisesStoresJoinsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerfranchisesstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerfranchisesstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblCustomerFranchisesStoresJoins(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin>> GetTblCustomerFranchisesStoresJoins(Query query)
        {
            return await GetTblCustomerFranchisesStoresJoins(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin>> GetTblCustomerFranchisesStoresJoins(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblCustomerFranchisesStoresJoins");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerFranchisesStoresJoins(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin>>(response);
        }

        partial void OnCreateTblCustomerFranchisesStoresJoin(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin> CreateTblCustomerFranchisesStoresJoin(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin tblCustomerFranchisesStoresJoin = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin))
        {
            var uri = new Uri(baseUri, $"TblCustomerFranchisesStoresJoins");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerFranchisesStoresJoin), Encoding.UTF8, "application/json");

            OnCreateTblCustomerFranchisesStoresJoin(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin>(response);
        }

        partial void OnDeleteTblCustomerFranchisesStoresJoin(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblCustomerFranchisesStoresJoin(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerFranchisesStoresJoins({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblCustomerFranchisesStoresJoin(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblCustomerFranchisesStoresJoinByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin> GetTblCustomerFranchisesStoresJoinByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerFranchisesStoresJoins({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerFranchisesStoresJoinByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin>(response);
        }

        partial void OnUpdateTblCustomerFranchisesStoresJoin(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblCustomerFranchisesStoresJoin(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin tblCustomerFranchisesStoresJoin = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin))
        {
            var uri = new Uri(baseUri, $"TblCustomerFranchisesStoresJoins({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerFranchisesStoresJoin), Encoding.UTF8, "application/json");

            OnUpdateTblCustomerFranchisesStoresJoin(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerGroupsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomergroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomergroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerGroupsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomergroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomergroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblCustomerGroups(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup>> GetTblCustomerGroups(Query query)
        {
            return await GetTblCustomerGroups(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup>> GetTblCustomerGroups(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblCustomerGroups");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerGroups(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup>>(response);
        }

        partial void OnCreateTblCustomerGroup(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup> CreateTblCustomerGroup(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup tblCustomerGroup = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup))
        {
            var uri = new Uri(baseUri, $"TblCustomerGroups");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerGroup), Encoding.UTF8, "application/json");

            OnCreateTblCustomerGroup(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup>(response);
        }

        partial void OnDeleteTblCustomerGroup(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblCustomerGroup(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerGroups({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblCustomerGroup(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblCustomerGroupByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup> GetTblCustomerGroupByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerGroups({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerGroupByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup>(response);
        }

        partial void OnUpdateTblCustomerGroup(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblCustomerGroup(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup tblCustomerGroup = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup))
        {
            var uri = new Uri(baseUri, $"TblCustomerGroups({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerGroup), Encoding.UTF8, "application/json");

            OnUpdateTblCustomerGroup(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerGroupsStoresJoinsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomergroupsstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomergroupsstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerGroupsStoresJoinsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomergroupsstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomergroupsstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblCustomerGroupsStoresJoins(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin>> GetTblCustomerGroupsStoresJoins(Query query)
        {
            return await GetTblCustomerGroupsStoresJoins(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin>> GetTblCustomerGroupsStoresJoins(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblCustomerGroupsStoresJoins");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerGroupsStoresJoins(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin>>(response);
        }

        partial void OnCreateTblCustomerGroupsStoresJoin(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin> CreateTblCustomerGroupsStoresJoin(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin tblCustomerGroupsStoresJoin = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin))
        {
            var uri = new Uri(baseUri, $"TblCustomerGroupsStoresJoins");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerGroupsStoresJoin), Encoding.UTF8, "application/json");

            OnCreateTblCustomerGroupsStoresJoin(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin>(response);
        }

        partial void OnDeleteTblCustomerGroupsStoresJoin(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblCustomerGroupsStoresJoin(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerGroupsStoresJoins({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblCustomerGroupsStoresJoin(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblCustomerGroupsStoresJoinByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin> GetTblCustomerGroupsStoresJoinByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerGroupsStoresJoins({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerGroupsStoresJoinByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin>(response);
        }

        partial void OnUpdateTblCustomerGroupsStoresJoin(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblCustomerGroupsStoresJoin(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin tblCustomerGroupsStoresJoin = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin))
        {
            var uri = new Uri(baseUri, $"TblCustomerGroupsStoresJoins({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerGroupsStoresJoin), Encoding.UTF8, "application/json");

            OnUpdateTblCustomerGroupsStoresJoin(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerIndustriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerindustries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerindustries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerIndustriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerindustries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerindustries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblCustomerIndustries(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry>> GetTblCustomerIndustries(Query query)
        {
            return await GetTblCustomerIndustries(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry>> GetTblCustomerIndustries(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblCustomerIndustries");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerIndustries(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry>>(response);
        }

        partial void OnCreateTblCustomerIndustry(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry> CreateTblCustomerIndustry(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry tblCustomerIndustry = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry))
        {
            var uri = new Uri(baseUri, $"TblCustomerIndustries");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerIndustry), Encoding.UTF8, "application/json");

            OnCreateTblCustomerIndustry(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry>(response);
        }

        partial void OnDeleteTblCustomerIndustry(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblCustomerIndustry(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerIndustries({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblCustomerIndustry(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblCustomerIndustryByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry> GetTblCustomerIndustryByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerIndustries({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerIndustryByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry>(response);
        }

        partial void OnUpdateTblCustomerIndustry(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblCustomerIndustry(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry tblCustomerIndustry = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry))
        {
            var uri = new Uri(baseUri, $"TblCustomerIndustries({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerIndustry), Encoding.UTF8, "application/json");

            OnUpdateTblCustomerIndustry(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerIndustryStoresJoinsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerindustrystoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerindustrystoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerIndustryStoresJoinsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerindustrystoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerindustrystoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblCustomerIndustryStoresJoins(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin>> GetTblCustomerIndustryStoresJoins(Query query)
        {
            return await GetTblCustomerIndustryStoresJoins(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin>> GetTblCustomerIndustryStoresJoins(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblCustomerIndustryStoresJoins");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerIndustryStoresJoins(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin>>(response);
        }

        partial void OnCreateTblCustomerIndustryStoresJoin(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin> CreateTblCustomerIndustryStoresJoin(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin tblCustomerIndustryStoresJoin = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin))
        {
            var uri = new Uri(baseUri, $"TblCustomerIndustryStoresJoins");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerIndustryStoresJoin), Encoding.UTF8, "application/json");

            OnCreateTblCustomerIndustryStoresJoin(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin>(response);
        }

        partial void OnDeleteTblCustomerIndustryStoresJoin(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblCustomerIndustryStoresJoin(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerIndustryStoresJoins({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblCustomerIndustryStoresJoin(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblCustomerIndustryStoresJoinByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin> GetTblCustomerIndustryStoresJoinByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerIndustryStoresJoins({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerIndustryStoresJoinByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin>(response);
        }

        partial void OnUpdateTblCustomerIndustryStoresJoin(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblCustomerIndustryStoresJoin(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin tblCustomerIndustryStoresJoin = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin))
        {
            var uri = new Uri(baseUri, $"TblCustomerIndustryStoresJoins({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerIndustryStoresJoin), Encoding.UTF8, "application/json");

            OnUpdateTblCustomerIndustryStoresJoin(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerProductandServicesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerproductandservices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerproductandservices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerProductandServicesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerproductandservices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerproductandservices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblCustomerProductandServices(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService>> GetTblCustomerProductandServices(Query query)
        {
            return await GetTblCustomerProductandServices(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService>> GetTblCustomerProductandServices(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblCustomerProductandServices");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerProductandServices(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService>>(response);
        }

        partial void OnCreateTblCustomerProductandService(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService> CreateTblCustomerProductandService(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService tblCustomerProductandService = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService))
        {
            var uri = new Uri(baseUri, $"TblCustomerProductandServices");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerProductandService), Encoding.UTF8, "application/json");

            OnCreateTblCustomerProductandService(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService>(response);
        }

        partial void OnDeleteTblCustomerProductandService(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblCustomerProductandService(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerProductandServices({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblCustomerProductandService(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblCustomerProductandServiceByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService> GetTblCustomerProductandServiceByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerProductandServices({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerProductandServiceByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService>(response);
        }

        partial void OnUpdateTblCustomerProductandService(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblCustomerProductandService(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService tblCustomerProductandService = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService))
        {
            var uri = new Uri(baseUri, $"TblCustomerProductandServices({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerProductandService), Encoding.UTF8, "application/json");

            OnUpdateTblCustomerProductandService(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerProductandServicesStoresJoinsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerproductandservicesstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerproductandservicesstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerProductandServicesStoresJoinsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerproductandservicesstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerproductandservicesstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblCustomerProductandServicesStoresJoins(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin>> GetTblCustomerProductandServicesStoresJoins(Query query)
        {
            return await GetTblCustomerProductandServicesStoresJoins(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin>> GetTblCustomerProductandServicesStoresJoins(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblCustomerProductandServicesStoresJoins");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerProductandServicesStoresJoins(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin>>(response);
        }

        partial void OnCreateTblCustomerProductandServicesStoresJoin(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin> CreateTblCustomerProductandServicesStoresJoin(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin tblCustomerProductandServicesStoresJoin = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin))
        {
            var uri = new Uri(baseUri, $"TblCustomerProductandServicesStoresJoins");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerProductandServicesStoresJoin), Encoding.UTF8, "application/json");

            OnCreateTblCustomerProductandServicesStoresJoin(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin>(response);
        }

        partial void OnDeleteTblCustomerProductandServicesStoresJoin(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblCustomerProductandServicesStoresJoin(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerProductandServicesStoresJoins({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblCustomerProductandServicesStoresJoin(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblCustomerProductandServicesStoresJoinByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin> GetTblCustomerProductandServicesStoresJoinByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerProductandServicesStoresJoins({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerProductandServicesStoresJoinByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin>(response);
        }

        partial void OnUpdateTblCustomerProductandServicesStoresJoin(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblCustomerProductandServicesStoresJoin(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin tblCustomerProductandServicesStoresJoin = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin))
        {
            var uri = new Uri(baseUri, $"TblCustomerProductandServicesStoresJoins({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerProductandServicesStoresJoin), Encoding.UTF8, "application/json");

            OnUpdateTblCustomerProductandServicesStoresJoin(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerStoresToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerstores/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerstores/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblCustomerStoresToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerstores/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerstores/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblCustomerStores(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore>> GetTblCustomerStores(Query query)
        {
            return await GetTblCustomerStores(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore>> GetTblCustomerStores(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblCustomerStores");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerStores(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore>>(response);
        }

        partial void OnCreateTblCustomerStore(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore> CreateTblCustomerStore(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore tblCustomerStore = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore))
        {
            var uri = new Uri(baseUri, $"TblCustomerStores");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerStore), Encoding.UTF8, "application/json");

            OnCreateTblCustomerStore(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore>(response);
        }

        partial void OnDeleteTblCustomerStore(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblCustomerStore(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerStores({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblCustomerStore(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblCustomerStoreByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore> GetTblCustomerStoreByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblCustomerStores({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblCustomerStoreByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore>(response);
        }

        partial void OnUpdateTblCustomerStore(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblCustomerStore(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore tblCustomerStore = default(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore))
        {
            var uri = new Uri(baseUri, $"TblCustomerStores({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblCustomerStore), Encoding.UTF8, "application/json");

            OnUpdateTblCustomerStore(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}