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
    public partial class UserAddData : Form
    {

        public static string postgresConStr = "Server=localhost;Port=5432;UserId=roberts;Password=crashday;Database=retroauto;";
        public NpgsqlConnection ncon = new NpgsqlConnection(postgresConStr);

        DataTable dt_apdrosinasana;
        NpgsqlDataAdapter ad_apdrosinasana = new NpgsqlDataAdapter();
        DataTable dt_auto;
        NpgsqlDataAdapter ad_auto = new NpgsqlDataAdapter();
        //DataTable dt_firma;
        NpgsqlDataAdapter ad_firma = new NpgsqlDataAdapter();
        //DataTable dt_godalga;
        NpgsqlDataAdapter ad_godalga = new NpgsqlDataAdapter();
        DataTable dt_klubs;
        NpgsqlDataAdapter ad_klubs = new NpgsqlDataAdapter();
        DataTable dt_krasa;
        NpgsqlDataAdapter ad_krasa = new NpgsqlDataAdapter();
        DataTable dt_modelis;
        NpgsqlDataAdapter ad_modelis = new NpgsqlDataAdapter();
        DataTable dt_persona;
        NpgsqlDataAdapter ad_persona = new NpgsqlDataAdapter();
        DataTable dt_pilseta;
        NpgsqlDataAdapter ad_pilseta = new NpgsqlDataAdapter();
        //DataTable dt_tehniska_apskate;
        NpgsqlDataAdapter ad_tehniska_apskate = new NpgsqlDataAdapter();

        //DataSet ds;
        public UserAddData()
        {
            InitializeComponent();

            #region persona
            //SELECT PERONA       
            NpgsqlCommand select_persona = new NpgsqlCommand("SELECT * FROM persona", ncon);
            //UPDATE PERSONA v
            NpgsqlCommand update_persona = new NpgsqlCommand("UPDATE persona SET vards=:vards, uzvards=:uzvards,dzivesvieta_id=:dzivesvieta_id, tel_numurs=:tel_numurs, klubs_id=:klubs_id, kluba_vaditajs=:kluba_vaditajs", ncon);
            update_persona.Parameters.Add(new NpgsqlParameter("@vards", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "vards"));
            update_persona.Parameters.Add(new NpgsqlParameter("@uzvards", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "uzvards"));
            update_persona.Parameters.Add(new NpgsqlParameter("@dzivesvieta_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "dzivesvieta_id"));
            update_persona.Parameters.Add(new NpgsqlParameter("@tel_numurs", NpgsqlTypes.NpgsqlDbType.Integer, 0, "tel_numurs"));
            update_persona.Parameters.Add(new NpgsqlParameter("@klubs_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "klubs_id"));
            update_persona.Parameters.Add(new NpgsqlParameter("@kluba_vaditajs", NpgsqlTypes.NpgsqlDbType.Integer, 0, "kluba_vaditajs"));
            //INSERT PERSONA
            NpgsqlCommand insert_persona = new NpgsqlCommand("INSERT INTO persona (vards,uzvards,dzivesvieta_id,tel_numurs,klubs_id,kluba_vaditajs) VALUES(:vards,:uzvards,:dzivesvieta_id,:tel_numurs,:klubs_id,:kluba_vaditajs)", ncon);
            insert_persona.Parameters.Add(new NpgsqlParameter("@vards", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "vards"));
            insert_persona.Parameters.Add(new NpgsqlParameter("@uzvards", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "uzvards"));
            insert_persona.Parameters.Add(new NpgsqlParameter("@dzivesvieta_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "dzivesvieta_id"));
            insert_persona.Parameters.Add(new NpgsqlParameter("@tel_numurs", NpgsqlTypes.NpgsqlDbType.Integer, 0, "tel_numurs"));
            insert_persona.Parameters.Add(new NpgsqlParameter("@klubs_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "klubs_id"));
            insert_persona.Parameters.Add(new NpgsqlParameter("@kluba_vaditajs", NpgsqlTypes.NpgsqlDbType.Integer, 0, "kluba_vaditajs"));
            //DELETE PERSONA
            NpgsqlCommand delete_persona = new NpgsqlCommand("DELETE FROM persona WHERE id_prs=:id_prs", ncon);
            delete_persona.Parameters.Add(new NpgsqlParameter("@id_prs", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_prs"));

            //KOMANDU UPDATE
            ad_persona.SelectCommand = select_persona;
            ad_persona.InsertCommand = insert_persona;
            ad_persona.UpdateCommand = update_persona;
            ad_persona.DeleteCommand = delete_persona;
            #endregion
            #region auto
            //SELECT AUTO
            NpgsqlCommand select_auto = new NpgsqlCommand("SELECT * FROM auto", ncon);
            //UPDATE AUTO
            NpgsqlCommand update_auto = new NpgsqlCommand("UPDATE auto SET modelis_id=:modelis_id,nobraukums=:nobraukums, izlaisanas_datums=:izlaisanas_datums, krasa_id=:krasa_id, tehniska_apskate=:tehniska_apskate,apdrosinasana_id=:apdrosinasana_id, ipasnieks_id=:ipasnieks_id, cena=:cena", ncon);
            update_auto.Parameters.Add(new NpgsqlParameter("@modelis_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "modelis_id"));
            update_auto.Parameters.Add(new NpgsqlParameter("@nobraukums", NpgsqlTypes.NpgsqlDbType.Integer, 0, "nobraukums"));
            update_auto.Parameters.Add(new NpgsqlParameter("@izlaisanas_datums", NpgsqlTypes.NpgsqlDbType.Date, 0, "izlaisanas_datums"));
            update_auto.Parameters.Add(new NpgsqlParameter("@krasa_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "krasa_id"));
            update_auto.Parameters.Add(new NpgsqlParameter("@tehniska_apskate", NpgsqlTypes.NpgsqlDbType.Integer, 0, "tehniska_apskate"));
            update_auto.Parameters.Add(new NpgsqlParameter("@apdrosinasana_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "apdrosinasana_id"));
            update_auto.Parameters.Add(new NpgsqlParameter("@ipasnieks_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "ipasnieks_id"));
            update_auto.Parameters.Add(new NpgsqlParameter("@cena", NpgsqlTypes.NpgsqlDbType.Integer, 0, "cena"));
            //INSERT AUTO 
            NpgsqlCommand insert_auto = new NpgsqlCommand("INSERT INTO auto (modelis_id,nobraukums,izlaisanas_datums,krasa_id,tehniska_apskate,apdrosinasana_id,ipasnieks_id,cena) VALUES(:modelis_id,:nobraukums,:izlaisanas_datums,:krasa_id,:tehniska_apskate,:apdrosinasana_id,:ipasnieks_id,:cena)", ncon);
            insert_auto.Parameters.Add(new NpgsqlParameter("@modelis_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "modelis_id"));
            insert_auto.Parameters.Add(new NpgsqlParameter("@nobraukums", NpgsqlTypes.NpgsqlDbType.Integer, 0, "nobraukums"));
            insert_auto.Parameters.Add(new NpgsqlParameter("@izlaisanas_datums", NpgsqlTypes.NpgsqlDbType.Date, 0, "izlaisanas_datums"));
            insert_auto.Parameters.Add(new NpgsqlParameter("@krasa_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "krasa_id"));
            insert_auto.Parameters.Add(new NpgsqlParameter("@tehniska_apskate", NpgsqlTypes.NpgsqlDbType.Integer, 0, "tehniska_apskate"));
            insert_auto.Parameters.Add(new NpgsqlParameter("@apdrosinasana_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "apdrosinasana_id"));
            insert_auto.Parameters.Add(new NpgsqlParameter("@ipasnieks_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "ipasnieks_id"));
            insert_auto.Parameters.Add(new NpgsqlParameter("@cena", NpgsqlTypes.NpgsqlDbType.Integer, 0, "cena"));
            //DELETE AUTO
            NpgsqlCommand delete_auto = new NpgsqlCommand("DELETE FROM auto WHERE id_at=:id_at", ncon);
            delete_persona.Parameters.Add(new NpgsqlParameter("@id_at", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_at"));

            //KOMANDU UPDATE
            ad_auto.SelectCommand = select_auto;
            ad_auto.InsertCommand = insert_auto;
            ad_auto.UpdateCommand = update_auto;
            ad_auto.DeleteCommand = delete_auto;
            #endregion   
            NpgsqlCommand select_modelis = new NpgsqlCommand("SELECT * FROM modelis", ncon);
            NpgsqlCommand select_krasa = new NpgsqlCommand("SELECT * FROM krasa", ncon);
            NpgsqlCommand select_pilseta = new NpgsqlCommand("SELECT * FROM pilseta", ncon);
            NpgsqlCommand select_klubs = new NpgsqlCommand("SELECT * FROM klubs", ncon);
            NpgsqlCommand select_tehniska_apskate = new NpgsqlCommand("SELECT * FROM tehniska_apskate", ncon);
            NpgsqlCommand select_apdrosinasana = new NpgsqlCommand("SELECT * FROM apdrosinasana", ncon);

            ad_modelis.SelectCommand = select_modelis;
            ad_krasa.SelectCommand = select_krasa;
            ad_pilseta.SelectCommand = select_pilseta;
            ad_klubs.SelectCommand = select_klubs;
            ad_apdrosinasana.SelectCommand = select_apdrosinasana;
            ad_tehniska_apskate.SelectCommand = select_tehniska_apskate;
        }    

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vai tiešām vēlaties iziet?", "Yes / No", MessageBoxButtons.OKCancel)== DialogResult.OK)
            {
                this.Close();
            }    
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewAddData.DataSource==dt_auto)
                            {
                                ad_auto.Update(dt_auto);
                            }
                            else if (dataGridViewAddData.DataSource==dt_persona)
                            {
                                ad_persona.Update(dt_persona);
                            }          
            }
            catch (System.ArgumentNullException)
            {

               
            }
              
 
        }

        private void personToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt_auto = new DataTable();
            dt_modelis = new DataTable();
            dt_krasa = new DataTable();
            dt_apdrosinasana = new DataTable();
            ad_auto.Fill(dt_auto);
            ad_modelis.Fill(dt_modelis);
            ad_krasa.Fill(dt_krasa);
            ad_apdrosinasana.Fill(dt_apdrosinasana);
            dataGridViewAddData.DataSource = dt_auto;


            DataGridViewComboBoxColumn modelis = new DataGridViewComboBoxColumn();
            modelis.DataSource = dt_modelis;
            modelis.DisplayMember = "modelis";
            modelis.HeaderText = "Auto modelis";
            modelis.DataPropertyName = "modelis_id";
            modelis.ValueMember = "id_md";
            dataGridViewAddData.Columns.Add(modelis);

            DataGridViewComboBoxColumn krasa = new DataGridViewComboBoxColumn();
            krasa.DataSource = dt_krasa;
            krasa.DisplayMember = "nosaukums";
            krasa.HeaderText = "Auto krāsa";
            krasa.DataPropertyName = "krasa_id";
            krasa.ValueMember = "id_kr";
            dataGridViewAddData.Columns.Add(krasa);

            DataGridViewComboBoxColumn apdrosinasana = new DataGridViewComboBoxColumn();
            apdrosinasana.DataSource = dt_apdrosinasana;
            apdrosinasana.DisplayMember = "firmas_nosaukums"; //nosaukums kaas atrodasdt_apdrosinasanā kur glabājas nosaukums
            apdrosinasana.HeaderText = "Auto apdrošināšana"; //kolonas nosaukums
            apdrosinasana.DataPropertyName = "apdrosinasana_id"; // auto kolonna kura ir saistīta ar dt_apdrosinasanu
            apdrosinasana.ValueMember = "id_apd";// dt_apdrosinsanas id kolonnas nosaukums
            dataGridViewAddData.Columns.Add(apdrosinasana);

            dataGridViewAddData.Columns["id_at"].Visible = false;//
            dataGridViewAddData.Columns["modelis_id"].Visible = false;//
            dataGridViewAddData.Columns["nobraukums"].HeaderText = "Nobraukums";
            dataGridViewAddData.Columns["izlaisanas_datums"].HeaderText = "Reģistrācijas datums";
            dataGridViewAddData.Columns["krasa_id"].Visible = false;//
            dataGridViewAddData.Columns["tehniska_apskate"].HeaderText = "Tehniskās apskates ID";
            dataGridViewAddData.Columns["apdrosinasana_id"].Visible = false;//
            dataGridViewAddData.Columns["ipasnieks_id"].HeaderText="Īpašnieka ID";
            dataGridViewAddData.Columns["cena"].HeaderText = "Cena";
            dataGridViewAddData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            dt_persona = new DataTable();
            dt_persona = new DataTable();
            dt_pilseta = new DataTable();
            dt_klubs = new DataTable();

            ad_persona.Fill(dt_persona);
            ad_pilseta.Fill(dt_pilseta);
            ad_klubs.Fill(dt_klubs);
            dataGridViewAddData.DataSource = dt_persona;

            DataGridViewComboBoxColumn dzivesvieta = new DataGridViewComboBoxColumn();
            dzivesvieta.DataSource = dt_pilseta;
            dzivesvieta.DisplayMember = "nosaukums";
            dzivesvieta.HeaderText = "Dzīvesvieta";
            dzivesvieta.DataPropertyName = "dzivesvieta_id";
            dzivesvieta.ValueMember = "id_pl";
            dataGridViewAddData.Columns.Add(dzivesvieta);

            DataGridViewComboBoxColumn klubs = new DataGridViewComboBoxColumn();
            klubs.DataSource = dt_klubs;
            klubs.DisplayMember = "nosaukums";
            klubs.HeaderText = "Klubs";
            klubs.DataPropertyName = "klubs_id";
            klubs.ValueMember = "id_kl";
            dataGridViewAddData.Columns.Add(klubs);

            dataGridViewAddData.Columns["id_prs"].Visible = false;//
            dataGridViewAddData.Columns["vards"].HeaderText = "Vārds";
            dataGridViewAddData.Columns["uzvards"].HeaderText = "Uzvārds";
            dataGridViewAddData.Columns["dzivesvieta_id"].Visible = false;//
            dataGridViewAddData.Columns["tel_numurs"].HeaderText = "tel_numurs";
            dataGridViewAddData.Columns["klubs_id"].Visible = false;//
            dataGridViewAddData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

    }
}
