using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Application.DTOs
{
   public  class AuthResponseDto
    {
        public bool isSuccess { get; set; } 
        public bool isNewUser { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
