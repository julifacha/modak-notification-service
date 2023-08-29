using Models;

namespace Test.Models
{
    public class NotificationRuleTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(50)]
        public void Test_Get_Interval_Minutes(int intervalValue)
        {
            // arrange
            NotificationRule rule = NotificationRule.Create(NotificationTypeEnum.News, IntervalEnum.Minute, intervalValue, 1);

            // act
            (DateTime intervalStart, DateTime intervalEnd) = rule.GetInterval();

            // assert
            Assert.Equal(intervalStart, DateTime.Now.Add(-TimeSpan.FromMinutes(rule.IntervalValue)), TimeSpan.FromSeconds(1));
            Assert.Equal(intervalEnd, DateTime.Now, TimeSpan.FromSeconds(1));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(50)]
        public void Test_Get_Interval_Hours(int intervalValue)
        {
            // arrange
            NotificationRule rule = NotificationRule.Create(NotificationTypeEnum.News, IntervalEnum.Hour, intervalValue, 1);

            // act
            (DateTime intervalStart, DateTime intervalEnd) = rule.GetInterval();

            // assert
            Assert.Equal(intervalStart, DateTime.Now.Add(-TimeSpan.FromHours(rule.IntervalValue)), TimeSpan.FromSeconds(1));
            Assert.Equal(intervalEnd, DateTime.Now, TimeSpan.FromSeconds(1));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(50)]
        public void Test_Get_Interval_Days(int intervalValue)
        {
            // arrange
            NotificationRule rule = NotificationRule.Create(NotificationTypeEnum.News, IntervalEnum.Day, intervalValue, 1);

            // act
            (DateTime intervalStart, DateTime intervalEnd) = rule.GetInterval();

            // assert
            Assert.Equal(intervalStart, DateTime.Now.Add(-TimeSpan.FromDays(rule.IntervalValue)), TimeSpan.FromSeconds(1));
            Assert.Equal(intervalEnd, DateTime.Now, TimeSpan.FromSeconds(1));
        }
    }
}
