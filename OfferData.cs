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
    class OfferData { 
        public static List<BasketModel> basket_data { get; private set; }

    public OfferData()
    {
        basket_data = new List<BasketModel>();
    }

    public List<BasketModel> AddUser()
    {
        basket_data.Add(new BasketModel()
        {
            Type = "Candy Chocolate",
            Name = "Chocolate",
            Image = Resource.Drawable.chococlate,
            OriginalPrice = "Rs.165",
            NewPrice = "Rs.155",
            Quant = 0

        });
        basket_data.Add(new BasketModel()
        {
            Type = "Caramel popcorn",
            Name = "Popcorn",
            Image = Resource.Drawable.popcorn,
            OriginalPrice = "Rs.65",
            NewPrice = "Rs.55",
            Quant = 0

        });
        basket_data.Add(new BasketModel()
        {
            Type = "Dry Fruits",
            Name = "Walnut",
            Image = Resource.Drawable.walnut,
            OriginalPrice = "Rs.265",
            NewPrice = "Rs.255",
            Quant = 0

        });
        basket_data.Add(new BasketModel()
        {
            Type = "Candy Chocolate",
            Name = "Choco Coin",
            Image = Resource.Drawable.chococoin,
            OriginalPrice = "Rs.165",
            NewPrice = "Rs.155",
            Quant = 0

        });
        basket_data.Add(new BasketModel()
        {
            Type = "Chocolate",
            Name = "Chocolate",
            Image = Resource.Drawable.chococlate,
            OriginalPrice = "Rs.165",
            NewPrice = "Rs.155",
            Quant = 0

        });
            basket_data.Add(new BasketModel()
            {
                Type = "Vegetable Basket",
                Name = "Vegetable Basket",
                Image = Resource.Drawable.image3sold,
                OriginalPrice = "Rs.155",
                NewPrice = "Rs.100",
                Quant = 0

            });

          
            return basket_data;

    }
}
}