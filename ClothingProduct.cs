using System;
namespace com.codedool.plaza.api
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
        
        public override long getBarcode()
        {
            return barcode;
        }

        public override string getName()
        {
            return name;
        }

        public override string getManufacturer()
        {
            return manufacturer;
        }
        public override string toString()
        {
            return "BC:" + barcode.ToString() + " N:" + name + " M:" + manufacturer + " Mat:" + material + " T:" + type;
        }
    }
}
