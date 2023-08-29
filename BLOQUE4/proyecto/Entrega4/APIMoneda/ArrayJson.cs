using static APIMoneda.FormatoJson;
using static APIMoneda.FormatoNombreJson;
using Newtonsoft.Json;
using Repositorios;
using Entidades.Entities;

namespace APIMoneda
{
    public class ArrayJson: IArrayJson
    {
        private Root jsonDeserializado;
        private Root2 jsonDeserializado2;
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
        public System.Reflection.PropertyInfo[] ArrayJson_file2(Root2 jsonDeserializado2)
        {
            System.Reflection.PropertyInfo[] propiedades = jsonDeserializado2.symbols.GetType().GetProperties();
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
                // Valor Monedas
                ServicioApi servicioApi = new ServicioApi();
                string responseData = await servicioApi.CallApiAsync();
                jsonDeserializado = JsonConvert.DeserializeObject<Root>(responseData);
                System.Reflection.PropertyInfo[] lista = ArrayJson_file(jsonDeserializado);

                // Nombre Monedas
                ServicioApiNombres servicioApi2 = new ServicioApiNombres();
                string responseData2 = await servicioApi2.CallApiAsync();
                jsonDeserializado2 = JsonConvert.DeserializeObject<Root2>(responseData2);
                System.Reflection.PropertyInfo[] lista2 = ArrayJson_file2(jsonDeserializado2);

                List<MonedaJson> lista_monedas = new List<MonedaJson>();
                List<MonedaNombreJson> lista_nombres = new List<MonedaNombreJson>();

                //Valor
                foreach (System.Reflection.PropertyInfo item in lista)
                {
                    MonedaJson moneda = new MonedaJson(item.Name,(float)item.GetValue(jsonDeserializado.conversion_rates));             
                    lista_monedas.Add(moneda);
                }
                //Nombre
                foreach (System.Reflection.PropertyInfo item in lista2)
                {
                    MonedaNombreJson monedaNombre = new MonedaNombreJson(item.Name, (string)item.GetValue(jsonDeserializado2.symbols));
                    lista_nombres.Add(monedaNombre);
                }

                //GUARDAR A BASE DE DATOS
                //var prueba = lista_nombres.FirstOrDefault(m => m.codigo == "AAA").nombre;
                //Crear la Moneda en la BBDD
                foreach (MonedaJson item in lista_monedas)
                {
                    //Paso el nombre
                    
                    Moneda monedaAdd = new Moneda();

                    monedaAdd.id = Guid.NewGuid();
                    monedaAdd.codigo = item.codigo;
                    monedaAdd.factor = item.factor;
                    var MonedaCoincide = lista_nombres.FirstOrDefault(m => m.codigo == item.codigo);
                    if (MonedaCoincide != null)
                    {
                        monedaAdd.nombre = MonedaCoincide.nombre;
                    }
                    else
                    {
                        monedaAdd.nombre = null;
                    }
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