using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Radzen;

using ThrottleCoreCRM.Server.Data;

namespace ThrottleCoreCRM.Server
{
    public partial class Throttle_Core_WebSiteService
    {
        Throttle_Core_WebSiteContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly Throttle_Core_WebSiteContext context;
        private readonly NavigationManager navigationManager;

        public Throttle_Core_WebSiteService(Throttle_Core_WebSiteContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);

        public void ApplyQuery<T>(ref IQueryable<T> items, Query query = null)
        {
            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }
        }


        public async Task ExportContactsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/contacts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/contacts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportContactsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/contacts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/contacts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnContactsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact>> GetContacts(Query query = null)
        {
            var items = Context.Contacts.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnContactsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnContactGet(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact item);
        partial void OnGetContactById(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact> GetContactById(int id)
        {
            var items = Context.Contacts
                              .AsNoTracking()
                              .Where(i => i.Id == id);

 
            OnGetContactById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnContactGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnContactCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact item);
        partial void OnAfterContactCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact> CreateContact(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact contact)
        {
            OnContactCreated(contact);

            var existingItem = Context.Contacts
                              .Where(i => i.Id == contact.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Contacts.Add(contact);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(contact).State = EntityState.Detached;
                throw;
            }

            OnAfterContactCreated(contact);

            return contact;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact> CancelContactChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnContactUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact item);
        partial void OnAfterContactUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact> UpdateContact(int id, ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact contact)
        {
            OnContactUpdated(contact);

            var itemToUpdate = Context.Contacts
                              .Where(i => i.Id == contact.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(contact);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterContactUpdated(contact);

            return contact;
        }

        partial void OnContactDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact item);
        partial void OnAfterContactDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact> DeleteContact(int id)
        {
            var itemToDelete = Context.Contacts
                              .Where(i => i.Id == id)
                              .Include(i => i.Opportunities)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnContactDeleted(itemToDelete);


            Context.Contacts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterContactDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportDepartmentsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/departments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/departments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDepartmentsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/departments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/departments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDepartmentsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department>> GetDepartments(Query query = null)
        {
            var items = Context.Departments.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnDepartmentsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDepartmentGet(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department item);
        partial void OnGetDepartmentById(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department> GetDepartmentById(int id)
        {
            var items = Context.Departments
                              .AsNoTracking()
                              .Where(i => i.Id == id);

 
            OnGetDepartmentById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnDepartmentGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnDepartmentCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department item);
        partial void OnAfterDepartmentCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department> CreateDepartment(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department department)
        {
            OnDepartmentCreated(department);

            var existingItem = Context.Departments
                              .Where(i => i.Id == department.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Departments.Add(department);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(department).State = EntityState.Detached;
                throw;
            }

            OnAfterDepartmentCreated(department);

            return department;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department> CancelDepartmentChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDepartmentUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department item);
        partial void OnAfterDepartmentUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department> UpdateDepartment(int id, ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department department)
        {
            OnDepartmentUpdated(department);

            var itemToUpdate = Context.Departments
                              .Where(i => i.Id == department.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(department);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterDepartmentUpdated(department);

            return department;
        }

        partial void OnDepartmentDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department item);
        partial void OnAfterDepartmentDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department> DeleteDepartment(int id)
        {
            var itemToDelete = Context.Departments
                              .Where(i => i.Id == id)
                              .Include(i => i.Employees)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDepartmentDeleted(itemToDelete);


            Context.Departments.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDepartmentDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportEmployeesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/employees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/employees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEmployeesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/employees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/employees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEmployeesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee>> GetEmployees(Query query = null)
        {
            var items = Context.Employees.AsQueryable();

            items = items.Include(i => i.Department);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnEmployeesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEmployeeGet(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee item);
        partial void OnGetEmployeeById(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee> GetEmployeeById(int id)
        {
            var items = Context.Employees
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Department);
 
            OnGetEmployeeById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnEmployeeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnEmployeeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee item);
        partial void OnAfterEmployeeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee> CreateEmployee(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee employee)
        {
            OnEmployeeCreated(employee);

            var existingItem = Context.Employees
                              .Where(i => i.Id == employee.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Employees.Add(employee);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(employee).State = EntityState.Detached;
                throw;
            }

            OnAfterEmployeeCreated(employee);

            return employee;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee> CancelEmployeeChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnEmployeeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee item);
        partial void OnAfterEmployeeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee> UpdateEmployee(int id, ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee employee)
        {
            OnEmployeeUpdated(employee);

            var itemToUpdate = Context.Employees
                              .Where(i => i.Id == employee.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(employee);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterEmployeeUpdated(employee);

            return employee;
        }

        partial void OnEmployeeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee item);
        partial void OnAfterEmployeeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee> DeleteEmployee(int id)
        {
            var itemToDelete = Context.Employees
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEmployeeDeleted(itemToDelete);


            Context.Employees.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEmployeeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportOpportunitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/opportunities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/opportunities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOpportunitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/opportunities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/opportunities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOpportunitiesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity>> GetOpportunities(Query query = null)
        {
            var items = Context.Opportunities.AsQueryable();

            items = items.Include(i => i.Contact);
            items = items.Include(i => i.OpportunityStatus);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnOpportunitiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnOpportunityGet(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity item);
        partial void OnGetOpportunityById(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity> GetOpportunityById(int id)
        {
            var items = Context.Opportunities
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Contact);
            items = items.Include(i => i.OpportunityStatus);
 
            OnGetOpportunityById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnOpportunityGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnOpportunityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity item);
        partial void OnAfterOpportunityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity> CreateOpportunity(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity opportunity)
        {
            OnOpportunityCreated(opportunity);

            var existingItem = Context.Opportunities
                              .Where(i => i.Id == opportunity.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Opportunities.Add(opportunity);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(opportunity).State = EntityState.Detached;
                throw;
            }

            OnAfterOpportunityCreated(opportunity);

            return opportunity;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity> CancelOpportunityChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnOpportunityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity item);
        partial void OnAfterOpportunityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity> UpdateOpportunity(int id, ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity opportunity)
        {
            OnOpportunityUpdated(opportunity);

            var itemToUpdate = Context.Opportunities
                              .Where(i => i.Id == opportunity.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(opportunity);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterOpportunityUpdated(opportunity);

            return opportunity;
        }

        partial void OnOpportunityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity item);
        partial void OnAfterOpportunityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity> DeleteOpportunity(int id)
        {
            var itemToDelete = Context.Opportunities
                              .Where(i => i.Id == id)
                              .Include(i => i.Tasks)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnOpportunityDeleted(itemToDelete);


            Context.Opportunities.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterOpportunityDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportOpportunityStatusesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/opportunitystatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/opportunitystatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOpportunityStatusesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/opportunitystatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/opportunitystatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOpportunityStatusesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus>> GetOpportunityStatuses(Query query = null)
        {
            var items = Context.OpportunityStatuses.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnOpportunityStatusesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnOpportunityStatusGet(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus item);
        partial void OnGetOpportunityStatusById(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus> GetOpportunityStatusById(int id)
        {
            var items = Context.OpportunityStatuses
                              .AsNoTracking()
                              .Where(i => i.Id == id);

 
            OnGetOpportunityStatusById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnOpportunityStatusGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnOpportunityStatusCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus item);
        partial void OnAfterOpportunityStatusCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus> CreateOpportunityStatus(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus opportunitystatus)
        {
            OnOpportunityStatusCreated(opportunitystatus);

            var existingItem = Context.OpportunityStatuses
                              .Where(i => i.Id == opportunitystatus.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.OpportunityStatuses.Add(opportunitystatus);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(opportunitystatus).State = EntityState.Detached;
                throw;
            }

            OnAfterOpportunityStatusCreated(opportunitystatus);

            return opportunitystatus;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus> CancelOpportunityStatusChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnOpportunityStatusUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus item);
        partial void OnAfterOpportunityStatusUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus> UpdateOpportunityStatus(int id, ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus opportunitystatus)
        {
            OnOpportunityStatusUpdated(opportunitystatus);

            var itemToUpdate = Context.OpportunityStatuses
                              .Where(i => i.Id == opportunitystatus.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(opportunitystatus);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterOpportunityStatusUpdated(opportunitystatus);

            return opportunitystatus;
        }

        partial void OnOpportunityStatusDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus item);
        partial void OnAfterOpportunityStatusDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus> DeleteOpportunityStatus(int id)
        {
            var itemToDelete = Context.OpportunityStatuses
                              .Where(i => i.Id == id)
                              .Include(i => i.Opportunities)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnOpportunityStatusDeleted(itemToDelete);


            Context.OpportunityStatuses.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterOpportunityStatusDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTasksToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tasks/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tasks/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTasksToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tasks/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tasks/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTasksRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task>> GetTasks(Query query = null)
        {
            var items = Context.Tasks.AsQueryable();

            items = items.Include(i => i.Opportunity);
            items = items.Include(i => i.TaskStatus);
            items = items.Include(i => i.TaskType);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTasksRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTaskGet(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task item);
        partial void OnGetTaskById(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task> GetTaskById(int id)
        {
            var items = Context.Tasks
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Opportunity);
            items = items.Include(i => i.TaskStatus);
            items = items.Include(i => i.TaskType);
 
            OnGetTaskById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTaskGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTaskCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task item);
        partial void OnAfterTaskCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task> CreateTask(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task task)
        {
            OnTaskCreated(task);

            var existingItem = Context.Tasks
                              .Where(i => i.Id == task.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Tasks.Add(task);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(task).State = EntityState.Detached;
                throw;
            }

            OnAfterTaskCreated(task);

            return task;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task> CancelTaskChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTaskUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task item);
        partial void OnAfterTaskUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task> UpdateTask(int id, ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task task)
        {
            OnTaskUpdated(task);

            var itemToUpdate = Context.Tasks
                              .Where(i => i.Id == task.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(task);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTaskUpdated(task);

            return task;
        }

        partial void OnTaskDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task item);
        partial void OnAfterTaskDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task> DeleteTask(int id)
        {
            var itemToDelete = Context.Tasks
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTaskDeleted(itemToDelete);


            Context.Tasks.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTaskDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTaskStatusesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/taskstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/taskstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTaskStatusesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/taskstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/taskstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTaskStatusesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus>> GetTaskStatuses(Query query = null)
        {
            var items = Context.TaskStatuses.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTaskStatusesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTaskStatusGet(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus item);
        partial void OnGetTaskStatusById(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus> GetTaskStatusById(int id)
        {
            var items = Context.TaskStatuses
                              .AsNoTracking()
                              .Where(i => i.Id == id);

 
            OnGetTaskStatusById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTaskStatusGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTaskStatusCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus item);
        partial void OnAfterTaskStatusCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus> CreateTaskStatus(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus taskstatus)
        {
            OnTaskStatusCreated(taskstatus);

            var existingItem = Context.TaskStatuses
                              .Where(i => i.Id == taskstatus.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TaskStatuses.Add(taskstatus);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(taskstatus).State = EntityState.Detached;
                throw;
            }

            OnAfterTaskStatusCreated(taskstatus);

            return taskstatus;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus> CancelTaskStatusChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTaskStatusUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus item);
        partial void OnAfterTaskStatusUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus> UpdateTaskStatus(int id, ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus taskstatus)
        {
            OnTaskStatusUpdated(taskstatus);

            var itemToUpdate = Context.TaskStatuses
                              .Where(i => i.Id == taskstatus.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(taskstatus);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTaskStatusUpdated(taskstatus);

            return taskstatus;
        }

        partial void OnTaskStatusDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus item);
        partial void OnAfterTaskStatusDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus> DeleteTaskStatus(int id)
        {
            var itemToDelete = Context.TaskStatuses
                              .Where(i => i.Id == id)
                              .Include(i => i.Tasks)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTaskStatusDeleted(itemToDelete);


            Context.TaskStatuses.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTaskStatusDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTaskTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tasktypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tasktypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTaskTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tasktypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tasktypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTaskTypesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType>> GetTaskTypes(Query query = null)
        {
            var items = Context.TaskTypes.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTaskTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTaskTypeGet(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType item);
        partial void OnGetTaskTypeById(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType> GetTaskTypeById(int id)
        {
            var items = Context.TaskTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

 
            OnGetTaskTypeById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTaskTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTaskTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType item);
        partial void OnAfterTaskTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType> CreateTaskType(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType tasktype)
        {
            OnTaskTypeCreated(tasktype);

            var existingItem = Context.TaskTypes
                              .Where(i => i.Id == tasktype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TaskTypes.Add(tasktype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tasktype).State = EntityState.Detached;
                throw;
            }

            OnAfterTaskTypeCreated(tasktype);

            return tasktype;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType> CancelTaskTypeChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTaskTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType item);
        partial void OnAfterTaskTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType> UpdateTaskType(int id, ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType tasktype)
        {
            OnTaskTypeUpdated(tasktype);

            var itemToUpdate = Context.TaskTypes
                              .Where(i => i.Id == tasktype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tasktype);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTaskTypeUpdated(tasktype);

            return tasktype;
        }

        partial void OnTaskTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType item);
        partial void OnAfterTaskTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType> DeleteTaskType(int id)
        {
            var itemToDelete = Context.TaskTypes
                              .Where(i => i.Id == id)
                              .Include(i => i.Tasks)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTaskTypeDeleted(itemToDelete);


            Context.TaskTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTaskTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblDatabasesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tbldatabases/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tbldatabases/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblDatabasesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tbldatabases/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tbldatabases/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblDatabasesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase>> GetTblDatabases(Query query = null)
        {
            var items = Context.TblDatabases.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTblDatabasesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblDatabaseGet(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase item);
        partial void OnGetTblDatabaseByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase> GetTblDatabaseByFldRecordId(int fldrecordid)
        {
            var items = Context.TblDatabases
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblDatabaseByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblDatabaseGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblDatabaseCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase item);
        partial void OnAfterTblDatabaseCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase> CreateTblDatabase(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase tbldatabase)
        {
            OnTblDatabaseCreated(tbldatabase);

            var existingItem = Context.TblDatabases
                              .Where(i => i.fldRecordID == tbldatabase.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblDatabases.Add(tbldatabase);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tbldatabase).State = EntityState.Detached;
                throw;
            }

            OnAfterTblDatabaseCreated(tbldatabase);

            return tbldatabase;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase> CancelTblDatabaseChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblDatabaseUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase item);
        partial void OnAfterTblDatabaseUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase> UpdateTblDatabase(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase tbldatabase)
        {
            OnTblDatabaseUpdated(tbldatabase);

            var itemToUpdate = Context.TblDatabases
                              .Where(i => i.fldRecordID == tbldatabase.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tbldatabase);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblDatabaseUpdated(tbldatabase);

            return tbldatabase;
        }

        partial void OnTblDatabaseDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase item);
        partial void OnAfterTblDatabaseDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase> DeleteTblDatabase(int fldrecordid)
        {
            var itemToDelete = Context.TblDatabases
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblDatabaseDeleted(itemToDelete);


            Context.TblDatabases.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblDatabaseDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblWebSiteErrorDescriptionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsiteerrordescriptions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsiteerrordescriptions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblWebSiteErrorDescriptionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsiteerrordescriptions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsiteerrordescriptions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblWebSiteErrorDescriptionsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription>> GetTblWebSiteErrorDescriptions(Query query = null)
        {
            var items = Context.TblWebSiteErrorDescriptions.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTblWebSiteErrorDescriptionsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblWebSiteErrorDescriptionGet(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription item);
        partial void OnGetTblWebSiteErrorDescriptionByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription> GetTblWebSiteErrorDescriptionByFldRecordId(int fldrecordid)
        {
            var items = Context.TblWebSiteErrorDescriptions
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblWebSiteErrorDescriptionByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblWebSiteErrorDescriptionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblWebSiteErrorDescriptionCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription item);
        partial void OnAfterTblWebSiteErrorDescriptionCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription> CreateTblWebSiteErrorDescription(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription tblwebsiteerrordescription)
        {
            OnTblWebSiteErrorDescriptionCreated(tblwebsiteerrordescription);

            var existingItem = Context.TblWebSiteErrorDescriptions
                              .Where(i => i.fldRecordID == tblwebsiteerrordescription.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblWebSiteErrorDescriptions.Add(tblwebsiteerrordescription);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblwebsiteerrordescription).State = EntityState.Detached;
                throw;
            }

            OnAfterTblWebSiteErrorDescriptionCreated(tblwebsiteerrordescription);

            return tblwebsiteerrordescription;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription> CancelTblWebSiteErrorDescriptionChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblWebSiteErrorDescriptionUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription item);
        partial void OnAfterTblWebSiteErrorDescriptionUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription> UpdateTblWebSiteErrorDescription(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription tblwebsiteerrordescription)
        {
            OnTblWebSiteErrorDescriptionUpdated(tblwebsiteerrordescription);

            var itemToUpdate = Context.TblWebSiteErrorDescriptions
                              .Where(i => i.fldRecordID == tblwebsiteerrordescription.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblwebsiteerrordescription);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblWebSiteErrorDescriptionUpdated(tblwebsiteerrordescription);

            return tblwebsiteerrordescription;
        }

        partial void OnTblWebSiteErrorDescriptionDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription item);
        partial void OnAfterTblWebSiteErrorDescriptionDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription> DeleteTblWebSiteErrorDescription(int fldrecordid)
        {
            var itemToDelete = Context.TblWebSiteErrorDescriptions
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblWebSiteErrorDescriptionDeleted(itemToDelete);


            Context.TblWebSiteErrorDescriptions.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblWebSiteErrorDescriptionDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblWebSiteLanguagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsitelanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsitelanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblWebSiteLanguagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsitelanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsitelanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblWebSiteLanguagesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage>> GetTblWebSiteLanguages(Query query = null)
        {
            var items = Context.TblWebSiteLanguages.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTblWebSiteLanguagesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblWebSiteLanguageGet(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage item);
        partial void OnGetTblWebSiteLanguageByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage> GetTblWebSiteLanguageByFldRecordId(int fldrecordid)
        {
            var items = Context.TblWebSiteLanguages
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblWebSiteLanguageByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblWebSiteLanguageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblWebSiteLanguageCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage item);
        partial void OnAfterTblWebSiteLanguageCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage> CreateTblWebSiteLanguage(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage tblwebsitelanguage)
        {
            OnTblWebSiteLanguageCreated(tblwebsitelanguage);

            var existingItem = Context.TblWebSiteLanguages
                              .Where(i => i.fldRecordID == tblwebsitelanguage.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblWebSiteLanguages.Add(tblwebsitelanguage);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblwebsitelanguage).State = EntityState.Detached;
                throw;
            }

            OnAfterTblWebSiteLanguageCreated(tblwebsitelanguage);

            return tblwebsitelanguage;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage> CancelTblWebSiteLanguageChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblWebSiteLanguageUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage item);
        partial void OnAfterTblWebSiteLanguageUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage> UpdateTblWebSiteLanguage(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage tblwebsitelanguage)
        {
            OnTblWebSiteLanguageUpdated(tblwebsitelanguage);

            var itemToUpdate = Context.TblWebSiteLanguages
                              .Where(i => i.fldRecordID == tblwebsitelanguage.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblwebsitelanguage);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblWebSiteLanguageUpdated(tblwebsitelanguage);

            return tblwebsitelanguage;
        }

        partial void OnTblWebSiteLanguageDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage item);
        partial void OnAfterTblWebSiteLanguageDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage> DeleteTblWebSiteLanguage(int fldrecordid)
        {
            var itemToDelete = Context.TblWebSiteLanguages
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblWebSiteLanguageDeleted(itemToDelete);


            Context.TblWebSiteLanguages.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblWebSiteLanguageDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblWebSiteMenusToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsitemenus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsitemenus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblWebSiteMenusToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsitemenus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsitemenus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblWebSiteMenusRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu>> GetTblWebSiteMenus(Query query = null)
        {
            var items = Context.TblWebSiteMenus.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTblWebSiteMenusRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblWebSiteMenuGet(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu item);
        partial void OnGetTblWebSiteMenuByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu> GetTblWebSiteMenuByFldRecordId(int fldrecordid)
        {
            var items = Context.TblWebSiteMenus
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblWebSiteMenuByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblWebSiteMenuGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblWebSiteMenuCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu item);
        partial void OnAfterTblWebSiteMenuCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu> CreateTblWebSiteMenu(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu tblwebsitemenu)
        {
            OnTblWebSiteMenuCreated(tblwebsitemenu);

            var existingItem = Context.TblWebSiteMenus
                              .Where(i => i.fldRecordID == tblwebsitemenu.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblWebSiteMenus.Add(tblwebsitemenu);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblwebsitemenu).State = EntityState.Detached;
                throw;
            }

            OnAfterTblWebSiteMenuCreated(tblwebsitemenu);

            return tblwebsitemenu;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu> CancelTblWebSiteMenuChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblWebSiteMenuUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu item);
        partial void OnAfterTblWebSiteMenuUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu> UpdateTblWebSiteMenu(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu tblwebsitemenu)
        {
            OnTblWebSiteMenuUpdated(tblwebsitemenu);

            var itemToUpdate = Context.TblWebSiteMenus
                              .Where(i => i.fldRecordID == tblwebsitemenu.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblwebsitemenu);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblWebSiteMenuUpdated(tblwebsitemenu);

            return tblwebsitemenu;
        }

        partial void OnTblWebSiteMenuDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu item);
        partial void OnAfterTblWebSiteMenuDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu> DeleteTblWebSiteMenu(int fldrecordid)
        {
            var itemToDelete = Context.TblWebSiteMenus
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblWebSiteMenuDeleted(itemToDelete);


            Context.TblWebSiteMenus.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblWebSiteMenuDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblWebSiteSecurityGroupsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsitesecuritygroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsitesecuritygroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblWebSiteSecurityGroupsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsitesecuritygroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsitesecuritygroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblWebSiteSecurityGroupsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup>> GetTblWebSiteSecurityGroups(Query query = null)
        {
            var items = Context.TblWebSiteSecurityGroups.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTblWebSiteSecurityGroupsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblWebSiteSecurityGroupGet(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup item);
        partial void OnGetTblWebSiteSecurityGroupByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup> GetTblWebSiteSecurityGroupByFldRecordId(int fldrecordid)
        {
            var items = Context.TblWebSiteSecurityGroups
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblWebSiteSecurityGroupByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblWebSiteSecurityGroupGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblWebSiteSecurityGroupCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup item);
        partial void OnAfterTblWebSiteSecurityGroupCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup> CreateTblWebSiteSecurityGroup(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup tblwebsitesecuritygroup)
        {
            OnTblWebSiteSecurityGroupCreated(tblwebsitesecuritygroup);

            var existingItem = Context.TblWebSiteSecurityGroups
                              .Where(i => i.fldRecordID == tblwebsitesecuritygroup.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblWebSiteSecurityGroups.Add(tblwebsitesecuritygroup);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblwebsitesecuritygroup).State = EntityState.Detached;
                throw;
            }

            OnAfterTblWebSiteSecurityGroupCreated(tblwebsitesecuritygroup);

            return tblwebsitesecuritygroup;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup> CancelTblWebSiteSecurityGroupChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblWebSiteSecurityGroupUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup item);
        partial void OnAfterTblWebSiteSecurityGroupUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup> UpdateTblWebSiteSecurityGroup(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup tblwebsitesecuritygroup)
        {
            OnTblWebSiteSecurityGroupUpdated(tblwebsitesecuritygroup);

            var itemToUpdate = Context.TblWebSiteSecurityGroups
                              .Where(i => i.fldRecordID == tblwebsitesecuritygroup.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblwebsitesecuritygroup);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblWebSiteSecurityGroupUpdated(tblwebsitesecuritygroup);

            return tblwebsitesecuritygroup;
        }

        partial void OnTblWebSiteSecurityGroupDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup item);
        partial void OnAfterTblWebSiteSecurityGroupDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup> DeleteTblWebSiteSecurityGroup(int fldrecordid)
        {
            var itemToDelete = Context.TblWebSiteSecurityGroups
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblWebSiteSecurityGroupDeleted(itemToDelete);


            Context.TblWebSiteSecurityGroups.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblWebSiteSecurityGroupDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblWebSiteSecuritySettingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsitesecuritysettings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsitesecuritysettings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblWebSiteSecuritySettingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsitesecuritysettings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsitesecuritysettings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblWebSiteSecuritySettingsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting>> GetTblWebSiteSecuritySettings(Query query = null)
        {
            var items = Context.TblWebSiteSecuritySettings.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTblWebSiteSecuritySettingsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblWebSiteSecuritySettingGet(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting item);
        partial void OnGetTblWebSiteSecuritySettingByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting> GetTblWebSiteSecuritySettingByFldRecordId(int fldrecordid)
        {
            var items = Context.TblWebSiteSecuritySettings
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblWebSiteSecuritySettingByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblWebSiteSecuritySettingGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblWebSiteSecuritySettingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting item);
        partial void OnAfterTblWebSiteSecuritySettingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting> CreateTblWebSiteSecuritySetting(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting tblwebsitesecuritysetting)
        {
            OnTblWebSiteSecuritySettingCreated(tblwebsitesecuritysetting);

            var existingItem = Context.TblWebSiteSecuritySettings
                              .Where(i => i.fldRecordID == tblwebsitesecuritysetting.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblWebSiteSecuritySettings.Add(tblwebsitesecuritysetting);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblwebsitesecuritysetting).State = EntityState.Detached;
                throw;
            }

            OnAfterTblWebSiteSecuritySettingCreated(tblwebsitesecuritysetting);

            return tblwebsitesecuritysetting;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting> CancelTblWebSiteSecuritySettingChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblWebSiteSecuritySettingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting item);
        partial void OnAfterTblWebSiteSecuritySettingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting> UpdateTblWebSiteSecuritySetting(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting tblwebsitesecuritysetting)
        {
            OnTblWebSiteSecuritySettingUpdated(tblwebsitesecuritysetting);

            var itemToUpdate = Context.TblWebSiteSecuritySettings
                              .Where(i => i.fldRecordID == tblwebsitesecuritysetting.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblwebsitesecuritysetting);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblWebSiteSecuritySettingUpdated(tblwebsitesecuritysetting);

            return tblwebsitesecuritysetting;
        }

        partial void OnTblWebSiteSecuritySettingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting item);
        partial void OnAfterTblWebSiteSecuritySettingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting> DeleteTblWebSiteSecuritySetting(int fldrecordid)
        {
            var itemToDelete = Context.TblWebSiteSecuritySettings
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblWebSiteSecuritySettingDeleted(itemToDelete);


            Context.TblWebSiteSecuritySettings.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblWebSiteSecuritySettingDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblWebSiteUsersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsiteusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsiteusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblWebSiteUsersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_website/tblwebsiteusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_website/tblwebsiteusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblWebSiteUsersRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser>> GetTblWebSiteUsers(Query query = null)
        {
            var items = Context.TblWebSiteUsers.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTblWebSiteUsersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblWebSiteUserGet(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser item);
        partial void OnGetTblWebSiteUserByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser> GetTblWebSiteUserByFldRecordId(int fldrecordid)
        {
            var items = Context.TblWebSiteUsers
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblWebSiteUserByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblWebSiteUserGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblWebSiteUserCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser item);
        partial void OnAfterTblWebSiteUserCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser> CreateTblWebSiteUser(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser tblwebsiteuser)
        {
            OnTblWebSiteUserCreated(tblwebsiteuser);

            var existingItem = Context.TblWebSiteUsers
                              .Where(i => i.fldRecordID == tblwebsiteuser.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblWebSiteUsers.Add(tblwebsiteuser);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblwebsiteuser).State = EntityState.Detached;
                throw;
            }

            OnAfterTblWebSiteUserCreated(tblwebsiteuser);

            return tblwebsiteuser;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser> CancelTblWebSiteUserChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblWebSiteUserUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser item);
        partial void OnAfterTblWebSiteUserUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser> UpdateTblWebSiteUser(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser tblwebsiteuser)
        {
            OnTblWebSiteUserUpdated(tblwebsiteuser);

            var itemToUpdate = Context.TblWebSiteUsers
                              .Where(i => i.fldRecordID == tblwebsiteuser.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblwebsiteuser);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblWebSiteUserUpdated(tblwebsiteuser);

            return tblwebsiteuser;
        }

        partial void OnTblWebSiteUserDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser item);
        partial void OnAfterTblWebSiteUserDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser> DeleteTblWebSiteUser(int fldrecordid)
        {
            var itemToDelete = Context.TblWebSiteUsers
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblWebSiteUserDeleted(itemToDelete);


            Context.TblWebSiteUsers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblWebSiteUserDeleted(itemToDelete);

            return itemToDelete;
        }
        }
}