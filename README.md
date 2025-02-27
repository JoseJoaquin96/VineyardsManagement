# VineyardsManagement

Descripción

Vineyards Management es una API desarrollada en ASP.NET Core Web API con Entity Framework Core y SQL Server. Permite gestionar viñedos, gerentes y parcelas, proporcionando endpoints para consultar datos relacionados de manera eficiente.

También cuenta con otro proyecto Tests, en el cuál se han realizado pruebas unitarias.

Tecnologías utilizadas
  - NET 8
  - ASP.Net Core Web API
  - Entity Framwework Core
  - SQL Server
  - xUnit

Para más información acerca del proyecto, consulta el archivo .pdf que se encuentra en este repositorio.

Instrucciones para ejecutar el proyecto:

  - Requisitos:
      - SQL Server/SQL Server Express
      - SQL Server Management
      - Visual Studio 2019 o superior (en mi caso utilice 2022)

Una vez tengamos todo esto haremos lo siguiente:
  - Descargar el script y ejecutarlo en SQL para la creación de la base de datos con datos de prueba insertados.
  - Abrir el proyecto con Visual Studio. Nos mostrará la siguiente estructura:
  ![image](https://github.com/user-attachments/assets/20235cdc-1d53-48aa-adb8-f4ce5146e64f)
    
  - En nuestro archivo appsettings.json, debemos configurar nuestra conexión a la base de datos, reemplazando el valor de Data Source por nuestro servidor de datos SQL Server.
  - Comprobar que tengamos los paquetes nuggets que se encuentran en la imagen instalados.
  - Inicializar el proyecto desde visual studio. Nos mostrará una pantalla como la siguiente:
    ![image](https://github.com/user-attachments/assets/cfc04557-2db9-4142-976d-3ed87debeb79)

  - Una vez iniciado el proyecto, comprobaremos que todos los endpoints funcionan correctamente y nos devuelven lo necesario.


Como futuras mejoras:
  - Implementar una interfaz más gráfica con MVC.
  - Ampliar la base de datos.
  - Ampliar los distintos endpoints para poder sacar información más precisa de cada tabla o de sus relaciones.
  - Incluir una autenticación para que solo pueda acceder el administrador del viñedo a los datos correspondientes.
    
