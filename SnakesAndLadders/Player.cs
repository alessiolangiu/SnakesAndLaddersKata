namespace SnakesAndLadders
{
    internal class Player
    {
        private int _currentPosition;

        public Player()
        {
        }

        public void SetPosition(int position)
        {
            _currentPosition = position;
        }

        public int GetPosition()
        {
            return _currentPosition;
        }
    }
}