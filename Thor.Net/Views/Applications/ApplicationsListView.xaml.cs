using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Thor.Asgard;
using Thor.Asgard.Bridges;
using Thor.Asgard.Mjolner;
using Thor.Models;
using Thor.Models.Jord;
using Thor.Net.Views.Controls;

namespace Thor.Net.Views.Applications
{
    public partial class ApplicationsListView : UserControl
    {
        private SettingsWrapper settingsWrapper;
        private List<FoundryTarget> targets;
        private ApplicationsBridge applicationsBridge;
        private List<FoundryApplication> applications;

        public ApplicationsListView()
        {
            InitializeComponent();

            settingsWrapper = new SettingsWrapper();
            targets = (new TargetsBridge(settingsWrapper)).GetTargets();

            if (targets.Count > 0)
            {
                applicationsBridge = new ApplicationsBridge(settingsWrapper);
                applications = (applicationsBridge).GetApplications();

                var delegateMethod = new MethodDelegate(GetCloudFoundryApplications);
                var callbackDelegate = new AsyncCallback(FoundryApplicationsFillViewAsyncCallback);
                delegateMethod.BeginInvoke(callbackDelegate, delegateMethod);
            }
        }

        public CloudsView ParentCloudsView
        {
            get { return ((Parent as StackPanel).Parent as CloudsView); }
        }

        IEnumerable<FoundryApplication> GetCloudFoundryApplications()
        {
            foreach (var target in targets)
            {
                var paas = new PaasTarget(target.Username, target.Password, target.Path);

                foreach (var cloudApplication in paas.CloudApplications)
                {
                    var foundryApplication = Mappers.Map.FoundryApplicationMap(target, cloudApplication);
                    applications.Add(foundryApplication);
                    applicationsBridge.PutApplication(foundryApplication);
                }
            }

            return applications;
        }

        delegate IEnumerable<FoundryApplication> MethodDelegate();

        public string GetCollectedInfo(FoundryApplication application)
        {
            const string lineBreak = "\n";
            var collectedInfo = Properties.Resources.ApplicationMemory + lineBreak + application.Resources.Memory +
                                lineBreak;

            return collectedInfo;
        }

        private void CloudApplicationOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            MessageBox.Show(Properties.Resources.NotAvailableYetJoinThorProject);
        }

        public void FoundryApplicationsFillViewAsyncCallback(IAsyncResult ar)
        {
            var delegateMethod = (MethodDelegate)ar.AsyncState;
            var applications = delegateMethod.EndInvoke(ar);

            CloudsViewStackPanel.Dispatcher.Invoke(
             System.Windows.Threading.DispatcherPriority.Normal,
                 new Action(delegate
                 {
                     CloudsViewStackPanel.Children.RemoveRange(1, CloudsViewStackPanel.Children.Count - 1);
                     foreach (var application in applications)
                     {
                         var cloudTile =
                             new ApplicationTile
                             {
                                 CloudApplication = { Title = application.Name + " @ " + application.Target.Name },
                                 AppsInfo = { Text = GetCollectedInfo(application) }
                             };

                         cloudTile.CloudApplication.Click += CloudApplicationOnClick;
                         CloudsViewStackPanel.Children.Add(cloudTile);
                     }
                 }));
        }
    }
}
