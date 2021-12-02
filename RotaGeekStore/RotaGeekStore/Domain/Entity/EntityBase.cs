using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline.Domain.Entity
{
    public class EntityBase
    {
        public string Id { get; protected set; } = Guid.NewGuid().ToString();
    }
}
