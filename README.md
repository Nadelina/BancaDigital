# Prueba Técnica 

Proyecto de banca digital, muestra y exporta el estado de cuenta digital y registra compras y pagos.

El proyecto esta construido en 3 capas:

 Capa de acceso a datos: `Banca.Data` es un proyecto de librerías .NET Standard que contiene métodos de entrada y salida para las entidades de la base de datos, aquí se aplica el patrón repositorio para los métodos del CRUD, incluye también un repositorio genérico que se hereda en los demás repositorios, se configura un `SeedDB` que se encargara de inicializar la base de datos y generar datos de prueba.

Capa de Aplicación y Negocio: `Banca.API`  es un proyecto de .Net 6 que contiene la API desde donde se consumen los métodos creados en la capa de acceso a datos, utiliza principios de CQRS separando las consultas de los comandos e incluye validaciones con FluentValidation

Capa de presentación: `Banca.Application` es un proyecto de MVC que utiliza razor, bootstrap y JQuery, consume a travez de HttpClient los metodos de la capa de negocio

## Levantando el proyecto:

Para configurar el proyecto y levantar un ambiente de desarrollo es necesario: 

1. Cambiar la URL del cliente: Dentro del proyecto de `Banca.API` en el archivo appsettings.json actualizar la UrlSettings llamada cliente, reemplazar la URL por la URL en la que se levanta el proyecto `Banca.Aplicacion`
2. Cambiar la Cadena de conexión: Dentro del proyecto de `Banca.API` en el archivo appsettings.json actualizar la cadena de conexión a la base de datos 
3. Cambiar la URL del servicio: Dentro del proyecto `Banca.Application` en el archivo appsettings.json reemplazar la ApiBaseUrl, por la URL donde se levanta el proyecto `Banca.API`
4. Verificar el orden en el que los proyectos se ejecutan, click derecho en la solución > propiedades > Proyectos de inicio múltiple: en la primera posición `Banca.API`, en la segunda posición `Banca.Application` 

> **Al ejecutar los proyectos, se ejecutará el seeder creado para la base de datos, esto permitirá la creación de la base de datos y sus tablas sin necesidad de realizar migración**
5. Una vez ejecutado el proyecto podrá visualizar la pagina principal, antes de hacer operaciones de creación de compras y pagos se deben ejecutar los triggers adjuntos en Banca.Data en la carpeta SQL>Triggers
> Los triggers actualizaran el saldo del titular en base a la transacción que se realiza: suma el saldo actual cuando se trate de una compra, y resta el saldo actual cuando se trate de un pago


## Características de la capa de presentación
**Estado de cuenta**
Muestra las compras, pagos y realiza el calculo del interés bonificable y el pago mínimo . Permite exportar PDF con todos los detalles del estado de cuenta. Y permite exportar por individual detalle de ventas del mes y detalle de pagos del mes.
**Crear compra**
El formulario presentado posee validaciones con JQuery
**Crear pagos**
El formulario presentado posee validaciones con JQuery


### Peticiones de prueba
Coleccion postman:
https://red-star-626662.postman.co/workspace/Team-Workspace~ca4bd1bc-e990-44e7-8a38-cfb13300fc9f/collection/19633127-05bbe916-0178-4882-9593-581071f63449?action=share&creator=19633127
