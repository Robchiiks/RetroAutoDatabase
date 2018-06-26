--
-- PostgreSQL database dump
--

-- Dumped from database version 10.3
-- Dumped by pg_dump version 10.3

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


--
-- Name: naudas_kopsumma(integer); Type: FUNCTION; Schema: public; Owner: roberts
--

CREATE FUNCTION public.naudas_kopsumma(integer) RETURNS SETOF record
    LANGUAGE sql
    AS $_$
select at.ipasnieks_id, sum(at.cena) AS "auto_cenu_kopsumma"
from auto AS at
where at.ipasnieks_id = $1
Group by 1
$_$;


ALTER FUNCTION public.naudas_kopsumma(integer) OWNER TO roberts;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: apdrosinasana; Type: TABLE; Schema: public; Owner: roberts
--

CREATE TABLE public.apdrosinasana (
    id_apd integer NOT NULL,
    firmas_nosaukums character varying(40)
);


ALTER TABLE public.apdrosinasana OWNER TO roberts;

--
-- Name: apdrosinasana_id_apd_seq; Type: SEQUENCE; Schema: public; Owner: roberts
--

CREATE SEQUENCE public.apdrosinasana_id_apd_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.apdrosinasana_id_apd_seq OWNER TO roberts;

--
-- Name: apdrosinasana_id_apd_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: roberts
--

ALTER SEQUENCE public.apdrosinasana_id_apd_seq OWNED BY public.apdrosinasana.id_apd;


--
-- Name: auto; Type: TABLE; Schema: public; Owner: roberts
--

CREATE TABLE public.auto (
    id_at integer NOT NULL,
    modelis_id integer NOT NULL,
    nobraukums integer,
    izlaisanas_datums date,
    krasa_id integer NOT NULL,
    tehniska_apskate integer NOT NULL,
    apdrosinasana_id integer NOT NULL,
    ipasnieks_id integer NOT NULL,
    cena integer
);


ALTER TABLE public.auto OWNER TO roberts;

--
-- Name: apdrosinasanu_uzskaite; Type: VIEW; Schema: public; Owner: roberts
--

CREATE VIEW public.apdrosinasanu_uzskaite AS
 SELECT apd.firmas_nosaukums AS "Apdrosinasana",
    count(at.id_at) AS "Apdrosinato_auto skaits"
   FROM (public.apdrosinasana apd
     JOIN public.auto at ON ((at.apdrosinasana_id = apd.id_apd)))
  GROUP BY apd.firmas_nosaukums
  ORDER BY apd.firmas_nosaukums;


ALTER TABLE public.apdrosinasanu_uzskaite OWNER TO roberts;

--
-- Name: auto_godalgas_index; Type: TABLE; Schema: public; Owner: roberts
--

CREATE TABLE public.auto_godalgas_index (
    id_agi integer NOT NULL,
    auto_id integer NOT NULL,
    godalga_id integer NOT NULL
);


ALTER TABLE public.auto_godalgas_index OWNER TO roberts;

--
-- Name: auto_godalgas_index_id_agi_seq; Type: SEQUENCE; Schema: public; Owner: roberts
--

CREATE SEQUENCE public.auto_godalgas_index_id_agi_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.auto_godalgas_index_id_agi_seq OWNER TO roberts;

--
-- Name: auto_godalgas_index_id_agi_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: roberts
--

ALTER SEQUENCE public.auto_godalgas_index_id_agi_seq OWNED BY public.auto_godalgas_index.id_agi;


--
-- Name: auto_id_at_seq; Type: SEQUENCE; Schema: public; Owner: roberts
--

CREATE SEQUENCE public.auto_id_at_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.auto_id_at_seq OWNER TO roberts;

--
-- Name: auto_id_at_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: roberts
--

ALTER SEQUENCE public.auto_id_at_seq OWNED BY public.auto.id_at;


--
-- Name: firma; Type: TABLE; Schema: public; Owner: roberts
--

CREATE TABLE public.firma (
    id_fr integer NOT NULL,
    nosaukums character varying(40)
);


ALTER TABLE public.firma OWNER TO roberts;

--
-- Name: krasa; Type: TABLE; Schema: public; Owner: roberts
--

CREATE TABLE public.krasa (
    id_kr integer NOT NULL,
    nosaukums character varying(20)
);


ALTER TABLE public.krasa OWNER TO roberts;

--
-- Name: modelis; Type: TABLE; Schema: public; Owner: roberts
--

CREATE TABLE public.modelis (
    id_md integer NOT NULL,
    id_firma integer NOT NULL,
    modelis character varying(20)
);


ALTER TABLE public.modelis OWNER TO roberts;

--
-- Name: persona; Type: TABLE; Schema: public; Owner: roberts
--

