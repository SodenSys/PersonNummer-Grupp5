using Xunit;

public class SpnGFProgramTests
{
    [Fact] // METOD 1
    public void ControlLastDigit_CheckIfValid() // Testar om den lyckas identifiera rätt sista siffra
    {
        int[] IntArray = { 9, 6, 1, 1, 1, 9, 7, 0, 3, 0 };

        bool result = SpnGFProgram.ControlLastDigit(IntArray);

        Assert.True(result);
    }

    [Fact] // METOD 1
    public void ControlLastDigit_CheckIfInvalid() // Testar om den lyckas identifiera felaktig sista siffra
    {
        int[] IntArray = { 9, 6, 1, 1, 1, 9, 7, 0, 4, 0 };

        bool result = SpnGFProgram.ControlLastDigit(IntArray);

        Assert.False(result);
    }

    [Fact] // METOD 2
    public void ControlFirstSixDigits_CheckIfValid() // Testar så att en valid 6 första 
    {
        int[] IntArray = { 9, 6, 1, 1, 1, 9 };
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            SpnGFProgram.ControlFirstSixDigits(IntArray);
            string actualOutput = sw.ToString().Trim();

            Assert.Equal(string.Empty, actualOutput);
        }
    }

    [Fact] // METOD 2
    public void ControlFirstSixDigits_CheckIfMonthInvalid() // Testar om den lyckas identifiera när en fel månad slås in
    {
        int[] IntArray = { 9, 6, 1, 3, 1, 9 };
        string expectedOutput = "Ogiltig månad, testa igen";
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            SpnGFProgram.ControlFirstSixDigits(IntArray);
            string actualOutput = sw.ToString().Trim();

            Assert.Equal(expectedOutput, actualOutput);
        }
    }

    [Fact] // METOD 2
    public void ControlFirstSixDigits_InvalidDay() // Testar om den lyckas identifiera när en fel dag slås in
    {
        int[] invalidDayIntArray = { 9, 6, 1, 1, 3, 2 };
        string expectedOutput = "Ogiltig dag, testa igen";
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            SpnGFProgram.ControlFirstSixDigits(invalidDayIntArray);
            string actualOutput = sw.ToString().Trim();

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}