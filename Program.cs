namespace SpnGF
{
	class Program
	{
		private static void Main(string[] args)
		{

			char[] personnummerChars = SkapaCharArray(); // Först sparar vi in personnummret som chars
			int[] personnummer = KonverteraTillIntArray(personnummerChars); // Sen konverterar vi arrayn till en int array för att kunna göra matte

			/* TODO METODER
			1: Kolla så att första 6 siffrorna stämmer (Shayan)
			2: Kolla så att siffra 7,8,9 Stämmer (Dina)
			3: Kolla så att Kontrollsiffran stämmer (_Soden)

			OBS : Notera att vi sparat upp i en int Array och inte en INT, så metoderna ska jobba med indexeringen för att jämföra och
			göra matte! Jag ska jobba lite och fixar metod #1 imorgon eller söndag!
			*/

			/* Här är lite kod som visar lite hur man kan ändra siffror vid en specifik index, man kan gångra, dela osv en vis index i arrayn
			personnummer[2] = 2;
			personnummer[3] = 3;
			personnummer[3] = personnummer[2] + 2;
			*/

			Console.Write("Ditt Personnummer är : ");
			foreach (int siffra in personnummer)
			{
				Console.Write(siffra); // Skriver ut personnummret för att dubellkolla att allt är rätt
			}

			// Här kollar vi om personnumret är giltigt enligt Luhn-algoritmen. (Dennis)
			bool isValid = KontrolleraSistaSiffra(personnummer);
			Write(" och personnumret är " + (isValid ? "giltigt." : "ogiltigt."));

		}

		// Metod för att kontrollera sista siffran (Dennis)
		static bool KontrolleraSistaSiffra(int[] personnummer)
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

		/* static char[] KollaFödelseOchKön()
		{
			Kolla så att siffra 7,8,9 Stämmer (Dina)
		}
		*/

		static char[] SkapaCharArray()
		{
			char[] personnummerChars = new char[10];

			Console.WriteLine("Ange ditt personnummer, 10 siffror, utan bindestreck:");

			string input = Console.ReadLine();

			if (input.Length == 10) // Kollar så att användaren skrev in 10 chars
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

