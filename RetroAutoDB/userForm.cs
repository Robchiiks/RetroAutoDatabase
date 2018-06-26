using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;
//using System.Data;

namespace RetroAutoDB
{
    public partial class userForm : Form
    {
        public password loginform;
        public UserAddData addData;
        public UserAddData data;

        public static string postgresConStr = "Server=localhost;Port=5432;UserId=roberts;Password=crashday;Database=retroauto;";
        public NpgsqlConnection ncon = new NpgsqlConnection(postgresConStr);


        DataTable dt_apdrosinasana;
        NpgsqlDataAdapter ad_apdrosinasana = new NpgsqlDataAdapter();//
        DataTable dt_auto;
        NpgsqlDataAdapter ad_auto = new NpgsqlDataAdapter();//
        DataTable dt_firma;
        NpgsqlDataAdapter ad_firma = new NpgsqlDataAdapter();//
        DataTable dt_godalga;
        NpgsqlDataAdapter ad_godalga = new NpgsqlDataAdapter();//
        DataTable dt_klubs;
        NpgsqlDataAdapter ad_klubs = new NpgsqlDataAdapter();//
        DataTable dt_krasa;
        NpgsqlDataAdapter ad_krasa = new NpgsqlDataAdapter();//
        DataTable dt_modelis;
        NpgsqlDataAdapter ad_modelis = new NpgsqlDataAdapter();//
        DataTable dt_persona;
        NpgsqlDataAdapter ad_persona = new NpgsqlDataAdapter();//
        DataTable dt_pilseta;
        NpgsqlDataAdapter ad_pilseta = new NpgsqlDataAdapter();//
        DataTable dt_tehniska_apskate;
        NpgsqlDataAdapter ad_tehniska_apskate = new NpgsqlDataAdapter();//
        
