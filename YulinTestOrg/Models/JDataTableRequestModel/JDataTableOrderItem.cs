namespace YulinTestOrg.Models.JDataTableRequestModel
{
    /// <summary>
    ///     控端前端的JqueryDataTable Order 模板
    /// </summary>
    public class JDataTableOrderItem
    {
        /// <summary>
        ///     排序欄位(對應前端的JDataTable)
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        ///     不明
        /// </summary>
        public string Dir { get; set; }

        /// <summary>
        ///     欄位的名稱(資料表的)
        /// </summary>
        public string ColumnName { get; set; }
    }
}
