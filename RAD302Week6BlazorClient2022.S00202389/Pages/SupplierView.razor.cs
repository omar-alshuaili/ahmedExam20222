using DataModel;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RAD302Week6BlazorClient2022.S00202389.Pages
{
    public partial class SupplierView
    {
        [Inject]
        HttpClient Http { get; set; }



        private Supplier[] suppliers;
        private Product[] products;



        protected override async Task OnInitializedAsync()
        {
            //Loadong for the first time
            if (SupplierStaticContext.Suppliers == null)
            {
                SupplierStaticContext.Suppliers =
                suppliers = await Http.GetFromJsonAsync<Supplier[]>("sample-data/Supplier.json");
                SupplierStaticContext.Products =
                products = await Http.GetFromJsonAsync<Product[]>("sample-data/Product.json");
                InitialiseSupplierProducts();
            }
            else
            {
                //we are reloading the page
                suppliers = SupplierStaticContext.Suppliers;
            }
            await base.OnInitializedAsync();
        }
        private void InitialiseSupplierProducts()
        {
            foreach (var item in suppliers)
            {
                List<Product> toadd = products.OrderBy(o => new Random().Next(2372)).Take(3).ToList();
                item.SupplierProducts = new List<Product>();
                item.SupplierProducts.AddRange(toadd);
            }
        }
    }
}
