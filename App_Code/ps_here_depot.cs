﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

	/// <summary>
/// 在库信息-类
	/// </summary>
	[Serializable]
	public partial class ps_here_depot
	{
		public ps_here_depot()
		{}

        #region Model
        
        /// <summary>
        /// 在库信息
        /// </summary>
        public long id { set; get; }

        /// <summary>
        /// 产品种类
        /// </summary>
        public int? product_category_id { set; get; }


        public int? product_series_id { set; get; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string product_no { set; get; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string product_name { set; get; }


        public string specification { set; get; }


        public string commercialStyle


        public string commercialcolor { set; get; }


    /// <summary>
    /// 产品图片
    /// </summary>
    public string product_url { set; get; }

        /// <summary>
        /// 入库价格
        /// </summary>
        public decimal? go_price { set; get; }

        /// <summary>
        /// 销售价格
        /// </summary>
        public decimal? salse_price { set; get; }

        /// <summary>
        /// 当前数量
        /// </summary>
        public int? product_num { set; get; }

        /// <summary>
        /// 单位
        /// </summary>
        public string dw { set; get; }

        /// <summary>
        /// 是否缺货
        /// </summary>
        public int? is_qh { set; get; }

        /// <summary>
        /// 暂停订购
        /// </summary>
        public int? is_zt { set; get; }

        /// <summary>
        /// 订单备注
        /// </summary>
        public string remark { set; get; }

        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime? add_time { set; get; }

        /// <summary>
        /// 操作人id
        /// </summary>
        public int? user_id { set; get; }

        /// <summary>
        /// 0不缺货1缺货
        /// </summary>
        public int? status { set; get; }

        /// <summary>
        /// 是否显示0显示1不显示
        /// </summary>
        public int? is_xs { set; get; }


        public string company { set; get; }

        public int is_kit { set; get; }

        public string UD_ProdName_c { set; get; }


    #endregion Model

    #region  Method
    /// <summary>
    /// 得到最大ID
    /// </summary>
    public int GetMaxId(int userid)
        {

            return DbHelperSQL.GetMaxID("id", "ps_here_depot where user_id=" + userid);
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [ps_here_depot]");
			strSql.Append(" where id=@id ");

			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 查询产品名称是否存在
        /// </summary>
        public bool Exists(string product_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from  [ps_here_depot]");
            strSql.Append(" where product_name=@product_name and product_name<>'' ");
            SqlParameter[] parameters = {
					new SqlParameter("@product_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = product_name;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 查询产品编码是否存在
        /// </summary>
        public bool IsExistsByProductNo(string product_no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from  [ps_here_depot]");
            strSql.Append(" where product_no=@product_no and product_no<>'' ");
            SqlParameter[] parameters = {
                        new SqlParameter("@product_no", SqlDbType.NVarChar,100)};
            parameters[0].Value = product_no;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 通过id返回商品类别id
        /// </summary>
        public string GetTPid(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 product_category_id from [ps_here_depot]");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }
        /// <summary>
        /// 通过id返回商品图片
        /// </summary>
        public string GetTPurl(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 product_url from [ps_here_depot]");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }
        /// <summary>
        /// 是否存在商品种类id记录
        /// </summary>
        public bool ExistsBM()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ps_here_depot]");
            strSql.Append(" where product_category_id=@product_category_id ");

            SqlParameter[] parameters = {
					new SqlParameter("@product_category_id", SqlDbType.Int,4)};
            parameters[0].Value = product_category_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 返回sql查询结果
        /// </summary>
        public string Getsql(string sqlstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(sqlstr);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "0";
            }
            return title;
        }

        /// <summary>
        /// 根据条件汇总
        /// </summary>
        public string GetwhereSum(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 count(id) as sumcode from [ps_here_depot]");
            strSql.Append(" where " + strWhere);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "0";
            }
            return title;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [ps_here_depot] (");
            strSql.Append("product_category_id,product_name,product_url,go_price,salse_price,product_num,dw,is_qh,is_zt,remark,add_time,user_id,status,is_xs,product_no,company,is_kit,product_series_id)");
            strSql.Append(" values (");
            strSql.Append("@product_category_id,@product_name,@product_url,@go_price,@salse_price,@product_num,@dw,@is_qh,@is_zt,@remark,@add_time,@user_id,@status,@is_xs,@product_no,@company,@is_kit,@product_series_id)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@product_category_id", SqlDbType.Int,4),
					new SqlParameter("@product_name", SqlDbType.VarChar,200),
					new SqlParameter("@product_url", SqlDbType.VarChar,250),
					new SqlParameter("@go_price", SqlDbType.Decimal,9),
					new SqlParameter("@salse_price", SqlDbType.Decimal,9),
					new SqlParameter("@product_num", SqlDbType.Int,4),
					new SqlParameter("@dw", SqlDbType.VarChar,50),
					new SqlParameter("@is_qh", SqlDbType.Int,4),
					new SqlParameter("@is_zt", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
                    new SqlParameter("@is_xs", SqlDbType.Int,4),
                    new SqlParameter("@product_no", SqlDbType.VarChar,200),
                    new SqlParameter("@company", SqlDbType.VarChar,50),
                    new SqlParameter("@is_kit", SqlDbType.Int,4),
                    new SqlParameter("@product_series_id", SqlDbType.Int,4) };

            parameters[0].Value = product_category_id;
            parameters[1].Value = product_name;
            parameters[2].Value = product_url;
            parameters[3].Value = go_price;
            parameters[4].Value = salse_price;
            parameters[5].Value = product_num;
            parameters[6].Value = dw;
            parameters[7].Value = is_qh;
            parameters[8].Value = is_zt;
            parameters[9].Value = remark;
            parameters[10].Value = add_time;
            parameters[11].Value = user_id;
            parameters[12].Value = status;
            parameters[13].Value = is_xs;
            parameters[14].Value = product_no;
            parameters[15].Value = company;
            parameters[16].Value = is_kit;
            parameters[17].Value = product_series_id;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool UpdateALL()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ps_here_depot] set ");
            strSql.Append("product_category_id=@product_category_id,");
            strSql.Append("product_name=@product_name,");
            strSql.Append("product_url=@product_url,");
            strSql.Append("go_price=@go_price,");
            strSql.Append("salse_price=@salse_price,");
            strSql.Append("product_num=@product_num,");
            strSql.Append("dw=@dw,");
            strSql.Append("is_qh=@is_qh,");
            strSql.Append("is_zt=@is_zt,");
            strSql.Append("remark=@remark,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("user_id=@user_id,");
            strSql.Append("company=@company,");
            strSql.Append("specification=@specification,");
            strSql.Append("commercialStyle=@commercialStyle,");
            strSql.Append("product_series_id=@product_series_id,");
            strSql.Append("status=@status,");
            strSql.Append("is_xs=@is_xs");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@product_category_id", SqlDbType.Int,4),
					new SqlParameter("@product_name", SqlDbType.VarChar,200),
					new SqlParameter("@product_url", SqlDbType.VarChar,250),
					new SqlParameter("@go_price", SqlDbType.Decimal,9),
					new SqlParameter("@salse_price", SqlDbType.Decimal,9),
					new SqlParameter("@product_num", SqlDbType.Int,4),
					new SqlParameter("@dw", SqlDbType.VarChar,50),
					new SqlParameter("@is_qh", SqlDbType.Int,4),
					new SqlParameter("@is_zt", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@user_id", SqlDbType.Int,4),
                    new SqlParameter("@company", SqlDbType.VarChar,200),
                    new SqlParameter("@specification", SqlDbType.VarChar,200),
                    new SqlParameter("@commercialStyle", SqlDbType.VarChar,200),
                    new SqlParameter("@product_series_id", SqlDbType.Int,4),
                    new SqlParameter("@status", SqlDbType.Int,4),
                    new SqlParameter("@is_xs", SqlDbType.Int,4),
                    new SqlParameter("@id", SqlDbType.BigInt,8)};
            parameters[0].Value = product_category_id;
            parameters[1].Value = product_name;
            parameters[2].Value = product_url;
            parameters[3].Value = go_price;
            parameters[4].Value = salse_price;
            parameters[5].Value = product_num;
            parameters[6].Value = dw;
            parameters[7].Value = is_qh;
            parameters[8].Value = is_zt;
            parameters[9].Value = remark;
            parameters[10].Value = add_time;
            parameters[11].Value = user_id;
            parameters[12].Value = company;
            parameters[13].Value = specification;
            parameters[14].Value = commercialStyle;
            parameters[15].Value = product_series_id;
            parameters[16].Value = status;
            parameters[17].Value = is_xs;
            parameters[18].Value = id;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [ps_here_depot] ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
            parameters[0].Value = id;

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

        /// 得到一个对象实体
        /// </summary>
        public void GetModel(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,product_category_id,product_series_id,product_name,product_no,product_url,go_price,salse_price,product_num,dw,is_qh,is_zt,remark,add_time,user_id,status,is_xs,company,is_kit,specification,commercialStyle,commercialcolor,UD_ProdName_c ");
            strSql.Append(" FROM [ps_here_depot] ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
            parameters[0].Value = id;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    this.id = long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_category_id"] != null && ds.Tables[0].Rows[0]["product_category_id"].ToString() != "")
                {
                    this.product_category_id = int.Parse(ds.Tables[0].Rows[0]["product_category_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_series_id"] != null && ds.Tables[0].Rows[0]["product_series_id"].ToString() != "")
                {
                    this.product_series_id = int.Parse(ds.Tables[0].Rows[0]["product_series_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_no"] != null)
                {
                    this.product_no = ds.Tables[0].Rows[0]["product_no"].ToString();
                }
                if (ds.Tables[0].Rows[0]["product_name"] != null)
                {
                    this.product_name = ds.Tables[0].Rows[0]["product_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["product_url"] != null)
                {
                    this.product_url = ds.Tables[0].Rows[0]["product_url"].ToString();
                }
                if (ds.Tables[0].Rows[0]["go_price"] != null && ds.Tables[0].Rows[0]["go_price"].ToString() != "")
                {
                    this.go_price = decimal.Parse(ds.Tables[0].Rows[0]["go_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["salse_price"] != null && ds.Tables[0].Rows[0]["salse_price"].ToString() != "")
                {
                    this.salse_price = decimal.Parse(ds.Tables[0].Rows[0]["salse_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_num"] != null && ds.Tables[0].Rows[0]["product_num"].ToString() != "")
                {
                    this.product_num = int.Parse(ds.Tables[0].Rows[0]["product_num"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dw"] != null)
                {
                    this.dw = ds.Tables[0].Rows[0]["dw"].ToString();
                }
                if (ds.Tables[0].Rows[0]["is_qh"] != null && ds.Tables[0].Rows[0]["is_qh"].ToString() != "")
                {
                    this.is_qh = int.Parse(ds.Tables[0].Rows[0]["is_qh"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_zt"] != null && ds.Tables[0].Rows[0]["is_zt"].ToString() != "")
                {
                    this.is_zt = int.Parse(ds.Tables[0].Rows[0]["is_zt"].ToString());
                }
                if (ds.Tables[0].Rows[0]["remark"] != null)
                {
                    this.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["add_time"] != null && ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    this.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_id"] != null && ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    this.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["status"] != null && ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    this.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_xs"] != null && ds.Tables[0].Rows[0]["is_xs"].ToString() != "")
                {
                    this.is_xs = int.Parse(ds.Tables[0].Rows[0]["is_xs"].ToString());
                }
                if (ds.Tables[0].Rows[0]["company"] != null && ds.Tables[0].Rows[0]["company"].ToString() != "")
                {
                    this.company = ds.Tables[0].Rows[0]["company"].ToString();
                }
                if (ds.Tables[0].Rows[0]["is_kit"] != null && ds.Tables[0].Rows[0]["is_kit"].ToString() != "")
                {
                    this.is_kit = int.Parse(ds.Tables[0].Rows[0]["is_kit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["specification"] != null && ds.Tables[0].Rows[0]["specification"].ToString() != "")
                {
                    this.specification = ds.Tables[0].Rows[0]["specification"].ToString();
                }
                if (ds.Tables[0].Rows[0]["commercialStyle"] != null && ds.Tables[0].Rows[0]["commercialStyle"].ToString() != "")
                {
                    this.commercialStyle = ds.Tables[0].Rows[0]["commercialStyle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["commercialcolor"] != null && ds.Tables[0].Rows[0]["commercialcolor"].ToString() != "")
                {
                    this.commercialcolor = ds.Tables[0].Rows[0]["commercialcolor"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UD_ProdName_c"] != null && ds.Tables[0].Rows[0]["UD_ProdName_c"].ToString() != "")
                {
                    this.UD_ProdName_c = ds.Tables[0].Rows[0]["UD_ProdName_c"].ToString();
                }
            


            }
        }

        /// 得到一个对象实体
        /// </summary>
        public void GetModel(string product_no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,product_category_id,product_series_id,product_name,product_no,product_url,go_price,salse_price,product_num,dw,is_qh,is_zt,remark,add_time,user_id,status,is_xs ,is_kit,company,specification,commercialStyle,commercialcolor,UD_ProdName_c");
            strSql.Append(" FROM [ps_here_depot] ");
            strSql.Append(" where product_no=@product_no ");
            SqlParameter[] parameters = {
                        new SqlParameter("@product_no", SqlDbType.NVarChar)};
            parameters[0].Value = product_no;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    this.id = long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_category_id"] != null && ds.Tables[0].Rows[0]["product_category_id"].ToString() != "")
                {
                    this.product_category_id = int.Parse(ds.Tables[0].Rows[0]["product_category_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_series_id"] != null && ds.Tables[0].Rows[0]["product_series_id"].ToString() != "")
                {
                    this.product_series_id = int.Parse(ds.Tables[0].Rows[0]["product_series_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_no"] != null)
                {
                    this.product_no = ds.Tables[0].Rows[0]["product_no"].ToString();
                }
                if (ds.Tables[0].Rows[0]["product_name"] != null)
                {
                    this.product_name = ds.Tables[0].Rows[0]["product_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["product_url"] != null)
                {
                    this.product_url = ds.Tables[0].Rows[0]["product_url"].ToString();
                }
                if (ds.Tables[0].Rows[0]["go_price"] != null && ds.Tables[0].Rows[0]["go_price"].ToString() != "")
                {
                    this.go_price = decimal.Parse(ds.Tables[0].Rows[0]["go_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["salse_price"] != null && ds.Tables[0].Rows[0]["salse_price"].ToString() != "")
                {
                    this.salse_price = decimal.Parse(ds.Tables[0].Rows[0]["salse_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_num"] != null && ds.Tables[0].Rows[0]["product_num"].ToString() != "")
                {
                    this.product_num = int.Parse(ds.Tables[0].Rows[0]["product_num"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dw"] != null)
                {
                    this.dw = ds.Tables[0].Rows[0]["dw"].ToString();
                }
                if (ds.Tables[0].Rows[0]["is_qh"] != null && ds.Tables[0].Rows[0]["is_qh"].ToString() != "")
                {
                    this.is_qh = int.Parse(ds.Tables[0].Rows[0]["is_qh"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_zt"] != null && ds.Tables[0].Rows[0]["is_zt"].ToString() != "")
                {
                    this.is_zt = int.Parse(ds.Tables[0].Rows[0]["is_zt"].ToString());
                }
                if (ds.Tables[0].Rows[0]["remark"] != null)
                {
                    this.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["add_time"] != null && ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    this.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_id"] != null && ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    this.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["status"] != null && ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    this.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_xs"] != null && ds.Tables[0].Rows[0]["is_xs"].ToString() != "")
                {
                    this.is_xs = int.Parse(ds.Tables[0].Rows[0]["is_xs"].ToString());
                }
                if (ds.Tables[0].Rows[0]["company"] != null && ds.Tables[0].Rows[0]["company"].ToString() != "")
                {
                    this.company = ds.Tables[0].Rows[0]["company"].ToString();
                }
                if (ds.Tables[0].Rows[0]["is_kit"] != null && ds.Tables[0].Rows[0]["is_kit"].ToString() != "")
                {
                    this.is_kit = int.Parse(ds.Tables[0].Rows[0]["is_kit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["specification"] != null && ds.Tables[0].Rows[0]["specification"].ToString() != "")
                {
                    this.specification = ds.Tables[0].Rows[0]["specification"].ToString();
                }
                if (ds.Tables[0].Rows[0]["commercialStyle"] != null && ds.Tables[0].Rows[0]["commercialStyle"].ToString() != "")
                {
                    this.commercialStyle = ds.Tables[0].Rows[0]["commercialStyle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["commercialcolor"] != null && ds.Tables[0].Rows[0]["commercialcolor"].ToString() != "")
                {
                    this.commercialcolor = ds.Tables[0].Rows[0]["commercialcolor"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UD_ProdName_c"] != null && ds.Tables[0].Rows[0]["UD_ProdName_c"].ToString() != "")
                {
                    this.UD_ProdName_c = ds.Tables[0].Rows[0]["UD_ProdName_c"].ToString();
                }
        }
        }
    /// <summary>
    /// 更新是否缺货状态
    /// </summary>
    public bool UpdateStatus()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ps_here_depot] set ");
            strSql.Append("status=@status");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@id", SqlDbType.BigInt,8)};
            parameters[0].Value = status;
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
        /// 更新是否显示
        /// </summary>
        public bool UpdateXS()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ps_here_depot] set ");
            strSql.Append("is_xs=@is_xs");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@is_xs", SqlDbType.TinyInt,1),
					new SqlParameter("@id", SqlDbType.BigInt,8)};
            parameters[0].Value = is_xs;
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
        /// 更新入库价格和销售价格
        /// </summary>
        public bool Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ps_here_depot] set ");
            strSql.Append("go_price=@go_price,");
            strSql.Append("salse_price=@salse_price");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@go_price", SqlDbType.Decimal,9),
					new SqlParameter("@salse_price", SqlDbType.Decimal,9),
					new SqlParameter("@id", SqlDbType.BigInt,8)};

            parameters[0].Value = go_price;
            parameters[1].Value = salse_price;
            parameters[2].Value = id;

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
        /// 获得SQL 查询的数据
        /// </summary>
        public DataSet GetListSql(string strsql)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(strsql);
            return DbHelperSQL.Query(strSql.ToString());
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [v_Here_Depot] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}


        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM  v_Here_Depot");
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
            strSql.Append("select * FROM  v_Here_Depot where (kit_status>0 or isnull(is_kit,0)=0)");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        public DataSet GetListForCart(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * FROM  v_Here_Depot where 1=1 ");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" and " + strWhere);
        }
        recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
        return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
    }

    /// <summary>
    /// 获得查询分页数据
    /// </summary>
    public DataSet GetKitList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM  v_Here_Depot ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

    #endregion  Method
}


