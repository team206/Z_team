using System;
namespace zmblog.Model
{
	/// <summary>
	/// skinInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class skinInfo
	{
		public skinInfo()
		{}
		#region Model
		private int _id;
		private string _skinnme;
		private int _skinid;
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
		public string skinNme
		{
			set{ _skinnme=value;}
			get{return _skinnme;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int skinID
		{
			set{ _skinid=value;}
			get{return _skinid;}
		}
		#endregion Model

	}
}

