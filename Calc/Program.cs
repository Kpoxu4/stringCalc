using Calc;


Calculate calc = new Calculate();
Cheacking cheacking = new Cheacking();
Information information = new Information();

while (true)
{
    Console.Clear();
    information.Info();
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

        if (cheacking.CheckingForCharacters(stringOperation) && firstSimbol != '/' && firstSimbol != '*')
        {

            while (lastSimbol == '+' || lastSimbol == '-' || lastSimbol == '/' || lastSimbol == '*')
            {
                stringOperation = stringOperation.TrimEnd(lastSimbol);
                lastSimbol = stringOperation[stringOperation.Length - 1];
            }

            if (stringOperation.Contains('('))
            {

                if (cheacking.CheackingBrackets(stringOperation))
                {

                    information.Info($"{stringOperation} = {calc.Solution(stringOperation)}");
                }
                else
                {
                    information.Info("формат записи не верный");
                }
            }
            else
            {

                information.Info($"{stringOperation} = {calc.Solution(stringOperation)}");
            }
        }
        else
        {
            information.Info("неверное выражение, внимательней");
        }
    }
    else
        information.Info($"надо ввести выражение");

    if (Console.ReadKey().Key == ConsoleKey.Escape)
        break;

}





