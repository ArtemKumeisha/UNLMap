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
using Xamarin.Forms.Platform.Android;

namespace UNLMaps.Droid.NativeViews
{
    public class RaitingSpinner : Spinner
    {
        /// <summary>
        /// Spinner adapter 
        /// </summary>
        private ArrayAdapter adapter;

        /// <summary>
        /// Spinner items :P 
        /// </summary>
        private IList<string> items;

        #region Properties

        public IList<string> ItemsSource
        {
            get { return items; }
            set
            {
                if (items == value) return;
                items = value;
                adapter.Clear();

                foreach (string str in items)
                {
                    adapter.Add(str);
                }
            }
        }

        public string SelectedObject
        {
            get { return (string)GetItemAtPosition(SelectedItemPosition); }
            set
            {
                if (items != null)
                {
                    int index = items.IndexOf(value);
                    if (index != -1)
                    {
                        SetSelection(index);
                    }
                }
            }
        }

        #endregion

        public RaitingSpinner(Context context) : base(context)
        {
            ItemSelected += OnBindableSpinnerItemSelected;

            adapter = new ArrayAdapter(context, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            Adapter = adapter;
        }

        void OnBindableSpinnerItemSelected(object sender, ItemSelectedEventArgs args)
        {
            SelectedObject = (string)GetItemAtPosition(args.Position);
        }
    }
}