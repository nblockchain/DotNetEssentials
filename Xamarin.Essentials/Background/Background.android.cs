using System;
using System.Collections.Generic;
using System.Text;
using Android.Content;

namespace Xamarin.Essentials.Background
{
    public static partial class Background
    {
        public static void StartBackgroundService(ContextWrapper context)
        {
            var intent = new Intent(context, typeof(BackgroundService));
            context.StartService(intent);
        }
    }
}
