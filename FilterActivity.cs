using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;

using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using BasketApp.Fragments;

namespace BasketApp
{
    [Activity(Label = "FilterActivity")]
    public class FilterActivity : AppCompatActivity
    {
        private ViewPager viewpager;
        private TabLayout tabLayout;
        Adapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.filter_list);
            viewpager = FindViewById<ViewPager>(Resource.Id.viewpager);
            setupViewPager(viewpager);
            tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
            tabLayout.SetupWithViewPager(viewpager);

        }
        void setupViewPager(Android.Support.V4.View.ViewPager viewPager)
        {
            adapter = new Adapter(SupportFragmentManager);
            adapter.AddFragment(new RefineBy(), "Refine By");
            adapter.AddFragment(new SortBy(), "Sort By");
            // adapter.AddFragment(new OverlayActivity(), "ADD EHR");
            viewpager.Adapter = adapter;
            viewpager.SetCurrentItem(0, true);
            viewpager.Adapter.NotifyDataSetChanged();
        }
        class Adapter : Android.Support.V4.App.FragmentPagerAdapter
        {
            List<Android.Support.V4.App.Fragment> fragments = new List<Android.Support.V4.App.Fragment>();
            List<string> fragmentTitles = new List<string>();
            public Adapter(Android.Support.V4.App.FragmentManager fm) : base(fm) { }
            public void AddFragment(Android.Support.V4.App.Fragment fragment, String title)
            {
                fragments.Add(fragment);
                fragmentTitles.Add(title);
            }
            public override Android.Support.V4.App.Fragment GetItem(int position)
            {
                return fragments[position];
            }
            public override int Count
            {
                get
                {
                    return fragments.Count;
                }
            }
            public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
            {
                return new Java.Lang.String(fragmentTitles[position]);
            }
        }
    }
}