CREATE TABLE public.persona (
    id_prs integer NOT NULL,
    vards character varying(15),
    uzvards character varying(30),
    dzivesvieta_id integer NOT NULL,
    tel_numurs numeric(8,0),
    klubs_id integer NOT NULL,
    kluba_vaditajs integer NOT NULL
);


ALTER TABLE public.persona OWNER TO roberts;

--
-- Name: tehniska_apskate; Type: TABLE; Schema: public; Owner: roberts
--

CREATE TABLE public.tehniska_apskate (
    id_tap integer NOT NULL,
    apskates_datums date,
    apskates_vieta integer NOT NULL,
    piezime character varying(50),
    CONSTRAINT tehniska_apskate_apskates_datums_check CHECK ((apskates_datums < ('now'::text)::date))
);


ALTER TABLE public.tehniska_apskate OWNER TO roberts;

--
-- Name: auto_uzskaite; Type: VIEW; Schema: public; Owner: roberts
--

CREATE VIEW public.auto_uzskaite AS
 SELECT fr.nosaukums AS "Firma",
    md.modelis AS "Modelis",
    at.nobraukums AS "Auto nobraukums km",
    kr.nosaukums AS "Krasa",
    tap.id_tap AS "Tehniskas apskates id",
    apd.firmas_nosaukums AS "Apdrosinasana",
    prs.vards AS "Ipasnieka vards",
    prs.uzvards AS "Ipasnieka uzvards",
    at.cena AS "Auto cena"
   FROM ((((((public.auto at
     JOIN public.krasa kr ON ((at.krasa_id = kr.id_kr)))
     JOIN public.tehniska_apskate tap ON ((at.tehniska_apskate = tap.id_tap)))
     JOIN public.apdrosinasana apd ON ((at.apdrosinasana_id = apd.id_apd)))
     JOIN public.persona prs ON ((at.ipasnieks_id = prs.id_prs)))
     JOIN public.modelis md ON ((at.modelis_id = md.id_md)))
     JOIN public.firma fr ON ((md.id_firma = fr.id_fr)))
  GROUP BY fr.nosaukums, md.modelis, at.nobraukums, kr.nosaukums, tap.id_tap, apd.firmas_nosaukums, prs.vards, prs.uzvards, at.cena
  ORDER BY fr.nosaukums;


ALTER TABLE public.auto_uzskaite OWNER TO roberts;

--
-- Name: firma_id_fr_seq; Type: SEQUENCE; Schema: public; Owner: roberts
--

CREATE SEQUENCE public.firma_id_fr_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.firma_id_fr_seq OWNER TO roberts;

--
-- Name: firma_id_fr_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: roberts
--

ALTER SEQUENCE public.firma_id_fr_seq OWNED BY public.firma.id_fr;


--
-- Name: reg_auto_sk; Type: VIEW; Schema: public; Owner: roberts
--

CREATE VIEW public.reg_auto_sk AS
 SELECT fr.nosaukums,
    md.modelis,
    count(at.id_at) AS count
   FROM ((public.firma fr
     JOIN public.modelis md ON ((md.id_firma = fr.id_fr)))
     JOIN public.auto at ON ((at.modelis_id = md.id_md)))
  GROUP BY fr.nosaukums, md.modelis
  ORDER BY fr.nosaukums;


ALTER TABLE public.reg_auto_sk OWNER TO roberts;

--
-- Name: firmu_uzskaite; Type: VIEW; Schema: public; Owner: roberts
--

CREATE VIEW public.firmu_uzskaite AS
 SELECT rgs.nosaukums AS firma,
    count(md.id_md) AS "Registreto modelu skaits",
    rgs.count AS "Registreto auto skaits"
   FROM (public.reg_auto_sk rgs
     JOIN public.modelis md ON (((md.modelis)::text = (rgs.modelis)::text)))
  GROUP BY rgs.nosaukums, rgs.count
  ORDER BY rgs.nosaukums;


ALTER TABLE public.firmu_uzskaite OWNER TO roberts;

--
-- Name: godalga; Type: TABLE; Schema: public; Owner: roberts
--

CREATE TABLE public.godalga (
    id_gl integer NOT NULL,
    nosaukums character varying(30)
);


ALTER TABLE public.godalga OWNER TO roberts;

--
-- Name: godalga_id_gl_seq; Type: SEQUENCE; Schema: public; Owner: roberts
--

CREATE SEQUENCE public.godalga_id_gl_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.godalga_id_gl_seq OWNER TO roberts;

--
-- Name: godalga_id_gl_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: roberts
--

ALTER SEQUENCE public.godalga_id_gl_seq OWNED BY public.godalga.id_gl;


--
-- Name: godalgu_uzskaite; Type: VIEW; Schema: public; Owner: roberts
--

