using Calc;
using System.Text.RegularExpressions;

Calculate calc = new Calculate();

while (true)
{
    Console.Clear();
    calc.Info();
    string stringOperation = Console.ReadLine();
    if (stringOperation.Contains(' '))
        stringOperation = string.Join("", stringOperation.Split(' ').ToArray());
    if (stringOperation != "")
    {
        if (stringOperation.Contains('(') && stringOperation.Contains(')'))
        {
            int countSimvol1 = new Regex("\\(").Matches(stringOperation).Count;
            int countSimvol2 = new Regex("\\)").Matches(stringOperation).Count;
            if (countSimvol1 == countSimvol2 && stringOperation.IndexOf('(') < stringOperation.IndexOf(')'))
            {
                calc.Info($"{stringOperation} = {calc.Solution(stringOperation)}");
            }
            else
            {
                calc.Info("не верное количество скобок");
            }
        }
        else
        {
            calc.Info($"{stringOperation} = {calc.Solution(stringOperation)}");
        }
        
    }
    else 
        calc.Info("надо ввести выражение");
    if (Console.ReadKey().Key == ConsoleKey.Escape)
        break;

}





