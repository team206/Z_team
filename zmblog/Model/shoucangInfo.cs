using System;
namespace zmblog.Model
{
	/// <summary>
	/// shoucangInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class shoucangInfo
	{
		public shoucangInfo()
		{}
		#region Model
		private int _id;
		private int _fabiaoid;
		private int _shoucangid;
		private int _xinxianshiid;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int fabiaoID
		{
			set{ _fabiaoid=value;}
			get{return _fabiaoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int shoucangID
		{
			set{ _shoucangid=value;}
			get{return _shoucangid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int xinxianshiID
		{
			set{ _xinxianshiid=value;}
			get{return _xinxianshiid;}
		}
		#endregion Model

	}
}