CREATE VIEW public.godalgu_uzskaite AS
 SELECT gl.nosaukums AS "Godalgas nosaukums",
    count(agi.auto_id) AS "Apbalvoto auto skaits"
   FROM (public.godalga gl
     JOIN public.auto_godalgas_index agi ON ((gl.id_gl = agi.godalga_id)))
  GROUP BY gl.nosaukums
  ORDER BY gl.nosaukums;


ALTER TABLE public.godalgu_uzskaite OWNER TO roberts;

--
-- Name: klubs; Type: TABLE; Schema: public; Owner: roberts
--

CREATE TABLE public.klubs (
    id_kl integer NOT NULL,
    nosaukums character varying(40),
    adrese character varying(40),
    pilseta_id integer NOT NULL,
    dibinasanas_datums date,
    CONSTRAINT klubs_dibinasanas_datums_check CHECK ((dibinasanas_datums < ('now'::text)::date))
);


ALTER TABLE public.klubs OWNER TO roberts;

--
-- Name: pilseta; Type: TABLE; Schema: public; Owner: roberts
--

CREATE TABLE public.pilseta (
    id_pl integer NOT NULL,
    nosaukums character varying(20)
);


ALTER TABLE public.pilseta OWNER TO roberts;

--
-- Name: kl_sk_pl; Type: VIEW; Schema: public; Owner: roberts
--

CREATE VIEW public.kl_sk_pl AS
 SELECT pl.nosaukums,
    count(kl.id_kl) AS count
   FROM (public.pilseta pl
     JOIN public.klubs kl ON ((pl.id_pl = kl.pilseta_id)))
  GROUP BY pl.nosaukums;


ALTER TABLE public.kl_sk_pl OWNER TO roberts;

--
-- Name: klubs_id_kl_seq; Type: SEQUENCE; Schema: public; Owner: roberts
--

CREATE SEQUENCE public.klubs_id_kl_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.klubs_id_kl_seq OWNER TO roberts;

--
-- Name: klubs_id_kl_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: roberts
--

ALTER SEQUENCE public.klubs_id_kl_seq OWNED BY public.klubs.id_kl;


--
-- Name: klubu_uzskaite; Type: VIEW; Schema: public; Owner: roberts
--

CREATE VIEW public.klubu_uzskaite AS
 SELECT kl.nosaukums AS "Kluba nosaukums",
    kl.adrese AS "Registreta adrese",
    pl.nosaukums AS "Registreta pilseta",
    prs.vards AS "Vaditaja Vards",
    prs.uzvards AS "Vaditaja Uzvards",
    ( SELECT count(prs_1.id_prs) AS count
           FROM (public.persona prs_1
             JOIN public.klubs kl_1 ON ((prs_1.klubs_id = kl_1.id_kl)))) AS "Biedru skaits"
   FROM ((public.klubs kl
     JOIN public.pilseta pl ON ((kl.pilseta_id = pl.id_pl)))
     JOIN public.persona prs ON ((prs.klubs_id = kl.id_kl)))
  GROUP BY kl.nosaukums, kl.adrese, pl.nosaukums, prs.vards, prs.uzvards, kl.dibinasanas_datums
  ORDER BY kl.dibinasanas_datums;


ALTER TABLE public.klubu_uzskaite OWNER TO roberts;

--
-- Name: krasa_id_kr_seq; Type: SEQUENCE; Schema: public; Owner: roberts
--

CREATE SEQUENCE public.krasa_id_kr_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.krasa_id_kr_seq OWNER TO roberts;

--
-- Name: krasa_id_kr_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: roberts
--

ALTER SEQUENCE public.krasa_id_kr_seq OWNED BY public.krasa.id_kr;


--
-- Name: krasu_uzskaite; Type: VIEW; Schema: public; Owner: roberts
--

CREATE VIEW public.krasu_uzskaite AS
 SELECT kr.nosaukums AS "Krasa",
    count(at.id_at) AS "Registreto auto skaits"
   FROM (public.krasa kr
     JOIN public.auto at ON ((at.krasa_id = kr.id_kr)))
  GROUP BY kr.nosaukums
  ORDER BY kr.nosaukums;


ALTER TABLE public.krasu_uzskaite OWNER TO roberts;

--
-- Name: modelis_id_md_seq; Type: SEQUENCE; Schema: public; Owner: roberts
--

CREATE SEQUENCE public.modelis_id_md_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.modelis_id_md_seq OWNER TO roberts;

--
-- Name: modelis_id_md_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: roberts
--

ALTER SEQUENCE public.modelis_id_md_seq OWNED BY public.modelis.id_md;


--
-- Name: modelu_uzskaite; Type: VIEW; Schema: public; Owner: roberts
--

CREATE VIEW public.modelu_uzskaite AS
 SELECT fr.nosaukums AS "Firma",
    md.modelis AS "Modelis",
    count(at.id_at) AS "Registreto auto skaits"
   FROM ((public.modelis md
     JOIN public.firma fr ON ((md.id_firma = fr.id_fr)))
     JOIN public.auto at ON ((at.modelis_id = md.id_md)))
  GROUP BY md.modelis, fr.nosaukums
  ORDER BY fr.nosaukums;


