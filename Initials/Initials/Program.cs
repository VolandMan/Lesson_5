using System;

namespace Initials
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ФИО");
            string str = Console.ReadLine();
            string[] strpars = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string StrSecondName = strpars[0].Substring(0, 1).ToUpper() + strpars[0].Remove(0, 1).ToLower();
            string StrName = char.ToString(strpars[1][0]);
            string StrSoname = char.ToString(strpars[2][0]);
            Console.WriteLine(String.Concat(StrSecondName, " ", StrName.ToUpper(), ". ", StrSoname.ToUpper(), ". "));
            Console.WriteLine("_________________________________");
        }
    }
}
