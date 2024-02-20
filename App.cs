using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Security.Policy;
using System.Xml;
using Microsoft.Extensions.Options;
//using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using System.Linq;
using System.Drawing.Printing;

namespace Numatic.Apps.CodingChallenges
{

    /// <summary>
    /// The main application class
    /// </summary>
    public class App : IApp
    {

        /// <summary>
        /// App constructor
        /// </summary>
        public App()
        {

        }

        /// <summary>
        /// The entrypoint to the application
        /// </summary>
        public void Run()
        {
            
          int average = Challenge3(new int[] { 4, 5, 6 });
            Console.WriteLine(average);
            int count = Challenge2("the quick brown fox jumps over the lazy dog");
            Console.WriteLine(count);
            bool isPalindrome = Challenge1("Hello world!");
            Console.WriteLine(isPalindrome);
        }

        /*----------- CHALLENGE #1 START -----------*/

        /// <summary>
        ///
        /// # Challenge 1
        ///
        /// Write a function or method that takes a string as input and determines whether
        /// it is a palindrome or not.A palindrome is a word, phrase, number, or other
        /// sequence of characters that reads the same forward and backward, ignoring spaces,
        /// punctuation, and letter casing.
        ///
        /// Specification:
        /// 1. The function should ignore spaces, punctuation, and letter casing.
        /// 2. The function should return true if the input string is a palindrome and false otherwise.
        /// 3. The function should be case-insensitive, meaning "Racecar" should be considered a palindrome.
        ///
        /// </summary>
        ///
        /// <param name="input">the string to check</param>
        /// <returns>boolean (true if the input string is a palindrome, false otherwise)</returns>
        ///
        /// <example>
        ///
        /// isPalindrome("racecar") => true
        /// isPalindrome("A man, a plan, a canal: Panama") => true
        /// isPalindrome("Hello world!") => false
        /// isPalindrome("12321") => true
        ///
        /// </example>

        // CODE GOES HERE

        public bool Challenge1(string Testpalindrome)
        {
            bool isPalindrome = false;
               foreach (char c in Testpalindrome)
            {
                if (!char.IsLetterOrDigit(c))
                    Testpalindrome= Testpalindrome.Replace(c, ' ');

            }
               Testpalindrome = Testpalindrome.Replace(" ", string.Empty);
               Testpalindrome = Testpalindrome.ToLower();
            char[] characters = Testpalindrome.ToCharArray();
            for (int i = 0; i < Testpalindrome.Length; i++)
            {
                if (characters[i] == characters[characters.Length - 1 - i])
                    isPalindrome = true;
                    
                else
                    isPalindrome = false;
                if (!isPalindrome)
                    break;
            }
            return isPalindrome;
            
        }

        /*------------ CHALLENGE #1 END ------------*/

        /*----------- CHALLENGE #2 START -----------*/

        /// <summary>
        ///
        /// Write a function that takes in a string as input and returns the number of unique words in
        /// the string. A word is defined as a sequence of characters separated by whitespace. You can assume
        /// that the input string does not contain any punctuation marks.
        ///
        /// Specification:
        /// 1. The function should ignore punctuation and letter casing.
        /// 2. The function should return a count of the amount of unique words in the string.
        ///
        /// </summary>
        ///
        /// <param name="input">string to count</param>
        /// <returns>integer (unique word count)</returns>
        ///
        /// <example>
        ///
        /// uniqueWordCount("Hello world!") => 2
        /// uniqueWordCount("the quick brown fox jumps over the lazy dog") => 8
        ///
        /// </example>

        // CODE GOES HERE
        
        public int Challenge2(string sentence)
        {
            int count = 0;
            List<string> ListOfWords = new List<string>();
            sentence= sentence.ToLower();
            foreach (string word in sentence.Split(" "))
            {
                if (!ListOfWords.Contains(word))
                {
                    count++;
                }
                ListOfWords.Add(word);
            }
                
                
            return count;
        }
        
        /*------------ CHALLENGE #2 END ------------*/

        /*----------- CHALLENGE #3 START -----------*/

        /// <summary>
        ///
        /// Write a function that takes in an array of numbers and returns the average value of those numbers.
        ///
        /// Specification:
        /// 1. The array should contain at least three numbers.
        /// 2. The input array can contain positive and/or negative numbers.
        /// 3. The average should be rounded to two decimal places.
        ///
        /// </summary>
        ///
        /// <param name="input">integer array (the numbers to calculate the average of)</param>
        /// <returns>the average of the input numbers rounded to two decimal places</returns>
        ///
        /// <example>
        ///
        /// calculateAverage([1, 2, 3, 4, 5]) => 3.00
        /// calculateAverage([-10, 0, 10]) => 0.00
        ///
        /// </example>

        // CODE GOES HERE
        
        public static int Challenge3(int[] numbers)
        {
            int sum = 0;
            int average; 
            foreach (int number in numbers)
            {
                sum += number;
            }
            average = sum / numbers.Length;
            return average;
        }

        /*------------ CHALLENGE #3 END ------------*/

        #region other methods

        public void Dispose()
        {

            // Dispose of things here

        }

        #endregion

    }

}
