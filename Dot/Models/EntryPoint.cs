using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Dot.Models
{
    public class EntryPoint
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public string Category { get; set; }
        public string Name { get; set; }
        public int Quantity{ get; set; }
        public float  Price_per_unit { get; set; }
        public float TotalCost { get { return this.Price_per_unit * this.Quantity; } }


    }
}
