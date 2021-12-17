# orientacionesexternaspnoa

Micro servicio en ASP.NET Core que devuelve orientaciones externas extraídas de bases de datos de PNOA.

Es una prueba de concepto con los datos de la base de datos AT_bdat_hu30_MUR. 
Lo hemos alojado en un servidor gratuito en Azure (de manera que no se le puede exigir mucho rendimiento) en la URL:

```
https://orientacionesexternaspnoa.azurewebsites.net/orientacionexterna/{nombre_de_foto}
```

como por ejemplo:

[https://orientacionesexternaspnoa.azurewebsites.net/orientacionexterna/01_100002](https://orientacionesexternaspnoa.azurewebsites.net/orientacionexterna/01_100002)

...para obtener la orientación externa de la foto 01_100002.

El micro servicio devuelve una cadena JSON con la información de la foto solicitada. Cualquier software con acceso de Internet puede obtener esta información, como la estación fotogramétrica digital Digi3D.NET.
