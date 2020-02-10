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
        }
        
        public abstract long getBarcode();
        public abstract string getName();
        public abstract string getManufacturer();
        public abstract string toString();
    }
}
