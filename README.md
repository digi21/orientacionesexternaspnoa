# Orientaciones Externas PNOA (micro-servicio)

Micro servicio en ASP.NET Core que devuelve orientaciones externas extraídas de bases de datos de PNOA.

Es una prueba de concepto con los datos de la base de datos _AT_bdat_hu30_MUR.mdb_. 
Lo hemos alojado en un servidor gratuito en Azure (de manera que no se le puede exigir mucho rendimiento) en la URL:

```
https://orientacionesexternaspnoa.azurewebsites.net/orientacionexterna/{nombre_de_foto}
```

como por ejemplo:

[https://orientacionesexternaspnoa.azurewebsites.net/orientacionexterna/01_100002](https://orientacionesexternaspnoa.azurewebsites.net/orientacionexterna/01_100002)

...para obtener la orientación externa de la foto 01_100002.

El micro servicio devuelve una cadena JSON con la información de la foto solicitada. Cualquier software con acceso de Internet puede obtener esta información, como la estación fotogramétrica digital [Digi3D.NET](https://www.digi21.net).

A continuación la cadena JSON devuelta con la consulta anterior:

```json
{"x":600864.191049171,"y":4251077.12154873,"z":7825.87054110617,"omega":-0.0205568168298517,"phi":0.283337443362341,"kappa":-0.172895078365148}
```

## Conversión de las bases de datos Access a SQLite

El micro servicio está hospedado en un contenedor Docker en Linux, de manera que hemos tenido que convertir la base de datos Access a un formato de bases de datos compatible con Linux. Como es una prueba de concepto, hemos incluido la base de datos dentro de la propia solución en formato SQLite.

En [dbsofts](https://www.dbsofts.com/articles/ms_access_to_sqlite/) proporcionan una herramienta que permite realizar la conversión.

Al instalarlo y ejecutarlo lo primero que te dicen es que es una herramienta de pago pero que permite importar tablas de menos de 5000 registros, así que
creo que será suficiente sin necesidad de adquirirlo.

* Pulsamos siguiente y en el desplegable "Source" seleccionamos "Microsoft Access (*.mdb;*.accd?)
* En el campo "Database" seleccionamos la base de datos a transformar.
* Pulsamos siguiente.
* Ahora nos solicita la base de datos a crear. Seleccionamos "SQLite".
* En el campo "Database" introducimos la ruta del archivo a crear.
* Pulsamos siguiente.
* Nos muestra las tablas a migrar. Haciendo Click en "Tables" nos selecciona todas las tablas. No es necesario hacer clic en "Views"
* Pulsamos Siguiente
* Pulsamos Submit
* Nos muestra una advertencia de que no se importarán más de 5000 registros. Aceptamos.

Y ya tenemos la base de datos importada.
