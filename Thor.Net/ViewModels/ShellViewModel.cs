using System.ComponentModel.Composition;

namespace Thor.Net.ViewModels {
    [Export(typeof(IShell))]
    public class ShellViewModel : IShell {}
}
