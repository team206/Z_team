using System;
namespace zmblog.Model
{
	/// <summary>
	/// sixin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sixin
	{
		public sixin()
		{}
		#region Model
		private int _msgid;
		private string _msgcontent;
		private int _sendid;
		private int _receivrid;
		private int _msgstate;
		/// <summary>
		/// 
		/// </summary>
		public int msgID
		{
			set{ _msgid=value;}
			get{return _msgid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string msgContent
		{
			set{ _msgcontent=value;}
			get{return _msgcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int sendID
		{
			set{ _sendid=value;}
			get{return _sendid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int receivrID
		{
			set{ _receivrid=value;}
			get{return _receivrid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int msgState
		{
			set{ _msgstate=value;}
			get{return _msgstate;}
		}
		#endregion Model

	}
}

