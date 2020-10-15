using System;
using System.Collections.Generic;
using System.Text;
using Windows.ApplicationModel.Background;

namespace Xamarin.Essentials.Background
{
    public class BackgroundService : Windows.ApplicationModel.Background.IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            Background.StartJobs();
        }
    }
}