        public userForm()
        {
            InitializeComponent();
           //komandu definēšana
            NpgsqlCommand select_auto = new NpgsqlCommand("SELECT * FROM auto_uzskaite", ncon);
            NpgsqlCommand select_apdrosinasana = new NpgsqlCommand("SELECT * FROM apdrosinasanu_uzskaite", ncon);
            NpgsqlCommand select_godalga = new NpgsqlCommand("SELECT * FROM godalgu_uzskaite", ncon);
            NpgsqlCommand select_klubs = new NpgsqlCommand("SELECT * FROM klubu_uzskaite", ncon);
            NpgsqlCommand select_firma = new NpgsqlCommand("SELECT * FROM firmu_uzskaite", ncon);
            NpgsqlCommand select_krasa = new NpgsqlCommand("SELECT * FROM krasu_uzskaite", ncon);
            NpgsqlCommand select_modelis = new NpgsqlCommand("SELECT * FROM modelu_uzskaite", ncon);
            NpgsqlCommand select_persona = new NpgsqlCommand("SELECT * FROM personu_uzskaite", ncon);
            NpgsqlCommand select_pilseta = new NpgsqlCommand("SELECT * FROM pilsetu_uzskaite", ncon);
            NpgsqlCommand select_tehniska_apskate = new NpgsqlCommand("SELECT * FROM tehnisko_apskasu_uzskaite", ncon);
            //komandu izsaukšana
            ad_auto.SelectCommand = select_auto;
            ad_klubs.SelectCommand = select_klubs;
            ad_apdrosinasana.SelectCommand = select_apdrosinasana;
            ad_godalga.SelectCommand = select_godalga;
            ad_firma.SelectCommand = select_firma;
            ad_krasa.SelectCommand = select_krasa;
            ad_modelis.SelectCommand = select_modelis;
            ad_persona.SelectCommand = select_persona;
            ad_pilseta.SelectCommand = select_pilseta;
            ad_tehniska_apskate.SelectCommand = select_tehniska_apskate;
           

            //izvada pirmo tabulu stratējot formu
            dt_pilseta = new DataTable();
            ad_pilseta.Fill(dt_pilseta);
            dataGridViewUserForm.DataSource = dt_pilseta;

            dataGridViewUserForm.Columns["Pilseta"].HeaderText = "Pilseta";

            dataGridViewUserForm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

     
        //Datu izvade caur toolStrip Pogām
        #region izvade
        private void klubuuzskaiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Izvada [Kluba nosaukums], [Registreta adrese], [Registreta pilseta], [Vaditaja Vards], [Vaditaja Uzvards], [Biedru skaits]
            //
            //Izvada tukšu Tabulu
            dt_klubs = new DataTable();
            ad_klubs.Fill(dt_klubs);
            dataGridViewUserForm.DataSource = dt_klubs;

            dataGridViewUserForm.Columns["Kluba nosaukums"].HeaderText = "Kluba nosaukums";
            dataGridViewUserForm.Columns["Registreta adrese"].HeaderText = "Registreta adrese";
            dataGridViewUserForm.Columns["Registreta pilseta"].HeaderText = "Registreta pilseta";
            dataGridViewUserForm.Columns["Vaditaja Vards"].HeaderText = "Vaditaja Vards";
            dataGridViewUserForm.Columns["Vaditaja Uzvards"].HeaderText = "Vaditaja Uzvards";
            dataGridViewUserForm.Columns["Biedru skaits"].HeaderText = "Biedru skaits";
            dataGridViewUserForm.Columns[5].Visible = false;
            dataGridViewUserForm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void cityTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Izvada[Pilseta], [Registreto klubu skaits], [Registreto personu skaits]
            dt_pilseta = new DataTable();
            ad_pilseta.Fill(dt_pilseta);
            dataGridViewUserForm.DataSource = dt_pilseta;

            dataGridViewUserForm.Columns["Pilseta"].HeaderText = "Pilseta";
            dataGridViewUserForm.Columns["Registreto klubu skaits"].HeaderText = "Registreto klubu skaits";
            dataGridViewUserForm.Columns["Registreto personu skaits"].HeaderText = "Registreto personu skaits";
            dataGridViewUserForm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void personTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Izvada [Vards], [Uzvards], [Dzivesvieta], [Telefona numurs], [Kluba biedrs], [Auto uzskaite] 
            dt_persona = new DataTable();
            ad_persona.Fill(dt_persona);
            dataGridViewUserForm.DataSource = dt_persona;

            dataGridViewUserForm.Columns["Vards"].HeaderText = "Vards";
            dataGridViewUserForm.Columns["Uzvards"].HeaderText = "Uzvards";
            dataGridViewUserForm.Columns["Dzivesvieta"].HeaderText = "Dzivesvieta";
            dataGridViewUserForm.Columns["Telefona numurs"].HeaderText = "Telefona numurs";
            dataGridViewUserForm.Columns["Kluba biedrs"].HeaderText = "Kluba biedrs";
            dataGridViewUserForm.Columns["Auto uzskaite"].HeaderText = "Auto uzskaite";
            dataGridViewUserForm.Columns[5].Visible = false;
            dataGridViewUserForm.AutoSizeColumnsMode= DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Izvada [Firma], [Modelis], [Registreto auto skaits]
            dt_modelis = new DataTable();
            ad_modelis.Fill(dt_modelis);
            dataGridViewUserForm.DataSource = dt_modelis;

            dataGridViewUserForm.Columns["Firma"].HeaderText = "Firma";
            dataGridViewUserForm.Columns["Modelis"].HeaderText = "Modelis";
            dataGridViewUserForm.Columns["Registreto auto skaits"].HeaderText = "Registreto auto skaits";
            dataGridViewUserForm.Columns[2].Visible = false;
            dataGridViewUserForm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ensurancyTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Izvada [Apdrosinasana], [Apdrosinato_auto skaits]
            dt_apdrosinasana = new DataTable();
            ad_apdrosinasana.Fill(dt_apdrosinasana);
            dataGridViewUserForm.DataSource = dt_apdrosinasana;

            dataGridViewUserForm.Columns["Apdrosinasana"].HeaderText = "Apdrosinasana";
            dataGridViewUserForm.Columns["Apdrosinato_auto skaits"].HeaderText = "Apdrosinato_auto skaits";
            dataGridViewUserForm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void firmTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Izvada [Firma], [Registreto modelu skaits], [Registreto auto skaits]
            dt_firma = new DataTable();
            ad_firma.Fill(dt_firma);
            dataGridViewUserForm.DataSource = dt_firma;

            dataGridViewUserForm.Columns["Firma"].HeaderText = "Firma";
            dataGridViewUserForm.Columns["Registreto modelu skaits"].HeaderText = "Registreto modelu skaits";
            dataGridViewUserForm.Columns["Registreto auto skaits"].HeaderText = "Registreto auto skaits";
            dataGridViewUserForm.Columns[2].Visible = false;
            dataGridViewUserForm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void colorTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Izvada [Firma], [Registreto auto skaits]
            dt_krasa = new DataTable();
            ad_krasa.Fill(dt_krasa);
            dataGridViewUserForm.DataSource = dt_krasa;

            dataGridViewUserForm.Columns["Krasa"].HeaderText = "Krasa";
            dataGridViewUserForm.Columns["Registreto auto skaits"].HeaderText = "Registreto auto skaits";
        }

