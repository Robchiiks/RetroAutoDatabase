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
    public partial class adminForm : Form
    {
        public StartScreen loadingForm1;
    

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
        DataTable dt_auto_godalgas;
        NpgsqlDataAdapter ad_auto_godalgas = new NpgsqlDataAdapter();//


        //DataSet ds;

        public adminForm()
        {
            InitializeComponent();
            #region persona
            //SELECT PERONA       
            NpgsqlCommand select_persona = new NpgsqlCommand("SELECT * FROM persona", ncon);

            //UPDATE PERSONA 
            NpgsqlCommand update_persona = new NpgsqlCommand("UPDATE persona SET vards=:vards, uzvards=:uzvards,dzivesvieta_id=:dzivesvieta_id, tel_numurs=:tel_numurs, klubs_id=:klubs_id, kluba_vaditajs=:kluba_vaditajs where id_prs = :id_prs", ncon);
            update_persona.Parameters.Add(new NpgsqlParameter("@vards", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "vards"));
            update_persona.Parameters.Add(new NpgsqlParameter("@uzvards", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "uzvards"));
            update_persona.Parameters.Add(new NpgsqlParameter("@dzivesvieta_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "dzivesvieta_id"));
            update_persona.Parameters.Add(new NpgsqlParameter("@tel_numurs", NpgsqlTypes.NpgsqlDbType.Integer, 0, "tel_numurs"));
            update_persona.Parameters.Add(new NpgsqlParameter("@klubs_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "klubs_id"));
            update_persona.Parameters.Add(new NpgsqlParameter("@kluba_vaditajs", NpgsqlTypes.NpgsqlDbType.Integer, 0, "kluba_vaditajs"));
            update_persona.Parameters.Add(new NpgsqlParameter("@id_prs", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_prs"));
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
            NpgsqlCommand update_auto = new NpgsqlCommand("UPDATE auto SET modelis_id=:modelis_id,nobraukums=:nobraukums, izlaisanas_datums=:izlaisanas_datums, krasa_id=:krasa_id, tehniska_apskate=:tehniska_apskate,apdrosinasana_id=:apdrosinasana_id, ipasnieks_id=:ipasnieks_id, cena=:cena where (id_at = :id_at)", ncon);
            update_auto.Parameters.Add(new NpgsqlParameter("@modelis_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "modelis_id"));
            update_auto.Parameters.Add(new NpgsqlParameter("@nobraukums", NpgsqlTypes.NpgsqlDbType.Integer, 0, "nobraukums"));
            update_auto.Parameters.Add(new NpgsqlParameter("@izlaisanas_datums", NpgsqlTypes.NpgsqlDbType.Date, 0, "izlaisanas_datums"));
            update_auto.Parameters.Add(new NpgsqlParameter("@krasa_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "krasa_id"));
            update_auto.Parameters.Add(new NpgsqlParameter("@tehniska_apskate", NpgsqlTypes.NpgsqlDbType.Integer, 0, "tehniska_apskate"));
            update_auto.Parameters.Add(new NpgsqlParameter("@apdrosinasana_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "apdrosinasana_id"));
            update_auto.Parameters.Add(new NpgsqlParameter("@ipasnieks_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "ipasnieks_id"));
            update_auto.Parameters.Add(new NpgsqlParameter("@cena", NpgsqlTypes.NpgsqlDbType.Integer, 0, "cena"));
            update_auto.Parameters.Add(new NpgsqlParameter("@id_at", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_at"));

            NpgsqlCommand insert_auto = new NpgsqlCommand("INSERT INTO auto (modelis_id,nobraukums,izlaisanas_datums,krasa_id,tehniska_apskate,apdrosinasana_id,ipasnieks_id,cena) VALUES(:modelis_id,:nobraukums,:izlaisanas_datums,:krasa_id,:tehniska_apskate,:apdrosinasana_id,:ipasnieks_id,:cena)", ncon);
            insert_auto.Parameters.Add(new NpgsqlParameter("@modelis_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "modelis_id"));
            insert_auto.Parameters.Add(new NpgsqlParameter("@nobraukums", NpgsqlTypes.NpgsqlDbType.Integer, 0, "nobraukums"));
            insert_auto.Parameters.Add(new NpgsqlParameter("@izlaisanas_datums", NpgsqlTypes.NpgsqlDbType.Date, 0, "izlaisanas_datums"));
            insert_auto.Parameters.Add(new NpgsqlParameter("@krasa_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "krasa_id"));
            insert_auto.Parameters.Add(new NpgsqlParameter("@tehniska_apskate", NpgsqlTypes.NpgsqlDbType.Integer, 0, "tehniska_apskate"));
            insert_auto.Parameters.Add(new NpgsqlParameter("@apdrosinasana_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "apdrosinasana_id"));
            insert_auto.Parameters.Add(new NpgsqlParameter("@ipasnieks_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "ipasnieks_id"));
            insert_auto.Parameters.Add(new NpgsqlParameter("@cena", NpgsqlTypes.NpgsqlDbType.Integer, 0, "cena"));


            ////INSERT AUTO 
            //NpgsqlCommand insert_auto = new NpgsqlCommand("INSERT INTO auto (modelis_id,nobraukums,izlaisanas_datums,krasa_id,tehniska_apskate,apdrosinasana_id,ipasnieks_id,cena) VALUES(:modelis_id,:nobraukums,:izlaisanas_datums,:krasa_id,:tehniska_apskate,:apdrosinasana_id,:ipasnieks_id,:cena)", ncon);
            //insert_auto.Parameters.Add(new NpgsqlParameter("@modelis_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "modelis_id"));
            //insert_auto.Parameters.Add(new NpgsqlParameter("@nobraukums", NpgsqlTypes.NpgsqlDbType.Integer, 0, "nobraukums"));
            //insert_auto.Parameters.Add(new NpgsqlParameter("@izlaisanas_datums", NpgsqlTypes.NpgsqlDbType.Date, 0, "izlaisanas_datums"));
            //insert_auto.Parameters.Add(new NpgsqlParameter("@krasa_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "krasa_id"));
            //insert_auto.Parameters.Add(new NpgsqlParameter("@tehniska_apskate", NpgsqlTypes.NpgsqlDbType.Integer, 0, "tehniska_apskate"));
            //insert_auto.Parameters.Add(new NpgsqlParameter("@apdrosinasana_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "apdrosinasana_id"));
            //insert_auto.Parameters.Add(new NpgsqlParameter("@ipasnieks_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "ipasnieks_id"));
            //insert_auto.Parameters.Add(new NpgsqlParameter("@cena", NpgsqlTypes.NpgsqlDbType.Integer, 0, "cena"));
            //DELETE AUTO
            NpgsqlCommand delete_auto = new NpgsqlCommand("DELETE FROM auto WHERE id_at=:id_at", ncon);
            delete_auto.Parameters.Add(new NpgsqlParameter("@id_at", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_at"));

            //KOMANDU UPDATE
           
            ad_auto.SelectCommand = select_auto;
            ad_auto.InsertCommand = insert_auto;
            ad_auto.UpdateCommand = update_auto;
            ad_auto.DeleteCommand = delete_auto;
            
            #endregion
            #region klubs
            //SELECT KLUBS
            NpgsqlCommand select_klubs = new NpgsqlCommand("SELECT * FROM klubs",ncon);
            //UPDATE KLUBS
            NpgsqlCommand update_klubs = new NpgsqlCommand("UPDATE klubs SET nosaukums=:nosaukums, adrese=:adrese, pilseta_id=:pilseta_id, dibinasanas_datums=:dibinasanas_datums where (id_kl = :id_kl)", ncon);
            update_klubs.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "nosaukums"));
            update_klubs.Parameters.Add(new NpgsqlParameter("@adrese", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "adrese"));
            update_klubs.Parameters.Add(new NpgsqlParameter("@pilseta_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "pilseta_id"));
            update_klubs.Parameters.Add(new NpgsqlParameter("@dibinasanas_datums", NpgsqlTypes.NpgsqlDbType.Date, 0, "dibinasanas_datums"));
            //INSERT KLUBS
            NpgsqlCommand insert_klubs = new NpgsqlCommand("INSERT INTO klubs (nosaukums,adrese,pilseta_id,dibinasanas_datums) VALUES(:nosaukums,:adrese,:pilseta_id,:dibinasanas_datums)", ncon);
            insert_klubs.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "nosaukums"));
            insert_klubs.Parameters.Add(new NpgsqlParameter("@adrese", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "adrese"));
            insert_klubs.Parameters.Add(new NpgsqlParameter("@pilseta_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "pilseta_id"));
            insert_klubs.Parameters.Add(new NpgsqlParameter("@dibinasanas_datums", NpgsqlTypes.NpgsqlDbType.Date, 0, "dibinasanas_datums"));
            //DELETE KLUBS
            NpgsqlCommand delete_klubs = new NpgsqlCommand("DELETE FROM klubs WHERE id_kl=:id_kl", ncon);
            delete_klubs.Parameters.Add(new NpgsqlParameter("@id_kl", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_kl"));

            //KOMANDU UPDATE
            ad_klubs.SelectCommand = select_klubs;
            ad_klubs.InsertCommand = insert_klubs;
            ad_klubs.UpdateCommand = update_klubs;
            ad_klubs.DeleteCommand = delete_klubs;
            
            #endregion
            #region auto_godalgas
            //SELECT AUTO_GODALGAS
            NpgsqlCommand select_auto_godalgas = new NpgsqlCommand("SELECT * FROM auto_godalgas_index",ncon);
            //UPDATE AUTO_GODALGAS,  WHERE (id_agi = :id_agi)
            NpgsqlCommand update_auto_godalgas = new NpgsqlCommand("UPDATE auto_godalgas_index SET auto_id=:auto_id, godalga_id=:godalga_id where (id_agi = :id_agi)", ncon); 
            update_auto_godalgas.Parameters.Add(new NpgsqlParameter("@auto_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "auto_id"));
            update_auto_godalgas.Parameters.Add(new NpgsqlParameter("@godalga_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "godalga_id"));
            update_auto_godalgas.Parameters.Add(new NpgsqlParameter("@id_agi", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_agi"));

            //INSERT_AUTO_GODALGAS
            NpgsqlCommand insert_auto_godalgas = new NpgsqlCommand("INSERT INTO auto_godalgas_index (auto_id,godalga_id) VALUES (:auto_id,:godalga_id)", ncon);
            update_auto_godalgas.Parameters.Add(new NpgsqlParameter("@auto_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "auto_id"));
            update_auto_godalgas.Parameters.Add(new NpgsqlParameter("@godalga_id", NpgsqlTypes.NpgsqlDbType.Integer, 0, "godalga_id"));
            //update_auto_godalgas.Parameters.Add(new NpgsqlParameter("@id_agi", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_agi"));
            //DELETE_AUTO_GODALGAS
            NpgsqlCommand delete_auto_godalgas = new NpgsqlCommand("DELETE FROM auto_godalgas_index WHERE id_agi=:id_agi", ncon);
            delete_auto_godalgas.Parameters.Add(new NpgsqlParameter("@id_agi", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_agi"));
            
            //KOMANDU UPDATE
            ad_auto_godalgas.SelectCommand = select_auto_godalgas;
            ad_auto_godalgas.InsertCommand = insert_auto_godalgas;
            ad_auto_godalgas.UpdateCommand = update_auto_godalgas;
            ad_auto_godalgas.DeleteCommand = delete_auto_godalgas;
            
            #endregion
            #region modelis
            //SELECT MODELIS
            NpgsqlCommand select_modelis = new NpgsqlCommand("SELECT * FROM modelis",ncon);
            //UPDATE MODELIS
            NpgsqlCommand update_modelis = new NpgsqlCommand("UPDATE modelis SET id_firma=:id_firma, modelis:modelis where (id_md = :id_md)", ncon);
            update_modelis.Parameters.Add(new NpgsqlParameter("@id_firma", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_firma"));
            update_modelis.Parameters.Add(new NpgsqlParameter("@modelis", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "modelis"));
            update_modelis.Parameters.Add(new NpgsqlParameter("@id_md", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_md"));

            //INSERT MODELIS
            NpgsqlCommand insert_modelis = new NpgsqlCommand("INSERT INTO modelis (id_firma,modelis) VALUES(:id_firma,:modelis)", ncon);
            insert_modelis.Parameters.Add(new NpgsqlParameter("@id_firma", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_firma"));
            insert_modelis.Parameters.Add(new NpgsqlParameter("@modelis", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "modelis"));
            //DELETE MODELIS
            NpgsqlCommand delete_modelis = new NpgsqlCommand("DELETE FROM modelis WHERE id_md=:id_md", ncon);
            delete_modelis.Parameters.Add(new NpgsqlParameter("@id_md", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_md"));

            //KOMANDU UPDATE
            ad_modelis.SelectCommand = select_modelis;
            ad_modelis.InsertCommand = insert_modelis;
            ad_modelis.UpdateCommand = update_modelis;
            ad_modelis.DeleteCommand = delete_modelis;
            
            #endregion
            #region apdrosinasana
            //SELECT APDROSINASANA
            NpgsqlCommand select_apdrosinasana = new NpgsqlCommand("SELECT * FROM apdrosinasana",ncon);
            //UPDATE APDROSINASANA
            NpgsqlCommand update_apdrosinasana = new NpgsqlCommand("UPDATE apdrosinasana SET firmas_nosaukums=:firmas_nosaukums where (id_apd = :id_apd)", ncon);
            update_apdrosinasana.Parameters.Add(new NpgsqlParameter("@firmas_nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "firmas_nosaukums"));
            update_apdrosinasana.Parameters.Add(new NpgsqlParameter("@id_apd", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_apd"));

            //INSERT APDROSINASANA
            NpgsqlCommand insert_apdrosinasana = new NpgsqlCommand("INSERT INTO apdrosinasana (firmas_nosaukums) VALUES(:firmas_nosaukums)", ncon);
            insert_apdrosinasana.Parameters.Add(new NpgsqlParameter("@firmas_nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "firmas_nosaukums"));
            //DELETE APDROSINASANA
            NpgsqlCommand delete_apdrosinasana = new NpgsqlCommand("DELETE FROM apdrosinasana WHERE id_apd=:id_apd", ncon);
            delete_apdrosinasana.Parameters.Add(new NpgsqlParameter("@id_apd", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_apd"));

            //KOMANDU UPDATE
            ad_apdrosinasana.SelectCommand = select_apdrosinasana;
            ad_apdrosinasana.InsertCommand = insert_apdrosinasana;
            ad_apdrosinasana.UpdateCommand = update_apdrosinasana;
            ad_apdrosinasana.DeleteCommand = delete_apdrosinasana;
           
            #endregion
            #region firma
            //SELECT FIRMA
            NpgsqlCommand select_firma = new NpgsqlCommand("SELECT * FROM firma",ncon);
            //UPDATE FIRMA
            NpgsqlCommand update_firma = new NpgsqlCommand("UPDATE firma SET nosaukums=:nosaukums where (id_fr = :id_fr)", ncon);
            update_firma.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "nosaukums"));
            update_firma.Parameters.Add(new NpgsqlParameter("@id_fr", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_fr"));

            //INSERT FIRMA
            NpgsqlCommand insert_firma = new NpgsqlCommand("INSERT INTO firma (nosaukums) VALUES(:nosaukums)", ncon);
            insert_firma.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "nosaukums"));
            //DELETE FIRMA
            NpgsqlCommand delete_firma = new NpgsqlCommand("DELETE FROM firma WHERE id_fr=:id_fr", ncon);
            delete_firma.Parameters.Add(new NpgsqlParameter("@id_fr", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_fr"));

            //KOMANDU UPDATE
            ad_firma.SelectCommand = select_firma;
            ad_firma.InsertCommand = insert_firma;
            ad_firma.UpdateCommand = update_firma;
            ad_firma.DeleteCommand = delete_firma;
           
            #endregion
            #region godalga
            //SELECT GODALGA
            NpgsqlCommand select_godalga = new NpgsqlCommand("SELECT * FROM godalga",ncon);
            //UPDATE GODALGA
            NpgsqlCommand update_godalga = new NpgsqlCommand("UPDATE godalga SET nosaukums=:nosaukums where (id_gl = :id_gl)", ncon);
            update_godalga.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "nosaukums"));
            update_godalga.Parameters.Add(new NpgsqlParameter("@id_gl", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_gl"));

            //INSERT GODALGA
            NpgsqlCommand insert_godalga = new NpgsqlCommand("INSERT INTO godalga (nosaukums) VALUES(:nosaukums)", ncon);
            insert_godalga.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "nosaukums"));
            //DELETE GODALGA
            NpgsqlCommand delete_godalga = new NpgsqlCommand("DELETE FROM godalga WHERE id_gl=:id_gl", ncon);
            delete_godalga.Parameters.Add(new NpgsqlParameter("@id_gl", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_gl"));

            //KOMANDU UPDATE
            ad_godalga.SelectCommand = select_godalga;
            ad_godalga.InsertCommand = insert_godalga;
            ad_godalga.UpdateCommand = update_godalga;
            ad_godalga.DeleteCommand = delete_godalga;
            
            #endregion
            #region krasa
            //SELECT KRASA
            NpgsqlCommand select_krasa = new NpgsqlCommand("SELECT * FROM krasa",ncon);
            //UPDATE KRASA
            NpgsqlCommand update_krasa = new NpgsqlCommand("UPDATE krasa SET nosaukums=:nosaukums where (id_kr = :id_kr)", ncon);
            update_krasa.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "nosaukums"));
            update_krasa.Parameters.Add(new NpgsqlParameter("@id_kr", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_kr"));

            //INSERT KRASA
            NpgsqlCommand insert_krasa = new NpgsqlCommand("INSERT INTO krasa (nosaukums) VALUES(:nosaukums)", ncon);
            insert_krasa.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "nosaukums"));
            //DELETE KRASA
            NpgsqlCommand delete_krasa = new NpgsqlCommand("DELETE FROM krasa WHERE id_kr=:id_kr", ncon);
            delete_krasa.Parameters.Add(new NpgsqlParameter("@id_kr", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_kr"));

            //KOMANDU UPDATE
            ad_krasa.SelectCommand = select_krasa;
            ad_krasa.InsertCommand = insert_krasa;
            ad_krasa.UpdateCommand = update_krasa;
            ad_krasa.DeleteCommand = delete_krasa;
            
            #endregion
            #region pilseta
           
            //SELECT PILSETA
            NpgsqlCommand select_pilseta = new NpgsqlCommand("SELECT * FROM pilseta",ncon);
            //UPDATE PILSETA
            NpgsqlCommand update_pilseta = new NpgsqlCommand("UPDATE pilseta SET nosaukums=:nosaukums where (id_pl = :id_pl)", ncon);
            update_pilseta.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "nosaukums"));
            update_pilseta.Parameters.Add(new NpgsqlParameter("@id_pl", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_pl"));

            //INSERT PILSETA
            NpgsqlCommand insert_pilseta = new NpgsqlCommand("INSERT INTO pilseta (nosaukums) VALUES(:nosaukums)", ncon);
            insert_pilseta.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "nosaukums"));
            //DELETE PILSETA
            NpgsqlCommand delete_pilseta = new NpgsqlCommand("DELETE FROM pilseta WHERE id_pl=:id_pl", ncon);
            delete_pilseta.Parameters.Add(new NpgsqlParameter("@id_pl", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_pl"));

            //KOMANDU UPDATE
            
            ad_pilseta.SelectCommand = select_pilseta;
            ad_pilseta.InsertCommand = insert_pilseta;
            ad_pilseta.UpdateCommand = update_pilseta;
            ad_pilseta.DeleteCommand = delete_pilseta;
            
            #endregion
            #region tehniska_apskate
            //SELECT TEHNISKA_APSKATE
            NpgsqlCommand select_tehniska_apskate_ = new NpgsqlCommand("SELECT * FROM tehniska_apskate",ncon);
            //UPDATE TEHNISKA_APSKATE
            NpgsqlCommand update_tehniska_apskate = new NpgsqlCommand("UPDATE tehniska_apskate SET  apskates_datums=:apskates_datums, apskates_vieta=:apskates_vieta, piezime=:piezime where (id_tap = :id_tap)", ncon);
            update_tehniska_apskate.Parameters.Add(new NpgsqlParameter("@apskates_datums", NpgsqlTypes.NpgsqlDbType.Date, 0, "apskates_datums"));
            update_tehniska_apskate.Parameters.Add(new NpgsqlParameter("@apskates_vieta", NpgsqlTypes.NpgsqlDbType.Integer, 0, "apskates_vieta"));
            update_tehniska_apskate.Parameters.Add(new NpgsqlParameter("@piezime", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "piezime"));
            update_tehniska_apskate.Parameters.Add(new NpgsqlParameter("@id_tap", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_tap"));

            //INSERT TEHNISKA_APSKATE
            NpgsqlCommand insert_tehniska_apskate = new NpgsqlCommand("INSERT INTO tehniska_apskate (apskates_datums, apskates_vieta, piezime) VALUES (:apskates_datums, :apskates_vieta, :piezime)", ncon);
            update_tehniska_apskate.Parameters.Add(new NpgsqlParameter("@apskates_datums", NpgsqlTypes.NpgsqlDbType.Date, 0, "apskates_datums"));
            update_tehniska_apskate.Parameters.Add(new NpgsqlParameter("@apskates_vieta", NpgsqlTypes.NpgsqlDbType.Integer, 0, "apskates_vieta"));
            update_tehniska_apskate.Parameters.Add(new NpgsqlParameter("@piezime", NpgsqlTypes.NpgsqlDbType.Varchar, 0, "piezime"));
            //DELETE TEHNISKA_APSKATE
            NpgsqlCommand delete_tehniska_apskate = new NpgsqlCommand("DELETE FROM tehniska_apskate WHERE id_tap=:id_tap", ncon);
            delete_tehniska_apskate.Parameters.Add(new NpgsqlParameter("@id_tap", NpgsqlTypes.NpgsqlDbType.Integer, 0, "id_tap"));

            //KOMANDU UPDATE
            ad_tehniska_apskate.SelectCommand = select_tehniska_apskate_;
            ad_tehniska_apskate.InsertCommand = insert_tehniska_apskate;
            ad_tehniska_apskate.UpdateCommand = update_tehniska_apskate;
            ad_tehniska_apskate.DeleteCommand = delete_tehniska_apskate;
           
            #endregion
        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt_auto = new DataTable();
            dt_modelis = new DataTable();
            dt_krasa = new DataTable();
            dt_apdrosinasana = new DataTable();

            ad_modelis.Fill(dt_modelis);
            ad_krasa.Fill(dt_krasa);
            ad_apdrosinasana.Fill(dt_apdrosinasana);          
            ad_auto.Fill(dt_auto);

            dataGridViewAdminform.DataSource = dt_auto;

            DataGridViewComboBoxColumn modelis = new DataGridViewComboBoxColumn();
            modelis.DataSource = dt_modelis;
            modelis.DisplayMember = "modelis";
            modelis.HeaderText = "Auto modelis";
            modelis.DataPropertyName = "modelis_id";
            modelis.ValueMember = "id_md";
            dataGridViewAdminform.Columns.Add(modelis);

            DataGridViewComboBoxColumn krasa = new DataGridViewComboBoxColumn();
            krasa.DataSource = dt_krasa;
            krasa.DisplayMember = "nosaukums";
            krasa.HeaderText = "Auto krāsa";
            krasa.DataPropertyName = "krasa_id";
            krasa.ValueMember = "id_kr";
            ////krasa.AutoComplete = AutoCompleteMode.SuggestAppend;

            dataGridViewAdminform.Columns.Add(krasa);

            

            DataGridViewComboBoxColumn apdrosinasana = new DataGridViewComboBoxColumn();
            apdrosinasana.DataSource = dt_apdrosinasana;
            apdrosinasana.DisplayMember = "firmas_nosaukums";
            apdrosinasana.HeaderText = "Auto apdrošināšana";
            apdrosinasana.DataPropertyName = "apdrosinasana_id";
            apdrosinasana.ValueMember = "id_apd";
            dataGridViewAdminform.Columns.Add(apdrosinasana);

            dataGridViewAdminform.Columns["id_at"].Visible = false;//
            dataGridViewAdminform.Columns["modelis_id"].Visible = false;//
            dataGridViewAdminform.Columns["nobraukums"].HeaderText = "Nobraukums";
            dataGridViewAdminform.Columns["izlaisanas_datums"].HeaderText = "Reģistrācijas datums";
            dataGridViewAdminform.Columns["krasa_id"].Visible = false;//
            dataGridViewAdminform.Columns["apdrosinasana_id"].Visible = false;//
            dataGridViewAdminform.Columns["ipasnieks_id"].Visible = false;
            dataGridViewAdminform.Columns["cena"].HeaderText = "Cena";
            dataGridViewAdminform.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;                     

        }
        
        private void personaToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            dt_persona = new DataTable();
            dt_pilseta = new DataTable();
            dt_klubs = new DataTable();
            ad_klubs.Fill(dt_klubs);

            ad_pilseta.Fill(dt_pilseta);
            ad_persona.Fill(dt_persona);
            dataGridViewAdminform.DataSource = dt_persona;

            DataGridViewComboBoxColumn dzivesvieta = new DataGridViewComboBoxColumn();
            dzivesvieta.DataSource = dt_pilseta;
            dzivesvieta.DisplayMember = "nosaukums";
            dzivesvieta.HeaderText = "Dzīvesvieta";
            dzivesvieta.DataPropertyName = "dzivesvieta_id";
            dzivesvieta.ValueMember = "id_pl";
            dataGridViewAdminform.Columns.Add(dzivesvieta);

            DataGridViewComboBoxColumn klubs = new DataGridViewComboBoxColumn();
            klubs.DataSource = dt_klubs;
            klubs.DisplayMember = "nosaukums";
            klubs.HeaderText = "Klubs";
            klubs.DataPropertyName = "klubs_id";
            klubs.ValueMember = "id_kl";
            dataGridViewAdminform.Columns.Add(klubs);

            dataGridViewAdminform.Columns[0].Visible = false;//
            dataGridViewAdminform.Columns[1].HeaderText = "Vārds";
            dataGridViewAdminform.Columns[2].HeaderText = "Uzvārds";
            dataGridViewAdminform.Columns[3].Visible = false;//
            dataGridViewAdminform.Columns[4].HeaderText = "telefona numurs";
            dataGridViewAdminform.Columns[5].Visible = false;//
            dataGridViewAdminform.Columns[6].HeaderText = "Kluba vadītāja ID";
            dataGridViewAdminform.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
        }
        private void apdrosinasanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt_apdrosinasana = new DataTable();
            ad_apdrosinasana.Fill(dt_apdrosinasana);
       
            dataGridViewAdminform.DataSource = dt_apdrosinasana;
      
            dataGridViewAdminform.Columns["id_apd"].Visible = false;//
            dataGridViewAdminform.Columns["firmas_nosaukums"].HeaderText = "Firmas nosaukums";
            dataGridViewAdminform.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void autoGodalgasToolStripMenuItem_Click(object sender, EventArgs e)
        {


            dt_auto_godalgas = new DataTable();
            dt_godalga = new DataTable();
            ad_godalga.Fill(dt_godalga);
            ad_auto_godalgas.Fill(dt_auto_godalgas);
            dataGridViewAdminform.DataSource = dt_auto_godalgas;

            DataGridViewComboBoxColumn godalga = new DataGridViewComboBoxColumn();
            godalga.DataSource = dt_godalga;
            godalga.DisplayMember = "nosaukums";
            godalga.HeaderText = "Godalga";
            godalga.DataPropertyName = "godalga_id";
            godalga.ValueMember = "id_gl";
            dataGridViewAdminform.Columns.Add(godalga);

            dataGridViewAdminform.Columns["id_agi"].Visible = false;//
            dataGridViewAdminform.Columns["auto_id"].HeaderText="Auto ID";
            dataGridViewAdminform.Columns["godalga_id"].Visible = false;//
            dataGridViewAdminform.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void firmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt_firma = new DataTable();
            ad_firma.Fill(dt_firma);
            dataGridViewAdminform.DataSource = dt_firma;

            dataGridViewAdminform.Columns["id_fr"].Visible = false;//
            dataGridViewAdminform.Columns["nosaukums"].HeaderText = "Firmas nosaukums";
            dataGridViewAdminform.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
        }
        private void godalgaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt_godalga = new DataTable();
            ad_godalga.Fill(dt_godalga);
            dataGridViewAdminform.DataSource = dt_godalga;

            dataGridViewAdminform.Columns["id_gl"].Visible = false;//
            dataGridViewAdminform.Columns["nosaukums"].HeaderText = "Godalgas nosaukums";
            dataGridViewAdminform.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void klubsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt_klubs = new DataTable();
            dt_pilseta = new DataTable();
            ad_pilseta.Fill(dt_pilseta);
            ad_klubs.Fill(dt_klubs);
            dataGridViewAdminform.DataSource = dt_klubs;

            DataGridViewComboBoxColumn pilseta = new DataGridViewComboBoxColumn();
            pilseta.DataSource = dt_pilseta;
            pilseta.DisplayMember = "nosaukums";
            pilseta.HeaderText = "Pilsēta";
            pilseta.DataPropertyName = "pilseta_id";
            pilseta.ValueMember = "id_pl";
            dataGridViewAdminform.Columns.Add(pilseta);

            dataGridViewAdminform.Columns["id_kl"].Visible = false;//
            dataGridViewAdminform.Columns["nosaukums"].HeaderText = "Kluba nosaukums";
            dataGridViewAdminform.Columns["adrese"].HeaderText = "Kluba adrese";
            dataGridViewAdminform.Columns["pilseta_id"].Visible = false;//
            dataGridViewAdminform.Columns["dibinasanas_datums"].HeaderText = "Dibināšanas datums";
            dataGridViewAdminform.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void modelisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt_modelis = new DataTable();
            dt_firma = new DataTable();
            ad_firma.Fill(dt_firma);
            ad_modelis.Fill(dt_modelis);
            dataGridViewAdminform.DataSource = dt_modelis;

            DataGridViewComboBoxColumn firma = new DataGridViewComboBoxColumn();
            firma.DataSource = dt_firma;
            firma.DisplayMember = "nosaukums";
            firma.HeaderText = "Firma";
            firma.DataPropertyName = "id_firma";
            firma.ValueMember = "id_fr";
            dataGridViewAdminform.Columns.Add(firma);

            dataGridViewAdminform.Columns["id_md"].Visible = false;//
            dataGridViewAdminform.Columns["id_firma"].Visible = false;//
            dataGridViewAdminform.Columns["modelis"].HeaderText = "Modelis";
            dataGridViewAdminform.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void pilsetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt_pilseta = new DataTable();
            ad_pilseta.Fill(dt_pilseta);
            dataGridViewAdminform.DataSource = dt_pilseta;

            dataGridViewAdminform.Columns["id_pl"].Visible = false;//
            dataGridViewAdminform.Columns["nosaukums"].HeaderText = "Pilsētas nosaukums";
            dataGridViewAdminform.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void tehniskaApskateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt_tehniska_apskate = new DataTable();
            dt_pilseta = new DataTable();
            ad_pilseta.Fill(dt_pilseta);
            ad_tehniska_apskate.Fill(dt_tehniska_apskate);
            dataGridViewAdminform.DataSource = dt_tehniska_apskate;

            DataGridViewComboBoxColumn pilseta = new DataGridViewComboBoxColumn();
            pilseta.DataSource = dt_pilseta;
            pilseta.DisplayMember = "nosaukums";
            pilseta.HeaderText = "Pilsēta";
            pilseta.DataPropertyName = "apskates_vieta";
            pilseta.ValueMember = "id_pl";
            dataGridViewAdminform.Columns.Add(pilseta);

            dataGridViewAdminform.Columns["id_tap"].Visible = false;//
            dataGridViewAdminform.Columns["apskates_datums"].HeaderText = "Apskates_datums";
            dataGridViewAdminform.Columns["apskates_vieta"].Visible = false;
            dataGridViewAdminform.Columns["piezime"].HeaderText = "Piezīme";
            dataGridViewAdminform.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void krasaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt_krasa = new DataTable();
            ad_krasa.Fill(dt_krasa);
            dataGridViewAdminform.DataSource = dt_krasa;

            dataGridViewAdminform.Columns["id_kr"].Visible = false;//
            dataGridViewAdminform.Columns["nosaukums"].HeaderText = "Nosaukums";
            dataGridViewAdminform.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        
        //Update data un close
        private void backToLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            this.Close();
            loadingForm1 = new StartScreen();
            loadingForm1.ShowDialog();
        }
        private void cLOSEProgrammToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewAdminform.DataSource == dt_apdrosinasana)
                {
                    ad_apdrosinasana.Update(dt_apdrosinasana);
                }

                else if (dataGridViewAdminform.DataSource == dt_auto)
                {
                    ad_auto.Update(dt_auto);
                }
                else if (dataGridViewAdminform.DataSource == dt_firma)
                {
                    ad_firma.Update(dt_firma);
                }

                else if (dataGridViewAdminform.DataSource == dt_godalga)
                {
                    ad_godalga.Update(dt_godalga);
                }
                else if (dataGridViewAdminform.DataSource == dt_klubs)
                {
                    ad_klubs.Update(dt_klubs);
                }
                else if (dataGridViewAdminform.DataSource == dt_krasa)
                {
                    ad_krasa.Update(dt_krasa);
                }
                else if (dataGridViewAdminform.DataSource == dt_modelis)
                {
                    ad_modelis.Update(dt_modelis);
                }
                else if (dataGridViewAdminform.DataSource == dt_persona)
                {
                    ad_persona.Update(dt_persona);
                }
                else if (dataGridViewAdminform.DataSource == dt_pilseta)
                {
                    ad_pilseta.Update(dt_pilseta);
                }
                else if (dataGridViewAdminform.DataSource == dt_tehniska_apskate)
                {
                    ad_tehniska_apskate.Update(dt_tehniska_apskate);
                }
                else if (dataGridViewAdminform.DataSource == dt_auto_godalgas)
                {
                    ad_auto_godalgas.Update(dt_auto_godalgas);
                }
            }
            catch (System.ArgumentNullException)
            {

                
            } 
            
            
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}


