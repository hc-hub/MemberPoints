using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemberPoint.Entity.POCOModel;
using MemberPoint.Entity.ViewModel;
using MemberPoint.Common;
using System.Data.SqlClient;

namespace MemberPoint.Business
{
    public class MemCardsService : BaseService<MemCards>
    {
        #region 列表查询
        /// 查询列表信息
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public OperateResult GetMemCards(GetPagedMemberCardListViewModel viewModel)
        {
            var query = PredicateExtensions.True<MemCards>();
            if (!string.IsNullOrWhiteSpace(viewModel.Name))
            {
                query = query.And(e => e.MC_Name == viewModel.Name);
            }
            int rowCount = 0;
            var pageData = GetList(viewModel.page, viewModel.rows, ref rowCount, query, e => e.MC_ID, true)
                .Select(e => new MemberCardListViewModel
                {
                    CardId = e.MC_CardID,
                    CardLevelName = e.CardLevels.CL_LevelName,
                    CreateTime = (DateTime)e.MC_CreateTime,
                    Id = e.MC_ID,
                    Mobile = e.MC_Mobile,
                    Name = e.MC_Name,
                    Point = (int)e.MC_Point,
                    Sex = ((SexTypeEnum)e.MC_Sex).ToString(),
                    State = ((CardStateTypeEnum)e.MC_State).ToString(),
                    TotalMoney = (float)e.MC_TotalMoney,
                    Money = (float)e.MC_Money
                }).ToList();
            var pageViewModel = new DataGridViewModel { total = rowCount, rows = pageData };
            return new OperateResult(ResultStatus.Success, "", pageViewModel);
        }
        #endregion
        #region 新增
        /// <summary>
        /// 添加会员
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public OperateResult Create(MemberCardEditViewModel viewModel)
        {
            var model = new MemCards
            {
                CL_ID = viewModel.CardLevelId,
                MC_BirthdayType = (byte)viewModel.BirthdayType,
                MC_Birthday_Day = viewModel.BirthdayDay,
                MC_Birthday_Month = viewModel.BirthdayMonth,
                MC_CardID = viewModel.CardId,
                MC_CreateTime = DateTime.Now,
                MC_IsPast = viewModel.IsPast,
                MC_IsPointAuto = viewModel.IsPointAuto,
                MC_Mobile = viewModel.Mobile,
                MC_Money = (float)viewModel.Money,
                MC_Name = viewModel.Name,
                MC_Password = viewModel.Password,
                MC_PastTime = Convert.ToDateTime(viewModel.PastTime),
                MC_Point = viewModel.Point,
                MC_Sex = (int)viewModel.Sex,
                MC_State = (int)viewModel.CardState,
                MC_RefererCard = viewModel.RefererCard,
            };

            //var refererResult = GetRefererInfo(model.MC_RefererCard);
            //if (refererResult.ResultStatus == ResultStatus.Success)
            //{
            //    model.MC_RefererName = ((MemCards)refererResult.Data).MC_Name;
            //    model.MC_RefererID = ((MemCards)refererResult.Data).MC_ID;
            //}
            //else
            //{
            //    return new OperateResult(ResultStatus.Error,refererResult.Msg);
            //}

            //判断推荐人是否存在
            if (!string.IsNullOrWhiteSpace(model.MC_RefererCard))
            {
                var referer = Find(e => e.MC_CardID == model.MC_RefererCard);
                if (referer != null)
                {
                    model.MC_RefererName = referer.MC_Name;
                    model.MC_RefererID = referer.MC_ID;
                }
                else
                {
                    return new OperateResult(ResultStatus.Error, "您输入的推荐人不存在");
                }
            }

            model.S_ID = 2;
            model.MC_TotalCount = 0;
            model.MC_TotalMoney = 0;
            model.MC_OverCount = 0;

            if (Add(model))
            {
                return new OperateResult(ResultStatus.Success, "会员创建成功");
            }
            else
            {
                return new OperateResult(ResultStatus.Success, "网络繁忙，请稍候重试");
            }
        }
        #endregion
        #region 修改
        /// <summary>
        /// 更新会员信息
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public OperateResult Update(MemberCardEditViewModel viewModel)
        {
            //1.根据id获取当前要编辑的会员

            var model = Find(e => e.MC_ID == viewModel.Id);
            if (model == null)
                return new OperateResult(ResultStatus.Error, "当前会员未找到");

            //2.为会员的属性赋值
            model.CL_ID = viewModel.CardLevelId;
            model.MC_BirthdayType = (byte)viewModel.BirthdayType;
            model.MC_Birthday_Day = viewModel.BirthdayDay;
            model.MC_Birthday_Month = viewModel.BirthdayMonth;
            model.MC_CardID = viewModel.CardId;
            model.MC_CreateTime = DateTime.Now;
            model.MC_IsPast = viewModel.IsPast;
            model.MC_IsPointAuto = viewModel.IsPointAuto;
            model.MC_Mobile = viewModel.Mobile;
            model.MC_Money = (float)viewModel.Money;
            model.MC_Name = viewModel.Name;

            if (!string.IsNullOrWhiteSpace(viewModel.Password) && !string.IsNullOrWhiteSpace(viewModel.PasswordConfirm))
            {
                if (viewModel.Password != viewModel.PasswordConfirm)
                    return new OperateResult(ResultStatus.Error, "两次输入的密码不一致");
                model.MC_Password = viewModel.Password;
            }
            model.MC_PastTime = Convert.ToDateTime(viewModel.PastTime);
            model.MC_Point = viewModel.Point;
            model.MC_Sex = (int)viewModel.Sex;
            model.MC_State = (int)viewModel.CardState;
            model.MC_RefererCard = viewModel.RefererCard;

            //判断推荐人是否存在
            if (!string.IsNullOrWhiteSpace(model.MC_RefererCard))
            {
                var referer = Find(e => e.MC_CardID == model.MC_RefererCard);
                if (referer != null)
                {
                    model.MC_RefererName = referer.MC_Name;
                    model.MC_RefererID = referer.MC_ID;
                }
                else
                {
                    return new OperateResult(ResultStatus.Error, "您输入的推荐人不存在");
                }
            }


            if (Update(model))
            {
                return new OperateResult(ResultStatus.Success, "会员更新成功");
            }
            else
            {
                return new OperateResult(ResultStatus.Success, "网络繁忙，请稍候重试");
            }

        }
        #endregion
        #region 删除
        /// <summary>
        /// 删除会员卡
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OperateResult DeleteMemberCard(int id)
        {
            //1.判断要删除的数据是否存在
            var model = Find(e => e.MC_ID == id);
            //2.如果存在则删除，否则提示该记录不存在
            if (model == null)
            {
                return new OperateResult(ResultStatus.Error, "您要删除的会员不存在");
            }
            if (Delete(model))
            {
                return new OperateResult(ResultStatus.Success, "会员删除成功");
            }
            else
            {
                return new OperateResult(ResultStatus.Error, "网络繁忙，请稍候重试");
            }

        }
        #endregion
        #region 根据Id查询会员信息
        /// <summary>
        /// 根据Id查询会员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OperateResult GetMemberCardInfo(int id)
        {
            var model = Find(e => e.MC_ID == id);
            if (model == null)
                return new OperateResult(ResultStatus.Error, "当前会员未找到");
            var viewModel = new MemberCardEditViewModel()
            {
                Id = model.MC_ID,
                BirthdayDay = (int)model.MC_Birthday_Day,
                BirthdayMonth = (int)model.MC_Birthday_Month,
                BirthdayType = (int)model.MC_BirthdayType,
                CardId = model.MC_CardID,
                CardLevelId = (int)model.CL_ID,
                IsPast = (bool)model.MC_IsPast,
                IsPointAuto = (bool)model.MC_IsPointAuto,
                Mobile = model.MC_Mobile,
                Money = (decimal)model.MC_Money,
                TotalMoney = (decimal)model.MC_TotalMoney,
                Name = model.MC_Name,
                PastTime = model.MC_PastTime.Value.ToString("yyyy-MM-dd"),
                Point = (int)model.MC_Point,
                RefererCard = model.MC_RefererCard,
                RefererName = model.MC_RefererName,
                Sex = (SexTypeEnum)model.MC_Sex,
                CardState = (CardStateTypeEnum)model.MC_State
            };
            return new OperateResult(ResultStatus.Success, "", viewModel);
        }
        #endregion
        #region 根据会员卡号查找推荐人
        /// <summary>
        /// 根据会员卡号查找推荐人
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public OperateResult GetRefererInfo(string cardId)
        {
            if (!string.IsNullOrWhiteSpace(cardId))
            {
                var model = Find(e => e.MC_CardID == cardId);
                if (model != null)
                {
                    var referer = new MemberCardEditViewModel()
                    {
                        Id = model.MC_ID,
                        BirthdayDay = (int)model.MC_Birthday_Day,
                        BirthdayMonth = (int)model.MC_Birthday_Month,
                        BirthdayType = (int)model.MC_BirthdayType,
                        CardId = model.MC_CardID,
                        CardLevelId = (int)model.CL_ID,
                        IsPast = (bool)model.MC_IsPast,
                        IsPointAuto = (bool)model.MC_IsPointAuto,
                        Mobile = model.MC_Mobile,
                        Money = (decimal)model.MC_Money,
                        TotalMoney = (decimal)model.MC_TotalMoney,
                        Name = model.MC_Name,
                        PastTime = model.MC_PastTime.Value.ToString("yyyy-MM-dd"),
                        Point = (int)model.MC_Point,
                        RefererCard = model.MC_RefererCard,
                        RefererName = model.MC_RefererName,
                        Sex = (SexTypeEnum)model.MC_Sex,
                        CardState = (CardStateTypeEnum)model.MC_State
                    };
                    return new OperateResult(ResultStatus.Success, "", referer);
                }
                else
                {
                    return new OperateResult(ResultStatus.Error, "您输入的推荐人不存在");
                }
            }
            return new OperateResult(ResultStatus.Error, "您输入的会员卡号不能为空");
        }
        #endregion
        #region 会员转账
        /// <summary>
        /// 会员转账
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public OperateResult TransferMoney(TransferMoneyViewModel viewModel)
        {
            if (viewModel.UserId == 0)
            {
                return new OperateResult(ResultStatus.Error, "转账人ID为空");
            }
            if (string.IsNullOrWhiteSpace(viewModel.FromMemberCardId))
            {
                return new OperateResult(ResultStatus.Error, "转账人卡号为空");
            }
            if (string.IsNullOrWhiteSpace(viewModel.ToMemberCardId))
            {
                return new OperateResult(ResultStatus.Error, "被转账人卡号为空");
            }
            if (viewModel.TransferMoney == 0)
            {
                return new OperateResult(ResultStatus.Error, "转账金额为0");
            }
            if (string.IsNullOrWhiteSpace(viewModel.Remark))
            {
                viewModel.Remark = "";
            }
            SqlParameter[] pams = {
                new SqlParameter("@userId",viewModel.UserId),
                new SqlParameter("@fromMemberCardId",viewModel.FromMemberCardId),
                new SqlParameter("@toMemberCardId",viewModel.ToMemberCardId),
                new SqlParameter("@transferMoney",viewModel.TransferMoney),
                new SqlParameter("@remark",viewModel.Remark),
                new SqlParameter("@errorMsg",System.Data.SqlDbType.NVarChar,128),
            };
            //指定输出参数
            pams[5].Direction = System.Data.ParameterDirection.Output;
            try
            {
                db.Database.ExecuteSqlCommand("EXEC dbo.SP_TransferMoney @userId,@fromMemberCardId,@toMemberCardId,@transferMoney,@remark,@errorMsg output", pams);
                //如果errorMsg有值，说明执行存储过程判断逻辑有问题
                if (!string.IsNullOrWhiteSpace(pams[5].Value.ToString()))
                {
                    return new OperateResult(ResultStatus.Error, pams[5].Value.ToString());
                }
                else
                {
                    return new OperateResult(ResultStatus.Success, "转账成功");
                }
            }
            catch (Exception ex)
            {
                return new OperateResult(ResultStatus.Error, ex.Message);
            }
            //https://www.cnblogs.com/blogs2014/p/5310093.html 错误级别解释
        }
        #endregion
        #region 锁定、挂失
        public OperateResult MemberLock(MemberCardEditViewModel viewModel)
        {
            //1.根据id获取当前要编辑的会员

            var model = Find(e => e.MC_ID == viewModel.Id && e.MC_CardID == viewModel.CardId);
            if (model == null)
                return new OperateResult(ResultStatus.Error, "当前会员未找到");

            //2.为会员的属性赋值
            model.MC_State = (int)viewModel.CardState;
            if (Update(model))
            {
                return new OperateResult(ResultStatus.Success, "更新状态成功");
            }
            else
            {
                return new OperateResult(ResultStatus.Error, "网络繁忙，请稍候重试");
            }

        }
        #endregion
        #region 会员换卡

        #endregion

    }
}
