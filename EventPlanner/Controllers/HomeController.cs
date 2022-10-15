using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventPlanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EventDBContext eventDBContext;

        public HomeController(ILogger<HomeController> logger, EventDBContext eventDBContext)
        {
            _logger = logger;
            this.eventDBContext = eventDBContext;
        }
        //CRUD
        //Read,Create,Update,Delete

        [HttpPost]
        public JsonResult GetAllEvents()
        {
            try
            {
                List<Event> events = new List<Event>();
                events = eventDBContext.Events.ToList();
                return Json(new {Result ="OK",Records = events});
            }
            catch (Exception ex)
            {

                return Json(new {Result ="ERROR",Message = ex.Message});
            }
        }
        [HttpPost]
        public JsonResult AddEvent(Event model)
        {
            try
            {
                eventDBContext.Events.Add(model);
                eventDBContext.SaveChanges();
                return Json(new { Result = "OK", Record = model});


            }
            catch (Exception ex)
            {

                return Json(new { Result = "ERROR", Message = ex.Message });

            }
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventId)
        {
            try
            {
                Event myevent = eventDBContext.Events.Find(eventId);
                eventDBContext.Events.Remove(myevent);
                eventDBContext.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {

                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult UpdateEvent(Event model)
        {
            try
            {
                eventDBContext.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                eventDBContext.SaveChanges();
                return Json(new { Result = "OK" });




            }
            catch (Exception ex)
            {

                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
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