using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyACTIO.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string Email { set; get; }
    }
}
