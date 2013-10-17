using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace zmblog.DAL
{
	/// <summary>
	/// 数据访问类:sixin
	/// </summary>
	public partial class sixin
	{
		public sixin()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("msgID", "sixin"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int msgID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sixin");
			strSql.Append(" where msgID=@msgID");
			SqlParameter[] parameters = {
					new SqlParameter("@msgID", SqlDbType.Int,4)
			};
			parameters[0].Value = msgID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(zmblog.Model.sixin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sixin(");
			strSql.Append("msgContent,sendID,receivrID,msgState)");
			strSql.Append(" values (");
			strSql.Append("@msgContent,@sendID,@receivrID,@msgState)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@msgContent", SqlDbType.NVarChar,500),
					new SqlParameter("@sendID", SqlDbType.Int,4),
					new SqlParameter("@receivrID", SqlDbType.Int,4),
					new SqlParameter("@msgState", SqlDbType.TinyInt,1)};
			parameters[0].Value = model.msgContent;
			parameters[1].Value = model.sendID;
			parameters[2].Value = model.receivrID;
			parameters[3].Value = model.msgState;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(zmblog.Model.sixin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sixin set ");
			strSql.Append("msgContent=@msgContent,");
			strSql.Append("sendID=@sendID,");
			strSql.Append("receivrID=@receivrID,");
			strSql.Append("msgState=@msgState");
			strSql.Append(" where msgID=@msgID");
			SqlParameter[] parameters = {
					new SqlParameter("@msgContent", SqlDbType.NVarChar,500),
					new SqlParameter("@sendID", SqlDbType.Int,4),
					new SqlParameter("@receivrID", SqlDbType.Int,4),
					new SqlParameter("@msgState", SqlDbType.TinyInt,1),
					new SqlParameter("@msgID", SqlDbType.Int,4)};
			parameters[0].Value = model.msgContent;
			parameters[1].Value = model.sendID;
			parameters[2].Value = model.receivrID;
			parameters[3].Value = model.msgState;
			parameters[4].Value = model.msgID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int msgID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sixin ");
			strSql.Append(" where msgID=@msgID");
			SqlParameter[] parameters = {
					new SqlParameter("@msgID", SqlDbType.Int,4)
			};
			parameters[0].Value = msgID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string msgIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sixin ");
			strSql.Append(" where msgID in ("+msgIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public zmblog.Model.sixin GetModel(int msgID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 msgID,msgContent,sendID,receivrID,msgState from sixin ");
			strSql.Append(" where msgID=@msgID");
			SqlParameter[] parameters = {
					new SqlParameter("@msgID", SqlDbType.Int,4)
			};
			parameters[0].Value = msgID;

			zmblog.Model.sixin model=new zmblog.Model.sixin();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public zmblog.Model.sixin DataRowToModel(DataRow row)
		{
			zmblog.Model.sixin model=new zmblog.Model.sixin();
			if (row != null)
			{
				if(row["msgID"]!=null && row["msgID"].ToString()!="")
				{
					model.msgID=int.Parse(row["msgID"].ToString());
				}
				if(row["msgContent"]!=null)
				{
					model.msgContent=row["msgContent"].ToString();
				}
				if(row["sendID"]!=null && row["sendID"].ToString()!="")
				{
					model.sendID=int.Parse(row["sendID"].ToString());
				}
				if(row["receivrID"]!=null && row["receivrID"].ToString()!="")
				{
					model.receivrID=int.Parse(row["receivrID"].ToString());
				}
				if(row["msgState"]!=null && row["msgState"].ToString()!="")
				{
					model.msgState=int.Parse(row["msgState"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select msgID,msgContent,sendID,receivrID,msgState ");
			strSql.Append(" FROM sixin ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" msgID,msgContent,sendID,receivrID,msgState ");
			strSql.Append(" FROM sixin ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM sixin ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.msgID desc");
			}
			strSql.Append(")AS Row, T.*  from sixin T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "sixin";
			parameters[1].Value = "msgID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

