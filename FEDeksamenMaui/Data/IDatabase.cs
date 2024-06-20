using FEDeksamenMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEDeksamenMaui.Data
{
    public interface IDatabase
    {
        Task<int> AddMaterials(List<Material> items);
        Task<int> SaveNewOrder(Order item);

        Task<int> SaveNewInvoice(Invoice item);

        Task<List<Order>> GetOrdersForSelectedDate(DateOnly date);
    }
}
