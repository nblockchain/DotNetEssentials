using System;
using System.Collections.Generic;
using System.Text;
using Android.Content;

namespace Xamarin.Essentials.Background
{
    public static partial class Background
    {
        static ContextWrapper context;

        public static void Init(ContextWrapper ctx)
        {
            context = ctx;
        }

        public static void StartBackgroundService(ContextWrapper context)
        {
            if (context == null)
                throw new InvalidOperationException("Background service is not initialized yet");
            var intent = new Intent(context, typeof(BackgroundService));
            context.StartService(intent);
        }
    }
}
