using System;

namespace com.codedool.plaza.api
{
    public class FoodProduct : Product
    {
        private int calories { get; }
        private DateTime bestBefore { get; }

        public FoodProduct(long barcode, string name, string manufacturer, int calories, DateTime bestBefore) : base(barcode, name, manufacturer)
        {
            this.calories = calories;
            this.bestBefore = bestBefore;
        }
        public bool isStillConsumable()
        {
            if (DateTime.Now.Date < bestBefore)
            {
                return true;
            }
            return false;
        }
        public int getCalories()
        {
            return calories;
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
            return "BC:" + barcode.ToString() + " N:" + name + " M:" + manufacturer + " C:" + calories.ToString() + " BB:" + bestBefore.ToString();
        }
    }
}
