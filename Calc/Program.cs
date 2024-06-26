﻿using Calc;

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

    if (stringOperation.Contains('.'))
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
    else
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("Ru");

    if (stringOperation != "" && stringOperation.Length >= 3 && cheacking.CheackinOneNumber(stringOperation))
    {

        var lastSimbol = stringOperation[stringOperation.Length - 1];
        var firstSimbol = stringOperation[0];

        if (cheacking.CheckingForCharacters(stringOperation) && firstSimbol != '/' && firstSimbol != '*' && cheacking.CheackinDuobleWrongOp(stringOperation))
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

                    information.Info($"{stringOperation} = {Math.Round(calc.Solution(stringOperation), 3, MidpointRounding.ToEven)}");
                }
                else
                {
                    information.Info("формат записи не верный");
                }
            }
            else
            {
                information.Info($"{stringOperation} = {Math.Round(calc.Solution(stringOperation), 3, MidpointRounding.ToEven)}");
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





