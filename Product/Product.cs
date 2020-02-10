using System;
namespace com.codedool.plaza.api
{
    public abstract class Product
    {
        protected long barcode { get; set; }
        protected String name { get; set; }
        protected String manufacturer { get; set; }
        protected Product(long barcode, String name, String manufacturer)
        {
            this.barcode = barcode;
            this.name = name;
            this.manufacturer = manufacturer;
        }
        public abstract long GetBarcode();
        public abstract string GetName();
        public abstract string GetManufacturer();
        public abstract override string ToString();
    }
}
