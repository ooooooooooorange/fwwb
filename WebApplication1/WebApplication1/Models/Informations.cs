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
        private String uid { get; set; }
        private UserType type { get; set; }
        private String password { get; set; }
        private ArraySegment<ReqInfo> req_infos { get; set; }
        private String name { get; set; }
    }
    //工夹具类型，具体类型后期添加
    partial class Fixture
    {

    }
    partial class Tool
    {
        private String fid { get; set; }
        private Fixture type { get; set; }
        private String purchase { get; set; }
        private List<String> unloadings { get; set; }
        private List<String> dam_reps { get; set; }
    }

    abstract partial class ReqInfo
    {
        /// <summary>
        /// 工夹具编号
        /// </summary>
        protected String fid { get; set; }
        /// <summary>
        /// 工夹具类别
        /// </summary>
        protected Fixture ftype { get; set; }
        /// <summary>
        /// 工夹具照片，//数据库储存路径
        /// </summary>
        protected List<Image> image;
        /// <summary>
        /// 申请人/领用人编号
        /// </summary>
        protected String applicant { get; set; }
        /// <summary>
        /// 操作人/审批人编号
        /// </summary>
        protected String approver { get; set; }
}
    class Message
    {

    }
}
