using System;
using System.Collections.Generic;
namespace com.codedool.plaza.api
{
    public interface Shop
    {
        public string getName();
        public string getOwner();
        public bool isOpen();
        public void open();
        public void close();
        public List<Product> getProducts(); //throws ShopIsClosedException
        public Product findByName(string name); //throws NoSuchProductException, ShopIsClosedException
        public float getPrice(long barcode); //throws NoSuchProductException, ShopIsClosedException
        public bool hasProduct(long barcode); //throws ShopIsClosedException
        public void addNewProduct(Product product, int quantity, float price); //throws ProductAlreadyExistsException, ShopIsClosedException
        public void addProduct(long barcode, int quantity); //throws NoSuchProductException, ShopIsClosedException
        public Product buyProduct(long barcode); //throws NoSuchProductException, OutOfStockException, ShopIsClosedException
        public List<Product> buyProducts(long barcode, int quantity); //throws NoSuchProductException, OutOfStockException, ShopIsClosedException
        public string toString();
    }
}
