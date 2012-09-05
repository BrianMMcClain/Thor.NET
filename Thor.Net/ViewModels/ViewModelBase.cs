using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Thor.Net.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
