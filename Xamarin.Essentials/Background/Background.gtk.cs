using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Essentials.Background
{
    public partial class Background
    {
        public static void StartBackgroundService()
        {
            Background.StartJobs();
        }
    }
}
