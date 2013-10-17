using System;
namespace zmblog.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class zanxinxianshi
	{
		public zanxinxianshi()
		{}
		#region Model
		private int _id;
		private int _fabiaoid;
		private int _zanid;
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
		public int zanID
		{
			set{ _zanid=value;}
			get{return _zanid;}
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

