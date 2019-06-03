using System;
using System.Collections.Generic;
using System.Text;

namespace QuartoLogic
{
    public class QuartoBoard
    {
        private const int _maxX = 4;
        private const int _maxY = 4;        
        private QuartoPiece[,] _board;
        private List<QuartoPiece> _piecesToPlay;
        private QuartoPiece _selectedPeice;

        public QuartoBoard()
        {

        }

        public void SetBoard()
        {
            _board = new QuartoPiece[_maxX, _maxY];
            _piecesToPlay = new List<QuartoPiece>();


            foreach (var isRounded in new[] { true, false })
            {
                foreach (var isDark in new[] { true, false })
                {

                    foreach (var hasHole in new[] { true, false })
                    {
                        foreach (var isTall in new[] { true, false })
                        {
                            _piecesToPlay.Add(new QuartoPiece( new bool[] { isTall, hasHole, isDark, isRounded }));
                        }
                    }
                }
            }

        }


        public bool PlayPiece(int x, int y)
        {
            
            if(x <= _maxX && y <= _maxY && _board[x,y] == null)
            {
                _selectedPeice.PlayedX = x;
                _selectedPeice.PlayedY = y;
                _board[x, y] = _selectedPeice;
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool PickAPiece(QuartoPiece chosenPiece)
        {
            if (chosenPiece == null || !_piecesToPlay.Contains(chosenPiece))
            {
                return false;
            }
            else
            {
                _selectedPeice = chosenPiece;
                return true;
            }
        }

        public Dictionary<int,int> CheckIfWon()
        {
            bool win = false;
            var winLineList = new Dictionary<int,int>();
            for(int j =0; j < _selectedPeice.Matching.Length; j++)
            {
                //Check Horizontal
                win = true;
                winLineList = new Dictionary<int,int>();
                for (int i = 0; i < _maxX; i++)
                {
                    if(_board[i, _selectedPeice.PlayedY] == null || _board[i, _selectedPeice.PlayedY].Matching[j] != _selectedPeice.Matching[j])
                    {
                        win = false;
                        break;
                    }
                    winLineList.Add(i, _selectedPeice.PlayedY);
                }
                if (win) return winLineList;
                //Check Vertical
                win = true;
                winLineList = new Dictionary<int,int>();
                for (int i = 0; i < _maxY; i++)
                {
                    if (_board[_selectedPeice.PlayedX, i] == null || _board[_selectedPeice.PlayedX, i].Matching[j] != _selectedPeice.Matching[j])
                    {
                        win = false;
                        break;
                    }
                    winLineList.Add(_selectedPeice.PlayedX, i);
                }
                if (win) return winLineList;
                //Check Top right diagonal
                win = true;
                winLineList = new Dictionary<int,int>();
                for (int i = 0; i < _maxX; i++)
                {
                    if (_board[_selectedPeice.PlayedY, i] == null || _board[i, i].Matching[j] != _selectedPeice.Matching[j])
                    {
                        win = false;
                        break;
                    }
                    winLineList.Add( i, i);
                }
                if (win) return winLineList;
                //Check Bottom right diagonal
                win = true;
                winLineList = new Dictionary<int,int>();
                for (int i = 0; i < _maxX; i++)
                {
                    if (_board[_selectedPeice.PlayedY, i] == null || _board[3-i, 3-i].Matching[j] != _selectedPeice.Matching[j])
                    {

                        win = false;
                        break;
                    }
                    winLineList.Add(3 - i, 3 - i);
                }
                if (win) return winLineList;

            }

            return new Dictionary<int,int>();
        }
    }
}
