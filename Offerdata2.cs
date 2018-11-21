using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BasketApp.Model;

namespace BasketApp
{
    class OfferData2
    {
        public static List<BasketModel> basket_data { get; private set; }

        public OfferData2()
        {
            basket_data = new List<BasketModel>();
        }

        public List<BasketModel> AddUser()
        {
            basket_data.Add(new BasketModel()
            {
                Type = "Foot Wear",
                Name = "FootWear",
                Image = Resource.Drawable.product1,
                OriginalPrice = "Rs.205",
                NewPrice = "Rs.120",
                Quant = 0

            });

            basket_data.Add(new BasketModel()
            {
                Type = "Web Camera",
                Name = "webcamera",
                Image = Resource.Drawable.product11,
                OriginalPrice = "Rs.2999",
                NewPrice = "Rs.1799",
                Quant = 0

            });

            basket_data.Add(new BasketModel()
            {
                Type = "Telescope",
                Name = "Telescope",
                Image = Resource.Drawable.product13,
                OriginalPrice = "Rs.1599",
                NewPrice = "Rs.799",
                Quant = 0

            });

            basket_data.Add(new BasketModel()
            {
                Type = "Puma Sport Shoes",
                Name = "Sport Shoes",
                Image = Resource.Drawable.product7,
                OriginalPrice = "Rs.999",
                NewPrice = "Rs.499",
                Quant = 0

            });
            basket_data.Add(new BasketModel()
            {
                Type = "IPhone X",
                Name = "IphoneX",
                Image = Resource.Drawable.product6,
                OriginalPrice = "Rs.65900",
                NewPrice = "Rs.45999",
                Quant = 0

            });
            basket_data.Add(new BasketModel()
            {
                Type = "Blue Tooth Ear Phone",
                Name = "Full Bass Ear Phone",
                Image = Resource.Drawable.product8,
                OriginalPrice = "Rs.799",
                NewPrice = "Rs.349",
                Quant = 0

            });
            basket_data.Add(new BasketModel()
            {
                Type = "Asus Laptop",
                Name = "AsusLaptop",
                Image = Resource.Drawable.product5,
                OriginalPrice = "Rs.39999",
                NewPrice = "Rs.24499",
                Quant = 0

            });
            basket_data.Add(new BasketModel()
            {
                Type = "Vegetable Basket",
                Name = "Vegetable Basket",
                Image = Resource.Drawable.image3sold,
                OriginalPrice = "Rs.1599",
                NewPrice = "Rs.799",
                Quant = 0

            });

            basket_data.Add(new BasketModel()
            {
                Type = "Tool Kit",
                Name = "Tool Kit",
                Image = Resource.Drawable.product9,
                OriginalPrice = "Rs.499",
                NewPrice = "Rs.199",
                Quant = 0

            });
           

            basket_data.Add(new BasketModel()
            {
                Type = "Combo",
                Name = "Masala Combo",
                Image = Resource.Drawable.product10,
                OriginalPrice = "Rs.299",
                NewPrice = "Rs.149",
                Quant = 0

            });
            return basket_data;

        }
    }
}