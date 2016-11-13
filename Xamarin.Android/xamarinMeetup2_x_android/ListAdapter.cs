using System;
using System.Collections;
using Android.Content;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using xamarinMeetup2;

namespace xamarinMeetup2_x_android
{
    public class ListAdapter : RecyclerView.Adapter
    {
        IList items;
        Context context;

        public ListAdapter(IList items, Context context)
        {
            this.items = items;
            this.context = context;
            NotifyDataSetChanged();
        }

        public override int ItemCount
        {
            get
            {
                return items?.Count ?? 0;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var myHolder = holder as CellHolder;
            var item = items[position] as ItemModel;

            byte[] imageAsBytes = Base64.Decode(item.Picture, Base64Flags.Default);

            myHolder.Image.SetImageBitmap(BitmapFactory.DecodeByteArray(imageAsBytes, 0, imageAsBytes.Length));
            myHolder.Caption.Text = item.Text;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            return new CellHolder(LayoutInflater.From(context).Inflate(Resource.Layout.list_cell, parent, false));
        }

        class CellHolder : RecyclerView.ViewHolder
        {
            public ImageView Image { get; private set; }
            public TextView Caption { get; private set; }

            public CellHolder(View itemView) : base(itemView)
            {
                Image = itemView.FindViewById<ImageView>(Resource.Id.imageView1);
                Caption = itemView.FindViewById<TextView>(Resource.Id.textView1);
            }
        }
    }
}