using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVM_WMS.BLL.BusinessLogicModule
{
    public class SortArray
    {
        public static T[] GetSortedArray<T>(T[] inArr, int lineCount, int columnCount, int sortType)
        {
            int t = 0;
            int size = lineCount * columnCount;
            T[] outarray = new T[size];
            T[] buffer = new T[columnCount];
            switch (sortType)
            {
                case 1:
                    {
                        Array.Reverse(inArr);//приводим массив в нужную последовательность.
                    }
                    break;
                case 2:
                    {
                        Array.Reverse(inArr);//приводим массив в нужную последовательность.
                        for (int i = 1; i <= lineCount; i++)
                        {
                            Array.Copy(inArr, t, buffer, 0, columnCount);//копируем элементы массива по у штук с t позиции(на входе - начало создаваевомого массива - 
                            Array.Reverse(buffer);
                            //нулевая позиция).
                            Array.Copy(buffer, 0, outarray, t, columnCount);
                            Array.Clear(buffer, 0, buffer.Length);
                            t = t + columnCount;//назначаем следующую позицию для старта копирования.
                        }
                    }
                    break;
            }

            return outarray;
        }
    }

}
