using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;

namespace Mpv.JsonIpc.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var pipeFactory = new NamedPipeFactory();

            
            using (var manager = new Manager(pipeFactory))
            {
                var ipc = new Ipc(manager);
                var api = new Api(ipc);
                
                while (true)
                {
//                    var volume = api.GetVolume().Result;
//                    Console.WriteLine($"The volume is {volume}");
//                    api.ShowText("Robin",TimeSpan.FromSeconds(10)).Wait();
                    var response = ipc.CycleProperty<Response<object>>(Property.Pause);
                    Thread.Sleep(1000 * 5);
                }
            }
        }
    }


  
}