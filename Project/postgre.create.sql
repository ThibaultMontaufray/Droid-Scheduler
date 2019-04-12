-- Database: "droid.scheduler"

-- DROP DATABASE "droid.scheduler";

CREATE DATABASE "droid.scheduler"
  WITH OWNER = postgres
       ENCODING = 'UTF8'
       TABLESPACE = pg_default
       LC_COLLATE = 'French_France.1252'
       LC_CTYPE = 'French_France.1252'
       CONNECTION LIMIT = -1;

-- Table: public.job

-- DROP TABLE public.job;

CREATE TABLE public.job
(
  name character varying,
  command character varying,
  launch character varying
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public.job
  OWNER TO postgres;

-- Table: public.running

-- DROP TABLE public.running;

CREATE TABLE public.running
(
  id integer NOT NULL,
  job character varying NOT NULL,
  status character varying,
  log character varying
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public.running
  OWNER TO postgres;
