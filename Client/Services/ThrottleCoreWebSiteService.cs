
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
    public partial class Throttle_Core_WebSiteService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;

        public Throttle_Core_WebSiteService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/Throttle_Core_WebSite/");
        }


        public async System.Threading.Tasks.Task ExportContactsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/contacts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/contacts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportContactsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/contacts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/contacts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetContacts(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact>> GetContacts(Query query)
        {
            return await GetContacts(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact>> GetContacts(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Contacts");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetContacts(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact>>(response);
        }

        partial void OnCreateContact(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact> CreateContact(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact contact = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact))
        {
            var uri = new Uri(baseUri, $"Contacts");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(contact), Encoding.UTF8, "application/json");

            OnCreateContact(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact>(response);
        }

        partial void OnDeleteContact(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteContact(int id = default(int))
        {
            var uri = new Uri(baseUri, $"Contacts({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteContact(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetContactById(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact> GetContactById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"Contacts({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetContactById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact>(response);
        }

        partial void OnUpdateContact(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateContact(int id = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact contact = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact))
        {
            var uri = new Uri(baseUri, $"Contacts({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(contact), Encoding.UTF8, "application/json");

            OnUpdateContact(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportDepartmentsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/departments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/departments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDepartmentsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/departments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/departments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetDepartments(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department>> GetDepartments(Query query)
        {
            return await GetDepartments(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department>> GetDepartments(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Departments");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDepartments(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department>>(response);
        }

        partial void OnCreateDepartment(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department> CreateDepartment(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department department = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department))
        {
            var uri = new Uri(baseUri, $"Departments");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(department), Encoding.UTF8, "application/json");

            OnCreateDepartment(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department>(response);
        }

        partial void OnDeleteDepartment(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteDepartment(int id = default(int))
        {
            var uri = new Uri(baseUri, $"Departments({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteDepartment(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetDepartmentById(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department> GetDepartmentById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"Departments({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDepartmentById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department>(response);
        }

        partial void OnUpdateDepartment(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateDepartment(int id = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department department = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department))
        {
            var uri = new Uri(baseUri, $"Departments({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(department), Encoding.UTF8, "application/json");

            OnUpdateDepartment(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportEmployeesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/employees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/employees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportEmployeesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/employees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/employees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetEmployees(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee>> GetEmployees(Query query)
        {
            return await GetEmployees(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee>> GetEmployees(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Employees");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEmployees(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee>>(response);
        }

        partial void OnCreateEmployee(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee> CreateEmployee(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee employee = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee))
        {
            var uri = new Uri(baseUri, $"Employees");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            OnCreateEmployee(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee>(response);
        }

        partial void OnDeleteEmployee(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteEmployee(int id = default(int))
        {
            var uri = new Uri(baseUri, $"Employees({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteEmployee(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetEmployeeById(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee> GetEmployeeById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"Employees({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEmployeeById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee>(response);
        }

        partial void OnUpdateEmployee(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateEmployee(int id = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee employee = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee))
        {
            var uri = new Uri(baseUri, $"Employees({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            OnUpdateEmployee(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportOpportunitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/opportunities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/opportunities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportOpportunitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/opportunities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/opportunities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetOpportunities(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity>> GetOpportunities(Query query)
        {
            return await GetOpportunities(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity>> GetOpportunities(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Opportunities");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetOpportunities(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity>>(response);
        }

        partial void OnCreateOpportunity(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity> CreateOpportunity(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity opportunity = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity))
        {
            var uri = new Uri(baseUri, $"Opportunities");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(opportunity), Encoding.UTF8, "application/json");

            OnCreateOpportunity(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity>(response);
        }

        partial void OnDeleteOpportunity(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteOpportunity(int id = default(int))
        {
            var uri = new Uri(baseUri, $"Opportunities({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteOpportunity(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetOpportunityById(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity> GetOpportunityById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"Opportunities({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetOpportunityById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity>(response);
        }

        partial void OnUpdateOpportunity(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateOpportunity(int id = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity opportunity = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity))
        {
            var uri = new Uri(baseUri, $"Opportunities({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(opportunity), Encoding.UTF8, "application/json");

            OnUpdateOpportunity(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportOpportunityStatusesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/opportunitystatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/opportunitystatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportOpportunityStatusesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/opportunitystatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/opportunitystatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetOpportunityStatuses(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus>> GetOpportunityStatuses(Query query)
        {
            return await GetOpportunityStatuses(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus>> GetOpportunityStatuses(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"OpportunityStatuses");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetOpportunityStatuses(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus>>(response);
        }

        partial void OnCreateOpportunityStatus(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus> CreateOpportunityStatus(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus opportunityStatus = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus))
        {
            var uri = new Uri(baseUri, $"OpportunityStatuses");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(opportunityStatus), Encoding.UTF8, "application/json");

            OnCreateOpportunityStatus(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus>(response);
        }

        partial void OnDeleteOpportunityStatus(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteOpportunityStatus(int id = default(int))
        {
            var uri = new Uri(baseUri, $"OpportunityStatuses({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteOpportunityStatus(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetOpportunityStatusById(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus> GetOpportunityStatusById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"OpportunityStatuses({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetOpportunityStatusById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus>(response);
        }

        partial void OnUpdateOpportunityStatus(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateOpportunityStatus(int id = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus opportunityStatus = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus))
        {
            var uri = new Uri(baseUri, $"OpportunityStatuses({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(opportunityStatus), Encoding.UTF8, "application/json");

            OnUpdateOpportunityStatus(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTasksToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tasks/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tasks/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTasksToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tasks/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tasks/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTasks(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task>> GetTasks(Query query)
        {
            return await GetTasks(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task>> GetTasks(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Tasks");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTasks(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task>>(response);
        }

        partial void OnCreateTask(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task> CreateTask(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task task = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task))
        {
            var uri = new Uri(baseUri, $"Tasks");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(task), Encoding.UTF8, "application/json");

            OnCreateTask(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task>(response);
        }

        partial void OnDeleteTask(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTask(int id = default(int))
        {
            var uri = new Uri(baseUri, $"Tasks({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTask(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTaskById(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task> GetTaskById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"Tasks({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTaskById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task>(response);
        }

        partial void OnUpdateTask(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTask(int id = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task task = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task))
        {
            var uri = new Uri(baseUri, $"Tasks({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(task), Encoding.UTF8, "application/json");

            OnUpdateTask(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTaskStatusesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/taskstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/taskstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTaskStatusesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/taskstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/taskstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTaskStatuses(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus>> GetTaskStatuses(Query query)
        {
            return await GetTaskStatuses(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus>> GetTaskStatuses(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TaskStatuses");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTaskStatuses(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus>>(response);
        }

        partial void OnCreateTaskStatus(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus> CreateTaskStatus(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus taskStatus = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus))
        {
            var uri = new Uri(baseUri, $"TaskStatuses");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(taskStatus), Encoding.UTF8, "application/json");

            OnCreateTaskStatus(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus>(response);
        }

        partial void OnDeleteTaskStatus(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTaskStatus(int id = default(int))
        {
            var uri = new Uri(baseUri, $"TaskStatuses({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTaskStatus(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTaskStatusById(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus> GetTaskStatusById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"TaskStatuses({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTaskStatusById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus>(response);
        }

        partial void OnUpdateTaskStatus(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTaskStatus(int id = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus taskStatus = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus))
        {
            var uri = new Uri(baseUri, $"TaskStatuses({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(taskStatus), Encoding.UTF8, "application/json");

            OnUpdateTaskStatus(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTaskTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tasktypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tasktypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTaskTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tasktypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tasktypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTaskTypes(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType>> GetTaskTypes(Query query)
        {
            return await GetTaskTypes(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType>> GetTaskTypes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TaskTypes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTaskTypes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType>>(response);
        }

        partial void OnCreateTaskType(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType> CreateTaskType(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType taskType = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType))
        {
            var uri = new Uri(baseUri, $"TaskTypes");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(taskType), Encoding.UTF8, "application/json");

            OnCreateTaskType(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType>(response);
        }

        partial void OnDeleteTaskType(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTaskType(int id = default(int))
        {
            var uri = new Uri(baseUri, $"TaskTypes({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTaskType(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTaskTypeById(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType> GetTaskTypeById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"TaskTypes({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTaskTypeById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType>(response);
        }

        partial void OnUpdateTaskType(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTaskType(int id = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType taskType = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType))
        {
            var uri = new Uri(baseUri, $"TaskTypes({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(taskType), Encoding.UTF8, "application/json");

            OnUpdateTaskType(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblDatabasesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tbldatabases/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tbldatabases/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblDatabasesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tbldatabases/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tbldatabases/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblDatabases(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase>> GetTblDatabases(Query query)
        {
            return await GetTblDatabases(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase>> GetTblDatabases(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblDatabases");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDatabases(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase>>(response);
        }

        partial void OnCreateTblDatabase(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase> CreateTblDatabase(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase tblDatabase = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase))
        {
            var uri = new Uri(baseUri, $"TblDatabases");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDatabase), Encoding.UTF8, "application/json");

            OnCreateTblDatabase(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase>(response);
        }

        partial void OnDeleteTblDatabase(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblDatabase(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDatabases({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblDatabase(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblDatabaseByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase> GetTblDatabaseByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblDatabases({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblDatabaseByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase>(response);
        }

        partial void OnUpdateTblDatabase(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblDatabase(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase tblDatabase = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase))
        {
            var uri = new Uri(baseUri, $"TblDatabases({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblDatabase), Encoding.UTF8, "application/json");

            OnUpdateTblDatabase(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblWebSiteErrorDescriptionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsiteerrordescriptions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsiteerrordescriptions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblWebSiteErrorDescriptionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsiteerrordescriptions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsiteerrordescriptions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblWebSiteErrorDescriptions(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription>> GetTblWebSiteErrorDescriptions(Query query)
        {
            return await GetTblWebSiteErrorDescriptions(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription>> GetTblWebSiteErrorDescriptions(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblWebSiteErrorDescriptions");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblWebSiteErrorDescriptions(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription>>(response);
        }

        partial void OnCreateTblWebSiteErrorDescription(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription> CreateTblWebSiteErrorDescription(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription tblWebSiteErrorDescription = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription))
        {
            var uri = new Uri(baseUri, $"TblWebSiteErrorDescriptions");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblWebSiteErrorDescription), Encoding.UTF8, "application/json");

            OnCreateTblWebSiteErrorDescription(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription>(response);
        }

        partial void OnDeleteTblWebSiteErrorDescription(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblWebSiteErrorDescription(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblWebSiteErrorDescriptions({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblWebSiteErrorDescription(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblWebSiteErrorDescriptionByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription> GetTblWebSiteErrorDescriptionByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblWebSiteErrorDescriptions({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblWebSiteErrorDescriptionByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription>(response);
        }

        partial void OnUpdateTblWebSiteErrorDescription(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblWebSiteErrorDescription(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription tblWebSiteErrorDescription = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription))
        {
            var uri = new Uri(baseUri, $"TblWebSiteErrorDescriptions({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblWebSiteErrorDescription), Encoding.UTF8, "application/json");

            OnUpdateTblWebSiteErrorDescription(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblWebSiteLanguagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsitelanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsitelanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblWebSiteLanguagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsitelanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsitelanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblWebSiteLanguages(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage>> GetTblWebSiteLanguages(Query query)
        {
            return await GetTblWebSiteLanguages(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage>> GetTblWebSiteLanguages(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblWebSiteLanguages");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblWebSiteLanguages(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage>>(response);
        }

        partial void OnCreateTblWebSiteLanguage(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage> CreateTblWebSiteLanguage(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage tblWebSiteLanguage = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage))
        {
            var uri = new Uri(baseUri, $"TblWebSiteLanguages");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblWebSiteLanguage), Encoding.UTF8, "application/json");

            OnCreateTblWebSiteLanguage(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage>(response);
        }

        partial void OnDeleteTblWebSiteLanguage(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblWebSiteLanguage(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblWebSiteLanguages({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblWebSiteLanguage(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblWebSiteLanguageByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage> GetTblWebSiteLanguageByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblWebSiteLanguages({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblWebSiteLanguageByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage>(response);
        }

        partial void OnUpdateTblWebSiteLanguage(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblWebSiteLanguage(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage tblWebSiteLanguage = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage))
        {
            var uri = new Uri(baseUri, $"TblWebSiteLanguages({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblWebSiteLanguage), Encoding.UTF8, "application/json");

            OnUpdateTblWebSiteLanguage(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblWebSiteMenusToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsitemenus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsitemenus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblWebSiteMenusToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsitemenus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsitemenus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblWebSiteMenus(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu>> GetTblWebSiteMenus(Query query)
        {
            return await GetTblWebSiteMenus(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu>> GetTblWebSiteMenus(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblWebSiteMenus");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblWebSiteMenus(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu>>(response);
        }

        partial void OnCreateTblWebSiteMenu(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu> CreateTblWebSiteMenu(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu tblWebSiteMenu = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu))
        {
            var uri = new Uri(baseUri, $"TblWebSiteMenus");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblWebSiteMenu), Encoding.UTF8, "application/json");

            OnCreateTblWebSiteMenu(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu>(response);
        }

        partial void OnDeleteTblWebSiteMenu(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblWebSiteMenu(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblWebSiteMenus({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblWebSiteMenu(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblWebSiteMenuByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu> GetTblWebSiteMenuByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblWebSiteMenus({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblWebSiteMenuByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu>(response);
        }

        partial void OnUpdateTblWebSiteMenu(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblWebSiteMenu(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu tblWebSiteMenu = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu))
        {
            var uri = new Uri(baseUri, $"TblWebSiteMenus({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblWebSiteMenu), Encoding.UTF8, "application/json");

            OnUpdateTblWebSiteMenu(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblWebSiteSecurityGroupsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsitesecuritygroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsitesecuritygroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblWebSiteSecurityGroupsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsitesecuritygroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsitesecuritygroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblWebSiteSecurityGroups(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup>> GetTblWebSiteSecurityGroups(Query query)
        {
            return await GetTblWebSiteSecurityGroups(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup>> GetTblWebSiteSecurityGroups(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblWebSiteSecurityGroups");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblWebSiteSecurityGroups(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup>>(response);
        }

        partial void OnCreateTblWebSiteSecurityGroup(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup> CreateTblWebSiteSecurityGroup(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup tblWebSiteSecurityGroup = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup))
        {
            var uri = new Uri(baseUri, $"TblWebSiteSecurityGroups");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblWebSiteSecurityGroup), Encoding.UTF8, "application/json");

            OnCreateTblWebSiteSecurityGroup(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup>(response);
        }

        partial void OnDeleteTblWebSiteSecurityGroup(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblWebSiteSecurityGroup(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblWebSiteSecurityGroups({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblWebSiteSecurityGroup(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblWebSiteSecurityGroupByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup> GetTblWebSiteSecurityGroupByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblWebSiteSecurityGroups({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblWebSiteSecurityGroupByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup>(response);
        }

        partial void OnUpdateTblWebSiteSecurityGroup(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblWebSiteSecurityGroup(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup tblWebSiteSecurityGroup = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup))
        {
            var uri = new Uri(baseUri, $"TblWebSiteSecurityGroups({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblWebSiteSecurityGroup), Encoding.UTF8, "application/json");

            OnUpdateTblWebSiteSecurityGroup(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblWebSiteSecuritySettingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsitesecuritysettings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsitesecuritysettings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblWebSiteSecuritySettingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsitesecuritysettings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsitesecuritysettings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblWebSiteSecuritySettings(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting>> GetTblWebSiteSecuritySettings(Query query)
        {
            return await GetTblWebSiteSecuritySettings(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting>> GetTblWebSiteSecuritySettings(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblWebSiteSecuritySettings");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblWebSiteSecuritySettings(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting>>(response);
        }

        partial void OnCreateTblWebSiteSecuritySetting(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting> CreateTblWebSiteSecuritySetting(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting tblWebSiteSecuritySetting = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting))
        {
            var uri = new Uri(baseUri, $"TblWebSiteSecuritySettings");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblWebSiteSecuritySetting), Encoding.UTF8, "application/json");

            OnCreateTblWebSiteSecuritySetting(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting>(response);
        }

        partial void OnDeleteTblWebSiteSecuritySetting(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblWebSiteSecuritySetting(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblWebSiteSecuritySettings({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblWebSiteSecuritySetting(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblWebSiteSecuritySettingByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting> GetTblWebSiteSecuritySettingByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblWebSiteSecuritySettings({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblWebSiteSecuritySettingByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting>(response);
        }

        partial void OnUpdateTblWebSiteSecuritySetting(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblWebSiteSecuritySetting(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting tblWebSiteSecuritySetting = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting))
        {
            var uri = new Uri(baseUri, $"TblWebSiteSecuritySettings({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblWebSiteSecuritySetting), Encoding.UTF8, "application/json");

            OnUpdateTblWebSiteSecuritySetting(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTblWebSiteUsersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsiteusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsiteusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblWebSiteUsersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsiteusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsiteusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTblWebSiteUsers(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser>> GetTblWebSiteUsers(Query query)
        {
            return await GetTblWebSiteUsers(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser>> GetTblWebSiteUsers(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblWebSiteUsers");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblWebSiteUsers(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser>>(response);
        }

        partial void OnCreateTblWebSiteUser(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser> CreateTblWebSiteUser(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser tblWebSiteUser = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser))
        {
            var uri = new Uri(baseUri, $"TblWebSiteUsers");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblWebSiteUser), Encoding.UTF8, "application/json");

            OnCreateTblWebSiteUser(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser>(response);
        }

        partial void OnDeleteTblWebSiteUser(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTblWebSiteUser(int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblWebSiteUsers({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblWebSiteUser(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTblWebSiteUserByFldRecordId(HttpRequestMessage requestMessage);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser> GetTblWebSiteUserByFldRecordId(string expand = default(string), int fldRecordId = default(int))
        {
            var uri = new Uri(baseUri, $"TblWebSiteUsers({fldRecordId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblWebSiteUserByFldRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser>(response);
        }

        partial void OnUpdateTblWebSiteUser(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTblWebSiteUser(int fldRecordId = default(int), ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser tblWebSiteUser = default(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser))
        {
            var uri = new Uri(baseUri, $"TblWebSiteUsers({fldRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblWebSiteUser), Encoding.UTF8, "application/json");

            OnUpdateTblWebSiteUser(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}