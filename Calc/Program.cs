using Calc;

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
        if (stringOperation.Contains('.'))
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        else
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("Ru");

        var lastSimbol = stringOperation[stringOperation.Length - 1];
        var firstSimbol = stringOperation[0];

        if (calc.CheckingForCharacters(stringOperation) && firstSimbol != '/' && firstSimbol != '*')
        {

            while (lastSimbol == '+' || lastSimbol == '-' || lastSimbol == '/' || lastSimbol == '*')
            {
                stringOperation = stringOperation.TrimEnd(lastSimbol);
                lastSimbol = stringOperation[stringOperation.Length - 1];
            }

            if (stringOperation.Contains('('))
            {

                if (calc.CheackingBrackets(stringOperation))
                {

                    calc.Info($"{stringOperation} = {calc.Solution(stringOperation)}");
                }
                else
                {
                    calc.Info("формат записи не верный");
                }
            }
            else
            {

                calc.Info($"{stringOperation} = {calc.Solution(stringOperation)}");
            }
        }
        else
        {
            calc.Info("неверное выражение, внимательней");
        }
    }
    else
        calc.Info($"надо ввести выражение");

    if (Console.ReadKey().Key == ConsoleKey.Escape)
        break;

}





