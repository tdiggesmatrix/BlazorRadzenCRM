using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ThrottleCoreCRM.Server.Controllers.Throttle_Core_Billing
{
    [Route("odata/Throttle_Core_Billing/SettingsConfigurations")]
    public partial class SettingsConfigurationsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context;

        public SettingsConfigurationsController(ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration> GetSettingsConfigurations()
        {
            var items = this.context.SettingsConfigurations.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration>();
            this.OnSettingsConfigurationsRead(ref items);

            return items;
        }

        partial void OnSettingsConfigurationsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration> items);

        partial void OnSettingsConfigurationGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Billing/SettingsConfigurations(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration> GetSettingsConfiguration(int key)
        {
            var items = this.context.SettingsConfigurations.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnSettingsConfigurationGet(ref result);

            return result;
        }
        partial void OnSettingsConfigurationDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration item);
        partial void OnAfterSettingsConfigurationDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration item);

        [HttpDelete("/odata/Throttle_Core_Billing/SettingsConfigurations(fldRecordID={fldRecordID})")]
        public IActionResult DeleteSettingsConfiguration(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.SettingsConfigurations
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnSettingsConfigurationDeleted(item);
                this.context.SettingsConfigurations.Remove(item);
                this.context.SaveChanges();
                this.OnAfterSettingsConfigurationDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnSettingsConfigurationUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration item);
        partial void OnAfterSettingsConfigurationUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration item);

        [HttpPut("/odata/Throttle_Core_Billing/SettingsConfigurations(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutSettingsConfiguration(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.fldRecordID != key))
                {
                    return BadRequest();
                }
                this.OnSettingsConfigurationUpdated(item);
                this.context.SettingsConfigurations.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.SettingsConfigurations.Where(i => i.fldRecordID == key);
                
                this.OnAfterSettingsConfigurationUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Billing/SettingsConfigurations(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchSettingsConfiguration(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.SettingsConfigurations.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnSettingsConfigurationUpdated(item);
                this.context.SettingsConfigurations.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.SettingsConfigurations.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnSettingsConfigurationCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration item);
        partial void OnAfterSettingsConfigurationCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null)
                {
                    return BadRequest();
                }

                this.OnSettingsConfigurationCreated(item);
                this.context.SettingsConfigurations.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.SettingsConfigurations.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterSettingsConfigurationCreated(item);

                return new ObjectResult(SingleResult.Create(itemToReturn))
                {
                    StatusCode = 201
                };
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
