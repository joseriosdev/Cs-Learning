using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyACTIO.Entities
{
    public class Event : IEntity
    {
        public int Id { set; get; }
        public string? Name { set; get; }
        public DateTime CreatedDate { set; get; }
        public string? OrganizedByName {set; get;}
        public int OrganizedById { set; get; }
        public int WorkSpaceId { set; get; }
    }
}
