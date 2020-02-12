﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace _2._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OleDbConnection con1 = new OleDbConnection();
            con1.ConnectionString = "provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source = ..\\..\\Bruinsma.accdb;" +
            "Persist Security Info = False;";
            con1.Open();

            String query = "SELECT * FROM Klanten";

            OleDbCommand comm = new OleDbCommand(query, con1);

            OleDbDataReader dbread = null;

            dbread = comm.ExecuteReader();
            while (dbread.Read())
            {
                lst_load.Items.Add(dbread["Voorletters"].ToString()
                + " " +
                dbread["Tussenvoegsel"].ToString() + " " +
                dbread["Achternaam"].ToString());
            }
            dbread.Close();
            con1.Close();

            if (lst_load.SelectedIndex > -1)
            {
                string selected_item = lst_load.GetItemText(lst_load.SelectedItem);
                OleDbConnection con2 = new OleDbConnection();
                con2.ConnectionString = "provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source = ..\\..\\Recepten.accdb;" +
              "Persist Security Info = False;";
                con2.Open();
                string query2 = "Select * FROM Klanten WHERE Voorletters ='" + selected_item + "'";
                txtvoornaam.Text = "";
                txtAchternaam.Text = "";
                txtTussenvoegsel.Text = "";
                txtStraat.Text = "";
                txtHuisnummer.Text = "";
                txtTvHuis.Text = "";
                txtPostcode.Text = "";
                txtWoonplaats.Text = "";
                txtTelefoon.Text = "";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        //string selected = listBox1.GetItemText(listBox1.SelectedItem);

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source = ..\\..\\Bruinsma.accdb;" +
            "Persist Security Info = False;";
            con.Open();
            String voornaam = txtvoornaam.Text;
            String achternaam = txtAchternaam.Text;
            String tussenvoeg = txtTussenvoegsel.Text;
            String Straat = txtStraat.Text;
            String Huisnummer = txtHuisnummer.Text;
            String Toevoeging = txtTvHuis.Text;
            String Postcode = txtPostcode.Text;
            String woonplaats = txtWoonplaats.Text;
            String telefoon = txtTelefoon.Text;
            String sql = "INSERT INTO Klanten (Voorletters,Tussenvoegsel,Achternaam,straat,Huisnummer,Toevoeging huisnummer,Postcode,Woonplaats,telfoon) VALUES('" + voornaam + "','" + tussenvoeg + "','" + achternaam + "','" + Straat + "','" + Huisnummer + "','" +Toevoeging+ "','" + Postcode + "','" + woonplaats + "','" + telefoon + "')";

            OleDbCommand comm = new OleDbCommand(sql, con);
            comm.ExecuteNonQuery();
            comm.Dispose();
            con.Close();
            

        }

      
    }
}
