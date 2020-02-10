using System;
using System.Collections.Generic;
namespace com.codedool.plaza.api
{
    public class ShopImpl : Shop
    {
        private string name;
        private string owner;
        private bool isOpened = false;
        private Dictionary<long, ShopImpl.ShopEntryImpl> products;

        public ShopImpl(String name, String owner)
        {
            this.name = name;
            this.owner = owner;
        }

        public void addNewProduct(Product product, int quantity, float price)
        {
            if (!isOpened)
            {
                throw new Exception("ShopIsClosedException");
            }
            if (products.ContainsKey(product.getBarcode()))
            {
                throw new Exception("ProductAlreadyExistsException");
            }
            ShopEntryImpl shopEntryImpl = new ShopEntryImpl(product, quantity, price);
            products.Add(product.getBarcode(), shopEntryImpl);
        }

        public void addProduct(long barcode, int quantity)
        {
            throw new NotImplementedException();
        }

        public Product buyProduct(long barcode)
        {
            throw new NotImplementedException();
        }

        public List<Product> buyProducts(long barcode, int quantity)
        {
            throw new NotImplementedException();
        }

        public void close()
        {
            isOpened = false;
        }

        public Product findByName(string name)
        {
            throw new NotImplementedException();
        }

        public string getName()
        {
            return name;
        }

        public string getOwner()
        {
            return owner;
        }

        public float getPrice(long barcode)
        {
            throw new NotImplementedException();
        }

        public List<Product> getProducts()
        {
            throw new NotImplementedException();
        }

        public bool hasProduct(long barcode)
        {
            throw new NotImplementedException();
        }

        public bool isOpen()
        {
            return isOpened;
        }

        public void open()
        {
            isOpened = true;
        }

        public string toString()
        {
            throw new NotImplementedException();
        }

        private class ShopEntryImpl //Inner CLASS!!!
        {
            private Product product;
            private int quantity;
            private float price;
            public ShopEntryImpl(Product product, int quantity, float price)
            {
                this.product = product;
                this.quantity = quantity;
                this.price = price;
            }
            public Product getProduct()
            {
                return product;
            }
            public void setProduct(Product product)
            {
                this.product = product;
            }
            public int getQuantity()
            {
                return quantity;
            }
            public void setQuantity(int quantity)
            {
                this.quantity = quantity;
            }
            public void increaseQuantity(int amount)
            {
                this.quantity += amount;
            }
            public void decreaseQuantity(int amount)
            {
                this.quantity -= amount;
            }
            public float getPrice()
            {
                return price;
            }
            public void setPrice(int price)
            {
                this.price = price;
            }
            public override String toString()
            {
                return product.getName() + quantity.ToString() + price.ToString();
            }
        }
        
    }
}
