﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebApplication1.Models.DBinfo;

using Connetion = System.Data.SqlClient.SqlConnection;
using Command = System.Data.SqlClient.SqlCommand;
using DataReader = System.Data.SqlClient.SqlDataReader;

namespace WebApplication1.Models
{
    public class DBinfo
    {
        public const String P = "'";
        public const String DBNAME = "";
        public const String SEVER = "";
        public const String DBUID = "";
        public const String DBPAWD = "";
        public const String CONNSTR =
            "sever= " + SEVER + ";database= " + DBNAME +
            ";uid= " + DBUID + ";pwd= " + DBPAWD;
        /// <summary>
        /// 生成简单SQL选择语句
        /// </summary>
        /// <param name="table_name">选择的表名</param>
        /// <param name="values">where中的限制条件，由行名及限制条见交替组成，故一定为偶数</param>
        /// <returns></returns>
        public static String SqlSelect(String table_name, params String[] values)
        {
            if ((values.Length & 1) == 1)
                return "";
            String ret = "select * from " + table_name + " where ";
            for (int i = 0; i < values.Length; i += 2)
            {
                ret += " " + values[i] + " = " + values[i + 1] + " and ";
            }
            ret = ret.Remove(ret.Length - 4, 4);
            return ret;
        }
        /// <summary>
        /// 生成简单SQL插入语句
        /// </summary>
        /// <param name="colnum">插入列个数，为零则插入完整值</param>
        /// <param name="table_name">插入的表名</param>
        /// <param name="values">插入的行值</param>
        /// <returns></returns>
        public static String SqlInsertLine(int colnum, String table_name, params String[] values)
        {
            String ret = "insert into " + table_name;
            if (colnum != 0)
            {
                ret += "( ";
                for (int i = 0; i < colnum; i++)
                {
                    ret += " " + values[i] + " ,";
                }
                ret = ret.Remove(ret.Length - 1, 1);
                ret += ") ";
            }
            ret += " values (";
            for (int i = 0; i < values.Length; i++)
            {
                ret += " " + values[i] + " ,";
            }
            ret = ret.Remove(ret.Length - 1, 1);
            ret += ")";
            return ret;
        }
        /// <summary>
        /// 生成简单SQL删除语句
        /// </summary>
        /// <param name="table_name">选择的表名</param>
        /// <param name="values">where中的限制条件，由行名及限制条见交替组成，故一定为偶数</param>
        /// <returns></returns>
        public static String SqlDelete(String table_name, params String[] values)
        {
            if ((values.Length & 1) == 1)
                return "";
            String ret = "delete from " + table_name + " where ";
            for (int i = 0; i < values.Length; i += 2)
            {
                ret += " " + values[i] + " = " + values[i + 1] + " and ";
            }
            ret = ret.Remove(ret.Length - 4, 4);
            return ret;
        }
        /// <summary>
        /// 生成简单SQL更新语句
        /// </summary>
        /// <param name="set_col">标识更新的列数</param>
        /// <param name="table_name">表名</param>
        /// <param name="values">应为偶数，前2*set_col为更新的列名及数据，后为限制条件</param>
        /// <returns></returns>
        public static String SqlUpdate(int set_col, String table_name, params String[] values)
        {
            String ret = "update " + table_name;
            ret += " set ";
            int var_col = set_col * 2;
            for (int i = 0; i < var_col; i += 2)
            {
                ret += values[i] + " = " + values[i + 1] + " ,";
            }
            ret = ret.Remove(ret.Length - 1, 1);
            ret += " where";
            for (int i = var_col; i < values.Length; i += 2)
            {
                ret += " " + values[i] + " = " + values[i + 1] + " and ";
            }
            ret = ret.Remove(ret.Length - 4, 4);
            return ret;
        }
    }
    partial class User
    {
        private const String tb_name = "";//数据库中的表名
        private const String tbcn_uid = "";//数据库中的用户编号
        private const String tbcn_type = "";//数据库中的用户类型
        private const String tbcn_name = "";//数据库中的用户名，姓名
        private const String tbcn_pwd = "";//数据库中的用户密码
        /// <summary>
        /// 根据给定的用户信息（用户编号及类型）从数据库查找相应用户
        /// </summary>
        /// <returns>返回完整用户信息，未找到则返回null</returns>
        public User Select()
        {
#if HASDB
            if (uid == "")
                return null;
            User ret = null;
            using (Connetion con = new Connetion(CONNSTR))
            using (Command com = new Command(SqlSelect(tb_name, tbcn_uid, P + uid + P, tbcn_type, P + Enum.GetName(typeof(UserType), type) + P), con))
            {
                con.Open();
                DataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    ret = new User
                    {
                        password = (String)rd[tbcn_pwd],
                        type = (UserType)Enum.Parse(typeof(UserType), (String)rd[tbcn_type]),
                        uid = (String)rd[tbcn_uid],
                        name = (String)rd[tbcn_name]
                    };
                    com.Clone();
                    con.Close();
                }
            }
            return ret;
#else
            User ret = new User
            {
                password = password,
                type = this.type,
                uid = uid,
                name = this.name
            };
            return ret;
#endif
        }
        /// <summary>
        /// 插入前应该保证用户数据的完整与正确
        /// </summary>
        /// <returns>不完整数据或已有该用户或其他数据库冲突情况导致数据库添加不成功，将返回false</returns>
        public Boolean Insert()
        {
            //如果关键信息之一不是有效值，将返回false
            //password的安全性校验应交给前端以及时反馈用户，在服务端或数据库最好进行二次检查
            if (uid == "" || name == "" || password == "")
                return false;
            using (Connetion con = new Connetion(CONNSTR))
            //暂定插入顺序为用户编号，用户ID，用户名，用户密码，用户类型
            using (Command com = new Command(SqlInsertLine(0, tb_name, P + uid + P, P + name + P, P + password + P, P + Enum.GetName(typeof(UserType), type) + P)))
            {
                return com.ExecuteNonQuery() > 0;
            }
        }
        /// <summary>
        /// 删除员工
        /// TODO:不紧急，再说
        /// </summary>
        /// <returns></returns>
        public Boolean Delete()
        {
            return false;
        }
    }
    partial class Tool
    {
        /*ID	WorkcellID	Workcell	FamilyID	Family	Code	Name	Model	PartNo	
         * UsedFor	UPL	Owner	OwnerName	Remark	PMPeriod	RecOn	RecBy	RecByName	EditOn	EditBy	EditByName
         */
        private const String tb_name = "";//数据库中的表名
        /// <summary>
        /// 通过若干条件，查找并返回对应工夹具信息列表
        /// </summary>
        /// <param name="vars">诺干列名，数值</param>
        /// <returns></returns>
        static public List<Tool> Select(params string[] vars)
        {
            if ((vars.Length & 1) == 1)
                return null;
            List<Tool> ret = new List<Tool>();
            string sql = SqlSelect(tb_name, vars);
            using (Connetion con = new Connetion(CONNSTR))
            using (Command com = new Command(sql))
            {
                con.Open();
                DataReader rd = com.ExecuteReader();
                while (rd.Read())
                {
                    ret.Add(new Tool
                    {
                        //TODO:在此添加相应的工夹具信息，似乎还有些问题
                    });
                }
            }
            return ret;
        }
        public Boolean Insert()
        {
            return false;
        }
        public Boolean Delete()
        {
            return false;
        }
        public Boolean Update()
        {
            return false;
        }
    }
    abstract partial class ReqInfo
    {
        abstract public Boolean Select();
        abstract public Boolean Insert();
        abstract public Boolean Delete();
        abstract public Boolean Update();
    }
    partial class ImExReq : ReqInfo
    {
        public override bool Delete()
        {
            throw new NotImplementedException();
        }

        public override bool Insert()
        {
            throw new NotImplementedException();
        }

        public override bool Select()
        {
            throw new NotImplementedException();
        }

        public override bool Update()
        {
            throw new NotImplementedException();
        }
    }
    partial class PurchaseReq : ReqInfo
    {
        public override bool Delete()
        {
            throw new NotImplementedException();
        }

        public override bool Insert()
        {
            throw new NotImplementedException();
        }

        public override bool Select()
        {
            throw new NotImplementedException();
        }

        public override bool Update()
        {
            throw new NotImplementedException();
        }
    }
    partial class RepairReq : ReqInfo
    {
        public override bool Delete()
        {
            throw new NotImplementedException();
        }

        public override bool Insert()
        {
            throw new NotImplementedException();
        }

        public override bool Select()
        {
            throw new NotImplementedException();
        }

        public override bool Update()
        {
            throw new NotImplementedException();
        }
    }
    partial class ScrapReq : ReqInfo
    {
        public override bool Delete()
        {
            throw new NotImplementedException();
        }

        public override bool Insert()
        {
            throw new NotImplementedException();
        }

        public override bool Select()
        {
            throw new NotImplementedException();
        }

        public override bool Update()
        {
            throw new NotImplementedException();
        }
    }
}
