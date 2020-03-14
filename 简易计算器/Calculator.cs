using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简易计算器
{
    class Calculator
    {
        int mode;
        int _num1;
        int _num2;
        char _operator;
        int _result;
        bool isOK;
        string _str1;
        string _str2;
        string _str;
        public void Func()
        {
            while (true)
            {
                Input();
                Calculate();
                Output();
            }

        }
        void Input()
        {
            Reset();
            try
            {
                Console.WriteLine("输入第一个整数或字符串");
                _str1 = Console.ReadLine();
                _num1 = int.Parse(_str1);
            }
            catch (Exception)
            {
                mode = 2;
            }
            try
            {
                Console.WriteLine("输入运算符");
                _operator = char.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("运算符只能输入【+】【-】【*】【/】【=】");
            }
            try
            {
                Console.WriteLine("输入第二个整数或字符串");
                _str2 = Console.ReadLine();
                _num2 = int.Parse(_str2);
            }
            catch (Exception)
            {
                mode = 2;
            }

        }
        void Calculate()
        {
            if (mode == 1)
            {
                switch (_operator)
                {
                    case '+':
                        _result = Add(_num1, _num2);
                        break;
                    case '-':
                        _result = Remove(_num1, _num2);
                        break;
                    case '*':
                        _result = Multiply(_num1, _num2);
                        break;
                    case '/':
                        _result = Division(_num1, _num2);
                        break;
                    case '=':
                        isOK = false;
                        if (Equals(_num1, _num2))
                        {
                            Console.WriteLine("{0}与{1}相等", _num1, _num2);
                        }
                        else
                        {
                            Console.WriteLine("{0}与{1}不相等", _num1, _num2);
                        }
                        break;
                    default:
                        isOK = false;
                        Console.WriteLine("运算符错误");
                        break;
                }

            }
            else if (mode == 2)
            {
                switch (_operator)
                {
                    case '+':
                        _str = Add(_str1, _str2);
                        break;
                    case '-':
                        _str = Remove(_str1, _str2);
                        break;
                    default:
                        isOK = false;
                        Console.WriteLine("运算符错误");
                        break;
                }

            }
        }
        void Output()
        {
            if (isOK)
            {
                switch (mode)
                {
                    case 1:
                        Console.WriteLine("=" + _result);
                        break;
                    case 2:
                        Console.WriteLine("=" + _str);
                        break;
                }
            }
            else
                Console.WriteLine("无法得出结果");
        }
        void Reset()
        {
            mode = 1;
            isOK = true;
            _operator = '!';
            _result = _num1 = _num2 = 0;
            _str = _str1 = _str2 = "";
        }
        public string Add(string str1, string str2)
        {
            return str1 + str2;
        }
        public string Remove(string str1, string str2)
        {
            int index = str1.IndexOf(str2);
            if (index == -1)
            {
                return str1;
            }
            else
            {
                return str1.Remove(index, str2.Length);
            }
        }
        public int Add(int x, int y)
        {
            return x + y;
        }
        public int Remove(int x, int y)
        {
            return x - y;
        }
        public int Multiply(int x, int y)
        {
            return x * y;
        }
        public int Division(int x, int y)
        {
            if (y == 0)
            {
                isOK = false;
                return 0;
            }
            return x / y;
        }
        bool Equals(int x, int y)
        {
            if (x == y)
                return true;
            else
                return false;
        }


    }
}
