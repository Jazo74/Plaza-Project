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
            if (!isOpened)
            {
                throw new Exception("ShopIsClosedException");
            }
            foreach (KeyValuePair< long, ShopImpl.ShopEntryImpl> item in products)
            {
                if (item.Key == barcode)
                {
                    item.Value.increaseQuantity(quantity);
                }
            }
            throw new Exception("NoSuchProductException");
        }

        public Product buyProduct(long barcode)
        {
            if (!isOpened)
            {
                throw new Exception("ShopIsClosedException");
            }
            foreach (KeyValuePair<long, ShopImpl.ShopEntryImpl> item in products)
            {
                if (item.Key == barcode)
                {
                    if (item.Value.getQuantity() < 1)
                    {
                        throw new Exception("OutOfStockException");
                    }
                    item.Value.decreaseQuantity(1);
                    return item.Value.getProduct();
                }
            }
            throw new Exception("NoSuchProductException");
        }

        public List<Product> buyProducts(long barcode, int quantity)
        {
            List<Product> productList = new List<Product>();
            if (!isOpened)
            {
                throw new Exception("ShopIsClosedException");
            }
            foreach (KeyValuePair<long, ShopImpl.ShopEntryImpl> item in products)
            {
                if (item.Key == barcode)
                {
                    if (item.Value.getQuantity() < quantity)
                    {
                        throw new Exception("OutOfStockException");
                    }
                    item.Value.decreaseQuantity(quantity);
                    for (int count = 0; count < quantity; count++)
                    {
                        productList.Add(item.Value.getProduct()); 
                    }
                    
                    return productList;
                }
            }
            throw new Exception("NoSuchProductException");
        }

        public void close()
        {
            isOpened = false;
        }

        public Product findByName(string name)
        {
            if (!isOpened)
            {
                throw new Exception("ShopIsClosedException");
            }
            foreach (KeyValuePair<long, ShopImpl.ShopEntryImpl> item in products)
            {
                if (item.Value.getProduct().getName() == name)
                {
                    return item.Value.getProduct();
                }
            }
            throw new Exception("NoSuchProductException");
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
            if (!isOpened)
            {
                throw new Exception("ShopIsClosedException");
            }
            foreach (KeyValuePair<long, ShopImpl.ShopEntryImpl> item in products)
            {
                if (item.Key == barcode)
                {
                    return item.Value.getPrice();
                }
            }
            throw new Exception("NoSuchProductException");
        }

        public List<Product> getProducts()
        {
            if (!isOpened)
            {
                throw new Exception("ShopIsClosedException");
            }
            List<Product> productList = new List<Product>();
            foreach (KeyValuePair<long, ShopImpl.ShopEntryImpl> item in products)
            {
                for (int quantity = 0;  quantity < item.Value.getQuantity(); quantity++)
                {
                    productList.Add(item.Value.getProduct());
                }
            }
            return productList;
        }

        public bool hasProduct(long barcode)
        {
            if (!isOpened)
            {
                throw new Exception("ShopIsClosedException");
            }
            if (products.ContainsKey(barcode))
            {
                return true;
            }
            return false;
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
            return "N: " + name + " O: " + owner + " Open: " + isOpened.ToString() + " Count: " + products.Count.ToString();
        }

        private class ShopEntryImpl //Inner CLASS!!!
        {
            private Product product;
            private int quantity;
            private float price;
            internal ShopEntryImpl(Product product, int quantity, float price)
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
            public override string ToString()
            {
                return product.getName() + quantity.ToString() + price.ToString();
            }
        }
        
    }
}
