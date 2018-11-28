using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections;
//using System.Security.Cryptography;
//using System.Text;

/// <summary>
///DBhelper 的摘要说明
/// </summary>
public class DBhelperBase
{
	public DBhelperBase()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    //生成连接字符串
    public SqlConnection GetConn() {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Data Source=.\\SQLEXPRESS ;Uid=sa;Password=123456;Initial Catalog=BBS;";
        return conn;
    }
    //根据select sql语句，没有参数，返回一个DataTable
    public DataTable GetTable(string sql) {
        SqlConnection conn = this.GetConn();
        SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
        DataTable table = new DataTable();
        sda.Fill(table);
        return table;
    }
    //根据select sql语句，有参数，返回一个DataTable
    public DataTable GetTable(string sql,Hashtable ht)
    {
        SqlConnection conn = this.GetConn();
        SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
        foreach (DictionaryEntry de in ht) {
            sda.SelectCommand.Parameters.AddWithValue(de.Key.ToString(), de.Value.ToString());
        }
        DataTable table = new DataTable();
        sda.Fill(table);
        return table;
    }
    //根据select sql语句，没有参数，返回一个DataRow
    public DataRow GetRow(string sql)
    {
        DataRow row;
        if (this.GetTable(sql).Rows.Count >= 1)
        {
            row = this.GetTable(sql).Rows[0];
        }
        else
        {
            row = null;
        }
        return row;
    }
    ////根据select sql语句，有参数，返回一个DataRow
    public DataRow GetRow(string sql,Hashtable ht)
    {
        DataRow row;
        if (this.GetTable(sql).Rows.Count >= 1)
        {
            row = this.GetTable(sql,ht).Rows[0];
        }
        else
        {
            row = null;
        }
        return row;
    }
    //根据select sql语句，没有参数，返回首行首列的值
    public string GetValue(string sql) {
        string str = "";
        if (this.GetRow(sql) != null) {
            str = this.GetRow(sql)[0].ToString();
        }
        return str;
    }
    //根据select sql语句，有参数，返回首行首列的值
    public string GetValue(string sql, Hashtable ht)
    {
        string str = "";
        if (this.GetRow(sql, ht) != null)
        {
            str = this.GetRow(sql, ht)[0].ToString();
        }
        return str;
    }
    //根据存储过程，没有参数，返回一个DataTable
    public DataTable GetTableByProc(string procName)
    {
        SqlConnection conn = this.GetConn();
        SqlDataAdapter sda = new SqlDataAdapter(procName, conn);
        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataTable table = new DataTable();
        sda.Fill(table);
        return table;
    }
      //根据存储过程，有参数，返回一个DataTable
    public DataTable GetTableByProc(string procName, Hashtable ht)
    {
        SqlConnection conn = this.GetConn();
        SqlDataAdapter sda = new SqlDataAdapter(procName, conn);
        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
        foreach (DictionaryEntry de in ht)
        {
            sda.SelectCommand.Parameters.AddWithValue(de.Key.ToString(), de.Value.ToString());
        }
        DataTable table = new DataTable();
        sda.Fill(table);
        return table;
    }
    //根据存储过程，没有参数，返回一个DataRow
    public DataRow GetRowByProc(string procName)
    {
        DataRow row;
        if (this.GetTableByProc(procName).Rows.Count >= 1)
        {
            row = this.GetTableByProc(procName).Rows[0];
        }
        else
        {
            row = null;
        }
        return row;
    }
    //根据存储过程，有参数，返回一个DataRow
    public DataRow GetRowByProc(string procName, Hashtable ht)
    {
        DataRow row;
        if (this.GetTableByProc(procName, ht).Rows.Count >= 1)
        {
            row = this.GetTableByProc(procName, ht).Rows[0];
        }
        else
        {
            row = null;
        }
        return row;
    }
    //根据存储过程，没有参数，返回首行首列的值
    public string GetValueByProc(string procName)
    {
        string str = "";
        if (this.GetRowByProc(procName) != null)
        {
            str = this.GetRowByProc(procName)[0].ToString();
        }
        return str;
    }
    //根据存储过程，有参数，返回首行首列的值
    public string GetValueByProc(string procName, Hashtable ht)
    {
        string str = "";
        if (this.GetRowByProc(procName,ht) != null)
        {
            str = this.GetRowByProc(procName, ht)[0].ToString();
        }
        return str;
    }
    //普通sql语句，执行维护操作，没有参数
    public int Execute(string sql) {
        SqlConnection conn = this.GetConn();
        conn.Open();
        SqlCommand comm = new SqlCommand(sql,conn);
        int c = comm.ExecuteNonQuery();
        conn.Close();
        return c;
    }
    //普通sql语句，执行维护操作，有参数
    public int Execute(string sql, Hashtable ht)
    {
        SqlConnection conn = this.GetConn();
        conn.Open();
        SqlCommand comm = new SqlCommand(sql, conn);
        foreach (DictionaryEntry de in ht)
        {
            comm.Parameters.AddWithValue(de.Key.ToString(), de.Value.ToString());
        }
        int c = comm.ExecuteNonQuery();
        conn.Close();
        return c;
    }
    //存储过程，执行维护操作，没有参数
    public int ExecuteProc(string procName)
    {
        SqlConnection conn = this.GetConn();
        conn.Open();
        SqlCommand comm = new SqlCommand(procName, conn);
        comm.CommandType = CommandType.StoredProcedure;
        int c = comm.ExecuteNonQuery();
        conn.Close();
        return c;
    }
    //存储过程，执行维护操作，有参数
    public int ExecuteProc(string procName,Hashtable ht)
    {
        SqlConnection conn = this.GetConn();
        conn.Open();
        SqlCommand comm = new SqlCommand(procName, conn);
        comm.CommandType = CommandType.StoredProcedure;
        foreach (DictionaryEntry de in ht)
        {
            comm.Parameters.AddWithValue(de.Key.ToString(), de.Value.ToString());
        }
        int c = comm.ExecuteNonQuery();
        conn.Close();
        return c;
    }
    //public string Get_MD5(string strSource)
    //{
    //    MD5 md5 = new MD5CryptoServiceProvider();
    //    //获取密文字节数组
    //    byte[] bytResult = md5.ComputeHash(Encoding.Default.GetBytes(strSource));
    //    //转换为字符串，32位
    //    string strResult = BitConverter.ToString(bytResult);
    //    //BitConverter转换出来的字符串会在每个字符中间产生一个分隔符，需要去掉
    //    strResult = strResult.Replace("-", "");
    //    return strResult;

    //}
}