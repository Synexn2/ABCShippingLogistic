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
    public class ABCLibrary : Controller
    {

        private ABCParcelService _parcelService;
        private ABC.Models.ApplicationDbContext _DBcontext;
        
        
        public ABCLibrary()
        {
            _parcelService = new ABCParcelService();
            _DBcontext = new ABC.Models.ApplicationDbContext();

        }



        public IEnumerable<SelectListItem> PopulateBranchListItem()
        {
            var _branch_list = _parcelService.GetBranches().ToList().Select(
                rr => new SelectListItem { Value = rr.branch_code.ToString(), Text = rr.addy_line1.ToString() });
            return _branch_list;
        }



        public IEnumerable<SelectListItem> PopulateUserListItem()
        {
            var _userlist = _DBcontext.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
                new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            return _userlist;
        }

        public IEnumerable<SelectListItem> PopulateRoleListItem()
        {
            var _rolelist = _DBcontext.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
                new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            return _rolelist;
        }







    }
}