ALTER TABLE public.modelu_uzskaite OWNER TO roberts;

--
-- Name: persona_id_prs_seq; Type: SEQUENCE; Schema: public; Owner: roberts
--

CREATE SEQUENCE public.persona_id_prs_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.persona_id_prs_seq OWNER TO roberts;

--
-- Name: persona_id_prs_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: roberts
--

ALTER SEQUENCE public.persona_id_prs_seq OWNED BY public.persona.id_prs;


--
-- Name: personu_uzskaite; Type: VIEW; Schema: public; Owner: roberts
--

CREATE VIEW public.personu_uzskaite AS
 SELECT prs.vards AS "Vards",
    prs.uzvards AS "Uzvards",
    pl.nosaukums AS "Dzivesvieta",
    prs.tel_numurs AS "Telefona numurs",
    kl.nosaukums AS "Kluba biedrs",
    count(at.id_at) AS "Auto uzskaite"
   FROM (((public.persona prs
     JOIN public.pilseta pl ON ((prs.dzivesvieta_id = pl.id_pl)))
     JOIN public.klubs kl ON ((prs.klubs_id = kl.id_kl)))
     JOIN public.auto at ON ((at.ipasnieks_id = prs.id_prs)))
  GROUP BY prs.vards, prs.uzvards, pl.nosaukums, prs.tel_numurs, kl.nosaukums
  ORDER BY prs.uzvards;


ALTER TABLE public.personu_uzskaite OWNER TO roberts;

--
-- Name: pilseta_id_pl_seq; Type: SEQUENCE; Schema: public; Owner: roberts
--

CREATE SEQUENCE public.pilseta_id_pl_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.pilseta_id_pl_seq OWNER TO roberts;

--
-- Name: pilseta_id_pl_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: roberts
--

ALTER SEQUENCE public.pilseta_id_pl_seq OWNED BY public.pilseta.id_pl;


--
-- Name: prs_sk_pl; Type: VIEW; Schema: public; Owner: roberts
--

CREATE VIEW public.prs_sk_pl AS
 SELECT pl.nosaukums,
    count(prs.id_prs) AS count
   FROM (public.pilseta pl
     JOIN public.persona prs ON ((pl.id_pl = prs.dzivesvieta_id)))
  GROUP BY pl.nosaukums;


ALTER TABLE public.prs_sk_pl OWNER TO roberts;

--
-- Name: pilsetu_uzskaite; Type: VIEW; Schema: public; Owner: roberts
--

CREATE VIEW public.pilsetu_uzskaite AS
 SELECT ksp.nosaukums AS "Pilseta",
    ksp.count AS "Registreto klubu skaits",
    psp.count AS "Registreto personu skaits"
   FROM (public.kl_sk_pl ksp
     JOIN public.prs_sk_pl psp ON (((ksp.nosaukums)::text = (psp.nosaukums)::text)));


ALTER TABLE public.pilsetu_uzskaite OWNER TO roberts;

--
-- Name: tehniska_apskate_id_tap_seq; Type: SEQUENCE; Schema: public; Owner: roberts
--

CREATE SEQUENCE public.tehniska_apskate_id_tap_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.tehniska_apskate_id_tap_seq OWNER TO roberts;

--
-- Name: tehniska_apskate_id_tap_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: roberts
--

ALTER SEQUENCE public.tehniska_apskate_id_tap_seq OWNED BY public.tehniska_apskate.id_tap;


--
-- Name: tehnisko_apskasu_uzskaite; Type: VIEW; Schema: public; Owner: roberts
--

CREATE VIEW public.tehnisko_apskasu_uzskaite AS
 SELECT at.id_at AS "Auto id",
    tap.apskates_datums AS "Apskates datums",
    pl.nosaukums AS "Pilseta",
    tap.piezime AS "Piezime"
   FROM ((public.auto at
     JOIN public.tehniska_apskate tap ON ((at.tehniska_apskate = tap.id_tap)))
     JOIN public.pilseta pl ON ((tap.apskates_vieta = pl.id_pl)))
  ORDER BY tap.apskates_datums;


ALTER TABLE public.tehnisko_apskasu_uzskaite OWNER TO roberts;

--
-- Name: apdrosinasana id_apd; Type: DEFAULT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.apdrosinasana ALTER COLUMN id_apd SET DEFAULT nextval('public.apdrosinasana_id_apd_seq'::regclass);


--
-- Name: auto id_at; Type: DEFAULT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.auto ALTER COLUMN id_at SET DEFAULT nextval('public.auto_id_at_seq'::regclass);


