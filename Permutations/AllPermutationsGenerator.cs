using System;
using System.Collections.Generic;

namespace Permutations
{
    /// <summary>
    /// This class provides generating of all permutations method.
    /// </summary>
    /// <typeparam name="T">Should be comparable.</typeparam>
    public class AllPermutationsGenerator<T> where T : IComparable<T>
    {
        /// <summary>
        /// Makes transposition of two typed variables.
        /// </summary>
        private static void Swap<TP>(ref TP left, ref TP right)
        {
            var temp = left;
            left = right;
            right = temp;
        }

        /// <summary>
        /// Calculates a factorial's value of <param name="number"/>.
        /// </summary>
        /// <param name="number">The integer belonging from 0 to 12.</param>
        private static int Factorial(int number)
        {
            if (number < 0 || number > 12)
                throw new ArgumentOutOfRangeException(nameof(number));

            var result = 1;

            for (var i = 1; i <= number; ++i)
                result *= i;

            return result;
        }

        /// <summary>
        /// Generates all permutations of <param name="set"/>.
        /// </summary>
        /// <param name="set">
        /// Not null and not empty list of typed elements ordered by ascending.
        /// Count of elements shouldn't be more than 11.
        /// </param>
        /// <returns>List of all permutations of <param name="set"/>.</returns>
        public List<List<T>> GenerateAllPermutations(List<T> set)
        {
            if (set == null || set.Count == 0 || set.Count > 11)
                throw new ArgumentOutOfRangeException(nameof(set));

            var length = set.Count;

            if (length == 1)
                return new List<List<T>>(new[] {set});

            var count = Factorial(length);

            var result = new List<List<T>>(count);

            // Массив для текущей перестановки
            var permut = new T[length];

            // Формирование тождественной перестановки
            for (var j = 0; j < length; ++j)
                permut[j] = set[j];
            for (;;)
            {
                var resList = new List<T>(length);

                int i;
                for (i = 0; i < length; ++i)
                    resList.Add(permut[i]);

                result.Add(resList);

                // Найти максимальное i, такое что permut[i] < permut[i+1] 
                for (i = length - 2; i > -1 && permut[i].CompareTo(permut[i + 1]) > 0; --i)
                {
                }

                if (i == -1)
                    break;

                // Найти  permut[j], наименьший элемент справа от 
                // permut[i] и больший его
                var j = length - 1;
                while (permut[i].CompareTo(permut[j]) > 0) --j;

                // Поменять местами и затем 
                // перевернуть  
                Swap(ref permut[i], ref permut[j]);

                var left = i + 1;
                var right = length - 1;

                while (right > left)
                    Swap(ref permut[right--], ref permut[left]);
            }

            return result;
        }
    }
}