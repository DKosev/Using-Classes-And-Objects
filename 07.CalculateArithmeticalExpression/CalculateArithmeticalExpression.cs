using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

/* * Write a program that calculates the value of given arithmetical 
* expression. The expression can contain the following elements only:
* Real numbers, e.g. 5, 18.33, 3.14159, 12.6
* Arithmetic operators: +, -, *, / (standard priorities)
* Mathematical functions: ln(x), sqrt(x), pow(x,y)
* Brackets (for changing the default priorities)
* Examples: (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)  ~ 10.6
* pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)  ~ 21.22 */

class CalculateArithmeticalExpression
{
    // Create dictionary with precedence for methods and operators
    private static Dictionary<string, int> precedence = new Dictionary<string, int>()
    {
        { "pow", 4 },
        { "sqrt", 4 },
        { "ln", 4 },
        { "*", 3 },
        { "/", 3 },
        { "+", 2 },
        { "-", 2 },
        { "(", 0 },
        { ")", 999 }
    };

    // Tokenize the entered string
    private static List<Tuple<string, string>> Tokenize(string inputString)
    {
        var tokens = new List<Tuple<string, string>>();

        for (int value = 0; value < inputString.Length; value++)
        {
            string numberValue = string.Empty;
            string exprType = string.Empty;

            if (inputString[value] == ' ')
            {
                continue;
            }
            else if (char.IsDigit(inputString[value]) || (inputString[value] == '-' && char.IsDigit(inputString[value + 1])))
            {
                exprType = "number";
                for (; value < inputString.Length && (char.IsDigit(inputString[value]) || inputString[value] == '.' || inputString[value] == '-'); value++)
                {
                    numberValue += inputString[value];
                }

                value--;
            }
            else if (char.IsLetter(inputString[value]))
            {
                exprType = "function";
                for (; value < inputString.Length && char.IsLetter(inputString[value]); value++)
                {
                    numberValue += inputString[value];
                }

                value--;
            }
            else if (inputString[value] == ',')
            {
                exprType = "separator";
                numberValue += inputString[value];
            }
            else
            {
                numberValue += inputString[value];
            }

            tokens.Add(new Tuple<string, string>(numberValue, exprType));
        }

        return tokens;
    }

    // Convert infix to postfix expression
    private static List<string> ConvertInfixToPrefix(List<Tuple<string, string>> infix)
    {
        var postfix = new List<string>();
        var operators = new Stack<string>();

        foreach (var tokens in infix)
        {
            string numberValue = tokens.Item1;
            string exprType = tokens.Item2;

            if (exprType == "number")
            {
                postfix.Add(numberValue);
            }
            else if (exprType == "function")
            {
                operators.Push(numberValue);
            }
            else if (exprType == "separator")
            {
                while (operators.Peek() != "(")
                {
                    postfix.Add(operators.Pop());
                }
            }
            else if (numberValue == "(")
            {
                operators.Push(numberValue);
            }
            else if (numberValue == ")")
            {
                while ((numberValue = operators.Pop()) != "(")
                {
                    postfix.Add(numberValue);
                }
            }
            else
            {
                while (operators.Count != 0 && precedence[numberValue] <= precedence[operators.Peek()])
                {
                    postfix.Add(operators.Pop());
                }

                operators.Push(numberValue);
            }
        }

        while (operators.Count != 0)
        {
            postfix.Add(operators.Pop());
        }

        return postfix;
    }

    // Evaluate a postfix expression
    private static double Evaluate(List<string> postfix)
    {
        var stack = new Stack<double>();
        foreach (var token in postfix)
        {
            if (token == "+")
            {
                stack.Push(stack.Pop() + stack.Pop());
            }
            else if (token == "-")
            {
                stack.Push(-stack.Pop() + stack.Pop());
            }
            else if (token == "*")
            {
                stack.Push(stack.Pop() * stack.Pop());
            }
            else if (token == "/")
            {
                stack.Push(1 / stack.Pop() * stack.Pop());
            }
            else if (token == "ln")
            {
                stack.Push(Math.Log(stack.Pop(), Math.E));
            }
            else if (token == "sqrt")
            {
                stack.Push(Math.Sqrt(stack.Pop()));
            }
            else if (token == "pow")
            {
                stack.Push(Math.Pow(y: stack.Pop(), x: stack.Pop()));
            }
            else
            {
                stack.Push(double.Parse(token));
            }
        }

        return stack.Pop();
    }

    static void Main()
    {
        // Convert the comma in numbers to dot
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        // Expressions
        string firstExpression = "(3 + 5.3) * 2.7 - ln(22) / pow(2.2, -1.7)";
        string secondExpression = "pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5 * 0.3)";

        // Output
        Console.WriteLine("You can calculate the value of arithmetical expression.");
        Console.WriteLine("Examples:\n");
        Console.WriteLine("{0} = {1}\n", firstExpression, string.Format("{0:0.00}", Evaluate(ConvertInfixToPrefix(Tokenize(firstExpression)))));
        Console.WriteLine("{0} = {1}\n", secondExpression, string.Format("{0:0.00}", Evaluate(ConvertInfixToPrefix(Tokenize(secondExpression)))));
    }
}
