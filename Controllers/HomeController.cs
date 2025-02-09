using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hospital.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationDbContext app= new ApplicationDbContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Booking()
        {
            var doctors=app.Doctors.ToList();
            return View(doctors);
        }
        public IActionResult Details(int id)
        {
            var Doctor=app.Doctors.Find(id);
            if (Doctor != null)
            {
                return View(Doctor);
            }
            return RedirectToAction("NotFoundPage");
        }
        public IActionResult SaveData(string PatientName, DateOnly date,TimeOnly time,int doctorid) {
            app.Appointments.Add(new Appointment() {PatientName=PatientName, AppointmentDate = date,AppointmentTime=time,DoctorId=doctorid });
            app.SaveChanges();
            var appointments= app.Appointments.ToList();
            return View(appointments);

        }
        public IActionResult NotFoundPage() 
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
