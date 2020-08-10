CREATE TABLE DIRECTOR
(
    DID         CHAR(5)         NOT NULL,
    D_Name      VARCHAR2(70)    NOT NULL,
    D_phone     CHAR(12)        NOT NULL,
    CONSTRAINT DIRECTOR_pk PRIMARY KEY (DID)

);

CREATE TABLE MOVIE
(
    IMDB            CHAR(17)        NOT NULL,
    Title           VARCHAR2(100)   NOT NULL,
    DID             CHAR(5)         NOT NULL,
    RelDate         DATE            NOT NULL, 
    Movie_genre     VARCHAR(70),
    Price           NUMBER          NOT NULL,
    Award           VARCHAR2(60),    
    CONSTRAINT MOVIE_pk PRIMARY KEY (IMDB),
    CONSTRAINT MOVIE_fk FOREIGN KEY (DID) REFERENCES DIRECTOR (DID)
);

CREATE TABLE WRITER
(
    WID         CHAR(8)         NOT NULL,
    First_Name  VARCHAR2(80)    NOT NULL,
    Last_Name   VARCHAR2(80)    NOT NULL,
    W_Address   VARCHAR2(100)   NOT NULL,
    W_City      VARCHAR2(70)    NOT NULL,
    W_State     VARCHAR2(2)     NOT NULL,
    W_zip       VARCHAR2(20)    NOT NULL,
    DOB         DATE,
    CONSTRAINT WRITER_pk PRIMARY KEY (WID)
);

CREATE TABLE MOVIE_WRITER
( 
    IMDB        CHAR(17)        NOT NULL,
    WID         CHAR(8)         NOT NULL,          
    CONSTRAINT MOVIE_WRITER_pk PRIMARY KEY (ISBN, AID),
    CONSTRAINT MOVIE_WRITER_fk_movie FOREIGN KEY (IMDB) REFERENCES MOVIE (IMDB),
    CONSTRAINT MOVIE_WRITER_fk_writer FOREIGN KEY (WID) REFERENCES WRITER (WID)
);

insert into director (did, d_name, d_phone) 
values ('D1', 'Rick','111-111-1111');

insert into director (did, d_name, d_phone) 
values ('D2', 'Susan', '222-222-2222');

insert into director (did, d_name, d_phone) 
values ('D3', 'James', '333-333-3333');

insert into director (did, d_name, d_phone) 
values ('D4', 'Michael', '444-444-4444');

commit;

insert into movie 
values ('tt0123456','Runaway','D3','15-Dec-17','Comedy',3.56,'NULL');

insert into movie 
values('tt0123342','Comeback','D3','17-Jan-15','Romance',20.23,'NULL');

commit;

insert into movie_writer (imdb, wid)
values ('123-1-123456-12-1', 'W8012439');

insert into movie_writer (imdb, wid)
values ('345-3-345678-34-3', 'W1374256');


COMMIT;

SET DEFINE ON;