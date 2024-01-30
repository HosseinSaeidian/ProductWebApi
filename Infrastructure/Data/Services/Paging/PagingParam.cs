namespace ProductWebApi.Infrastructure.Data.Services.Paging
{
    public class PagingParam
    {
        private const int _pageSize = 5;
        private const int _pageIndex = 1;


        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public PagingParam()
        {
            PageSize = _pageSize;
            PageIndex = _pageIndex;

        }
    }
}