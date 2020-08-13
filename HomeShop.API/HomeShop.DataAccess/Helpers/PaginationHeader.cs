namespace HomeShop.DataAccess.Helpers
{
    class PaginationHeader
    {
        public int CurrentPage { get; set; }
        public int ItemPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }

        public PaginationHeader(int currentPage, int itemPrePage, int totalItems, int totalPage)
        {
            this.CurrentPage = currentPage;
            this.ItemPerPage = itemPrePage;
            this.TotalItems = totalItems;
            this.TotalPages = totalPage;
        }

    }
}
