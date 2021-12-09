using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Permutations;

namespace PermutationsTests
{
    [TestClass]
    public class AllPermutationsGeneratorTests
    {
        private static bool AreEqual<T>(IReadOnlyList<List<T>> expected, IReadOnlyList<List<T>> actual)
        {
            if (expected.Count != actual.Count)
                return false;

            for (var i = 0; i < expected.Count; i++)
            {
                if (expected[i].Count != actual[i].Count)
                    return false;

                for (var j = 0; j < expected[i].Count; j++)
                    if (!expected[i][j].Equals(actual[i][j]))
                        return false;
            }

            return true;
        }

        [TestMethod]
        public void AllIntPermutationsShouldBeEqualToExpected()
        {
            var allPermutationsGenerator = new AllPermutationsGenerator<int>();

            var set = new List<int>(new[] { 1, 2 });

            var expected = new List<List<int>>(new[]
            {
                new List<int>(new[] {1, 2}),
                new List<int>(new[] {2, 1})
            });

            var actual = allPermutationsGenerator.GenerateAllPermutations(set);

            Assert.IsTrue(AreEqual(expected, actual));
        }

        [TestMethod]
        public void AllStringPermutationsShouldBeEqualToExpected()
        {
            var allPermutationsGenerator = new AllPermutationsGenerator<string>();

            var set = new List<string>(new[] {"", "abc"});

            var expected = new List<List<string>>(new[]
            {
                new List<string>(new[] {"", "abc"}),
                new List<string>(new[] {"abc", ""})
                
            });

            var actual = allPermutationsGenerator.GenerateAllPermutations(set);

            Assert.IsTrue(AreEqual(expected, actual));
        }

        [TestMethod]
        public void PermutationsShouldBeNotEqualToExpected()
        {
            var allPermutationsGenerator = new AllPermutationsGenerator<int>();

            var set = new List<int>(new[] { 1, 2 });

            var expected = new List<List<int>>(new[]
            {
                new List<int>(new[] {1, 2}),
                new List<int>(new[] {2, 3})
            });

            var actual = allPermutationsGenerator.GenerateAllPermutations(set);

            Assert.IsFalse(AreEqual(expected, actual));
        }

        [TestMethod]
        public void PermutationsShouldContainOnlySet()
        {
            var allPermutationsGenerator = new AllPermutationsGenerator<int>();

            var set = new List<int>(new[] {1});

            var expected = new List<List<int>>(new[]
            {
                new List<int>(new[] {1})
            });

            var actual = allPermutationsGenerator.GenerateAllPermutations(set);

            Assert.IsTrue(AreEqual(expected, actual));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PermutationsGeneratorShouldThrowArgumentOutOfRangeExceptionIfSetIsEmpty()
        {
            var allPermutationsGenerator = new AllPermutationsGenerator<int>();

            var set = new List<int>();

            allPermutationsGenerator.GenerateAllPermutations(set);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PermutationsGeneratorShouldThrowArgumentOutOfRangeExceptionIfSetIsNull()
        {
            var allPermutationsGenerator = new AllPermutationsGenerator<int>();

            allPermutationsGenerator.GenerateAllPermutations(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PermutationsGeneratorShouldThrowArgumentOutOfRangeExceptionIfSetContainsMoreThan11Elements()
        {
            var allPermutationsGenerator = new AllPermutationsGenerator<int>();

            var set = new List<int>(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12});

            allPermutationsGenerator.GenerateAllPermutations(set);
        }
    }
}
