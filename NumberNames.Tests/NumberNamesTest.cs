using Xunit;
namespace NumberNames.Tests;

/*
Z - ZERO (OUT OF SCOPE)
O - ONE (ONE DIGIT)
M - MANY (MULTIPLE DIGITS)
B - BOUNDRIES (N/A)
I - longERFACES (N/A)
E - EXCEPTIONS (11-19)
S - SIMPLE SCENARIOS (N/A)
*/

public class NumberNamesTest
{
    [Theory]
    [InlineData(1, "one")]
    [InlineData(2, "two")]
    [InlineData(3, "three")]
    [InlineData(4, "four")]
    [InlineData(5, "five")]
    [InlineData(6, "six")]
    [InlineData(7, "seven")]
    [InlineData(8, "eight")]
    [InlineData(9, "nine")]
    public void Single_Digit_Number(long number, string name)
    {
        Assert.Equal(name, NumberNames.GetName(number));
    }

    [Theory]
    [InlineData(10, "ten")]
    [InlineData(20, "twenty")]
    [InlineData(30, "thirty")]
    [InlineData(40, "forty")]
    [InlineData(50, "fifty")]
    [InlineData(60, "sixty")]
    [InlineData(70, "seventy")]
    [InlineData(80, "eighty")]
    [InlineData(90, "ninety")]
    public void Two_Digit_Multiples_Of_Ten(long number, string name) {
        Assert.Equal(name, NumberNames.GetName(number));
    }

    [Theory]
    [InlineData(21, "twenty one")]
    [InlineData(32, "thirty two")]
    [InlineData(43, "forty three")]
    [InlineData(95, "ninety five")]
    public void Two_Digit_Non_Multiples_Of_Ten(long number, string name)
    {
        Assert.Equal(name, NumberNames.GetName(number));
    }

    [Theory]
    [InlineData(11, "eleven")]
    [InlineData(12, "twelve")]
    [InlineData(13, "thirteen")]
    [InlineData(14, "fourteen")]
    [InlineData(15, "fifteen")]
    [InlineData(16, "sixteen")]
    [InlineData(17, "seventeen")]
    [InlineData(18, "eighteen")]
    [InlineData(19, "nineteen")]
    public void Eleven_To_Nineteen(long number, string name)
    {
        Assert.Equal(name, NumberNames.GetName(number));
    }

    [Theory]
    [InlineData(100, "one hundred")]
    [InlineData(200, "two hundred")]
    [InlineData(900, "nine hundred")]
    public void Three_Digit_Multiples_Of_Hundred(long number, string name)
    {
        Assert.Equal(name, NumberNames.GetName(number));
    }

    [Theory]
    [InlineData(125, "one hundred twenty five")]
    [InlineData(257, "two hundred fifty seven")]
    [InlineData(926, "nine hundred twenty six")]
    [InlineData(906, "nine hundred six")]
    public void Three_Digit_Non_Multiple_Of_Hundred(long number, string name)
    {
        Assert.Equal(name, NumberNames.GetName(number));
    }
    
    [Theory]
    [InlineData(1000, "one thousand")]
    [InlineData(2000, "two thousand")]
    [InlineData(9000, "nine thousand")]
    public void Four_Digit_Multiples_Of_Thousand(long number, string name)
    {
        Assert.Equal(name, NumberNames.GetName(number));
    }

    [Theory]
    [InlineData(1234, "one thousand two hundred thirty four")]
    [InlineData(3805, "three thousand eight hundred five")]
    [InlineData(7011, "seven thousand eleven")]
    public void Four_Digit_Non_Multiples_Of_Thousand(long number, string name)
    {
        Assert.Equal(name, NumberNames.GetName(number));
    }

    [Theory]
    [InlineData(10000, "ten thousand")]
    [InlineData(20000, "twenty thousand")]
    [InlineData(90000, "ninety thousand")]
    public void Five_Digit_Multiples_Of_Ten_Thousand(long number, string name)
    {
        Assert.Equal(name, NumberNames.GetName(number));
    }

    [Fact]
    public void Five_Digit_Multiple_Of_Thousand()
    {
        Assert.Equal("twenty three thousand", NumberNames.GetName(23000));
    }

    [Fact]
    public void Five_Digit_Non_Multiple_Of_Thousand()
    {
        Assert.Equal("thirty four thousand five hundred eleven", NumberNames.GetName(34511));
    }

    [Fact]
    public void Six_Digit_Number()
    {
        Assert.Equal("four hundred fifty eight thousand six hundred twenty", NumberNames.GetName(458620));
    }

    [Theory]
    [InlineData(123456789, "one hundred twenty three million four hundred fifty six thousand seven hundred eighty nine")]
    [InlineData(5600000, "five million six hundred thousand")]
    public void Numbers_In_Millions(long number, string name)
    {
        Assert.Equal(name, NumberNames.GetName(number));
    }
    
    [Theory]
    [InlineData(123456789012, "one hundred twenty three billion four hundred fifty six million seven hundred eighty nine thousand twelve")]
    [InlineData(5000600000, "five billion six hundred thousand")]
    public void Numbers_In_Billions(long number, string name)
    {
        Assert.Equal(name, NumberNames.GetName(number));
    }
   
    [Theory]
    [InlineData(123456789012345, "one hundred twenty three trillion four hundred fifty six billion seven hundred eighty nine million twelve thousand three hundred forty five")]
    [InlineData(5000000600000, "five trillion six hundred thousand")]
    [InlineData(600000000000006, "six hundred trillion six")]
    public void Numbers_In_Trillions(long number, string name)
    {
        Assert.Equal(name, NumberNames.GetName(number));
    }

    [Theory]
    [InlineData(123456789012345678, "one hundred twenty three quadrillion four hundred fifty six trillion seven hundred eighty nine billion twelve million three hundred forty five thousand six hundred seventy eight")]
    [InlineData(50000000000600000, "fifty quadrillion six hundred thousand")]
    [InlineData(600000000000000006, "six hundred quadrillion six")]
    public void Numbers_In_Quadrillions(long number, string name)
    {
        Assert.Equal(name, NumberNames.GetName(number));
    }

    [Theory]
    [InlineData(3456789012345678901, "three quintillion four hundred fifty six quadrillion seven hundred eighty nine trillion twelve billion three hundred forty five million six hundred seventy eight thousand nine hundred one")]
    [InlineData(9223372036854775807, "nine quintillion two hundred twenty three quadrillion three hundred seventy two trillion thirty six billion eight hundred fifty four million seven hundred seventy five thousand eight hundred seven")]
    [InlineData(5000000000000600000, "five quintillion six hundred thousand")]
    [InlineData(6000000000000000006, "six quintillion six")]
    public void Numbers_In_Quintillions(long number, string name)
    {
        Assert.Equal(name, NumberNames.GetName(number));
    }

    [Fact]
    public void Zero()
    {
        Assert.Equal("zero", NumberNames.GetName(0));
    }
}
