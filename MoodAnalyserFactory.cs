using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyserApp
{
    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalysis(string className, string constructName)
        {
            string pattern = @"." + constructName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyserType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyserExceptions(MoodAnalyserExceptions.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }
            }
            else
            {
                throw new MoodAnalyserExceptions(MoodAnalyserExceptions.ExceptionType.NO_SUCH_METHOD, "Constructor not found");

            }
        }
        public static object CreateMoodAnalyserUsingParametricConstructor(string className, string constructName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if(type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyserExceptions(MoodAnalyserExceptions.ExceptionType.NO_SUCH_METHOD, "Constructor Not Found");
                }
            }
            else
            {
                throw new MoodAnalyserExceptions(MoodAnalyserExceptions.ExceptionType.NO_SUCH_METHOD, "Class not found");
            }

        }
    }
}
