using System;
using System.Collections.Generic;
using System.Text;

namespace Numatic.Apps.CodingChallenges
{

    /// <summary>
    /// Contains extensions for strings
    /// </summary>
    public static class StringExtensions
    {

        /// <summary>
        /// Transforms a string to Pascal Case e.g. someString => SomeString
        /// </summary>
        /// <param name="@this">The value to transform</param>
        /// <returns>The transformed value</returns>
        public static string ToPascalCase(this string @this)
        {

            if (@this == null)
            {

                return @this;

            }

            if (@this.Length < 2)
            {

                return @this.ToUpper();

            }

            string[] words = @this.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

            string result = "";

            foreach (string word in words)
            {

                result += word.Substring(0, 1).ToUpper() + word.Substring(1);

            }

            return result;

        }

        /// <summary>
        /// Transforms a string to Camel Case e.g. SomeString => someString
        /// </summary>
        /// <param name="@this">The value to transform</param>
        /// <returns>The transformed value</returns>
        public static string ToCamelCase(this string @this)
        {

            if (@this == null || @this.Length < 2)
            {

                return @this;

            }

            string[] words = @this.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

            string result = words[0].ToLower();

            for (int i = 1; i < words.Length; i++)
            {

                result += words[i].Substring(0, 1).ToUpper() + words[i].Substring(1);

            }

            return result;

        }

        /// <summary>
        /// Transforms a string to Lisp Case e.g. SomeString => some-string
        /// </summary>
        /// <param name="@this">The value to transform</param>
        /// <returns>The transformed value</returns>
        public static string ToLispCase(this string @this)
        {

            return ToSeperatedCase(@this, "-");

        }

        /// <summary>
        /// Transforms a string to Snake Case e.g. SomeString => some_string
        /// </summary>
        /// <param name="@this">The value to transform</param>
        /// <returns>The transformed value</returns>
        public static string ToSnakeCase(this string @this)
        {

            return ToSeperatedCase(@this, "_");

        }

        /// <summary>
        /// Transforms a string to a string with a seperator
        /// </summary>
        /// <param name="value">The value to transform</param>
        /// <param name="seperator">The seperator to use</param>
        /// <returns>The transformed value</returns>
        private static string ToSeperatedCase(string value, string seperator)
        {

            if (value == null)
            {

                return value;

            }

            if (value.Length < 2)
            {

                return value.ToUpper();

            }

            string result = value.Substring(0, 1).ToUpper();

            for (int i = 1; i < value.Length; i++)
            {

                if (char.IsUpper(value[i]))
                {

                    result += seperator;

                }

                result += value[i];

            }

            return result.ToLower();

        }

    }

}

