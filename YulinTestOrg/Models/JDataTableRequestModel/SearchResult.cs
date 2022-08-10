namespace YulinTestOrg.Models.JDataTableRequestModel
{
    public class SearchResult<T> where T : class
    {
        /// <summary>
        /// 總筆數
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 目標資料
        /// </summary>
        public List<T> ListData { get; set; }
    }
}
