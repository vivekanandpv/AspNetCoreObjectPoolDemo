using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.ObjectPool;

namespace AspNetCoreObjectPoolDemo.Models
{
    public class AppConfig
    {
        public int BlockId { get; set; }
        public string Name { get; set; }
        public double Threshold { get; set; }
        public double Load { get; set; }
        public int Connections { get; set; }
    }

    public class AppConfigPolicy : IPooledObjectPolicy<AppConfig>
    {
        private static int _count = 0;
        public AppConfig Create()
        {
            ++_count;
            return new AppConfig { BlockId = _count, Connections = _count + 200, Load = Math.PI * _count, Threshold = Math.E * _count, Name = $"Config: {_count}" };
        }

        public bool Return(AppConfig obj)
        {
            return true;
        }
    }


    public class ServerViewModel
    {
        public int Id { get; set; }
        public int BlockId { get; set; }
        public string Name { get; set; }
        public double Threshold { get; set; }
        public double Load { get; set; }
        public int Connections { get; set; }
    }
}
