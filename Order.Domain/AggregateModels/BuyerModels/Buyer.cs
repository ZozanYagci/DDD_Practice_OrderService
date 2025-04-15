using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.AggregateModels.BuyerModels
{
    public class Buyer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
