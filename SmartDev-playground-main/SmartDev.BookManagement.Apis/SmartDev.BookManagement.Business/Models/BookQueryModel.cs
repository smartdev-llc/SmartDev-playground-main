using System;
using System.Collections.Generic;

namespace SmartDev.BookManagement.Business.Models
{
    public class BookQueryModel
    {
        public string Name { get; set; }
        public IEnumerable<Guid> ListIds { get; set; }
    }
}
