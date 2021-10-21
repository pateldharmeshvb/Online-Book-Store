using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBookstore.Application.DTOs.Author
{
    public class GetAllAuthorsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }
        public DateTime Dob { get; set; }
    }
}
