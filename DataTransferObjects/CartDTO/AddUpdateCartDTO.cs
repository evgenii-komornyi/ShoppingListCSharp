using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.CartDTO
{
    public class AddUpdateCartDTO : CartBasicDTO
    {
        public long productId { get; set; }
        public long cartId { get; set; }
        public int quantity { get; set; }
    }
}
