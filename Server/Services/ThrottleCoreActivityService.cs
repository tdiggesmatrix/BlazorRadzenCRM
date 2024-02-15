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
    public partial class Throttle_Core_ActivityService
    {
        Throttle_Core_ActivityContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly Throttle_Core_ActivityContext context;
        private readonly NavigationManager navigationManager;

        public Throttle_Core_ActivityService(Throttle_Core_ActivityContext context, NavigationManager navigationManager)
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


        public async Task ExportTblDataDmSFileActivitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsfileactivities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsfileactivities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblDataDmSFileActivitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsfileactivities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsfileactivities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblDataDmSFileActivitiesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity>> GetTblDataDmSFileActivities(Query query = null)
        {
            var items = Context.TblDataDmSFileActivities.AsQueryable();


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

            OnTblDataDmSFileActivitiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblDataDmSFileActivityGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity item);
        partial void OnGetTblDataDmSFileActivityByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity> GetTblDataDmSFileActivityByFldRecordId(int fldrecordid)
        {
            var items = Context.TblDataDmSFileActivities
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblDataDmSFileActivityByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblDataDmSFileActivityGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblDataDmSFileActivityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity item);
        partial void OnAfterTblDataDmSFileActivityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity> CreateTblDataDmSFileActivity(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity tbldatadmsfileactivity)
        {
            OnTblDataDmSFileActivityCreated(tbldatadmsfileactivity);

            var existingItem = Context.TblDataDmSFileActivities
                              .Where(i => i.fldRecordID == tbldatadmsfileactivity.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblDataDmSFileActivities.Add(tbldatadmsfileactivity);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tbldatadmsfileactivity).State = EntityState.Detached;
                throw;
            }

            OnAfterTblDataDmSFileActivityCreated(tbldatadmsfileactivity);

            return tbldatadmsfileactivity;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity> CancelTblDataDmSFileActivityChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblDataDmSFileActivityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity item);
        partial void OnAfterTblDataDmSFileActivityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity> UpdateTblDataDmSFileActivity(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity tbldatadmsfileactivity)
        {
            OnTblDataDmSFileActivityUpdated(tbldatadmsfileactivity);

            var itemToUpdate = Context.TblDataDmSFileActivities
                              .Where(i => i.fldRecordID == tbldatadmsfileactivity.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tbldatadmsfileactivity);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblDataDmSFileActivityUpdated(tbldatadmsfileactivity);

            return tbldatadmsfileactivity;
        }

        partial void OnTblDataDmSFileActivityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity item);
        partial void OnAfterTblDataDmSFileActivityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity> DeleteTblDataDmSFileActivity(int fldrecordid)
        {
            var itemToDelete = Context.TblDataDmSFileActivities
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblDataDmSFileActivityDeleted(itemToDelete);


            Context.TblDataDmSFileActivities.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblDataDmSFileActivityDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblDataDmSFileArchiveActivitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsfilearchiveactivities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsfilearchiveactivities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblDataDmSFileArchiveActivitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsfilearchiveactivities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsfilearchiveactivities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblDataDmSFileArchiveActivitiesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity>> GetTblDataDmSFileArchiveActivities(Query query = null)
        {
            var items = Context.TblDataDmSFileArchiveActivities.AsQueryable();


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

            OnTblDataDmSFileArchiveActivitiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblDataDmSFileArchiveActivityGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity item);
        partial void OnGetTblDataDmSFileArchiveActivityByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity> GetTblDataDmSFileArchiveActivityByFldRecordId(int fldrecordid)
        {
            var items = Context.TblDataDmSFileArchiveActivities
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblDataDmSFileArchiveActivityByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblDataDmSFileArchiveActivityGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblDataDmSFileArchiveActivityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity item);
        partial void OnAfterTblDataDmSFileArchiveActivityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity> CreateTblDataDmSFileArchiveActivity(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity tbldatadmsfilearchiveactivity)
        {
            OnTblDataDmSFileArchiveActivityCreated(tbldatadmsfilearchiveactivity);

            var existingItem = Context.TblDataDmSFileArchiveActivities
                              .Where(i => i.fldRecordID == tbldatadmsfilearchiveactivity.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblDataDmSFileArchiveActivities.Add(tbldatadmsfilearchiveactivity);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tbldatadmsfilearchiveactivity).State = EntityState.Detached;
                throw;
            }

            OnAfterTblDataDmSFileArchiveActivityCreated(tbldatadmsfilearchiveactivity);

            return tbldatadmsfilearchiveactivity;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity> CancelTblDataDmSFileArchiveActivityChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblDataDmSFileArchiveActivityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity item);
        partial void OnAfterTblDataDmSFileArchiveActivityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity> UpdateTblDataDmSFileArchiveActivity(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity tbldatadmsfilearchiveactivity)
        {
            OnTblDataDmSFileArchiveActivityUpdated(tbldatadmsfilearchiveactivity);

            var itemToUpdate = Context.TblDataDmSFileArchiveActivities
                              .Where(i => i.fldRecordID == tbldatadmsfilearchiveactivity.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tbldatadmsfilearchiveactivity);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblDataDmSFileArchiveActivityUpdated(tbldatadmsfilearchiveactivity);

            return tbldatadmsfilearchiveactivity;
        }

        partial void OnTblDataDmSFileArchiveActivityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity item);
        partial void OnAfterTblDataDmSFileArchiveActivityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity> DeleteTblDataDmSFileArchiveActivity(int fldrecordid)
        {
            var itemToDelete = Context.TblDataDmSFileArchiveActivities
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblDataDmSFileArchiveActivityDeleted(itemToDelete);


            Context.TblDataDmSFileArchiveActivities.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblDataDmSFileArchiveActivityDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblDataDmSFileArchiveServersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsfilearchiveservers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsfilearchiveservers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblDataDmSFileArchiveServersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsfilearchiveservers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsfilearchiveservers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblDataDmSFileArchiveServersRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer>> GetTblDataDmSFileArchiveServers(Query query = null)
        {
            var items = Context.TblDataDmSFileArchiveServers.AsQueryable();


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

            OnTblDataDmSFileArchiveServersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblDataDmSFileArchiveServerGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer item);
        partial void OnGetTblDataDmSFileArchiveServerByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer> GetTblDataDmSFileArchiveServerByFldRecordId(int fldrecordid)
        {
            var items = Context.TblDataDmSFileArchiveServers
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblDataDmSFileArchiveServerByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblDataDmSFileArchiveServerGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblDataDmSFileArchiveServerCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer item);
        partial void OnAfterTblDataDmSFileArchiveServerCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer> CreateTblDataDmSFileArchiveServer(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer tbldatadmsfilearchiveserver)
        {
            OnTblDataDmSFileArchiveServerCreated(tbldatadmsfilearchiveserver);

            var existingItem = Context.TblDataDmSFileArchiveServers
                              .Where(i => i.fldRecordID == tbldatadmsfilearchiveserver.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblDataDmSFileArchiveServers.Add(tbldatadmsfilearchiveserver);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tbldatadmsfilearchiveserver).State = EntityState.Detached;
                throw;
            }

            OnAfterTblDataDmSFileArchiveServerCreated(tbldatadmsfilearchiveserver);

            return tbldatadmsfilearchiveserver;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer> CancelTblDataDmSFileArchiveServerChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblDataDmSFileArchiveServerUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer item);
        partial void OnAfterTblDataDmSFileArchiveServerUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer> UpdateTblDataDmSFileArchiveServer(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer tbldatadmsfilearchiveserver)
        {
            OnTblDataDmSFileArchiveServerUpdated(tbldatadmsfilearchiveserver);

            var itemToUpdate = Context.TblDataDmSFileArchiveServers
                              .Where(i => i.fldRecordID == tbldatadmsfilearchiveserver.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tbldatadmsfilearchiveserver);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblDataDmSFileArchiveServerUpdated(tbldatadmsfilearchiveserver);

            return tbldatadmsfilearchiveserver;
        }

        partial void OnTblDataDmSFileArchiveServerDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer item);
        partial void OnAfterTblDataDmSFileArchiveServerDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer> DeleteTblDataDmSFileArchiveServer(int fldrecordid)
        {
            var itemToDelete = Context.TblDataDmSFileArchiveServers
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblDataDmSFileArchiveServerDeleted(itemToDelete);


            Context.TblDataDmSFileArchiveServers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblDataDmSFileArchiveServerDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblDataDmSFtPActivitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsftpactivities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsftpactivities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblDataDmSFtPActivitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsftpactivities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsftpactivities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblDataDmSFtPActivitiesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity>> GetTblDataDmSFtPActivities(Query query = null)
        {
            var items = Context.TblDataDmSFtPActivities.AsQueryable();


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

            OnTblDataDmSFtPActivitiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblDataDmSFtPActivityGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity item);
        partial void OnGetTblDataDmSFtPActivityByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity> GetTblDataDmSFtPActivityByFldRecordId(int fldrecordid)
        {
            var items = Context.TblDataDmSFtPActivities
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblDataDmSFtPActivityByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblDataDmSFtPActivityGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblDataDmSFtPActivityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity item);
        partial void OnAfterTblDataDmSFtPActivityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity> CreateTblDataDmSFtPActivity(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity tbldatadmsftpactivity)
        {
            OnTblDataDmSFtPActivityCreated(tbldatadmsftpactivity);

            var existingItem = Context.TblDataDmSFtPActivities
                              .Where(i => i.fldRecordID == tbldatadmsftpactivity.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblDataDmSFtPActivities.Add(tbldatadmsftpactivity);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tbldatadmsftpactivity).State = EntityState.Detached;
                throw;
            }

            OnAfterTblDataDmSFtPActivityCreated(tbldatadmsftpactivity);

            return tbldatadmsftpactivity;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity> CancelTblDataDmSFtPActivityChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblDataDmSFtPActivityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity item);
        partial void OnAfterTblDataDmSFtPActivityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity> UpdateTblDataDmSFtPActivity(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity tbldatadmsftpactivity)
        {
            OnTblDataDmSFtPActivityUpdated(tbldatadmsftpactivity);

            var itemToUpdate = Context.TblDataDmSFtPActivities
                              .Where(i => i.fldRecordID == tbldatadmsftpactivity.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tbldatadmsftpactivity);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblDataDmSFtPActivityUpdated(tbldatadmsftpactivity);

            return tbldatadmsftpactivity;
        }

        partial void OnTblDataDmSFtPActivityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity item);
        partial void OnAfterTblDataDmSFtPActivityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity> DeleteTblDataDmSFtPActivity(int fldrecordid)
        {
            var itemToDelete = Context.TblDataDmSFtPActivities
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblDataDmSFtPActivityDeleted(itemToDelete);


            Context.TblDataDmSFtPActivities.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblDataDmSFtPActivityDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblDataDmSProvidersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblDataDmSProvidersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatadmsproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatadmsproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblDataDmSProvidersRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider>> GetTblDataDmSProviders(Query query = null)
        {
            var items = Context.TblDataDmSProviders.AsQueryable();


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

            OnTblDataDmSProvidersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblDataDmSProviderGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider item);
        partial void OnGetTblDataDmSProviderByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider> GetTblDataDmSProviderByFldRecordId(int fldrecordid)
        {
            var items = Context.TblDataDmSProviders
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblDataDmSProviderByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblDataDmSProviderGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblDataDmSProviderCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider item);
        partial void OnAfterTblDataDmSProviderCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider> CreateTblDataDmSProvider(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider tbldatadmsprovider)
        {
            OnTblDataDmSProviderCreated(tbldatadmsprovider);

            var existingItem = Context.TblDataDmSProviders
                              .Where(i => i.fldRecordID == tbldatadmsprovider.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblDataDmSProviders.Add(tbldatadmsprovider);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tbldatadmsprovider).State = EntityState.Detached;
                throw;
            }

            OnAfterTblDataDmSProviderCreated(tbldatadmsprovider);

            return tbldatadmsprovider;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider> CancelTblDataDmSProviderChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblDataDmSProviderUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider item);
        partial void OnAfterTblDataDmSProviderUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider> UpdateTblDataDmSProvider(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider tbldatadmsprovider)
        {
            OnTblDataDmSProviderUpdated(tbldatadmsprovider);

            var itemToUpdate = Context.TblDataDmSProviders
                              .Where(i => i.fldRecordID == tbldatadmsprovider.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tbldatadmsprovider);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblDataDmSProviderUpdated(tbldatadmsprovider);

            return tbldatadmsprovider;
        }

        partial void OnTblDataDmSProviderDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider item);
        partial void OnAfterTblDataDmSProviderDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider> DeleteTblDataDmSProvider(int fldrecordid)
        {
            var itemToDelete = Context.TblDataDmSProviders
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblDataDmSProviderDeleted(itemToDelete);


            Context.TblDataDmSProviders.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblDataDmSProviderDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblDataHelperAcknowledgementTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperacknowledgementtypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperacknowledgementtypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblDataHelperAcknowledgementTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperacknowledgementtypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperacknowledgementtypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblDataHelperAcknowledgementTypesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType>> GetTblDataHelperAcknowledgementTypes(Query query = null)
        {
            var items = Context.TblDataHelperAcknowledgementTypes.AsQueryable();


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

            OnTblDataHelperAcknowledgementTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblDataHelperAcknowledgementTypeGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType item);
        partial void OnGetTblDataHelperAcknowledgementTypeByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType> GetTblDataHelperAcknowledgementTypeByFldRecordId(int fldrecordid)
        {
            var items = Context.TblDataHelperAcknowledgementTypes
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblDataHelperAcknowledgementTypeByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblDataHelperAcknowledgementTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblDataHelperAcknowledgementTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType item);
        partial void OnAfterTblDataHelperAcknowledgementTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType> CreateTblDataHelperAcknowledgementType(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType tbldatahelperacknowledgementtype)
        {
            OnTblDataHelperAcknowledgementTypeCreated(tbldatahelperacknowledgementtype);

            var existingItem = Context.TblDataHelperAcknowledgementTypes
                              .Where(i => i.fldRecordID == tbldatahelperacknowledgementtype.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblDataHelperAcknowledgementTypes.Add(tbldatahelperacknowledgementtype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tbldatahelperacknowledgementtype).State = EntityState.Detached;
                throw;
            }

            OnAfterTblDataHelperAcknowledgementTypeCreated(tbldatahelperacknowledgementtype);

            return tbldatahelperacknowledgementtype;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType> CancelTblDataHelperAcknowledgementTypeChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblDataHelperAcknowledgementTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType item);
        partial void OnAfterTblDataHelperAcknowledgementTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType> UpdateTblDataHelperAcknowledgementType(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType tbldatahelperacknowledgementtype)
        {
            OnTblDataHelperAcknowledgementTypeUpdated(tbldatahelperacknowledgementtype);

            var itemToUpdate = Context.TblDataHelperAcknowledgementTypes
                              .Where(i => i.fldRecordID == tbldatahelperacknowledgementtype.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tbldatahelperacknowledgementtype);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblDataHelperAcknowledgementTypeUpdated(tbldatahelperacknowledgementtype);

            return tbldatahelperacknowledgementtype;
        }

        partial void OnTblDataHelperAcknowledgementTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType item);
        partial void OnAfterTblDataHelperAcknowledgementTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType> DeleteTblDataHelperAcknowledgementType(int fldrecordid)
        {
            var itemToDelete = Context.TblDataHelperAcknowledgementTypes
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblDataHelperAcknowledgementTypeDeleted(itemToDelete);


            Context.TblDataHelperAcknowledgementTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblDataHelperAcknowledgementTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblDataHelperFileTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperfiletypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperfiletypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblDataHelperFileTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperfiletypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperfiletypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblDataHelperFileTypesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType>> GetTblDataHelperFileTypes(Query query = null)
        {
            var items = Context.TblDataHelperFileTypes.AsQueryable();


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

            OnTblDataHelperFileTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblDataHelperFileTypeGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType item);
        partial void OnGetTblDataHelperFileTypeByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType> GetTblDataHelperFileTypeByFldRecordId(int fldrecordid)
        {
            var items = Context.TblDataHelperFileTypes
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblDataHelperFileTypeByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblDataHelperFileTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblDataHelperFileTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType item);
        partial void OnAfterTblDataHelperFileTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType> CreateTblDataHelperFileType(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType tbldatahelperfiletype)
        {
            OnTblDataHelperFileTypeCreated(tbldatahelperfiletype);

            var existingItem = Context.TblDataHelperFileTypes
                              .Where(i => i.fldRecordID == tbldatahelperfiletype.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblDataHelperFileTypes.Add(tbldatahelperfiletype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tbldatahelperfiletype).State = EntityState.Detached;
                throw;
            }

            OnAfterTblDataHelperFileTypeCreated(tbldatahelperfiletype);

            return tbldatahelperfiletype;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType> CancelTblDataHelperFileTypeChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblDataHelperFileTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType item);
        partial void OnAfterTblDataHelperFileTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType> UpdateTblDataHelperFileType(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType tbldatahelperfiletype)
        {
            OnTblDataHelperFileTypeUpdated(tbldatahelperfiletype);

            var itemToUpdate = Context.TblDataHelperFileTypes
                              .Where(i => i.fldRecordID == tbldatahelperfiletype.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tbldatahelperfiletype);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblDataHelperFileTypeUpdated(tbldatahelperfiletype);

            return tbldatahelperfiletype;
        }

        partial void OnTblDataHelperFileTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType item);
        partial void OnAfterTblDataHelperFileTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType> DeleteTblDataHelperFileType(int fldrecordid)
        {
            var itemToDelete = Context.TblDataHelperFileTypes
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblDataHelperFileTypeDeleted(itemToDelete);


            Context.TblDataHelperFileTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblDataHelperFileTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblDataHelperIntegrationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperintegrations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperintegrations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblDataHelperIntegrationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperintegrations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperintegrations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblDataHelperIntegrationsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration>> GetTblDataHelperIntegrations(Query query = null)
        {
            var items = Context.TblDataHelperIntegrations.AsQueryable();


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

            OnTblDataHelperIntegrationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblDataHelperIntegrationGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration item);
        partial void OnGetTblDataHelperIntegrationByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration> GetTblDataHelperIntegrationByFldRecordId(int fldrecordid)
        {
            var items = Context.TblDataHelperIntegrations
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblDataHelperIntegrationByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblDataHelperIntegrationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblDataHelperIntegrationCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration item);
        partial void OnAfterTblDataHelperIntegrationCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration> CreateTblDataHelperIntegration(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration tbldatahelperintegration)
        {
            OnTblDataHelperIntegrationCreated(tbldatahelperintegration);

            var existingItem = Context.TblDataHelperIntegrations
                              .Where(i => i.fldRecordID == tbldatahelperintegration.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblDataHelperIntegrations.Add(tbldatahelperintegration);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tbldatahelperintegration).State = EntityState.Detached;
                throw;
            }

            OnAfterTblDataHelperIntegrationCreated(tbldatahelperintegration);

            return tbldatahelperintegration;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration> CancelTblDataHelperIntegrationChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblDataHelperIntegrationUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration item);
        partial void OnAfterTblDataHelperIntegrationUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration> UpdateTblDataHelperIntegration(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration tbldatahelperintegration)
        {
            OnTblDataHelperIntegrationUpdated(tbldatahelperintegration);

            var itemToUpdate = Context.TblDataHelperIntegrations
                              .Where(i => i.fldRecordID == tbldatahelperintegration.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tbldatahelperintegration);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblDataHelperIntegrationUpdated(tbldatahelperintegration);

            return tbldatahelperintegration;
        }

        partial void OnTblDataHelperIntegrationDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration item);
        partial void OnAfterTblDataHelperIntegrationDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration> DeleteTblDataHelperIntegration(int fldrecordid)
        {
            var itemToDelete = Context.TblDataHelperIntegrations
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblDataHelperIntegrationDeleted(itemToDelete);


            Context.TblDataHelperIntegrations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblDataHelperIntegrationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblDataHelperPosTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperpostypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperpostypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblDataHelperPosTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperpostypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperpostypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblDataHelperPosTypesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType>> GetTblDataHelperPosTypes(Query query = null)
        {
            var items = Context.TblDataHelperPosTypes.AsQueryable();


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

            OnTblDataHelperPosTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblDataHelperPosTypeGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType item);
        partial void OnGetTblDataHelperPosTypeByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType> GetTblDataHelperPosTypeByFldRecordId(int fldrecordid)
        {
            var items = Context.TblDataHelperPosTypes
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblDataHelperPosTypeByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblDataHelperPosTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblDataHelperPosTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType item);
        partial void OnAfterTblDataHelperPosTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType> CreateTblDataHelperPosType(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType tbldatahelperpostype)
        {
            OnTblDataHelperPosTypeCreated(tbldatahelperpostype);

            var existingItem = Context.TblDataHelperPosTypes
                              .Where(i => i.fldRecordID == tbldatahelperpostype.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblDataHelperPosTypes.Add(tbldatahelperpostype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tbldatahelperpostype).State = EntityState.Detached;
                throw;
            }

            OnAfterTblDataHelperPosTypeCreated(tbldatahelperpostype);

            return tbldatahelperpostype;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType> CancelTblDataHelperPosTypeChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblDataHelperPosTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType item);
        partial void OnAfterTblDataHelperPosTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType> UpdateTblDataHelperPosType(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType tbldatahelperpostype)
        {
            OnTblDataHelperPosTypeUpdated(tbldatahelperpostype);

            var itemToUpdate = Context.TblDataHelperPosTypes
                              .Where(i => i.fldRecordID == tbldatahelperpostype.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tbldatahelperpostype);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblDataHelperPosTypeUpdated(tbldatahelperpostype);

            return tbldatahelperpostype;
        }

        partial void OnTblDataHelperPosTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType item);
        partial void OnAfterTblDataHelperPosTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType> DeleteTblDataHelperPosType(int fldrecordid)
        {
            var itemToDelete = Context.TblDataHelperPosTypes
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblDataHelperPosTypeDeleted(itemToDelete);


            Context.TblDataHelperPosTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblDataHelperPosTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblDataHelperProductsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperproducts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperproducts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblDataHelperProductsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldatahelperproducts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldatahelperproducts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblDataHelperProductsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct>> GetTblDataHelperProducts(Query query = null)
        {
            var items = Context.TblDataHelperProducts.AsQueryable();


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

            OnTblDataHelperProductsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblDataHelperProductGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct item);
        partial void OnGetTblDataHelperProductByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct> GetTblDataHelperProductByFldRecordId(int fldrecordid)
        {
            var items = Context.TblDataHelperProducts
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblDataHelperProductByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblDataHelperProductGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblDataHelperProductCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct item);
        partial void OnAfterTblDataHelperProductCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct> CreateTblDataHelperProduct(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct tbldatahelperproduct)
        {
            OnTblDataHelperProductCreated(tbldatahelperproduct);

            var existingItem = Context.TblDataHelperProducts
                              .Where(i => i.fldRecordID == tbldatahelperproduct.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblDataHelperProducts.Add(tbldatahelperproduct);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tbldatahelperproduct).State = EntityState.Detached;
                throw;
            }

            OnAfterTblDataHelperProductCreated(tbldatahelperproduct);

            return tbldatahelperproduct;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct> CancelTblDataHelperProductChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblDataHelperProductUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct item);
        partial void OnAfterTblDataHelperProductUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct> UpdateTblDataHelperProduct(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct tbldatahelperproduct)
        {
            OnTblDataHelperProductUpdated(tbldatahelperproduct);

            var itemToUpdate = Context.TblDataHelperProducts
                              .Where(i => i.fldRecordID == tbldatahelperproduct.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tbldatahelperproduct);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblDataHelperProductUpdated(tbldatahelperproduct);

            return tbldatahelperproduct;
        }

        partial void OnTblDataHelperProductDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct item);
        partial void OnAfterTblDataHelperProductDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct> DeleteTblDataHelperProduct(int fldrecordid)
        {
            var itemToDelete = Context.TblDataHelperProducts
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblDataHelperProductDeleted(itemToDelete);


            Context.TblDataHelperProducts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblDataHelperProductDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblDataImportStoresToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldataimportstores/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldataimportstores/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblDataImportStoresToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldataimportstores/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldataimportstores/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblDataImportStoresRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore>> GetTblDataImportStores(Query query = null)
        {
            var items = Context.TblDataImportStores.AsQueryable();


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

            OnTblDataImportStoresRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblDataImportStoreGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore item);
        partial void OnGetTblDataImportStoreByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore> GetTblDataImportStoreByFldRecordId(int fldrecordid)
        {
            var items = Context.TblDataImportStores
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblDataImportStoreByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblDataImportStoreGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblDataImportStoreCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore item);
        partial void OnAfterTblDataImportStoreCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore> CreateTblDataImportStore(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore tbldataimportstore)
        {
            OnTblDataImportStoreCreated(tbldataimportstore);

            var existingItem = Context.TblDataImportStores
                              .Where(i => i.fldRecordID == tbldataimportstore.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblDataImportStores.Add(tbldataimportstore);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tbldataimportstore).State = EntityState.Detached;
                throw;
            }

            OnAfterTblDataImportStoreCreated(tbldataimportstore);

            return tbldataimportstore;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore> CancelTblDataImportStoreChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblDataImportStoreUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore item);
        partial void OnAfterTblDataImportStoreUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore> UpdateTblDataImportStore(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore tbldataimportstore)
        {
            OnTblDataImportStoreUpdated(tbldataimportstore);

            var itemToUpdate = Context.TblDataImportStores
                              .Where(i => i.fldRecordID == tbldataimportstore.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tbldataimportstore);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblDataImportStoreUpdated(tbldataimportstore);

            return tbldataimportstore;
        }

        partial void OnTblDataImportStoreDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore item);
        partial void OnAfterTblDataImportStoreDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore> DeleteTblDataImportStore(int fldrecordid)
        {
            var itemToDelete = Context.TblDataImportStores
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblDataImportStoreDeleted(itemToDelete);


            Context.TblDataImportStores.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblDataImportStoreDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblDataImportVerificationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldataimportverifications/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldataimportverifications/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblDataImportVerificationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tbldataimportverifications/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tbldataimportverifications/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblDataImportVerificationsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification>> GetTblDataImportVerifications(Query query = null)
        {
            var items = Context.TblDataImportVerifications.AsQueryable();


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

            OnTblDataImportVerificationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblDataImportVerificationGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification item);
        partial void OnGetTblDataImportVerificationByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification> GetTblDataImportVerificationByFldRecordId(int fldrecordid)
        {
            var items = Context.TblDataImportVerifications
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblDataImportVerificationByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblDataImportVerificationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblDataImportVerificationCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification item);
        partial void OnAfterTblDataImportVerificationCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification> CreateTblDataImportVerification(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification tbldataimportverification)
        {
            OnTblDataImportVerificationCreated(tbldataimportverification);

            var existingItem = Context.TblDataImportVerifications
                              .Where(i => i.fldRecordID == tbldataimportverification.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblDataImportVerifications.Add(tbldataimportverification);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tbldataimportverification).State = EntityState.Detached;
                throw;
            }

            OnAfterTblDataImportVerificationCreated(tbldataimportverification);

            return tbldataimportverification;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification> CancelTblDataImportVerificationChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblDataImportVerificationUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification item);
        partial void OnAfterTblDataImportVerificationUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification> UpdateTblDataImportVerification(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification tbldataimportverification)
        {
            OnTblDataImportVerificationUpdated(tbldataimportverification);

            var itemToUpdate = Context.TblDataImportVerifications
                              .Where(i => i.fldRecordID == tbldataimportverification.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tbldataimportverification);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblDataImportVerificationUpdated(tbldataimportverification);

            return tbldataimportverification;
        }

        partial void OnTblDataImportVerificationDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification item);
        partial void OnAfterTblDataImportVerificationDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification> DeleteTblDataImportVerification(int fldrecordid)
        {
            var itemToDelete = Context.TblDataImportVerifications
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblDataImportVerificationDeleted(itemToDelete);


            Context.TblDataImportVerifications.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblDataImportVerificationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblMessageActivitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessageactivities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessageactivities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblMessageActivitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessageactivities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessageactivities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblMessageActivitiesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity>> GetTblMessageActivities(Query query = null)
        {
            var items = Context.TblMessageActivities.AsQueryable();


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

            OnTblMessageActivitiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblMessageActivityGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity item);
        partial void OnGetTblMessageActivityByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity> GetTblMessageActivityByFldRecordId(long fldrecordid)
        {
            var items = Context.TblMessageActivities
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblMessageActivityByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblMessageActivityGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblMessageActivityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity item);
        partial void OnAfterTblMessageActivityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity> CreateTblMessageActivity(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity tblmessageactivity)
        {
            OnTblMessageActivityCreated(tblmessageactivity);

            var existingItem = Context.TblMessageActivities
                              .Where(i => i.fldRecordID == tblmessageactivity.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblMessageActivities.Add(tblmessageactivity);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblmessageactivity).State = EntityState.Detached;
                throw;
            }

            OnAfterTblMessageActivityCreated(tblmessageactivity);

            return tblmessageactivity;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity> CancelTblMessageActivityChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblMessageActivityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity item);
        partial void OnAfterTblMessageActivityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity> UpdateTblMessageActivity(long fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity tblmessageactivity)
        {
            OnTblMessageActivityUpdated(tblmessageactivity);

            var itemToUpdate = Context.TblMessageActivities
                              .Where(i => i.fldRecordID == tblmessageactivity.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblmessageactivity);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblMessageActivityUpdated(tblmessageactivity);

            return tblmessageactivity;
        }

        partial void OnTblMessageActivityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity item);
        partial void OnAfterTblMessageActivityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity> DeleteTblMessageActivity(long fldrecordid)
        {
            var itemToDelete = Context.TblMessageActivities
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblMessageActivityDeleted(itemToDelete);


            Context.TblMessageActivities.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblMessageActivityDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblMessageCommDatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagecommdates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagecommdates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblMessageCommDatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagecommdates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagecommdates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblMessageCommDatesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate>> GetTblMessageCommDates(Query query = null)
        {
            var items = Context.TblMessageCommDates.AsQueryable();


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

            OnTblMessageCommDatesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblMessageCommDateGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate item);
        partial void OnGetTblMessageCommDateByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate> GetTblMessageCommDateByFldRecordId(int fldrecordid)
        {
            var items = Context.TblMessageCommDates
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblMessageCommDateByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblMessageCommDateGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblMessageCommDateCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate item);
        partial void OnAfterTblMessageCommDateCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate> CreateTblMessageCommDate(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate tblmessagecommdate)
        {
            OnTblMessageCommDateCreated(tblmessagecommdate);

            var existingItem = Context.TblMessageCommDates
                              .Where(i => i.fldRecordID == tblmessagecommdate.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblMessageCommDates.Add(tblmessagecommdate);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblmessagecommdate).State = EntityState.Detached;
                throw;
            }

            OnAfterTblMessageCommDateCreated(tblmessagecommdate);

            return tblmessagecommdate;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate> CancelTblMessageCommDateChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblMessageCommDateUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate item);
        partial void OnAfterTblMessageCommDateUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate> UpdateTblMessageCommDate(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate tblmessagecommdate)
        {
            OnTblMessageCommDateUpdated(tblmessagecommdate);

            var itemToUpdate = Context.TblMessageCommDates
                              .Where(i => i.fldRecordID == tblmessagecommdate.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblmessagecommdate);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblMessageCommDateUpdated(tblmessagecommdate);

            return tblmessagecommdate;
        }

        partial void OnTblMessageCommDateDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate item);
        partial void OnAfterTblMessageCommDateDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate> DeleteTblMessageCommDate(int fldrecordid)
        {
            var itemToDelete = Context.TblMessageCommDates
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblMessageCommDateDeleted(itemToDelete);


            Context.TblMessageCommDates.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblMessageCommDateDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblMessageDirectionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagedirections/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagedirections/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblMessageDirectionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagedirections/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagedirections/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblMessageDirectionsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection>> GetTblMessageDirections(Query query = null)
        {
            var items = Context.TblMessageDirections.AsQueryable();


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

            OnTblMessageDirectionsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblMessageDirectionGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection item);
        partial void OnGetTblMessageDirectionByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection> GetTblMessageDirectionByFldRecordId(int fldrecordid)
        {
            var items = Context.TblMessageDirections
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblMessageDirectionByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblMessageDirectionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblMessageDirectionCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection item);
        partial void OnAfterTblMessageDirectionCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection> CreateTblMessageDirection(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection tblmessagedirection)
        {
            OnTblMessageDirectionCreated(tblmessagedirection);

            var existingItem = Context.TblMessageDirections
                              .Where(i => i.fldRecordID == tblmessagedirection.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblMessageDirections.Add(tblmessagedirection);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblmessagedirection).State = EntityState.Detached;
                throw;
            }

            OnAfterTblMessageDirectionCreated(tblmessagedirection);

            return tblmessagedirection;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection> CancelTblMessageDirectionChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblMessageDirectionUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection item);
        partial void OnAfterTblMessageDirectionUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection> UpdateTblMessageDirection(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection tblmessagedirection)
        {
            OnTblMessageDirectionUpdated(tblmessagedirection);

            var itemToUpdate = Context.TblMessageDirections
                              .Where(i => i.fldRecordID == tblmessagedirection.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblmessagedirection);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblMessageDirectionUpdated(tblmessagedirection);

            return tblmessagedirection;
        }

        partial void OnTblMessageDirectionDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection item);
        partial void OnAfterTblMessageDirectionDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection> DeleteTblMessageDirection(int fldrecordid)
        {
            var itemToDelete = Context.TblMessageDirections
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblMessageDirectionDeleted(itemToDelete);


            Context.TblMessageDirections.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblMessageDirectionDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblMessageErrorCodesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessageerrorcodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessageerrorcodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblMessageErrorCodesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessageerrorcodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessageerrorcodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblMessageErrorCodesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode>> GetTblMessageErrorCodes(Query query = null)
        {
            var items = Context.TblMessageErrorCodes.AsQueryable();


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

            OnTblMessageErrorCodesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblMessageErrorCodeGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode item);
        partial void OnGetTblMessageErrorCodeByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode> GetTblMessageErrorCodeByFldRecordId(int fldrecordid)
        {
            var items = Context.TblMessageErrorCodes
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblMessageErrorCodeByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblMessageErrorCodeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblMessageErrorCodeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode item);
        partial void OnAfterTblMessageErrorCodeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode> CreateTblMessageErrorCode(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode tblmessageerrorcode)
        {
            OnTblMessageErrorCodeCreated(tblmessageerrorcode);

            var existingItem = Context.TblMessageErrorCodes
                              .Where(i => i.fldRecordID == tblmessageerrorcode.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblMessageErrorCodes.Add(tblmessageerrorcode);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblmessageerrorcode).State = EntityState.Detached;
                throw;
            }

            OnAfterTblMessageErrorCodeCreated(tblmessageerrorcode);

            return tblmessageerrorcode;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode> CancelTblMessageErrorCodeChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblMessageErrorCodeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode item);
        partial void OnAfterTblMessageErrorCodeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode> UpdateTblMessageErrorCode(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode tblmessageerrorcode)
        {
            OnTblMessageErrorCodeUpdated(tblmessageerrorcode);

            var itemToUpdate = Context.TblMessageErrorCodes
                              .Where(i => i.fldRecordID == tblmessageerrorcode.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblmessageerrorcode);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblMessageErrorCodeUpdated(tblmessageerrorcode);

            return tblmessageerrorcode;
        }

        partial void OnTblMessageErrorCodeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode item);
        partial void OnAfterTblMessageErrorCodeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode> DeleteTblMessageErrorCode(int fldrecordid)
        {
            var itemToDelete = Context.TblMessageErrorCodes
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblMessageErrorCodeDeleted(itemToDelete);


            Context.TblMessageErrorCodes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblMessageErrorCodeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblMessageGroupingTermsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagegroupingterms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagegroupingterms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblMessageGroupingTermsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagegroupingterms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagegroupingterms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblMessageGroupingTermsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm>> GetTblMessageGroupingTerms(Query query = null)
        {
            var items = Context.TblMessageGroupingTerms.AsQueryable();


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

            OnTblMessageGroupingTermsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblMessageGroupingTermGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm item);
        partial void OnGetTblMessageGroupingTermByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm> GetTblMessageGroupingTermByFldRecordId(int fldrecordid)
        {
            var items = Context.TblMessageGroupingTerms
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblMessageGroupingTermByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblMessageGroupingTermGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblMessageGroupingTermCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm item);
        partial void OnAfterTblMessageGroupingTermCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm> CreateTblMessageGroupingTerm(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm tblmessagegroupingterm)
        {
            OnTblMessageGroupingTermCreated(tblmessagegroupingterm);

            var existingItem = Context.TblMessageGroupingTerms
                              .Where(i => i.fldRecordID == tblmessagegroupingterm.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblMessageGroupingTerms.Add(tblmessagegroupingterm);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblmessagegroupingterm).State = EntityState.Detached;
                throw;
            }

            OnAfterTblMessageGroupingTermCreated(tblmessagegroupingterm);

            return tblmessagegroupingterm;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm> CancelTblMessageGroupingTermChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblMessageGroupingTermUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm item);
        partial void OnAfterTblMessageGroupingTermUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm> UpdateTblMessageGroupingTerm(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm tblmessagegroupingterm)
        {
            OnTblMessageGroupingTermUpdated(tblmessagegroupingterm);

            var itemToUpdate = Context.TblMessageGroupingTerms
                              .Where(i => i.fldRecordID == tblmessagegroupingterm.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblmessagegroupingterm);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblMessageGroupingTermUpdated(tblmessagegroupingterm);

            return tblmessagegroupingterm;
        }

        partial void OnTblMessageGroupingTermDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm item);
        partial void OnAfterTblMessageGroupingTermDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm> DeleteTblMessageGroupingTerm(int fldrecordid)
        {
            var itemToDelete = Context.TblMessageGroupingTerms
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblMessageGroupingTermDeleted(itemToDelete);


            Context.TblMessageGroupingTerms.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblMessageGroupingTermDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblMessageGroupingTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagegroupingtypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagegroupingtypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblMessageGroupingTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagegroupingtypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagegroupingtypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblMessageGroupingTypesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType>> GetTblMessageGroupingTypes(Query query = null)
        {
            var items = Context.TblMessageGroupingTypes.AsQueryable();


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

            OnTblMessageGroupingTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblMessageGroupingTypeGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType item);
        partial void OnGetTblMessageGroupingTypeByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType> GetTblMessageGroupingTypeByFldRecordId(short fldrecordid)
        {
            var items = Context.TblMessageGroupingTypes
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblMessageGroupingTypeByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblMessageGroupingTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblMessageGroupingTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType item);
        partial void OnAfterTblMessageGroupingTypeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType> CreateTblMessageGroupingType(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType tblmessagegroupingtype)
        {
            OnTblMessageGroupingTypeCreated(tblmessagegroupingtype);

            var existingItem = Context.TblMessageGroupingTypes
                              .Where(i => i.fldRecordID == tblmessagegroupingtype.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblMessageGroupingTypes.Add(tblmessagegroupingtype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblmessagegroupingtype).State = EntityState.Detached;
                throw;
            }

            OnAfterTblMessageGroupingTypeCreated(tblmessagegroupingtype);

            return tblmessagegroupingtype;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType> CancelTblMessageGroupingTypeChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblMessageGroupingTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType item);
        partial void OnAfterTblMessageGroupingTypeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType> UpdateTblMessageGroupingType(short fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType tblmessagegroupingtype)
        {
            OnTblMessageGroupingTypeUpdated(tblmessagegroupingtype);

            var itemToUpdate = Context.TblMessageGroupingTypes
                              .Where(i => i.fldRecordID == tblmessagegroupingtype.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblmessagegroupingtype);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblMessageGroupingTypeUpdated(tblmessagegroupingtype);

            return tblmessagegroupingtype;
        }

        partial void OnTblMessageGroupingTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType item);
        partial void OnAfterTblMessageGroupingTypeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType> DeleteTblMessageGroupingType(short fldrecordid)
        {
            var itemToDelete = Context.TblMessageGroupingTypes
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblMessageGroupingTypeDeleted(itemToDelete);


            Context.TblMessageGroupingTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblMessageGroupingTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblMessageMissedCallsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagemissedcalls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagemissedcalls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblMessageMissedCallsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagemissedcalls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagemissedcalls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblMessageMissedCallsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall>> GetTblMessageMissedCalls(Query query = null)
        {
            var items = Context.TblMessageMissedCalls.AsQueryable();


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

            OnTblMessageMissedCallsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblMessageMissedCallGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall item);
        partial void OnGetTblMessageMissedCallByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall> GetTblMessageMissedCallByFldRecordId(int fldrecordid)
        {
            var items = Context.TblMessageMissedCalls
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblMessageMissedCallByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblMessageMissedCallGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblMessageMissedCallCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall item);
        partial void OnAfterTblMessageMissedCallCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall> CreateTblMessageMissedCall(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall tblmessagemissedcall)
        {
            OnTblMessageMissedCallCreated(tblmessagemissedcall);

            var existingItem = Context.TblMessageMissedCalls
                              .Where(i => i.fldRecordID == tblmessagemissedcall.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblMessageMissedCalls.Add(tblmessagemissedcall);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblmessagemissedcall).State = EntityState.Detached;
                throw;
            }

            OnAfterTblMessageMissedCallCreated(tblmessagemissedcall);

            return tblmessagemissedcall;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall> CancelTblMessageMissedCallChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblMessageMissedCallUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall item);
        partial void OnAfterTblMessageMissedCallUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall> UpdateTblMessageMissedCall(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall tblmessagemissedcall)
        {
            OnTblMessageMissedCallUpdated(tblmessagemissedcall);

            var itemToUpdate = Context.TblMessageMissedCalls
                              .Where(i => i.fldRecordID == tblmessagemissedcall.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblmessagemissedcall);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblMessageMissedCallUpdated(tblmessagemissedcall);

            return tblmessagemissedcall;
        }

        partial void OnTblMessageMissedCallDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall item);
        partial void OnAfterTblMessageMissedCallDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall> DeleteTblMessageMissedCall(int fldrecordid)
        {
            var itemToDelete = Context.TblMessageMissedCalls
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblMessageMissedCallDeleted(itemToDelete);


            Context.TblMessageMissedCalls.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblMessageMissedCallDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblMessageNotificationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagenotifications/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagenotifications/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblMessageNotificationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagenotifications/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagenotifications/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblMessageNotificationsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification>> GetTblMessageNotifications(Query query = null)
        {
            var items = Context.TblMessageNotifications.AsQueryable();


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

            OnTblMessageNotificationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblMessageNotificationGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification item);
        partial void OnGetTblMessageNotificationByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification> GetTblMessageNotificationByFldRecordId(int fldrecordid)
        {
            var items = Context.TblMessageNotifications
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblMessageNotificationByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblMessageNotificationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblMessageNotificationCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification item);
        partial void OnAfterTblMessageNotificationCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification> CreateTblMessageNotification(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification tblmessagenotification)
        {
            OnTblMessageNotificationCreated(tblmessagenotification);

            var existingItem = Context.TblMessageNotifications
                              .Where(i => i.fldRecordID == tblmessagenotification.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblMessageNotifications.Add(tblmessagenotification);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblmessagenotification).State = EntityState.Detached;
                throw;
            }

            OnAfterTblMessageNotificationCreated(tblmessagenotification);

            return tblmessagenotification;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification> CancelTblMessageNotificationChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblMessageNotificationUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification item);
        partial void OnAfterTblMessageNotificationUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification> UpdateTblMessageNotification(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification tblmessagenotification)
        {
            OnTblMessageNotificationUpdated(tblmessagenotification);

            var itemToUpdate = Context.TblMessageNotifications
                              .Where(i => i.fldRecordID == tblmessagenotification.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblmessagenotification);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblMessageNotificationUpdated(tblmessagenotification);

            return tblmessagenotification;
        }

        partial void OnTblMessageNotificationDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification item);
        partial void OnAfterTblMessageNotificationDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification> DeleteTblMessageNotification(int fldrecordid)
        {
            var itemToDelete = Context.TblMessageNotifications
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblMessageNotificationDeleted(itemToDelete);


            Context.TblMessageNotifications.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblMessageNotificationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblMessagePhoneNumbersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagephonenumbers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagephonenumbers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblMessagePhoneNumbersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagephonenumbers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagephonenumbers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblMessagePhoneNumbersRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber>> GetTblMessagePhoneNumbers(Query query = null)
        {
            var items = Context.TblMessagePhoneNumbers.AsQueryable();


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

            OnTblMessagePhoneNumbersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblMessagePhoneNumberGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber item);
        partial void OnGetTblMessagePhoneNumberByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber> GetTblMessagePhoneNumberByFldRecordId(long fldrecordid)
        {
            var items = Context.TblMessagePhoneNumbers
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblMessagePhoneNumberByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblMessagePhoneNumberGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblMessagePhoneNumberCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber item);
        partial void OnAfterTblMessagePhoneNumberCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber> CreateTblMessagePhoneNumber(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber tblmessagephonenumber)
        {
            OnTblMessagePhoneNumberCreated(tblmessagephonenumber);

            var existingItem = Context.TblMessagePhoneNumbers
                              .Where(i => i.fldRecordID == tblmessagephonenumber.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblMessagePhoneNumbers.Add(tblmessagephonenumber);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblmessagephonenumber).State = EntityState.Detached;
                throw;
            }

            OnAfterTblMessagePhoneNumberCreated(tblmessagephonenumber);

            return tblmessagephonenumber;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber> CancelTblMessagePhoneNumberChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblMessagePhoneNumberUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber item);
        partial void OnAfterTblMessagePhoneNumberUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber> UpdateTblMessagePhoneNumber(long fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber tblmessagephonenumber)
        {
            OnTblMessagePhoneNumberUpdated(tblmessagephonenumber);

            var itemToUpdate = Context.TblMessagePhoneNumbers
                              .Where(i => i.fldRecordID == tblmessagephonenumber.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblmessagephonenumber);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblMessagePhoneNumberUpdated(tblmessagephonenumber);

            return tblmessagephonenumber;
        }

        partial void OnTblMessagePhoneNumberDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber item);
        partial void OnAfterTblMessagePhoneNumberDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber> DeleteTblMessagePhoneNumber(long fldrecordid)
        {
            var itemToDelete = Context.TblMessagePhoneNumbers
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblMessagePhoneNumberDeleted(itemToDelete);


            Context.TblMessagePhoneNumbers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblMessagePhoneNumberDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblMessageSettingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagesettings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagesettings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblMessageSettingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessagesettings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessagesettings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblMessageSettingsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting>> GetTblMessageSettings(Query query = null)
        {
            var items = Context.TblMessageSettings.AsQueryable();


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

            OnTblMessageSettingsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblMessageSettingGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting item);
        partial void OnGetTblMessageSettingByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting> GetTblMessageSettingByFldRecordId(int fldrecordid)
        {
            var items = Context.TblMessageSettings
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblMessageSettingByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblMessageSettingGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblMessageSettingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting item);
        partial void OnAfterTblMessageSettingCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting> CreateTblMessageSetting(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting tblmessagesetting)
        {
            OnTblMessageSettingCreated(tblmessagesetting);

            var existingItem = Context.TblMessageSettings
                              .Where(i => i.fldRecordID == tblmessagesetting.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblMessageSettings.Add(tblmessagesetting);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblmessagesetting).State = EntityState.Detached;
                throw;
            }

            OnAfterTblMessageSettingCreated(tblmessagesetting);

            return tblmessagesetting;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting> CancelTblMessageSettingChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblMessageSettingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting item);
        partial void OnAfterTblMessageSettingUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting> UpdateTblMessageSetting(int fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting tblmessagesetting)
        {
            OnTblMessageSettingUpdated(tblmessagesetting);

            var itemToUpdate = Context.TblMessageSettings
                              .Where(i => i.fldRecordID == tblmessagesetting.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblmessagesetting);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblMessageSettingUpdated(tblmessagesetting);

            return tblmessagesetting;
        }

        partial void OnTblMessageSettingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting item);
        partial void OnAfterTblMessageSettingDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting> DeleteTblMessageSetting(int fldrecordid)
        {
            var itemToDelete = Context.TblMessageSettings
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblMessageSettingDeleted(itemToDelete);


            Context.TblMessageSettings.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblMessageSettingDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblMessageUsagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessageusages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessageusages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblMessageUsagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/tblmessageusages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/tblmessageusages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblMessageUsagesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage>> GetTblMessageUsages(Query query = null)
        {
            var items = Context.TblMessageUsages.AsQueryable();


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

            OnTblMessageUsagesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblMessageUsageGet(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage item);
        partial void OnGetTblMessageUsageByFldRecordId(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage> items);


        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage> GetTblMessageUsageByFldRecordId(long fldrecordid)
        {
            var items = Context.TblMessageUsages
                              .AsNoTracking()
                              .Where(i => i.fldRecordID == fldrecordid);

 
            OnGetTblMessageUsageByFldRecordId(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblMessageUsageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblMessageUsageCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage item);
        partial void OnAfterTblMessageUsageCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage> CreateTblMessageUsage(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage tblmessageusage)
        {
            OnTblMessageUsageCreated(tblmessageusage);

            var existingItem = Context.TblMessageUsages
                              .Where(i => i.fldRecordID == tblmessageusage.fldRecordID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblMessageUsages.Add(tblmessageusage);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblmessageusage).State = EntityState.Detached;
                throw;
            }

            OnAfterTblMessageUsageCreated(tblmessageusage);

            return tblmessageusage;
        }

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage> CancelTblMessageUsageChanges(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblMessageUsageUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage item);
        partial void OnAfterTblMessageUsageUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage> UpdateTblMessageUsage(long fldrecordid, ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage tblmessageusage)
        {
            OnTblMessageUsageUpdated(tblmessageusage);

            var itemToUpdate = Context.TblMessageUsages
                              .Where(i => i.fldRecordID == tblmessageusage.fldRecordID)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblmessageusage);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblMessageUsageUpdated(tblmessageusage);

            return tblmessageusage;
        }

        partial void OnTblMessageUsageDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage item);
        partial void OnAfterTblMessageUsageDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage item);

        public async Task<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage> DeleteTblMessageUsage(long fldrecordid)
        {
            var itemToDelete = Context.TblMessageUsages
                              .Where(i => i.fldRecordID == fldrecordid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblMessageUsageDeleted(itemToDelete);


            Context.TblMessageUsages.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblMessageUsageDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportUserdetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/userdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/userdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportUserdetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/throttle_core_activity/userdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/throttle_core_activity/userdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnUserdetailsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.Userdetail> items);

        public async Task<IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.Userdetail>> GetUserdetails(Query query = null)
        {
            var items = Context.Userdetails.AsQueryable();


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

            OnUserdetailsRead(ref items);

            return await Task.FromResult(items);
        }
    }
}