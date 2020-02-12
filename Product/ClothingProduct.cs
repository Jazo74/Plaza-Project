using System;
namespace com.codecool.plaza.api
{
    public class ClothingProduct : Product
    {
        private string material;
        private string type;

        public ClothingProduct(long barcode, string name, string manufacturer, string material, string type) : base(barcode, name, manufacturer)
        {
            this.material = material;
            this.type = type;
        }
        public string getMaterial()
        {
            return material;
        }
        public string getType()
        {
            return type;
        }
        
        public override long GetBarcode()
        {
            return barcode;
        }

        public override string GetName()
        {
            return name;
        }

        public override string GetManufacturer()
        {
            return manufacturer;
        }
        public override string ToString()
        {
            return "Barcode:" + barcode.ToString() + ", Name:" + name + ", Manufacturer:" + manufacturer + ", Material:" + material + ", Type:" + type;
        }
    }
}