--
-- Name: auto_godalgas_index id_agi; Type: DEFAULT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.auto_godalgas_index ALTER COLUMN id_agi SET DEFAULT nextval('public.auto_godalgas_index_id_agi_seq'::regclass);


--
-- Name: firma id_fr; Type: DEFAULT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.firma ALTER COLUMN id_fr SET DEFAULT nextval('public.firma_id_fr_seq'::regclass);


--
-- Name: godalga id_gl; Type: DEFAULT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.godalga ALTER COLUMN id_gl SET DEFAULT nextval('public.godalga_id_gl_seq'::regclass);


--
-- Name: klubs id_kl; Type: DEFAULT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.klubs ALTER COLUMN id_kl SET DEFAULT nextval('public.klubs_id_kl_seq'::regclass);


--
-- Name: krasa id_kr; Type: DEFAULT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.krasa ALTER COLUMN id_kr SET DEFAULT nextval('public.krasa_id_kr_seq'::regclass);


--
-- Name: modelis id_md; Type: DEFAULT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.modelis ALTER COLUMN id_md SET DEFAULT nextval('public.modelis_id_md_seq'::regclass);


--
-- Name: persona id_prs; Type: DEFAULT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.persona ALTER COLUMN id_prs SET DEFAULT nextval('public.persona_id_prs_seq'::regclass);


--
-- Name: pilseta id_pl; Type: DEFAULT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.pilseta ALTER COLUMN id_pl SET DEFAULT nextval('public.pilseta_id_pl_seq'::regclass);


--
-- Name: tehniska_apskate id_tap; Type: DEFAULT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.tehniska_apskate ALTER COLUMN id_tap SET DEFAULT nextval('public.tehniska_apskate_id_tap_seq'::regclass);


--
-- Data for Name: apdrosinasana; Type: TABLE DATA; Schema: public; Owner: roberts
--

COPY public.apdrosinasana (id_apd, firmas_nosaukums) FROM stdin;
1	BALTA
4	COMPENSA
3	BTA
6	Gjensidige
5	ERGO
8	Seesam
7	if
9	Swedbank
2	Baltijas Apdrosinasanas nams
\.


--
-- Data for Name: auto; Type: TABLE DATA; Schema: public; Owner: roberts
--

COPY public.auto (id_at, modelis_id, nobraukums, izlaisanas_datums, krasa_id, tehniska_apskate, apdrosinasana_id, ipasnieks_id, cena) FROM stdin;
14	12	874523	1990-02-02	12	14	2	14	852667
25	1	23432	2001-04-02	5	11	6	25	52654
21	5	8542658	1989-03-03	13	21	8	21	84263
22	4	41254	1990-03-03	8	22	8	22	85412365
23	3	842654	1991-03-03	9	23	9	23	84265
24	2	2652	1992-03-03	10	24	3	24	8542654
2	24	2005005	1986-01-01	6	2	6	2	300000
1	25	1001001	1985-01-01	5	1	5	1	2000000
4	22	3333333	1988-01-01	8	4	8	4	777777
3	23	1100110	1987-01-01	7	3	7	3	999999
6	20	999999	1990-01-01	10	6	2	6	99999
5	21	777777	1989-01-01	9	5	9	5	66666
8	18	444444	1992-01-01	6	8	6	8	44000
7	19	222222	1991-01-01	11	7	3	7	222222
10	16	74523652	1986-02-02	8	10	8	10	74523
9	17	666666	1985-02-02	7	9	7	9	888888
12	14	74125	1988-02-02	10	12	4	12	74523
11	15	74523698	1987-02-02	9	11	9	11	752965
13	13	75295195	1989-02-02	11	13	5	13	96521
16	10	125475	1992-02-02	8	16	8	16	985275
15	11	74265841	1991-02-02	7	15	7	15	65288
18	8	42658412	1986-03-03	10	18	1	18	98412
17	9	123541265	1985-03-03	9	17	9	17	265842
20	6	742654	1988-03-03	12	20	7	20	9874263
19	7	985426	1987-03-03	11	19	5	19	98542
\.


--
-- Data for Name: auto_godalgas_index; Type: TABLE DATA; Schema: public; Owner: roberts
--

COPY public.auto_godalgas_index (id_agi, auto_id, godalga_id) FROM stdin;
2	2	2
12	12	12
11	11	11
14	14	14
13	13	13
1	1	1
4	4	4
3	3	3
6	6	6
5	5	5
8	8	8
7	7	7
10	10	10
9	9	9
\.


--
-- Data for Name: firma; Type: TABLE DATA; Schema: public; Owner: roberts
--

