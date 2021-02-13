using System;
using System.Text;

public static class Diamond
{
    private static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVXYWZ";
    private static char _target;
    private static int _lineSize;

    public static string Make(char target)
    {
        _target = target;
        _lineSize = alphabet.IndexOf(_target) + 2;

        return _target == 'A'
                    ? target.ToString()
                    : $"{alphabet[0]}\n{MakeLines(1, 1)}{alphabet[0]}";
    }

    private static string MakeLines(int index, int numMiddleSpaces)
    {
        var line1 = alphabet[index].ToString();
        line1 = line1.PadRight(numMiddleSpaces + 1, ' ');
        line1 += alphabet[index].ToString() + '\n';

        if (alphabet[index].Equals(_target))
            return line1;

        line1 += MakeLines(index+1, numMiddleSpaces+2);

        var line2 = alphabet[index].ToString();
        line2 = line2.PadRight(numMiddleSpaces + 1, ' ');
        line2 += alphabet[index].ToString() + '\n';

        return line1 + line2;
    }
}