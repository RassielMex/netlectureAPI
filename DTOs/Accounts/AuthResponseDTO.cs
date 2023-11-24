using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netlectureAPI.DTOs.User
{
    public class AuthResponseDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}