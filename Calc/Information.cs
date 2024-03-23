using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class Information
    {
        public void Info()
        {
            Console.WriteLine("Калькулятор простых действий\n" +
                "Пример ввода (2+3)+4+6");
        }

        public void Info(string info)
        {
            Console.WriteLine(info);
            Console.WriteLine("Для продолжения нажмите любую клавишу\n" +
                "что бы выйти нажми ESC");
        }

    }
}
