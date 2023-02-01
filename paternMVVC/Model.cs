using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paternMVVC
{
    static class Model
    {
        public static double? count = null;

        public static List<string> dataList = new List<string> { "Сложение", "Вычитание", "Деление", "Умножение" };
        public static List<string> dataZnak = new List<string> { "+", "-", "/", "*" };
    }
}
