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
            int count = Challenge2("Hello There");
            Console.WriteLine(count);
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

        public void Challenge1()
        {
               
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
            
            sentence= sentence.ToLower();
            string[] words = sentence.Split(' ');
            for(int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (words[j] != words[i])
                        count++;
                }
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
