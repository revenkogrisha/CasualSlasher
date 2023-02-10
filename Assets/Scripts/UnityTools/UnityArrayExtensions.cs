using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace UnityTools
{
    public static class UnityArrayExtensions
    {
        public static void ShuffleArray(this Array array)
        {
            var newArray = array.Clone() as int[];
            for (int i = 0; i < newArray.Length; i++)
            {
                var temp = newArray[i];
                var random = Random.Range(0, newArray.Length);

                newArray[i] = newArray[random];
                newArray[random] = temp;
            }

            Array.Copy(newArray, array, array.Length);
        }
    }
}
