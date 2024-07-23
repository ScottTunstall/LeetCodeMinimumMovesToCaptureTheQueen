namespace LeetCodeMinimumMovesToCaptureTheQueen
{
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
            _rookY = a;
            _rookX = b;

            _bishopY = c;
            _bishopX = d;

            _queenY = e;
            _queenX = f;

            var rookMoves = RookMoves();
            if (rookMoves == 1)
                return 1; // Never going to beat a score of 1

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
                    if (_rookY > _bishopY && _bishopY> _queenY)
                    {
                        return 3;
                    }

                    if (_rookY < _bishopY && _bishopY < _queenY)
                    {
                        return 3;
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
                        return 3;
                    }

                    if (_rookX < _bishopX && _bishopX <_queenX)
                    {
                        return 3;
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

            
            if (IsRookInTheWayOfBishop(_bishopX, _bishopY))
            {
                return 3; // At least 3 moves to get to Queen - and the rook can get there faster
            }

            if (IsSquareReachableByBishopInSingleMove(_bishopX,_bishopY,_queenX,_queenY))
            {
                return 1;
            }

            return 2; // Rook can get there fastest

        }

        private bool AreSquaresSameColour(int square1X, int square1Y, int square2X, int square2Y)
        {
            var x1 = (square1X - 1) % 2;
            var y1 = (square1Y - 1) % 2;

            var isSquare1White = x1 == 1 && y1 == 1;
            
            var x2 = (square2X - 1) % 2;
            var y2 = (square2Y - 1) % 2;

            var isSquare2White = x1 == 1 && y1 == 1;

            return isSquare1White == isSquare2White;
        }

        
        private bool IsSquareReachableByBishopInSingleMove(int currentX, int currentY, int newX, int newY)
        {
            int dx = Math.Abs(newX - currentX);
            int dy = Math.Abs(newY - currentY);

            if (dx != dy)
                return false;

            return true;
        }


        private bool IsRookInTheWayOfBishop(int currentX, int currentY)
        {
            if (_rookX == _queenX && _rookY == _queenY)
                return true;

            int dx, dy;
            if (_queenX < currentX)
                dx = -1;
            else
                dx = 1;

            if (_queenY < currentY)
                dy = -1;
            else
                dy = 1;

            var x = currentX;
            var y = currentY;

            for (;;)
            {
                // Let's check if we bump into the queen before the rook
                if (x == _queenX && y == _queenY)
                    return false; // No, bishop is not in way of queen

                if (x == _rookX && y == _rookY)
                    return true; // Yes, bishop is in the way of the queen

                x += dx;
                y += dy;

                // are we off the board?
                if (x == 0 || x == 9)
                    return false;

                if (y == 0 || y == 9)
                    return false;
            }
        }
    }
}
