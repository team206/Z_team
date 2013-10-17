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
namespace zmblog.Web.sixin
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtmsgContent.Text.Trim().Length==0)
			{
				strErr+="msgContent不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtsendID.Text))
			{
				strErr+="sendID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtreceivrID.Text))
			{
				strErr+="receivrID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtmsgState.Text))
			{
				strErr+="msgState格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string msgContent=this.txtmsgContent.Text;
			int sendID=int.Parse(this.txtsendID.Text);
			int receivrID=int.Parse(this.txtreceivrID.Text);
			int msgState=int.Parse(this.txtmsgState.Text);

			zmblog.Model.sixin model=new zmblog.Model.sixin();
			model.msgContent=msgContent;
			model.sendID=sendID;
			model.receivrID=receivrID;
			model.msgState=msgState;

			zmblog.BLL.sixin bll=new zmblog.BLL.sixin();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
