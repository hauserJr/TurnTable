using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurnTableDefault;
namespace TurnTable.Controllers
{
    public class TurnTableController : Controller
    {
        // GET: TurnTable
        public ActionResult TurnTable()
        {
            return View();
        }

        public ActionResult RandomChoice()
        {
            return Content("1800");
        }
        
        public ActionResult getTable()
        {
            int Amount = 6;
            List <TurnTableDefault>  _TurnTableItem = new List<TurnTableDefault>();
            for (int i = 0; i < Amount; i++)
            {
                double Min_Angle = ((Math.PI*2) / Amount) * i;
                double Max_Angle = ((Math.PI*2) / Amount) * (i + 1);
                _TurnTableItem.Add(new TurnTableItem()
                {
                    NO = i,
                    Chosen_Name = @"Name" + i.ToString(),
                    Min_Angle = Min_Angle <= 0 ? 0.ToString():Min_Angle.ToString("#.##"),
                    Max_Angle = Max_Angle <= 0 ? 0.ToString():Max_Angle.ToString("#.##")
                });
            }
            string json_data = JsonConvert.SerializeObject(_TurnTableItem);
            return Content(json_data);
        }
    }
}