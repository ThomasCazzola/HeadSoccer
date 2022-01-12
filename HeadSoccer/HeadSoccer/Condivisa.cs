namespace HeadSoccer
{
    public sealed class Condivisa
    {
        // variabile statica per l'istanza della classe Condivisa
        private static Condivisa instance = null;

        public Giocatore avversario { get; set; }

        private Condivisa()
        {
            avversario = new Giocatore();
        }

        private Condivisa(Giocatore g2)
        {
            avversario = g2;
        }

        public static Condivisa GetInstance(Giocatore avversario)
        {
            if (instance == null)
            {
                if (instance == null)
                {
                    instance = new Condivisa(avversario);
                }
            }
            return instance;
        }

        public static Condivisa getInstance()
        {
            if (instance == null)
            {
                instance = new Condivisa();
            }
            return instance;
        }

    }
}
