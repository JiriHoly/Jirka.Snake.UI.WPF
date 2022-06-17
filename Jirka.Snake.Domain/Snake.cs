namespace Jirka.Snake.Logic
{
    public class Snake
    {
        private Queue<Point> Points { get; set; }
        private Enums.Direction previousDirection;

        public Snake(Point point)
        {
            Points = new Queue<Point>();
            point.Status = Enums.PointStatus.Snake;
            Points.Enqueue(point);
            previousDirection = Enums.Direction.Left;
        }
        /// <summary>
        /// Move snake for one point
        /// </summary>
        /// <param name="point">Point where to move</param>
        /// <param name="direction">Direction of move</param>
        /// <returns>True if new point is a food</returns>
        public bool Move(Point point, Enums.Direction direction)
        {
            bool isFood = (point.Status == Enums.PointStatus.Food);

            switch (point.Status)
            {
                case Enums.PointStatus.Barrier:
                    throw new Exception();
                case Enums.PointStatus.Snake:
                    throw new Exception();

            }

            
            if (!isFood)
            {
                Points.Dequeue().Status = Enums.PointStatus.Empty;
            }

            point.Status = Enums.PointStatus.Snake;
            Points.Enqueue(point);
            previousDirection = direction;
            return isFood;
        }

        public bool IsValisDirection(Enums.Direction direction)
        {
            if (direction == Enums.Direction.Null)
                return false;
            return (int)direction != ((int)previousDirection * (-1));
        }

        public Point GetHead()
        {
            return Points.Last();
        }
    }
}