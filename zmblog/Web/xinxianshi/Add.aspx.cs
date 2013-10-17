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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtxinxianshiID.Text))
			{
				strErr+="xinxianshiID格式错误！\\n";	
			}
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
			int xinxianshiID=int.Parse(this.txtxinxianshiID.Text);
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
