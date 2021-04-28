using System;

namespace GS1US.Framework.Common.Logging.Models
{
    /// <summary>
    ///     This <see langword="enum" /> matches the categories defined in our logging configuration.
    ///     Multiple categories can be assigned to log messages.
    /// </summary>
    [Flags]
    public enum LogCategories
    {
        /// <summary>
        ///     The general category
        /// </summary>
        General = 1,

        /// <summary>
        ///     The data access category
        /// </summary>
        DataAccess = 2,

        /// <summary>
        ///     The order invoice processing category
        /// </summary>
        OrderInvoiceProcessing = 4,

        /// <summary>
        ///     The email processing category
        /// </summary>
        EmailProcessing = 8,

        /// <summary>
        ///     The order termination processing category
        /// </summary>
        OrderTerminationProcessing = 16,

        /// <summary>
        ///     The order renewal processing category
        /// </summary>
        OrderRenewalProcessing = 32,

        /// <summary>
        ///     The recurring invoice email / renewal open billing sales order category
        /// </summary>
        OrderRecurringInvoiceProcessing = 64,

        /// <summary>
        ///     For when Sync Engine is syncing to CE
        /// </summary>
        SyncToFO = 128,

        /// <summary>
        ///     For when Sync Engine is syncing to F&amp;O
        /// </summary>
        SyncToCE = 256,

        /// <summary>
        ///     The GS1 US Access Control system
        /// </summary>
        AccessControl = 512,

        /// <summary>
        ///     The GS1 Data Hub system
        /// </summary>
        DataHub = 1024,

        /// <summary>
        ///     The GS1 Claims Mapper system
        /// </summary>
        ClaimsMapper = 2048,

        /// <summary>
        ///     The GoToWebinar SSAS system
        /// </summary>
        GoToWebinar = 4096,

        /// <summary>
        ///     The API Management system
        /// </summary>
        APIManagement = 8192,

        /// <summary>
        ///     Past-due order processing 
        /// </summary>
        OrderPastDueProcessing = 16384
    }
}
