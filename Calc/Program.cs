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

    if (stringOperation != "" && stringOperation.Length >= 3)
    {
        var lastSimbol = stringOperation[stringOperation.Length - 1];
        var firstSimbol = stringOperation[0];

        if (calc.CheckingForCharacters(stringOperation))
        {

            while (lastSimbol == '+' || lastSimbol == '-' || lastSimbol == '/' || lastSimbol == '*')
            {
                stringOperation = stringOperation.TrimEnd(lastSimbol);
                lastSimbol = stringOperation[stringOperation.Length - 1];
            }

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
        {
            calc.Info("неверное выражение");
        }
    }
    else
        calc.Info($"надо ввести выражение");
    
    if (Console.ReadKey().Key == ConsoleKey.Escape)
        break;

}





