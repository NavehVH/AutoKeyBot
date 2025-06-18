using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace AutoKeyBot.App_Data
{
    public class Connection
    {
        private OleDbConnection con;
        private OleDbDataAdapter ad;

        public Connection(String database)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            string connString = "provider='Microsoft.jet.OleDb.4.0'; data source='|DataDirectory|\\App_Data\\program_data.mdb'";
            this.con = new OleDbConnection(connString);
        }

        public OleDbConnection Con
        {
            get { return this.con; }
            set { this.con = value; }
        }

        public OleDbDataReader getDataReader(String sqlStr)
        {
            this.con.Open();
            OleDbCommand cmd = new OleDbCommand(sqlStr, this.con);
            return cmd.ExecuteReader();
        }

        public DataSet getDataSet(String SqlStr, string TableName)
        {
            ad = new OleDbDataAdapter(SqlStr, this.con);
            DataSet ds = new DataSet();
            ad.Fill(ds, TableName);
            return ds;
        }

        public void conClose()
        {
            this.con.Close();
        }

        public void conOpen()
        {
             this.con.Open();
        }

        public bool NonQuery(String SqlStr)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand(SqlStr, this.con);
            int a = cmd.ExecuteNonQuery();
            conClose();
            return a > 0;
        }

        public void UpdateDataSet(DataSet ds)
        {
            OleDbCommandBuilder Builder = new OleDbCommandBuilder(ad);
            ad.InsertCommand = Builder.GetInsertCommand();
            ad.UpdateCommand = Builder.GetUpdateCommand();
            ad.DeleteCommand = Builder.GetDeleteCommand();
            ad.Update(ds.Tables[0]);
        }

        public void UpdateDataSet(DataSet ds, String TableName)
        {
            OleDbCommandBuilder Builder = new OleDbCommandBuilder(ad);
            ad.InsertCommand = Builder.GetInsertCommand();
            ad.UpdateCommand = Builder.GetUpdateCommand();
            ad.DeleteCommand = Builder.GetDeleteCommand();
            ad.Update(ds, TableName);
        }
    }
}