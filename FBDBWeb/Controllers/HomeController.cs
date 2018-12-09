using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FBDBWeb.Models;

namespace FBDBWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        #region Game
        public IActionResult GameAnalysis()
        {
            return View();
        }

        public IActionResult GameResult(string HomeTeam, string AwayTeam)
        {
            // Daten aus dem Request lesen
            WebModel oModel = new WebModel();
            ViewData["Result"] = oModel.analyseGame(AwayTeam, HomeTeam);

            return View();
        }
        #endregion

        #region Gameday
        public IActionResult GamedayAnalysis()
        {
            return View();
        }

        public IActionResult GamedayResult (string Gameday)
        {
            WebModel oModel = new WebModel();
            ViewData["Result"] = oModel.analyseGameday(Gameday);
            return View();
        }
        #endregion

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Links()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
