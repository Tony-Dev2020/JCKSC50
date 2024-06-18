﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

	/// <summary>
	///操作日志-类
	/// </summary>
	[Serializable]
	public partial class ps_manager_log
	{
		public ps_manager_log()
		{}
		#region Model

		/// <summary>
		/// 
		/// </summary>
		public long id { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public int? user_id { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public string user_name { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public string action_type { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public string remark { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public string user_ip { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? add_time { set; get; }

		#endregion Model


		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [ps_manager_log]");
			strSql.Append(" where id=@id ");

			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [ps_manager_log] (");
			strSql.Append("user_id,user_name,action_type,remark,user_ip,add_time)");
			strSql.Append(" values (");
			strSql.Append("@user_id,@user_name,@action_type,@remark,@user_ip,@add_time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@action_type", SqlDbType.NVarChar,100),
					new SqlParameter("@remark", SqlDbType.NVarChar,int.MaxValue),
					new SqlParameter("@user_ip", SqlDbType.NVarChar,30),
					new SqlParameter("@add_time", SqlDbType.DateTime)};
			parameters[0].Value = user_id;
			parameters[1].Value = user_name;
			parameters[2].Value = action_type;
			parameters[3].Value = remark;
			parameters[4].Value = user_ip;
			parameters[5].Value = add_time;

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
	/// 增加一条数据
	/// </summary>
	public int AddLog(string user_id, string user_name, string action_type, string remark, string user_ip)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("insert into [ps_manager_log] (");
		strSql.Append("user_id,user_name,action_type,remark,user_ip,add_time)");
		strSql.Append(" values (");
		strSql.Append("@user_id,@user_name,@action_type,@remark,@user_ip,getdate())");
		strSql.Append(";select @@IDENTITY");
		SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.NVarChar,100),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@action_type", SqlDbType.NVarChar,100),
					new SqlParameter("@remark", SqlDbType.NVarChar,int.MaxValue),
					new SqlParameter("@user_ip", SqlDbType.NVarChar,30)};
		parameters[0].Value = user_id;
		parameters[1].Value = user_name;
		parameters[2].Value = action_type;
		parameters[3].Value = remark;
		parameters[4].Value = user_ip;

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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [ps_manager_log] set ");
			strSql.Append("user_id=@user_id,");
			strSql.Append("user_name=@user_name,");
			strSql.Append("action_type=@action_type,");
			strSql.Append("remark=@remark,");
			strSql.Append("user_ip=@user_ip,");
			strSql.Append("add_time=@add_time");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@action_type", SqlDbType.NVarChar,100),
					new SqlParameter("@remark", SqlDbType.NVarChar,255),
					new SqlParameter("@user_ip", SqlDbType.NVarChar,30),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.BigInt,8)};
			parameters[0].Value = user_id;
			parameters[1].Value = user_name;
			parameters[2].Value = action_type;
			parameters[3].Value = remark;
			parameters[4].Value = user_ip;
			parameters[5].Value = add_time;
			parameters[6].Value = id;

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
		/// 删除一条数据
		/// </summary>
		public bool Delete(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [ps_manager_log] ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
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
		public void GetModel(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,user_id,user_name,action_type,remark,user_ip,add_time ");
			strSql.Append(" FROM [ps_manager_log] ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = id;

			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					this.id=long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["user_id"]!=null && ds.Tables[0].Rows[0]["user_id"].ToString()!="")
				{
					this.user_id=int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["user_name"]!=null )
				{
					this.user_name=ds.Tables[0].Rows[0]["user_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["action_type"]!=null )
				{
					this.action_type=ds.Tables[0].Rows[0]["action_type"].ToString();
				}
				if(ds.Tables[0].Rows[0]["remark"]!=null )
				{
					this.remark=ds.Tables[0].Rows[0]["remark"].ToString();
				}
				if(ds.Tables[0].Rows[0]["user_ip"]!=null )
				{
					this.user_ip=ds.Tables[0].Rows[0]["user_ip"].ToString();
				}
				if(ds.Tables[0].Rows[0]["add_time"]!=null && ds.Tables[0].Rows[0]["add_time"].ToString()!="")
				{
					this.add_time=DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
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
			strSql.Append(" FROM [ps_manager_log] ");
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
            strSql.Append("select * FROM  ps_manager_log");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
		#endregion  Method
	}


