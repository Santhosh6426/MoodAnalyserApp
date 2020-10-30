using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserApp;

namespace MoodAnalyserAppTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Givens the sad mood should return sad.
        /// </summary>
        [TestMethod]
        public void GivenSadMoodShudReturnSad()
        {
            ///Arrange
            string expected = "SAD";
            string message = "I'm in a sad mood";
            MoodAnalyser moodAnalyse = new MoodAnalyser(message);

            string mood = moodAnalyse.AnalyseMood();
            Assert.AreEqual(expected, mood);
        }        
        [TestMethod]
        /// <summary>
        /// Givens the happy mood shud return happy.
        /// </summary>
        /// <param name="message">The message.</param>
        /// [DataRow("I am in happy mood")]
        [DataRow(null)]
        public void GivenHappyMoodShudReturnHappy(string message)
        {
            ///Arrange
            string expected = "HAPPY";

            MoodAnalyser moodAnalyse = new MoodAnalyser(message);
            string mood = moodAnalyse.AnalyseMood();
            ///Assert.
            Assert.AreEqual(expected, mood);
        }
        /// <summary>
        /// Givens the empty mood should throw mood analysis exception indicating empty mood.
        /// </summary>
        [TestMethod]
        public void Given_Empty_Mood_Should_Throw_MoodAnalysisException_Indicating_EmptyMood()
        {
            try
            {
                ///Arrange
                string message = "";
                MoodAnalyser moodAnalyse = new MoodAnalyser(message);
                string mood = moodAnalyse.AnalyseMood();
            }
            catch (MoodAnalyserExceptions e)
            {
                Assert.AreEqual("Mood should not be empty", e.Message);
            }
        }
        /// <summary>
        /// Givens the null mood should throw mood analysis exception.
        /// </summary>
        [TestMethod]
        public void Given_Null_Mood_Should_Throw_MoodAnalysisException()
        {
            try
            {
                ///Arrange
                string message = null;
                MoodAnalyser moodAnalyse = new MoodAnalyser(message);
                string mood = moodAnalyse.AnalyseMood();
            }
            catch (MoodAnalyserExceptions e)
            {
                ///Assert
                Assert.AreEqual("Mood should not be Null", e.Message);
            }
        }
    }
}
