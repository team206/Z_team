using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using zmblog.Model;
namespace zmblog.BLL
{
	/// <summary>
	/// 1
	/// </summary>
	public partial class xinxianshi
	{
		private readonly zmblog.DAL.xinxianshi dal=new zmblog.DAL.xinxianshi();
		public xinxianshi()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int xinxianshiID)
		{
			return dal.Exists(xinxianshiID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(zmblog.Model.xinxianshi model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(zmblog.Model.xinxianshi model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int xinxianshiID)
		{
			
			return dal.Delete(xinxianshiID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string xinxianshiIDlist )
		{
			return dal.DeleteList(xinxianshiIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public zmblog.Model.xinxianshi GetModel(int xinxianshiID)
		{
			
			return dal.GetModel(xinxianshiID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public zmblog.Model.xinxianshi GetModelByCache(int xinxianshiID)
		{
			
			string CacheKey = "xinxianshiModel-" + xinxianshiID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(xinxianshiID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (zmblog.Model.xinxianshi)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<zmblog.Model.xinxianshi> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<zmblog.Model.xinxianshi> DataTableToList(DataTable dt)
		{
			List<zmblog.Model.xinxianshi> modelList = new List<zmblog.Model.xinxianshi>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				zmblog.Model.xinxianshi model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

