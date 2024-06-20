using SQLite;
using SQLiteNetExtensions.Attributes;
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
        
        [TextBlob("MaterialsUsedBlobbed")]
        public List<Dictionary<string, int>> MaterialsUsed { get; set; }
        public int HoursUsed { get; set; }
        public int Price { get; set; }
        
        [Ignore]
        public string MaterialsUsedBlobbed { get; set; }
    }
}
