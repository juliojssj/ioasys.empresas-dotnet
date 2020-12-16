﻿using System.Collections.Generic;

namespace Ioasys.Domain.Shared.Filters
{
    public class GenericFilter<T>
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }

        public List<T> Items { get; set; }
    }
}
