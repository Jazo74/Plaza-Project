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
            products = new Dictionary<long, ShopEntryImpl>();
        }

        public void AddNewProduct(Product product, int quantity, float price)
        {
            if (!isOpened)
            {
                throw new Exception("ShopIsClosedException");
            }
            if (products.ContainsKey(product.GetBarcode()))
            {
                throw new Exception("ProductAlreadyExistsException");
            }
            ShopEntryImpl shopEntryImpl = new ShopEntryImpl(product, quantity, price);
            products.Add(product.GetBarcode(), shopEntryImpl);
        }

        public void AddProduct(long barcode, int quantity)
        {
            if (!isOpened)
            {
                throw new Exception("ShopIsClosedException");
            }
            foreach (KeyValuePair< long, ShopImpl.ShopEntryImpl> item in products)
            {
                if (item.Key == barcode)
                {
                    item.Value.IncreaseQuantity(quantity);
                }
            }
            throw new Exception("NoSuchProductException");
        }

        public Product BuyProduct(long barcode)
        {
            if (!isOpened)
            {
                throw new Exception("ShopIsClosedException");
            }
            foreach (KeyValuePair<long, ShopImpl.ShopEntryImpl> item in products)
            {
                if (item.Key == barcode)
                {
                    if (item.Value.GetQuantity() < 1)
                    {
                        throw new Exception("OutOfStockException");
                    }
                    item.Value.DecreaseQuantity(1);
                    return item.Value.GetProduct();
                }
            }
            throw new Exception("NoSuchProductException");
        }

        public List<Product> BuyProducts(long barcode, int quantity)
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
                    if (item.Value.GetQuantity() < quantity)
                    {
                        throw new Exception("OutOfStockException");
                    }
                    item.Value.DecreaseQuantity(quantity);
                    for (int count = 0; count < quantity; count++)
                    {
                        productList.Add(item.Value.GetProduct()); 
                    }
                    
                    return productList;
                }
            }
            throw new Exception("NoSuchProductException");
        }

        public void Close()
        {
            isOpened = false;
        }

        public Product FindByName(string name)
        {
            if (!isOpened)
            {
                throw new Exception("ShopIsClosedException");
            }
            foreach (KeyValuePair<long, ShopImpl.ShopEntryImpl> item in products)
            {
                if (item.Value.GetProduct().GetName() == name)
                {
                    return item.Value.GetProduct();
                }
            }
            throw new Exception("NoSuchProductException");
        }

        public string GetName()
        {
            return name;
        }

        public string GetOwner()
        {
            return owner;
        }

        public float GetPrice(long barcode)
        {
            if (!isOpened)
            {
                throw new Exception("ShopIsClosedException");
            }
            foreach (KeyValuePair<long, ShopImpl.ShopEntryImpl> item in products)
            {
                if (item.Key == barcode)
                {
                    return item.Value.GetPrice();
                }
            }
            throw new Exception("NoSuchProductException");
        }

        public List<Product> GetProducts()
        {
            if (!isOpened)
            {
                throw new Exception("ShopIsClosedException");
            }
            List<Product> productList = new List<Product>();
            foreach (KeyValuePair<long, ShopImpl.ShopEntryImpl> item in products)
            {
                for (int quantity = 0;  quantity < item.Value.GetQuantity(); quantity++)
                {
                    productList.Add(item.Value.GetProduct());
                }
            }
            return productList;
        }

        public bool HasProduct(long barcode)
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

        public bool IsOpen()
        {
            return isOpened;
        }

        public void Open()
        {
            isOpened = true;
        }

        public override string ToString()
        {
            return "Name: " + name + " Owner: " + owner + " Open: " + isOpened.ToString() + " Count: " + products.Count.ToString();
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
            public Product GetProduct()
            {
                return product;
            }
            public void SetProduct(Product product)
            {
                this.product = product;
            }
            public int GetQuantity()
            {
                return quantity;
            }
            public void SetQuantity(int quantity)
            {
                this.quantity = quantity;
            }
            public void IncreaseQuantity(int amount)
            {
                this.quantity += amount;
            }
            public void DecreaseQuantity(int amount)
            {
                this.quantity -= amount;
            }
            public float GetPrice()
            {
                return price;
            }
            public void SetPrice(int price)
            {
                this.price = price;
            }
            public override string ToString()
            {
                return product.GetName() + quantity.ToString() + price.ToString();
            }
        }
        
    }
}
