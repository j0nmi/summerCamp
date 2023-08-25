using static APIMonedaNombre.FormatoJsonN;
using Newtonsoft.Json;
using Entidades.Entities;
using Repositorios;

namespace APIMonedaNombre
{
    public class ArrayJsonN : IArrayJsonN
    {
        private Root jsonDeserializado;
        private readonly IRepositorioMonedasNombre repositorioMonedasNombre;

        public ArrayJsonN(IRepositorioMonedasNombre repositorioMonedasNombre)
        {
            this.repositorioMonedasNombre = repositorioMonedasNombre;
        }

        public System.Reflection.PropertyInfo[] ArrayJson_file(Root jsonDeserializado)
        {
            System.Reflection.PropertyInfo[] propiedades = jsonDeserializado.GetType().GetProperties();
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

                ServicioApiN servicioApiN = new ServicioApiN();
                string responseData = await servicioApiN.CallApiAsync();
                jsonDeserializado = JsonConvert.DeserializeObject<Root>(responseData);

                System.Reflection.PropertyInfo[] lista = ArrayJson_file(jsonDeserializado);

                List<MonedaJsonN> lista_monedasNombre = new List<MonedaJsonN>();

                foreach (System.Reflection.PropertyInfo item in lista)
                {
                    MonedaJsonN moneda = new MonedaJsonN(item.Name, (string)item.GetValue(jsonDeserializado.Monedanombre));
                    lista_monedasNombre.Add(moneda);
                }

                //GUARDAR A BASE DE DATOS

                //Crear la Moneda en la BBDD
                foreach (MonedaJsonN item in lista_monedasNombre)
                {
                    //Paso el nombre
                    MonedaNombre monedaAdd = new MonedaNombre();

                    monedaAdd.id = Guid.NewGuid();
                    monedaAdd.codigo = item.codigo;
                    monedaAdd.descripcion = item.descripcion;
                    repositorioMonedasNombre.alta(monedaAdd);

                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

    }
}