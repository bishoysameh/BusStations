﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Bus
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
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedById { get; set; }
    }
}
