using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class Basket : BaseEntity
    {
        public virtual ICollection<BasketItem> BasketItems { get; set; }

        //---Creates an empty list of the basket
        public Basket()
        {
            this.BasketItems = new List<BasketItem>();
        }
    }
}
