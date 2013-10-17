using System;
namespace zmblog.Model
{
	/// <summary>
	/// followInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class followInfo
	{
		public followInfo()
		{}
		#region Model
		private int _id;
		private int _userid;
		private int _fansid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int userID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int fansID
		{
			set{ _fansid=value;}
			get{return _fansid;}
		}
		#endregion Model

	}
}

