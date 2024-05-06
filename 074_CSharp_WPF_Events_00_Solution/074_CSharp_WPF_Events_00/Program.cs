using System;
using System.Collections.Generic;

namespace _074_CSharp_WPF_Events_00
{
    public delegate void ManejadorEventos<T>(Object source, T datos);
    internal class Program
    {
        //video 1: La Ruta Dev: Qué son y Cómo Funcionan los Eventos en C# ✅ | La guía definitiva.
        //www.youtube.com/watch?v=ZNT_f4LC4Eg&list=PLSmWs9lvUXbAmyFfJJorZErjEhUWRh_1W

        //video 2: Cómo Personalizar Un Evento En C# | La guía definitiva  ✅ 
        //www.youtube.com/watch?v=S3V0ZaU9wio&list=PLSmWs9lvUXbAmyFfJJorZErjEhUWRh_1W&index=2


        static NumRandom numero;
        static int random;
        static void Main(string[] args)
        {
            Random rand = new Random();
            random = rand.Next(1, 10);
            numero = new NumRandom();

            numero.EvtCambiaNumero += CambiaNumero;
            numero.EvtCambiaNumero += CambiaNumeroSuccess;
            numero.EvtCambiaNumero += CambiaNumeroFail;
            numero.EvtCambiaNumero += CambiaNumeroFail;
            numero.EvtCambiaNumero -= CambiaNumeroFail;

            while (random != numero.Numero)
            {
                Console.WriteLine($"El random es: {random}. Ingresa un numero del 1 al 10");
                numero.Numero = int.Parse(Console.ReadLine());
                numero.Cont++;
                if(numero.Cont == 3)
                {
                    break;
                }
            }
        }

        static void CambiaNumero(Object source, int datos)
        {
            numero = (NumRandom)source;
            Console.WriteLine($"El random es: {random} El número ha cambiado a {numero.Numero}");
        }

        static void CambiaNumeroSuccess(Object source, int datos)
        {
            numero = (NumRandom)source;
            if(numero.Numero == random && numero.Cont <= 3)
            {
                Console.WriteLine($"Felicidades el número aleatorio es {numero.Numero}");

            }
        }

        static void CambiaNumeroFail(Object source, int datos)
        {
            numero = (NumRandom)source;
            if (numero.Numero != random && numero.Cont >= 3)
            {
                Console.WriteLine($"Lo siento has fallado el número aleatorio era {random}");

            }
        }
    }

    internal class NumRandom
    {
        public int Numero { get; set; }
        private int _cont;

        public NumRandom()
        {
            Numero = 0;
            _cont = 0;
        }

        public int Cont
        {
            get { return _cont; }
            set {
                if( _cont != value)
                {
                    _cont = value;
                    //?- valida que no sea null
                    //if(CambiaNumer != null)
                    _evtCambiaNumero?.Invoke(this, this._cont);
                }
            }
        }

        private ManejadorEventos<int> _evtCambiaNumero;
        public event ManejadorEventos<int> EvtCambiaNumero
        {
            add
            {
                _evtCambiaNumero += value;
                Console.WriteLine($"Añadido el método {value} al evento EvtCambiaNumero");
            }

            remove
            {
                _evtCambiaNumero -= value;
                Console.WriteLine($"Eliminado el método {value} del evento EvtCambiaNumero");
            }
        }

    }
}
