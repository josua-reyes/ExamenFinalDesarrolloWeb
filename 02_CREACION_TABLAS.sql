ALTER SESSION SET CURRENT_SCHEMA = EXAMEN_FINAL_DESA_WEB;

-- Crear secuencias para las llaves primarias
CREATE SEQUENCE seq_idgenero START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE seq_idgrupo START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE seq_idmusico START WITH 1 INCREMENT BY 1;

-- Crear la tabla 'genero'
CREATE TABLE genero (
  idgenero INT DEFAULT seq_idgenero.NEXTVAL PRIMARY KEY,
  descripcion VARCHAR(45)
);

-- Crear la tabla 'grupo'
CREATE TABLE grupo (
  idgrupo INT DEFAULT seq_idgrupo.NEXTVAL PRIMARY KEY,
  nombre VARCHAR(45),
  formacion DATE,
  desintegracion DATE
);

-- Crear la tabla 'musico'
CREATE TABLE musico (
  idmusico INT DEFAULT seq_idmusico.NEXTVAL PRIMARY KEY,
  nombre VARCHAR(45),
  instrumento VARCHAR(45),
  lugarnacimiento VARCHAR(45),
  fechanacimiento DATE,
  fechamuerte DATE
);

-- Crear la tabla 'generosgrupos' sin restricciones de clave foránea
CREATE TABLE generosgrupos (
  idgrupo INT,
  idgenero INT
);

-- Crear la tabla 'musicosgrupos' sin restricciones de clave foránea
CREATE TABLE musicosgrupos (
  idgrupo INT,
  idmusico INT,
  instrumento VARCHAR(45),
  fechainicio DATE,
  fechafin DATE
);

-- Agregar las restricciones de clave foránea después de crear todas las tablas
ALTER TABLE generosgrupos
ADD CONSTRAINT fk_generosgrupos_grupo FOREIGN KEY (idgrupo) REFERENCES grupo(idgrupo);

ALTER TABLE generosgrupos
ADD CONSTRAINT fk_generosgrupos_genero FOREIGN KEY (idgenero) REFERENCES genero(idgenero);

ALTER TABLE musicosgrupos
ADD CONSTRAINT fk_musicosgrupos_grupo FOREIGN KEY (idgrupo) REFERENCES grupo(idgrupo);

ALTER TABLE musicosgrupos
ADD CONSTRAINT fk_musicosgrupos_musico FOREIGN KEY (idmusico) REFERENCES musico(idmusico);
