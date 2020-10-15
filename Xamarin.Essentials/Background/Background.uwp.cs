using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace Xamarin.Essentials.Background
{
    public static partial class Background
    {
        const string backServiceName = "Xamarin.Essentials.Background.BackgroundService";

        public static void StartBackgroundService()
        {
            Task.Run(StartBackgroundServiceAsync);
        }

        static async Task StartBackgroundServiceAsync()
        {
            var access = await BackgroundExecutionManager.RequestAccessAsync();

            switch (access)
            {
                case BackgroundAccessStatus.Unspecified:
                case BackgroundAccessStatus.DeniedByUser:
                case BackgroundAccessStatus.DeniedBySystemPolicy:
                    return;
            }

            var task = new BackgroundTaskBuilder
            {
                Name = backServiceName,
                TaskEntryPoint = backServiceName
            };

            var trigger = new ApplicationTrigger();
            task.SetTrigger(trigger);

            task.Register();

            await trigger.RequestAsync();
        }
    }
}
