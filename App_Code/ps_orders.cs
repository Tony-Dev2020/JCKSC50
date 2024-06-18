﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

	/// <summary>
	/// 类ps_orders。
	/// </summary>
	[Serializable]
	public partial class ps_orders
	{
		public ps_orders()
		{}
        #region Model
   





        /// <summary>
        /// 自增ID
        /// </summary>
        public int id { set; get; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string order_no { set; get; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string epicor_order_no { set; get; }

        /// <summary>
        /// 地区id
        /// </summary>
        public int? depot_category_id { set; get; }

        /// <summary>
        /// 商家的ID
        /// </summary>
        public int? depot_id { set; get; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int? user_id { set; get; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name { set; get; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public int? payment_id { set; get; }

        /// <summary>
        /// 支付状态1未支付2已支付
        /// </summary>
        public int? payment_status { set; get; }

        /// <summary>
        /// 支付时间
        /// </summary> 
        public DateTime? payment_time { set; get; }

        /// <summary>
        /// 订单留言
        /// </summary>
        public string message { set; get; }

        /// <summary>
        /// 订单备注
        /// </summary>
        public string remark { set; get; }

        /// <summary>
        /// 订单商品总金额
        /// </summary>
        public decimal? payable_amount { set; get; }

        /// <summary>
        /// 调价金额
        /// </summary>
        public decimal? real_amount { set; get; }

        /// <summary>
        /// 订单实际总金额
        /// </summary>
        public decimal? order_amount { set; get; }

 
        public decimal? discount_amount { set; get; }


        public decimal? payration { set; get; }


    


        /// <summary>
        /// 订单状态1生成订单,2确认订单,3完成订单,4取消订单
        /// </summary>
        public int? status { set; get; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime? add_time { set; get; }

        /// <summary>
        /// 确认时间
        /// </summary>
        public DateTime? confirm_time { set; get; }

        /// <summary>
        /// 订单完成时间
        /// </summary>
        public DateTime? complete_time { set; get; }

 
        public DateTime? designtime { set; get; }


        public DateTime? comfirmdesigntime { set; get; }

        public DateTime? quotetime { set; get; }

        public DateTime? comfirmquotetime { set; get; }

        public DateTime? paytime { set; get; }

    public DateTime? comfirmpaytime { set; get; }


        public string confirmuser { set; get; }


        public string completeuser { set; get; }

        public string adduser { set; get; }

        public string designuser { set; get; }

        public string comfirmdesignuser { set; get; }


        public string quoteuser { set; get; }

        public string comfirmquoteuser { set; get; }

        public string payuser { set; get; }

        public string comfirmpayuser { set; get; }


  
    

        public DateTime? order_date { set; get; }


        public DateTime? need_date { set; get; }


        public DateTime? ship_date { set; get; }



        public string contract_name { set; get; }

        public string contact_number { set; get; }

        public string provice { set; get; }


        public string city { set; get; }


        public string area { set; get; }


        public string address { set; get; }


        public string attachment1 { set; get; }


        public string attachment2 { set; get; }


        public string attachment3 { set; get; }

        public string attachment4 { set; get; }


        public string quoteattachment { set; get; }

        public string quoteremark { set; get; }


        public string designattachment { set; get; }

        public string designattachment2 { set; get; }

        public string designattachment3 { set; get; }

        public string designattachment4 { set; get; }

        public string designattachment5 { set; get; }


        public string designremark { set; get; }

        public string payattachment { set; get; }

        public string payaremark { set; get; }

    
        public decimal? payamount { set; get; }


        public string completeremark { set; get; }


        public string backremark { set; get; }


    #endregion Model


    #region  Method


    /// <summary>
    /// 得到最大ID
    /// </summary>
    public int GetMaxId()
		{

		return DbHelperSQL.GetMaxID("id", "ps_orders"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [ps_orders]");
			strSql.Append(" where id=@id ");

			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string order_no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ps_orders]");
            strSql.Append(" where order_no=@order_no ");
            SqlParameter[] parameters = {
					new SqlParameter("@order_no", SqlDbType.NVarChar,100)};
            parameters[0].Value = order_no.Trim();

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据条件和字段汇总
        /// </summary>
        public string GetTitleSum(string strWhere, string Title)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 " + Title + " as sumcode from [ps_orders]");
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
            strSql.Append("insert into [ps_orders] (");
            strSql.Append("order_no,depot_category_id,depot_id,user_id,user_name,payment_id,payment_status,payment_time,message,remark,payable_amount,real_amount,order_amount,status,add_time,confirm_time,complete_time,order_date,need_date,ship_date,provice,city,area,address, contract_name,contact_number,attachment1,attachment2,attachment3,attachment4)");
            strSql.Append(" values (");
            strSql.Append("@order_no,@depot_category_id,@depot_id,@user_id,@user_name,@payment_id,@payment_status,@payment_time,@message,@remark,@payable_amount,@real_amount,@order_amount,@status,@add_time,@confirm_time,@complete_time,@order_date,@need_date,@ship_date,@provice,@city,@area,@address,@contract_name,@contact_number,@attachment1,@attachment2,@attachment3,@attachment4)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@order_no", SqlDbType.NVarChar,100),
					new SqlParameter("@depot_category_id", SqlDbType.Int,4),
					new SqlParameter("@depot_id", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@payment_id", SqlDbType.Int,4),
					new SqlParameter("@payment_status", SqlDbType.TinyInt,1),
					new SqlParameter("@payment_time", SqlDbType.DateTime),
					new SqlParameter("@message", SqlDbType.NVarChar,500),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@payable_amount", SqlDbType.Decimal,5),
					new SqlParameter("@real_amount", SqlDbType.Decimal,5),
					new SqlParameter("@order_amount", SqlDbType.Decimal,5),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@confirm_time", SqlDbType.DateTime),
					new SqlParameter("@complete_time", SqlDbType.DateTime),
                    new SqlParameter("@order_date", SqlDbType.DateTime),
                    new SqlParameter("@need_date", SqlDbType.DateTime),
                    new SqlParameter("@ship_date", SqlDbType.DateTime),
                    new SqlParameter("@provice", SqlDbType.NVarChar,500),
                    new SqlParameter("@city", SqlDbType.NVarChar,500),
                    new SqlParameter("@area", SqlDbType.NVarChar,500),
                    new SqlParameter("@address", SqlDbType.NVarChar,500),
                    new SqlParameter("@contract_name", SqlDbType.NVarChar,500),
                    new SqlParameter("@contact_number", SqlDbType.NVarChar,500),
                    new SqlParameter("@attachment1", SqlDbType.NVarChar,500),
                    new SqlParameter("@attachment2", SqlDbType.NVarChar,500),
                    new SqlParameter("@attachment3", SqlDbType.NVarChar,500),
                    new SqlParameter("@attachment4", SqlDbType.NVarChar,500)};
            parameters[0].Value = order_no;
            parameters[1].Value = depot_category_id;
            parameters[2].Value = depot_id;
            parameters[3].Value = user_id;
            parameters[4].Value = user_name;
            parameters[5].Value = payment_id;
            parameters[6].Value = payment_status;
            parameters[7].Value = payment_time;
            parameters[8].Value = message;
            parameters[9].Value = remark;
            parameters[10].Value = payable_amount;
            parameters[11].Value = real_amount;
            parameters[12].Value = order_amount;
            parameters[13].Value = status;
            parameters[14].Value = add_time;
            parameters[15].Value = confirm_time;
            parameters[16].Value = complete_time;
            parameters[17].Value = order_date;
            parameters[18].Value = need_date;
            parameters[19].Value = ship_date;
            parameters[20].Value = provice;
            parameters[21].Value = city;
            parameters[22].Value = area;
            parameters[23].Value = address;
            parameters[24].Value = contract_name;
            parameters[25].Value = contact_number;
            parameters[26].Value = attachment1;
            parameters[27].Value = attachment2;
            parameters[28].Value = attachment3;
            parameters[29].Value = attachment4;

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
        public bool Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ps_orders] set ");
            strSql.Append("order_no=@order_no,");
            strSql.Append("depot_category_id=@depot_category_id,");
            strSql.Append("depot_id=@depot_id,");
            strSql.Append("user_id=@user_id,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("payment_id=@payment_id,");
            strSql.Append("payment_status=@payment_status,");
            strSql.Append("payment_time=@payment_time,");
            strSql.Append("message=@message,");
            strSql.Append("remark=@remark,");
            strSql.Append("payable_amount=@payable_amount,");
            strSql.Append("real_amount=@real_amount,");
            strSql.Append("order_amount=@order_amount,");
            strSql.Append("status=@status,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("confirm_time=@confirm_time,");
            strSql.Append("complete_time=@complete_time,");
            strSql.Append("order_date=@order_date,");
            strSql.Append("need_date=@need_date,");
            strSql.Append("ship_date=@ship_date,");
            strSql.Append("provice=@provice,");
            strSql.Append("city=@city,");
            strSql.Append("area=@area,");
            strSql.Append("address=@address,");
            strSql.Append("contract_name=@contract_name,");
            strSql.Append("contact_number=@contact_number,");

            strSql.Append("designtime=@designtime,");
            strSql.Append("comfirmdesigntime=@comfirmdesigntime,");
            strSql.Append("quotetime=@quotetime,");
            strSql.Append("comfirmquotetime=@comfirmquotetime,");
            strSql.Append("paytime=@paytime,");
            strSql.Append("comfirmpaytime=@comfirmpaytime,");
            strSql.Append("confirmuser=@confirmuser,");
            strSql.Append("completeuser=@completeuser,");
            strSql.Append("adduser=@adduser,");
            strSql.Append("designuser=@designuser,");
            strSql.Append("comfirmdesignuser=@comfirmdesignuser,");
            strSql.Append("quoteuser=@quoteuser,");
            strSql.Append("comfirmquoteuser=@comfirmquoteuser,");
            strSql.Append("payuser=@payuser,");
            strSql.Append("comfirmpayuser=@comfirmpayuser,");

            strSql.Append("quoteattachment=@quoteattachment,");
            strSql.Append("quoteremark=@quoteremark,");
            strSql.Append("designattachment=@designattachment,");
            strSql.Append("designattachment2=@designattachment2,");
            strSql.Append("designattachment3=@designattachment3,");
            strSql.Append("designattachment4=@designattachment4,");
            strSql.Append("designattachment5=@designattachment5,");
            strSql.Append("designremark=@designremark,");
            strSql.Append("payattachment=@payattachment,");
            strSql.Append("payaremark=@payaremark,");
            strSql.Append("payamount=@payamount,");
            strSql.Append("completeremark=@completeremark,");
            strSql.Append("backremark=@backremark,");
            strSql.Append("payration=@payration");

            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@order_no", SqlDbType.NVarChar,100),
					new SqlParameter("@depot_category_id", SqlDbType.Int,4),
					new SqlParameter("@depot_id", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@payment_id", SqlDbType.Int,4),
					new SqlParameter("@payment_status", SqlDbType.TinyInt,1),
					new SqlParameter("@payment_time", SqlDbType.DateTime),
					new SqlParameter("@message", SqlDbType.NVarChar,500),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@payable_amount", SqlDbType.Decimal,5),
					new SqlParameter("@real_amount", SqlDbType.Decimal,5),
					new SqlParameter("@order_amount", SqlDbType.Decimal,5),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@confirm_time", SqlDbType.DateTime),
					new SqlParameter("@complete_time", SqlDbType.DateTime),
                    new SqlParameter("@order_date", SqlDbType.DateTime),
                    new SqlParameter("@need_date", SqlDbType.DateTime),
                    new SqlParameter("@ship_date", SqlDbType.DateTime),
                    new SqlParameter("@provice", SqlDbType.NVarChar,500),
                    new SqlParameter("@city", SqlDbType.NVarChar,500),
                    new SqlParameter("@area", SqlDbType.NVarChar,500),
                    new SqlParameter("@address", SqlDbType.NVarChar,500),
                    new SqlParameter("@contract_name", SqlDbType.NVarChar,500),
                    new SqlParameter("@contact_number", SqlDbType.NVarChar,500),

                    new SqlParameter("@designtime", SqlDbType.DateTime),
                    new SqlParameter("@comfirmdesigntime", SqlDbType.DateTime),
                    new SqlParameter("@quotetime", SqlDbType.DateTime),
                    new SqlParameter("@comfirmquotetime", SqlDbType.DateTime),
                    new SqlParameter("@paytime", SqlDbType.DateTime),
                    new SqlParameter("@comfirmpaytime", SqlDbType.DateTime),

                    new SqlParameter("@confirmuser", SqlDbType.NVarChar,500),
                    new SqlParameter("@completeuser", SqlDbType.NVarChar,500),
                    new SqlParameter("@adduser", SqlDbType.NVarChar,500),
                    new SqlParameter("@designuser", SqlDbType.NVarChar,500),
                    new SqlParameter("@comfirmdesignuser", SqlDbType.NVarChar,500),
                    new SqlParameter("@quoteuser", SqlDbType.NVarChar,500),
                    new SqlParameter("@comfirmquoteuser", SqlDbType.NVarChar,500),
                    new SqlParameter("@payuser", SqlDbType.NVarChar,500),
                    new SqlParameter("@comfirmpayuser", SqlDbType.NVarChar,500),

                    new SqlParameter("@quoteattachment", SqlDbType.NVarChar,500),
                    new SqlParameter("@quoteremark", SqlDbType.NVarChar,500),
                    new SqlParameter("@designattachment", SqlDbType.NVarChar,500),
                    new SqlParameter("@designattachment2", SqlDbType.NVarChar,500),
                    new SqlParameter("@designattachment3", SqlDbType.NVarChar,500),
                    new SqlParameter("@designattachment4", SqlDbType.NVarChar,500),
                    new SqlParameter("@designattachment5", SqlDbType.NVarChar,500),
                    new SqlParameter("@designremark", SqlDbType.NVarChar,500),
                    new SqlParameter("@payattachment", SqlDbType.NVarChar,500),
                    new SqlParameter("@payaremark", SqlDbType.NVarChar,500),
                    new SqlParameter("@payamount", SqlDbType.Decimal,5),
                    new SqlParameter("@completeremark", SqlDbType.NVarChar,500),
                    new SqlParameter("@backremark", SqlDbType.NVarChar,500),
                    new SqlParameter("@payration", SqlDbType.Decimal,5),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = order_no;
            parameters[1].Value = depot_category_id;
            parameters[2].Value = depot_id;
            parameters[3].Value = user_id;
            parameters[4].Value = user_name;
            parameters[5].Value = payment_id;
            parameters[6].Value = payment_status;
            parameters[7].Value = payment_time;
            parameters[8].Value = message;
            parameters[9].Value = remark;
            parameters[10].Value = payable_amount;
            parameters[11].Value = real_amount;
            parameters[12].Value = order_amount;
            parameters[13].Value = status;
            parameters[14].Value = add_time;
            parameters[15].Value = confirm_time;
            parameters[16].Value = complete_time;
            parameters[17].Value = order_date;
            parameters[18].Value = need_date;
            parameters[19].Value = ship_date;
            parameters[20].Value = provice;
            parameters[21].Value = city;
            parameters[22].Value = area;
            parameters[23].Value = address;
            parameters[24].Value = contract_name;
            parameters[25].Value = contact_number;

            parameters[26].Value = designtime;
            parameters[27].Value = comfirmdesigntime;
            parameters[28].Value = quotetime;
            parameters[29].Value = comfirmquotetime;
            parameters[30].Value = paytime;
            parameters[31].Value = comfirmpaytime;
            parameters[32].Value = confirmuser;
            parameters[33].Value = completeuser;
            parameters[34].Value = adduser;
            parameters[35].Value = designuser;
            parameters[36].Value = comfirmdesigntime;
            parameters[37].Value = quoteuser;
            parameters[38].Value = comfirmquoteuser;
            parameters[39].Value = payuser;
            parameters[40].Value = comfirmpayuser;




            parameters[41].Value = quoteattachment;
            parameters[42].Value = quoteremark;
            parameters[43].Value = designattachment;
            parameters[44].Value = designattachment2;
            parameters[45].Value = designattachment3;
            parameters[46].Value = designattachment4;
            parameters[47].Value = designattachment5;
        
            parameters[48].Value = designremark;
            parameters[49].Value = payattachment;
            parameters[50].Value = payaremark;
            parameters[51].Value = payamount;
            parameters[52].Value = completeremark;
            parameters[53].Value = backremark;
            parameters[54].Value = payration;

            parameters[55].Value = id;
            

                   
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
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [ps_orders] ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
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

    /// <summary>
    /// 删除一条数据
    /// </summary>
    public bool CancelOrder(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update [ps_orders] set status=@status ");
        strSql.Append(" where id=@id ");
        SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@status", SqlDbType.Int,4)};
        parameters[0].Value = id;
        parameters[1].Value = 10;

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
    public bool UpdateEpicorOrderNo(string orderno,string epicororderno)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update [ps_orders] set epicor_order_no=@epicororderno ");
        strSql.Append(" where order_no=@orderno ");
        SqlParameter[] parameters = {
                    new SqlParameter("@orderno", SqlDbType.NVarChar,200),
                    new SqlParameter("@epicororderno", SqlDbType.NVarChar,200)};
        parameters[0].Value = orderno;
        parameters[1].Value = epicororderno;

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

    public bool UpdateOrderAmount(int orderid)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("EXEC UpdateSOAmount "+ orderid + "");
        int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CancelEpicorQuote(int QuoteNum)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("EXEC CancelQuote " + QuoteNum + "");
        int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CancelEpicorOrder(int QuoteNum)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("EXEC CancelOrder " + QuoteNum + "");
        int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,order_no,epicor_order_no,depot_category_id,depot_id,user_id,user_name,payment_id,payment_status,payment_time,message,remark,payable_amount,real_amount,order_amount,status,add_time,confirm_time,complete_time,order_date,need_date,ship_date,provice,city,area,address,contract_name,contact_number,attachment1,attachment2,attachment3,attachment4, quoteattachment,quoteremark,designattachment,designattachment2,designattachment3,designattachment4,designattachment5,designremark,payattachment,payaremark,payamount,completeremark,confirm_time,designtime,comfirmdesigntime,quotetime,comfirmquotetime,comfirmpaytime,paytime,complete_time,backremark,payration");
            strSql.Append(" FROM [v_Orders] ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    this.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order_no"] != null)
                {
                    this.order_no = ds.Tables[0].Rows[0]["order_no"].ToString();
                }
                if (ds.Tables[0].Rows[0]["epicor_order_no"] != null)
                {
                    this.epicor_order_no = ds.Tables[0].Rows[0]["epicor_order_no"].ToString()=="" ? "未生成" : ds.Tables[0].Rows[0]["epicor_order_no"].ToString();
                }
                else
                {
                    this.epicor_order_no = "未生成";
                }
                if (ds.Tables[0].Rows[0]["depot_category_id"] != null && ds.Tables[0].Rows[0]["depot_category_id"].ToString() != "")
                {
                    this.depot_category_id = int.Parse(ds.Tables[0].Rows[0]["depot_category_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["depot_id"] != null && ds.Tables[0].Rows[0]["depot_id"].ToString() != "")
                {
                    this.depot_id = int.Parse(ds.Tables[0].Rows[0]["depot_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_id"] != null && ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    this.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_name"] != null)
                {
                    this.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["payment_id"] != null && ds.Tables[0].Rows[0]["payment_id"].ToString() != "")
                {
                    this.payment_id = int.Parse(ds.Tables[0].Rows[0]["payment_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["payment_status"] != null && ds.Tables[0].Rows[0]["payment_status"].ToString() != "")
                {
                    this.payment_status = int.Parse(ds.Tables[0].Rows[0]["payment_status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["payment_time"] != null && ds.Tables[0].Rows[0]["payment_time"].ToString() != "")
                {
                    this.payment_time = DateTime.Parse(ds.Tables[0].Rows[0]["payment_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["message"] != null)
                {
                    this.message = ds.Tables[0].Rows[0]["message"].ToString();
                }
                if (ds.Tables[0].Rows[0]["remark"] != null)
                {
                    this.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["payable_amount"] != null && ds.Tables[0].Rows[0]["payable_amount"].ToString() != "")
                {
                    this.payable_amount = decimal.Parse(ds.Tables[0].Rows[0]["payable_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["payration"] != null && ds.Tables[0].Rows[0]["payration"].ToString() != "")
                {
                    this.payration = decimal.Parse(ds.Tables[0].Rows[0]["payration"].ToString());
                }
            
                if (ds.Tables[0].Rows[0]["real_amount"] != null && ds.Tables[0].Rows[0]["real_amount"].ToString() != "")
                {
                    this.real_amount = decimal.Parse(ds.Tables[0].Rows[0]["real_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order_amount"] != null && ds.Tables[0].Rows[0]["order_amount"].ToString() != "")
                {
                    this.order_amount = decimal.Parse(ds.Tables[0].Rows[0]["order_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["status"] != null && ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    this.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"] != null && ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    this.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["confirm_time"] != null && ds.Tables[0].Rows[0]["confirm_time"].ToString() != "")
                {
                    this.confirm_time = DateTime.Parse(ds.Tables[0].Rows[0]["confirm_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["complete_time"] != null && ds.Tables[0].Rows[0]["complete_time"].ToString() != "")
                {
                    this.complete_time = DateTime.Parse(ds.Tables[0].Rows[0]["complete_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order_date"] != null && ds.Tables[0].Rows[0]["order_date"].ToString() != "")
                {
                    this.order_date = DateTime.Parse(ds.Tables[0].Rows[0]["order_date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["need_date"] != null && ds.Tables[0].Rows[0]["need_date"].ToString() != "")
                {
                    this.need_date = DateTime.Parse(ds.Tables[0].Rows[0]["need_date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ship_date"] != null && ds.Tables[0].Rows[0]["ship_date"].ToString() != "")
                {
                    this.ship_date = DateTime.Parse(ds.Tables[0].Rows[0]["ship_date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["provice"] != null)
                {
                    this.provice = ds.Tables[0].Rows[0]["provice"].ToString();
                }
                if (ds.Tables[0].Rows[0]["city"] != null)
                {
                    this.city = ds.Tables[0].Rows[0]["city"].ToString();
                }
                if (ds.Tables[0].Rows[0]["area"] != null)
                {
                    this.area = ds.Tables[0].Rows[0]["area"].ToString();
                }
                if (ds.Tables[0].Rows[0]["address"] != null)
                {
                    this.address = ds.Tables[0].Rows[0]["address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["contract_name"] != null)
                {
                    this.contract_name = ds.Tables[0].Rows[0]["contract_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["contact_number"] != null)
                {
                    this.contact_number = ds.Tables[0].Rows[0]["contact_number"].ToString();
                }
                if (ds.Tables[0].Rows[0]["attachment1"] != null)
                {
                    this.attachment1 = ds.Tables[0].Rows[0]["attachment1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["attachment2"] != null)
                {
                    this.attachment2 = ds.Tables[0].Rows[0]["attachment2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["attachment3"] != null)
                {
                    this.attachment3 = ds.Tables[0].Rows[0]["attachment3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["attachment4"] != null)
                {
                    this.attachment4 = ds.Tables[0].Rows[0]["attachment4"].ToString();
                }
                if (ds.Tables[0].Rows[0]["quoteattachment"] != null)
                {
                    this.quoteattachment = ds.Tables[0].Rows[0]["quoteattachment"].ToString();
                }
                if (ds.Tables[0].Rows[0]["quoteremark"] != null)
                {
                    this.quoteremark = ds.Tables[0].Rows[0]["quoteremark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["designattachment"] != null)
                {
                    this.designattachment = ds.Tables[0].Rows[0]["designattachment"].ToString();
                }
                if (ds.Tables[0].Rows[0]["designattachment2"] != null)
                {
                    this.designattachment2 = ds.Tables[0].Rows[0]["designattachment2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["designattachment3"] != null)
                {
                    this.designattachment3 = ds.Tables[0].Rows[0]["designattachment3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["designattachment4"] != null)
                {
                    this.designattachment4 = ds.Tables[0].Rows[0]["designattachment4"].ToString();
                }
                if (ds.Tables[0].Rows[0]["designattachment5"] != null)
                {
                    this.designattachment5 = ds.Tables[0].Rows[0]["designattachment5"].ToString();
                }

                if (ds.Tables[0].Rows[0]["designremark"] != null)
                {
                    this.designremark = ds.Tables[0].Rows[0]["designremark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["payattachment"] != null)
                {
                    this.payattachment = ds.Tables[0].Rows[0]["payattachment"].ToString();
                }
                if (ds.Tables[0].Rows[0]["payaremark"] != null)
                {
                    this.payaremark = ds.Tables[0].Rows[0]["payaremark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["payamount"] != null)
                {
                    this.payamount = decimal.Parse(ds.Tables[0].Rows[0]["payamount"].ToString()=="" ? "0" : ds.Tables[0].Rows[0]["payamount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["completeremark"] != null)
                {
                    this.completeremark = ds.Tables[0].Rows[0]["completeremark"].ToString();
                }
                //confirm_time,designtime,comfirmdesigntime,quotetime,comfirmquotetime,comfirmpaytime,paytime,complete_time
                if (ds.Tables[0].Rows[0]["confirm_time"] != null && ds.Tables[0].Rows[0]["confirm_time"].ToString() != "")
                {
                    this.confirm_time = DateTime.Parse(ds.Tables[0].Rows[0]["confirm_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["designtime"] != null && ds.Tables[0].Rows[0]["designtime"].ToString() != "")
                {
                    this.designtime = DateTime.Parse(ds.Tables[0].Rows[0]["designtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["comfirmdesigntime"] != null && ds.Tables[0].Rows[0]["comfirmdesigntime"].ToString() != "")
                {
                    this.comfirmdesigntime = DateTime.Parse(ds.Tables[0].Rows[0]["comfirmdesigntime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["quotetime"] != null && ds.Tables[0].Rows[0]["quotetime"].ToString() != "")
                {
                    this.quotetime = DateTime.Parse(ds.Tables[0].Rows[0]["quotetime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["comfirmquotetime"] != null && ds.Tables[0].Rows[0]["comfirmquotetime"].ToString() != "")
                {
                    this.comfirmquotetime = DateTime.Parse(ds.Tables[0].Rows[0]["comfirmquotetime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["paytime"] != null && ds.Tables[0].Rows[0]["paytime"].ToString() != "")
                {
                    this.paytime = DateTime.Parse(ds.Tables[0].Rows[0]["paytime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["comfirmpaytime"] != null && ds.Tables[0].Rows[0]["comfirmpaytime"].ToString() != "")
                {
                    this.comfirmpaytime = DateTime.Parse(ds.Tables[0].Rows[0]["comfirmpaytime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["complete_time"] != null && ds.Tables[0].Rows[0]["complete_time"].ToString() != "")
                {
                    this.complete_time = DateTime.Parse(ds.Tables[0].Rows[0]["complete_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["backremark"] != null && ds.Tables[0].Rows[0]["backremark"].ToString() != "")
                {
                    this.backremark = ds.Tables[0].Rows[0]["backremark"].ToString();
                }
            }
        }



    /// <summary>
    /// 根据订单号返回一个实体
    /// </summary>
    public void GetModel(string order_no)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select id,order_no,epicor_order_no,depot_category_id,depot_id,user_id,user_name,payment_id,payment_status,payment_time,message,remark,payable_amount,real_amount,order_amount,status,add_time,confirm_time,complete_time,order_date,need_date,ship_date,provice,city,area,address,contract_name,contact_number,discount_amount,quoteattachment,quoteremark,designattachment,designattachment2,designattachment3,designattachment4,designattachment5,designremark,payattachment,payaremark,payamount,completeremark,confirm_time,designtime,comfirmdesigntime,quotetime,comfirmquotetime,comfirmpaytime,paytime,complete_time,backremark,payration,attachment1,attachment2,attachment3,attachment4 ");
        strSql.Append(" FROM [ps_orders] ");
        strSql.Append(" where order_no=@order_no");
        SqlParameter[] parameters = {
				new SqlParameter("@order_no", SqlDbType.NVarChar,100)};
        parameters[0].Value = order_no;

        DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
            {
                this.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
            }
            if (ds.Tables[0].Rows[0]["order_no"] != null)
            {
                this.order_no = ds.Tables[0].Rows[0]["order_no"].ToString();
            }
            if (ds.Tables[0].Rows[0]["epicor_order_no"] != null)
            {
                this.epicor_order_no = ds.Tables[0].Rows[0]["epicor_order_no"].ToString() == "" ? "未生成" : ds.Tables[0].Rows[0]["epicor_order_no"].ToString();
            }
            else
            {
                this.epicor_order_no = "未生成";
            }
            if (ds.Tables[0].Rows[0]["depot_category_id"] != null && ds.Tables[0].Rows[0]["depot_category_id"].ToString() != "")
            {
                this.depot_category_id = int.Parse(ds.Tables[0].Rows[0]["depot_category_id"].ToString());
            }
            if (ds.Tables[0].Rows[0]["depot_id"] != null && ds.Tables[0].Rows[0]["depot_id"].ToString() != "")
            {
                this.depot_id = int.Parse(ds.Tables[0].Rows[0]["depot_id"].ToString());
            }
            if (ds.Tables[0].Rows[0]["user_id"] != null && ds.Tables[0].Rows[0]["user_id"].ToString() != "")
            {
                this.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
            }
            if (ds.Tables[0].Rows[0]["user_name"] != null)
            {
                this.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
            }
            if (ds.Tables[0].Rows[0]["payment_id"] != null && ds.Tables[0].Rows[0]["payment_id"].ToString() != "")
            {
                this.payment_id = int.Parse(ds.Tables[0].Rows[0]["payment_id"].ToString());
            }
            if (ds.Tables[0].Rows[0]["payment_status"] != null && ds.Tables[0].Rows[0]["payment_status"].ToString() != "")
            {
                this.payment_status = int.Parse(ds.Tables[0].Rows[0]["payment_status"].ToString());
            }
            if (ds.Tables[0].Rows[0]["payment_time"] != null && ds.Tables[0].Rows[0]["payment_time"].ToString() != "")
            {
                this.payment_time = DateTime.Parse(ds.Tables[0].Rows[0]["payment_time"].ToString());
            }
            if (ds.Tables[0].Rows[0]["message"] != null)
            {
                this.message = ds.Tables[0].Rows[0]["message"].ToString();
            }
            if (ds.Tables[0].Rows[0]["remark"] != null)
            {
                this.remark = ds.Tables[0].Rows[0]["remark"].ToString();
            }
            if (ds.Tables[0].Rows[0]["payable_amount"] != null && ds.Tables[0].Rows[0]["payable_amount"].ToString() != "")
            {
                this.payable_amount = decimal.Parse(ds.Tables[0].Rows[0]["payable_amount"].ToString());
            }
            if (ds.Tables[0].Rows[0]["real_amount"] != null && ds.Tables[0].Rows[0]["real_amount"].ToString() != "")
            {
                this.real_amount = decimal.Parse(ds.Tables[0].Rows[0]["real_amount"].ToString());
            }
            if (ds.Tables[0].Rows[0]["order_amount"] != null && ds.Tables[0].Rows[0]["order_amount"].ToString() != "")
            {
                this.order_amount = decimal.Parse(ds.Tables[0].Rows[0]["order_amount"].ToString());
            }
            if (ds.Tables[0].Rows[0]["discount_amount"] != null && ds.Tables[0].Rows[0]["discount_amount"].ToString() != "")
            {
                this.discount_amount = decimal.Parse(ds.Tables[0].Rows[0]["discount_amount"].ToString());
            }
            if (ds.Tables[0].Rows[0]["payration"] != null && ds.Tables[0].Rows[0]["payration"].ToString() != "")
            {
                this.payration = decimal.Parse(ds.Tables[0].Rows[0]["payration"].ToString());
            }
            if (ds.Tables[0].Rows[0]["status"] != null && ds.Tables[0].Rows[0]["status"].ToString() != "")
            {
                this.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
            }
            if (ds.Tables[0].Rows[0]["add_time"] != null && ds.Tables[0].Rows[0]["add_time"].ToString() != "")
            {
                this.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
            }
            if (ds.Tables[0].Rows[0]["confirm_time"] != null && ds.Tables[0].Rows[0]["confirm_time"].ToString() != "")
            {
                this.confirm_time = DateTime.Parse(ds.Tables[0].Rows[0]["confirm_time"].ToString());
            }
            if (ds.Tables[0].Rows[0]["complete_time"] != null && ds.Tables[0].Rows[0]["complete_time"].ToString() != "")
            {
                this.complete_time = DateTime.Parse(ds.Tables[0].Rows[0]["complete_time"].ToString());
            }
            if (ds.Tables[0].Rows[0]["order_date"] != null && ds.Tables[0].Rows[0]["order_date"].ToString() != "")
            {
                this.order_date = DateTime.Parse(ds.Tables[0].Rows[0]["order_date"].ToString());
            }
            if (ds.Tables[0].Rows[0]["need_date"] != null && ds.Tables[0].Rows[0]["need_date"].ToString() != "")
            {
                this.need_date = DateTime.Parse(ds.Tables[0].Rows[0]["need_date"].ToString());
            }
            if (ds.Tables[0].Rows[0]["ship_date"] != null && ds.Tables[0].Rows[0]["ship_date"].ToString() != "")
            {
                this.ship_date = DateTime.Parse(ds.Tables[0].Rows[0]["ship_date"].ToString());
            }
            if (ds.Tables[0].Rows[0]["provice"] != null)
            {
                this.provice = ds.Tables[0].Rows[0]["provice"].ToString();
            }
            if (ds.Tables[0].Rows[0]["city"] != null)
            {
                this.city = ds.Tables[0].Rows[0]["city"].ToString();
            }
            if (ds.Tables[0].Rows[0]["area"] != null)
            {
                this.area = ds.Tables[0].Rows[0]["area"].ToString();
            }
            if (ds.Tables[0].Rows[0]["address"] != null)
            {
                this.address = ds.Tables[0].Rows[0]["address"].ToString();
            }
            if (ds.Tables[0].Rows[0]["contract_name"] != null)
            {
                this.contract_name = ds.Tables[0].Rows[0]["contract_name"].ToString();
            }
            if (ds.Tables[0].Rows[0]["quoteattachment"] != null)
            {
                this.quoteattachment = ds.Tables[0].Rows[0]["quoteattachment"].ToString();
            }

            if (ds.Tables[0].Rows[0]["quoteremark"] != null)
            {
                this.quoteremark = ds.Tables[0].Rows[0]["quoteremark"].ToString();
            }
            if (ds.Tables[0].Rows[0]["designattachment"] != null)
            {
                this.designattachment = ds.Tables[0].Rows[0]["designattachment"].ToString();
            }
            if (ds.Tables[0].Rows[0]["designattachment2"] != null)
            {
                this.designattachment2 = ds.Tables[0].Rows[0]["designattachment2"].ToString();
            }
            if (ds.Tables[0].Rows[0]["designattachment3"] != null)
            {
                this.designattachment3 = ds.Tables[0].Rows[0]["designattachment3"].ToString();
            }
            if (ds.Tables[0].Rows[0]["designattachment4"] != null)
            {
                this.designattachment4 = ds.Tables[0].Rows[0]["designattachment4"].ToString();
            }
            if (ds.Tables[0].Rows[0]["designattachment5"] != null)
            {
                this.designattachment5 = ds.Tables[0].Rows[0]["designattachment5"].ToString();
            }
            if (ds.Tables[0].Rows[0]["designremark"] != null)
            {
                this.designremark = ds.Tables[0].Rows[0]["designremark"].ToString();
            }
            if (ds.Tables[0].Rows[0]["payattachment"] != null)
            {
                this.payattachment = ds.Tables[0].Rows[0]["payattachment"].ToString();
            }
            if (ds.Tables[0].Rows[0]["payaremark"] != null)
            {
                this.payaremark = ds.Tables[0].Rows[0]["payaremark"].ToString();
            }
            if (ds.Tables[0].Rows[0]["payamount"] != null)
            {
                this.payamount = decimal.Parse(ds.Tables[0].Rows[0]["payamount"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["payamount"].ToString());
            }
            if (ds.Tables[0].Rows[0]["completeremark"] != null)
            {
                this.completeremark = ds.Tables[0].Rows[0]["completeremark"].ToString();
            }
            if (ds.Tables[0].Rows[0]["confirm_time"] != null && ds.Tables[0].Rows[0]["confirm_time"].ToString() != "")
            {
                this.confirm_time = DateTime.Parse(ds.Tables[0].Rows[0]["confirm_time"].ToString());
            }
            if (ds.Tables[0].Rows[0]["designtime"] != null && ds.Tables[0].Rows[0]["designtime"].ToString() != "")
            {
                this.designtime = DateTime.Parse(ds.Tables[0].Rows[0]["designtime"].ToString());
            }
            if (ds.Tables[0].Rows[0]["comfirmdesigntime"] != null && ds.Tables[0].Rows[0]["comfirmdesigntime"].ToString() != "")
            {
                this.comfirmdesigntime = DateTime.Parse(ds.Tables[0].Rows[0]["comfirmdesigntime"].ToString());
            }
            if (ds.Tables[0].Rows[0]["quotetime"] != null && ds.Tables[0].Rows[0]["quotetime"].ToString() != "")
            {
                this.quotetime = DateTime.Parse(ds.Tables[0].Rows[0]["quotetime"].ToString());
            }
            if (ds.Tables[0].Rows[0]["comfirmquotetime"] != null && ds.Tables[0].Rows[0]["comfirmquotetime"].ToString() != "")
            {
                this.comfirmquotetime = DateTime.Parse(ds.Tables[0].Rows[0]["comfirmquotetime"].ToString());
            }
            if (ds.Tables[0].Rows[0]["paytime"] != null && ds.Tables[0].Rows[0]["paytime"].ToString() != "")
            {
                this.paytime = DateTime.Parse(ds.Tables[0].Rows[0]["paytime"].ToString());
            }
            if (ds.Tables[0].Rows[0]["comfirmpaytime"] != null && ds.Tables[0].Rows[0]["comfirmpaytime"].ToString() != "")
            {
                this.comfirmpaytime = DateTime.Parse(ds.Tables[0].Rows[0]["comfirmpaytime"].ToString());
            }
            if (ds.Tables[0].Rows[0]["complete_time"] != null && ds.Tables[0].Rows[0]["complete_time"].ToString() != "")
            {
                this.complete_time = DateTime.Parse(ds.Tables[0].Rows[0]["complete_time"].ToString());
            }
            if (ds.Tables[0].Rows[0]["backremark"] != null && ds.Tables[0].Rows[0]["backremark"].ToString() != "")
            {
                this.backremark = ds.Tables[0].Rows[0]["backremark"].ToString();
            }

            if (ds.Tables[0].Rows[0]["attachment1"] != null && ds.Tables[0].Rows[0]["attachment1"].ToString() != "")
            {
                this.attachment1 = ds.Tables[0].Rows[0]["attachment1"].ToString();
            }
            if (ds.Tables[0].Rows[0]["attachment2"] != null && ds.Tables[0].Rows[0]["attachment2"].ToString() != "")
            {
                this.attachment2 = ds.Tables[0].Rows[0]["attachment2"].ToString();
            }
            
            if (ds.Tables[0].Rows[0]["attachment3"] != null && ds.Tables[0].Rows[0]["attachment3"].ToString() != "")
            {
                this.attachment3 = ds.Tables[0].Rows[0]["attachment3"].ToString();
            }
            if (ds.Tables[0].Rows[0]["attachment4"] != null && ds.Tables[0].Rows[0]["attachment4"].ToString() != "")
            {
                this.attachment4 = ds.Tables[0].Rows[0]["attachment4"].ToString();
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
		strSql.Append(" FROM [ps_orders] ");
		if(strWhere.Trim()!="")
		{
			strSql.Append(" where "+strWhere);
		}
		return DbHelperSQL.Query(strSql.ToString());
	}

    /// <summary>
    /// 获得查询分页数据
    /// </summary>
    public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM  v_Orders");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

		#endregion  Method
	}


