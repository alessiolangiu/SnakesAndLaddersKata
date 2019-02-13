namespace SnakesAndLadders
{
    using System.Collections.Generic;
    using System.Linq;

    public class Board
    {
        private readonly Dictionary<string, int> _players=new Dictionary<string, int>();
        private const int InitialPosition = 1;
        private const int WinningPosition = 100;
        private readonly IDice _dice;

        public Board(IDice dice)
        {
            _dice = dice;
        }

        public void StartGame()
        {
            List<string> playersNames = _players.Keys.ToList();
            foreach (var playerName in playersNames)
            {
                _players[playerName]=InitialPosition;
            }
        }

        public void AddPlayer(string playerName)
        {
            _players.Add(playerName, InitialPosition);
        }

        public int GetPlayerPosition(string playerName)
        {
            return _players[playerName];
        }

        public void MovePlayer(string playerName, int numberOfSpacesToMove)
        {
            int currentPlayerPosition = _players[playerName];
            if (currentPlayerPosition + numberOfSpacesToMove <= WinningPosition)
            {
                _players[playerName]= currentPlayerPosition + numberOfSpacesToMove;
            }
        }

        public PlayerStatus RollDice(string playerName)
        {
            var score = _dice.RollDice();
            MovePlayer(playerName, score);
            return GetPlayerStatus(playerName);
        }

        private PlayerStatus GetPlayerStatus(string playerName)
        {
            var position = _players[playerName];
            return position == WinningPosition ? PlayerStatus.Winner : PlayerStatus.InGame;
        }

        public enum PlayerStatus
        {
            InGame=0,
            Winner=1
        }
    }
}