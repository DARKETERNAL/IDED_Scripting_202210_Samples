using System.Collections.Generic;
using System.Linq;

namespace SourceSample
{
    public class SampleAlgorithms
    {
        public static bool IsPalindrome(string sourceString)
        {
            bool result = true;
            string compareStr = sourceString.ToLower();

            Stack<char> sourceStack = FillStack(compareStr);
            Stack<char> compareStack = FillStackInversed(compareStr);

            do
            {
                result = sourceStack.Pop() == compareStack.Pop();
                //char char1 = sourceStack.Pop();
                //char char2 = compareStack.Pop();

                //result = char1 == char2;
            }
            while (result && sourceStack.Count > 0);

            return result;
        }

        public static KeyValuePair<T2, T1> GetFromDictionary<T1, T2>(Queue<T1> sourceQueue, Stack<T2> sourceStack, int index)
        {
            T2 resultKey;
            T1 resultValue;

            Dictionary<T2, T1> dictionary = FillDictionary(sourceQueue, sourceStack);

            //result = dictionary.ElementAt(index);

            resultKey = dictionary.Keys.ToArray()[index];
            resultValue = dictionary.Values.ToArray()[index];

            KeyValuePair<T2, T1> result = new KeyValuePair<T2, T1>(resultKey, resultValue);

            return result;
        }

        private static Dictionary<T2, T1> FillDictionary<T2, T1>(Queue<T1> sourceQueue, Stack<T2> sourceStack)
        {
            Dictionary<T2, T1> result = new Dictionary<T2, T1>();

            if (sourceQueue.Count <= sourceStack.Count)
            {
                while (sourceQueue.Count > 0)
                {
                    try
                    {
                        result.Add(sourceStack.Pop(), sourceQueue.Dequeue());
                    }
                    catch (System.Exception)
                    {
                        sourceQueue.Dequeue();
                        sourceStack.Pop();
                        continue;
                    }
                }
            }
            else
            {
                while (sourceQueue.Count > 0)
                {
                    try
                    {
                        result.Add(sourceStack.Pop(), sourceQueue.Dequeue());
                    }
                    catch (System.Exception)
                    {
                        sourceQueue.Dequeue();
                        sourceStack.Pop();
                        continue;
                    }
                }
            }

            return result;
        }

        private static Stack<char> FillStackInversed(string str)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = str.Length - 1; i >= 0; i--)
            {
                stack.Push(str[i]);
            }

            return stack;
        }

        private static Stack<char> FillStack(string str)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                stack.Push(str[i]);
            }

            return stack;
        }
    }
}