        private void tehniskoapskašuTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Izvada [Auto id], [Apskates datums], [Pilseta], [Piezime]
            dt_tehniska_apskate = new DataTable();
            ad_tehniska_apskate.Fill(dt_tehniska_apskate);
            dataGridViewUserForm.DataSource = dt_tehniska_apskate;

            dataGridViewUserForm.Columns["Auto id"].HeaderText = "Auto id";
            dataGridViewUserForm.Columns["Apskates datums"].HeaderText = "Apskates datums";
            dataGridViewUserForm.Columns["Pilseta"].HeaderText = "Pilseta";
            dataGridViewUserForm.Columns["Piezime"].HeaderText = "Piezime";
            dataGridViewUserForm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void awardsTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Izvada [Godalgas nosaukums], [Apbalvoto auto skaits]
            dt_godalga = new DataTable();
            ad_godalga.Fill(dt_godalga);
            dataGridViewUserForm.DataSource = dt_godalga;

            dataGridViewUserForm.Columns["Godalgas nosaukums"].HeaderText = "Godalgas nosaukums";
            dataGridViewUserForm.Columns["Apbalvoto auto skaits"].HeaderText = "Apbalvoto auto skaits";
            dataGridViewUserForm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void autoTablleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Izvada [Firma], [Modelis], [Auto nobraukums], [Krasa], [Tehniskas apskates id], [Apdrosinasana], [Ipasnieka vards], [Ipasnieka uzvards], [Auto cena], [godalgu skaits]
            dt_auto = new DataTable();
            ad_auto.Fill(dt_auto);
            dataGridViewUserForm.DataSource = dt_auto;

            dataGridViewUserForm.Columns["Firma"].HeaderText = "Firma";
            dataGridViewUserForm.Columns["Modelis"].HeaderText = "Modelis";
            dataGridViewUserForm.Columns["Auto nobraukums km"].HeaderText = "Auto nobraukums";
            dataGridViewUserForm.Columns["Krasa"].HeaderText = "Krasa";
            dataGridViewUserForm.Columns["Tehniskas apskates id"].HeaderText = "Tehniskas apskates id";
            dataGridViewUserForm.Columns["Apdrosinasana"].HeaderText = "Apdrosinasana";
            dataGridViewUserForm.Columns["Ipasnieka vards"].HeaderText = "Ipasnieka vards";
            dataGridViewUserForm.Columns["Ipasnieka uzvards"].HeaderText = "Ipasnieka uzvards";
            dataGridViewUserForm.Columns["Auto cena"].HeaderText = "Auto cena";
            dataGridViewUserForm.Columns[4].Visible = false;
            //dataGridViewUserForm.Columns["godalgu skaits"].HeaderText = "godalgu skaits";
            dataGridViewUserForm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

   

        private void loginAsAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // updateInfo();
            this.Hide();
            loginform = new password();
            loginform.ShowDialog();
        }

        private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //updateInfo();
        }
        private void updateInfo()
        {
            ad_apdrosinasana.Update((DataTable)dataGridViewUserForm.DataSource);
            ad_auto.Update((DataTable)dataGridViewUserForm.DataSource);
            ad_firma.Update((DataTable)dataGridViewUserForm.DataSource);
            ad_godalga.Update((DataTable)dataGridViewUserForm.DataSource);
            ad_klubs.Update((DataTable)dataGridViewUserForm.DataSource);
            ad_krasa.Update((DataTable)dataGridViewUserForm.DataSource);
            ad_modelis.Update((DataTable)dataGridViewUserForm.DataSource);
            ad_persona.Update((DataTable)dataGridViewUserForm.DataSource);
            ad_pilseta.Update((DataTable)dataGridViewUserForm.DataSource);
            ad_tehniska_apskate.Update((DataTable)dataGridViewUserForm.DataSource);

            NpgsqlTransaction trans = ncon.BeginTransaction();
            try
            {
                ad_apdrosinasana.Update(dt_apdrosinasana);
                ad_auto.Update(dt_auto);
                ad_firma.Update(dt_firma);
                ad_godalga.Update(dt_godalga);
                ad_klubs.Update(dt_klubs);
                ad_krasa.Update(dt_krasa);
                ad_modelis.Update(dt_modelis);
                ad_persona.Update(dt_persona);
                ad_pilseta.Update(dt_pilseta);
                ad_tehniska_apskate.Update(dt_tehniska_apskate);
                trans.Commit();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                trans.Rollback();
            }
        }

        private void aizvērtProgrammuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //updateInfo();
            Application.Exit();
        }

        private void backToLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // updateInfo();
            this.Close();
            loginform = new password();
            loginform.ShowDialog();
        }

        private void reģistrētAutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data = new UserAddData();
            data.ShowDialog();
      
         
        }


    }
}
