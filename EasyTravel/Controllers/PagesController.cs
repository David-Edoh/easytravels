using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyTravel.Models;
using EasyTravel.Data;
using EasyTravel.Models.PagesViewModels;
using Microsoft.AspNetCore.Http;

namespace EasyTravel.Controllers
{
    public class PagesController : Controller
    {
        private ApplicationDbContext context;
        public PagesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(b_IndexViewModel model)
        {
            
                Booking booking = new Booking();
                booking.From = model.From;
                booking.To = model.To;
                booking.Travel_Date = model.Travel_Date;

                context.Bookings.Add(booking);
                context.SaveChanges();

                return RedirectToAction("Choosepark/" + booking.Id.ToString());

        }

        public IActionResult Support()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Account()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Choosepark(Guid id)
        {
            ChooseParkViewModel chooseParkViewModel = new ChooseParkViewModel();

            return View(chooseParkViewModel);
        }

        [HttpPost]
        public IActionResult Choosepark(ChooseParkViewModel model)
        {
            Booking booking = context.Bookings.Find(model.Id);
            booking.Motor_park = model.Motor_park;
            booking.Fare = model.Fare;
            booking.Vehicle = model.Vehicle;
            booking.Depature_Time = model.Depature_Time;
            booking.Address = model.Address;
            context.SaveChanges();

            return RedirectToAction("Bookingdetails/" + booking.Id.ToString());

        }

        [HttpGet]
        public IActionResult Bookingdetails(Guid Id)
        {
            BookingDetailsViewModel bookingDetailsViewModel = new BookingDetailsViewModel();
            bookingDetailsViewModel.id = Id;
            return View(bookingDetailsViewModel);
        }

        [HttpPost]
        public IActionResult Bookingdetails(BookingDetailsViewModel model)
        {
            Booking booking = context.Bookings.Find(model.id);
            booking.First_Name = model.First_Name;
            booking.Last_Name = model.Last_Name;
            booking.PhoneNumber = model.PhoneNumber;
            booking.Email = model.Email;
            booking.Gender = model.Gender;
            booking.Age = model.Age;
            booking.Prefered_Seat = model.Prefered_Seat;

            context.SaveChanges();
            HttpContext.Session.SetString("id", model.id.ToString());


            return RedirectToAction("summary/" + booking.Id.ToString());
        }

        public IActionResult Summary(Guid id)
        {

            Booking booking = context.Bookings.Find(id);
            SuccessViewModel successViewModel = new SuccessViewModel();
            successViewModel.First_Name = booking.First_Name;
            successViewModel.Last_Name = booking.Last_Name;
            successViewModel.PhoneNumber = booking.PhoneNumber;
            successViewModel.Email = booking.Email;
            successViewModel.Address = booking.Address;
            successViewModel.Age = booking.Age;
            successViewModel.Age = booking.Depature_Time;
            successViewModel.Fare = booking.Fare;
            successViewModel.From = booking.From;
            successViewModel.To = booking.To;
            successViewModel.Motor_park = booking.Motor_park;
            successViewModel.Prefered_Seat = booking.Prefered_Seat;
            successViewModel.Travel_Date = booking.Travel_Date;
            successViewModel.Depature_Time = booking.Depature_Time;
            successViewModel.Vehicle = booking.Vehicle;



            return View(successViewModel);
        }

        public IActionResult Verify(string id)
        {
            string str_id = HttpContext.Session.GetString("id");
            Guid guid = new Guid(str_id);

            //call api to verify payment here...........


            //if successful save transref here.
            Booking booking = context.Bookings.Find(guid);
            booking.Payment_Ref = id;
            context.SaveChanges();

            //View model for status view.
            VerifyViewModel verifyViewModel = new VerifyViewModel();

            verifyViewModel.First_Name = booking.First_Name;
            verifyViewModel.Last_Name = booking.Last_Name;
            verifyViewModel.PhoneNumber = booking.PhoneNumber;
            verifyViewModel.Email = booking.Email;
            verifyViewModel.Address = booking.Address;
            verifyViewModel.Age = booking.Age;
            verifyViewModel.Payment_Ref = booking.Payment_Ref;
            verifyViewModel.Age = booking.Depature_Time;
            verifyViewModel.Fare = booking.Fare;
            verifyViewModel.From = booking.From;
            verifyViewModel.To = booking.To;
            verifyViewModel.Motor_park = booking.Motor_park;
            verifyViewModel.Prefered_Seat = booking.Prefered_Seat;
            verifyViewModel.Travel_Date = booking.Travel_Date;
            verifyViewModel.Depature_Time = booking.Depature_Time;
            verifyViewModel.Vehicle = booking.Vehicle;

            return View(verifyViewModel);
        }

        public IActionResult Createaccountresult()
        {
            return View();
        }

        public IActionResult Feedback()
        {
            return View();
        }

        public IActionResult Complaint()
        {
            return View();
        }

        public IActionResult ConfirmBooking()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Status()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Status(StatusViewModel model)
        {
            List<Booking> a_Payment_Ref = context.Bookings.Where(u => u.Payment_Ref == model.transref).ToList();

            return RedirectToAction("Statusresult/" + a_Payment_Ref.First().Id.ToString());
        }

        public IActionResult Statusresult(Guid id)
        {
            Booking booking = new Booking();
            booking = context.Bookings.Find(id);
            return View(booking);

        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        public IActionResult Faq()
        {
            return View();
        }

        public IActionResult Affiliate()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Developer()
        {
            return View();
        }
    }
}
