[TestClass]
public class SpnGFProgramTests
{
    [TestMethod] // METOD 1
    public void ControlLastDigit_CheckIfValid() // Testar om den lyckas identifiera rätt sista siffra
    {
        int[] IntArray = { 9, 6, 1, 1, 1, 9, 7, 0, 3, 0 };

        bool result = SpnGFProgram.ControlLastDigit(IntArray);

        Assert.IsTrue(result);
    }

    [TestMethod] // METOD 1
    public void ControlLastDigit_CheckIfInvalid() // Testar om den lyckas identifiera felaktig sista siffra
    {
        int[] IntArray = { 9, 6, 1, 1, 1, 9, 7, 0, 4, 0 };

        bool result = SpnGFProgram.ControlLastDigit(IntArray);

        Assert.IsFalse(result);
    }

    [TestMethod] // METOD 2
    public void ControlFirstSixDigits_CheckIfValid() // Testar så att en valid 6 första 
    {
        int[] IntArray = { 9, 6, 1, 1, 1, 9 };
        StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        SpnGFProgram.ControlFirstSixDigits(IntArray);
        string actualOutput = sw.ToString().Trim();

        Assert.AreEqual(string.Empty, actualOutput);
    }

    [TestMethod] // METOD 2
    public void ControlFirstSixDigits_CheckIfMonthInvalid() // Testar om den lyckas identifiera när en fel månad slås in
    {
        int[] IntArray = { 9, 6, 1, 3, 1, 9 };
        string expectedOutput = "Ogiltligt månad i personnumret, vänligen ange personnummret på nytt.";
        StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        SpnGFProgram.ControlFirstSixDigits(IntArray);
        string actualOutput = sw.ToString().Trim();

        Assert.AreEqual(expectedOutput, actualOutput);
    }

    [TestMethod] // METOD 2
    public void ControlFirstSixDigits_InvalidDay() // Testar om den lyckas identifiera när en fel dag slås in
    {
        int[] invalidDayIntArray = { 9, 6, 1, 1, 3, 2 };
        string expectedOutput = "Ogiltligt dag i personnumret, vänligen ange personnummret på nytt.";
        StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        SpnGFProgram.ControlFirstSixDigits(invalidDayIntArray);
        string actualOutput = sw.ToString().Trim();

        Assert.AreEqual(expectedOutput, actualOutput);
    }
}