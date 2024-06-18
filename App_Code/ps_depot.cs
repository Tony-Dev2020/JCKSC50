﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

	/// <summary>
	/// 商家-类
	/// </summary>
	[Serializable]
	public partial class ps_depot
	{
		public ps_depot()
		{}
        #region Model

        /// <summary>
        /// 商家id
        /// </summary>
        public int id { set; get; }
      
        /// <summary>
        /// 地区id
        /// </summary>
        public int? category_id { set; get; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public string code { set; get; }
       
        /// <summary>
        /// 商家名称
        /// </summary>
        public string title { set; get; }

        /// <summary>
        /// 管理用户id
        /// </summary>
        public int? manage_id { set; get; }
        /// <summary>
        /// 老板姓名
        /// </summary>
        public string contact_name { set; get; }

        /// <summary>
        /// 固定电话
        /// </summary>
        public string contact_tel { set; get; }

        /// <summary>
        /// 手机
        /// </summary>
        public string contact_mobile { set; get; }

        /// <summary>
        /// 地址
        /// </summary> 
        public string contact_address { set; get; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public int? status { set; get; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? sort_id { set; get; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { set; get; }


        public string company { set; get; }

        public string customersupportid { set; get; }


    


        #endregion Model


        #region  Method


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [ps_depot]");
			strSql.Append(" where id=@id ");

			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 查询名称是否存在
        /// </summary>
        public bool Exists(string title)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from  ps_depot");
            strSql.Append(" where title=@title ");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100)};
            parameters[0].Value = title;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 查询排除本身名称是否存在
        /// </summary>
        public bool Exists(string title,  int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from  ps_depot");
            strSql.Append(" where id<>@id and  title=@title ");
            SqlParameter[] parameters = {
                     new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,100)};
            parameters[0].Value = id;
            parameters[1].Value = title;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在地区id记录
        /// </summary>
        public bool ExistsBM()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ps_depot]");
            strSql.Append(" where category_id=@category_id ");

            SqlParameter[] parameters = {
					new SqlParameter("@category_id", SqlDbType.Int,4)};
            parameters[0].Value = category_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 返回地区名称
        /// </summary>
        public string GetTitle(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 title from [ps_depot]");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

    public string GetCode(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select top 1 code from [ps_depot]");
        strSql.Append(" where id=" + id);
        string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        if (string.IsNullOrEmpty(title))
        {
            return "";
        }
        return title;
    }

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public int Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [ps_depot] (");
			strSql.Append("category_id,code,title,manage_id,contact_name,contact_tel,contact_mobile,contact_address,status,sort_id,remark,customersupportid)");
			strSql.Append(" values (");
			strSql.Append("@category_id,@code,@title,@manage_id,@contact_name,@contact_tel,@contact_mobile,@contact_address,@status,@sort_id,@remark,@customersupportid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@category_id", SqlDbType.Int,4),
					new SqlParameter("@code", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@manage_id", SqlDbType.Int,4),
					new SqlParameter("@contact_name", SqlDbType.VarChar,50),
					new SqlParameter("@contact_tel", SqlDbType.VarChar,50),
					new SqlParameter("@contact_mobile", SqlDbType.VarChar,50),
					new SqlParameter("@contact_address", SqlDbType.VarChar,300),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.Char,10),
                    new SqlParameter("@customersupportid", SqlDbType.NVarChar,50)};
			parameters[0].Value = category_id;
			parameters[1].Value = code;
			parameters[2].Value = title;
			parameters[3].Value = manage_id;
			parameters[4].Value = contact_name;
			parameters[5].Value = contact_tel;
			parameters[6].Value = contact_mobile;
			parameters[7].Value = contact_address;
			parameters[8].Value = status;
			parameters[9].Value = sort_id;
			parameters[10].Value = remark;
            parameters[11].Value = customersupportid;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
	
        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [ps_depot] set ");
			strSql.Append("category_id=@category_id,");
			strSql.Append("code=@code,");
			strSql.Append("title=@title,");
			strSql.Append("manage_id=@manage_id,");
			strSql.Append("contact_name=@contact_name,");
			strSql.Append("contact_tel=@contact_tel,");
			strSql.Append("contact_mobile=@contact_mobile,");
			strSql.Append("contact_address=@contact_address,");
			strSql.Append("status=@status,");
			strSql.Append("sort_id=@sort_id,");
			strSql.Append("remark=@remark,");
            strSql.Append("customersupportid=@customersupportid ");
            strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@category_id", SqlDbType.Int,4),
					new SqlParameter("@code", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@manage_id", SqlDbType.Int,4),
					new SqlParameter("@contact_name", SqlDbType.VarChar,50),
					new SqlParameter("@contact_tel", SqlDbType.VarChar,50),
					new SqlParameter("@contact_mobile", SqlDbType.VarChar,50),
					new SqlParameter("@contact_address", SqlDbType.VarChar,300),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.Char,10),
                    new SqlParameter("@customersupportid", SqlDbType.NVarChar,20),
                    new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = category_id;
			parameters[1].Value = code;
			parameters[2].Value = title;
			parameters[3].Value = manage_id;
			parameters[4].Value = contact_name;
			parameters[5].Value = contact_tel;
			parameters[6].Value = contact_mobile;
			parameters[7].Value = contact_address;
			parameters[8].Value = status;
			parameters[9].Value = sort_id;
			parameters[10].Value = remark;
            parameters[11].Value = customersupportid;
            parameters[12].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


        /// <summary>
        /// 更新商家地址
        /// </summary>
        public bool UpdateAddress()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ps_depot] set ");
            strSql.Append("contact_address=@contact_address");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@contact_address", SqlDbType.VarChar,300),
					new SqlParameter("@id", SqlDbType.Int,4)};

            parameters[0].Value = contact_address;
            parameters[1].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ps_depot set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
	
        /// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [ps_depot] ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public void GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,category_id,code,title,manage_id,contact_name,contact_tel,contact_mobile,contact_address,status,sort_id,remark,company,CustomerSupportID");
			strSql.Append(" FROM [ps_depot] ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					this.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["category_id"]!=null && ds.Tables[0].Rows[0]["category_id"].ToString()!="")
				{
					this.category_id=int.Parse(ds.Tables[0].Rows[0]["category_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["code"]!=null )
				{
					this.code=ds.Tables[0].Rows[0]["code"].ToString();
				}
				if(ds.Tables[0].Rows[0]["title"]!=null )
				{
					this.title=ds.Tables[0].Rows[0]["title"].ToString();
				}
				if(ds.Tables[0].Rows[0]["manage_id"]!=null && ds.Tables[0].Rows[0]["manage_id"].ToString()!="")
				{
					this.manage_id=int.Parse(ds.Tables[0].Rows[0]["manage_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["contact_name"]!=null )
				{
					this.contact_name=ds.Tables[0].Rows[0]["contact_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["contact_tel"]!=null )
				{
					this.contact_tel=ds.Tables[0].Rows[0]["contact_tel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["contact_mobile"]!=null )
				{
					this.contact_mobile=ds.Tables[0].Rows[0]["contact_mobile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["contact_address"]!=null )
				{
					this.contact_address=ds.Tables[0].Rows[0]["contact_address"].ToString();
				}
				if(ds.Tables[0].Rows[0]["status"]!=null && ds.Tables[0].Rows[0]["status"].ToString()!="")
				{
					this.status=int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sort_id"]!=null && ds.Tables[0].Rows[0]["sort_id"].ToString()!="")
				{
					this.sort_id=int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["remark"]!=null )
				{
					this.remark=ds.Tables[0].Rows[0]["remark"].ToString();
				}
                if (ds.Tables[0].Rows[0]["company"] != null)
                {
                    this.company = ds.Tables[0].Rows[0]["company"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerSupportID"] != null)
                {
                    this.customersupportid = ds.Tables[0].Rows[0]["CustomerSupportID"].ToString();
                }


        }
		}


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public void GetModel(string title)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,category_id ");
            strSql.Append(" FROM [ps_depot] ");
            strSql.Append(" where title=@title ");
            SqlParameter[] parameters = {
						new SqlParameter("@title", SqlDbType.VarChar,50)};
            parameters[0].Value = title;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    this.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["category_id"] != null && ds.Tables[0].Rows[0]["category_id"].ToString() != "")
                {
                    this.category_id = int.Parse(ds.Tables[0].Rows[0]["category_id"].ToString());
                }
            }
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [ps_depot] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 通过id获得对应的信息
        /// </summary>
        public DataTable GetList(int category_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ps_depot");
            if (category_id == 0)
            {
                //strSql.Append(" order by sort_id asc,id desc");
                strSql.Append(" order by sort_id asc,code asc");
            }
            else
            {
                //strSql.Append(" where status=1 and category_id=" + category_id + " order by sort_id asc,id desc");
                strSql.Append(" where status=1 and category_id=" + category_id + " order by sort_id asc,code asc");
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds.Tables[0];
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM  ps_depot");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM  ps_depot");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetKuJiaLeList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM  ps_kujiale");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    #endregion  Method
}


