using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIApp.Model;

namespace WebAPIApp.Service
{
    interface IDeviceStatus
    {
        IEnumerable<DeviceSensorDetails> GetAllDeviceStatus();
    }
}
