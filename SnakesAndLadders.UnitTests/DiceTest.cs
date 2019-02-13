namespace SnakesAndLadders.UnitTests
{
    using FluentAssertions;
    using Xunit;

    public class DiceTest
    {
        private readonly Dice _sut = new Dice();
        [Fact]
        public void RollDice_ShouldReturnAScoreBetweenOneAndSix()
        {
            for (int counter = 0; counter < 100000; counter++)
            {
                var result = _sut.RollDice();
                result.Should().BeGreaterOrEqualTo(1);
                result.Should().BeLessOrEqualTo(6);
            }
        }
    }
}
