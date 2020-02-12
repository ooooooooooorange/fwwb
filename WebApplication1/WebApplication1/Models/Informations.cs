using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Drawing.Image;

namespace WebApplication1.Models
{
    //  用户类型，暂定于以下四种类型
    enum UserType
    {
        OperatorI,
        OperatorII,
        Supervisor,
        Manager,
        Admin,

    }
    partial class User
    {
        public String uid { get; set; }
        public UserType type { get; set; }
        public String password { get; set; }
        public ArraySegment<ReqInfo> req_infos { get; set; }
        public String name { get; set; }
    }
    //工夹具类型，具体类型后期添加
    partial class Fixture
    {
        public int ID { get; set; }
        public int code { get; set; }
        public string name { get; set; }
        public string family_ID { get; set; }
        public string family { get; set; }
        public string[] model { get; set; }
        public string[] part_no { get; set; }
        public int UPL { get; set; }
        public string used_for { get; set; }
        //TODO:疑问：时间点？段？
        public string PM_period { get; set; }
        public string owner { get; set; }
        public DateTime rec_on { get; set; }
        public string rec_by { get; set; }
        public DateTime edit_on { get; set; }
        public string edit_by { get; set; }
        public string workcell { get; set; }
    }
    partial class Tool :Fixture
    {
        public new string code { get; set; }
        public int seq_ID { get; set; }
        public string bill_no { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime reg_date { get; set; }
        public int used_count { get; set; }
        public string location { get; set; }
        //public Fixture type { get; set; }
        public List<String> unloadings { get; set; }
        public List<String> dam_reps { get; set; }
    }

    abstract partial class ReqInfo
    {
        /// <summary>
        /// 工夹具编号
        /// </summary>
        public String fid { get; set; }
        /// <summary>
        /// 工夹具类别
        /// </summary>
        public Tool tool { get; set; }
        /// <summary>
        /// 工夹具照片，//数据库储存路径
        /// </summary>
        public List<Image> image { get; set; }
        /// <summary>
        /// 申请人/领用人编号
        /// </summary>
        public String applicant { get; set; }
        /// <summary>
        /// 操作人/审批人编号
        /// </summary>
        public String approver { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime creatdate { get; set; }
}
    class Message
    {

    }
}
