using System;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace SolucionLeerAnexos
{
    public static class Function1
    {
        [FunctionName("SolucionLeerAnexos")]
        public static void Run(
            //[TimerTrigger("0 */30 * * * *")] TimerInfo myTimer,
            [TimerTrigger("0 * * * * *")] TimerInfo myTimer,
            ILogger log)
        {
            var basePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));
            var path = Path.Combine(basePath, "Recursos", "AnexoA.xml");

            if (!File.Exists(path))
            {
                log.LogError($"Archivo XML no encontrado en la ruta: {path}");
                return;
            }

            XElement xmlRoot;
            try
            {
                xmlRoot = XElement.Load(path);
            }
            catch (Exception ex)
            {
                log.LogError($"Error al leer el XML: {ex.Message}");
                return;
            }

            var areas = ObtenerAreas(xmlRoot);

            var areasConMasDe2 = areas.Count(area =>
                ObtenerEmpleados(area).Count > 2);

            log.LogInformation($"Nodos de tipo <area>: {areas.Count}");
            log.LogInformation(
                $"Nodos <area> con mas de 2 empleados: {areasConMasDe2}");
            log.LogInformation("---------------------------------------------------------------------------");

            foreach (var area in areas)
            {
                var nombre = area.Element("name")?.Value ?? "SinNombre";
                var empleados = ObtenerEmpleados(area);
                if (empleados.Count == 0) continue;

                var totalSalarios = empleados
                    .Select(e => e.Attribute("salary")?.Value)
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(s => double.TryParse(
                        s,
                        NumberStyles.Any,
                        CultureInfo.InvariantCulture,
                        out var val) ? val : 0)
                    .Sum();
                log.LogInformation($"{nombre}|{totalSalarios:F2}");
            }
            log.LogInformation("---------------------------------------------------------------------------");
        }

        private static List<XElement> ObtenerAreas(XElement root)
        {
            return root.Descendants("area").ToList();
        }

        private static List<XElement> ObtenerEmpleados(XElement area)
        {
            return area.Descendants("employee").ToList();
        }
    }
}
