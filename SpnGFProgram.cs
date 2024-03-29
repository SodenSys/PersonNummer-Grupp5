﻿using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

public class SpnGFProgram
{
	public static void Main(string[] args)
	{

		char[] SocialSecurityNumberCharray = CreateCharArray(); // Först sparar vi in personnummret som chars
		int[] SocialSecurityNumberIntArray = ConvertIntoIntArray(SocialSecurityNumberCharray); // Sen konverterar vi arrayn till en int array för att kunna göra matte
		ControlFirstSixDigits(SocialSecurityNumberIntArray);

		Write("Ditt Personnummer är: ");
		foreach (int Digit in SocialSecurityNumberIntArray)
		{
			Write(Digit); // Skriver ut personnummret för att dubellkolla att allt är rätt
		}

		bool isValid = ControlLastDigit(SocialSecurityNumberIntArray); // Här kollar vi om personnumret är giltigt enligt Luhn-algoritmen. (Dennis)
		Write(" och personnumret är " + (isValid ? "giltigt.\n" : "ogiltigt.\n"));

		ReadBirthplaceAndSex(SocialSecurityNumberIntArray);


	}
	public static bool ControlLastDigit(int[] intArray) // Metod för att kontrollera sista siffran (Dennis)
	{
		int Sum = 0;

		for (int i = 0; i < intArray.Length; i++)
		{
			int digit = intArray[i];

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

			Sum += digit;
		}

		// Kontrollera om summan är jämnt delbar med 10
		return Sum % 10 == 0;
	}

	public static void ControlFirstSixDigits(int[] intArray) // kontrollerar att man anger en månad eller dag som existerar
	{
		if (intArray[2] > 1)
		{
			WriteLine("Ogiltig månad, testa igen");
		}
		else if (intArray[4] > 3)
		{
			WriteLine("Ogiltig dag, testa igen");
		}
		else if (intArray[2] == 1 && intArray[3] > 2)
		{
			WriteLine("Ogiltig månad, testa igen");
		}
		else if (intArray[4] == 3 && intArray[5] > 1)
		{
			WriteLine("Ogiltig dag, testa igen");
		}
	}

	public static char[] CreateCharArray()
	{
		char[] charArray = new char[10];

		Write("Ange ditt personnummer, 10 siffror, utan bindestreck: ");

		try
		{
		string? input = ReadLine();

		if (!string.IsNullOrEmpty(input) && input.Length == 10) // Säkerställer att användaren skrev in 10 chars
		{
			for (int i = 0; i < 10; i++)
			{
				charArray[i] = input[i]; // Sparar in dem 1 och 1 in till CharArrayen
			}
		}
		else
		{
			WriteLine("Ogiltigt personnummer. Var vänlig ange 10 siffror.");
			return CreateCharArray(); // Börjar om i metoden, så att användaren får en chans till
		}

		}
		catch (Exception e)
		{
		    WriteLine($"Exception: {e}");
		    WriteLine($"Exception Type: {e.GetType().Name}");
		    Environment.Exit(1);
		}
		
		return charArray;
	}

	public static int[] ConvertIntoIntArray(char[] charArray) // Tar in vår Char array, och försöker konvertera den till Int Array
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
				WriteLine("Vänligen använd endast siffror"); // Om använder skrev in 10 chars, men ena eller flera INTE är siffror
				Environment.Exit(1);
			}
		}

		return intArray; // Skickar tillbaks arrayn
	}

	public static void ReadBirthplaceAndSex(int[] intArray)
	{
		int SexNumber = intArray[8];
		int BirthplaceNumberOne = intArray[6];
		int BirthplaceNumberTwo = intArray[7];

		string Sex = (SexNumber % 2 == 0) ? "kvinna" : "man"; //kontrollerar Sex
		string Birthplace = $"{BirthplaceNumberOne}{BirthplaceNumberTwo}"; //kontrollerar födelseplats 

		WriteLine($"Personen är en {Sex} som är född i födelseplats nummer : {Birthplace}"); //Resultat
	}
}