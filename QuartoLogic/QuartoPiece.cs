using System;
using System.Collections.Generic;
using System.Text;

namespace QuartoLogic
{
    public class QuartoPiece
    {
        private readonly bool[] _matchingTraits;


        public QuartoPiece(bool[] matchingTraits)
        {
            _matchingTraits = matchingTraits;
        }

        public bool[] Matching => _matchingTraits;

        public int PlayedX { get; set; }

        public int PlayedY { get; set; }
    }
}
