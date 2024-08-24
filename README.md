# S3ExampleApp

## Descripción

**S3ExampleApp** es una aplicación de consola en .NET diseñada para interactuar con Amazon S3, uno de los servicios de almacenamiento en la nube proporcionados por AWS. Esta aplicación permite a los desarrolladores listar los buckets de S3 en su cuenta de AWS y subir archivos a un bucket específico de manera sencilla y eficiente.

## Funcionalidades

- **Listar Buckets de S3**: La aplicación muestra una lista de todos los buckets de S3 asociados con la cuenta de AWS configurada.
- **Subir Archivos a S3**: La aplicación permite subir un archivo local a un bucket de S3, con opciones para configurar la clase de almacenamiento, el tamaño de las partes (para archivos grandes), y permisos de acceso público.

## Requisitos

- **.NET SDK**: Asegúrate de tener instalado el .NET SDK.
- **Visual Studio 2019 o superior**: Para compilar y ejecutar la aplicación.
- **AWS CLI**: Configurado con un perfil válido que tenga permisos para operar en S3.
- **AWS SDK for .NET**: Incluido en el proyecto a través del paquete NuGet `AWSSDK.S3`.

## Instalación y Configuración

1. **Clonar el Repositorio**:
   ```bash
   git clone https://github.com/tu-usuario/S3ExampleApp.git
   cd S3ExampleApp

2. **Abrir el Proyecto en Visual Studio**:
    Abre el archivo S3ExampleApp.sln en Visual Studio.
3. **Agregar Configuracione**:
    - Asegúrate de haber configurado AWS CLI con un perfil  que tenga permisos para acceder a S3.
    - Reemplaza los valores de bucketName, keyName y filePath en Program.cs con los valores correspondientes a tu entorno.
4. **Ejecutar la Aplicación**:

 - Presiona F5 o selecciona Start en Visual Studio para compilar y ejecutar la aplicación.
## Uso
Al ejecutar la aplicación, se realizarán los siguientes pasos:

 - Listar los buckets de S3 disponibles en tu cuenta.
 - Subir un archivo local especificado al bucket de S3 designado.
- Verificar que la subida se haya realizado correctamente.

## Personalización
Puedes personalizar esta aplicación para realizar otras operaciones en S3, como la descarga de archivos, eliminación de objetos, o la creación de nuevos buckets. También puedes expandir la funcionalidad para integrar otros servicios de AWS.

## Contribuciones
¡Las contribuciones son bienvenidas! Si deseas agregar más funcionalidades o mejorar el código existente, no dudes en abrir un pull request.