COPY public.firma (id_fr, nosaukums) FROM stdin;
2	BMW
1	Audi
4	Renault
3	Mercedes-Benz
6	Aston Martin
5	Alfa Romeo
8	Buick
7	Bentley
10	Fiat
9	Dacia
25	Hyundai
26	Jaguar
27	Land Rover
28	Lamborghini
21	Saab
22	Ford
23	Ginetta
24	Genesis
29	Lincoln
30	Lancia
12	Lada
11	Honda
14	Nissan
13	Lotus
16	Opel
15	test
18	Rolls-Royce
17	Toyota
20	Rover
19	Subaru
32	Citroen
31	MG
33	Volkswagen\n
\.


--
-- Data for Name: godalga; Type: TABLE DATA; Schema: public; Owner: roberts
--

COPY public.godalga (id_gl, nosaukums) FROM stdin;
12	Best stereo 2016
11	Fastest in class B
14	Best in Baltics
13	Best all-around
2	Beauty 2015
1	Fastest in class C
4	Spectator's sympathy
3	Best stereo
6	Best in class A
5	Beauty 2014
8	Best sleeper
7	Oldest one
10	Rust bucket
9	Biggest mileage
\.


--
-- Data for Name: klubs; Type: TABLE DATA; Schema: public; Owner: roberts
--

COPY public.klubs (id_kl, nosaukums, adrese, pilseta_id, dibinasanas_datums) FROM stdin;
12	LV Streets Huligans	Krasta iela 5	9	2012-07-07
13	retroauto.lv	Jelgavas iela 1	10	2013-07-07
1	rwd.lv	Druvienas iela 1	4	2001-01-01
6	jaguarclub	Elizabetes iela 33	9	2006-03-03
8	motormuzejs	Kr. Barona iela 3	5	2008-04-04
7	japcar	Slokas iela 22	10	2007-04-04
10	uscars	Aizkraukles iela 6	7	2010-06-06
11	ffr	Rigas iela 22	8	2011-06-06
2	skystreets	Terbatas iela 2	5	2002-01-01
4	forsaza	Brivibas bulvaris 303	7	2004-02-02
3	durka racing	Liela iela 22	6	2003-02-02
5	gaz21	Kaleju iela 15	8	2005-03-03
9	tunings	Vienibas gatve 420	6	2009-05-05
\.


--
-- Data for Name: krasa; Type: TABLE DATA; Schema: public; Owner: roberts
--

COPY public.krasa (id_kr, nosaukums) FROM stdin;
13	Dzintars
15	Kaula
2	Zils
1	Sarkans
4	Sudraba
6	Melns
8	Dzeltens
7	Balts
9	Violets
12	Bruns
11	Roza
14	Laima zals
3	Peleks
5	Zals
10	Lilla
\.


--
-- Data for Name: modelis; Type: TABLE DATA; Schema: public; Owner: roberts
--

COPY public.modelis (id_md, id_firma, modelis) FROM stdin;
14	14	Skyline r31
16	16	Vectra
15	15	test
18	18	Silver Shadow
17	17	AE86
20	20	100
19	19	Impreza 22B
21	21	900
22	22	Mustang
23	23	G4
25	25	Tiburon
26	26	XJ220
27	27	Discovery
24	24	Turbo
28	28	Diablo SV
33	33	Golf I GTi
32	32	C4
31	31	B-GT
29	29	Continental
30	30	Stratos
12	12	Niva
11	11	NSX
13	13	Esprit
2	2	2002 Turbo
1	1	Quattro S1
4	4	Clio
3	3	300SL
6	6	DB5
5	5	Spider
8	8	Regal GNX
7	7	Mulsanne
10	10	500
9	9	Sandero
\.


--
-- Data for Name: persona; Type: TABLE DATA; Schema: public; Owner: roberts
--

COPY public.persona (id_prs, vards, uzvards, dzivesvieta_id, tel_numurs, klubs_id, kluba_vaditajs) FROM stdin;
25	Roberts	Binovskis	5	26848945	3	4
26	Reinis	Buls	11	23684566	1	3
27	Amanda	Betlere	14	24648658	2	1
28	Arturs	Astramovics	2	26486456	4	2
21	Ralfs	Gulans	6	25564856	5	4
22	Kendriks	Lamars	5	24846886	7	5
23	Martins	Koluzs	12	26486656	9	4
24	Gatis	Lama	14	24615687	5	7
29	Matiss	Juhna	1	23584655	5	4
10	Davis	Bodnieks	10	24564568	4	4
12	Augusts	Veidenbaums	12	21564568	6	4
11	Ieva	Reinfelde	11	21564523	5	4
14	Signe	Ozols	14	21686486	8	4
13	Kitija	Paeglite	13	24152648	7	4
16	Roberts	Remesis	16	21538346	10	4
15	Kristofers	Sveide	15	21534864	9	4
30	Martins	Vanags	1	29874563	7	2
2	Reinis	Nitiss	2	25876984	11	4
1	Dzimijs	Batlers	1	24865486	11	4
4	Rasels	Vestbruks	4	26874593	11	4
3	Andre	Ingrams	3	25874569	11	4
6	Karlo	Avakovs	6	25685486	11	4
5	Beate	Bluma	5	21458769	11	4
8	It G	Ma	8	27486483	2	4
7	Inga 	Krumina	7	26987563	1	4
9	Ricards	Codars	9	24564568	3	4
18	Verners	Luste	18	25462186	12	4
17	Ernests	Salinieks	17	21384865	11	4
20	Eriks	Kamols	4	29845621	2	4
19	Raimonds	Vejonis	2	24862165	13	4
\.


