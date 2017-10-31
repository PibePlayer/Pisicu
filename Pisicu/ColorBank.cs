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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Pisicu{

    public class ColorBank{

        public static Color undefined = new Color(255,0,255);

        public static Color alizarin = new Color(231, 76, 60);
        public static Color pomegranate = new Color(192, 57, 43);
        public static Color midnightblue = new Color(44, 62, 80);
        public static Color turquoise = new Color(26, 188, 156);
        public static Color orange = new Color(243, 156, 18);
        public static Color clouds = new Color(236, 240, 241);
        public static Color amethyst = new Color(155, 89, 182);
        public static Color wetasphalt = new Color(52, 73, 94);
    }
}