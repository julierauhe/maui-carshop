using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEDeksamenMaui.Models
{
    public class Invoice
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //OrderId refers to Id in Order
        public int OrderId { get; set; }
        public string MechanicName { get; set; }
        public List<Dictionary<string, decimal>> MaterialsUsed { get; set; }
        public float HoursUsed { get; set; }
        public decimal Price { get; set; }
    }
}
