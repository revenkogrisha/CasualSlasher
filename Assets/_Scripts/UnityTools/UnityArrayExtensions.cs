using System;
using Random = UnityEngine.Random;

namespace Revenkorg
{
    public static class UnityArrayExtensions
    {
        public static void ShuffleArray(this Array array)
        {
            int[] newArray = array.Clone() as int[];
            for (int i = 0; i < newArray.Length; i++)
            {
                int temp = newArray[i];
                int random = Random.Range(0, newArray.Length);

                newArray[i] = newArray[random];
                newArray[random] = temp;
            }

            Array.Copy(newArray, array, array.Length);
        }
    }
}
