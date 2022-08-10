namespace YulinTestOrg.Models.JDataTableRequestModel
{
    /// <summary>
    ///     頁面的搜尋設定
    /// </summary>
    public class SearchParameters
    {
        private int? _pageSize;

        /// <summary>
        /// 每一頁幾筆
        /// </summary>
        public int PageSize
        {
            get
            {
                if (_pageSize == null)
                {
                    return int.MaxValue;
                }

                return _pageSize.Value;
            }

            set => _pageSize = value;
        }

        /// <summary>
        /// 起始 index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 排序方式
        /// </summary>
        public OrderBehavior Order { get; set; }

        /// <summary>
        /// 排序的欄位
        /// </summary>
        public string SortColumn { get; set; }

        /// <summary>
        /// 總筆數
        /// </summary>
        public int Total { get; set; }
    }

    /// <summary>
    /// 排序方式
    /// </summary>
    public enum OrderBehavior
    {
        DESC = 0
      , ASC
    };
}
