using System;
using System.Collections.Generic;
namespace com.codedool.plaza.api
{
    public class PlazaImpl : Plaza
    {
        private List<Shop> shops;
        public string name { get; }
        bool isOpened = false;
        public PlazaImpl(string name)
        {
            this.name = name;
        }

        public List<Shop> getShops()
        {
            if (!isOpened)
            {
                throw new Exception("PlazaIsClosedException");
            }
            return shops;
        }

        public void addShop(Shop shop)
        {
            if (!isOpened)
            {
                throw new Exception("PlazaIsClosedException");
            }
            shops.Add(shop);
        }

        public void removeShop(Shop shop)
        {
            if (!isOpened)
            {
                throw new Exception("PlazaIsClosedException");
            }
            for (int index = shops.Count-1; index >= 0; index--)
            {
                if (shops[index] == shop)
                {
                    shops.RemoveAt(index);
                }
            }
            throw new Exception("NoSuchShopException");
        }

        public Shop findShopByName(string name)
        {
            if (!isOpened)
            {
                throw new Exception("PlazaIsClosedException");
            }
            foreach (Shop shop in shops)
            {
                if (shop.getName() == name)
                {
                    return shop;
                }
            }
            throw new Exception("NoSuchShopException");
        }

        public bool isOpen()
        {
            return isOpened;
        }

        public void open()
        {
            isOpened = true;
        }

        public void close()
        {
            isOpened = false;
        }

        public string toString()
        {
            string status = isOpened.ToString() + " - " + shops.Count.ToString();
            return status;
        }
    }
}
