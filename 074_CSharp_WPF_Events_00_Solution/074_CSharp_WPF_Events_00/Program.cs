namespace _074_CSharp_WPF_Events_00
{
    public delegate void ManejadorEventos<T>(Object source, T datos);
    internal class Program
    {
        //www.youtube.com/watch?v=ZNT_f4LC4Eg&list=PLSmWs9lvUXbAmyFfJJorZErjEhUWRh_1W
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
                    //?- valida que no sea null
                    //if(CambiaNumer != null)
                    CambiaNumero?.Invoke(this, this._cont);
                }
            }
        }

        public event ManejadorEventos<int> CambiaNumero;

    }
}
