/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Collections.Generic;

namespace BlackFire
{
    /// <summary>
    /// Magic Utilities.
    /// </summary>
    public static partial class Utility
    {
        public static class Array
        {
            public static T[] Merge<T>(T[] first,T[] second)
            {
                T[] array = new T[first.Length+second.Length];
                int index = 0;

                for (int i = 0; i < first.Length; i++)
                {
                    array[index++] = first[i];
                }

                for (int i = 0; i < second.Length; i++)
                {
                    array[index++] = second[i];
                }
                return array;
            }

            public static T[] Merge<T>(LinkedList<T> first, LinkedList<T> second)
            {
                T[] array = new T[first.Count+second.Count];
                int index = 0;

                var current = first.First;
                while (null!= current)
                {
                    array[index++] = current.Value;
                    current = current.Next;
                }

                current = second.First;
                while (null != current)
                {
                    array[index++] = current.Value;
                    current = current.Next;
                }

                return array;
            }

        }

    }
}

