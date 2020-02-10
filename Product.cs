using System;
namespace com.codedool.plaza.api
{
    public abstract class Product
    {
        protected Product(long barcode, String name, String manufacturer)
        {
        }
        protected long barcode;
        protected String name;
        protected String manufacturer;
        public abstract long getBarcode();
        public abstract string getName();
        public abstract string getManufacturer();
        public abstract string toString();
    }
}
