using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Domain.Entities
{
    public class BasketItemDto
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
