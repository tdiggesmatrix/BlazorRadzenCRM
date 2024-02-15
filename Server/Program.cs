using Radzen;
using ThrottleCoreCRM.Server.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;
using ThrottleCoreCRM.Server.Data;
using Microsoft.AspNetCore.Identity;
using ThrottleCoreCRM.Server.Models;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents().AddHubOptions(options => options.MaximumReceiveMessageSize = 10 * 1024 * 1024).AddInteractiveWebAssemblyComponents();
builder.Services.AddControllers();
builder.Services.AddRadzenComponents();
builder.Services.AddHttpClient();
builder.Services.AddScoped<ThrottleCoreCRM.Server.Throttle_Core_WebSiteService>();
builder.Services.AddDbContext<ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Throttle_Core_WebSiteConnection"));
});
builder.Services.AddControllers().AddOData(opt =>
{
    var oDataBuilderThrottle_Core_WebSite = new ODataConventionModelBuilder();
    oDataBuilderThrottle_Core_WebSite.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact>("Contacts");
    oDataBuilderThrottle_Core_WebSite.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department>("Departments");
    oDataBuilderThrottle_Core_WebSite.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee>("Employees");
    oDataBuilderThrottle_Core_WebSite.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity>("Opportunities");
    oDataBuilderThrottle_Core_WebSite.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus>("OpportunityStatuses");
    oDataBuilderThrottle_Core_WebSite.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task>("Tasks");
    oDataBuilderThrottle_Core_WebSite.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus>("TaskStatuses");
    oDataBuilderThrottle_Core_WebSite.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType>("TaskTypes");
    oDataBuilderThrottle_Core_WebSite.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase>("TblDatabases");
    oDataBuilderThrottle_Core_WebSite.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription>("TblWebSiteErrorDescriptions");
    oDataBuilderThrottle_Core_WebSite.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage>("TblWebSiteLanguages");
    oDataBuilderThrottle_Core_WebSite.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu>("TblWebSiteMenus");
    oDataBuilderThrottle_Core_WebSite.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup>("TblWebSiteSecurityGroups");
    oDataBuilderThrottle_Core_WebSite.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting>("TblWebSiteSecuritySettings");
    oDataBuilderThrottle_Core_WebSite.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser>("TblWebSiteUsers");
    opt.AddRouteComponents("odata/Throttle_Core_WebSite", oDataBuilderThrottle_Core_WebSite.GetEdmModel()).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
});
builder.Services.AddScoped<ThrottleCoreCRM.Client.Throttle_Core_WebSiteService>();
builder.Services.AddScoped<ThrottleCoreCRM.Server.Throttle_Core_SummaryService>();
builder.Services.AddDbContext<ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Throttle_Core_SummaryConnection"));
});
builder.Services.AddControllers().AddOData(opt =>
{
    var oDataBuilderThrottle_Core_Summary = new ODataConventionModelBuilder();
    oDataBuilderThrottle_Core_Summary.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal>("TblDailyTotals");
    oDataBuilderThrottle_Core_Summary.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator>("TblDailyTotalsOperators");
    oDataBuilderThrottle_Core_Summary.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart>("TblDailyTotalsParts");
    oDataBuilderThrottle_Core_Summary.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon>("TblHelperCoupons");
    oDataBuilderThrottle_Core_Summary.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode>("TblHelperEmailStatusCodes");
    oDataBuilderThrottle_Core_Summary.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor>("TblHelperLabors");
    oDataBuilderThrottle_Core_Summary.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError>("TblHelperMailAddressErrors");
    oDataBuilderThrottle_Core_Summary.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart>("TblHelperParts");
    oDataBuilderThrottle_Core_Summary.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign>("TblSummaryCampaigns");
    oDataBuilderThrottle_Core_Summary.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer>("TblSummaryCustomers");
    oDataBuilderThrottle_Core_Summary.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale>("TblSummarySales");
    oDataBuilderThrottle_Core_Summary.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle>("TblSummaryVehicles");
    oDataBuilderThrottle_Core_Summary.Function("TblDailyTotalsLabors").Returns<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsLabor>();
    var throttleCoreSummaryGetDashboardValuesOriginal = oDataBuilderThrottle_Core_Summary.Function("GetDashboardValuesOriginalsFunc");
    throttleCoreSummaryGetDashboardValuesOriginal.Parameter<int?>("WebUserID");
    throttleCoreSummaryGetDashboardValuesOriginal.Parameter<int?>("CustomerID");
    throttleCoreSummaryGetDashboardValuesOriginal.Parameter<string>("StartDate");
    throttleCoreSummaryGetDashboardValuesOriginal.Parameter<string>("EndDate");
    throttleCoreSummaryGetDashboardValuesOriginal.Parameter<string>("Stores");
    throttleCoreSummaryGetDashboardValuesOriginal.Parameter<string>("Groups");
    throttleCoreSummaryGetDashboardValuesOriginal.Parameter<int?>("StartOfWeekDay");
    throttleCoreSummaryGetDashboardValuesOriginal.Parameter<bool?>("ActiveOnly");
    throttleCoreSummaryGetDashboardValuesOriginal.Returns(typeof(int));
    var throttleCoreSummaryGetEmployeesWithDepartment = oDataBuilderThrottle_Core_Summary.Function("GetEmployeesWithDepartmentsFunc");
    throttleCoreSummaryGetEmployeesWithDepartment.Parameter<int?>("id");
    throttleCoreSummaryGetEmployeesWithDepartment.Returns(typeof(int));
    var throttleCoreSummaryUspDashboardGetStatisticsCustomer = oDataBuilderThrottle_Core_Summary.Function("UspDashboardGetStatisticsCustomersFunc");
    throttleCoreSummaryUspDashboardGetStatisticsCustomer.Parameter<int?>("WebUserID");
    throttleCoreSummaryUspDashboardGetStatisticsCustomer.Parameter<int?>("CustomerID");
    throttleCoreSummaryUspDashboardGetStatisticsCustomer.Parameter<string>("Stores");
    throttleCoreSummaryUspDashboardGetStatisticsCustomer.Parameter<string>("Groups");
    throttleCoreSummaryUspDashboardGetStatisticsCustomer.Parameter<string>("StartDate");
    throttleCoreSummaryUspDashboardGetStatisticsCustomer.Parameter<string>("EndDate");
    throttleCoreSummaryUspDashboardGetStatisticsCustomer.Parameter<bool?>("OnlyActiveStores");
    throttleCoreSummaryUspDashboardGetStatisticsCustomer.Parameter<bool?>("ext_Daily");
    throttleCoreSummaryUspDashboardGetStatisticsCustomer.Parameter<bool?>("ext_WTD");
    throttleCoreSummaryUspDashboardGetStatisticsCustomer.Parameter<bool?>("ext_MTD");
    throttleCoreSummaryUspDashboardGetStatisticsCustomer.Parameter<bool?>("ext_YTD");
    throttleCoreSummaryUspDashboardGetStatisticsCustomer.Parameter<bool?>("ext_DOD");
    throttleCoreSummaryUspDashboardGetStatisticsCustomer.Parameter<bool?>("ext_WOW");
    throttleCoreSummaryUspDashboardGetStatisticsCustomer.Parameter<bool?>("ext_MOM");
    throttleCoreSummaryUspDashboardGetStatisticsCustomer.Parameter<bool?>("ext_YOY");
    throttleCoreSummaryUspDashboardGetStatisticsCustomer.Returns(typeof(int));
    var throttleCoreSummaryUspDashboardGetStatisticsTopVehiclesServiced = oDataBuilderThrottle_Core_Summary.Function("UspDashboardGetStatisticsTopVehiclesServicedsFunc");
    throttleCoreSummaryUspDashboardGetStatisticsTopVehiclesServiced.Parameter<int?>("WebUserID");
    throttleCoreSummaryUspDashboardGetStatisticsTopVehiclesServiced.Parameter<int?>("CustomerID");
    throttleCoreSummaryUspDashboardGetStatisticsTopVehiclesServiced.Parameter<string>("Stores");
    throttleCoreSummaryUspDashboardGetStatisticsTopVehiclesServiced.Parameter<string>("Groups");
    throttleCoreSummaryUspDashboardGetStatisticsTopVehiclesServiced.Parameter<string>("StartDate");
    throttleCoreSummaryUspDashboardGetStatisticsTopVehiclesServiced.Parameter<string>("EndDate");
    throttleCoreSummaryUspDashboardGetStatisticsTopVehiclesServiced.Parameter<bool?>("OnlyActiveStores");
    throttleCoreSummaryUspDashboardGetStatisticsTopVehiclesServiced.Parameter<int?>("ext_TopXNumberofVehicles");
    throttleCoreSummaryUspDashboardGetStatisticsTopVehiclesServiced.Parameter<bool?>("ext_IncludeVehicleYear");
    throttleCoreSummaryUspDashboardGetStatisticsTopVehiclesServiced.Returns(typeof(int));
    var throttleCoreSummaryUspDashboardGetValuesCampaign = oDataBuilderThrottle_Core_Summary.Function("UspDashboardGetValuesCampaignsFunc");
    throttleCoreSummaryUspDashboardGetValuesCampaign.Parameter<int?>("WebUserID");
    throttleCoreSummaryUspDashboardGetValuesCampaign.Parameter<int?>("CustomerID");
    throttleCoreSummaryUspDashboardGetValuesCampaign.Parameter<string>("Stores");
    throttleCoreSummaryUspDashboardGetValuesCampaign.Parameter<string>("Groups");
    throttleCoreSummaryUspDashboardGetValuesCampaign.Parameter<string>("StartDate");
    throttleCoreSummaryUspDashboardGetValuesCampaign.Parameter<string>("EndDate");
    throttleCoreSummaryUspDashboardGetValuesCampaign.Parameter<bool?>("OnlyActiveStores");
    throttleCoreSummaryUspDashboardGetValuesCampaign.Parameter<bool?>("ext_Daily");
    throttleCoreSummaryUspDashboardGetValuesCampaign.Parameter<bool?>("ext_WTD");
    throttleCoreSummaryUspDashboardGetValuesCampaign.Parameter<bool?>("ext_MTD");
    throttleCoreSummaryUspDashboardGetValuesCampaign.Parameter<bool?>("ext_YTD");
    throttleCoreSummaryUspDashboardGetValuesCampaign.Parameter<bool?>("ext_DOD");
    throttleCoreSummaryUspDashboardGetValuesCampaign.Parameter<bool?>("ext_WOW");
    throttleCoreSummaryUspDashboardGetValuesCampaign.Parameter<bool?>("ext_MOM");
    throttleCoreSummaryUspDashboardGetValuesCampaign.Parameter<bool?>("ext_YOY");
    throttleCoreSummaryUspDashboardGetValuesCampaign.Returns(typeof(int));
    var throttleCoreSummaryUspDashboardGetValuesSale = oDataBuilderThrottle_Core_Summary.Function("UspDashboardGetValuesSalesFunc");
    throttleCoreSummaryUspDashboardGetValuesSale.Parameter<int?>("WebUserID");
    throttleCoreSummaryUspDashboardGetValuesSale.Parameter<int?>("CustomerID");
    throttleCoreSummaryUspDashboardGetValuesSale.Parameter<string>("Stores");
    throttleCoreSummaryUspDashboardGetValuesSale.Parameter<string>("Groups");
    throttleCoreSummaryUspDashboardGetValuesSale.Parameter<string>("StartDate");
    throttleCoreSummaryUspDashboardGetValuesSale.Parameter<string>("EndDate");
    throttleCoreSummaryUspDashboardGetValuesSale.Parameter<bool?>("OnlyActiveStores");
    throttleCoreSummaryUspDashboardGetValuesSale.Parameter<bool?>("ext_Daily");
    throttleCoreSummaryUspDashboardGetValuesSale.Parameter<bool?>("ext_WTD");
    throttleCoreSummaryUspDashboardGetValuesSale.Parameter<bool?>("ext_MTD");
    throttleCoreSummaryUspDashboardGetValuesSale.Parameter<bool?>("ext_YTD");
    throttleCoreSummaryUspDashboardGetValuesSale.Parameter<bool?>("ext_DOD");
    throttleCoreSummaryUspDashboardGetValuesSale.Parameter<bool?>("ext_WOW");
    throttleCoreSummaryUspDashboardGetValuesSale.Parameter<bool?>("ext_MOM");
    throttleCoreSummaryUspDashboardGetValuesSale.Parameter<bool?>("ext_YOY");
    throttleCoreSummaryUspDashboardGetValuesSale.Returns(typeof(int));
    var throttleCoreSummaryUspDataCreateVehicleSummaryDatum = oDataBuilderThrottle_Core_Summary.Function("UspDataCreateVehicleSummaryDataFunc");
    throttleCoreSummaryUspDataCreateVehicleSummaryDatum.Returns(typeof(int));
    opt.AddRouteComponents("odata/Throttle_Core_Summary", oDataBuilderThrottle_Core_Summary.GetEdmModel()).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
});
builder.Services.AddScoped<ThrottleCoreCRM.Client.Throttle_Core_SummaryService>();
builder.Services.AddScoped<ThrottleCoreCRM.Server.Throttle_Core_CustomerService>();
builder.Services.AddDbContext<ThrottleCoreCRM.Server.Data.Throttle_Core_CustomerContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Throttle_Core_CustomerConnection"));
});
builder.Services.AddControllers().AddOData(opt =>
{
    var oDataBuilderThrottle_Core_Customer = new ODataConventionModelBuilder();
    oDataBuilderThrottle_Core_Customer.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer>("TblCustomers");
    oDataBuilderThrottle_Core_Customer.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand>("TblCustomerBrands");
    oDataBuilderThrottle_Core_Customer.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin>("TblCustomerBrandsStoresJoins");
    oDataBuilderThrottle_Core_Customer.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact>("TblCustomerContacts");
    oDataBuilderThrottle_Core_Customer.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin>("TblCustomerContactsStoresJoins");
    oDataBuilderThrottle_Core_Customer.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise>("TblCustomerFranchises");
    oDataBuilderThrottle_Core_Customer.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin>("TblCustomerFranchisesStoresJoins");
    oDataBuilderThrottle_Core_Customer.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup>("TblCustomerGroups");
    oDataBuilderThrottle_Core_Customer.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin>("TblCustomerGroupsStoresJoins");
    oDataBuilderThrottle_Core_Customer.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry>("TblCustomerIndustries");
    oDataBuilderThrottle_Core_Customer.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin>("TblCustomerIndustryStoresJoins");
    oDataBuilderThrottle_Core_Customer.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService>("TblCustomerProductandServices");
    oDataBuilderThrottle_Core_Customer.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin>("TblCustomerProductandServicesStoresJoins");
    oDataBuilderThrottle_Core_Customer.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore>("TblCustomerStores");
    opt.AddRouteComponents("odata/Throttle_Core_Customer", oDataBuilderThrottle_Core_Customer.GetEdmModel()).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
});
builder.Services.AddScoped<ThrottleCoreCRM.Client.Throttle_Core_CustomerService>();
builder.Services.AddScoped<ThrottleCoreCRM.Server.Throttle_Core_ActivityService>();
builder.Services.AddDbContext<ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Throttle_Core_ActivityConnection"));
});
builder.Services.AddControllers().AddOData(opt =>
{
    var oDataBuilderThrottle_Core_Activity = new ODataConventionModelBuilder();
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity>("TblDataDmSFileActivities");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity>("TblDataDmSFileArchiveActivities");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer>("TblDataDmSFileArchiveServers");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity>("TblDataDmSFtPActivities");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider>("TblDataDmSProviders");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType>("TblDataHelperAcknowledgementTypes");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType>("TblDataHelperFileTypes");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration>("TblDataHelperIntegrations");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType>("TblDataHelperPosTypes");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct>("TblDataHelperProducts");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore>("TblDataImportStores");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification>("TblDataImportVerifications");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity>("TblMessageActivities");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate>("TblMessageCommDates");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection>("TblMessageDirections");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode>("TblMessageErrorCodes");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm>("TblMessageGroupingTerms");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType>("TblMessageGroupingTypes");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall>("TblMessageMissedCalls");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification>("TblMessageNotifications");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber>("TblMessagePhoneNumbers");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting>("TblMessageSettings");
    oDataBuilderThrottle_Core_Activity.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage>("TblMessageUsages");
    oDataBuilderThrottle_Core_Activity.Function("Userdetails").Returns<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.Userdetail>();
    opt.AddRouteComponents("odata/Throttle_Core_Activity", oDataBuilderThrottle_Core_Activity.GetEdmModel()).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
});
builder.Services.AddScoped<ThrottleCoreCRM.Client.Throttle_Core_ActivityService>();
builder.Services.AddScoped<ThrottleCoreCRM.Server.Throttle_Core_BillingService>();
builder.Services.AddDbContext<ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Throttle_Core_BillingConnection"));
});
builder.Services.AddControllers().AddOData(opt =>
{
    var oDataBuilderThrottle_Core_Billing = new ODataConventionModelBuilder();
    oDataBuilderThrottle_Core_Billing.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling>("BulkBillings");
    oDataBuilderThrottle_Core_Billing.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore>("CurrentStores");
    oDataBuilderThrottle_Core_Billing.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling>("CustomerBillings");
    oDataBuilderThrottle_Core_Billing.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping>("CustomerShippings");
    oDataBuilderThrottle_Core_Billing.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>("Jobs");
    oDataBuilderThrottle_Core_Billing.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>("LineItems");
    oDataBuilderThrottle_Core_Billing.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product>("Products");
    oDataBuilderThrottle_Core_Billing.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory>("ProductCategories");
    oDataBuilderThrottle_Core_Billing.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin>("RemindersSettingsAdmins");
    oDataBuilderThrottle_Core_Billing.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration>("SettingsConfigurations");
    oDataBuilderThrottle_Core_Billing.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact>("SettingsContacts");
    oDataBuilderThrottle_Core_Billing.EntitySet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference>("TblCrossReferences");
    var throttleCoreBillingSpGetBillingDetailsByDateByAccount = oDataBuilderThrottle_Core_Billing.Function("SpGetBillingDetailsByDateByAccountsFunc");
    throttleCoreBillingSpGetBillingDetailsByDateByAccount.Parameter<string>("StartDate");
    throttleCoreBillingSpGetBillingDetailsByDateByAccount.Parameter<string>("EndDate");
    throttleCoreBillingSpGetBillingDetailsByDateByAccount.Parameter<string>("DealerCloud");
    throttleCoreBillingSpGetBillingDetailsByDateByAccount.Parameter<string>("Brand");
    throttleCoreBillingSpGetBillingDetailsByDateByAccount.Parameter<string>("SubBrand");
    throttleCoreBillingSpGetBillingDetailsByDateByAccount.Parameter<bool?>("ForPublication");
    throttleCoreBillingSpGetBillingDetailsByDateByAccount.Parameter<bool?>("ShowZeroPriceTrans");
    throttleCoreBillingSpGetBillingDetailsByDateByAccount.Parameter<bool?>("ShowDetails");
    throttleCoreBillingSpGetBillingDetailsByDateByAccount.Parameter<bool?>("SaveDatatoTemporaryTable");
    throttleCoreBillingSpGetBillingDetailsByDateByAccount.Returns(typeof(int));
    var throttleCoreBillingSpGetGeocodeByAddressOrPlace = oDataBuilderThrottle_Core_Billing.Function("SpGetGeocodeByAddressOrPlacesFunc");
    throttleCoreBillingSpGetGeocodeByAddressOrPlace.Parameter<string>("APIkey");
    throttleCoreBillingSpGetGeocodeByAddressOrPlace.Parameter<string>("Address");
    throttleCoreBillingSpGetGeocodeByAddressOrPlace.Parameter<string>("City");
    throttleCoreBillingSpGetGeocodeByAddressOrPlace.Parameter<string>("State");
    throttleCoreBillingSpGetGeocodeByAddressOrPlace.Parameter<string>("Country");
    throttleCoreBillingSpGetGeocodeByAddressOrPlace.Parameter<string>("PostalCode");
    throttleCoreBillingSpGetGeocodeByAddressOrPlace.Parameter<string>("County");
    throttleCoreBillingSpGetGeocodeByAddressOrPlace.Parameter<decimal?>("GPSLatitude");
    throttleCoreBillingSpGetGeocodeByAddressOrPlace.Parameter<decimal?>("GPSLongitude");
    throttleCoreBillingSpGetGeocodeByAddressOrPlace.Parameter<string>("MapURL");
    throttleCoreBillingSpGetGeocodeByAddressOrPlace.Parameter<string>("PlaceID");
    throttleCoreBillingSpGetGeocodeByAddressOrPlace.Returns(typeof(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SpGetGeocodeByAddressOrPlaceResult));
    var throttleCoreBillingSpInsertDataFromXebra = oDataBuilderThrottle_Core_Billing.Function("SpInsertDataFromXebrasFunc");
    throttleCoreBillingSpInsertDataFromXebra.Returns(typeof(int));
    opt.AddRouteComponents("odata/Throttle_Core_Billing", oDataBuilderThrottle_Core_Billing.GetEdmModel()).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
});
builder.Services.AddScoped<ThrottleCoreCRM.Client.Throttle_Core_BillingService>();
builder.Services.AddHttpClient("ThrottleCoreCRM.Server").ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { UseCookies = false }).AddHeaderPropagation(o => o.Headers.Add("Cookie"));
builder.Services.AddHeaderPropagation(o => o.Headers.Add("Cookie"));
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddScoped<ThrottleCoreCRM.Client.SecurityService>();
builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Throttle_Core_WebSiteConnection"));
});
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<ApplicationIdentityDbContext>().AddDefaultTokenProviders();
builder.Services.AddControllers().AddOData(o =>
{
    var oDataBuilder = new ODataConventionModelBuilder();
    oDataBuilder.EntitySet<ApplicationUser>("ApplicationUsers");
    var usersType = oDataBuilder.StructuralTypes.First(x => x.ClrType == typeof(ApplicationUser));
    usersType.AddProperty(typeof(ApplicationUser).GetProperty(nameof(ApplicationUser.Password)));
    usersType.AddProperty(typeof(ApplicationUser).GetProperty(nameof(ApplicationUser.ConfirmPassword)));
    oDataBuilder.EntitySet<ApplicationRole>("ApplicationRoles");
    o.AddRouteComponents("odata/Identity", oDataBuilder.GetEdmModel()).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
});
builder.Services.AddScoped<AuthenticationStateProvider, ThrottleCoreCRM.Client.ApplicationAuthenticationStateProvider>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseHeaderPropagation();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode().AddInteractiveWebAssemblyRenderMode().AddAdditionalAssemblies(typeof(ThrottleCoreCRM.Client._Imports).Assembly);
app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationIdentityDbContext>().Database.Migrate();
app.Run();