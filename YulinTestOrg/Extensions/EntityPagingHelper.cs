namespace YulinTestOrg.Extensions
{
    public static class EntityPagingHelper<T>
    {
        public static IQueryable<T> Paging(IQueryable<T> listSource, int? length, int? index)
        {
            try
            {
                if (length != null && index != null)
                {
                    if (length > 1000)
                    {
                        throw new ValidateException("單頁限制不可超過一千筆！");
                    }

                    //--考慮到 db 承受能力，就算給 -1 最多也就給 1000
                    length = length > 0 ? length : 1000;

                    return listSource.Skip((int)index).Take((int)length);
                }
                else
                {
                    return listSource.Take(1000);
                }
            }
            catch
            {
                throw;
            }
        }

        public static List<T> Paging(List<T> listSource, int? length, int? index)
        {
            try
            {
                if (length != null && index != null)
                {
                    if (length > 1000)
                    {
                        throw new ValidateException("單頁限制不可超過一千筆！");
                    }

                    //--考慮到 db 承受能力，就算給 -1 最多也就給 1000
                    length = length > 0 ? length : 1000;

                    return listSource.Skip((int)index).Take((int)length).ToList<T>();
                }
                else
                {
                    return listSource.Take(1000).ToList();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
