-- Insertar registros de ejemplo en la tabla 'genero'
INSERT INTO genero (descripcion) VALUES ('Rock');
INSERT INTO genero (descripcion) VALUES ('Pop');
INSERT INTO genero (descripcion) VALUES ('Jazz');
INSERT INTO genero (descripcion) VALUES ('Hip-Hop');

-- Insertar registros de ejemplo en la tabla 'grupo'
INSERT INTO grupo (nombre, formacion, desintegracion) VALUES ('The Beatles', TO_DATE('1960-01-01', 'YYYY-MM-DD'), TO_DATE('1970-04-10', 'YYYY-MM-DD'));
INSERT INTO grupo (nombre, formacion, desintegracion) VALUES ('Queen', TO_DATE('1970-06-27', 'YYYY-MM-DD'), NULL);
INSERT INTO grupo (nombre, formacion, desintegracion) VALUES ('Led Zeppelin', TO_DATE('1968-09-01', 'YYYY-MM-DD'), TO_DATE('1980-12-04', 'YYYY-MM-DD'));

-- Insertar registros de ejemplo en la tabla 'musico'
INSERT INTO musico (nombre, instrumento, lugarnacimiento, fechanacimiento, fechamuerte) VALUES ('John Lennon', 'Guitarra', 'Liverpool', TO_DATE('1940-10-09', 'YYYY-MM-DD'), TO_DATE('1980-12-08', 'YYYY-MM-DD'));
INSERT INTO musico (nombre, instrumento, lugarnacimiento, fechanacimiento, fechamuerte) VALUES ('Freddie Mercury', 'Voz', 'Zanzíbar', TO_DATE('1946-09-05', 'YYYY-MM-DD'), TO_DATE('1991-11-24', 'YYYY-MM-DD'));
INSERT INTO musico (nombre, instrumento, lugarnacimiento, fechanacimiento, fechamuerte) VALUES ('Jimmy Page', 'Guitarra', 'Heston', TO_DATE('1944-01-09', 'YYYY-MM-DD'), NULL);

-- Insertar registros de ejemplo en la tabla 'generosgrupos'
INSERT INTO generosgrupos (idgrupo, idgenero) VALUES (1, 1);
INSERT INTO generosgrupos (idgrupo, idgenero) VALUES (1, 3);
INSERT INTO generosgrupos (idgrupo, idgenero) VALUES (2, 2);
INSERT INTO generosgrupos (idgrupo, idgenero) VALUES (3, 1);
INSERT INTO generosgrupos (idgrupo, idgenero) VALUES (3, 3);

-- Insertar registros de ejemplo en la tabla 'musicosgrupos'
INSERT INTO musicosgrupos (idgrupo, idmusico, instrumento, fechainicio, fechafin) VALUES (1, 1, 'Guitarra', TO_DATE('1960-01-01', 'YYYY-MM-DD'), TO_DATE('1970-04-10', 'YYYY-MM-DD'));
INSERT INTO musicosgrupos (idgrupo, idmusico, instrumento, fechainicio, fechafin) VALUES (2, 2, 'Voz', TO_DATE('1970-06-27', 'YYYY-MM-DD'), NULL);
INSERT INTO musicosgrupos (idgrupo, idmusico, instrumento, fechainicio, fechafin) VALUES (3, 3, 'Guitarra', TO_DATE('1968-09-01', 'YYYY-MM-DD'), TO_DATE('1980-12-04', 'YYYY-MM-DD'));

COMMIT;