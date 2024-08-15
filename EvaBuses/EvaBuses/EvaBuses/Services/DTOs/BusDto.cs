using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTOs;

namespace Services.DTOs
{
    public class BusDto
    {
        public int Id { get; set; }
        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }
        public string BusStopStation { get; set; }
        public int CarNumber { get; set; }
        public int BusCapacity { get; set; }
        public string CarModel { get; set; }
        public string BusLineStops { get; set; }
        public string BusType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