--
-- Data for Name: pilseta; Type: TABLE DATA; Schema: public; Owner: roberts
--

COPY public.pilseta (id_pl, nosaukums) FROM stdin;
14	Mazpisani
13	Aluksne
16	Dirsi
15	Jurmala
1	Riga
4	Jekabpils
5	Liepaja
7	Rezekne
9	Cesis
12	Smiltene
11	Sigulda
18	Dobele
17	Saldus
2	Jelgava
3	Valmiera
6	Ventspils
8	Daugavpils
10	Ogre
\.


--
-- Data for Name: tehniska_apskate; Type: TABLE DATA; Schema: public; Owner: roberts
--

COPY public.tehniska_apskate (id_tap, apskates_datums, apskates_vieta, piezime) FROM stdin;
21	2010-02-02	6	Apskate izieta 
22	2010-02-02	2	Apskate neizieta  
23	2010-02-02	2	Apskate izieta 
24	2010-02-02	3	Apskate izieta 
6	2010-02-02	6	Apskate izieta 
8	2010-02-02	8	Apskate izieta 
7	2010-02-02	7	Apskate izieta 
10	2010-02-02	10	Apskate izieta 
9	2010-02-02	9	Apskate izieta 
12	2010-02-02	12	Apskate izieta 
11	2010-02-02	11	Apskate neizieta  
13	2010-02-02	13	Apskate izieta 
16	2010-02-02	16	Apskate neizieta 
15	2010-02-02	15	Apskate izieta 
18	2010-02-02	18	Apskate izieta 
17	2010-02-02	17	Apskate neizieta  
20	2010-02-02	5	Apskate izieta 
19	2010-02-02	3	Apskate izieta 
2	2018-03-25	2	Apskate neizieta  
1	2018-02-03	1	Apskate neizieta  
4	2017-08-17	4	Apskate izieta 
3	2018-01-30	3	Apskate izieta 
5	2018-04-20	5	Apskate neizieta  
14	2010-02-02	14	Apskate izieta 
\.


--
-- Name: apdrosinasana_id_apd_seq; Type: SEQUENCE SET; Schema: public; Owner: roberts
--

SELECT pg_catalog.setval('public.apdrosinasana_id_apd_seq', 25, true);


--
-- Name: auto_godalgas_index_id_agi_seq; Type: SEQUENCE SET; Schema: public; Owner: roberts
--

SELECT pg_catalog.setval('public.auto_godalgas_index_id_agi_seq', 37, true);


--
-- Name: auto_id_at_seq; Type: SEQUENCE SET; Schema: public; Owner: roberts
--

SELECT pg_catalog.setval('public.auto_id_at_seq', 31, true);


--
-- Name: firma_id_fr_seq; Type: SEQUENCE SET; Schema: public; Owner: roberts
--

SELECT pg_catalog.setval('public.firma_id_fr_seq', 33, true);


--
-- Name: godalga_id_gl_seq; Type: SEQUENCE SET; Schema: public; Owner: roberts
--

SELECT pg_catalog.setval('public.godalga_id_gl_seq', 25, true);


--
-- Name: klubs_id_kl_seq; Type: SEQUENCE SET; Schema: public; Owner: roberts
--

SELECT pg_catalog.setval('public.klubs_id_kl_seq', 32, true);


--
-- Name: krasa_id_kr_seq; Type: SEQUENCE SET; Schema: public; Owner: roberts
--

SELECT pg_catalog.setval('public.krasa_id_kr_seq', 31, true);


--
-- Name: modelis_id_md_seq; Type: SEQUENCE SET; Schema: public; Owner: roberts
--

SELECT pg_catalog.setval('public.modelis_id_md_seq', 51, true);


--
-- Name: persona_id_prs_seq; Type: SEQUENCE SET; Schema: public; Owner: roberts
--

SELECT pg_catalog.setval('public.persona_id_prs_seq', 48, true);


--
-- Name: pilseta_id_pl_seq; Type: SEQUENCE SET; Schema: public; Owner: roberts
--

SELECT pg_catalog.setval('public.pilseta_id_pl_seq', 71, true);


--
-- Name: tehniska_apskate_id_tap_seq; Type: SEQUENCE SET; Schema: public; Owner: roberts
--

SELECT pg_catalog.setval('public.tehniska_apskate_id_tap_seq', 39, true);


