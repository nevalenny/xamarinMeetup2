using System;
using Android.Support.V4.App;

namespace xamarinMeetup2_x_android
{
    /**
     * A {@link FragmentPagerAdapter} that returns a fragment corresponding to
     * one of the sections/tabs/pages.
     */
    public class SectionsPagerAdapter : FragmentPagerAdapter
    {
        public SectionsPagerAdapter(FragmentManager fm) : base(fm)
        {
        }

        public override int Count
        {
            get
            {
                return 2;
            }
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            switch (position)
            {
                case 0:
                    return new Java.Lang.String("List");
                case 1:
                    return new Java.Lang.String("Calculations");
            }

            return null;
        }

        public override Fragment GetItem(int position)
        {
           switch (position)
            {
                case 0:
                    return ListFragment.NewInstance();
                case 1:
                    return CalculationsFragment.NewInstance();
            }

            return null;
        }
    }
}