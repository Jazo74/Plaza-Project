using System;
using System.Collections.Generic;
namespace com.codedool.plaza.api
{
    public interface Plaza
    {
        public List<Shop> getShops(); //throws PlazaIsClosedException
        public void addShop(Shop shop); //throws ShopAlreadyExistsException, PlazaIsClosedException
        public void removeShop(Shop shop); //throws NoSuchShopException, PlazaIsClosedException
        public Shop findShopByName(String name); //throws NoSuchShopException, PlazaIsClosedException
        public bool isOpen();
        public void open();
        public void close();
        public string toString();
    }
}
