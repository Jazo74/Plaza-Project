using System;
using System.Collections.Generic;
namespace com.codecool.plaza.api
{
    public interface Shop
    {
        public string GetName();
        public string GetOwner();
        public bool IsOpen();
        public void Open();
        public void Close();
        public List<Product> GetProducts(); //throws ShopIsClosedException
        public Product FindByName(string name); //throws NoSuchProductException, ShopIsClosedException
        public float GetPrice(long barcode); //throws NoSuchProductException, ShopIsClosedException
        public bool HasProduct(long barcode); //throws ShopIsClosedException
        public void AddNewProduct(Product product, int quantity, float price); //throws ProductAlreadyExistsException, ShopIsClosedException
        public void AddProduct(long barcode, int quantity); //throws NoSuchProductException, ShopIsClosedException
        public Product BuyProduct(long barcode); //throws NoSuchProductException, OutOfStockException, ShopIsClosedException
        public List<Product> BuyProducts(long barcode, int quantity); //throws NoSuchProductException, OutOfStockException, ShopIsClosedException
        public string ToString();
    }
}

