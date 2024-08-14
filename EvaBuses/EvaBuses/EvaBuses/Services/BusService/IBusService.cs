using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.DTOs;
using DB.Models;

namespace Services.BusService
{
    public interface IBusService
    {
       // Task<Bus> GetBusByIdAsync(int id);
        //Task<bool> EditBusRecordAsync(int id, EditBusDto busDto);
       // Task<bool> DeleteBusRecordAsync(int id);
        Task<int> AddBusRecordAsync(CreateBusDto busDto);
        Task<IEnumerable<Bus>> GetBusesAsync(BusFilterDto filter);
        //Task<bool> SaveExcelDataAsync(IEnumerable<CreateBusDto> busDtos);
    }
}
