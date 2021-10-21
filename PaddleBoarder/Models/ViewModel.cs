using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaddleBoarder.Models
{
    public class ViewModel
    {
        public bool IsRain { get; set; }
        public bool IsCloud { get; set; }
        public bool IsSun { get; set; }
        public bool IsThunder { get; set; }
        public bool IsSnow { get; set; }
    }
}