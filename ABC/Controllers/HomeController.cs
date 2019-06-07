using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using ABCIntegration;
using ABCIntegration.DAO;
using ABCService.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ABC.Models;


namespace ABC.Controllers
{
    public class HomeController : Controller
    {
        
        
        private ABCParcelService _parcelService;
        private Parcel _recording; //declare a variable name of type Parcel to be used to create an instance of the parcel class
        /// Application DB context
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        /// User manager - attached to application DB context
        protected UserManager<ApplicationUser> UserManager { get; set; }


        public HomeController()
        {
            _parcelService = new ABCParcelService();
            //_abcLib = new ABCLibrary();
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));


        }

        // GET: Parcel
        [Authorize(Roles = "Admin, Staff, Remote Branch, User")]
        public ActionResult DisplayParcels()
        {
            var _loginUser = UserManager.FindById(User.Identity.GetUserId());

            if (this.User.IsInRole("User") && _loginUser.Roles.Count == 1)
            {
                ViewBag.UserType = "User";
                return View(_parcelService.GetUserParcels(_loginUser.UserName));
            }
            else
            {
                //ViewBag.HeaderMsg = "Display of All Parcels";
                return View(_parcelService.GetParcels());
            }
            
        }



        //To implement
        //Method: Public
        //Return type: ActionResult
        //MethodName: DisplayParcel
        //Parameter type: int
        //Parameter name: Parcel_Id
        //Return a View
        //Start Date: 13-03-2015
        //Submission: Assignment 2
        public ActionResult DisplayParcel(int Parcel_Id)
        {
            _recording = new Parcel();
            _recording = _parcelService.GetParcel(Parcel_Id);

            return View(_recording);
            //return View(_parcelService.GetParcels());
        }



        [HttpGet]
        [Authorize(Roles = "Admin, Staff, Remote Branch, User")]
        public ActionResult TrackParcels(string Tracking_Id)
        {
            //return View();
            return View("ParcelStatus", _parcelService.GetParcelTrackingLog(Tracking_Id));
        }


        [HttpGet]
        public ActionResult TrackParcel()

        {
            return View();
        }


        [HttpPost]
        public ActionResult TrackParcel(string Tracking_Id)
        {
            try
            {
                
                return View("ParcelStatus",_parcelService.GetParcelTrackingLog(Tracking_Id));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Index()
        {
            return View();
        }


    }
}
