﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace zmblog.DAL
{
	/// <summary>
	/// 数据访问类:userInfo
	/// </summary>
	public partial class userInfo
	{
		public userInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("userID", "userInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int userID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from userInfo");
			strSql.Append(" where userID=@userID");
			SqlParameter[] parameters = {
					new SqlParameter("@userID", SqlDbType.Int,4)
			};
			parameters[0].Value = userID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(zmblog.Model.userInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into userInfo(");
			strSql.Append("userName,userPwd,userEmail,phone,birthday,sex,position)");
			strSql.Append(" values (");
			strSql.Append("@userName,@userPwd,@userEmail,@phone,@birthday,@sex,@position)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.NVarChar,50),
					new SqlParameter("@userPwd", SqlDbType.VarChar,50),
					new SqlParameter("@userEmail", SqlDbType.VarChar,50),
					new SqlParameter("@phone", SqlDbType.VarChar,11),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@sex", SqlDbType.Bit,1),
					new SqlParameter("@position", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.userName;
			parameters[1].Value = model.userPwd;
			parameters[2].Value = model.userEmail;
			parameters[3].Value = model.phone;
			parameters[4].Value = model.birthday;
			parameters[5].Value = model.sex;
			parameters[6].Value = model.position;

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
		public bool Update(zmblog.Model.userInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update userInfo set ");
			strSql.Append("userName=@userName,");
			strSql.Append("userPwd=@userPwd,");
			strSql.Append("userEmail=@userEmail,");
			strSql.Append("phone=@phone,");
			strSql.Append("birthday=@birthday,");
			strSql.Append("sex=@sex,");
			strSql.Append("position=@position");
			strSql.Append(" where userID=@userID");
			SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.NVarChar,50),
					new SqlParameter("@userPwd", SqlDbType.VarChar,50),
					new SqlParameter("@userEmail", SqlDbType.VarChar,50),
					new SqlParameter("@phone", SqlDbType.VarChar,11),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@sex", SqlDbType.Bit,1),
					new SqlParameter("@position", SqlDbType.NVarChar,50),
					new SqlParameter("@userID", SqlDbType.Int,4)};
			parameters[0].Value = model.userName;
			parameters[1].Value = model.userPwd;
			parameters[2].Value = model.userEmail;
			parameters[3].Value = model.phone;
			parameters[4].Value = model.birthday;
			parameters[5].Value = model.sex;
			parameters[6].Value = model.position;
			parameters[7].Value = model.userID;

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
		public bool Delete(int userID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from userInfo ");
			strSql.Append(" where userID=@userID");
			SqlParameter[] parameters = {
					new SqlParameter("@userID", SqlDbType.Int,4)
			};
			parameters[0].Value = userID;

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
		public bool DeleteList(string userIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from userInfo ");
			strSql.Append(" where userID in ("+userIDlist + ")  ");
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
		public zmblog.Model.userInfo GetModel(int userID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 userID,userName,userPwd,userEmail,phone,birthday,sex,position from userInfo ");
			strSql.Append(" where userID=@userID");
			SqlParameter[] parameters = {
					new SqlParameter("@userID", SqlDbType.Int,4)
			};
			parameters[0].Value = userID;

			zmblog.Model.userInfo model=new zmblog.Model.userInfo();
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
		public zmblog.Model.userInfo DataRowToModel(DataRow row)
		{
			zmblog.Model.userInfo model=new zmblog.Model.userInfo();
			if (row != null)
			{
				if(row["userID"]!=null && row["userID"].ToString()!="")
				{
					model.userID=int.Parse(row["userID"].ToString());
				}
				if(row["userName"]!=null)
				{
					model.userName=row["userName"].ToString();
				}
				if(row["userPwd"]!=null)
				{
					model.userPwd=row["userPwd"].ToString();
				}
				if(row["userEmail"]!=null)
				{
					model.userEmail=row["userEmail"].ToString();
				}
				if(row["phone"]!=null)
				{
					model.phone=row["phone"].ToString();
				}
				if(row["birthday"]!=null && row["birthday"].ToString()!="")
				{
					model.birthday=DateTime.Parse(row["birthday"].ToString());
				}
				if(row["sex"]!=null && row["sex"].ToString()!="")
				{
					if((row["sex"].ToString()=="1")||(row["sex"].ToString().ToLower()=="true"))
					{
						model.sex=true;
					}
					else
					{
						model.sex=false;
					}
				}
				if(row["position"]!=null)
				{
					model.position=row["position"].ToString();
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
			strSql.Append("select userID,userName,userPwd,userEmail,phone,birthday,sex,position ");
			strSql.Append(" FROM userInfo ");
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
			strSql.Append(" userID,userName,userPwd,userEmail,phone,birthday,sex,position ");
			strSql.Append(" FROM userInfo ");
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
			strSql.Append("select count(1) FROM userInfo ");
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
				strSql.Append("order by T.userID desc");
			}
			strSql.Append(")AS Row, T.*  from userInfo T ");
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
			parameters[0].Value = "userInfo";
			parameters[1].Value = "userID";
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

