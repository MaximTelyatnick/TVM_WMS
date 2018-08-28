using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace TVM_WMS.BLL.BusinessLogicModule
{
    /// <summary>
    /// Public class for verification users password
    /// </summary>
    public class Security
    {
        private const string _KEY = "sdkj34t89dfd";

        public static bool VerifyPassword(string input, string basePassword)
        {
            return StringComparer.OrdinalIgnoreCase.Compare(Coding(input), basePassword) == 0 ? true : false;
        }

        public static string Coding(string password)     //процедура "Шифрование". используем шифр Виженера.
        {
            string key = _KEY;
            string all = @"`1234567890-=~!@#$%^&*()_+qwertyuiop[]QWERTYUIOP{}asdfghjkl;'\ASDFGHJKL:""|ZXCVBNM<>?zxcvbnm,./№ёЁйцукенгшщзхъЙЦУКЕНГШЩЗХЪфывапролджэФЫВАПРОЛДЖЭячсмитьбюЯЧСМИТЬБЮ";
            string st; int center;
            string leftSlice, rightSlice, cPass = "";

            if (key.Length > password.Length)               //если длина строки пароля (ключа для входа в программу и для шифрования)>длины строки пароля (какого-либо сайта и т.д.),
            {
                key = key.Substring(0, password.Length);    //то переменная key обрежется и станет равной длинне пароля 
            }
            else                                            // Иначе повторять ключ (ключключключклю), пока не станет равным длинне пароля
                for (int i = 0; key.Length < password.Length; i++)
                {
                    key = key + key.Substring(i, 1);
                }
            //основной цикл шифрования
            for (int i = 0; i < password.Length; i++)
            {//находим центр строки all (центр - это будущий первый символ строки со сдвигом)
                center = all.IndexOf(key.Substring(i, 1));
                leftSlice = all.Substring(center); //берем левую часть будущей строки со сдвигом
                rightSlice = all.Substring(0, center);// затем правую
                st = leftSlice + rightSlice;// формируем строку со сдвигом
                center = all.IndexOf(password.Substring(i, 1));// теперь в переменную center запишем индекс очередного символа шифруемой строки
                cPass += st.Substring(center, 1);    //поскольку индексы символа из строки со сдвигом и из обычной строки совпадают, то нужный нам символ берется по такому же индексу
            }

            return cPass;
        }

        public static string Decoding(string password)        //процедура "Расшифрование"
        {
            string key = _KEY;
            // строка all содержит все символы, которые можно вводить с русской и англ раскладки клавиатуры
            string all = @"`1234567890-=~!@#$%^&*()_+qwertyuiop[]QWERTYUIOP{}asdfghjkl;'\ASDFGHJKL:""|ZXCVBNM<>?zxcvbnm,./№ёЁйцукенгшщзхъЙЦУКЕНГШЩЗХЪфывапролджэФЫВАПРОЛДЖЭячсмитьбюЯЧСМИТЬБЮ";
            //строка st со сдвигом по ключу (в качестве ключа используем наш пароль для входа)
            string st; int center; // центр указывает на индекс символа, до которого идет сдвиг по ключу.
            string leftSlice, rightSlice, cPass = ""; //leftSlice, rightSlice - правый срез, левый срез. из них составляется строка со сдвигом st. 

            //если пароль короче ключа - обрезаем ключ
            if (key.Length > password.Length)
            {
                key = key.Substring(0, password.Length);
            }
            //Иначе повторяем ключ, пока он не примет длинну пароля.
            else
                for (int i = 0; key.Length < password.Length; i++)
                {
                    key = key + key.Substring(i, 1);
                }
            // основной цикл расшифрования.
            for (int i = 0; i < password.Length; i++)
            {
                //находим центр строки all (центр - это будущий первый символ строки со сдвигом)
                center = all.IndexOf(key.Substring(i, 1));
                leftSlice = all.Substring(center); //берем левую часть будущей строки со сдвигом
                rightSlice = all.Substring(0, center);// затем правую
                st = leftSlice + rightSlice; // формируем строку со сдвигом
                center = st.IndexOf(password.Substring(i, 1)); // теперь в переменную center запишем индекс очередного символа расшифроввываемой строки
                cPass += all.Substring(center, 1); //поскольку индексы символа из строки со сдвигом и из обычной строки совпадают, то нужный нам символ берется по такому же индексу
            }
            return cPass; //возвращаем расшифрованный пароль.
        }
    }
}
