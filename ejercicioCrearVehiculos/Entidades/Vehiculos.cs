namespace Entidades
{
    public class Vehiculos
    {
        //  Crea un programa que permita crear diversos tipos de vehículos en función del constructor. 
        //     -Permite crear vehículos especificando el año de compra y el color 
        //     -Permite crear vehículos especificando marca y modelo 
        //     -Permite crear vehículos especificando año de compra, marca, modelo y color.


        public class Vehiculo
        {
            public int AnoCompra { get; set; }
            public string Color { get; set; }
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public Vehiculo(int anocompra, string color, string marca, string modelo)
            {
                AnoCompra = anocompra;
                Color = color;
                Marca = marca;
                Modelo = modelo;
            }

        }

    }
}