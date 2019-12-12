using System;

namespace DynamicDataExtensions.Attributes.Enums
{
    //[Flags]
    //public enum FilterAction
    //{
    //    /// <summary>
    //    /// Filter is never generated if not enabled.
    //    /// </summary>
    //    Enabled = 0x1,
    //    /// <summary>
    //    /// Hide Filter on page even if enabled.
    //    /// </summary>
    //    Hidden = 0x2,
    //    /// <summary>
    //    /// Show Filter but disable even it if enabled.
    //    /// </summary>
    //    Disabled = 0x4,
    //    /// <summary>
    //    /// Set Default value if enabled
    //    /// </summary>
    //    AutoDefault = 0x8,
    //}

    /// <summary>
    /// Actions a Column can 
    /// have assigned to itself.
    /// </summary>
    [Flags]
    public enum ColumnActions
    {
        /// <summary>
        /// Action on a column/property
        /// </summary>
        DenyRead = 1,
        /// <summary>
        /// Action on a column/property
        /// </summary>
        DenyWrite = 2,
    }

    /// <summary>
    /// Table permissions enum, allows different 
    /// levels of permission to be set for each 
    /// table on a per role bassis.
    /// </summary>
    [Flags]
    public enum TableActions
    {
        /// <summary>
        /// Default no permissions
        /// </summary>
        None = 0x00,
        /// <summary>
        /// Details page
        /// </summary>
        Details = 0x01,
        /// <summary>
        /// List page
        /// </summary>
        List = 0x02,
        /// <summary>
        /// Edit page
        /// </summary>
        Edit = 0x04,
        /// <summary>
        /// Insert page
        /// </summary>
        Insert = 0x08,
        /// <summary>
        /// Delete operations
        /// </summary>
        Delete = 0x10,
    }

    /// <summary>
    /// Combines Table permissions enums
    /// into logical security groups
    /// i.e. ReadOnly combines TableActions
    /// Details and List
    /// </summary>
    public static class CombinedActions
    {
        /// <summary>
        /// Read Only access 
        /// TableActions.Details or 
        /// TableActions.List
        /// </summary>
        public const TableActions ReadOnly = 
            TableActions.Details | 
            TableActions.List;
        /// <summary>
        /// Read and Write access 
        /// TableActions.Details or 
        /// TableActions.List or
        /// TableActions.Edit
        /// </summary>
        public const TableActions ReadWrite = 
            TableActions.Details | 
            TableActions.List | 
            TableActions.Edit;
        /// <summary>
        /// Read Insert access 
        /// TableActions.Details or 
        /// TableActions.List or 
        /// TableActions.Insert
        /// 
        /// </summary>
        public const TableActions ReadInsert = 
            TableActions.Details | 
            TableActions.List | 
            TableActions.Insert;
        /// <summary>
        /// Read Insert and Delete access 
        /// TableActions.Details or 
        /// TableActions.List or 
        /// TableActions.Insert or 
        /// TableActions.Delete)
        /// </summary>
        public const TableActions ReadInsertDelete = 
            TableActions.Details | 
            TableActions.List | 
            TableActions.Insert | 
            TableActions.Delete;
        /// <summary>
        /// Read and Write access 
        /// TableActions.Details or 
        /// TableActions.List or 
        /// TableActions.Edit or 
        /// TableActions.Insert)
        /// </summary>
        public const TableActions ReadWriteInsert = 
            TableActions.Details | 
            TableActions.List | 
            TableActions.Edit | 
            TableActions.Insert;
        /// <summary>
        /// Full access 
        /// TableActions.Delete or
        /// TableActions.Details or 
        /// TableActions.Edit or 
        /// TableActions.Insert or 
        /// TableActions.List)
        /// </summary>
        public const TableActions Full = 
            TableActions.Delete | 
            TableActions.Details | 
            TableActions.Edit | 
            TableActions.Insert | 
            TableActions.List;
    }
}