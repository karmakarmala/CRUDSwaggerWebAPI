using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using WebAPIApp.Model;
using WebAPIApp.Service;

namespace WebAPIApp.Controllers
{
   
    [Route("[controller]")]
    [ApiController]
    public class DeviceStatusController : Controller, IDeviceStatus
    {

        private readonly ILogger<DeviceStatusController> _logger;
        private List<DeviceSensorDetails> _deviceSensorDetails;

        public DeviceStatusController(ILogger<DeviceStatusController> logger)
        {
            _logger = logger;
        }

        // GET: DeviceStatus/GetStatus/DeviceName
        [HttpGet("GetStatus/{DeviceName}")]
        public IActionResult GetStatus(string DeviceName)
        {
            var DeviceStatus = GetAllDeviceStatus().Where(x => x.DeviceName == DeviceName).FirstOrDefault();

             if(DeviceStatus==null)
            {
                string message = string.Format("Mo Device found with Device Name: {0}", DeviceName);
                return NotFound(message);
            }
            else
            {
                return Ok(DeviceStatus);
            }
          
        }

        // GET: GetAllDeviceStatus
        [HttpGet("GetAllDeviceStatus")]
        public IEnumerable<DeviceSensorDetails> GetAllDeviceStatus()
        {
            _deviceSensorDetails = new List<DeviceSensorDetails>()
            {
                new DeviceSensorDetails()
                {
                    DeviceName="HP Color LaserJet MFP M183fw",
                    ModelNo="NPIBDA46B",
                    DeviceStatus="Sleep mode is on.",
                    MotorTemperature=30.5,
                    BlackCartridgePercentage=20.0,
                    CyanCartridgePercentage=40.0,
                    MagentaCartridgePercentage=50.0,
                    YellowCartridgePercentage=50.0

                }
            };

            return _deviceSensorDetails;
        }

        //Post : AddDeviceStatus/DeviceDetails
        [HttpPost("AddDeviceStatus")]
        public IActionResult AddDeviceStatus(DeviceSensorDetails sensorDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _deviceSensorDetails = new List<DeviceSensorDetails>();
            _deviceSensorDetails.Add(sensorDetails);
            return Ok("Added New Status");
        }

 
    }
}

