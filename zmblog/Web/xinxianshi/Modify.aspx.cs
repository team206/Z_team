using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace zmblog.Web.xinxianshi
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int xinxianshiID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(xinxianshiID);
				}
			}
		}
			
	private void ShowInfo(int xinxianshiID)
	{
		zmblog.BLL.xinxianshi bll=new zmblog.BLL.xinxianshi();
		zmblog.Model.xinxianshi model=bll.GetModel(xinxianshiID);
		this.lblxinxianshiID.Text=model.xinxianshiID.ToString();
		this.txtuserID.Text=model.userID.ToString();
		this.txtpostTime.Text=model.postTime.ToString();
		this.txtcommentTitle.Text=model.commentTitle;
		this.txtcommentMsg.Text=model.commentMsg;
		this.txtimgUrl.Text=model.imgUrl;
		this.txtfaceID.Text=model.faceID.ToString();
		this.txtxinqingID.Text=model.xinqingID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtuserID.Text))
			{
				strErr+="userID格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtpostTime.Text))
			{
				strErr+="postTime格式错误！\\n";	
			}
			if(this.txtcommentTitle.Text.Trim().Length==0)
			{
				strErr+="commentTitle不能为空！\\n";	
			}
			if(this.txtcommentMsg.Text.Trim().Length==0)
			{
				strErr+="commentMsg不能为空！\\n";	
			}
			if(this.txtimgUrl.Text.Trim().Length==0)
			{
				strErr+="imgUrl不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtfaceID.Text))
			{
				strErr+="faceID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtxinqingID.Text))
			{
				strErr+="xinqingID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int xinxianshiID=int.Parse(this.lblxinxianshiID.Text);
			int userID=int.Parse(this.txtuserID.Text);
			DateTime postTime=DateTime.Parse(this.txtpostTime.Text);
			string commentTitle=this.txtcommentTitle.Text;
			string commentMsg=this.txtcommentMsg.Text;
			string imgUrl=this.txtimgUrl.Text;
			int faceID=int.Parse(this.txtfaceID.Text);
			int xinqingID=int.Parse(this.txtxinqingID.Text);


			zmblog.Model.xinxianshi model=new zmblog.Model.xinxianshi();
			model.xinxianshiID=xinxianshiID;
			model.userID=userID;
			model.postTime=postTime;
			model.commentTitle=commentTitle;
			model.commentMsg=commentMsg;
			model.imgUrl=imgUrl;
			model.faceID=faceID;
			model.xinqingID=xinqingID;

			zmblog.BLL.xinxianshi bll=new zmblog.BLL.xinxianshi();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
