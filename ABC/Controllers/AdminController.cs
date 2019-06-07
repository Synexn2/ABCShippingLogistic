using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Import Required Name Spaces
using ABCIntegration;
using ABCIntegration.DAO;
using ABCService.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ABC.Models;



namespace ABC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        
        //Variable Declarations
        private ABCParcelService _parcelService;
        private ABCLibrary _abcLib;
        private Parcel _parcelRecording;
        private ABC.Models.ApplicationDbContext _DBcontext;
        private UserBranch _userBranch;
        private Branch _branchRecording;
        
        
        /// Application DB context
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        /// User manager - attached to application DB context
        protected UserManager<ApplicationUser> UserManager { get; set; }



        public AdminController()
        {
            
            //Object Initialisation
            _parcelService = new ABCParcelService();
            _abcLib = new ABCLibrary();
            _DBcontext = new ABC.Models.ApplicationDbContext();
            _userBranch = new UserBranch();
            _branchRecording = new Branch();

            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
    
        }



        /**********************Edit Parcel Implementation Begins************************************************/
        //Implement an action result
        //Action name: EditParcel
        //Parameter type: int
        //Parameter name: Parcel_Id
        //Return type: View
        //Submission: Required for Assignment 2
        //Date; 12/03/2015
        [HttpGet]
        public ActionResult EditParcel(int Parcel_Id)
        {
            ViewBag.Branch_List = _abcLib.PopulateBranchListItem();
            _parcelRecording = new Parcel();
            _parcelRecording = _parcelService.GetParcel(Parcel_Id);
            return View(_parcelRecording);
        }

        [HttpPost]
        public ActionResult EditParcel(Parcel recording)
        {

            try
            {
                ViewBag.Branch_List = _abcLib.PopulateBranchListItem();
                _parcelService.EditParcel(recording);
                return RedirectToAction("DisplayParcels", "Home");
            }
            catch
            {
                return View();
            }
        }
        /**********************Edit Parcel Implementation Ends************************************************/

        /**********************Delete Parcel Implementation Begins************************************************/
        //To Implement
        //Method annotation: [HttpGet]
        //Method: Public
        //Return type; ActionResult
        //Method name: DeleteParcel
        //parameter type: Parcel
        //Parameter name: Parcel_Id
        //Remark: The action is to load the music recording to be deleted to seek confirmation
        [HttpGet]
        public ActionResult DeleteParcel(int Parcel_Id)
        {
            _parcelRecording = new Parcel();
            _parcelRecording = _parcelService.GetParcel(Parcel_Id);
            return View(_parcelRecording);
        }



        //To Implement
        //Method annotation: [HttpPost]
        //Method: Public
        //Return type; ActionResult
        //Method name: DeleteParcel
        //parameter type: Parcel
        //Parameter name: Parcel_Id
        //Remark: The action is to load the music recording to be deleted to seek confirmation
        [HttpPost]
        public ActionResult DeleteParcel(Parcel Recording)
        {
            _parcelRecording = new Parcel();
            _parcelRecording = Recording;
            _parcelRecording = _parcelService.GetParcel(_parcelRecording.parcel_id);
            _parcelService.DeleteParcel(_parcelRecording);
            //return RedirectToAction(_parcelRecording.Genre);DisplayParcels
            return RedirectToAction("DisplayParcels", "Home");
        }
        /**********************Delete Parcel Implementation Ends************************************************/

        /**********************Create New Parcel Implementation Begins************************************************/
        //To implement
        //Method: Public
        //Return type: ActionResult
        //MethodName: NewParcel
        //Parameter type: string
        //Parameter name: branch_code
        //Return a View, passing nothing
        //Start Date: 11-03-2015
        //[Authorize(Roles = "Admin")]
        [Authorize(Roles = "Admin, User, Staff, Remote Branch")]
        public ActionResult NewParcel(string branch_code)
        {
            ViewBag.Branch_List = _abcLib.PopulateBranchListItem();
            return View();

        }

        
        
        //POST: Admin/NewParcel
        //To implement
        //Method: Public
        //Return type: ActionResult
        //MethodName: NewParcel
        //Parameter type: Parcel
        //Parameter name: New_Parcel_Record
        //Return a View and Redirect passing branch_code
        //Start Date: 11-03-2015
        [HttpPost]
        public ActionResult NewParcel(Parcel New_Parcel_Record)
        {
            var _loginUser = UserManager.FindById(User.Identity.GetUserId());
            try
            {
                New_Parcel_Record.date_create = DateTime.Now;
                New_Parcel_Record.creator_id = _loginUser.UserName;
                _parcelService.CreateParcel(New_Parcel_Record);
                return RedirectToAction("../Home/DisplayParcels");
            }
            catch
            {
                return View();
            }
            
        }
        /**********************Create New Parcel Implementation Ends************************************************/


        /**********************Tracking Management Implementation Begins************************************************/
        //Implement an action result
        //Action name: AddTrackingId
        //Parameter type: int
        //Parameter name: Parcel_Id
        //Return type: View
        //Submission: Required for Assignment 3
        //Date; 20/04/2015

        //public string Selected_Branch_Code { get; set; }

        [HttpGet]
        [Authorize(Roles = "Admin, Staff, Remote Branch")]
        public ActionResult AddTrackingId(int Parcel_Id)
        {
            _parcelRecording = new Parcel();
            _parcelRecording = _parcelService.GetParcel(Parcel_Id);
            return View(_parcelRecording);
        }


        [HttpPost]
        public ActionResult AddTrackingId(Parcel recording)
        {
            try
            {
                _parcelService.AddParcelTrackingId(recording);
                return RedirectToAction("DisplayParcels", "Home");
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        [Authorize(Roles = "Admin, Staff, Remote Branch")]
        public ActionResult LogParcelMovement(string Parcel_Id, string Tracking_Id)
        {
            ViewBag.Parcel_Id = Parcel_Id;
            ViewBag.Tracking_Id = Tracking_Id;
            return View(_parcelRecording);
        }


        [HttpPost]
        public ActionResult LogParcelMovement(Parcel_Tracking_Log Log_Record)
        {
            var _loginUser = UserManager.FindById(User.Identity.GetUserId());

            _userBranch = _parcelService.GetUserBranchCode(_loginUser.UserName);
            Log_Record.branch_code = _userBranch.branch_code;
            _branchRecording = _parcelService.GetBranch(Log_Record.branch_code);
            Log_Record.date = DateTime.Now;
            Log_Record.location = _branchRecording.city;
            
            try
            {
                _parcelService.LogParcelMovement(Log_Record);
                //return RedirectToAction("DisplayParcels", "Home");
                return View();
            }
            catch
            {
                return View();
            }
        }






        /**********************Tracking Management Implementation Ends************************************************/


        /**********************ASP.NET Authentication Implementation Begins************************************************/
        [Authorize(Roles = "Admin")]
        public ActionResult GetUsers()
        {
            return View(_DBcontext.Users.ToList());
        }


        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateRole(FormCollection collection)
        {
            try
            {
                _DBcontext.Roles.Add(
                    new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                    {
                        Name = collection["RoleName"]
                    });
                _DBcontext.SaveChanges();
                return RedirectToAction("GetRoles");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetRoles()
        {
            return View(_DBcontext.Roles.ToList());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult ManageUserRoles()
        {
            //populate roles for the view dropdown
            ViewBag.Roles = _abcLib.PopulateRoleListItem();

            //populate users for the view dropdown
            ViewBag.Users = _abcLib.PopulateUserListItem();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public ActionResult ManageUserRoles(string UserName, string RoleName)
        {
            ApplicationUser user = _DBcontext.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var um = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(_DBcontext));
            var idResult = um.AddToRole(user.Id, RoleName);
        
            //populate roles for the view dropdown
            ViewBag.Roles = _abcLib.PopulateRoleListItem();

            //populate users for the view dropdown
            ViewBag.Users = _abcLib.PopulateUserListItem();
            return View("ManageUserRoles");
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult GetRolesForUser()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult GetRolesForUser(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user =
                    _DBcontext.Users.Where(u => u.UserName.Equals
                    (UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var um = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(_DBcontext));
                ViewBag.RolesForThisUser = um.GetRoles(user.Id);
            }
            return View("GetRolesForUserConfirmed");
        }


        /**************************************ASP.NET Authentication Implementation Ends********************************/


        /**********************Branch Management Implementation Begins************************************************/
        //To implement
        //Method: Public
        //Return type: ActionResult
        //MethodName: NewBranch
        //Parameter type: string
        //Return a View, passing nothing
        //Start Date: 21-04-2015
        [Authorize(Roles = "Admin")]
        public ActionResult NewBranch()
        {
            return View();
        }



        //POST: Admin/NewBranch
        //To implement
        //Method: Public
        //Return type: ActionResult
        //MethodName: NewBranch
        //Parameter type: Branch
        //Parameter name: New_Branch_Record
        //Return a View
        //Start Date: 21-04-2015
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult NewBranch(Branch New_Branch_Record)
        {
            try
            {
                _parcelService.CreateBranch(New_Branch_Record);
                return View();
            }
            catch
            {
                return View();
            }

        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetBranches()
        {
            return View(_parcelService.GetBranches());
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult ManageUserBranch()
        {
            //populate roles for the view dropdown
            ViewBag.Branches = _abcLib.PopulateBranchListItem();

            //populate users for the view dropdown
            ViewBag.Users = _abcLib.PopulateUserListItem();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult ManageUserBranch(UserBranch New_UserBranch_Record)
        {
            try
            {
                _parcelService.CreateUserBranch(New_UserBranch_Record);
                return RedirectToAction("../Home/DisplayParcels");
            }
            catch
            {
                return View();
            }
        }

/**********************Branch Management Implementation Ends************************************************/
        [Authorize(Roles = "Admin")]
        public ActionResult Home()
        {
            return View();
        }



       



    }
}