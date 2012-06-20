/*==============================================================*/
/* DBMS name:      Sybase SQL Anywhere 10                       */
/* Created on:     12/01/2012 21:21:44                          */
/*==============================================================*/


if exists(
   select 1 from sys.sysindex i, sys.systable t
   where i.table_id=t.table_id 
     and i.index_name='USR_PK'
     and t.table_name='USR'
) then
   drop index USR.USR_PK
end if;

if exists(
   select 1 from sys.systable 
   where table_name='USR'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table USR
end if;

/*==============================================================*/
/* Table: USR                                                   */
/*==============================================================*/
create table USR 
(
   ID_USR               varchar(50)                    not null,
   USR_NAME             varchar(50)                    null,
   USR_PASS             varchar(50)                    null,
   USR_POINT            integer                        null,
   constraint PK_USR primary key (ID_USR)
);

/*==============================================================*/
/* Index: USR_PK                                                */
/*==============================================================*/
create unique index USR_PK on USR (
ID_USR ASC
);

