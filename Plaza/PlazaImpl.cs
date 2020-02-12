using System;
using System.Collections.Generic;
namespace com.codecool.plaza.api
{
    public class PlazaImpl : Plaza
    {
        private List<Shop> shops = new List<Shop>();
        public string name { get; }
        bool isOpened = false;
        public PlazaImpl(string name)
        {
            this.name = name;
        }

        public List<Shop> GetShops()
        {
            if (!isOpened)
            {
                throw new PlazaIsClosedException();
            }
            return shops;
        }

        public void AddShop(Shop shop)
        {
            if (!isOpened)
            {
                throw new PlazaIsClosedException();
            }
            shops.Add(shop);
        }

        public void RemoveShop(Shop shop)
        {
            bool found = false;
            if (!isOpened)
            {
                throw new PlazaIsClosedException();
            }
            for (int index = shops.Count-1; index >= 0; index--)
            {
                if (shops[index] == shop)
                {
                    shops.RemoveAt(index);
                    found = true;
                }
            }
            if (!found) { throw new NoSuchShopException(); }
        }

        public Shop FindShopByName(string name)
        {
            if (!isOpened)
            {
                throw new PlazaIsClosedException();
            }
            foreach (Shop shop in shops)
            {
                if (shop.GetName() == name)
                {
                    return shop;
                }
            }
            throw new NoSuchShopException();
        }

        public bool IsOpen()
        {
            return isOpened;
        }

        public void Open()
        {
            isOpened = true;
        }

        public void Close()
        {
            isOpened = false;
        }

        public override string ToString()
        {
            string status = isOpened.ToString() + " - " + shops.Count.ToString();
            return status;
        }
    }
}
