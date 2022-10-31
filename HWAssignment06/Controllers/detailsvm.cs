namespace HWAssignment06.Controllers
{
    public partial class ProductsController
    {
        public class detailsvm
        {
            public int productid { get; set; }
            public int storeid { get; set; }

            public string store { get; set; }

            public int quant { get; set; }
        }
    }
}
