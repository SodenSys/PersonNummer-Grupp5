namespace SpnGF
{
    class Program
    {
        private static void Main(string[] args)
        {

            char[] personnummerChars = SkapaCharArray(); // Först sparar vi in personnummret som chars
            int[] personnummer = KonverteraTillIntArray(personnummerChars); // Sen konverterar vi arrayn till en int array för att kunna göra matte
            KontrolleraFörstaSex(personnummer);

            Console.Write("Ditt Personnummer är : ");
            foreach (int siffra in personnummer)
            {
                Console.Write(siffra); // Skriver ut personnummret för att dubellkolla att allt är rätt
            }

            bool isValid = KontrolleraSistaSiffra(personnummer); // Här kollar vi om personnumret är giltigt enligt Luhn-algoritmen. (Dennis)
            Console.Write(" och personnumret är " + (isValid ? "giltigt.\n" : "ogiltigt.\n"));

            VisaKönOchFödelseplats(personnummer);


        }
        static bool KontrolleraSistaSiffra(int[] personnummer) // Metod för att kontrollera sista siffran (Dennis)
        {
            int summa = 0;

            for (int i = 0; i < personnummer.Length; i++)
            {
                int digit = personnummer[i];

                // Jämna positioner (0-index) dubbleras
                if (i % 2 == 0)
                {
                    digit *= 2;

                    // Om dubbelvärdet är större än 9, subtrahera 9
                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }

                summa += digit;
            }

            // Kontrollera om summan är jämnt delbar med 10
            return summa % 10 == 0;
        }

        static void VisaKönOchFödelseplats(int[] personnummer)
        {
            int könsNummer = personnummer[8];
            int födelseNummer1 = personnummer[6];
            int födelseNummer2 = personnummer[7];

            string kön = (könsNummer % 2 == 0) ? "kvinna" : "man"; //kontrollerar kön
            string födelseort = $"{födelseNummer1}{födelseNummer2}"; //kontrollerar födelseplats 

            Console.WriteLine($"Personen är en {kön} som är född i födelseplats nummer : {födelseort}"); //Resultat
        }

        static void KontrolleraFörstaSex(int[] personnummer) // kontrollerar att man anger en månad eller dag som existerar
        {
            if (personnummer[2] > 1)
            {
                Console.WriteLine("Ogiltligt månad i personnumret, vänligen ange personnummer på nytt.");
                Environment.Exit(1);
            }
            else if (personnummer[4] > 3)
            {
                Console.WriteLine("Ogiltligt dag i personnumret, vänligen ange personnummer på nytt.");
                Environment.Exit(1);
            }
            else if (personnummer[2] == 1 && personnummer[3] > 2)
            {
                Console.WriteLine("Ogiltligt månad i personnumret, vänligen ange personnummer på nytt.");
                Environment.Exit(1);
            }
            else if (personnummer[4] == 3 && personnummer[5] > 1)
            {
                Console.WriteLine("Ogiltligt dag i personnumret, vänligen ange personnummer på nytt.");
                Environment.Exit(1);
            }
        }

        static char[] SkapaCharArray()
        {
            char[] personnummerChars = new char[10];

            Console.Write("Ange ditt personnummer, 10 siffror, utan bindestreck: ");

            string input = Console.ReadLine();

            if (input.Length == 10) // Säkerställer att användaren skrev in 10 chars
            {
                for (int i = 0; i < 10; i++)
                {
                    personnummerChars[i] = input[i]; // Sparar in dem 1 och 1 in till CharArrayen
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt personnummer. Var vänlig ange 10 siffror.");
                return SkapaCharArray(); // Börjar om i metoden, så att användaren får en chans till
            }

            return personnummerChars;
        }



        static int[] KonverteraTillIntArray(char[] charArray) // Tar in vår Char array, och försöker konvertera den till Int Array
        {
            int[] intArray = new int[charArray.Length]; // Skapar en temporär array som sprar siffrorna som sedan ska skickas tillbaks

            for (int i = 0; i < charArray.Length; i++)
            {
                if (int.TryParse(charArray[i].ToString(), out int digit))
                {
                    intArray[i] = digit; // Gör alla index i arrayn till siffror
                }
                else
                {
                    Console.WriteLine("Vänligen använd endast siffror"); // Om använder skrev in 10 chars, men ena eller flera INTE är siffror
                    Environment.Exit(1);
                }
            }

            return intArray; // Skickar tillbaks arrayn
        }

    }

}
