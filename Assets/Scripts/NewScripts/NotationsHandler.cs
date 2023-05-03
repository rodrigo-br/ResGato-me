using System.Collections;
using System.Collections.Generic;
using BreakInfinity;

public static class NotationsHandler
{
    private static readonly List<string> StandardNotation = new List<string>
    {
        "", "K", "M", "B", "T", "Qa", "Qt", "Sx", "Sp", "Oc", "No", "Dc", "UDc", "DDc", "TDc", "QaDc", "QtDc", "SxDc",
        "SpDc", "ODc", "NDc", "Vg", "UVg", "DVg", "TVg", "QaVg", "QtVg", "SxVg", "SpVg", "OVg", "NVg", "Tg", "UTg", 
        "DTg", "TTg", "QaTg", "QtTg", "SxTg", "SpTg", "OTg", "NTg", "Qd", "UQd", "DQd", "TQd", "QaQd", "QtQd", "SxQd",
        "SpQd", "OQd", "NQd", "Qi", "UQi", "DQi", "TQi", "QaQi", "QtQi", "SxQi", "SpQi", "OQi", "NQi", "Se", "USe", "DSe",
        "TSe", "QaSe", "QtSe", "SxSe", "SpSe", "OSe", "NSe", "St", "USt", "DSt", "TSt", "QaSt", "QtSt", "SxSt", "SpSt",
        "OSt", "NSt", "Og", "UOg", "DOg", "TOg", "QaOg", "QtOg", "SxOg", "SpOg", "OOg", "NOg", "Nn", "UNn", "DNn", "TNn",
        "QaNn", "QtNn", "SxNn", "SpNn", "ONn", "NNn", "Ce", 
    };
    

    private static readonly List<List<string>> StandardPrefixes = new List<List<string>>
    {
        new List<string> {"", "U", "D", "T", "Qa", "Qt", "Sx", "Sp", "O", "N"},
        new List<string> {"", "Dc", "Vg", "Tg", "Qd", "Qi", "Se", "St", "Og", "Nn"},
        new List<string> {"", "Ce", "Dn", "Tc", "Qe", "Qu", "Sc", "Si", "Oe", "Ne"}
    };

    private static readonly List<string> StandardPrefixes2 = new List<string>
    {
        "", "MI-", "MC-", "NA-", "PC-", "FM-", "Sx", "Sp", "O", "N"
    };

    public static string GetAbbreviation(BigDouble exp)
    {
        exp = BigDouble.Floor(exp / 3) - 1;
        var index2 = 0;
        var prefix = new List<string> {StandardPrefixes[0][(int) exp % 10]};
        
        while (exp >= 10)     
        {
            exp = BigDouble.Floor(exp / 10);
            prefix.Add(StandardPrefixes[++index2 % 3][(int) exp % 10]);
        }

        index2 = (int)BigDouble.Floor(index2 / 3);

        while (prefix.Count % 3 != 0) prefix.Add("");
        
        
        var ret = "";

        while (index2 >= 0) ret += prefix[index2 * 3] + prefix[index2*3+1] + prefix[index2*3+2] + StandardPrefixes2[index2--];
        

        if (ret.EndsWith("-")) ret = ret.Slice(0, ret.Length - 1);

        return ret.Replace("UM", "M").Replace("UNA", "NA").Replace("UPC", "PC").Replace("UFM", "FM");
    }
    
    private static string Slice(this string source, int start, int end)
    {
        if (end < 0) end = source.Length + end;
        var len = end - start;
        return source.Substring(start, len);
    }

    public static string Notate(this BigDouble number)
    {
        if (number < 1e3 && number > -1e3)
        {
            return number.ToDouble().ToString("N2");
        }

        string numberString = (number / BigDouble.Pow(10, 3 * BigDouble.Floor(number.exponent / 3))).ToString("F2");
        string abbreviationSTring = number.exponent < 306 ?
                                    StandardNotation[(int)((number.exponent - number.exponent % 3) / 3)] :
                                    GetAbbreviation(number.exponent);
        return numberString + abbreviationSTring;
    }
}
