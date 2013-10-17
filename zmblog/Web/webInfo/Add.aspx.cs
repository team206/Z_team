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
namespace zmblog.Web.webInfo
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtlogoURL.Text.Trim().Length==0)
			{
				strErr+="logoURL不能为空！\\n";	
			}
			if(this.txtwebName.Text.Trim().Length==0)
			{
				strErr+="webName不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtlastPuvTime.Text))
			{
				strErr+="lastPuvTime格式错误！\\n";	
			}
			if(this.txtauthotr.Text.Trim().Length==0)
			{
				strErr+="authotr不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string logoURL=this.txtlogoURL.Text;
			string webName=this.txtwebName.Text;
			DateTime lastPuvTime=DateTime.Parse(this.txtlastPuvTime.Text);
			string authotr=this.txtauthotr.Text;

			zmblog.Model.webInfo model=new zmblog.Model.webInfo();
			model.logoURL=logoURL;
			model.webName=webName;
			model.lastPuvTime=lastPuvTime;
			model.authotr=authotr;

			zmblog.BLL.webInfo bll=new zmblog.BLL.webInfo();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
