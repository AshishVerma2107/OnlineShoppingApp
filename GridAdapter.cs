using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BasketApp.Model;

namespace BasketApp
{
    class GridAdapter: BaseAdapter<GridModel>
    {
        private Context c;
        private List<GridModel> fruits;
        private LayoutInflater inflater;

        public GridAdapter(List<GridModel> fruits, Context c)
        {
            this.fruits = fruits;
            this.c = c;
        }

        public override GridModel this[int position]
        {
            get
            {
                return fruits[position];
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var local = new LocalOnClickListener();
            if (inflater == null)
            {
                inflater = (LayoutInflater)c.GetSystemService(Context.LayoutInflaterService);
            }

            if (convertView == null)
            {
                convertView = inflater.Inflate(Resource.Layout.GridChild, parent, false);
            }

            TextView nameTxt = convertView.FindViewById<TextView>(Resource.Id.nameTxt);
            //ImageView img = convertView.FindViewById<ImageView>(Resource.Id.imageView1);
            nameTxt.SetOnClickListener(local);
            nameTxt.SetTextColor(Color.LightGray);
            nameTxt.Text = fruits[position].Name;
            //if (MainFragment.registered)
            //{

            //}
            //else
            //{
            //    nameTxt.SetTextColor(Color.DarkGray);
            //}
            // img.SetImageResource(fruits[position].Image);

            local.HandleOnClick = () =>
            {
                    card_click(fruits[position].Name);
                
            };
    //        int[] thumbIds = {
    //    Resource.Drawable.,
    //    Resource.Drawable.sample_2,
    //    Resource.Drawable.sample_3,
    //    Resource.Drawable.sample_4,
    //    Resource.Drawable.sample_1,
    //    Resource.Drawable.sample_2,
    //};

            return convertView;
        }

        public override int Count
        {
            get { return fruits.Count(); }
        }

        public void card_click(string card_name)
        {
            if (card_name.Equals(" PayTm "))
            {
                Intent i = new Intent(c, typeof(TermsConditons));
                c.StartActivity(i);
            }
            if (card_name.Equals("CITI Bank"))
            {
                Intent i = new Intent(c, typeof(TermsConditons));
                c.StartActivity(i);
            }
            if (card_name.Equals("Simple"))
            {
                Intent i = new Intent(c, typeof(TermsConditons));
                // i.SetFlags(ActivityFlags.NewTask);
                c.StartActivity(i);

            }
            if (card_name.Equals("Kotak"))
            {
                Intent i = new Intent(c, typeof(TermsConditons));
                c.StartActivity(i);

            }
            if (card_name.Equals("MobiKwik"))
            {
                Intent i = new Intent(c, typeof(TermsConditons));
                c.StartActivity(i);

            }
            if (card_name.Equals("PayZAPP"))
            {
                Intent i = new Intent(c, typeof(TermsConditons));
                //i.PutExtra("npid", MainFragment.npid);
                //i.PutExtra("patient_name", MainFragment.name.Text);
                //i.PutExtra("patient_number", MainFragment.mobile.Text);
                c.StartActivity(i);
            }
        }

        public class LocalOnClickListener : Java.Lang.Object, View.IOnClickListener
        {
            public void OnClick(View v)
            {
                HandleOnClick();
            }
            public System.Action HandleOnClick { get; set; }
        }

    }
    }
