namespace LeetCodeMinimumMovesToCaptureTheQueen
{
    // With thanks to https://lichess.org/editor which let me visualise the pieces on the board
    // in order to sanity check the algorithm
    public class Solution
    {
        private int _rookY;
        private int _rookX;
        private int _bishopY;
        private int _bishopX;
        private int _queenY;
        private int _queenX;


        public int MinMovesToCaptureTheQueen(int a, int b, int c, int d, int e, int f)
        {
            _rookX = b;
            _rookY = a;

            _bishopX = d;
            _bishopY = c;

            _queenX = f;
            _queenY = e;

            var rookMoves = RookMoves();
            if (rookMoves == 1)
                return 1; // Never going to beat a score of 1, don't bother checking bishop

            var bishopMoves = BishopMoves();
            return Math.Min(rookMoves, bishopMoves);

            return 0;
        }



        private int RookMoves()
        {
            // Is the rook on the same horizontal column as the queen?
            if (_rookX == _queenX)
            {
                if (_rookX == _bishopX)
                {
                    // Is the bishop in the way of the rook and the queen?
                    // If so, it'll take 2 moves - 1 to move the bishop out the way
                    // and the other to move the rook to capture the queen
                    if (_rookY > _bishopY && _bishopY> _queenY)
                    {
                        return 2;
                    }

                    if (_rookY < _bishopY && _bishopY < _queenY)
                    {
                        return 2;
                    }
                }

                return 1;
            }

            // Is the rook on the same vertical column as the queen?
            if (_rookY == _queenY)
            {
                if (_rookY == _bishopY)
                {
                    if (_rookX > _bishopX && _bishopX>_queenX)
                    {
                        return 2;
                    }

                    if (_rookX < _bishopX && _bishopX <_queenX)
                    {
                        return 2;
                    }
                }

                return 1;
            }

            // Rook on different column and row to queen, so will be 2 moves to get there
            return 2;

        }


        private int BishopMoves()
        {
            if (!AreSquaresSameColour(_bishopX, _bishopY, _queenX, _queenY))
                return int.MaxValue;

            
            if (IsRookBlockingViewOfQueenForBishop())
            {
                return 3; // At least 3 moves to get to Queen - and the rook can get there faster
            }

            if (IsSquareDiagonalToBishop(_queenX,_queenY))
            {
                return 1;
            }

            return 2; // Rook can get there fastest

        }

        private bool AreSquaresSameColour(int square1X, int square1Y, int square2X, int square2Y)
        {
            var isSquare1White = IsWhiteSquare(square1X, square1Y);
            var isSquare2White = IsWhiteSquare(square2X, square2Y);
            return isSquare1White == isSquare2White;
        }


        // X and Y are both 1..8. Y is the row number
        private bool IsWhiteSquare(int x, int y)
        {
            // Odd numbered rows start with white square, so an odd numbered column is white
            if (y % 2 == 1)
            {
                return x % 2 == 1;
            }

            // Even numbered rows start with black square, so an even numbered column is white
            return x % 2 == 0;
        }


        
        private bool IsSquareDiagonalToBishop(int newX, int newY)
        {
            int dx = Math.Abs(newX - _bishopX);
            int dy = Math.Abs(newY - _bishopY);

            if (dx != dy)
                return false;

            return true;
        }


        private bool IsRookBlockingViewOfQueenForBishop()
        {
            // If rook is diagonal to bishop, rookDistX and rookDistY will be same
            int rookDistX = Math.Abs(_bishopX - _rookX);
            int rookDistY = Math.Abs(_bishopY - _rookY);
            if (rookDistX != rookDistY)
                return false; // Rook not on a square that can be moved to by bishop

            // If queen is diagonal to bishop, queenDistX and queenDistY will be same
            int queenDistX = Math.Abs(_bishopX - _queenX);
            int queenDistY = Math.Abs(_bishopY - _queenY);
            if (queenDistX != queenDistY)
                return false; // Queen not on a square that can be moved to by bishop

            // Check to see if the rook and queen are collinear
            var rookSignX = _bishopX - _rookX > 0 ? 1 : 0;
            var rookSignY = _bishopY - _rookY > 0 ? 1 : 0;

            var queenSignX = _bishopX - _queenX > 0 ? 1 : 0;
            var queenSignY = _bishopY - _queenY > 0 ? 1 : 0;

            return (rookSignX == queenSignX && rookSignY == queenSignY && rookDistX < queenDistX);
        }
    }
}
