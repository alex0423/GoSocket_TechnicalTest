# GoSocket Technical Test

Este repositorio contiene la solución a una prueba técnica para GoSocket. El objetivo principal fue desarrollar una Azure Function en C# que procese eventos recibidos vía HTTP, aplique reglas de validación y estructuración, y devuelva una respuesta conforme a los requerimientos definidos.

## 🧠 Descripción del Proyecto

Se desarrolló una función HTTP Trigger utilizando **Azure Functions v4** y **.NET 6**, con una arquitectura orientada a la limpieza del código y separación de responsabilidades. El foco estuvo en mantener un código limpio, testeable y fácilmente extensible.

## 🚀 Tecnologías Utilizadas

- C#
- Azure Functions v4
- .NET 6
- Newtonsoft.Json para manejo de JSON
- Visual Studio / VS Code

## 📁 Estructura del Proyecto

GoSocket_TechnicalTest/

│

├── GoSocket.Function/ # Azure Function principal

│ └── Function1.cs # Endpoint HTTP Trigger

│

├── Recursos/ # Folder de recursos usables

│ └── AnexoA.xml # Anexo XML de Areas y Empleados

│

└── host.json / local.settings.json # Configuración de Azure Function


## 📋 Copiar Recurso

Se debe copiar el recurso del proytecto en la ruta especificada

│

├── Recursos/ # Folder

│ └── AnexoA.xml # Anexo


En la ruta C:\GoSocket\Recursos\AnexoA.xml