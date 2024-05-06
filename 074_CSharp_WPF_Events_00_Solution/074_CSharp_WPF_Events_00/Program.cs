namespace _074_CSharp_WPF_Events_00
{
    public delegate void ManejadorEventos<T>(Object source, T datos);
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    internal class NumRandom
    {
        public int Numero { get; set; }
        private int _cont;

        public int Cont
        {
            get { return _cont; }
            set {
                if( _cont != value)
                {
                    _cont = value;
                }
            }
        }

        public event ManejadorEventos<int> CambiaNumero;

    }
}
