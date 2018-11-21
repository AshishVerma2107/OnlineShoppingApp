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
   public class ListAdapter : BaseAdapter<BasketModel>
    {
        Context context;
        List<BasketModel> basket;
        
        public ListAdapter( Context context, List<BasketModel> basket1)
        {
            this.context = context;
            this.basket = basket1;
        }
        public override BasketModel this[int position]
        {
            get
            {
                return basket[position];
            }
        }
        public override int Count
        {
            get
            {
                return basket.Count;
            }
        }

        public List<BasketModel> Quantity1 { get; private set; }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            var local = new LocalOnClickListener();
            var local1 = new LocalOnClickListener();
            var local2 = new LocalOnClickListener();
            //var local3 = new LocalOnClickListener();

            //if (view == null)
            //{
                //view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.category_list, parent, false);
            view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.category_list, null);
            var photo = view.FindViewById<ImageView>(Resource.Id.ImageView);
                var type = view.FindViewById<TextView>(Resource.Id.tv1);
                var name = view.FindViewById<TextView>(Resource.Id.tv2);
                var originalprice = view.FindViewById<TextView>(Resource.Id.tv3);
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
                view.Tag = new ViewHolder() {Photo=photo, Type = type, Name = name,OriginalPrice= originalprice,NewPrice= newprice, Add_Button = add_btn, Plus = plus, Minus = minus, Quantity = quantity, Linear = linear };
            

            var holder = (ViewHolder)view.Tag;
            holder.Photo.SetImageResource(basket[position].Image);
            holder.Type.Text = basket[position].Type;
            holder.Name.Text = basket[position].Name;
            //holder.Spin.Tag = basket[position].spin;
            holder.OriginalPrice.Text = basket[position].OriginalPrice;
            holder.NewPrice.Text = basket[position].NewPrice;
            local.HandleOnClick = () =>
            {
                int quant = basket[position].Quant + 1;
                basket[position].Quant = quant;
                holder.Quantity.Text = quant.ToString();
                NotifyDataSetChanged();
            };
            local2.HandleOnClick = () =>
            {
                int quant = basket[position].Quant - 1;
                basket[position].Quant = quant;
                holder.Quantity.Text = quant.ToString();
                if (quant <= 0)
                {
                    holder.Quantity.Text = "0";
                    basket[position].Quant = 0;
                }
            };

            local1.HandleOnClick = () =>
            {
                int quant = basket[position].Quant + 1;
                holder.Add_Button.Visibility = ViewStates.Invisible;
                holder.Linear.Visibility = ViewStates.Visible;
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
    }
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