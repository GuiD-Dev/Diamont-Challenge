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

        if (_target.Equals('A'))
        {
            return _target.ToString();
        }
        else
        {
            var lines = MakeLines(1, 1);

            var edgeLine = alphabet[0].ToString();
            var spaces = _lineSize - edgeLine.Length;
            while (spaces > 0)
            {
                edgeLine = $" {edgeLine} "; 
                spaces -= 2;
            }

            return $"{edgeLine}\n{lines}{edgeLine}";    
        }
    }

    private static string MakeLines(int index, int numMiddleSpaces)
    {
        var line = alphabet[index].ToString();
        line = line.PadRight(numMiddleSpaces + 1, ' ');
        line += alphabet[index].ToString();

        if (alphabet[index].Equals(_target))
        {
            _lineSize = line.Length;
            return $"{line}\n";
        }

        var middle = MakeLines(index+1, numMiddleSpaces+2);

        var spaces = _lineSize - line.Length;
        while (spaces > 0)
        {
            line = $" {line} "; 
            spaces -= 2;
        }

        line += '\n';

        return line + middle + line;
    }
}