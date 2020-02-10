using System;
using System.Collections.Generic;
namespace com.codedool.plaza.api
{
    public class ShopImpl
    {
        private string name;
        private string owner;
        private Dictionary<long, ShopImpl.ShopEntryImpl> products;

        public ShopImpl(String name, String owner)
        {
        }
        private class ShopEntryImpl
        {
            private Product product;
            private int quantity;
            private float price;
            private ShopEntryImpl(Product product, int quantity, float price)
            {

            }
            public Product getProduct()
            {

            }
            public void setProduct(Product product)
            {

            }
            public int getQuantity()
            {

            }
            public void setQuantity(int quantity)
            {

            }
            public void increaseQuantity(int amount)
            {

            }
            public void decreaseQuantity(int amount)
            {

            }
            public float getPrice()
            {

            }
            public void setPrice(int price)
            {

            }
            public override String toString()
            {

            }
        }
        
    }
}
