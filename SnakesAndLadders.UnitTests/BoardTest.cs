namespace SnakesAndLadders.UnitTests
{
    using FluentAssertions;
    using Moq;
    using Xunit;

    public class BoardTest
    {
        private readonly Board _sut;
        private const string PlayerOneName = "Player One Name";
        private const string PlayerTwoName = "Player Two Name";
        private const int InitialPosition = 1;

        private readonly Mock<IDice> _dice = new Mock<IDice>();

        public BoardTest()
        {
            _sut=new Board(_dice.Object);
        }

        [Fact]
        public void StartGame_ShouldResetPlayersPlaceholders()
        {
            //Arrange
            _sut.AddPlayer(PlayerOneName);
            _sut.AddPlayer(PlayerTwoName);
            
            //Act
            _sut.StartGame();
            
            //Assert
            _sut.GetPlayerPosition(PlayerOneName).Should().Be(InitialPosition);
            _sut.GetPlayerPosition(PlayerTwoName).Should().Be(InitialPosition);
        }

        [Fact]
        public void MovePlayer_ShouldMoveToTheRightPositon()
        {
            //Arrange
            _sut.AddPlayer(PlayerOneName);
            _sut.AddPlayer(PlayerTwoName);
            _sut.StartGame();

            //Act
            const int numberOfSpacesToMove = 3;
            const int expectedPosition = 4;
            _sut.MovePlayer(PlayerOneName, numberOfSpacesToMove);

            //Assert
            _sut.GetPlayerPosition(PlayerOneName).Should().Be(expectedPosition);
            _sut.GetPlayerPosition(PlayerTwoName).Should().Be(InitialPosition);

        }


        [Fact]
        public void MovePlayer_TwoMovesShouldMoveToTheRightPositon()
        {
            //Arrange
            _sut.AddPlayer(PlayerOneName);
            _sut.AddPlayer(PlayerTwoName);
            _sut.StartGame();
            const int numberOfSpacesToMoveInitially = 3;
            _sut.MovePlayer(PlayerOneName, numberOfSpacesToMoveInitially);

            //Act
            const int numberOfSpacesToMove = 4;
            const int expectedPosition = 8;
            _sut.MovePlayer(PlayerOneName, numberOfSpacesToMove);

            //Assert
            _sut.GetPlayerPosition(PlayerOneName).Should().Be(expectedPosition);
            _sut.GetPlayerPosition(PlayerTwoName).Should().Be(InitialPosition);

        }

        [Fact]
        public void RollDice_ShouldMovePlayerToTheRightPosition()
        {
            //Arrange
            const int diceResult = 4;
            _dice.Setup(m => m.RollDice()).Returns(diceResult);
            _sut.AddPlayer(PlayerOneName);
            _sut.AddPlayer(PlayerTwoName);
            _sut.StartGame();

            //Act
            _sut.RollDice(PlayerOneName);

            //Assert
            const int expectedPosition = 5;
            _sut.GetPlayerPosition(PlayerOneName).Should().Be(expectedPosition);
            _sut.GetPlayerPosition(PlayerTwoName).Should().Be(InitialPosition);

        }

        [Fact]
        public void RollDice_ShouldReturnInGameIfPlayersPlaceHolderIsNotAtWinningPosition()
        {
            const int diceResult = 4;
            _dice.Setup(m => m.RollDice()).Returns(diceResult);
            _sut.AddPlayer(PlayerOneName);
            _sut.AddPlayer(PlayerTwoName);
            _sut.StartGame();
            _sut.MovePlayer(PlayerOneName, 96);

            //Act
            Board.PlayerStatus result=_sut.RollDice(PlayerOneName);

            //Assert
            const int expectedPosition = 97;
            _sut.GetPlayerPosition(PlayerOneName).Should().Be(expectedPosition);
            result.Should().Be(Board.PlayerStatus.InGame);
            _sut.GetPlayerPosition(PlayerTwoName).Should().Be(InitialPosition);

        }

        [Fact]
        public void RollDice_ShouldReturnWinnerIfPlayersPlaceHolderIsAtWinningPosition()
        {
            const int diceResult = 3;
            _dice.Setup(m => m.RollDice()).Returns(diceResult);
            _sut.AddPlayer(PlayerOneName);
            _sut.AddPlayer(PlayerTwoName);
            _sut.StartGame();
            _sut.MovePlayer(PlayerOneName, 96);

            //Act
            Board.PlayerStatus result = _sut.RollDice(PlayerOneName);

            //Assert
            const int expectedPosition = 100;
            _sut.GetPlayerPosition(PlayerOneName).Should().Be(expectedPosition);
            result.Should().Be(Board.PlayerStatus.Winner);
            _sut.GetPlayerPosition(PlayerTwoName).Should().Be(InitialPosition);

        }
    }
}
