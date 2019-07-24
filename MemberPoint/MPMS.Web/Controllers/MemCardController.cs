using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MemberPoint.Entity.POCOModel;
using MemberPoint.Entity.ViewModel;
using MemberPoint.Common;
using MemberPoint.Business;

namespace MPMS.Web.Controllers
{
    //[Authorize]
    public class MemCardController : Controller
    {
        private MemCardsService _MemberCardService = new MemCardsService();
        private CardLevelService _CardLevelService = new CardLevelService();
        // GET: MemCard
        #region 列表查询
        //[Authorize]
        public ActionResult Index()
        {
            //1.获取会员等级信息
            var cardLevels = _CardLevelService.GetList(e => true).Select(e => new SelectListItem() { Text = e.CL_LevelName, Value = e.CL_ID.ToString() }).ToList();
            cardLevels.Insert(0, new SelectListItem() { Text = "全部", Value = "0" });
            ViewBag.CardLevel = cardLevels;
            //2.获取状态信息
            var cardTypeList = EnumHelper.EnumListDic<CardStateTypeEnum>("全部", "0");
            var cardTypeSelectList = new SelectList(cardTypeList, "value", "key");
            ViewBag.CardTypeSelectList = cardTypeSelectList;
            return View();
        }
        public ActionResult GetPagedMemberCardList(GetPagedMemberCardListViewModel pageModel)
        {
            var result = _MemberCardService.GetMemCards(pageModel);
            return Json(result.Data);
            #region 原本加载页面     
            //using (var db = new MemberPointModel())
            //{
            //    var query = db.MemCards.AsQueryable();
            //    if (!string.IsNullOrEmpty(pageModel.Mobile))
            //    {
            //        query = query.Where(e => e.MC_Mobile.Contains(pageModel.Mobile));
            //    }
            //    if (!string.IsNullOrEmpty(pageModel.Name))
            //    {
            //        query = query.Where(e => e.MC_Name.Contains(pageModel.Name));
            //    }
            //    if (pageModel.State != 0)
            //    {
            //        query = query.Where(e => e.MC_Name.Contains(pageModel.Name));
            //    }
            //    int rowsCount = query.Count();
            //    pageModel.page = pageModel.page - 1 < 1 ? 1 : pageModel.page;
            //    var mcList = query.OrderBy(e => e.MC_ID).Skip((pageModel.page - 1) * pageModel.rows).Take(pageModel.rows)
            //    .Select(e => new MemberCardListViewModel()
            //    {
            //        CardId = e.MC_CardID,
            //        CardLevelName = e.CardLevels.CL_LevelName,
            //        CreateTime = (DateTime)e.MC_CreateTime,
            //        Id = e.MC_ID,
            //        Mobile = e.MC_Mobile,
            //        Name = e.MC_Name,
            //        Point = (int)e.MC_Point,
            //        Sex = ((SexTypeEnum)e.MC_Sex).ToString(),
            //        State = ((CardStateTypeEnum)e.MC_State).ToString(),
            //        TotalMoney = (float)e.MC_TotalMoney
            //    }).ToList();
            //    var dataGrid = new DataGridViewModel { total = rowsCount, rows = mcList };
            //    return Json(dataGrid);
            //}
            #endregion
        }
        #endregion
        #region 新增
        /// <summary>
        /// 修改添加视图加载
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id = 0)
        {
            var cardLevels = _CardLevelService.GetList(e => true).Select(e => new SelectListItem() { Text = e.CL_LevelName, Value = e.CL_ID.ToString() }).ToList();
            cardLevels.Insert(0, new SelectListItem() { Text = "全部", Value = "0" });
            ViewBag.CardLevel = cardLevels;
            if (id > 0)
            {
                //编辑
                var result = _MemberCardService.GetMemberCardInfo(id);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    return View(result.Data);
                }
                else
                {
                    //返回错误消息
                    return Content(result.Msg);
                    //return Redirect("友好页面")
                }
            }
            else
            {
                //新增
                return View();
            }
            #region 原本添加修改加载
            //using (var db = new MemberPointModel())
            //{
            //    var cardLevels = db.CardLevels.Select(e => new SelectListItem() { Text = e.CL_LevelName, Value = e.CL_ID.ToString() }).ToList();
            //    cardLevels.Insert(0, new SelectListItem() { Text = "全部", Value = "0" });
            //    ViewBag.CardLevel = cardLevels;
            //    if (id > 0)
            //    {
            //        //编辑
            //        var model = db.MemCards.FirstOrDefault(e => e.MC_ID == id);
            //        if (model != null)
            //        {
            //            var viewModel = new MemberCardEditViewModel()
            //            {
            //                Id = model.MC_ID,
            //                BirthdayDay = (int)model.MC_Birthday_Day,
            //                BirthdayMonth = (int)model.MC_Birthday_Month,
            //                BirthdayType = (int)model.MC_BirthdayType,
            //                CardId = model.MC_CardID,
            //                CardLevelId = (int)model.CL_ID,
            //                IsPast = (bool)model.MC_IsPast,
            //                IsPointAuto = (bool)model.MC_IsPointAuto,
            //                Mobile = model.MC_Mobile,
            //                Money = (decimal)model.MC_Money,
            //                Name = model.MC_Name,
            //                PastTime = model.MC_PastTime.Value.ToString("yyyy-MM-dd"),
            //                Point = (int)model.MC_Point,
            //                RefererCard = model.MC_RefererCard,
            //                RefererName = model.MC_RefererName,
            //                Sex = (SexTypeEnum)model.MC_Sex,
            //                CardState = (CardStateTypeEnum)model.MC_State,
            //                RefererID = (int)model.MC_RefererID
            //            };
            //            return View(viewModel);
            //        }
            //        else
            //        {
            //            return Content("该会员不存在");
            //        }
            //    }
            //    else
            //    {
            //        //新增
            //        return View();
            //    }
            //}
            #endregion

        }
        [HttpPost]
        public ActionResult Create(MemberCardEditViewModel viewModel)
        {
            var result = _MemberCardService.Create(viewModel);
            return Json(result);
            #region 原本添加
            //try
            //{
            //    var db = new MemberPointModel();
            //    var model = new MemCards()
            //    {

            //    };
            //    db.MemCards.Add(model);
            //    OperateResult result;
            //    if (db.SaveChanges() > 0)
            //    {
            //        //result.ResultStatus = ResultStatus.Success;
            //        //result.Msg = "添加会员成功";
            //        result = new OperateResult(ResultStatus.Success, "成功");
            //    }
            //    else
            //    {
            //        //result.ResultStatus = ResultStatus.Error;
            //        //result.Msg = "添加会员失败";
            //        result = new OperateResult(ResultStatus.Error, "失败");
            //    }
            //    return Json(result);
            //}
            //catch
            //{
            //    return View();
            //}
            #endregion
        }
        #endregion
        #region 修改
        [HttpPost]
        public ActionResult Edit(MemberCardEditViewModel viewModel)
        {
            var result = _MemberCardService.Update(viewModel);
            return Json(result);
        }
        #endregion
        #region 删除
        public ActionResult Delete(int id)
        {
            var result = _MemberCardService.DeleteMemberCard(id);
            return Json(result);
        }
        #endregion
        #region 根据会员ID查询推荐人姓名
        public ActionResult GetReferer(string id)
        {
            var result = _MemberCardService.GetRefererInfo(id);
            return Json(result);
        }
        #endregion
        #region 锁定挂失会员卡
        public ActionResult Lock(int id)
        {
            var model = _MemberCardService.GetMemberCardInfo(id);
            return View(model.Data);
        }
        [HttpPost]
        public ActionResult Lock(MemberCardEditViewModel m)
        {
            //问题：卡片过期时间不设置时怎么解决 
            return Json(_MemberCardService.MemberLock(m));

        }
        #endregion
        #region 会员转账
        public ActionResult TransferL(int id)
        {
            ViewData["MemCard"] = _MemberCardService.GetMemberCardInfo(id).Data;
            return View();
        }
        [HttpPost]
        public ActionResult TransferL(TransferMoneyViewModel t)
        {
            t.UserId = 1;
            return Json(_MemberCardService.TransferMoney(t));
            // return Content("<script>window.parent.$('#dlg').dialog('close');window.parent.$('#dg').datagrid('reload');window.parent.$.messager.alert('提示','" + s + "','info');</script>");
        }
        #endregion
    }
}
