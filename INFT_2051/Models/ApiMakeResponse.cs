using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFT_2051.Models
{
    internal class ApiMakeResponse
    {
        public int Total_count { get; set; }
        public ApiMakeModel[] Results { get; set; }
    }
}
