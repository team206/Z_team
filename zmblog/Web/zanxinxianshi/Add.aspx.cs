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
namespace zmblog.Web.zanxinxianshi
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtid.Text))
			{
				strErr+="id格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtfabiaoID.Text))
			{
				strErr+="fabiaoID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtzanID.Text))
			{
				strErr+="zanID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtxinxianshiID.Text))
			{
				strErr+="xinxianshiID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.txtid.Text);
			int fabiaoID=int.Parse(this.txtfabiaoID.Text);
			int zanID=int.Parse(this.txtzanID.Text);
			int xinxianshiID=int.Parse(this.txtxinxianshiID.Text);

			zmblog.Model.zanxinxianshi model=new zmblog.Model.zanxinxianshi();
			model.id=id;
			model.fabiaoID=fabiaoID;
			model.zanID=zanID;
			model.xinxianshiID=xinxianshiID;

			zmblog.BLL.zanxinxianshi bll=new zmblog.BLL.zanxinxianshi();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
