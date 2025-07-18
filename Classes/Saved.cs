﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoKeyBot.App_Data;

namespace AutoKeyBot.Classes
{
    class Saved
    {
        private int id;
        private String bot;
        private String client;
        private int version;
        private String scriptText;

        public Saved(String bot)
        {
            String query = "SELECT * FROM saved WHERE bot = '" + bot + "'";
            Connection con = new Connection("program_data");
            OleDbDataReader r = con.getDataReader(query);
            if (r.Read())
            {
                this.id = r.GetInt32(0);
                this.bot = r.GetString(1);
                this.client = r.GetString(2);
                this.version = r.GetInt32(3);
                if (!r.IsDBNull(4))
                    this.scriptText = r.GetString(4);
                else
                    this.scriptText = "";
            }
            con.conClose();
        }

        public Saved(int id)
        {
            String query = "SELECT * FROM saved WHERE id = " + id + "";
            Connection con = new Connection("program_data");
            OleDbDataReader r = con.getDataReader(query);
            if (r.Read())
            {
                this.id = r.GetInt32(0);
                this.bot = r.GetString(1);
                this.client = r.GetString(2);
                this.version = r.GetInt32(3);
                if(!r.IsDBNull(4))
                    this.scriptText = r.GetString(4);
                else
                    this.scriptText = "";
            }
            con.conClose();
        }

        public Saved()
        {

        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; UpdateDb(); }
        }

        public String Bot
        {
            get { return this.bot; }
            set { this.bot = value; UpdateDb(); }
        }

        public String Client
        {
            get { return this.client; }
            set { this.client = value; UpdateDb(); }
        }

        public int Version
        {
            get { return this.version; }
            set { this.version = value; UpdateDb(); }
        }

        public String ScriptText
        {
            get { return this.scriptText; }
            set { this.scriptText = value; UpdateDb(); }
        }

        public void UpdateDb()
        {
            Connection con = new Connection("program_data");
            OleDbDataReader r = con.getDataReader("SELECT * FROM [saved] WHERE id = " + Id + "");
            if (r.Read())
            {
                con.conClose();
                con.NonQuery("UPDATE [saved] SET [bot] = '" + Bot + "', [client] = '" + Client + "', [version] = " + version + ", [scriptText] = '" + ScriptText + "' WHERE [Id] = " + Id + "");
            }
        }

        public void AddSaved()
        {
            Connection con = new Connection("program_data");
            OleDbDataReader r = con.getDataReader("SELECT * FROM [saved] WHERE [Id] = " + Id + "");
            if (!r.Read())
            {
                con.conClose();
                con.NonQuery("INSERT INTO [saved] ([bot], [client], [version], [scriptText]) VALUES ('" + Bot + "', '" + Client + "', " + Version + ", '" + ScriptText + "')");
            }
        }

        public void DeleteSaved()
        {
            Connection con = new Connection("program_data");
            OleDbDataReader r = con.getDataReader("SELECT * FROM [saved] WHERE id = " + Id + "");
            if (r.Read())
            {
                con.conClose();
                con.NonQuery("DELETE FROM [saved] WHERE id = " + Id + "");
            }
        }
    }
}
