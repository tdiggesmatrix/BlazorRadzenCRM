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
    public partial class Throttle_Core_BillingService
    {
        Throttle_Core_BillingContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly Throttle_Core_BillingContext context;
        private readonly NavigationManager navigationManager;

        public Throttle_Core_BillingService(Throttle_Core_BillingContext context, NavigationManager navigationManager)
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


        public async Task ExportBulkBillingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/bulkbillings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/bulkbillings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBulkBillingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/bulkbillings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/bulkbillings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBulkBillingsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling>> GetBulkBillings(Query query = null)
        {
            var items = Context.BulkBillings.AsQueryable();


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

            OnBulkBillingsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBulkBillingGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling item);
        partial void OnGetBulkBillingByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling> GetBulkBillingByFldRecordId(int fldrecordid)
        {
            var items = Context.BulkBillings
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetBulkBillingByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnBulkBillingGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBulkBillingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling item);
        partial void OnAfterBulkBillingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling> CreateBulkBilling(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling bulkbilling)
        {
            OnBulkBillingCreated(bulkbilling);

            var existingItem = Context.BulkBillings
                              .Where(i => i.fldRecordID == bulkbilling.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.BulkBillings.Add(bulkbilling);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(bulkbilling).State = EntityState.Detached;
                throw;
            }

            OnAfterBulkBillingCreated(bulkbilling);

            return bulkbilling;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling> CancelBulkBillingChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBulkBillingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling item);
        partial void OnAfterBulkBillingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling> UpdateBulkBilling(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling bulkbilling)
        {
            OnBulkBillingUpdated(bulkbilling);

            var itemToUpdate = Context.BulkBillings
                              .Where(i => i.fldRecordID == bulkbilling.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(bulkbilling);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBulkBillingUpdated(bulkbilling);

            return bulkbilling;
        }

        partial void OnBulkBillingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling item);
        partial void OnAfterBulkBillingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling> DeleteBulkBilling(int fldrecordid)
        {
            var itemToDelete = Context.BulkBillings
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBulkBillingDeleted(itemToDelete);


            Context.BulkBillings.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBulkBillingDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCurrentStoresToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/currentstores/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/currentstores/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCurrentStoresToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/currentstores/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/currentstores/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCurrentStoresRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore>> GetCurrentStores(Query query = null)
        {
            var items = Context.CurrentStores.AsQueryable();


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

            OnCurrentStoresRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCurrentStoreGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore item);
        partial void OnGetCurrentStoreByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore> GetCurrentStoreByFldRecordId(int fldrecordid)
        {
            var items = Context.CurrentStores
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetCurrentStoreByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCurrentStoreGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCurrentStoreCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore item);
        partial void OnAfterCurrentStoreCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore> CreateCurrentStore(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore currentstore)
        {
            OnCurrentStoreCreated(currentstore);

            var existingItem = Context.CurrentStores
                              .Where(i => i.fldRecordID == currentstore.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CurrentStores.Add(currentstore);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(currentstore).State = EntityState.Detached;
                throw;
            }

            OnAfterCurrentStoreCreated(currentstore);

            return currentstore;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore> CancelCurrentStoreChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCurrentStoreUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore item);
        partial void OnAfterCurrentStoreUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore> UpdateCurrentStore(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore currentstore)
        {
            OnCurrentStoreUpdated(currentstore);

            var itemToUpdate = Context.CurrentStores
                              .Where(i => i.fldRecordID == currentstore.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(currentstore);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCurrentStoreUpdated(currentstore);

            return currentstore;
        }

        partial void OnCurrentStoreDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore item);
        partial void OnAfterCurrentStoreDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore> DeleteCurrentStore(int fldrecordid)
        {
            var itemToDelete = Context.CurrentStores
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCurrentStoreDeleted(itemToDelete);


            Context.CurrentStores.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCurrentStoreDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCustomerBillingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/customerbillings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/customerbillings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCustomerBillingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/customerbillings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/customerbillings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCustomerBillingsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling>> GetCustomerBillings(Query query = null)
        {
            var items = Context.CustomerBillings.AsQueryable();


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

            OnCustomerBillingsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCustomerBillingGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling item);
        partial void OnGetCustomerBillingByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling> GetCustomerBillingByFldRecordId(int fldrecordid)
        {
            var items = Context.CustomerBillings
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetCustomerBillingByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCustomerBillingGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCustomerBillingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling item);
        partial void OnAfterCustomerBillingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling> CreateCustomerBilling(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling customerbilling)
        {
            OnCustomerBillingCreated(customerbilling);

            var existingItem = Context.CustomerBillings
                              .Where(i => i.fldRecordID == customerbilling.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CustomerBillings.Add(customerbilling);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(customerbilling).State = EntityState.Detached;
                throw;
            }

            OnAfterCustomerBillingCreated(customerbilling);

            return customerbilling;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling> CancelCustomerBillingChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCustomerBillingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling item);
        partial void OnAfterCustomerBillingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling> UpdateCustomerBilling(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling customerbilling)
        {
            OnCustomerBillingUpdated(customerbilling);

            var itemToUpdate = Context.CustomerBillings
                              .Where(i => i.fldRecordID == customerbilling.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(customerbilling);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCustomerBillingUpdated(customerbilling);

            return customerbilling;
        }

        partial void OnCustomerBillingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling item);
        partial void OnAfterCustomerBillingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling> DeleteCustomerBilling(int fldrecordid)
        {
            var itemToDelete = Context.CustomerBillings
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCustomerBillingDeleted(itemToDelete);


            Context.CustomerBillings.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCustomerBillingDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCustomerShippingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/customershippings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/customershippings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCustomerShippingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/customershippings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/customershippings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCustomerShippingsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping>> GetCustomerShippings(Query query = null)
        {
            var items = Context.CustomerShippings.AsQueryable();


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

            OnCustomerShippingsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCustomerShippingGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping item);
        partial void OnGetCustomerShippingByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping> GetCustomerShippingByFldRecordId(int fldrecordid)
        {
            var items = Context.CustomerShippings
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetCustomerShippingByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCustomerShippingGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCustomerShippingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping item);
        partial void OnAfterCustomerShippingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping> CreateCustomerShipping(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping customershipping)
        {
            OnCustomerShippingCreated(customershipping);

            var existingItem = Context.CustomerShippings
                              .Where(i => i.fldRecordID == customershipping.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CustomerShippings.Add(customershipping);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(customershipping).State = EntityState.Detached;
                throw;
            }

            OnAfterCustomerShippingCreated(customershipping);

            return customershipping;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping> CancelCustomerShippingChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCustomerShippingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping item);
        partial void OnAfterCustomerShippingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping> UpdateCustomerShipping(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping customershipping)
        {
            OnCustomerShippingUpdated(customershipping);

            var itemToUpdate = Context.CustomerShippings
                              .Where(i => i.fldRecordID == customershipping.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(customershipping);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCustomerShippingUpdated(customershipping);

            return customershipping;
        }

        partial void OnCustomerShippingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping item);
        partial void OnAfterCustomerShippingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping> DeleteCustomerShipping(int fldrecordid)
        {
            var itemToDelete = Context.CustomerShippings
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCustomerShippingDeleted(itemToDelete);


            Context.CustomerShippings.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCustomerShippingDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportJobsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/jobs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/jobs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportJobsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/jobs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/jobs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnJobsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>> GetJobs(Query query = null)
        {
            var items = Context.Jobs.AsQueryable();


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

            OnJobsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnJobGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job item);
        partial void OnGetJobByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job> GetJobByFldRecordId(int fldrecordid)
        {
            var items = Context.Jobs
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetJobByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnJobGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnJobCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job item);
        partial void OnAfterJobCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job> CreateJob(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job job)
        {
            OnJobCreated(job);

            var existingItem = Context.Jobs
                              .Where(i => i.fldRecordID == job.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Jobs.Add(job);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(job).State = EntityState.Detached;
                throw;
            }

            OnAfterJobCreated(job);

            return job;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job> CancelJobChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnJobUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job item);
        partial void OnAfterJobUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job> UpdateJob(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job job)
        {
            OnJobUpdated(job);

            var itemToUpdate = Context.Jobs
                              .Where(i => i.fldRecordID == job.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(job);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterJobUpdated(job);

            return job;
        }

        partial void OnJobDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job item);
        partial void OnAfterJobDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job> DeleteJob(int fldrecordid)
        {
            var itemToDelete = Context.Jobs
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnJobDeleted(itemToDelete);


            Context.Jobs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterJobDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportLineItemsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/lineitems/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/lineitems/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLineItemsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/lineitems/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/lineitems/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLineItemsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>> GetLineItems(Query query = null)
        {
            var items = Context.LineItems.AsQueryable();


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

            OnLineItemsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnLineItemGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem item);
        partial void OnGetLineItemByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem> GetLineItemByFldRecordId(int fldrecordid)
        {
            var items = Context.LineItems
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetLineItemByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnLineItemGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnLineItemCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem item);
        partial void OnAfterLineItemCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem> CreateLineItem(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem lineitem)
        {
            OnLineItemCreated(lineitem);

            var existingItem = Context.LineItems
                              .Where(i => i.fldRecordID == lineitem.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.LineItems.Add(lineitem);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(lineitem).State = EntityState.Detached;
                throw;
            }

            OnAfterLineItemCreated(lineitem);

            return lineitem;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem> CancelLineItemChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnLineItemUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem item);
        partial void OnAfterLineItemUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem> UpdateLineItem(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem lineitem)
        {
            OnLineItemUpdated(lineitem);

            var itemToUpdate = Context.LineItems
                              .Where(i => i.fldRecordID == lineitem.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(lineitem);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterLineItemUpdated(lineitem);

            return lineitem;
        }

        partial void OnLineItemDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem item);
        partial void OnAfterLineItemDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem> DeleteLineItem(int fldrecordid)
        {
            var itemToDelete = Context.LineItems
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnLineItemDeleted(itemToDelete);


            Context.LineItems.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterLineItemDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProductsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/products/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/products/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProductsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/products/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/products/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProductsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product>> GetProducts(Query query = null)
        {
            var items = Context.Products.AsQueryable();


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

            OnProductsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProductGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product item);
        partial void OnGetProductByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product> GetProductByFldRecordId(int fldrecordid)
        {
            var items = Context.Products
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetProductByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnProductGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProductCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product item);
        partial void OnAfterProductCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product> CreateProduct(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product product)
        {
            OnProductCreated(product);

            var existingItem = Context.Products
                              .Where(i => i.fldRecordID == product.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Products.Add(product);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(product).State = EntityState.Detached;
                throw;
            }

            OnAfterProductCreated(product);

            return product;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product> CancelProductChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProductUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product item);
        partial void OnAfterProductUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product> UpdateProduct(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product product)
        {
            OnProductUpdated(product);

            var itemToUpdate = Context.Products
                              .Where(i => i.fldRecordID == product.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(product);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProductUpdated(product);

            return product;
        }

        partial void OnProductDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product item);
        partial void OnAfterProductDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product> DeleteProduct(int fldrecordid)
        {
            var itemToDelete = Context.Products
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProductDeleted(itemToDelete);


            Context.Products.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProductDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProductCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/productcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/productcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProductCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/productcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/productcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProductCategoriesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory>> GetProductCategories(Query query = null)
        {
            var items = Context.ProductCategories.AsQueryable();


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

            OnProductCategoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProductCategoryGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory item);
        partial void OnGetProductCategoryByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory> GetProductCategoryByFldRecordId(int fldrecordid)
        {
            var items = Context.ProductCategories
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetProductCategoryByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnProductCategoryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProductCategoryCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory item);
        partial void OnAfterProductCategoryCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory> CreateProductCategory(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory productcategory)
        {
            OnProductCategoryCreated(productcategory);

            var existingItem = Context.ProductCategories
                              .Where(i => i.fldRecordID == productcategory.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ProductCategories.Add(productcategory);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(productcategory).State = EntityState.Detached;
                throw;
            }

            OnAfterProductCategoryCreated(productcategory);

            return productcategory;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory> CancelProductCategoryChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProductCategoryUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory item);
        partial void OnAfterProductCategoryUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory> UpdateProductCategory(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory productcategory)
        {
            OnProductCategoryUpdated(productcategory);

            var itemToUpdate = Context.ProductCategories
                              .Where(i => i.fldRecordID == productcategory.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(productcategory);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProductCategoryUpdated(productcategory);

            return productcategory;
        }

        partial void OnProductCategoryDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory item);
        partial void OnAfterProductCategoryDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory> DeleteProductCategory(int fldrecordid)
        {
            var itemToDelete = Context.ProductCategories
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProductCategoryDeleted(itemToDelete);


            Context.ProductCategories.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProductCategoryDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportRemindersSettingsAdminsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/reminderssettingsadmins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/reminderssettingsadmins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRemindersSettingsAdminsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/reminderssettingsadmins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/reminderssettingsadmins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRemindersSettingsAdminsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin>> GetRemindersSettingsAdmins(Query query = null)
        {
            var items = Context.RemindersSettingsAdmins.AsQueryable();


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

            OnRemindersSettingsAdminsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnRemindersSettingsAdminGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin item);
        partial void OnGetRemindersSettingsAdminByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin> GetRemindersSettingsAdminByFldRecordId(int fldrecordid)
        {
            var items = Context.RemindersSettingsAdmins
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetRemindersSettingsAdminByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnRemindersSettingsAdminGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnRemindersSettingsAdminCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin item);
        partial void OnAfterRemindersSettingsAdminCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin> CreateRemindersSettingsAdmin(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin reminderssettingsadmin)
        {
            OnRemindersSettingsAdminCreated(reminderssettingsadmin);

            var existingItem = Context.RemindersSettingsAdmins
                              .Where(i => i.fldRecordID == reminderssettingsadmin.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.RemindersSettingsAdmins.Add(reminderssettingsadmin);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(reminderssettingsadmin).State = EntityState.Detached;
                throw;
            }

            OnAfterRemindersSettingsAdminCreated(reminderssettingsadmin);

            return reminderssettingsadmin;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin> CancelRemindersSettingsAdminChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnRemindersSettingsAdminUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin item);
        partial void OnAfterRemindersSettingsAdminUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin> UpdateRemindersSettingsAdmin(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin reminderssettingsadmin)
        {
            OnRemindersSettingsAdminUpdated(reminderssettingsadmin);

            var itemToUpdate = Context.RemindersSettingsAdmins
                              .Where(i => i.fldRecordID == reminderssettingsadmin.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(reminderssettingsadmin);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterRemindersSettingsAdminUpdated(reminderssettingsadmin);

            return reminderssettingsadmin;
        }

        partial void OnRemindersSettingsAdminDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin item);
        partial void OnAfterRemindersSettingsAdminDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin> DeleteRemindersSettingsAdmin(int fldrecordid)
        {
            var itemToDelete = Context.RemindersSettingsAdmins
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnRemindersSettingsAdminDeleted(itemToDelete);


            Context.RemindersSettingsAdmins.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterRemindersSettingsAdminDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSettingsConfigurationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/settingsconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/settingsconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSettingsConfigurationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/settingsconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/settingsconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSettingsConfigurationsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration>> GetSettingsConfigurations(Query query = null)
        {
            var items = Context.SettingsConfigurations.AsQueryable();


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

            OnSettingsConfigurationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSettingsConfigurationGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration item);
        partial void OnGetSettingsConfigurationByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration> GetSettingsConfigurationByFldRecordId(int fldrecordid)
        {
            var items = Context.SettingsConfigurations
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetSettingsConfigurationByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnSettingsConfigurationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSettingsConfigurationCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration item);
        partial void OnAfterSettingsConfigurationCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration> CreateSettingsConfiguration(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration settingsconfiguration)
        {
            OnSettingsConfigurationCreated(settingsconfiguration);

            var existingItem = Context.SettingsConfigurations
                              .Where(i => i.fldRecordID == settingsconfiguration.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SettingsConfigurations.Add(settingsconfiguration);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(settingsconfiguration).State = EntityState.Detached;
                throw;
            }

            OnAfterSettingsConfigurationCreated(settingsconfiguration);

            return settingsconfiguration;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration> CancelSettingsConfigurationChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSettingsConfigurationUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration item);
        partial void OnAfterSettingsConfigurationUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration> UpdateSettingsConfiguration(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration settingsconfiguration)
        {
            OnSettingsConfigurationUpdated(settingsconfiguration);

            var itemToUpdate = Context.SettingsConfigurations
                              .Where(i => i.fldRecordID == settingsconfiguration.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(settingsconfiguration);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSettingsConfigurationUpdated(settingsconfiguration);

            return settingsconfiguration;
        }

        partial void OnSettingsConfigurationDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration item);
        partial void OnAfterSettingsConfigurationDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration> DeleteSettingsConfiguration(int fldrecordid)
        {
            var itemToDelete = Context.SettingsConfigurations
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSettingsConfigurationDeleted(itemToDelete);


            Context.SettingsConfigurations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSettingsConfigurationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSettingsContactsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/settingscontacts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/settingscontacts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSettingsContactsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/settingscontacts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/settingscontacts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSettingsContactsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact>> GetSettingsContacts(Query query = null)
        {
            var items = Context.SettingsContacts.AsQueryable();


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

            OnSettingsContactsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSettingsContactGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact item);
        partial void OnGetSettingsContactByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact> GetSettingsContactByFldRecordId(int fldrecordid)
        {
            var items = Context.SettingsContacts
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetSettingsContactByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnSettingsContactGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSettingsContactCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact item);
        partial void OnAfterSettingsContactCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact> CreateSettingsContact(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact settingscontact)
        {
            OnSettingsContactCreated(settingscontact);

            var existingItem = Context.SettingsContacts
                              .Where(i => i.fldRecordID == settingscontact.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SettingsContacts.Add(settingscontact);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(settingscontact).State = EntityState.Detached;
                throw;
            }

            OnAfterSettingsContactCreated(settingscontact);

            return settingscontact;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact> CancelSettingsContactChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSettingsContactUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact item);
        partial void OnAfterSettingsContactUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact> UpdateSettingsContact(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact settingscontact)
        {
            OnSettingsContactUpdated(settingscontact);

            var itemToUpdate = Context.SettingsContacts
                              .Where(i => i.fldRecordID == settingscontact.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(settingscontact);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSettingsContactUpdated(settingscontact);

            return settingscontact;
        }

        partial void OnSettingsContactDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact item);
        partial void OnAfterSettingsContactDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact> DeleteSettingsContact(int fldrecordid)
        {
            var itemToDelete = Context.SettingsContacts
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSettingsContactDeleted(itemToDelete);


            Context.SettingsContacts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSettingsContactDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblCrossReferencesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/tblcrossreferences/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/tblcrossreferences/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblCrossReferencesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_billing/tblcrossreferences/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_billing/tblcrossreferences/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblCrossReferencesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference>> GetTblCrossReferences(Query query = null)
        {
            var items = Context.TblCrossReferences.AsQueryable();


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

            OnTblCrossReferencesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblCrossReferenceGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference item);
        partial void OnGetTblCrossReferenceByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference> GetTblCrossReferenceByFldRecordId(int fldrecordid)
        {
            var items = Context.TblCrossReferences
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblCrossReferenceByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblCrossReferenceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblCrossReferenceCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference item);
        partial void OnAfterTblCrossReferenceCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference> CreateTblCrossReference(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference tblcrossreference)
        {
            OnTblCrossReferenceCreated(tblcrossreference);

            var existingItem = Context.TblCrossReferences
                              .Where(i => i.fldRecordID == tblcrossreference.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblCrossReferences.Add(tblcrossreference);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblcrossreference).State = EntityState.Detached;
                throw;
            }

            OnAfterTblCrossReferenceCreated(tblcrossreference);

            return tblcrossreference;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference> CancelTblCrossReferenceChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblCrossReferenceUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference item);
        partial void OnAfterTblCrossReferenceUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference> UpdateTblCrossReference(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference tblcrossreference)
        {
            OnTblCrossReferenceUpdated(tblcrossreference);

            var itemToUpdate = Context.TblCrossReferences
                              .Where(i => i.fldRecordID == tblcrossreference.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblcrossreference);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblCrossReferenceUpdated(tblcrossreference);

            return tblcrossreference;
        }

        partial void OnTblCrossReferenceDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference item);
        partial void OnAfterTblCrossReferenceDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference> DeleteTblCrossReference(int fldrecordid)
        {
            var itemToDelete = Context.TblCrossReferences
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblCrossReferenceDeleted(itemToDelete);


            Context.TblCrossReferences.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblCrossReferenceDeleted(itemToDelete);

            return itemToDelete;
        }
          public async Task<int> SpGetBillingDetailsByDateByAccounts(string StartDate, string EndDate, string DealerCloud, string Brand, string SubBrand, bool? ForPublication, bool? ShowZeroPriceTrans, bool? ShowDetails, bool? SaveDatatoTemporaryTable)
      {
          OnSpGetBillingDetailsByDateByAccountsDefaultParams(ref StartDate, ref EndDate, ref DealerCloud, ref Brand, ref SubBrand, ref ForPublication, ref ShowZeroPriceTrans, ref ShowDetails, ref SaveDatatoTemporaryTable);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@StartDate", SqlDbType.DateTime, -1) {Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@EndDate", SqlDbType.DateTime, -1) {Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@DealerCloud", SqlDbType.VarChar, 11) {Direction = ParameterDirection.Input, Value = DealerCloud},
              new SqlParameter("@Brand", SqlDbType.VarChar, 10) {Direction = ParameterDirection.Input, Value = Brand},
              new SqlParameter("@SubBrand", SqlDbType.VarChar, 10) {Direction = ParameterDirection.Input, Value = SubBrand},
              new SqlParameter("@ForPublication", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ForPublication},
              new SqlParameter("@ShowZeroPriceTrans", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ShowZeroPriceTrans},
              new SqlParameter("@ShowDetails", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ShowDetails},
              new SqlParameter("@SaveDatatoTemporaryTable", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = SaveDatatoTemporaryTable},

          };

          foreach(var _p in @params)
          {
              if((_p.Direction == ParameterDirection.Input || _p.Direction == ParameterDirection.InputOutput) && _p.Value == null)
              {
                  _p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[sp_Get_Billing_Details_By_Date_By_Account] @StartDate, @EndDate, @DealerCloud, @Brand, @SubBrand, @ForPublication, @ShowZeroPriceTrans, @ShowDetails, @SaveDatatoTemporaryTable", @params);

          int result = Convert.ToInt32(@params[0].Value);


          OnSpGetBillingDetailsByDateByAccountsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnSpGetBillingDetailsByDateByAccountsDefaultParams(ref string StartDate, ref string EndDate, ref string DealerCloud, ref string Brand, ref string SubBrand, ref bool? ForPublication, ref bool? ShowZeroPriceTrans, ref bool? ShowDetails, ref bool? SaveDatatoTemporaryTable);
      partial void OnSpGetBillingDetailsByDateByAccountsInvoke(ref int result);
      public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SpGetGeocodeByAddressOrPlaceResult> SpGetGeocodeByAddressOrPlaces(string APIkey, string Address, string City, string State, string Country, string PostalCode, string County, decimal? GPSLatitude, decimal? GPSLongitude, string MapURL, string PlaceID)
      {
          OnSpGetGeocodeByAddressOrPlacesDefaultParams(ref APIkey, ref Address, ref City, ref State, ref Country, ref PostalCode, ref County, ref GPSLatitude, ref GPSLongitude, ref MapURL, ref PlaceID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@APIkey", SqlDbType.VarChar, 100) {Direction = ParameterDirection.InputOutput, Value = APIkey},
              new SqlParameter("@Address", SqlDbType.VarChar, 80) {Direction = ParameterDirection.InputOutput, Value = Address},
              new SqlParameter("@City", SqlDbType.VarChar, 40) {Direction = ParameterDirection.InputOutput, Value = City},
              new SqlParameter("@State", SqlDbType.VarChar, 40) {Direction = ParameterDirection.InputOutput, Value = State},
              new SqlParameter("@Country", SqlDbType.VarChar, 40) {Direction = ParameterDirection.InputOutput, Value = Country},
              new SqlParameter("@PostalCode", SqlDbType.VarChar, 20) {Direction = ParameterDirection.InputOutput, Value = PostalCode},
              new SqlParameter("@County", SqlDbType.VarChar, 40) {Direction = ParameterDirection.InputOutput, Value = County},
              new SqlParameter("@GPSLatitude", SqlDbType.Decimal, -1) {Direction = ParameterDirection.InputOutput, Value = GPSLatitude},
              new SqlParameter("@GPSLongitude", SqlDbType.Decimal, -1) {Direction = ParameterDirection.InputOutput, Value = GPSLongitude},
              new SqlParameter("@MapURL", SqlDbType.VarChar, 1024) {Direction = ParameterDirection.InputOutput, Value = MapURL},
              new SqlParameter("@PlaceID", SqlDbType.VarChar, 250) {Direction = ParameterDirection.InputOutput, Value = PlaceID},

          };

          foreach(var _p in @params)
          {
              if((_p.Direction == ParameterDirection.Input || _p.Direction == ParameterDirection.InputOutput) && _p.Value == null)
              {
                  _p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[sp_Get_Geocode_by_Address_or_Place] @APIkey out, @Address out, @City out, @State out, @Country out, @PostalCode out, @County out, @GPSLatitude out, @GPSLongitude out, @MapURL out, @PlaceID out", @params);

          var result = new ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SpGetGeocodeByAddressOrPlaceResult();

          foreach(var _p in @params)
          {
            if((_p.Direction == ParameterDirection.Output || _p.Direction == ParameterDirection.InputOutput) && _p.Value == DBNull.Value)
            {
                _p.Value = null;
            }
          }
            
          result.returnValue = Convert.ToInt32(@params[0].Value);
          result.APIkey = Convert.ToString(@params[1].Value);
          result.Address = Convert.ToString(@params[2].Value);
          result.City = Convert.ToString(@params[3].Value);
          result.State = Convert.ToString(@params[4].Value);
          result.Country = Convert.ToString(@params[5].Value);
          result.PostalCode = Convert.ToString(@params[6].Value);
          result.County = Convert.ToString(@params[7].Value);
          result.GPSLatitude = Convert.ToDecimal(@params[8].Value);
          result.GPSLongitude = Convert.ToDecimal(@params[9].Value);
          result.MapURL = Convert.ToString(@params[10].Value);
          result.PlaceID = Convert.ToString(@params[11].Value);


          OnSpGetGeocodeByAddressOrPlacesInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnSpGetGeocodeByAddressOrPlacesDefaultParams(ref string APIkey, ref string Address, ref string City, ref string State, ref string Country, ref string PostalCode, ref string County, ref decimal? GPSLatitude, ref decimal? GPSLongitude, ref string MapURL, ref string PlaceID);
      partial void OnSpGetGeocodeByAddressOrPlacesInvoke(ref ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SpGetGeocodeByAddressOrPlaceResult result);
      public async Task<int> SpInsertDataFromXebras()
      {
          OnSpInsertDataFromXebrasDefaultParams();

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},

          };

          foreach(var _p in @params)
          {
              if((_p.Direction == ParameterDirection.Input || _p.Direction == ParameterDirection.InputOutput) && _p.Value == null)
              {
                  _p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[sp_Insert_Data_From_Xebra] ", @params);

          int result = Convert.ToInt32(@params[0].Value);


          OnSpInsertDataFromXebrasInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnSpInsertDataFromXebrasDefaultParams();
      partial void OnSpInsertDataFromXebrasInvoke(ref int result);
    }
}