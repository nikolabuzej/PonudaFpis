﻿using Core.ListView.Ponuda;

namespace Core.ListView
{
    public enum SortOrder { asc, desc }
    public class PaginationParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public SortOrder SortOrder { get; set; } = SortOrder.asc;
        public SortProperty SortProperty { get; set; } = SortProperty.DatumPristizanja;
        public string SearchText { get; set; } = string.Empty;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
