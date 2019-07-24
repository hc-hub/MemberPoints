using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MemberPoint.Entity.ViewModel;
using MemberPoint.Common;
using MemberPoint.Business;

namespace MemberPoint.Controllers
{
    public class MemCardsController : Controller
    {
        private MemCardsService _MemCardsService = new MemCardsService();
        // GET: MemCards
        public ActionResult MenCardsManage()
        {
            return View();
        }
        public ActionResult GetMenCardsList(GetPagedMemberCardListViewModel viewModel)
        {
            var result = _MemCardsService.GetMemCards(viewModel);
            return Json(result.Data);
        }
        // GET: MemCards/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MemCards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemCards/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MemCards/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MemCards/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MemCards/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MemCards/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
