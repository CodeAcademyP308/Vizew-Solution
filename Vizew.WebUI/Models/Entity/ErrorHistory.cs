using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vizew.WebUI.Models.Entity
{
    public class ErrorHistory : BaseEntity
    {
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int? ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}