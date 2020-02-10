using System;
using System.Collections.Generic;
namespace com.codedool.plaza.api
{
    public interface Plaza
    {
        public List<Shop> GetShops(); //throws PlazaIsClosedException
        public void AddShop(Shop shop); //throws ShopAlreadyExistsException, PlazaIsClosedException
        public void RemoveShop(Shop shop); //throws NoSuchShopException, PlazaIsClosedException
        public Shop FindShopByName(String name); //throws NoSuchShopException, PlazaIsClosedException
        public bool IsOpen();
        public void Open();
        public void Close();
        public string ToString();
    }
}
