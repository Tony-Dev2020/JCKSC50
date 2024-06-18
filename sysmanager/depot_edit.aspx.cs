﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sysmanager_depot_edit : System.Web.UI.Page
{
    protected int page;
    private string action = "Add"; //操作类型
    private int id = 0;
    ManagePage mym = new ManagePage();
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否登录
        if (!mym.IsAdminLogin())
        {
            Response.Write("<script>parent.location.href='../index.aspx'</script>");
            Response.End();
        }
        //判断权限
        ps_manager_role_value myrv = new ps_manager_role_value();
        int role_id = Convert.ToInt32(Session["RoleID"]);
        int nav_id = 28;
        if (!myrv.QXExists(role_id, nav_id))
        {
            Response.Redirect("../error.html");
            Response.End();
        }
        string _action = AXRequest.GetQueryString("action");
        this.page = AXRequest.GetQueryInt("page", 1);
        if (!string.IsNullOrEmpty(_action) && _action == "Edit")
        {
            this.action = "Edit";//修改类型
            txtcode.Enabled = false;
            if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
            {
                mym.JscriptMsg(this.Page, "传输参数不正确！", "back", "Error");
                return;
            }

        }
        if (!Page.IsPostBack)
        {
            TreeBind(Convert.ToInt32(Session["DepotCatID"])); //绑定地区
            BindCustomerSupport();
            if (action == "Edit") //修改
            {
                ShowInfo(this.id);
            }
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ps_depot model = new ps_depot();
        model.GetModel(_id);
        ddlCategoryId.SelectedValue = model.category_id.ToString();
        ddlCustomerSupport.SelectedValue = model.customersupportid.ToString();
        txtcode.Text = model.code;
        txttitle.Text = model.title;
        txtcontact_name.Text = model.contact_name;
        txtcontact_tel.Text = model.contact_mobile;
        txtcontact_address.Text = model.contact_address;
        txtSortId.Text = model.sort_id.ToString();
        txtremark.Text = model.remark;
        if (model.status == 1)
        {
            cbIsLock.Checked = true;
        }
        else
        {
            cbIsLock.Checked = false;
        }
    }
    #endregion
    #region 绑定地区=================================
    private void TreeBind(int _category_id)
    {
        ps_depot_category bll = new ps_depot_category();
        DataTable dt = bll.GetList(_category_id);
        this.ddlCategoryId.Items.Clear();
        this.ddlCategoryId.Items.Add(new ListItem("请选择所属地区...", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            string Title = dr["name"].ToString().Trim();
            this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
        }
    }
    #endregion

    #region 绑定客服=================================
    private void BindCustomerSupport()
    {
        ps_depot_category bll = new ps_depot_category();
        DataTable dt = bll.GetCustomerSupportList(0);
        this.ddlCustomerSupport.Items.Clear();
        this.ddlCustomerSupport.Items.Add(new ListItem("请选择所属客服...", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            string Title = dr["name"].ToString().Trim();
            this.ddlCustomerSupport.Items.Add(new ListItem(Title, Id));
        }
    }
    #endregion

    

    #region 增加操作=================================
    private bool DoAdd()
    {
        ps_depot model = new ps_depot();
        if (model.Exists(txttitle.Text.Trim()))
        {
            mym.JscriptMsg(this.Page, "您输入的商家名称已经存在，请检查！", "", "Error");
            return false;
        }
        model.title = txttitle.Text.Trim();
        model.code = txtcode.Text.Trim();
        model.contact_name = txtcontact_name.Text.Trim();
        model.contact_mobile = txtcontact_tel.Text.Trim();
        model.contact_address = txtcontact_address.Text.Trim();
        model.category_id = int.Parse(ddlCategoryId.SelectedValue.Trim());
        model.sort_id = int.Parse(txtSortId.Text.Trim());
        model.remark = txtremark.Text.Trim();
        model.customersupportid = ddlCustomerSupport.SelectedValue;
        if (cbIsLock.Checked == true)
        {
            model.status = 1;
        }
        else
        {
            model.status = 2;
        }
        if (model.Add() > 0)
        {
            mym.AddAdminLog("增加", "添加商家：" + txttitle.Text); //记录日志
            return true;
        }

        return false;
    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        bool result = false;

        ps_depot model = new ps_depot();
        if (model.Exists(txttitle.Text.Trim(), _id))
        {
            mym.JscriptMsg(this.Page, "您输入的商家名称已经存在，请检查！", "", "Error");
            return false;
        }
        model.GetModel(_id);

        model.title = txttitle.Text.Trim();
        model.code = txtcode.Text.Trim();
        model.contact_name = txtcontact_name.Text.Trim();
        model.contact_mobile = txtcontact_tel.Text.Trim();
        model.contact_address = txtcontact_address.Text.Trim();
        model.category_id = int.Parse(ddlCategoryId.SelectedValue.Trim());
        model.sort_id = int.Parse(txtSortId.Text.Trim());
        model.remark = txtremark.Text.Trim();
        model.customersupportid = ddlCustomerSupport.SelectedValue;
        if (cbIsLock.Checked == true)
        {
            model.status = 1;
        }
        else
        {
            model.status = 2;
        }

        if (model.Update())
        {
            mym.AddAdminLog("修改", "修改商家:" + txttitle.Text); //记录日志
            result = true;
        }

        return result;
    }
    #endregion

    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (action == "Edit") //修改
        {
            if (!DoEdit(this.id))
            {
                mym.JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                return;
            }
            mym.JscriptMsg(this.Page, "修改商家信息成功！", Utils.CombUrlTxt("depot_list.aspx", "page={0}", this.page.ToString()), "Success");
        }
        else //添加
        {
            if (!DoAdd())
            {
                mym.JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                return;
            }
            mym.JscriptMsg(this.Page, "添加商家信息成功！", "depot_list.aspx", "Success");
        }
    }

}