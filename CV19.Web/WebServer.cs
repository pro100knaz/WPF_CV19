using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CV19.Web
{


    internal class WebServer
    {
        private event EventHandler<RequestReceiverEventArgs> RequestReceiver;
        //  private TcpListener _listener = new TcpListener(new IPEndPoint(IPAddress.Any, 8000));

        private HttpListener _httpListener;
        private readonly int _Port;
        private bool _Enabled;
        private readonly object _SyncRoot = new object();




        public int Port => _Port;
        public bool Enabled
        {
            get => _Enabled;
            set
            {
                if (value) Start();
                else
                {
                    Stop();
                }
            }
        }
        public WebServer(int Port) => _Port = Port;


        public void Start()
        {
            if(_Enabled) return;
            lock (_SyncRoot)
            {
                if (_Enabled) return;
                    _httpListener = new HttpListener();
                    _httpListener.Prefixes.Add($"http://*:{_Port}");
                    _httpListener.Prefixes.Add($"http://+:{_Port}");
                    _Enabled = true;
            }
            ListenAsync();
        }

        public void Stop()
        {
            if(!_Enabled) return;
            lock (_SyncRoot)
            {
                if(!_Enabled) return;
                _httpListener = null;
                _Enabled = false;
            }
        }

        private async void ListenAsync()
        {
            var listener = _httpListener; //если кто-то изменит ссылку чтобы мы могли продолжить работу
            

            listener.Start();

            while (_Enabled)
            {
                var received_context_task = await listener.GetContextAsync().ConfigureAwait(false);

                ProcessRequest(received_context_task);
            }

            listener.Stop();

        }

        private void ProcessRequest(HttpListenerContext context)
        {
            RequestReceiver?.Invoke(this, new RequestReceiverEventArgs(context));
        }

    }

    class RequestReceiverEventArgs : EventArgs
    {
        public HttpListenerContext Context { get; }

        public RequestReceiverEventArgs(HttpListenerContext context)
        {
            Context = context;
        }
    }
}
