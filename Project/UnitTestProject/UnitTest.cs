using Droid_scheduler;
using NUnit.Framework;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void TestUTRuns()
        {
            Assert.IsTrue(true);
        }
        [Test]
        public void TestUTCreateHolidays()
        {
            try
            {
                Holiday obj = new Holiday();
                Assert.IsTrue(obj != null);
            }
            catch (System.Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }
        [Test]
        public void TestUTCreateHolidaysCalculator()
        {
            try
            {
                HolidayCalculator obj = new HolidayCalculator();
                Assert.IsTrue(obj != null);
            }
            catch (System.Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }
        [Test]
        public void TestUTCreateCalendarConvert()
        {
            try
            {
                CalendarConvert obj = new CalendarConvert();
                Assert.IsTrue(obj != null);
            }
            catch (System.Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }
        [Test]
        public void TestUTCreateScheduler()
        {
            try
            {
                Scheduler obj = new Scheduler();
                Assert.IsTrue(obj != null);
            }
            catch (System.Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }
    }
}
