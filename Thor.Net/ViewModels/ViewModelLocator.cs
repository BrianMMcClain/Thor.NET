using System;
using System.Runtime.CompilerServices;
using Thor.Net.ViewModels.Clouds;

namespace Thor.Net.ViewModels
{
    public class ViewModelLocator : IDisposable
    {
        private bool _isDisposed;

        ~ViewModelLocator()
        {
            Dispose(false);
        }

        private static MainWindowViewModel _mainWindowViewModel = null;
        public IMainWindowViewModel MainWindowVm
        {
            get { return _mainWindowViewModel ?? (_mainWindowViewModel = new MainWindowViewModel()); }
        }

        private static InformationViewModel _informationViewModel = null;
        public IInformationViewModel InformationVm
        {
            get { return _informationViewModel ?? (_informationViewModel = new InformationViewModel()); }
        }

        [MethodImpl(MethodImplOptions.NoOptimization)]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (_isDisposed) return;

            if (isDisposing)
            {
                if (_mainWindowViewModel != null)
                {
                    _mainWindowViewModel.Dispose();
                    _mainWindowViewModel = null;
                }

                _isDisposed = true;
            }
        }
    }
}
