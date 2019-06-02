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
                            _piecesToPlay.Add(new QuartoPiece(isTall, hasHole, isDark, isRounded));
                        }
                    }
                }
            }

        }


        public bool PlayPiece(int x, int y)
        {
            
            if(x <= _maxX && y <= _maxY && _board[x,y] == null)
            {
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

        public bool CheckIfWon()
        {
            //Check Horizontal
            for(int i= 0; i < 4; i++)
            {

            }
            //Check Vertical
            for (int i = 0; i < 4; i++)
            {

            }
            //Check diagonal
        }
    }
}
