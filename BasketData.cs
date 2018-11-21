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
    public class BasketData
    {
        public static List<BasketModel> basket_data { get; private set; }

        public BasketData()
        {
            basket_data = new List<BasketModel>();
        }

        public List<BasketModel> AddUser()
        {
            basket_data.Add(new BasketModel()
            {
                Type = "Fresho",
                Name = "Apple",
                Image = Resource.Drawable.fruit5,
                OriginalPrice = "Rs.65",
                NewPrice = "Rs.55",
                Quant = 0

            });
            basket_data.Add(new BasketModel()
            {
                Type = "Fresho",
                Name = "MixFruits",
                Image = Resource.Drawable.fruit2,
                OriginalPrice = "Rs.65",
                NewPrice = "Rs.55",
                Quant = 0

            });
            basket_data.Add(new BasketModel()
            {
                Type = "Fresho",
                Name = "Guava",
                Image = Resource.Drawable.fruit3,
                OriginalPrice = "Rs.65",
                NewPrice = "Rs.55",
                Quant = 0

            });
            basket_data.Add(new BasketModel()
            {
                Type = "Fresho",
                Name = "Grapes",
                Image = Resource.Drawable.fruit4,
                OriginalPrice = "Rs.65",
                NewPrice = "Rs.55",
                Quant = 0

            });
            basket_data.Add(new BasketModel()
            {
                Type = "Fresho",
                Name = "Mix Fruits",
                Image = Resource.Drawable.fruit,
                OriginalPrice = "Rs.65",
                NewPrice = "Rs.55",
                Quant = 0

            });
            return basket_data;

        }
    }
}