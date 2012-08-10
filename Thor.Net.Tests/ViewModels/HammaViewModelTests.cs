using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using Thor.Net.ViewModels;

namespace Thor.Net.Tests.ViewModels
{
    [TestFixture]
    public class HammaViewModelTests
    {
        [Test]
        public void should_show_apps_screen_when_apps_selected()
        {
            HammaViewModel viewModel = new HammaViewModel();
            viewModel.Apps().Should().;
        }

        [Test]
        public void should_show_clouds_screen_when_clouds_selected()
        {

        }

        [Test]
        public void should_show_services_screen_when_services_selected()
        {

        }
    }
}
