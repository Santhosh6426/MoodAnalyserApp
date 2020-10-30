using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserApp
{
    public class MoodAnalyser
    {
        private string message;
        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyser"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public MoodAnalyser(string message) 
        {
            this.message = message;
        }
        /// <summary>
        /// paramterized constructer. Analyses the mood.
        /// With handling Exceptions.
        /// </summary>
        /// <returns></returns>
        public string AnalyseMood()
        {
            try
            {
                if(this.message.Equals(string.Empty))
                {
                    throw new MoodAnalyserExceptions(MoodAnalyserExceptions.ExceptionType.EMPTY_MESSAGE, "Mood should not be empty");

                }
                if (this.message.Contains("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserExceptions(MoodAnalyserExceptions.ExceptionType.NULL_MESSAGE, "Mood should not be Null");
            }
        }
    }
}
