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
    public partial class Throttle_Core_SummaryService
    {
        Throttle_Core_SummaryContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly Throttle_Core_SummaryContext context;
        private readonly NavigationManager navigationManager;

        public Throttle_Core_SummaryService(Throttle_Core_SummaryContext context, NavigationManager navigationManager)
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


        public async Task ExportTblDailyTotalsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tbldailytotals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tbldailytotals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblDailyTotalsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tbldailytotals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tbldailytotals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblDailyTotalsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal>> GetTblDailyTotals(Query query = null)
        {
            var items = Context.TblDailyTotals.AsQueryable();


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

            OnTblDailyTotalsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblDailyTotalGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal item);
        partial void OnGetTblDailyTotalByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal> GetTblDailyTotalByFldRecordId(long fldrecordid)
        {
            var items = Context.TblDailyTotals
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblDailyTotalByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblDailyTotalGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblDailyTotalCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal item);
        partial void OnAfterTblDailyTotalCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal> CreateTblDailyTotal(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal tbldailytotal)
        {
            OnTblDailyTotalCreated(tbldailytotal);

            var existingItem = Context.TblDailyTotals
                              .Where(i => i.fldRecordID == tbldailytotal.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblDailyTotals.Add(tbldailytotal);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tbldailytotal).State = EntityState.Detached;
                throw;
            }

            OnAfterTblDailyTotalCreated(tbldailytotal);

            return tbldailytotal;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal> CancelTblDailyTotalChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblDailyTotalUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal item);
        partial void OnAfterTblDailyTotalUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal> UpdateTblDailyTotal(long fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal tbldailytotal)
        {
            OnTblDailyTotalUpdated(tbldailytotal);

            var itemToUpdate = Context.TblDailyTotals
                              .Where(i => i.fldRecordID == tbldailytotal.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tbldailytotal);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblDailyTotalUpdated(tbldailytotal);

            return tbldailytotal;
        }

        partial void OnTblDailyTotalDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal item);
        partial void OnAfterTblDailyTotalDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal> DeleteTblDailyTotal(long fldrecordid)
        {
            var itemToDelete = Context.TblDailyTotals
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblDailyTotalDeleted(itemToDelete);


            Context.TblDailyTotals.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblDailyTotalDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblDailyTotalsLaborsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tbldailytotalslabors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tbldailytotalslabors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblDailyTotalsLaborsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tbldailytotalslabors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tbldailytotalslabors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblDailyTotalsLaborsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsLabor> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsLabor>> GetTblDailyTotalsLabors(Query query = null)
        {
            var items = Context.TblDailyTotalsLabors.AsQueryable();


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

            OnTblDailyTotalsLaborsRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportTblDailyTotalsOperatorsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tbldailytotalsoperators/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tbldailytotalsoperators/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblDailyTotalsOperatorsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tbldailytotalsoperators/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tbldailytotalsoperators/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblDailyTotalsOperatorsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator>> GetTblDailyTotalsOperators(Query query = null)
        {
            var items = Context.TblDailyTotalsOperators.AsQueryable();


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

            OnTblDailyTotalsOperatorsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblDailyTotalsOperatorGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator item);
        partial void OnGetTblDailyTotalsOperatorByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator> GetTblDailyTotalsOperatorByFldRecordId(long fldrecordid)
        {
            var items = Context.TblDailyTotalsOperators
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblDailyTotalsOperatorByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblDailyTotalsOperatorGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblDailyTotalsOperatorCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator item);
        partial void OnAfterTblDailyTotalsOperatorCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator> CreateTblDailyTotalsOperator(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator tbldailytotalsoperator)
        {
            OnTblDailyTotalsOperatorCreated(tbldailytotalsoperator);

            var existingItem = Context.TblDailyTotalsOperators
                              .Where(i => i.fldRecordID == tbldailytotalsoperator.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblDailyTotalsOperators.Add(tbldailytotalsoperator);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tbldailytotalsoperator).State = EntityState.Detached;
                throw;
            }

            OnAfterTblDailyTotalsOperatorCreated(tbldailytotalsoperator);

            return tbldailytotalsoperator;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator> CancelTblDailyTotalsOperatorChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblDailyTotalsOperatorUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator item);
        partial void OnAfterTblDailyTotalsOperatorUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator> UpdateTblDailyTotalsOperator(long fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator tbldailytotalsoperator)
        {
            OnTblDailyTotalsOperatorUpdated(tbldailytotalsoperator);

            var itemToUpdate = Context.TblDailyTotalsOperators
                              .Where(i => i.fldRecordID == tbldailytotalsoperator.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tbldailytotalsoperator);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblDailyTotalsOperatorUpdated(tbldailytotalsoperator);

            return tbldailytotalsoperator;
        }

        partial void OnTblDailyTotalsOperatorDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator item);
        partial void OnAfterTblDailyTotalsOperatorDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator> DeleteTblDailyTotalsOperator(long fldrecordid)
        {
            var itemToDelete = Context.TblDailyTotalsOperators
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblDailyTotalsOperatorDeleted(itemToDelete);


            Context.TblDailyTotalsOperators.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblDailyTotalsOperatorDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblDailyTotalsPartsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tbldailytotalsparts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tbldailytotalsparts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblDailyTotalsPartsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tbldailytotalsparts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tbldailytotalsparts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblDailyTotalsPartsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart>> GetTblDailyTotalsParts(Query query = null)
        {
            var items = Context.TblDailyTotalsParts.AsQueryable();


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

            OnTblDailyTotalsPartsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblDailyTotalsPartGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart item);
        partial void OnGetTblDailyTotalsPartByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart> GetTblDailyTotalsPartByFldRecordId(long fldrecordid)
        {
            var items = Context.TblDailyTotalsParts
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblDailyTotalsPartByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblDailyTotalsPartGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblDailyTotalsPartCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart item);
        partial void OnAfterTblDailyTotalsPartCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart> CreateTblDailyTotalsPart(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart tbldailytotalspart)
        {
            OnTblDailyTotalsPartCreated(tbldailytotalspart);

            var existingItem = Context.TblDailyTotalsParts
                              .Where(i => i.fldRecordID == tbldailytotalspart.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblDailyTotalsParts.Add(tbldailytotalspart);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tbldailytotalspart).State = EntityState.Detached;
                throw;
            }

            OnAfterTblDailyTotalsPartCreated(tbldailytotalspart);

            return tbldailytotalspart;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart> CancelTblDailyTotalsPartChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblDailyTotalsPartUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart item);
        partial void OnAfterTblDailyTotalsPartUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart> UpdateTblDailyTotalsPart(long fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart tbldailytotalspart)
        {
            OnTblDailyTotalsPartUpdated(tbldailytotalspart);

            var itemToUpdate = Context.TblDailyTotalsParts
                              .Where(i => i.fldRecordID == tbldailytotalspart.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tbldailytotalspart);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblDailyTotalsPartUpdated(tbldailytotalspart);

            return tbldailytotalspart;
        }

        partial void OnTblDailyTotalsPartDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart item);
        partial void OnAfterTblDailyTotalsPartDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart> DeleteTblDailyTotalsPart(long fldrecordid)
        {
            var itemToDelete = Context.TblDailyTotalsParts
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblDailyTotalsPartDeleted(itemToDelete);


            Context.TblDailyTotalsParts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblDailyTotalsPartDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblHelperCouponsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelpercoupons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelpercoupons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblHelperCouponsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelpercoupons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelpercoupons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblHelperCouponsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon>> GetTblHelperCoupons(Query query = null)
        {
            var items = Context.TblHelperCoupons.AsQueryable();


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

            OnTblHelperCouponsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblHelperCouponGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon item);
        partial void OnGetTblHelperCouponByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon> GetTblHelperCouponByFldRecordId(long fldrecordid)
        {
            var items = Context.TblHelperCoupons
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblHelperCouponByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblHelperCouponGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblHelperCouponCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon item);
        partial void OnAfterTblHelperCouponCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon> CreateTblHelperCoupon(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon tblhelpercoupon)
        {
            OnTblHelperCouponCreated(tblhelpercoupon);

            var existingItem = Context.TblHelperCoupons
                              .Where(i => i.fldRecordID == tblhelpercoupon.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblHelperCoupons.Add(tblhelpercoupon);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblhelpercoupon).State = EntityState.Detached;
                throw;
            }

            OnAfterTblHelperCouponCreated(tblhelpercoupon);

            return tblhelpercoupon;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon> CancelTblHelperCouponChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblHelperCouponUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon item);
        partial void OnAfterTblHelperCouponUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon> UpdateTblHelperCoupon(long fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon tblhelpercoupon)
        {
            OnTblHelperCouponUpdated(tblhelpercoupon);

            var itemToUpdate = Context.TblHelperCoupons
                              .Where(i => i.fldRecordID == tblhelpercoupon.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblhelpercoupon);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblHelperCouponUpdated(tblhelpercoupon);

            return tblhelpercoupon;
        }

        partial void OnTblHelperCouponDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon item);
        partial void OnAfterTblHelperCouponDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon> DeleteTblHelperCoupon(long fldrecordid)
        {
            var itemToDelete = Context.TblHelperCoupons
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblHelperCouponDeleted(itemToDelete);


            Context.TblHelperCoupons.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblHelperCouponDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblHelperEmailStatusCodesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelperemailstatuscodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelperemailstatuscodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblHelperEmailStatusCodesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelperemailstatuscodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelperemailstatuscodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblHelperEmailStatusCodesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode>> GetTblHelperEmailStatusCodes(Query query = null)
        {
            var items = Context.TblHelperEmailStatusCodes.AsQueryable();


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

            OnTblHelperEmailStatusCodesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblHelperEmailStatusCodeGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode item);
        partial void OnGetTblHelperEmailStatusCodeByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode> GetTblHelperEmailStatusCodeByFldRecordId(int fldrecordid)
        {
            var items = Context.TblHelperEmailStatusCodes
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblHelperEmailStatusCodeByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblHelperEmailStatusCodeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblHelperEmailStatusCodeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode item);
        partial void OnAfterTblHelperEmailStatusCodeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode> CreateTblHelperEmailStatusCode(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode tblhelperemailstatuscode)
        {
            OnTblHelperEmailStatusCodeCreated(tblhelperemailstatuscode);

            var existingItem = Context.TblHelperEmailStatusCodes
                              .Where(i => i.fldRecordID == tblhelperemailstatuscode.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblHelperEmailStatusCodes.Add(tblhelperemailstatuscode);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblhelperemailstatuscode).State = EntityState.Detached;
                throw;
            }

            OnAfterTblHelperEmailStatusCodeCreated(tblhelperemailstatuscode);

            return tblhelperemailstatuscode;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode> CancelTblHelperEmailStatusCodeChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblHelperEmailStatusCodeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode item);
        partial void OnAfterTblHelperEmailStatusCodeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode> UpdateTblHelperEmailStatusCode(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode tblhelperemailstatuscode)
        {
            OnTblHelperEmailStatusCodeUpdated(tblhelperemailstatuscode);

            var itemToUpdate = Context.TblHelperEmailStatusCodes
                              .Where(i => i.fldRecordID == tblhelperemailstatuscode.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblhelperemailstatuscode);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblHelperEmailStatusCodeUpdated(tblhelperemailstatuscode);

            return tblhelperemailstatuscode;
        }

        partial void OnTblHelperEmailStatusCodeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode item);
        partial void OnAfterTblHelperEmailStatusCodeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode> DeleteTblHelperEmailStatusCode(int fldrecordid)
        {
            var itemToDelete = Context.TblHelperEmailStatusCodes
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblHelperEmailStatusCodeDeleted(itemToDelete);


            Context.TblHelperEmailStatusCodes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblHelperEmailStatusCodeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblHelperLaborsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelperlabors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelperlabors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblHelperLaborsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelperlabors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelperlabors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblHelperLaborsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor>> GetTblHelperLabors(Query query = null)
        {
            var items = Context.TblHelperLabors.AsQueryable();


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

            OnTblHelperLaborsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblHelperLaborGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor item);
        partial void OnGetTblHelperLaborByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor> GetTblHelperLaborByFldRecordId(long fldrecordid)
        {
            var items = Context.TblHelperLabors
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblHelperLaborByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblHelperLaborGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblHelperLaborCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor item);
        partial void OnAfterTblHelperLaborCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor> CreateTblHelperLabor(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor tblhelperlabor)
        {
            OnTblHelperLaborCreated(tblhelperlabor);

            var existingItem = Context.TblHelperLabors
                              .Where(i => i.fldRecordID == tblhelperlabor.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblHelperLabors.Add(tblhelperlabor);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblhelperlabor).State = EntityState.Detached;
                throw;
            }

            OnAfterTblHelperLaborCreated(tblhelperlabor);

            return tblhelperlabor;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor> CancelTblHelperLaborChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblHelperLaborUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor item);
        partial void OnAfterTblHelperLaborUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor> UpdateTblHelperLabor(long fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor tblhelperlabor)
        {
            OnTblHelperLaborUpdated(tblhelperlabor);

            var itemToUpdate = Context.TblHelperLabors
                              .Where(i => i.fldRecordID == tblhelperlabor.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblhelperlabor);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblHelperLaborUpdated(tblhelperlabor);

            return tblhelperlabor;
        }

        partial void OnTblHelperLaborDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor item);
        partial void OnAfterTblHelperLaborDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor> DeleteTblHelperLabor(long fldrecordid)
        {
            var itemToDelete = Context.TblHelperLabors
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblHelperLaborDeleted(itemToDelete);


            Context.TblHelperLabors.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblHelperLaborDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblHelperMailAddressErrorsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelpermailaddresserrors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelpermailaddresserrors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblHelperMailAddressErrorsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelpermailaddresserrors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelpermailaddresserrors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblHelperMailAddressErrorsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError>> GetTblHelperMailAddressErrors(Query query = null)
        {
            var items = Context.TblHelperMailAddressErrors.AsQueryable();


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

            OnTblHelperMailAddressErrorsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblHelperMailAddressErrorGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError item);
        partial void OnGetTblHelperMailAddressErrorByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError> GetTblHelperMailAddressErrorByFldRecordId(int fldrecordid)
        {
            var items = Context.TblHelperMailAddressErrors
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblHelperMailAddressErrorByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblHelperMailAddressErrorGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblHelperMailAddressErrorCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError item);
        partial void OnAfterTblHelperMailAddressErrorCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError> CreateTblHelperMailAddressError(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError tblhelpermailaddresserror)
        {
            OnTblHelperMailAddressErrorCreated(tblhelpermailaddresserror);

            var existingItem = Context.TblHelperMailAddressErrors
                              .Where(i => i.fldRecordID == tblhelpermailaddresserror.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblHelperMailAddressErrors.Add(tblhelpermailaddresserror);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblhelpermailaddresserror).State = EntityState.Detached;
                throw;
            }

            OnAfterTblHelperMailAddressErrorCreated(tblhelpermailaddresserror);

            return tblhelpermailaddresserror;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError> CancelTblHelperMailAddressErrorChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblHelperMailAddressErrorUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError item);
        partial void OnAfterTblHelperMailAddressErrorUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError> UpdateTblHelperMailAddressError(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError tblhelpermailaddresserror)
        {
            OnTblHelperMailAddressErrorUpdated(tblhelpermailaddresserror);

            var itemToUpdate = Context.TblHelperMailAddressErrors
                              .Where(i => i.fldRecordID == tblhelpermailaddresserror.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblhelpermailaddresserror);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblHelperMailAddressErrorUpdated(tblhelpermailaddresserror);

            return tblhelpermailaddresserror;
        }

        partial void OnTblHelperMailAddressErrorDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError item);
        partial void OnAfterTblHelperMailAddressErrorDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError> DeleteTblHelperMailAddressError(int fldrecordid)
        {
            var itemToDelete = Context.TblHelperMailAddressErrors
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblHelperMailAddressErrorDeleted(itemToDelete);


            Context.TblHelperMailAddressErrors.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblHelperMailAddressErrorDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblHelperPartsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelperparts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelperparts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblHelperPartsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblhelperparts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblhelperparts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblHelperPartsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart>> GetTblHelperParts(Query query = null)
        {
            var items = Context.TblHelperParts.AsQueryable();


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

            OnTblHelperPartsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblHelperPartGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart item);
        partial void OnGetTblHelperPartByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart> GetTblHelperPartByFldRecordId(long fldrecordid)
        {
            var items = Context.TblHelperParts
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblHelperPartByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblHelperPartGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblHelperPartCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart item);
        partial void OnAfterTblHelperPartCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart> CreateTblHelperPart(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart tblhelperpart)
        {
            OnTblHelperPartCreated(tblhelperpart);

            var existingItem = Context.TblHelperParts
                              .Where(i => i.fldRecordID == tblhelperpart.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblHelperParts.Add(tblhelperpart);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblhelperpart).State = EntityState.Detached;
                throw;
            }

            OnAfterTblHelperPartCreated(tblhelperpart);

            return tblhelperpart;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart> CancelTblHelperPartChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblHelperPartUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart item);
        partial void OnAfterTblHelperPartUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart> UpdateTblHelperPart(long fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart tblhelperpart)
        {
            OnTblHelperPartUpdated(tblhelperpart);

            var itemToUpdate = Context.TblHelperParts
                              .Where(i => i.fldRecordID == tblhelperpart.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblhelperpart);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblHelperPartUpdated(tblhelperpart);

            return tblhelperpart;
        }

        partial void OnTblHelperPartDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart item);
        partial void OnAfterTblHelperPartDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart> DeleteTblHelperPart(long fldrecordid)
        {
            var itemToDelete = Context.TblHelperParts
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblHelperPartDeleted(itemToDelete);


            Context.TblHelperParts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblHelperPartDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblSummaryCampaignsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblsummarycampaigns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblsummarycampaigns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblSummaryCampaignsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblsummarycampaigns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblsummarycampaigns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblSummaryCampaignsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign>> GetTblSummaryCampaigns(Query query = null)
        {
            var items = Context.TblSummaryCampaigns.AsQueryable();


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

            OnTblSummaryCampaignsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblSummaryCampaignGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign item);
        partial void OnGetTblSummaryCampaignByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign> GetTblSummaryCampaignByFldRecordId(int fldrecordid)
        {
            var items = Context.TblSummaryCampaigns
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblSummaryCampaignByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblSummaryCampaignGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblSummaryCampaignCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign item);
        partial void OnAfterTblSummaryCampaignCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign> CreateTblSummaryCampaign(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign tblsummarycampaign)
        {
            OnTblSummaryCampaignCreated(tblsummarycampaign);

            var existingItem = Context.TblSummaryCampaigns
                              .Where(i => i.fldRecordID == tblsummarycampaign.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblSummaryCampaigns.Add(tblsummarycampaign);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblsummarycampaign).State = EntityState.Detached;
                throw;
            }

            OnAfterTblSummaryCampaignCreated(tblsummarycampaign);

            return tblsummarycampaign;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign> CancelTblSummaryCampaignChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblSummaryCampaignUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign item);
        partial void OnAfterTblSummaryCampaignUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign> UpdateTblSummaryCampaign(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign tblsummarycampaign)
        {
            OnTblSummaryCampaignUpdated(tblsummarycampaign);

            var itemToUpdate = Context.TblSummaryCampaigns
                              .Where(i => i.fldRecordID == tblsummarycampaign.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblsummarycampaign);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblSummaryCampaignUpdated(tblsummarycampaign);

            return tblsummarycampaign;
        }

        partial void OnTblSummaryCampaignDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign item);
        partial void OnAfterTblSummaryCampaignDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign> DeleteTblSummaryCampaign(int fldrecordid)
        {
            var itemToDelete = Context.TblSummaryCampaigns
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblSummaryCampaignDeleted(itemToDelete);


            Context.TblSummaryCampaigns.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblSummaryCampaignDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblSummaryCustomersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblsummarycustomers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblsummarycustomers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblSummaryCustomersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblsummarycustomers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblsummarycustomers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblSummaryCustomersRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer>> GetTblSummaryCustomers(Query query = null)
        {
            var items = Context.TblSummaryCustomers.AsQueryable();


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

            OnTblSummaryCustomersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblSummaryCustomerGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer item);
        partial void OnGetTblSummaryCustomerByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer> GetTblSummaryCustomerByFldRecordId(int fldrecordid)
        {
            var items = Context.TblSummaryCustomers
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblSummaryCustomerByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblSummaryCustomerGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblSummaryCustomerCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer item);
        partial void OnAfterTblSummaryCustomerCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer> CreateTblSummaryCustomer(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer tblsummarycustomer)
        {
            OnTblSummaryCustomerCreated(tblsummarycustomer);

            var existingItem = Context.TblSummaryCustomers
                              .Where(i => i.fldRecordID == tblsummarycustomer.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblSummaryCustomers.Add(tblsummarycustomer);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblsummarycustomer).State = EntityState.Detached;
                throw;
            }

            OnAfterTblSummaryCustomerCreated(tblsummarycustomer);

            return tblsummarycustomer;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer> CancelTblSummaryCustomerChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblSummaryCustomerUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer item);
        partial void OnAfterTblSummaryCustomerUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer> UpdateTblSummaryCustomer(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer tblsummarycustomer)
        {
            OnTblSummaryCustomerUpdated(tblsummarycustomer);

            var itemToUpdate = Context.TblSummaryCustomers
                              .Where(i => i.fldRecordID == tblsummarycustomer.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblsummarycustomer);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblSummaryCustomerUpdated(tblsummarycustomer);

            return tblsummarycustomer;
        }

        partial void OnTblSummaryCustomerDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer item);
        partial void OnAfterTblSummaryCustomerDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer> DeleteTblSummaryCustomer(int fldrecordid)
        {
            var itemToDelete = Context.TblSummaryCustomers
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblSummaryCustomerDeleted(itemToDelete);


            Context.TblSummaryCustomers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblSummaryCustomerDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblSummarySalesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblsummarysales/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblsummarysales/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblSummarySalesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblsummarysales/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblsummarysales/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblSummarySalesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale>> GetTblSummarySales(Query query = null)
        {
            var items = Context.TblSummarySales.AsQueryable();


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

            OnTblSummarySalesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblSummarySaleGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale item);
        partial void OnGetTblSummarySaleByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale> GetTblSummarySaleByFldRecordId(int fldrecordid)
        {
            var items = Context.TblSummarySales
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblSummarySaleByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblSummarySaleGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblSummarySaleCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale item);
        partial void OnAfterTblSummarySaleCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale> CreateTblSummarySale(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale tblsummarysale)
        {
            OnTblSummarySaleCreated(tblsummarysale);

            var existingItem = Context.TblSummarySales
                              .Where(i => i.fldRecordID == tblsummarysale.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblSummarySales.Add(tblsummarysale);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblsummarysale).State = EntityState.Detached;
                throw;
            }

            OnAfterTblSummarySaleCreated(tblsummarysale);

            return tblsummarysale;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale> CancelTblSummarySaleChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblSummarySaleUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale item);
        partial void OnAfterTblSummarySaleUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale> UpdateTblSummarySale(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale tblsummarysale)
        {
            OnTblSummarySaleUpdated(tblsummarysale);

            var itemToUpdate = Context.TblSummarySales
                              .Where(i => i.fldRecordID == tblsummarysale.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblsummarysale);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblSummarySaleUpdated(tblsummarysale);

            return tblsummarysale;
        }

        partial void OnTblSummarySaleDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale item);
        partial void OnAfterTblSummarySaleDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale> DeleteTblSummarySale(int fldrecordid)
        {
            var itemToDelete = Context.TblSummarySales
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblSummarySaleDeleted(itemToDelete);


            Context.TblSummarySales.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblSummarySaleDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblSummaryVehiclesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblsummaryvehicles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblsummaryvehicles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblSummaryVehiclesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_summary/tblsummaryvehicles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_summary/tblsummaryvehicles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblSummaryVehiclesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle>> GetTblSummaryVehicles(Query query = null)
        {
            var items = Context.TblSummaryVehicles.AsQueryable();


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

            OnTblSummaryVehiclesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblSummaryVehicleGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle item);
        partial void OnGetTblSummaryVehicleByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle> GetTblSummaryVehicleByFldRecordId(int fldrecordid)
        {
            var items = Context.TblSummaryVehicles
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblSummaryVehicleByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblSummaryVehicleGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblSummaryVehicleCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle item);
        partial void OnAfterTblSummaryVehicleCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle> CreateTblSummaryVehicle(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle tblsummaryvehicle)
        {
            OnTblSummaryVehicleCreated(tblsummaryvehicle);

            var existingItem = Context.TblSummaryVehicles
                              .Where(i => i.fldRecordID == tblsummaryvehicle.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblSummaryVehicles.Add(tblsummaryvehicle);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblsummaryvehicle).State = EntityState.Detached;
                throw;
            }

            OnAfterTblSummaryVehicleCreated(tblsummaryvehicle);

            return tblsummaryvehicle;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle> CancelTblSummaryVehicleChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblSummaryVehicleUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle item);
        partial void OnAfterTblSummaryVehicleUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle> UpdateTblSummaryVehicle(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle tblsummaryvehicle)
        {
            OnTblSummaryVehicleUpdated(tblsummaryvehicle);

            var itemToUpdate = Context.TblSummaryVehicles
                              .Where(i => i.fldRecordID == tblsummaryvehicle.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblsummaryvehicle);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblSummaryVehicleUpdated(tblsummaryvehicle);

            return tblsummaryvehicle;
        }

        partial void OnTblSummaryVehicleDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle item);
        partial void OnAfterTblSummaryVehicleDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle> DeleteTblSummaryVehicle(int fldrecordid)
        {
            var itemToDelete = Context.TblSummaryVehicles
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblSummaryVehicleDeleted(itemToDelete);


            Context.TblSummaryVehicles.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblSummaryVehicleDeleted(itemToDelete);

            return itemToDelete;
        }
          public async Task<int> GetDashboardValuesOriginals(int? WebUserID, int? CustomerID, string StartDate, string EndDate, string Stores, string Groups, int? StartOfWeekDay, bool? ActiveOnly)
      {
          OnGetDashboardValuesOriginalsDefaultParams(ref WebUserID, ref CustomerID, ref StartDate, ref EndDate, ref Stores, ref Groups, ref StartOfWeekDay, ref ActiveOnly);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@WebUserID", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = WebUserID},
              new SqlParameter("@CustomerID", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = CustomerID},
              new SqlParameter("@StartDate", SqlDbType.DateTime, -1) {Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@EndDate", SqlDbType.DateTime, -1) {Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@Stores", SqlDbType.VarChar, -1) {Direction = ParameterDirection.Input, Value = Stores},
              new SqlParameter("@Groups", SqlDbType.VarChar, -1) {Direction = ParameterDirection.Input, Value = Groups},
              new SqlParameter("@StartOfWeekDay", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = StartOfWeekDay},
              new SqlParameter("@ActiveOnly", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ActiveOnly},

          };

          foreach(var _p in @params)
          {
              if((_p.Direction == ParameterDirection.Input || _p.Direction == ParameterDirection.InputOutput) && _p.Value == null)
              {
                  _p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[GetDashboardValuesOriginal] @WebUserID, @CustomerID, @StartDate, @EndDate, @Stores, @Groups, @StartOfWeekDay, @ActiveOnly", @params);

          int result = Convert.ToInt32(@params[0].Value);


          OnGetDashboardValuesOriginalsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnGetDashboardValuesOriginalsDefaultParams(ref int? WebUserID, ref int? CustomerID, ref string StartDate, ref string EndDate, ref string Stores, ref string Groups, ref int? StartOfWeekDay, ref bool? ActiveOnly);
      partial void OnGetDashboardValuesOriginalsInvoke(ref int result);
      public async Task<int> GetEmployeesWithDepartments(int? id)
      {
          OnGetEmployeesWithDepartmentsDefaultParams(ref id);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@id", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = id},

          };

          foreach(var _p in @params)
          {
              if((_p.Direction == ParameterDirection.Input || _p.Direction == ParameterDirection.InputOutput) && _p.Value == null)
              {
                  _p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[GetEmployeesWithDepartment] @id", @params);

          int result = Convert.ToInt32(@params[0].Value);


          OnGetEmployeesWithDepartmentsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnGetEmployeesWithDepartmentsDefaultParams(ref int? id);
      partial void OnGetEmployeesWithDepartmentsInvoke(ref int result);
      public async Task<int> UspDashboardGetStatisticsCustomers(int? WebUserID, int? CustomerID, string Stores, string Groups, string StartDate, string EndDate, bool? OnlyActiveStores, bool? ext_Daily, bool? ext_WTD, bool? ext_MTD, bool? ext_YTD, bool? ext_DOD, bool? ext_WOW, bool? ext_MOM, bool? ext_YOY)
      {
          OnUspDashboardGetStatisticsCustomersDefaultParams(ref WebUserID, ref CustomerID, ref Stores, ref Groups, ref StartDate, ref EndDate, ref OnlyActiveStores, ref ext_Daily, ref ext_WTD, ref ext_MTD, ref ext_YTD, ref ext_DOD, ref ext_WOW, ref ext_MOM, ref ext_YOY);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@WebUserID", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = WebUserID},
              new SqlParameter("@CustomerID", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = CustomerID},
              new SqlParameter("@Stores", SqlDbType.VarChar, -1) {Direction = ParameterDirection.Input, Value = Stores},
              new SqlParameter("@Groups", SqlDbType.VarChar, -1) {Direction = ParameterDirection.Input, Value = Groups},
              new SqlParameter("@StartDate", SqlDbType.DateTime, -1) {Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@EndDate", SqlDbType.DateTime, -1) {Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@OnlyActiveStores", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = OnlyActiveStores},
              new SqlParameter("@ext_Daily", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_Daily},
              new SqlParameter("@ext_WTD", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_WTD},
              new SqlParameter("@ext_MTD", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_MTD},
              new SqlParameter("@ext_YTD", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_YTD},
              new SqlParameter("@ext_DOD", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_DOD},
              new SqlParameter("@ext_WOW", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_WOW},
              new SqlParameter("@ext_MOM", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_MOM},
              new SqlParameter("@ext_YOY", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_YOY},

          };

          foreach(var _p in @params)
          {
              if((_p.Direction == ParameterDirection.Input || _p.Direction == ParameterDirection.InputOutput) && _p.Value == null)
              {
                  _p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[uspDashboardGetStatisticsCustomer] @WebUserID, @CustomerID, @Stores, @Groups, @StartDate, @EndDate, @OnlyActiveStores, @ext_Daily, @ext_WTD, @ext_MTD, @ext_YTD, @ext_DOD, @ext_WOW, @ext_MOM, @ext_YOY", @params);

          int result = Convert.ToInt32(@params[0].Value);


          OnUspDashboardGetStatisticsCustomersInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnUspDashboardGetStatisticsCustomersDefaultParams(ref int? WebUserID, ref int? CustomerID, ref string Stores, ref string Groups, ref string StartDate, ref string EndDate, ref bool? OnlyActiveStores, ref bool? ext_Daily, ref bool? ext_WTD, ref bool? ext_MTD, ref bool? ext_YTD, ref bool? ext_DOD, ref bool? ext_WOW, ref bool? ext_MOM, ref bool? ext_YOY);
      partial void OnUspDashboardGetStatisticsCustomersInvoke(ref int result);
      public async Task<int> UspDashboardGetStatisticsTopVehiclesServiceds(int? WebUserID, int? CustomerID, string Stores, string Groups, string StartDate, string EndDate, bool? OnlyActiveStores, int? ext_TopXNumberofVehicles, bool? ext_IncludeVehicleYear)
      {
          OnUspDashboardGetStatisticsTopVehiclesServicedsDefaultParams(ref WebUserID, ref CustomerID, ref Stores, ref Groups, ref StartDate, ref EndDate, ref OnlyActiveStores, ref ext_TopXNumberofVehicles, ref ext_IncludeVehicleYear);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@WebUserID", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = WebUserID},
              new SqlParameter("@CustomerID", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = CustomerID},
              new SqlParameter("@Stores", SqlDbType.VarChar, -1) {Direction = ParameterDirection.Input, Value = Stores},
              new SqlParameter("@Groups", SqlDbType.VarChar, -1) {Direction = ParameterDirection.Input, Value = Groups},
              new SqlParameter("@StartDate", SqlDbType.DateTime, -1) {Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@EndDate", SqlDbType.DateTime, -1) {Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@OnlyActiveStores", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = OnlyActiveStores},
              new SqlParameter("@ext_TopXNumberofVehicles", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = ext_TopXNumberofVehicles},
              new SqlParameter("@ext_IncludeVehicleYear", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_IncludeVehicleYear},

          };

          foreach(var _p in @params)
          {
              if((_p.Direction == ParameterDirection.Input || _p.Direction == ParameterDirection.InputOutput) && _p.Value == null)
              {
                  _p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[uspDashboardGetStatisticsTopVehiclesServiced] @WebUserID, @CustomerID, @Stores, @Groups, @StartDate, @EndDate, @OnlyActiveStores, @ext_TopXNumberofVehicles, @ext_IncludeVehicleYear", @params);

          int result = Convert.ToInt32(@params[0].Value);


          OnUspDashboardGetStatisticsTopVehiclesServicedsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnUspDashboardGetStatisticsTopVehiclesServicedsDefaultParams(ref int? WebUserID, ref int? CustomerID, ref string Stores, ref string Groups, ref string StartDate, ref string EndDate, ref bool? OnlyActiveStores, ref int? ext_TopXNumberofVehicles, ref bool? ext_IncludeVehicleYear);
      partial void OnUspDashboardGetStatisticsTopVehiclesServicedsInvoke(ref int result);
      public async Task<int> UspDashboardGetValuesCampaigns(int? WebUserID, int? CustomerID, string Stores, string Groups, string StartDate, string EndDate, bool? OnlyActiveStores, bool? ext_Daily, bool? ext_WTD, bool? ext_MTD, bool? ext_YTD, bool? ext_DOD, bool? ext_WOW, bool? ext_MOM, bool? ext_YOY)
      {
          OnUspDashboardGetValuesCampaignsDefaultParams(ref WebUserID, ref CustomerID, ref Stores, ref Groups, ref StartDate, ref EndDate, ref OnlyActiveStores, ref ext_Daily, ref ext_WTD, ref ext_MTD, ref ext_YTD, ref ext_DOD, ref ext_WOW, ref ext_MOM, ref ext_YOY);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@WebUserID", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = WebUserID},
              new SqlParameter("@CustomerID", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = CustomerID},
              new SqlParameter("@Stores", SqlDbType.VarChar, -1) {Direction = ParameterDirection.Input, Value = Stores},
              new SqlParameter("@Groups", SqlDbType.VarChar, -1) {Direction = ParameterDirection.Input, Value = Groups},
              new SqlParameter("@StartDate", SqlDbType.DateTime, -1) {Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@EndDate", SqlDbType.DateTime, -1) {Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@OnlyActiveStores", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = OnlyActiveStores},
              new SqlParameter("@ext_Daily", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_Daily},
              new SqlParameter("@ext_WTD", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_WTD},
              new SqlParameter("@ext_MTD", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_MTD},
              new SqlParameter("@ext_YTD", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_YTD},
              new SqlParameter("@ext_DOD", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_DOD},
              new SqlParameter("@ext_WOW", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_WOW},
              new SqlParameter("@ext_MOM", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_MOM},
              new SqlParameter("@ext_YOY", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_YOY},

          };

          foreach(var _p in @params)
          {
              if((_p.Direction == ParameterDirection.Input || _p.Direction == ParameterDirection.InputOutput) && _p.Value == null)
              {
                  _p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[uspDashboardGetValuesCampaigns] @WebUserID, @CustomerID, @Stores, @Groups, @StartDate, @EndDate, @OnlyActiveStores, @ext_Daily, @ext_WTD, @ext_MTD, @ext_YTD, @ext_DOD, @ext_WOW, @ext_MOM, @ext_YOY", @params);

          int result = Convert.ToInt32(@params[0].Value);


          OnUspDashboardGetValuesCampaignsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnUspDashboardGetValuesCampaignsDefaultParams(ref int? WebUserID, ref int? CustomerID, ref string Stores, ref string Groups, ref string StartDate, ref string EndDate, ref bool? OnlyActiveStores, ref bool? ext_Daily, ref bool? ext_WTD, ref bool? ext_MTD, ref bool? ext_YTD, ref bool? ext_DOD, ref bool? ext_WOW, ref bool? ext_MOM, ref bool? ext_YOY);
      partial void OnUspDashboardGetValuesCampaignsInvoke(ref int result);
      public async Task<int> UspDashboardGetValuesSales(int? WebUserID, int? CustomerID, string Stores, string Groups, string StartDate, string EndDate, bool? OnlyActiveStores, bool? ext_Daily, bool? ext_WTD, bool? ext_MTD, bool? ext_YTD, bool? ext_DOD, bool? ext_WOW, bool? ext_MOM, bool? ext_YOY)
      {
          OnUspDashboardGetValuesSalesDefaultParams(ref WebUserID, ref CustomerID, ref Stores, ref Groups, ref StartDate, ref EndDate, ref OnlyActiveStores, ref ext_Daily, ref ext_WTD, ref ext_MTD, ref ext_YTD, ref ext_DOD, ref ext_WOW, ref ext_MOM, ref ext_YOY);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@WebUserID", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = WebUserID},
              new SqlParameter("@CustomerID", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = CustomerID},
              new SqlParameter("@Stores", SqlDbType.VarChar, -1) {Direction = ParameterDirection.Input, Value = Stores},
              new SqlParameter("@Groups", SqlDbType.VarChar, -1) {Direction = ParameterDirection.Input, Value = Groups},
              new SqlParameter("@StartDate", SqlDbType.DateTime, -1) {Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@EndDate", SqlDbType.DateTime, -1) {Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@OnlyActiveStores", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = OnlyActiveStores},
              new SqlParameter("@ext_Daily", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_Daily},
              new SqlParameter("@ext_WTD", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_WTD},
              new SqlParameter("@ext_MTD", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_MTD},
              new SqlParameter("@ext_YTD", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_YTD},
              new SqlParameter("@ext_DOD", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_DOD},
              new SqlParameter("@ext_WOW", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_WOW},
              new SqlParameter("@ext_MOM", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_MOM},
              new SqlParameter("@ext_YOY", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_YOY},

          };

          foreach(var _p in @params)
          {
              if((_p.Direction == ParameterDirection.Input || _p.Direction == ParameterDirection.InputOutput) && _p.Value == null)
              {
                  _p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[uspDashboardGetValuesSales] @WebUserID, @CustomerID, @Stores, @Groups, @StartDate, @EndDate, @OnlyActiveStores, @ext_Daily, @ext_WTD, @ext_MTD, @ext_YTD, @ext_DOD, @ext_WOW, @ext_MOM, @ext_YOY", @params);

          int result = Convert.ToInt32(@params[0].Value);


          OnUspDashboardGetValuesSalesInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnUspDashboardGetValuesSalesDefaultParams(ref int? WebUserID, ref int? CustomerID, ref string Stores, ref string Groups, ref string StartDate, ref string EndDate, ref bool? OnlyActiveStores, ref bool? ext_Daily, ref bool? ext_WTD, ref bool? ext_MTD, ref bool? ext_YTD, ref bool? ext_DOD, ref bool? ext_WOW, ref bool? ext_MOM, ref bool? ext_YOY);
      partial void OnUspDashboardGetValuesSalesInvoke(ref int result);
      public async Task<int> UspDataCreateVehicleSummaryData()
      {
          OnUspDataCreateVehicleSummaryDataDefaultParams();

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

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[uspDataCreateVehicleSummaryData] ", @params);

          int result = Convert.ToInt32(@params[0].Value);


          OnUspDataCreateVehicleSummaryDataInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnUspDataCreateVehicleSummaryDataDefaultParams();
      partial void OnUspDataCreateVehicleSummaryDataInvoke(ref int result);
    }
}