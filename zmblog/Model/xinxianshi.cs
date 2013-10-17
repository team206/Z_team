using System;
namespace zmblog.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class xinxianshi
	{
		public xinxianshi()
		{}
		#region Model
		private int _xinxianshiid;
		private int _userid;
		private DateTime _posttime;
		private string _commenttitle;
		private string _commentmsg;
		private string _imgurl;
		private int _faceid;
		private int _xinqingid;
		/// <summary>
		/// 
		/// </summary>
		public int xinxianshiID
		{
			set{ _xinxianshiid=value;}
			get{return _xinxianshiid;}
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
		public DateTime postTime
		{
			set{ _posttime=value;}
			get{return _posttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string commentTitle
		{
			set{ _commenttitle=value;}
			get{return _commenttitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string commentMsg
		{
			set{ _commentmsg=value;}
			get{return _commentmsg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int faceID
		{
			set{ _faceid=value;}
			get{return _faceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int xinqingID
		{
			set{ _xinqingid=value;}
			get{return _xinqingid;}
		}
		#endregion Model

	}
}

