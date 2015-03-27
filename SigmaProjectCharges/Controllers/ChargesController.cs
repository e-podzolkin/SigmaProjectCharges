using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using BL;

namespace SigmaProjectCharges.Controllers
{
    public class ChargesController : Controller
    {
        //
        // GET: /Charges/

        public ActionResult Index(char search = ' ', int OrderBy = 0)
        {
            BL.Helpers.ChargesHelper helper = new BL.Helpers.ChargesHelper();
            if (search == ' ')
            {
                IEnumerable<BL.ChargesModels.ChargesInfo> charg = helper.GetChargesList(OrderBy);
                return View(charg);
            }
            else
            {
                IEnumerable<BL.ChargesModels.ChargesInfo> sear = helper.GetSearchList(search);
                if (sear != null)
                {
                    return View(sear);
                }
                else
                {
                    ModelState.AddModelError("", Resx.ChargesStrings.nodata);
                    IEnumerable<BL.ChargesModels.ChargesInfo> charg = helper.GetChargesList(OrderBy);
                    return View(charg);
                }
            }
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BL.ChargesModels.ChargesCreate charges)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BL.Helpers.ChargesHelper h = new BL.Helpers.ChargesHelper();
                    h.AddCharges(charges, User.Identity.Name);
                    return RedirectToAction("Index", "Charges");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", @Resx.HomeStrings.errormodel);
            }
            return View(charges);
        }

        [Authorize]
        public ActionResult Edit(int id = 1)
        {
            BL.Helpers.ChargesHelper helper = new BL.Helpers.ChargesHelper();
            BL.ChargesModels.ChargesEdit edit = helper.GetEditList(User.Identity.Name, id);
            if (edit != null)
            {
                return View(edit);
            }
            else
            {
                BL.Helpers.RolesHelper helperRole = new BL.Helpers.RolesHelper();
                if (helperRole.RoleAdmin(User.Identity.Name) == true)
                {
                    BL.ChargesModels.ChargesEdit editAdmin = helper.GetEditAdminList(id);
                    return View(editAdmin);
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BL.ChargesModels.ChargesEdit charges)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    BL.Helpers.ChargesHelper h = new BL.Helpers.ChargesHelper();
                    h.EditCharges(charges);
                    return RedirectToAction("Index", "Charges");
                }

            }
            catch (DataException)
            {
                ModelState.AddModelError("", @Resx.HomeStrings.errormodel);
            }
            return View(charges);
        }

        [Authorize]
        public ActionResult Delete(int id = 1)
        {
            BL.Helpers.ChargesHelper helper = new BL.Helpers.ChargesHelper();
            BL.ChargesModels.ChargesDelete delete = helper.GetDeleteList(User.Identity.Name, id);
            if (delete != null)
            {
                return View(delete);
            }
            else
            {
                BL.Helpers.RolesHelper helperRole = new BL.Helpers.RolesHelper();
                if (helperRole.RoleAdmin(User.Identity.Name) == true)
                {
                    BL.ChargesModels.ChargesDelete delAdmin = helper.GetDeleteAdminList(id);
                    return View(delAdmin);
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    BL.Helpers.ChargesHelper h = new BL.Helpers.ChargesHelper();
                    h.DeleteCharges(id);
                }

            }
            catch (DataException)
            {
                ModelState.AddModelError("", @Resx.HomeStrings.errormodel);
            }
            return RedirectToAction("Index", "Charges");
        }

        [HttpPost]
        public ActionResult _Search(BL.ChargesModels.ChargesInfo search)
        {
            return RedirectToAction("Index", "Charges", search);
        }

        [HttpPost]
        public ActionResult _SearchDate(DateTime search, int OrderBy = 0)
        {
            BL.Helpers.ChargesHelper helper = new BL.Helpers.ChargesHelper();
            IEnumerable<BL.ChargesModels.ChargesInfo> sear = helper.GetSearchDateList(search);
            if (sear != null)
            {
                return View(sear);
            }
            else
            {
                ModelState.AddModelError("", Resx.ChargesStrings.nodata);
                IEnumerable<BL.ChargesModels.ChargesInfo> charg = helper.GetChargesList(OrderBy);
                return View(charg);
            }
        }
    }
}

     
