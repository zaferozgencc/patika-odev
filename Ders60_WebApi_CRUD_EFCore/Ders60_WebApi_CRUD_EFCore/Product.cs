using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ders60_WebApi_CRUD_EFCore
{
    public class Product
    {
        public int ID { get; set; }
        public string UrunAdi { get; set; } = string.Empty;
        public decimal Fiyat { get; set; }
        public int Stok { get; set; }

    }
}
