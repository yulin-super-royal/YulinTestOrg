namespace YulinTestOrg.Models.JDataTableRequestModel
{
    /// <summary>
    ///     JDataTable回應
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JDataTableResponse<T>
    {
        /// <summary>
        ///     不明
        /// </summary>
        public int Draw { get; set; }

        /// <summary>
        ///     總筆數
        /// </summary>
        public int RecordsTotal { get; set; }

        /// <summary>
        ///     不明
        /// </summary>
        public int RecordsFiltered { get; set; }

        /// <summary>
        ///     資料內容
        /// </summary>
        public List<T> Data { get; set; }

        /// <summary>
        ///     建構子
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="data"></param>
        /// <param name="total"></param>
        public JDataTableResponse(int draw
                                , List<T> data
                                , int total)
        {
            this.Draw = draw;
            this.Data = data;
            this.RecordsTotal = total;
            this.RecordsFiltered = total;
        }
    }
}
