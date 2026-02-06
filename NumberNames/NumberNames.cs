using System.Diagnostics;
using System.Text;

namespace NumberNames;

public class NumberNames
{
    record DigitNames(
        string Digit,
        string TensDigit,
        string ElevenToNineteen
    );

    private static readonly Dictionary<int, DigitNames> digitNames = new()
    {
        { 1, new DigitNames("one", "ten", "eleven")},
        { 2, new DigitNames("two", "twenty", "twelve")},
        { 3, new DigitNames("three", "thirty", "thirteen")},
        { 4, new DigitNames("four", "forty", "fourteen")},
        { 5, new DigitNames("five", "fifty", "fifteen")},
        { 6, new DigitNames("six", "sixty", "sixteen")},
        { 7, new DigitNames("seven", "seventy", "seventeen")},
        { 8, new DigitNames("eight", "eighty", "eighteen")},
        { 9, new DigitNames("nine", "ninety", "nineteen")},
    };

    private static readonly Dictionary<int, string> digitGroupLabels = new()
    {
        {2, "thousand"},
        {3, "million"},
        {4, "billion"},
        {5, "trillion"},
        {6, "quadrillion"},
        {7, "quintillion"}
    };

    public static string GetName(ulong number)
    {
        if (number == 0)
            return "zero";

        return GetRemainderAsName(number, GetNumDigitGroups(number));
    }

    private static int GetNumDigitGroups(ulong number)
    {
        return (int)Math.Floor(Math.Log10(number)) / 3 + 1;
    }

    private static string GetRemainderAsName(ulong remainder, int numDigitGroups)
    {
        if (remainder == 0)
            return "";

        var nameBuilder = new StringBuilder();

        ulong digitGroupBase = GetDigitGroupBase(numDigitGroups);
        int nextDigitGroup = (int)(remainder / digitGroupBase);

        nameBuilder.Append(GetDigitGroupAsNameWithLabel(nextDigitGroup, numDigitGroups));

        if (numDigitGroups > 1)
            nameBuilder
                .Append(' ')
                .Append(GetRemainderAsName(remainder % digitGroupBase, numDigitGroups - 1));

        return nameBuilder.ToString().Trim();
    }

    private static ulong GetDigitGroupBase(int numDigitGroups)
    {
        return (ulong)Math.Pow(10, (numDigitGroups - 1) * 3);
    }

    private static string GetDigitGroupAsNameWithLabel(int digitGroup, int digitGroupNumber)
    {
        Debug.Assert(digitGroup < 1000, "Digit group " + digitGroup + " must be less than one thousand");
        
        if (digitGroup == 0)
            return "";

        var nameBuilder = new StringBuilder();

        nameBuilder.Append(GetDigitGroupAsName(digitGroup));

        if (digitGroupNumber > 1)
            nameBuilder
                .Append(' ')
                .Append(GetDigitGroupLabel(digitGroupNumber));

        return nameBuilder.ToString();
    }
   
    private static string GetDigitGroupAsName(int digitGroup)
    {
        Debug.Assert(0 < digitGroup && digitGroup < 1000, "digitGroup " + digitGroup + " must be between 0 and 1000");

        var nameBuilder = new StringBuilder();

        if (digitGroup >= 100)
            nameBuilder.Append(GetHundredsDigitAsName(digitGroup));

        nameBuilder
            .Append(' ')
            .Append(GetTwoDigitNumberAsName(digitGroup % 100));

        return nameBuilder.ToString().Trim();
    }

    private static string GetHundredsDigitAsName(int digitGroup)
    {
        Debug.Assert(0 < digitGroup && digitGroup < 1000, "digitGroup " + digitGroup + " must be between 0 and 1000");
        
        return digitNames[digitGroup / 100].Digit + " hundred";
    }

    private static string GetTwoDigitNumberAsName(int twoDigitNumber)
    {
        Debug.Assert(twoDigitNumber < 100, "twoDigitNumber " + twoDigitNumber + " must be less than 100");
 
        if (twoDigitNumber == 0)
            return "";
        
        var nameBuilder = new StringBuilder();

        if (11 <= twoDigitNumber && twoDigitNumber <= 19)
            return nameBuilder.Append(GetElevenToNineteenAsName(twoDigitNumber)).ToString();

        if (twoDigitNumber >= 10)
            nameBuilder
                .Append(GetTensDigitForEveryNumberExpectElevenThroughNineteenAsName(twoDigitNumber))
                .Append(' ');

        nameBuilder.Append(GetOnesDigitAsName(twoDigitNumber % 10));

        return nameBuilder.ToString().Trim();
    }
   
    private static string GetElevenToNineteenAsName(int twoDigitNumber)
    {
        Debug.Assert(11 <= twoDigitNumber && twoDigitNumber <= 19, "twoDigitNumber " + twoDigitNumber + " must be between 11 and 19");

        return digitNames[twoDigitNumber - 10].ElevenToNineteen;
    }
   
    private static string GetTensDigitForEveryNumberExpectElevenThroughNineteenAsName(int twoDigitNumber)
    {
        Debug.Assert(twoDigitNumber >= 20 || twoDigitNumber <= 10, "twoDigitNumber " + twoDigitNumber + " cannot be between 10 and 20");

        return digitNames[twoDigitNumber / 10].TensDigit;
    }
    
    private static string GetOnesDigitAsName(int onesDigit)
    {
        Debug.Assert(onesDigit < 10, "onesDigit " + onesDigit + " must be less than 10");

        if (onesDigit == 0)
            return "";

        return digitNames[onesDigit].Digit;
    }

    private static string GetDigitGroupLabel(int digitGroupNumber)
    {
        Debug.Assert(digitGroupNumber >= 2, "Digit group number " + digitGroupNumber + " must be at least 2 to have label");

        return digitGroupLabels[digitGroupNumber];
    }
}