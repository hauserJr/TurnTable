using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            Random Angle_Random = new Random();
            return Content((1800+ Angle_Random.Next(1, 360)).ToString());
        }
        
        public ActionResult getTable()
        {
            int Amount = 7;
            double TwoPI = 360.0;
            List <TurnTableDefault>  _TurnTableItem = new List<TurnTableDefault>();
            for (int i = 0; i < Amount; i++)
            {
                double Min_Angle = (TwoPI / Amount) * i;
                double Max_Angle = (TwoPI / Amount) * (i + 1);
                _TurnTableItem.Add(new TurnTableDefault()
                {
                    NO = i,
                    Chosen_Name = @"Name" + i.ToString(),
                    Min_Angle = Min_Angle <= 0 ? 0.ToString():(Min_Angle + 10).ToString("#.##"),
                    Max_Angle = Max_Angle <= 0 ? 0.ToString():(Max_Angle - 10).ToString("#.##")
                });
            }
            try
            {
                string json_data = JsonConvert.SerializeObject(_TurnTableItem);
                return Content(json_data);
            }
            catch (Exception ex)
            {

            }
            return null;           
        }
    }
}