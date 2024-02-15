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
    public partial class Throttle_Core_CustomerService
    {
        Throttle_Core_CustomerContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly Throttle_Core_CustomerContext context;
        private readonly NavigationManager navigationManager;

        public Throttle_Core_CustomerService(Throttle_Core_CustomerContext context, NavigationManager navigationManager)
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


        public async Task ExportTblCustomersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblCustomersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblCustomersRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer>> GetTblCustomers(Query query = null)
        {
            var items = Context.TblCustomers.AsQueryable();


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

            OnTblCustomersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblCustomerGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer item);
        partial void OnGetTblCustomerByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer> GetTblCustomerByFldRecordId(int fldrecordid)
        {
            var items = Context.TblCustomers
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblCustomerByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblCustomerGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblCustomerCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer item);
        partial void OnAfterTblCustomerCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer> CreateTblCustomer(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer tblcustomer)
        {
            OnTblCustomerCreated(tblcustomer);

            var existingItem = Context.TblCustomers
                              .Where(i => i.fldRecordID == tblcustomer.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblCustomers.Add(tblcustomer);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblcustomer).State = EntityState.Detached;
                throw;
            }

            OnAfterTblCustomerCreated(tblcustomer);

            return tblcustomer;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer> CancelTblCustomerChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblCustomerUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer item);
        partial void OnAfterTblCustomerUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer> UpdateTblCustomer(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer tblcustomer)
        {
            OnTblCustomerUpdated(tblcustomer);

            var itemToUpdate = Context.TblCustomers
                              .Where(i => i.fldRecordID == tblcustomer.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblcustomer);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblCustomerUpdated(tblcustomer);

            return tblcustomer;
        }

        partial void OnTblCustomerDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer item);
        partial void OnAfterTblCustomerDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer> DeleteTblCustomer(int fldrecordid)
        {
            var itemToDelete = Context.TblCustomers
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblCustomerDeleted(itemToDelete);


            Context.TblCustomers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblCustomerDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblCustomerBrandsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerbrands/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerbrands/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblCustomerBrandsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerbrands/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerbrands/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblCustomerBrandsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand>> GetTblCustomerBrands(Query query = null)
        {
            var items = Context.TblCustomerBrands.AsQueryable();


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

            OnTblCustomerBrandsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblCustomerBrandGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand item);
        partial void OnGetTblCustomerBrandByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand> GetTblCustomerBrandByFldRecordId(int fldrecordid)
        {
            var items = Context.TblCustomerBrands
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblCustomerBrandByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblCustomerBrandGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblCustomerBrandCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand item);
        partial void OnAfterTblCustomerBrandCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand> CreateTblCustomerBrand(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand tblcustomerbrand)
        {
            OnTblCustomerBrandCreated(tblcustomerbrand);

            var existingItem = Context.TblCustomerBrands
                              .Where(i => i.fldRecordID == tblcustomerbrand.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblCustomerBrands.Add(tblcustomerbrand);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblcustomerbrand).State = EntityState.Detached;
                throw;
            }

            OnAfterTblCustomerBrandCreated(tblcustomerbrand);

            return tblcustomerbrand;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand> CancelTblCustomerBrandChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblCustomerBrandUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand item);
        partial void OnAfterTblCustomerBrandUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand> UpdateTblCustomerBrand(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand tblcustomerbrand)
        {
            OnTblCustomerBrandUpdated(tblcustomerbrand);

            var itemToUpdate = Context.TblCustomerBrands
                              .Where(i => i.fldRecordID == tblcustomerbrand.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblcustomerbrand);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblCustomerBrandUpdated(tblcustomerbrand);

            return tblcustomerbrand;
        }

        partial void OnTblCustomerBrandDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand item);
        partial void OnAfterTblCustomerBrandDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand> DeleteTblCustomerBrand(int fldrecordid)
        {
            var itemToDelete = Context.TblCustomerBrands
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblCustomerBrandDeleted(itemToDelete);


            Context.TblCustomerBrands.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblCustomerBrandDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblCustomerBrandsStoresJoinsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerbrandsstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerbrandsstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblCustomerBrandsStoresJoinsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerbrandsstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerbrandsstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblCustomerBrandsStoresJoinsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin>> GetTblCustomerBrandsStoresJoins(Query query = null)
        {
            var items = Context.TblCustomerBrandsStoresJoins.AsQueryable();


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

            OnTblCustomerBrandsStoresJoinsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblCustomerBrandsStoresJoinGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin item);
        partial void OnGetTblCustomerBrandsStoresJoinByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin> GetTblCustomerBrandsStoresJoinByFldRecordId(int fldrecordid)
        {
            var items = Context.TblCustomerBrandsStoresJoins
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblCustomerBrandsStoresJoinByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblCustomerBrandsStoresJoinGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblCustomerBrandsStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin item);
        partial void OnAfterTblCustomerBrandsStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin> CreateTblCustomerBrandsStoresJoin(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin tblcustomerbrandsstoresjoin)
        {
            OnTblCustomerBrandsStoresJoinCreated(tblcustomerbrandsstoresjoin);

            var existingItem = Context.TblCustomerBrandsStoresJoins
                              .Where(i => i.fldRecordID == tblcustomerbrandsstoresjoin.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblCustomerBrandsStoresJoins.Add(tblcustomerbrandsstoresjoin);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblcustomerbrandsstoresjoin).State = EntityState.Detached;
                throw;
            }

            OnAfterTblCustomerBrandsStoresJoinCreated(tblcustomerbrandsstoresjoin);

            return tblcustomerbrandsstoresjoin;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin> CancelTblCustomerBrandsStoresJoinChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblCustomerBrandsStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin item);
        partial void OnAfterTblCustomerBrandsStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin> UpdateTblCustomerBrandsStoresJoin(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin tblcustomerbrandsstoresjoin)
        {
            OnTblCustomerBrandsStoresJoinUpdated(tblcustomerbrandsstoresjoin);

            var itemToUpdate = Context.TblCustomerBrandsStoresJoins
                              .Where(i => i.fldRecordID == tblcustomerbrandsstoresjoin.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblcustomerbrandsstoresjoin);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblCustomerBrandsStoresJoinUpdated(tblcustomerbrandsstoresjoin);

            return tblcustomerbrandsstoresjoin;
        }

        partial void OnTblCustomerBrandsStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin item);
        partial void OnAfterTblCustomerBrandsStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin> DeleteTblCustomerBrandsStoresJoin(int fldrecordid)
        {
            var itemToDelete = Context.TblCustomerBrandsStoresJoins
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblCustomerBrandsStoresJoinDeleted(itemToDelete);


            Context.TblCustomerBrandsStoresJoins.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblCustomerBrandsStoresJoinDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblCustomerContactsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomercontacts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomercontacts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblCustomerContactsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomercontacts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomercontacts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblCustomerContactsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact>> GetTblCustomerContacts(Query query = null)
        {
            var items = Context.TblCustomerContacts.AsQueryable();


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

            OnTblCustomerContactsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblCustomerContactGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact item);
        partial void OnGetTblCustomerContactByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact> GetTblCustomerContactByFldRecordId(int fldrecordid)
        {
            var items = Context.TblCustomerContacts
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblCustomerContactByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblCustomerContactGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblCustomerContactCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact item);
        partial void OnAfterTblCustomerContactCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact> CreateTblCustomerContact(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact tblcustomercontact)
        {
            OnTblCustomerContactCreated(tblcustomercontact);

            var existingItem = Context.TblCustomerContacts
                              .Where(i => i.fldRecordID == tblcustomercontact.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblCustomerContacts.Add(tblcustomercontact);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblcustomercontact).State = EntityState.Detached;
                throw;
            }

            OnAfterTblCustomerContactCreated(tblcustomercontact);

            return tblcustomercontact;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact> CancelTblCustomerContactChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblCustomerContactUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact item);
        partial void OnAfterTblCustomerContactUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact> UpdateTblCustomerContact(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact tblcustomercontact)
        {
            OnTblCustomerContactUpdated(tblcustomercontact);

            var itemToUpdate = Context.TblCustomerContacts
                              .Where(i => i.fldRecordID == tblcustomercontact.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblcustomercontact);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblCustomerContactUpdated(tblcustomercontact);

            return tblcustomercontact;
        }

        partial void OnTblCustomerContactDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact item);
        partial void OnAfterTblCustomerContactDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact> DeleteTblCustomerContact(int fldrecordid)
        {
            var itemToDelete = Context.TblCustomerContacts
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblCustomerContactDeleted(itemToDelete);


            Context.TblCustomerContacts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblCustomerContactDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblCustomerContactsStoresJoinsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomercontactsstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomercontactsstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblCustomerContactsStoresJoinsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomercontactsstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomercontactsstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblCustomerContactsStoresJoinsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin>> GetTblCustomerContactsStoresJoins(Query query = null)
        {
            var items = Context.TblCustomerContactsStoresJoins.AsQueryable();


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

            OnTblCustomerContactsStoresJoinsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblCustomerContactsStoresJoinGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin item);
        partial void OnGetTblCustomerContactsStoresJoinByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin> GetTblCustomerContactsStoresJoinByFldRecordId(int fldrecordid)
        {
            var items = Context.TblCustomerContactsStoresJoins
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblCustomerContactsStoresJoinByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblCustomerContactsStoresJoinGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblCustomerContactsStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin item);
        partial void OnAfterTblCustomerContactsStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin> CreateTblCustomerContactsStoresJoin(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin tblcustomercontactsstoresjoin)
        {
            OnTblCustomerContactsStoresJoinCreated(tblcustomercontactsstoresjoin);

            var existingItem = Context.TblCustomerContactsStoresJoins
                              .Where(i => i.fldRecordID == tblcustomercontactsstoresjoin.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblCustomerContactsStoresJoins.Add(tblcustomercontactsstoresjoin);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblcustomercontactsstoresjoin).State = EntityState.Detached;
                throw;
            }

            OnAfterTblCustomerContactsStoresJoinCreated(tblcustomercontactsstoresjoin);

            return tblcustomercontactsstoresjoin;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin> CancelTblCustomerContactsStoresJoinChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblCustomerContactsStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin item);
        partial void OnAfterTblCustomerContactsStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin> UpdateTblCustomerContactsStoresJoin(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin tblcustomercontactsstoresjoin)
        {
            OnTblCustomerContactsStoresJoinUpdated(tblcustomercontactsstoresjoin);

            var itemToUpdate = Context.TblCustomerContactsStoresJoins
                              .Where(i => i.fldRecordID == tblcustomercontactsstoresjoin.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblcustomercontactsstoresjoin);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblCustomerContactsStoresJoinUpdated(tblcustomercontactsstoresjoin);

            return tblcustomercontactsstoresjoin;
        }

        partial void OnTblCustomerContactsStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin item);
        partial void OnAfterTblCustomerContactsStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin> DeleteTblCustomerContactsStoresJoin(int fldrecordid)
        {
            var itemToDelete = Context.TblCustomerContactsStoresJoins
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblCustomerContactsStoresJoinDeleted(itemToDelete);


            Context.TblCustomerContactsStoresJoins.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblCustomerContactsStoresJoinDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblCustomerFranchisesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerfranchises/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerfranchises/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblCustomerFranchisesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerfranchises/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerfranchises/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblCustomerFranchisesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise>> GetTblCustomerFranchises(Query query = null)
        {
            var items = Context.TblCustomerFranchises.AsQueryable();


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

            OnTblCustomerFranchisesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblCustomerFranchiseGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise item);
        partial void OnGetTblCustomerFranchiseByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise> GetTblCustomerFranchiseByFldRecordId(int fldrecordid)
        {
            var items = Context.TblCustomerFranchises
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblCustomerFranchiseByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblCustomerFranchiseGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblCustomerFranchiseCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise item);
        partial void OnAfterTblCustomerFranchiseCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise> CreateTblCustomerFranchise(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise tblcustomerfranchise)
        {
            OnTblCustomerFranchiseCreated(tblcustomerfranchise);

            var existingItem = Context.TblCustomerFranchises
                              .Where(i => i.fldRecordID == tblcustomerfranchise.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblCustomerFranchises.Add(tblcustomerfranchise);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblcustomerfranchise).State = EntityState.Detached;
                throw;
            }

            OnAfterTblCustomerFranchiseCreated(tblcustomerfranchise);

            return tblcustomerfranchise;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise> CancelTblCustomerFranchiseChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblCustomerFranchiseUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise item);
        partial void OnAfterTblCustomerFranchiseUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise> UpdateTblCustomerFranchise(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise tblcustomerfranchise)
        {
            OnTblCustomerFranchiseUpdated(tblcustomerfranchise);

            var itemToUpdate = Context.TblCustomerFranchises
                              .Where(i => i.fldRecordID == tblcustomerfranchise.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblcustomerfranchise);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblCustomerFranchiseUpdated(tblcustomerfranchise);

            return tblcustomerfranchise;
        }

        partial void OnTblCustomerFranchiseDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise item);
        partial void OnAfterTblCustomerFranchiseDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise> DeleteTblCustomerFranchise(int fldrecordid)
        {
            var itemToDelete = Context.TblCustomerFranchises
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblCustomerFranchiseDeleted(itemToDelete);


            Context.TblCustomerFranchises.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblCustomerFranchiseDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblCustomerFranchisesStoresJoinsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerfranchisesstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerfranchisesstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblCustomerFranchisesStoresJoinsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerfranchisesstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerfranchisesstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblCustomerFranchisesStoresJoinsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin>> GetTblCustomerFranchisesStoresJoins(Query query = null)
        {
            var items = Context.TblCustomerFranchisesStoresJoins.AsQueryable();


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

            OnTblCustomerFranchisesStoresJoinsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblCustomerFranchisesStoresJoinGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin item);
        partial void OnGetTblCustomerFranchisesStoresJoinByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin> GetTblCustomerFranchisesStoresJoinByFldRecordId(int fldrecordid)
        {
            var items = Context.TblCustomerFranchisesStoresJoins
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblCustomerFranchisesStoresJoinByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblCustomerFranchisesStoresJoinGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblCustomerFranchisesStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin item);
        partial void OnAfterTblCustomerFranchisesStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin> CreateTblCustomerFranchisesStoresJoin(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin tblcustomerfranchisesstoresjoin)
        {
            OnTblCustomerFranchisesStoresJoinCreated(tblcustomerfranchisesstoresjoin);

            var existingItem = Context.TblCustomerFranchisesStoresJoins
                              .Where(i => i.fldRecordID == tblcustomerfranchisesstoresjoin.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblCustomerFranchisesStoresJoins.Add(tblcustomerfranchisesstoresjoin);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblcustomerfranchisesstoresjoin).State = EntityState.Detached;
                throw;
            }

            OnAfterTblCustomerFranchisesStoresJoinCreated(tblcustomerfranchisesstoresjoin);

            return tblcustomerfranchisesstoresjoin;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin> CancelTblCustomerFranchisesStoresJoinChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblCustomerFranchisesStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin item);
        partial void OnAfterTblCustomerFranchisesStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin> UpdateTblCustomerFranchisesStoresJoin(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin tblcustomerfranchisesstoresjoin)
        {
            OnTblCustomerFranchisesStoresJoinUpdated(tblcustomerfranchisesstoresjoin);

            var itemToUpdate = Context.TblCustomerFranchisesStoresJoins
                              .Where(i => i.fldRecordID == tblcustomerfranchisesstoresjoin.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblcustomerfranchisesstoresjoin);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblCustomerFranchisesStoresJoinUpdated(tblcustomerfranchisesstoresjoin);

            return tblcustomerfranchisesstoresjoin;
        }

        partial void OnTblCustomerFranchisesStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin item);
        partial void OnAfterTblCustomerFranchisesStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin> DeleteTblCustomerFranchisesStoresJoin(int fldrecordid)
        {
            var itemToDelete = Context.TblCustomerFranchisesStoresJoins
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblCustomerFranchisesStoresJoinDeleted(itemToDelete);


            Context.TblCustomerFranchisesStoresJoins.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblCustomerFranchisesStoresJoinDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblCustomerGroupsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomergroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomergroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblCustomerGroupsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomergroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomergroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblCustomerGroupsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup>> GetTblCustomerGroups(Query query = null)
        {
            var items = Context.TblCustomerGroups.AsQueryable();


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

            OnTblCustomerGroupsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblCustomerGroupGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup item);
        partial void OnGetTblCustomerGroupByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup> GetTblCustomerGroupByFldRecordId(int fldrecordid)
        {
            var items = Context.TblCustomerGroups
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblCustomerGroupByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblCustomerGroupGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblCustomerGroupCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup item);
        partial void OnAfterTblCustomerGroupCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup> CreateTblCustomerGroup(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup tblcustomergroup)
        {
            OnTblCustomerGroupCreated(tblcustomergroup);

            var existingItem = Context.TblCustomerGroups
                              .Where(i => i.fldRecordID == tblcustomergroup.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblCustomerGroups.Add(tblcustomergroup);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblcustomergroup).State = EntityState.Detached;
                throw;
            }

            OnAfterTblCustomerGroupCreated(tblcustomergroup);

            return tblcustomergroup;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup> CancelTblCustomerGroupChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblCustomerGroupUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup item);
        partial void OnAfterTblCustomerGroupUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup> UpdateTblCustomerGroup(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup tblcustomergroup)
        {
            OnTblCustomerGroupUpdated(tblcustomergroup);

            var itemToUpdate = Context.TblCustomerGroups
                              .Where(i => i.fldRecordID == tblcustomergroup.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblcustomergroup);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblCustomerGroupUpdated(tblcustomergroup);

            return tblcustomergroup;
        }

        partial void OnTblCustomerGroupDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup item);
        partial void OnAfterTblCustomerGroupDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup> DeleteTblCustomerGroup(int fldrecordid)
        {
            var itemToDelete = Context.TblCustomerGroups
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblCustomerGroupDeleted(itemToDelete);


            Context.TblCustomerGroups.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblCustomerGroupDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblCustomerGroupsStoresJoinsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomergroupsstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomergroupsstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblCustomerGroupsStoresJoinsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomergroupsstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomergroupsstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblCustomerGroupsStoresJoinsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin>> GetTblCustomerGroupsStoresJoins(Query query = null)
        {
            var items = Context.TblCustomerGroupsStoresJoins.AsQueryable();


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

            OnTblCustomerGroupsStoresJoinsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblCustomerGroupsStoresJoinGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin item);
        partial void OnGetTblCustomerGroupsStoresJoinByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin> GetTblCustomerGroupsStoresJoinByFldRecordId(int fldrecordid)
        {
            var items = Context.TblCustomerGroupsStoresJoins
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblCustomerGroupsStoresJoinByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblCustomerGroupsStoresJoinGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblCustomerGroupsStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin item);
        partial void OnAfterTblCustomerGroupsStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin> CreateTblCustomerGroupsStoresJoin(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin tblcustomergroupsstoresjoin)
        {
            OnTblCustomerGroupsStoresJoinCreated(tblcustomergroupsstoresjoin);

            var existingItem = Context.TblCustomerGroupsStoresJoins
                              .Where(i => i.fldRecordID == tblcustomergroupsstoresjoin.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblCustomerGroupsStoresJoins.Add(tblcustomergroupsstoresjoin);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblcustomergroupsstoresjoin).State = EntityState.Detached;
                throw;
            }

            OnAfterTblCustomerGroupsStoresJoinCreated(tblcustomergroupsstoresjoin);

            return tblcustomergroupsstoresjoin;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin> CancelTblCustomerGroupsStoresJoinChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblCustomerGroupsStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin item);
        partial void OnAfterTblCustomerGroupsStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin> UpdateTblCustomerGroupsStoresJoin(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin tblcustomergroupsstoresjoin)
        {
            OnTblCustomerGroupsStoresJoinUpdated(tblcustomergroupsstoresjoin);

            var itemToUpdate = Context.TblCustomerGroupsStoresJoins
                              .Where(i => i.fldRecordID == tblcustomergroupsstoresjoin.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblcustomergroupsstoresjoin);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblCustomerGroupsStoresJoinUpdated(tblcustomergroupsstoresjoin);

            return tblcustomergroupsstoresjoin;
        }

        partial void OnTblCustomerGroupsStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin item);
        partial void OnAfterTblCustomerGroupsStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin> DeleteTblCustomerGroupsStoresJoin(int fldrecordid)
        {
            var itemToDelete = Context.TblCustomerGroupsStoresJoins
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblCustomerGroupsStoresJoinDeleted(itemToDelete);


            Context.TblCustomerGroupsStoresJoins.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblCustomerGroupsStoresJoinDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblCustomerIndustriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerindustries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerindustries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblCustomerIndustriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerindustries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerindustries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblCustomerIndustriesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry>> GetTblCustomerIndustries(Query query = null)
        {
            var items = Context.TblCustomerIndustries.AsQueryable();


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

            OnTblCustomerIndustriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblCustomerIndustryGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry item);
        partial void OnGetTblCustomerIndustryByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry> GetTblCustomerIndustryByFldRecordId(int fldrecordid)
        {
            var items = Context.TblCustomerIndustries
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblCustomerIndustryByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblCustomerIndustryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblCustomerIndustryCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry item);
        partial void OnAfterTblCustomerIndustryCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry> CreateTblCustomerIndustry(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry tblcustomerindustry)
        {
            OnTblCustomerIndustryCreated(tblcustomerindustry);

            var existingItem = Context.TblCustomerIndustries
                              .Where(i => i.fldRecordID == tblcustomerindustry.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblCustomerIndustries.Add(tblcustomerindustry);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblcustomerindustry).State = EntityState.Detached;
                throw;
            }

            OnAfterTblCustomerIndustryCreated(tblcustomerindustry);

            return tblcustomerindustry;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry> CancelTblCustomerIndustryChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblCustomerIndustryUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry item);
        partial void OnAfterTblCustomerIndustryUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry> UpdateTblCustomerIndustry(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry tblcustomerindustry)
        {
            OnTblCustomerIndustryUpdated(tblcustomerindustry);

            var itemToUpdate = Context.TblCustomerIndustries
                              .Where(i => i.fldRecordID == tblcustomerindustry.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblcustomerindustry);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblCustomerIndustryUpdated(tblcustomerindustry);

            return tblcustomerindustry;
        }

        partial void OnTblCustomerIndustryDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry item);
        partial void OnAfterTblCustomerIndustryDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry> DeleteTblCustomerIndustry(int fldrecordid)
        {
            var itemToDelete = Context.TblCustomerIndustries
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblCustomerIndustryDeleted(itemToDelete);


            Context.TblCustomerIndustries.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblCustomerIndustryDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblCustomerIndustryStoresJoinsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerindustrystoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerindustrystoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblCustomerIndustryStoresJoinsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerindustrystoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerindustrystoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblCustomerIndustryStoresJoinsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin>> GetTblCustomerIndustryStoresJoins(Query query = null)
        {
            var items = Context.TblCustomerIndustryStoresJoins.AsQueryable();


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

            OnTblCustomerIndustryStoresJoinsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblCustomerIndustryStoresJoinGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin item);
        partial void OnGetTblCustomerIndustryStoresJoinByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin> GetTblCustomerIndustryStoresJoinByFldRecordId(int fldrecordid)
        {
            var items = Context.TblCustomerIndustryStoresJoins
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblCustomerIndustryStoresJoinByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblCustomerIndustryStoresJoinGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblCustomerIndustryStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin item);
        partial void OnAfterTblCustomerIndustryStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin> CreateTblCustomerIndustryStoresJoin(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin tblcustomerindustrystoresjoin)
        {
            OnTblCustomerIndustryStoresJoinCreated(tblcustomerindustrystoresjoin);

            var existingItem = Context.TblCustomerIndustryStoresJoins
                              .Where(i => i.fldRecordID == tblcustomerindustrystoresjoin.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblCustomerIndustryStoresJoins.Add(tblcustomerindustrystoresjoin);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblcustomerindustrystoresjoin).State = EntityState.Detached;
                throw;
            }

            OnAfterTblCustomerIndustryStoresJoinCreated(tblcustomerindustrystoresjoin);

            return tblcustomerindustrystoresjoin;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin> CancelTblCustomerIndustryStoresJoinChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblCustomerIndustryStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin item);
        partial void OnAfterTblCustomerIndustryStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin> UpdateTblCustomerIndustryStoresJoin(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin tblcustomerindustrystoresjoin)
        {
            OnTblCustomerIndustryStoresJoinUpdated(tblcustomerindustrystoresjoin);

            var itemToUpdate = Context.TblCustomerIndustryStoresJoins
                              .Where(i => i.fldRecordID == tblcustomerindustrystoresjoin.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblcustomerindustrystoresjoin);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblCustomerIndustryStoresJoinUpdated(tblcustomerindustrystoresjoin);

            return tblcustomerindustrystoresjoin;
        }

        partial void OnTblCustomerIndustryStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin item);
        partial void OnAfterTblCustomerIndustryStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin> DeleteTblCustomerIndustryStoresJoin(int fldrecordid)
        {
            var itemToDelete = Context.TblCustomerIndustryStoresJoins
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblCustomerIndustryStoresJoinDeleted(itemToDelete);


            Context.TblCustomerIndustryStoresJoins.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblCustomerIndustryStoresJoinDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblCustomerProductandServicesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerproductandservices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerproductandservices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblCustomerProductandServicesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerproductandservices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerproductandservices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblCustomerProductandServicesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService>> GetTblCustomerProductandServices(Query query = null)
        {
            var items = Context.TblCustomerProductandServices.AsQueryable();


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

            OnTblCustomerProductandServicesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblCustomerProductandServiceGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService item);
        partial void OnGetTblCustomerProductandServiceByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService> GetTblCustomerProductandServiceByFldRecordId(int fldrecordid)
        {
            var items = Context.TblCustomerProductandServices
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblCustomerProductandServiceByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblCustomerProductandServiceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblCustomerProductandServiceCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService item);
        partial void OnAfterTblCustomerProductandServiceCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService> CreateTblCustomerProductandService(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService tblcustomerproductandservice)
        {
            OnTblCustomerProductandServiceCreated(tblcustomerproductandservice);

            var existingItem = Context.TblCustomerProductandServices
                              .Where(i => i.fldRecordID == tblcustomerproductandservice.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblCustomerProductandServices.Add(tblcustomerproductandservice);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblcustomerproductandservice).State = EntityState.Detached;
                throw;
            }

            OnAfterTblCustomerProductandServiceCreated(tblcustomerproductandservice);

            return tblcustomerproductandservice;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService> CancelTblCustomerProductandServiceChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblCustomerProductandServiceUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService item);
        partial void OnAfterTblCustomerProductandServiceUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService> UpdateTblCustomerProductandService(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService tblcustomerproductandservice)
        {
            OnTblCustomerProductandServiceUpdated(tblcustomerproductandservice);

            var itemToUpdate = Context.TblCustomerProductandServices
                              .Where(i => i.fldRecordID == tblcustomerproductandservice.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblcustomerproductandservice);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblCustomerProductandServiceUpdated(tblcustomerproductandservice);

            return tblcustomerproductandservice;
        }

        partial void OnTblCustomerProductandServiceDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService item);
        partial void OnAfterTblCustomerProductandServiceDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService> DeleteTblCustomerProductandService(int fldrecordid)
        {
            var itemToDelete = Context.TblCustomerProductandServices
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblCustomerProductandServiceDeleted(itemToDelete);


            Context.TblCustomerProductandServices.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblCustomerProductandServiceDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblCustomerProductandServicesStoresJoinsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerproductandservicesstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerproductandservicesstoresjoins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblCustomerProductandServicesStoresJoinsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerproductandservicesstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerproductandservicesstoresjoins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblCustomerProductandServicesStoresJoinsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin>> GetTblCustomerProductandServicesStoresJoins(Query query = null)
        {
            var items = Context.TblCustomerProductandServicesStoresJoins.AsQueryable();


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

            OnTblCustomerProductandServicesStoresJoinsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblCustomerProductandServicesStoresJoinGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin item);
        partial void OnGetTblCustomerProductandServicesStoresJoinByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin> GetTblCustomerProductandServicesStoresJoinByFldRecordId(int fldrecordid)
        {
            var items = Context.TblCustomerProductandServicesStoresJoins
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblCustomerProductandServicesStoresJoinByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblCustomerProductandServicesStoresJoinGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblCustomerProductandServicesStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin item);
        partial void OnAfterTblCustomerProductandServicesStoresJoinCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin> CreateTblCustomerProductandServicesStoresJoin(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin tblcustomerproductandservicesstoresjoin)
        {
            OnTblCustomerProductandServicesStoresJoinCreated(tblcustomerproductandservicesstoresjoin);

            var existingItem = Context.TblCustomerProductandServicesStoresJoins
                              .Where(i => i.fldRecordID == tblcustomerproductandservicesstoresjoin.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblCustomerProductandServicesStoresJoins.Add(tblcustomerproductandservicesstoresjoin);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblcustomerproductandservicesstoresjoin).State = EntityState.Detached;
                throw;
            }

            OnAfterTblCustomerProductandServicesStoresJoinCreated(tblcustomerproductandservicesstoresjoin);

            return tblcustomerproductandservicesstoresjoin;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin> CancelTblCustomerProductandServicesStoresJoinChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblCustomerProductandServicesStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin item);
        partial void OnAfterTblCustomerProductandServicesStoresJoinUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin> UpdateTblCustomerProductandServicesStoresJoin(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin tblcustomerproductandservicesstoresjoin)
        {
            OnTblCustomerProductandServicesStoresJoinUpdated(tblcustomerproductandservicesstoresjoin);

            var itemToUpdate = Context.TblCustomerProductandServicesStoresJoins
                              .Where(i => i.fldRecordID == tblcustomerproductandservicesstoresjoin.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblcustomerproductandservicesstoresjoin);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblCustomerProductandServicesStoresJoinUpdated(tblcustomerproductandservicesstoresjoin);

            return tblcustomerproductandservicesstoresjoin;
        }

        partial void OnTblCustomerProductandServicesStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin item);
        partial void OnAfterTblCustomerProductandServicesStoresJoinDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin> DeleteTblCustomerProductandServicesStoresJoin(int fldrecordid)
        {
            var itemToDelete = Context.TblCustomerProductandServicesStoresJoins
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblCustomerProductandServicesStoresJoinDeleted(itemToDelete);


            Context.TblCustomerProductandServicesStoresJoins.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblCustomerProductandServicesStoresJoinDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblCustomerStoresToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerstores/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerstores/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblCustomerStoresToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_customer/tblcustomerstores/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_customer/tblcustomerstores/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblCustomerStoresRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore>> GetTblCustomerStores(Query query = null)
        {
            var items = Context.TblCustomerStores.AsQueryable();


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

            OnTblCustomerStoresRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblCustomerStoreGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore item);
        partial void OnGetTblCustomerStoreByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore> GetTblCustomerStoreByFldRecordId(int fldrecordid)
        {
            var items = Context.TblCustomerStores
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblCustomerStoreByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblCustomerStoreGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblCustomerStoreCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore item);
        partial void OnAfterTblCustomerStoreCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore> CreateTblCustomerStore(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore tblcustomerstore)
        {
            OnTblCustomerStoreCreated(tblcustomerstore);

            var existingItem = Context.TblCustomerStores
                              .Where(i => i.fldRecordID == tblcustomerstore.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblCustomerStores.Add(tblcustomerstore);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblcustomerstore).State = EntityState.Detached;
                throw;
            }

            OnAfterTblCustomerStoreCreated(tblcustomerstore);

            return tblcustomerstore;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore> CancelTblCustomerStoreChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblCustomerStoreUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore item);
        partial void OnAfterTblCustomerStoreUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore> UpdateTblCustomerStore(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore tblcustomerstore)
        {
            OnTblCustomerStoreUpdated(tblcustomerstore);

            var itemToUpdate = Context.TblCustomerStores
                              .Where(i => i.fldRecordID == tblcustomerstore.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblcustomerstore);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblCustomerStoreUpdated(tblcustomerstore);

            return tblcustomerstore;
        }

        partial void OnTblCustomerStoreDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore item);
        partial void OnAfterTblCustomerStoreDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore> DeleteTblCustomerStore(int fldrecordid)
        {
            var itemToDelete = Context.TblCustomerStores
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblCustomerStoreDeleted(itemToDelete);


            Context.TblCustomerStores.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblCustomerStoreDeleted(itemToDelete);

            return itemToDelete;
        }
        }
}