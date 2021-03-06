﻿using System;
using ServiceStack.Text;
using Thor.Models;
using Thor.Models.Jord;
using Thor.Testings.Properties;

namespace Thor.Testings.Asgard
{
    public static class StaticTestData
    {
        public static void MakeSureSettingsJsonFoundryExists()
        {
            if (string.IsNullOrWhiteSpace(Settings.Default.Foundry))
            {
                var foundry = new Foundry();
                Settings.Default.Foundry = foundry.ToJson();
                Settings.Default.Save();
            }
        }

        public static FoundryTarget SampleFoundryTarget()
        {
            var target =
                new FoundryTarget()
                             {
                                 Created = DateTime.Now.AddDays(-4),
                                 Name = "A Sample Target",
                                 Notes = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam tempus ornare nulla in feugiat. Nulla pellentesque accumsan dapibus. Sed lobortis iaculis eros, ultrices laoreet elit dictum eu.",
                                 Path = new Uri("http://api.robotech.wa1.wfabric.com")
                             };

            return target;
        }
    }
}
