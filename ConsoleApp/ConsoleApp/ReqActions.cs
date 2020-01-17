
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    /// <summary>
    /// 用以所有请求表单的父类，
    /// 在其子类中定义成员变量以及实现
    /// 所有请求有一个发起人，及一个或多个审核
    /// 所有请求都至少包括发起人编号及物品编号
    /// </summary>
    abstract partial class ReqInfo
    {
        /// <summary>
        /// 将请求按规则转为字符串，方便发送
        /// </summary>
        /// <returns></returns>
        abstract public String GetInfo();
        /// <summary>
        /// 相应请求通过后的后续操作
        /// </summary>
        /// <param name="actor">操作人员编号</param>
        abstract public void Access(String actor);
        /// <summary>
        /// 相应请求未通过的后续操作
        /// </summary>
        /// <param name="actor">操作人员编号</param>
        abstract public void Refuse(String actor);
        /// <summary>
        /// 用字符串构造实体,通过字符串进行传参，对接webget方法
        /// </summary>
        /// <param name="info">存放所有参数及信息</param>
        public ReqInfo(String info)
        {

        }
        public ReqInfo() { }

    }
    /// <summary>
    /// --采购入库流程请求表单--
    /// 由采购员（OI）提交，监管员初审，经理终审
    /// 多于一个审核人，添加一个
    /// </summary>
    partial class PurchaseReq : ReqInfo
    {
        /// <summary>
        /// 采购入库收据单号
        /// </summary>
        private String receipt_id;
        private DateTime date;
        /// <summary>
        /// 最终审核人员（Work cell经理）
        /// </summary>
        private String fina_approver;
        /// <summary>
        /// 通过字符串的构造函数
        /// </summary>
        /// <param name="info"></param>
        public PurchaseReq(String info):base(info)
        {

        }
        /// <summary>
        /// 默认构造
        /// </summary>
        public PurchaseReq() { }
        public override void Access(String actor)
        {
            throw new NotImplementedException();
        }

        public override string GetInfo()
        {
            throw new NotImplementedException();
        }

        public override void Refuse(String actor)
        {
            throw new NotImplementedException();
        }

    }
    /// <summary>
    /// --进出库流程表单--
    /// 由产线员工申请，仓管员确认
    /// 在确认扫描方式自动录入后，亦应有自动通过选项
    /// 一般情况均应通过请求，即无不通过
    /// </summary>
    partial class ImExReq : ReqInfo
    {
        private String production_line;
        private DateTime date;
        /// <summary>
        /// 通过字符串的构造函数
        /// </summary>
        /// <param name="info"></param>
        public ImExReq(String info) : base(info)
        {

        }
        /// <summary>
        /// 默认构造
        /// </summary>
        public ImExReq() { }
        public override void Access(string actor)
        {
            throw new NotImplementedException();
        }

        public override string GetInfo()
        {
            throw new NotImplementedException();
        }

        public override void Refuse(string actor)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// --维修请求单--
    /// 由初级用户（OI）发起，高级用户（OII）处理后关闭
    /// </summary>
    partial class RepairReq : ReqInfo
    {
        /// <summary>
        /// 故障描述
        /// </summary>
        private String describe;
        /// <summary>
        /// 通过字符串的构造函数
        /// </summary>
        /// <param name="info"></param>
        public RepairReq(String info) : base(info)
        {

        }
        /// <summary>
        /// 默认构造
        /// </summary>
        public RepairReq() { }
        public override void Access(string actor)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string GetInfo()
        {
            throw new NotImplementedException();
        }

        public override void Refuse(string actor)
        {
            throw new NotImplementedException();
        }

    }
    /// <summary>
    /// --报废申请单--
    /// 由高级用户（OII）发起，监管员初审，Manage终审
    /// </summary>
    partial class ScrapReq : ReqInfo
    {
        /// <summary>
        /// 物品寿命计数
        /// </summary>
        private String count;
        /// <summary>
        /// 报废原因
        /// </summary>
        private String reason;
        /// <summary>
        /// 最终审核人员（Work cell经理）
        /// </summary>
        private String fina_approver;
        public ScrapReq(String info) : base(info)
        {

        }
        public override void Access(string actor)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string GetInfo()
        {
            throw new NotImplementedException();
        }

        public override void Refuse(string actor)
        {
            throw new NotImplementedException();
        }
    }
}
