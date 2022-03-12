// See https://aka.ms/new-console-template for more information
namespace Mod3
{

    class KodeBuah
    {
        public enum Buah { Apel, Aprikot, Alpukat, Pisang, Paprika, Blackberry, Ceri, Kelapa, Jagung, Kurma, Durian, Anggur, Melon, Semangka}
        public static string getKodeBuah(Buah buah)
        {
            string[] kodeBuah = { "A00", "B00", "C00", "D00", "E00", "F00", "G00", "H00", "I00", "J00", "K00", "L00", "M00", "N00", "O00" };
            return kodeBuah[(int) buah];
        }
    }

    class PosisiKarakterGame
    {
        public enum State { Tengkurap, Jongkok, Berdiri, Terbang}
        public enum Trigger { TombolW, TombolS, TombolX}
        public State currentState;

        public PosisiKarakterGame()
        {
            currentState = State.Terbang;
        }

        class Transition
        {
            public State prevState;
            public State nextState;
            public Trigger trigger;

            public Transition(State prevState, State nextState, Trigger trigger)
            {
                this.prevState = prevState;
                this.nextState = nextState;
                this.trigger = trigger;
            }
        }

        private Transition[] transitions =
        {
            new Transition(State.Tengkurap, State.Jongkok, Trigger.TombolW),
            new Transition(State.Jongkok, State.Tengkurap, Trigger.TombolS),
            new Transition(State.Jongkok, State.Berdiri, Trigger.TombolW),
            new Transition(State.Berdiri, State.Jongkok, Trigger.TombolS),
            new Transition(State.Berdiri, State.Terbang, Trigger.TombolW),
            new Transition(State.Terbang, State.Berdiri, Trigger.TombolS),
            new Transition(State.Terbang, State.Jongkok, Trigger.TombolX)
        };

        public State getNextState(State prevState, Trigger trigger)
        {
            State nextState = prevState;

            for (int i = 0; i < transitions.Length; i++)
            {
                if (transitions[i].prevState == prevState && transitions[i].trigger == trigger)
                {
                    nextState = transitions[i].nextState;
                }
            }

            return nextState;
        }

        public void activateTrigger(Trigger trigger)
        {
            State nextState = getNextState(currentState, trigger);
            currentState = nextState;

            if (trigger == Trigger.TombolS)
            {
                Console.WriteLine("tombol arah bawah ditekan");
            }
            else if (trigger == Trigger.TombolW)
            {
                Console.WriteLine("tombol arah atas ditekan");
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            PosisiKarakterGame karakter = new();

            Console.WriteLine("Contoh memunculkan kode buah dengan konsep table driven ");
            Console.WriteLine($"Kode apel\t: {KodeBuah.getKodeBuah(KodeBuah.Buah.Apel)}");
            Console.WriteLine($"Kode anggur\t: {KodeBuah.getKodeBuah(KodeBuah.Buah.Anggur)}");

            Console.WriteLine("Contoh menjalankan kelas PosisiKarakterGame menggunakan konsep state-based dengan posisi default terbang");

            Console.WriteLine("1. Tekan S");
            karakter.activateTrigger(PosisiKarakterGame.Trigger.TombolS);
            Console.WriteLine($"Current state: {karakter.currentState}");

            Console.WriteLine("2. Tekan W");
            karakter.activateTrigger(PosisiKarakterGame.Trigger.TombolW);
            Console.WriteLine($"Current state: {karakter.currentState}");

            Console.WriteLine("3. Tekan X");
            karakter.activateTrigger(PosisiKarakterGame.Trigger.TombolX);
            Console.WriteLine($"Current state: {karakter.currentState}");

            Console.WriteLine("4. Tekan S");
            karakter.activateTrigger(PosisiKarakterGame.Trigger.TombolS);
            Console.WriteLine($"Current state: {karakter.currentState}");

            Console.WriteLine("5. Tekan W");
            karakter.activateTrigger(PosisiKarakterGame.Trigger.TombolW);
            Console.WriteLine($"Current state: {karakter.currentState}");

            Console.WriteLine("6. Tekan W");
            karakter.activateTrigger(PosisiKarakterGame.Trigger.TombolW);
            Console.WriteLine($"Current state: {karakter.currentState}");

            Console.WriteLine("7. Tekan S");
            karakter.activateTrigger(PosisiKarakterGame.Trigger.TombolS);
            Console.WriteLine($"Current state: {karakter.currentState}");
        }
    }
}