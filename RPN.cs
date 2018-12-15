using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNLibrary
{
    public static class RPN
    {
        internal static List<string> GetRPNFromList(List<string> s)
        {
            Stack<string> op = new Stack<string>();
            List<string> res = new List<string>();

            for (int i = 0; i < s.Count; i++)
            {
                string cur = s[i];

                //if (IsNum(cur))
                if (Double.TryParse(cur, out double num))
                    res.Add(cur);
                else
                {
                    string temp = string.Empty;

                    if (op.Count == 0)
                        op.Push(cur);
                    else
                    {
                        if (GetPriority(cur) <= GetPriority(op.Peek()))
                        {
                            while (op.Count != 0 && (GetPriority(cur) <= GetPriority(op.Peek())))
                                res.Add(op.Pop());
                            op.Push(cur);
                        }
                        else
                            op.Push(cur);
                    }
                }
            }

            while (op.Count != 0)
                res.Add(op.Pop());

            return res;
        }

        public static double CalculateRPN(string inputStr)
        {
            List<string> resList = new List<string>();
            string num = string.Empty;

            for (int i = 0; i < inputStr.Length; i++)
            {
                char c = inputStr[i];

                if (IsSqrt(inputStr, out double SqrtRes, ref i))
                {
                    resList.Add(SqrtRes.ToString());
                    continue;
                }

                if (Char.IsDigit(c) || c == ',' || c == '.')
                    num += c;
                else if ((i == 0 && c == '-')
                    || (c == '-' && !Char.IsDigit(inputStr[i - 1])))
                    num += c.ToString();
                else
                {
                    if (num != "")
                        resList.Add(num);
                    resList.Add(c.ToString());
                    num = string.Empty;
                }
            }
            if (num != "")
                resList.Add(num);

            return CalculateRPN(resList);
        }

        public static double CalculateRPN(List<string> inputList)
        {
            List<string> RPNList = GetRPNFromList(inputList);
            Stack<double> nums = new Stack<double>();

            double n1, n2;

            foreach (var i in RPNList)
            {
                //if (IsNum(i))
                if (Double.TryParse(i, out double num))
                    nums.Push(Convert.ToDouble(i));
                else
                {
                    n1 = nums.Pop();
                    n2 = nums.Pop();
                    nums.Push(ApplyOperation(i, n1, n2));
                }
            }

            return nums.Pop();
        }

        private static bool IsSqrt(string inputStr, out double res, ref int iterator)
        {
            string sqrt = "SQRT(";
            res = 0;

            if (inputStr[iterator] == sqrt[0]
                && inputStr.Substring(iterator, sqrt.Length).ToUpper() == sqrt)
            {
                string sqrtNum = string.Empty;
                iterator += sqrt.Length;

                while (inputStr[iterator] != ')')
                {
                    sqrtNum += inputStr[iterator];
                    iterator++;
                }

                res = Math.Sqrt(Double.Parse(sqrtNum));

                return true;
            }

            return false;
        }

        static double ApplyOperation(string op, double n1, double n2)
        {
            switch (op)
            {
                case "+": return (n1 + n2);
                case "-": return (n2 - n1);
                case "*": return (n1 * n2);
                case "/": return (n2 / n1);
                case "^": return (Math.Pow(n2, n1));
                default: return 0;
            }
        }

        static bool IsNum(string op)
        {
            return Char.IsNumber(op.Last());
        }

        /// <summary>
        /// Определяет приоритет операции
        /// </summary>
        /// <param name="op"> Символ оперицции </param>
        /// <returns> Приооритет операции</returns>
        static int GetPriority(string op)
        {
            switch (op)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                case "^":
                    return 3;
                default:
                    return 0;
            }
        }
    }
}
