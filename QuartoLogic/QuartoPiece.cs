using System;
using System.Collections.Generic;
using System.Text;

namespace QuartoLogic
{
    public class QuartoPiece
    {
        private readonly bool _tall;
        private readonly bool _holed;
        private readonly bool _dark;
        private readonly bool _rounded;

        public QuartoPiece(bool tall, bool holed, bool dark, bool rounded)
        {
            _tall = tall;
            _holed = holed;
            _dark = dark;
            _rounded = rounded;
        }

        public bool Rounded => _rounded;

        public bool Dark => _dark;

        public bool Holed => _holed;

        public bool Tall => _tall;
    }
}
