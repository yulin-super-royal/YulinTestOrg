namespace YulinTestOrg.Models.JDataTableRequestModel
{
    /// <summary>
    ///     控端前端的JqueryDataTable模板
    /// </summary>
    public class JDataTableRequest
    {
        /// <summary>
        ///     不明
        /// </summary>
        public int Draw { get; set; }

        /// <summary>
        ///     開始筆數
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        ///     取得筆數
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        ///     排序設定
        /// </summary>
        public List<JDataTableOrderItem> Order { get; set; }
    }
}
