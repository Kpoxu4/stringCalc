using System.Text;
using System.Text.RegularExpressions;

namespace Calc
{
    public class Calculate
    {

        public static string ExpressionToRPN(string expression)
        {
            string current = "";
            Stack<string> stack = new Stack<string>();
            int priority;
            for (int i = 0; i < expression.Length; i++)
            {
                priority = GetPriority(expression[i]);

                if (priority == 0)
                    current += expression[i];
                if (priority == 1)
                    stack.Push(expression[i].ToString());
                if (priority > 1) 
                {
                    current += ' ';
                    while (stack.Count != 0)
                    {
                        if (GetPriority(char.Parse(stack.Peek())) >= priority)
                            current += stack.Pop();
                        else
                            break;
                    }
                    stack.Push(expression[i].ToString());
                }
                if (priority == -1)
                {
                    current += ' ';
                    while (GetPriority(char.Parse(stack.Peek())) != 1)
                    {
                        current += stack.Pop();
                    }
                    stack.Pop();
                }
            }
            while (stack.Count != 0)
            {
                current += stack.Pop();

            }
            return current;
        }

        public static double RPNtoAnswer(string rpn)
        {
            string operand = "";
            Stack<Double> stack = new Stack<Double>();

            for (int i = 0; i < rpn.Length; i++)
            {
                if (rpn[i] == ' ')
                    continue;

                if (GetPriority(rpn[i]) == 0)
                {
                    while (rpn[i] != ' ' && GetPriority(rpn[i]) == 0)
                    {
                        operand += rpn[i++];
                        if (i == rpn.Length)
                        {
                            break;
                        }
                    }
                    stack.Push(double.Parse(operand));
                    operand = "";
                }

                if (GetPriority(rpn[i]) > 1)
                {
                    double a = stack.Pop();
                    double b = stack.Pop();

                    if(rpn[i] == '+')
                        stack.Push(b + a);
                    if (rpn[i] == '-')
                        stack.Push(b - a);
                    if (rpn[i] == '*')
                        stack.Push(b * a);
                    if (rpn[i] == '/')
                        stack.Push(b / a);

                }
            }

            return stack.Pop();
        }

        private static int GetPriority(char tokin)
        {
            switch (tokin)
            {
                case '*':
                case '/':
                    return 3;
                case '+':
                case '-':
                    return 2;
                case '(':
                    return 1;
                case ')':
                    return -1;
               default: return 0; 
            }
        }
    }

}
