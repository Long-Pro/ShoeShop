using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.InputModel
{
    public class ShoeFilter
    {
        public string? q { get; set; }
        public string? sort { get; set; }
        public int? priceStart { get; set; }
        public int? priceEnd { get; set; }
        public int? brandId { get; set; }
        public int page { get; set; }

        public ShoeFilter()
        {
            page = 1;
        }
    }
}
