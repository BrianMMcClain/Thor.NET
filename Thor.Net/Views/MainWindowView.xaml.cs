namespace Thor.Net.Views
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            ////testing a tile.
            //var asdf = new Tile { Content = "est" + "\nblasdgh", Title = "Test1", Count = "53" };
            //CloudStackPanel.Children.Add(asdf);

            //if (string.IsNullOrWhiteSpace(Settings.Default.FoundryTargets))
            //    Settings.Default.FoundryTargets = "blagh";
            //Settings.Default.Save();

            //var target = new FoundryTarget
            //                 {
            //                     Name = "Why No Not Here",
            //                     Created = DateTime.Now,
            //                     Stamp = DateTime.Now,
            //                     Path = new Uri("http://api.someplace.com")
            //                 };

            //var serialized = target.ToJson();

            //var deserialized = serialized.FromJson<FoundryTarget>();

            //MessageBox.Show("Settings was saved " + Settings.Default.FoundryTargets + "\n" +
            //    "\n\n...and serilized:\n" + serialized + "\n\n\nTarget Name: " + deserialized.Name + "\nType:" + deserialized.GetType());
        }
    }
}
