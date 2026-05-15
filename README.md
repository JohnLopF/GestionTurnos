# GestionTurnos
Sistema de Gestión de Turnos (TurnoFlow)
Este sistema es una solución integral para la gestión, asignación y trazabilidad de turnos en centros de atención al cliente. Desarrollado en C# con Windows Forms, el proyecto implementa una arquitectura multicapa y un diseño orientado a la eficiencia operativa.

Descripción del Proyecto
El sistema permite optimizar el flujo de clientes mediante la categorización de trámites y prioridades. Incluye módulos para la recepción de clientes, atención por parte de asesores, visualización en tiempo real (Dashboard) y un panel administrativo para la gestión de usuarios y generación de reportes de tiempos de servicio.

Características Principales
Gestión de Usuarios: CRUD completo con eliminación lógica y control de roles (Admin, Recepción, Asesor).
Asignación de Turnos: Generación de códigos alfanuméricos basados en la prioridad (Ej: P-001, G-005).
Panel de Asesor: Interfaz intuitiva para llamar, finalizar o marcar inasistencias de clientes.
Dashboard Público: Pantalla de alta visibilidad para sala de espera que anuncia el turno actual y el módulo correspondiente.
Reportes y Trazabilidad: Seguimiento detallado de la duración de cada atención y tiempos de espera.

Arquitectura Técnica
El proyecto sigue el patrón de diseño N-Tier (Arquitectura en Capas):
Capa de Presentación (UI): Formularios de Windows para la interacción con el usuario.
Capa de Negocio (BLL): Lógica de validación, algoritmos de prioridad y reglas de negocio.
Capa de Acceso a Datos (DAL): Persistencia y comunicación con la base de datos SQL.
Capa de Entidades: Clases de objeto que representan las tablas del sistema.

Modelo de Base de Datos
El sistema utiliza una base de datos relacional con las siguientes tablas principales:
Roles y Usuarios: Seguridad y autenticación.
Prioridades: Configuración de tipos de atención (General, Preferencial, etc.).
Modulos: Puntos físicos de atención.
Turnos y Atenciones: El núcleo operativo y registro de tiempos.
