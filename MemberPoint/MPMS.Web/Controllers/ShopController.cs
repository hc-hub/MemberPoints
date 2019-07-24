using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MemberPoint.Entity.POCOModel;
using MemberPoint.Entity.ViewModel;
using MemberPoint.Common;

namespace MPMS.Web.Controllers
{
    public class ShopController : Controller
    {
        private MemberPointModel db = new MemberPointModel();
        /// <summary>
        /// 列表展示
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var list = db.Shops.Select(e => new ShopListViewModel()
            {
                S_Address = e.S_Address,
                S_Category = ((CategoryTypeEnum)e.S_Category).ToString(),
                S_ContactName = e.S_ContactName,
                S_ContactTel = e.S_ContactTel,
                S_ID = Convert.ToInt32(e.S_Name),
                S_Name = e.S_Name,
                S_Remark = e.S_Remark

            }).ToList();
            return View(list);
        }

        /// <summary>
        /// 详情页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var shopModel = db.Shops.FirstOrDefault(e => e.S_ID == id);
            return View(shopModel);
        }
        #region 添加店铺
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ShopEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var shopModel = new Shops()
                    {
                        S_Address = model.S_Address,
                        S_Category = model.S_Category,
                        S_ContactName = model.S_ContactName,
                        S_ContactTel = model.S_ContactTel,
                        S_Name = model.S_Name,
                        S_Remark = model.S_Remark,
                        S_CreateTime = model.S_CreateTime,
                        S_ID = model.S_ID,
                        S_IsHasSetAdmin = model.S_IsHasSetAdmin
                    };
                    db.Shops.Add(shopModel);
                    if (db.SaveChanges() > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "添加失败");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "请输入的信息有误");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
        #endregion


        #region 修改店铺
        public ActionResult Edit(int id)
        {
            var model = db.Shops.FirstOrDefault(e => e.S_ID == id);
            var editModel = new ShopEditViewModel()
            {
                S_Address = model.S_Address,
                S_Category = model.S_Category,
                S_ContactName = model.S_ContactName,
                S_ContactTel = model.S_ContactTel,
                S_Name = model.S_Name,
                S_Remark = model.S_Remark,
                S_CreateTime = model.S_CreateTime,
                S_ID = model.S_ID,
                S_IsHasSetAdmin = model.S_IsHasSetAdmin
            };
            return View(editModel);
        }

        // POST: Shop/Edit/5
        [HttpPost]
        public ActionResult Edit(ShopEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var shopModel = db.Shops.FirstOrDefault(e => e.S_ID == model.S_ID);
                    if (shopModel != null)
                    {
                        shopModel.S_Address = model.S_Address;
                        shopModel.S_Category = model.S_Category;
                        shopModel.S_ContactName = model.S_ContactName;
                        shopModel.S_ContactTel = model.S_ContactTel;
                        shopModel.S_Name = model.S_Name;
                        shopModel.S_Remark = model.S_Remark;
                        shopModel.S_CreateTime = model.S_CreateTime;
                        shopModel.S_ID = model.S_ID;
                        shopModel.S_IsHasSetAdmin = model.S_IsHasSetAdmin;
                        if (db.SaveChanges() > 0)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "修改失败");
                            return View();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "该店铺不存在");
                        return View();
                    }

                }
                else
                {
                    ModelState.AddModelError("", "请输入的信息有误");
                }
                return View();
            }
            catch
            {
                ModelState.AddModelError("", "报错信息");
                return View();
            }
        }
        #endregion


        #region 删除店铺
        public ActionResult Delete(int id)
        {
            var model = db.Shops.FirstOrDefault(e => e.S_ID == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var model = db.Shops.FirstOrDefault(e => e.S_ID == id);
                if (model != null)
                {
                    db.Shops.Remove(model);
                    if (db.SaveChanges() > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return Content("删除失败");
                    }
                }
                else
                {
                    return Content("该信息不存在或已被删除");
                }
            }
            catch
            {
                return View();
            }
        }
        #endregion

    }
}
