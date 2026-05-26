# Sistema Inteligente de Gestión de Turnos (SistemaTurnos)

Herramientas de Programación II - Proyecto Final
Tecnología Base: C# .NET Windows Forms, SQL Server, ADO.NET, Git/GitHub  
Arquitectura: Diseño en Capas Independientes

Descripción del Proyecto
Este sistema es desarrollado para resolver los problemas de congestión, ineficiencia y falta de métricas en salas de espera empresariales. Proporciona una solución integral que abarca desde el registro del cliente en la recepción hasta la gestión de atención por parte de los asesores, controlando flujos lógicos mediante perfiles de acceso.

Problema que Resuelve
La falta de optimización en los flujos de servicio al público genera largas filas y pérdidas económicas. Este software implementa una **Priorización Inteligente Automática** basada en matrices de peso numérico, organizando la cola del servidor en tiempo real y permitiendo extraer indicadores clave de rendimiento (KPIs) para la toma de decisiones.

Instalación y Despliegue Rápido
Configuración de Base de Datos
Abra SQL Server Management Studio (SSMS) y conéctese a su instancia (Ej: .\SQLEXPRESS).

Cree una base de datos llamada SistemaTurnos.

Ejecute en la base de datos el script estructural basedatos.sql y el de programabilidad procedimientos.sql incluidos en la raíz.

Configuración del Código Fuente
Abra la solución .sln en Visual Studio 2022.

En la capa de acceso a datos, verifique que la cadena de conexión de DatabaseConnection.cs apunte a su servidor local:

C#
private readonly string _strConn = @"Server=localhost\SQLEXPRESS;Database=SistemaTurnos;Trusted_Connection=True;TrustServerCertificate=True;";
Compile y ejecute el proyecto (F5).

Arquitectura General
El proyecto se encuentra estrictamente dividido en capas lógicas para asegurar la mantenibilidad y el aislamiento de responsabilidades:
* **Presentación (`SistemaTurnos.Presentacion`):** Aloja las interfaces de usuario (GUI), captura los eventos del teclado y mouse, y muta visualmente según el rol que inicia sesión.
* **Lógica de Negocio (`SistemaTurnos.LogicaNegocio`):** Gobierna el estado transaccional de los formularios mediante un bus de eventos global sincronizado en hilos paralelos.
* **Acceso a Datos (`SistemaTurnos.AccesoDatos`):** Aloja la clase fundamental `DatabaseConnection` encargada de procesar comandos nativos e inyectar parámetros seguros a los procedimientos almacenados.
* **Entidades (`SistemaTurnos.Entidades`):** Clases planas (POCO) de transporte de datos entre capas.

Función Diferencial: Priorización Automática
A diferencia de los sistemas de turnos convencionales tipo FIFO (orden de llegada estricto), este MVP cuenta con un motor de priorización dinámico. Cada trámite configurado en el sistema posee un **peso jerárquico numérico**. 

Al solicitar la cola de espera, el procedimiento almacenado ordena la base de datos aplicando la regla:
```sql
ORDER BY P.peso_prioridad DESC, T.fecha_creacion ASC



