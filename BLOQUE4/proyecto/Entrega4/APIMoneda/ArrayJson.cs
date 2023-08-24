using static APIMoneda.FormatoJson;
using Newtonsoft.Json;
using Repositorios;
using Entidades.Entities;

namespace APIMoneda
{
    public class ArrayJson: IArrayJson
    {
        private Root jsonDeserializado;
        private readonly IRepositorioMonedas repositorioMonedas;

        public ArrayJson(IRepositorioMonedas repositorioMonedas)
        {
            this.repositorioMonedas = repositorioMonedas;
        }

        public System.Reflection.PropertyInfo[] ArrayJson_file(Root jsonDeserializado)
        {
            System.Reflection.PropertyInfo[] propiedades = jsonDeserializado.conversion_rates.GetType().GetProperties();
            return propiedades;
        }

        public void Ejecutar()
        {
            ConsultarAPIyMostrar().Wait();
        }

        public async Task ConsultarAPIyMostrar()
        {
            try
            {
                
                ServicioApi servicioApi = new ServicioApi();
                string responseData = await servicioApi.CallApiAsync();
                jsonDeserializado = JsonConvert.DeserializeObject<Root>(responseData);

                System.Reflection.PropertyInfo[] lista = ArrayJson_file(jsonDeserializado);
                List<MonedaJson> lista_monedas = new List<MonedaJson>();

                foreach (System.Reflection.PropertyInfo item in lista)
                {
                    MonedaJson moneda = new MonedaJson(item.Name,(float)item.GetValue(jsonDeserializado.conversion_rates));             
                    lista_monedas.Add(moneda);
                }

                //GUARDAR A BASE DE DATOS
                
                //Crear la Moneda en la BBDD
                foreach (MonedaJson item in lista_monedas)
                {
                    //Paso el nombre
                    Moneda monedaAdd = new Moneda();

                    monedaAdd.id = Guid.NewGuid();
                    monedaAdd.codigo = item.codigo;
                    monedaAdd.factor = item.factor;
                    monedaAdd.nombre = item.nombre;
                    repositorioMonedas.alta(monedaAdd);
                    
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

    }
}