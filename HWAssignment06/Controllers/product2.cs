using System.Collections.Generic;

namespace HWAssignment06.Controllers
{
    public partial class ProductsController
    {
        public class product2
        {
            public int id { get; set; }
            public string ProductName { get; set; }
            public int ModelYear { get; set; }

            public int categoryID { get; set; }

            public int brandID { get; set; }
            public decimal ListPrice { get; set; }

            public string BrandName { get; set; }

            public string CategoryName { get; set; }

            public List<detailsvm> detailsvms = new List<detailsvm>();

        }
    }
}
