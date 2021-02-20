using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PortalGate.Models;
using PortalGate.Models.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalGate.Controllers
{
    public class TransitController : Controller
    {
        private RailroadsContext db;

        public TransitController(RailroadsContext context)
        {
            db = context;
        }

        [HttpGet]
        public string TransitToUnit(int railroadId, int industryId, int unitId)
        {
            UnitStartPageURI unitStartPage = db.UnitStartPageUries.FirstOrDefault(u =>
                u.Railroad == railroadId && 
                u.Industry == industryId 
                && u.Unit == unitId);
            
            if (unitStartPage != null)
                return unitStartPage.URI;

            return String.Empty;
        }
    }
}
