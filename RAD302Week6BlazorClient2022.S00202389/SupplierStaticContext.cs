using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAD302Week6BlazorClient2022.S00202389
{
    public class SupplierStaticContext
    {
        public static Supplier CurrentSupplier { get; set; }
        public static Product[] Products { get; set; }
        public static Supplier[] Suppliers { get; set; }



        public static Supplier GetNewSupplier(int supplierID)
        {
            return CurrentSupplier = Suppliers.FirstOrDefault(s => s.SupplierID == supplierID);
        }
    }
}
