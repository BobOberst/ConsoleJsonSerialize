using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleJsonSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product
            {
                Name = "Product 1",
                Price = 99.95m,
                ExpiryDate = new DateTime(2000, 12, 29, 0, 0, 0, DateTimeKind.Utc),
            };
            Product p2 = new Product
            {
                Name = "Product 2",
                Price = 12.50m,
                ExpiryDate = new DateTime(2009, 7, 31, 0, 0, 0, DateTimeKind.Utc),
            };

            List<Product> products = new List<Product>();
            products.Add(p1);
            products.Add(p2);

            const string PRODUCT_DATA = "Products.json";

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);   //convert to json

            Console.WriteLine(json);                                                    

            File.WriteAllText(PRODUCT_DATA, json);                                      //write to json file

            json = "";                                                                  //clear json data

            products.Clear();                                                           //clear list of products

            Console.WriteLine($"Products found: {products.Count}");

            json = File.ReadAllText(PRODUCT_DATA);                                      //read from json file

            products = JsonConvert.DeserializeObject<List<Product>>(json);              //convert json products

            Console.WriteLine($"Products found: {products.Count}");

            Console.WriteLine(json);

            Console.ReadLine();
        }
    }
}
