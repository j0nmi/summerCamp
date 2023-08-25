using Newtonsoft.Json;
using Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static APIPaises.FormatoJson;
using Repositorios;

namespace APIPaises
{
    public class ArrayJsonP : IArrayJsonP
    {
        private readonly IRepositorioPais repositorioPais;

        public ArrayJsonP(IRepositorioPais repositorioPais)
        {
            this.repositorioPais = repositorioPais;
        }

        public void Ejecutar()
        {
            ConsultarAPIyGuardarEnDB().Wait();
        }

        public System.Reflection.PropertyInfo[] ArrayJson_file(Paises jsonDeserializado)
        {
            System.Reflection.PropertyInfo[] propiedades = jsonDeserializado.GetType().GetProperties();
            return propiedades;
        }
        public async Task ConsultarAPIyGuardarEnDB()
        {
            try
            {
                ServicioApi servicioApi = new ServicioApi();
                string responseData = await servicioApi.CallApiAsync();
                var jsonDeserializado = JsonConvert.DeserializeObject<Paises>(responseData);

                // Crear una lista para almacenar los países deserializados
                List<PaisJson> lista_paises = new List<PaisJson>();

                // Obtener las propiedades del objeto deserializado
                System.Reflection.PropertyInfo[] propiedades = ArrayJson_file(jsonDeserializado);

                // Recorrer las propiedades y agregar los países a la lista
                foreach (var propiedad in propiedades)
                {
                    string prefijo = propiedad.Name;
                    string nombre = propiedad.GetValue(jsonDeserializado)?.ToString();
                    lista_paises.Add(new PaisJson(prefijo, nombre));
                }

                // GUARDAR A BASE DE DATOS
                // Crear los países en la BBDD
                foreach (PaisJson item in lista_paises)
                {
                    Pais paisAdd = new Pais();

                    paisAdd.bandera = item.prefijo;
                    paisAdd.nombre = item.nombre;

                    repositorioPais.alta(paisAdd);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
