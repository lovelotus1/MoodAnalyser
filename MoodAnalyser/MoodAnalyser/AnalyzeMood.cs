using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    public class AnalyzeMood
    {
        //variable
        public string message;
        /// <summary>
        /// parameterized constructor
        /// </summary>
        /// <param name="message"></param>
        public AnalyzeMood(string message)
        {
            this.message = message;
        }
        /// <summary>
        /// default Constructor
        /// </summary>
        public AnalyzeMood()
        {
        }
        //uc1
        /// <summary>
        /// Method to return the type of Mood
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string Mood(string message)
        {
            if (message.ToLower().Contains("happy"))
            {
                return "happy";
            }
            else
            {
                return "sad";
            }
        }
        //UC1_Refactored
        //UC2
        ///exception handeled for
        ///passing null value returnd happy
        ///Method to return the type of Mood
        /// <summary>
        /// refactored Mood
        /// metod overloading
        /// </summary>
        /// <returns></returns>
        public string Mood()
        {
            try
            {
                if (message.ToLower().Contains("happy"))
                {
                    return "happy";
                }
                else if (message.Equals(string.Empty))
                {
                    throw new MoodAnalyserCustomException(ExceptionType.EMPTY_EXCEPTION, "Message can't be Empty");
                }
                else
                {
                    return "sad";
                }
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(ExceptionType.NULL_EXCEPTION, "Message can't be Null");
                // Console.WriteLine(exception.Message);
                // return "happy";  
            }

        }
    }

    [Serializable]
    public class MoodAnalyserCustomException : Exception
    {
        //enum ExceptionType;
        public ExceptionType type;
        public MoodAnalyserCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
