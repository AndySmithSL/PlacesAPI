﻿using PlacesAPI.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Views.ListView
{
    public class PlaceGroupListView : PlaceGroupView
    {
        public int Places => ViewObject.Places.Count;
    }
}
