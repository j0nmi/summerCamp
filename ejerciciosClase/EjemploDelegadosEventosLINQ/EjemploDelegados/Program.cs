using EjemploDelegados.Medios;
using static EjemploDelegados.ContenidoMedios;
using static EjemploDelegados.InventarioMedios;

namespace EjemploDelegados
{
    // Hay que crear una aplicación para 
    // el archivo de medios de una biblioteca publica
    // de modo que:
    // A- Segun el tipo de medio indique al usuario los pasos
    //   a dar para reproducir ese medio y verificar 
    //   si está en buen estado para archivarlo
    //   o bien desecharlo si está en mal estado
    // B- Crear una aplicación que permita indicar
    //   los pasos a dar independientemente del medio
    // C- Mostrar el contenido del medio según el tipo de medio. 
    //   Pasar código de barras o identificador para localizar el medio
    //   en la BBDD
    //       CDs - Mostrar lista de canciones
    //       Vinilo - Mostrar lista de canciones en la contraportada
    //       VHS - Mostrar información de la película
    internal class Program
    {
        // Los delegados guardan métodos. 
        // Es como almacenar código en una variable.
        static void Main(string[] args)
        {
            Console.WriteLine("\n");
            //+ 1 Crear instancias

            // Crear instancias
            var inventarioMedios = new InventarioMedios();
            var infoMedios = new ContenidoMedios();

            var tocaDiscos = new Tocadiscos();
            var reproductorCds = new ReproductorCds();
            var videoVhs = new VideoVhs();


            //+ 2 Crear instancias de delegados
            ProbarMediosDelegado probarVinilosDelegado = new ProbarMediosDelegado(tocaDiscos.ProbarVinilo);
            ProbarMediosDelegado probarCdsDelegado = new ProbarMediosDelegado(reproductorCds.ProbarCds);
            ProbarMediosDelegado probarVhsDelegado = new ProbarMediosDelegado(videoVhs.ProbarVideoVhs);

            InfoMedioDelegado infoVinilosDelegado = new InfoMedioDelegado(tocaDiscos.ObtenerCancionesVinilo);
            InfoMedioDelegado infoCdsDelegado = new InfoMedioDelegado(reproductorCds.ObtenerCancionesCd);
            InfoMedioDelegado infoVhsDelegado = new InfoMedioDelegado(videoVhs.ObtenerInfoPelicula);


            //+ 3 Utilizar delegados

            // Probar un vinilo
            //inventarioMedios.ResultadoProbarMedios(probarVinilosDelegado);
            //inventarioMedios.ResultadoProbarMedios(probarCdsDelegado);
            // inventarioMedios.ResultadoProbarMedios(probarVhsDelegado);
            

            // Informacion de Medios introduciendo codigo barras
            infoMedios.ResultadoInfoMedioDelegado(infoVinilosDelegado, "1234");
            infoMedios.ResultadoInfoMedioDelegado(infoCdsDelegado, "5678");
            infoMedios.ResultadoInfoMedioDelegado(infoVhsDelegado, "1111");



        }
    }
}