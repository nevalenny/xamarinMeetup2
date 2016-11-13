﻿using System;
using System.IO;

namespace xamarinMeetup2
{
    public class ItemModel
    {
        //public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        //public string email { get; set; }
        public string picture { get; set; }

        public string Text
        {
            get
            {
                return first_name + " " + last_name;
            }
        }

        public string Picture
        {
            get
            {
                // we remove "data:image/png;base64," from each string start and convert raw base64
                return picture.Remove(0, 22);
            }
        }
    }
}