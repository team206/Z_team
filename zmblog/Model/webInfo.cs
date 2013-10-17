using System;
namespace zmblog.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class webInfo
	{
		public webInfo()
		{}
		#region Model
		private int _id;
		private string _logourl;
		private string _webname;
		private DateTime _lastpuvtime;
		private string _authotr;
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
		public string logoURL
		{
			set{ _logourl=value;}
			get{return _logourl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string webName
		{
			set{ _webname=value;}
			get{return _webname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime lastPuvTime
		{
			set{ _lastpuvtime=value;}
			get{return _lastpuvtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string authotr
		{
			set{ _authotr=value;}
			get{return _authotr;}
		}
		#endregion Model

	}
}

