using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace zmblog.DAL
{
	/// <summary>
	/// 数据访问类:xinxianshi
	/// </summary>
	public partial class xinxianshi
	{
		public xinxianshi()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("xinxianshiID", "xinxianshi"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int xinxianshiID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from xinxianshi");
			strSql.Append(" where xinxianshiID=@xinxianshiID ");
			SqlParameter[] parameters = {
					new SqlParameter("@xinxianshiID", SqlDbType.Int,4)			};
			parameters[0].Value = xinxianshiID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(zmblog.Model.xinxianshi model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into xinxianshi(");
			strSql.Append("xinxianshiID,userID,postTime,commentTitle,commentMsg,imgUrl,faceID,xinqingID)");
			strSql.Append(" values (");
			strSql.Append("@xinxianshiID,@userID,@postTime,@commentTitle,@commentMsg,@imgUrl,@faceID,@xinqingID)");
			SqlParameter[] parameters = {
					new SqlParameter("@xinxianshiID", SqlDbType.Int,4),
					new SqlParameter("@userID", SqlDbType.Int,4),
					new SqlParameter("@postTime", SqlDbType.DateTime),
					new SqlParameter("@commentTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@commentMsg", SqlDbType.NVarChar,50),
					new SqlParameter("@imgUrl", SqlDbType.VarChar,50),
					new SqlParameter("@faceID", SqlDbType.Int,4),
					new SqlParameter("@xinqingID", SqlDbType.Int,4)};
			parameters[0].Value = model.xinxianshiID;
			parameters[1].Value = model.userID;
			parameters[2].Value = model.postTime;
			parameters[3].Value = model.commentTitle;
			parameters[4].Value = model.commentMsg;
			parameters[5].Value = model.imgUrl;
			parameters[6].Value = model.faceID;
			parameters[7].Value = model.xinqingID;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(zmblog.Model.xinxianshi model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update xinxianshi set ");
			strSql.Append("userID=@userID,");
			strSql.Append("postTime=@postTime,");
			strSql.Append("commentTitle=@commentTitle,");
			strSql.Append("commentMsg=@commentMsg,");
			strSql.Append("imgUrl=@imgUrl,");
			strSql.Append("faceID=@faceID,");
			strSql.Append("xinqingID=@xinqingID");
			strSql.Append(" where xinxianshiID=@xinxianshiID ");
			SqlParameter[] parameters = {
					new SqlParameter("@userID", SqlDbType.Int,4),
					new SqlParameter("@postTime", SqlDbType.DateTime),
					new SqlParameter("@commentTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@commentMsg", SqlDbType.NVarChar,50),
					new SqlParameter("@imgUrl", SqlDbType.VarChar,50),
					new SqlParameter("@faceID", SqlDbType.Int,4),
					new SqlParameter("@xinqingID", SqlDbType.Int,4),
					new SqlParameter("@xinxianshiID", SqlDbType.Int,4)};
			parameters[0].Value = model.userID;
			parameters[1].Value = model.postTime;
			parameters[2].Value = model.commentTitle;
			parameters[3].Value = model.commentMsg;
			parameters[4].Value = model.imgUrl;
			parameters[5].Value = model.faceID;
			parameters[6].Value = model.xinqingID;
			parameters[7].Value = model.xinxianshiID;

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
		public bool Delete(int xinxianshiID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from xinxianshi ");
			strSql.Append(" where xinxianshiID=@xinxianshiID ");
			SqlParameter[] parameters = {
					new SqlParameter("@xinxianshiID", SqlDbType.Int,4)			};
			parameters[0].Value = xinxianshiID;

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
		public bool DeleteList(string xinxianshiIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from xinxianshi ");
			strSql.Append(" where xinxianshiID in ("+xinxianshiIDlist + ")  ");
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
		public zmblog.Model.xinxianshi GetModel(int xinxianshiID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 xinxianshiID,userID,postTime,commentTitle,commentMsg,imgUrl,faceID,xinqingID from xinxianshi ");
			strSql.Append(" where xinxianshiID=@xinxianshiID ");
			SqlParameter[] parameters = {
					new SqlParameter("@xinxianshiID", SqlDbType.Int,4)			};
			parameters[0].Value = xinxianshiID;

			zmblog.Model.xinxianshi model=new zmblog.Model.xinxianshi();
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
		public zmblog.Model.xinxianshi DataRowToModel(DataRow row)
		{
			zmblog.Model.xinxianshi model=new zmblog.Model.xinxianshi();
			if (row != null)
			{
				if(row["xinxianshiID"]!=null && row["xinxianshiID"].ToString()!="")
				{
					model.xinxianshiID=int.Parse(row["xinxianshiID"].ToString());
				}
				if(row["userID"]!=null && row["userID"].ToString()!="")
				{
					model.userID=int.Parse(row["userID"].ToString());
				}
				if(row["postTime"]!=null && row["postTime"].ToString()!="")
				{
					model.postTime=DateTime.Parse(row["postTime"].ToString());
				}
				if(row["commentTitle"]!=null)
				{
					model.commentTitle=row["commentTitle"].ToString();
				}
				if(row["commentMsg"]!=null)
				{
					model.commentMsg=row["commentMsg"].ToString();
				}
				if(row["imgUrl"]!=null)
				{
					model.imgUrl=row["imgUrl"].ToString();
				}
				if(row["faceID"]!=null && row["faceID"].ToString()!="")
				{
					model.faceID=int.Parse(row["faceID"].ToString());
				}
				if(row["xinqingID"]!=null && row["xinqingID"].ToString()!="")
				{
					model.xinqingID=int.Parse(row["xinqingID"].ToString());
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
			strSql.Append("select xinxianshiID,userID,postTime,commentTitle,commentMsg,imgUrl,faceID,xinqingID ");
			strSql.Append(" FROM xinxianshi ");
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
			strSql.Append(" xinxianshiID,userID,postTime,commentTitle,commentMsg,imgUrl,faceID,xinqingID ");
			strSql.Append(" FROM xinxianshi ");
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
			strSql.Append("select count(1) FROM xinxianshi ");
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
				strSql.Append("order by T.xinxianshiID desc");
			}
			strSql.Append(")AS Row, T.*  from xinxianshi T ");
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
			parameters[0].Value = "xinxianshi";
			parameters[1].Value = "xinxianshiID";
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

