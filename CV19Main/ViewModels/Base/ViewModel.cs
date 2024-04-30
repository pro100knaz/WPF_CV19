using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Threading;
using System.Xaml;


namespace CV19Main.ViewModels.Base
{
    internal abstract class ViewModel : MarkupExtension ,INotifyPropertyChanged , IDisposable
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {

            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            var handlers = PropertyChanged;
            if (handlers is null)
            {
                return;
            }

            var invokation_list = handlers.GetInvocationList();

            var arg = new PropertyChangedEventArgs(propertyName);

            foreach (var action in invokation_list)
            {
                if (action.Target is DispatcherObject disp_obj)
                {
                    disp_obj.Dispatcher.Invoke(action, this, arg);
                }
                else
                {
                    action.DynamicInvoke(this, arg);
                }
            }

        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }


        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var value_target_service = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget; // обьект к которому мы подключени

            var root_object_service = serviceProvider.GetService(typeof(IRootObjectProvider)) as IRootObjectProvider; // окно

            OnInitialized(value_target_service?.TargetObject, 
                value_target_service?.TargetProperty, 
                root_object_service?.RootObject);

            return this;
        }



        private WeakReference _TargetRef;
        private WeakReference _RootRef;

        public object TargetObject => _TargetRef.Target;
        public object RootObject => _RootRef.Target;


        protected virtual void OnInitialized(object Target, object Propert, object Root)
        {
            _TargetRef = new WeakReference(Target);
            _RootRef = new WeakReference(Root);

        }

        public void Dispose()
        {
            Dispose(true);
        }

        private bool _Disposed;

        protected virtual void Dispose(bool Disposing)
        {
            if(!Disposing || _Disposed) return;

            _Disposed = true;
        }
    }
}
