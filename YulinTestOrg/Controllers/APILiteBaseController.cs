using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YulinTestOrg.Models.JDataTableRequestModel;

namespace YulinTestOrg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APILiteBaseController : ControllerBase
    {
        protected SearchParameters BindingSearchParam(JDataTableRequest request, Dictionary<int, string> SortColumn)
        {
            try
            {
                SearchParameters searchParameters = new SearchParameters();
                searchParameters.Index = request.Start;
                searchParameters.PageSize = request.Length;

                #region order

                if (request.Order == null || request.Order.Count() == 0)
                {
                    searchParameters.Order = OrderBehavior.DESC;
                    searchParameters.SortColumn = SortColumn[0];
                }
                else
                {
                    var o = request.Order.First();
                    searchParameters.Order = o.Dir.ToLower() == "asc" ? OrderBehavior.ASC : OrderBehavior.DESC;
                    searchParameters.SortColumn = SortColumn[0];
                    string columnName = string.IsNullOrWhiteSpace(o.ColumnName) ? "" : o.ColumnName.ToLower().Trim();

                    //--有欄位名稱優先用
                    if (SortColumn.Any(x => x.Value.ToLower() == columnName))
                    {
                        var di = SortColumn.FirstOrDefault(x => x.Value.ToLower() == columnName);
                        searchParameters.SortColumn = di.Value;
                    }
                    else if (SortColumn.Any(x => x.Key == o.Column))
                    {
                        searchParameters.SortColumn = SortColumn[o.Column];
                    }

                }

                #endregion}

                return searchParameters;
            }
            catch
            {
                throw;
            }
        }
    }
}