--
-- Name: apdrosinasana apdrosinasana_pkey; Type: CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.apdrosinasana
    ADD CONSTRAINT apdrosinasana_pkey PRIMARY KEY (id_apd);


--
-- Name: auto_godalgas_index auto_godalgas_index_pkey; Type: CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.auto_godalgas_index
    ADD CONSTRAINT auto_godalgas_index_pkey PRIMARY KEY (id_agi);


--
-- Name: auto auto_pkey; Type: CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.auto
    ADD CONSTRAINT auto_pkey PRIMARY KEY (id_at);


--
-- Name: firma firma_pkey; Type: CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.firma
    ADD CONSTRAINT firma_pkey PRIMARY KEY (id_fr);


--
-- Name: godalga godalga_pkey; Type: CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.godalga
    ADD CONSTRAINT godalga_pkey PRIMARY KEY (id_gl);


--
-- Name: klubs klubs_pkey; Type: CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.klubs
    ADD CONSTRAINT klubs_pkey PRIMARY KEY (id_kl);


--
-- Name: krasa krasa_pkey; Type: CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.krasa
    ADD CONSTRAINT krasa_pkey PRIMARY KEY (id_kr);


--
-- Name: modelis modelis_pkey; Type: CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.modelis
    ADD CONSTRAINT modelis_pkey PRIMARY KEY (id_md);


--
-- Name: persona persona_pkey; Type: CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.persona
    ADD CONSTRAINT persona_pkey PRIMARY KEY (id_prs);


--
-- Name: pilseta pilseta_pkey; Type: CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.pilseta
    ADD CONSTRAINT pilseta_pkey PRIMARY KEY (id_pl);


--
-- Name: tehniska_apskate tehniska_apskate_pkey; Type: CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.tehniska_apskate
    ADD CONSTRAINT tehniska_apskate_pkey PRIMARY KEY (id_tap);


--
-- Name: auto auto_apdrosinasana_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.auto
    ADD CONSTRAINT auto_apdrosinasana_id_fkey FOREIGN KEY (apdrosinasana_id) REFERENCES public.apdrosinasana(id_apd);


--
-- Name: auto_godalgas_index auto_godalgas_index_auto_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.auto_godalgas_index
    ADD CONSTRAINT auto_godalgas_index_auto_id_fkey FOREIGN KEY (auto_id) REFERENCES public.auto(id_at);


--
-- Name: auto_godalgas_index auto_godalgas_index_godalga_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.auto_godalgas_index
    ADD CONSTRAINT auto_godalgas_index_godalga_id_fkey FOREIGN KEY (godalga_id) REFERENCES public.godalga(id_gl);


--
-- Name: auto auto_ipasnieks_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.auto
    ADD CONSTRAINT auto_ipasnieks_id_fkey FOREIGN KEY (ipasnieks_id) REFERENCES public.persona(id_prs);


--
-- Name: auto auto_krasa_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.auto
    ADD CONSTRAINT auto_krasa_id_fkey FOREIGN KEY (krasa_id) REFERENCES public.krasa(id_kr);


--
-- Name: auto auto_modelis_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.auto
    ADD CONSTRAINT auto_modelis_id_fkey FOREIGN KEY (modelis_id) REFERENCES public.modelis(id_md);


--
-- Name: klubs klubs_pilseta_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.klubs
    ADD CONSTRAINT klubs_pilseta_id_fkey FOREIGN KEY (pilseta_id) REFERENCES public.pilseta(id_pl);


--
-- Name: modelis modelis_id_firma_fkey; Type: FK CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.modelis
    ADD CONSTRAINT modelis_id_firma_fkey FOREIGN KEY (id_firma) REFERENCES public.firma(id_fr);


--
-- Name: persona persona_dzivesvieta_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.persona
    ADD CONSTRAINT persona_dzivesvieta_id_fkey FOREIGN KEY (dzivesvieta_id) REFERENCES public.pilseta(id_pl);


--
-- Name: persona persona_kluba_vaditajs_fkey; Type: FK CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.persona
    ADD CONSTRAINT persona_kluba_vaditajs_fkey FOREIGN KEY (kluba_vaditajs) REFERENCES public.persona(id_prs);


--
-- Name: persona persona_klubs_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.persona
    ADD CONSTRAINT persona_klubs_id_fkey FOREIGN KEY (klubs_id) REFERENCES public.klubs(id_kl);


--
-- Name: tehniska_apskate tehniska_apskate_apskates_vieta_fkey; Type: FK CONSTRAINT; Schema: public; Owner: roberts
--

ALTER TABLE ONLY public.tehniska_apskate
    ADD CONSTRAINT tehniska_apskate_apskates_vieta_fkey FOREIGN KEY (apskates_vieta) REFERENCES public.pilseta(id_pl);


--
-- PostgreSQL database dump complete
--

