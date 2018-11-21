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
using BasketApp;
using BasketApp.Fragments;
using BasketApp.Model;
using Java.Lang;
using Object = Java.Lang.Object;



namespace BasketApp
{
    public class CategoryAdapter : BaseAdapter<BasketModel>, IFilterable
    {
        Context context;
        public List<BasketModel> MatchItem;
        public List<BasketModel> AllItem;
        string[] items = new string[] { "Available quantities for Fresho-Apple-Washington,Regular", "4 pcs", "2 x 4 pcs-Multipack" };
        Database db = new Database();

        public CategoryAdapter(Context context, List<BasketModel> basket1)
        {
            this.context = context;
            this.MatchItem = basket1;
            this.AllItem = basket1;
            Filter = new ChemicalFilter(this);
        }

        public override BasketModel this[int position]
        {
            get
            {
                return MatchItem[position];
            }
        }

        public override int Count
        {
            get

            {
                return MatchItem.Count;
            }
        }

        public List<BasketModel> Quantity1 { get; private set; }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var chemical = MatchItem[position];
            var view = convertView;
            var local = new LocalOnClickListener();
            var local1 = new LocalOnClickListener();
            var local2 = new LocalOnClickListener();


            //if (view == null)
            //{
            //view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.List_Med, parent, false);
            view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.category_list, null);
            var photo = view.FindViewById<ImageView>(Resource.Id.ImageView);
            var type = view.FindViewById<TextView>(Resource.Id.tv1);
            var name = view.FindViewById<TextView>(Resource.Id.tv2);
            var originalprice = view.FindViewById<TextView>(Resource.Id.tv3);
            //originalprice.Text="Text here";
            originalprice.PaintFlags= PaintFlags.StrikeThruText;
            var newprice = view.FindViewById<TextView>(Resource.Id.tv4);
            Button add_btn = view.FindViewById<Button>(Resource.Id.btn1);
            Button plus = view.FindViewById<Button>(Resource.Id.plus);
            Button minus = view.FindViewById<Button>(Resource.Id.minus);
            LinearLayout linear = view.FindViewById<LinearLayout>(Resource.Id.ll);
            TextView quantity = view.FindViewById<TextView>(Resource.Id.ed1);
            Spinner spinner = view.FindViewById<Spinner>(Resource.Id.spinner);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(context, Resource.Array.basket_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            view.Tag = new ViewHolder() { Photo = photo, Type = type, Name = name, OriginalPrice = originalprice, NewPrice = newprice, Add_Button = add_btn, Plus = plus, Minus = minus, Quantity = quantity, Linear = linear };
            if (Category.data[position].Quant > 0)
            {
                add_btn.Visibility = ViewStates.Invisible;
                linear.Visibility = ViewStates.Visible;

            }
            else
            {
                add_btn.Visibility = ViewStates.Visible;
                linear.Visibility = ViewStates.Invisible;

            }
        
        var holder = (ViewHolder)view.Tag;
            holder.Photo.SetImageResource(MatchItem[position].Image);
            holder.Type.Text = MatchItem[position].Type;
            holder.Name.Text = MatchItem[position].Name;
            //holder.Spin.Text = MatchItem[position].Spin;
            holder.OriginalPrice.Text = MatchItem[position].OriginalPrice;
            holder.NewPrice.Text = MatchItem[position].NewPrice;
            
           
            local.HandleOnClick = () =>
            {
                int quant = MatchItem[position].Quant + 1;
                MatchItem[position].Quant = quant;
                holder.Quantity.Text = quant.ToString();
                db.updateIntoTable(MatchItem[position]);
                NotifyDataSetChanged();
            };

            local2.HandleOnClick = () =>
            {
                int quant = MatchItem[position].Quant - 1;
                MatchItem[position].Quant = quant;
                holder.Quantity.Text = quant.ToString();
                if (quant <= 0)
                {
                    holder.Quantity.Text = "0";
                    MatchItem[position].Quant = 0;

                }
                db.updateIntoTable(MatchItem[position]);
            };

            local1.HandleOnClick = () =>
            {
                int quant = MatchItem[position].Quant + 1;
                holder.Add_Button.Visibility = ViewStates.Invisible;
                holder.Linear.Visibility = ViewStates.Visible;
                MatchItem[position].Quant = quant;
                holder.Quantity.Text = MatchItem[position].Quant.ToString();
                MatchItem[position].SelectItem = true;
                db.updateIntoTable(MatchItem[position]);
                // NotifyDataSetChanged();
            };
           
            holder.Plus.SetOnClickListener(local);
            holder.Add_Button.SetOnClickListener(local1);
            holder.Minus.SetOnClickListener(local2);
            return view;
        }
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

        }

        public Filter Filter { get; private set; }

        public override void NotifyDataSetChanged()
        {
            // If you are using cool stuff like sections
            // remember to update the indices here!
            base.NotifyDataSetChanged();
        }


        public class ViewHolder : Java.Lang.Object
        {
            public ImageView Photo { get; set; }
            public TextView Type { get; set; }
            public TextView Name { get; set; }
            public TextView OriginalPrice { get; set; }
            public TextView NewPrice { get; set; }
            public TextView Spin { get; set; }
            public Button Add_Button { get; set; }
            public Button Plus { get; set; }
            public Button Minus { get; set; }
            public TextView Quantity { get; set; }
            public LinearLayout Linear { get; set; }

        }
    }
    class ChemicalFilter : Filter
    {
        readonly CategoryAdapter _adapter;

        public ChemicalFilter(CategoryAdapter adapter) : base()
        {
            _adapter = adapter;
        }

        protected override Filter.FilterResults PerformFiltering(Java.Lang.ICharSequence constraint)
        {
            FilterResults returnObj = new FilterResults();

            var matchList = new List<BasketModel>();


            var results = new List<BasketModel>();


            if (_adapter.AllItem == null)
                _adapter.AllItem = _adapter.MatchItem;

            if (constraint == null) return returnObj;

            if (_adapter.AllItem != null && _adapter.AllItem.Any())
            {
                results.AddRange(
                    _adapter.AllItem.Where(
                        chemical => chemical.Name.ToLower().Contains(constraint.ToString().ToLower())));
            }
            returnObj.Values = FromArray(results.Select(r => r.ToJavaObject()).ToArray());
            returnObj.Count = results.Count;

            constraint.Dispose();

            return returnObj;
        }

        protected override void PublishResults(ICharSequence constraint, Filter.FilterResults results)
        {
            using (var values = results.Values)
                _adapter.MatchItem = values.ToArray<Object>()
                    .Select(r => r.ToNetObject<BasketModel>()).ToList();

            _adapter.NotifyDataSetChanged();
        }
    }
}



