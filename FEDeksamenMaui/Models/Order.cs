using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEDeksamenMaui.Models
{
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime TimeOfSubmission { get; set; }
        public string Reperation { get; set; }
    }
}
