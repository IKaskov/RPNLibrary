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

                if (IsNum(cur))
                //if(Double.TryParse(cur, out double num))
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

        public static double CalculateRPN(List<string> temp)
        {
            List<string> s = GetRPNFromList(temp);
            Stack<double> nums = new Stack<double>();

            double n1, n2;

            foreach (var i in s)
            {
                if (IsNum(i))
                //if(Double.TryParse(i,out double num))
                    nums.Push(Convert.ToDouble( i));
                else
                {
                    n1 = nums.Pop();
                    n2 = nums.Pop();
                    nums.Push(ApplyOperation(i, n1, n2));
                }
            }

            return nums.Pop();
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
