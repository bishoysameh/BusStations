using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Models;
using Services.DTOs;
using Microsoft.EntityFrameworkCore;
using DB;

namespace Services.BusService
{
    public class BusService : IBusService
    {
        private readonly DBContext _context;

        public BusService(DBContext context)
        {
            _context = context;
        }

        public async Task<int> AddBusRecordAsync(CreateBusDto busDto)
        {
            var newBus = new Bus
            {
                DriverName = busDto.DriverName,
                DriverPhoneNumber = busDto.DriverPhoneNumber,
                BusStopStation = busDto.BusStopStation,
                CarNumber = busDto.CarNumber,
                BusCapacity = busDto.BusCapacity,
                CarModel = busDto.CarModel,
                BusLineStops = busDto.BusLineStops,
                BusType = busDto.BusType,
                CreatedOn = DateTime.UtcNow,
                CreatedById = busDto.CreatedById,
                IsDeleted = false
            };

            _context.Buses.Add(newBus);
            await _context.SaveChangesAsync();
            return newBus.Id;
        }





        public async Task<IEnumerable<Bus>> GetBusesAsync(BusFilterDto filterDto)
        {
            var query = _context.Buses.AsQueryable();

            if (!string.IsNullOrEmpty(filterDto.DriverName))
            {
                query = query.Where(b => b.DriverName.Contains(filterDto.DriverName));
            }

            if (!string.IsNullOrEmpty(filterDto.DriverPhoneNumber))
            {
                query = query.Where(b => b.DriverPhoneNumber.Contains(filterDto.DriverPhoneNumber));
            }

            if (!string.IsNullOrEmpty(filterDto.BusStopStation))
            {
                query = query.Where(b => b.BusStopStation.Contains(filterDto.BusStopStation));
            }

            if (filterDto.CarNumber.HasValue)
            {
                query = query.Where(b => b.CarNumber == filterDto.CarNumber.Value);
            }

            if (filterDto.BusCapacity.HasValue)
            {
                query = query.Where(b => b.BusCapacity == filterDto.BusCapacity.Value);
            }

            if (!string.IsNullOrEmpty(filterDto.CarModel))
            {
                query = query.Where(b => b.CarModel.Contains(filterDto.CarModel));
            }

            return await query.ToListAsync();
        }
    }
}


