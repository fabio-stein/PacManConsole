using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase
{
    public class Ghost : EntityBase
    {
        public override string name { get; set; } = "Ghost";
        public override char character { get; set; } = Constant.GhostChar;
        private Direction previousPosition = Direction.NONE;
        private int viewDistance = 5;

        public override void Start(Scene scene, int x, int y)
        {
            base.Start(scene, x, y);
            pixel.BackgroundColor = ConsoleColor.Magenta;
        }

        public override void Update()
        {
            var nextDirection = GetNextDirection();

            switch (nextDirection)
            {
                case Direction.UP:
                    previousPosition = Direction.DOWN;
                    break;
                case Direction.DOWN:
                    previousPosition = Direction.UP;
                    break;
                case Direction.LEFT:
                    previousPosition = Direction.RIGHT;
                    break;
                case Direction.RIGHT:
                    previousPosition = Direction.LEFT;
                    break;
                default:
                    previousPosition = Direction.NONE;
                    break;
            }

            var destX = x;
            var destY = y;
            if (nextDirection == Direction.UP)
                destY--;
            else if (nextDirection == Direction.DOWN)
                destY++;
            else if (nextDirection == Direction.LEFT)
                destX--;
            else if (nextDirection == Direction.RIGHT)
                destX++;

            var destEntity = GetEntityInDirection(nextDirection, 1);
            if (destEntity.entityType == EntityType.PLAYER)
                Environment.Exit(0);

            if (destX != x || destY != y)
                Move(destX, destY);
        }

        private Direction GetNextDirection()
        {
            var directions = new List<DirectionInfo>()
            {
                GetDirectionInfo(Direction.UP),
                GetDirectionInfo(Direction.DOWN),
                GetDirectionInfo(Direction.LEFT),
                GetDirectionInfo(Direction.RIGHT)
            };
            directions.RemoveAll(d => !d.IsAvailable);

            var playerDirection = directions.Find(d => d.IsPlayerVisible);
            if (playerDirection != null)
                return playerDirection.Direction;

            if (directions.Count > 1)
                directions.RemoveAll(d => d.Direction == previousPosition);

            if (directions.Count == 0)
                return Direction.NONE;

            return directions[random.Next(0, directions.Count)].Direction;
        }

        private DirectionInfo GetDirectionInfo(Direction direction)
        {
            var info = new DirectionInfo()
            {
                Direction = direction,
                IsAvailable = false,
                IsPlayerVisible = false
            };

            for (int i = 1; i <= viewDistance; i++)
            {
                var entity = GetEntityInDirection(direction, i);
                if (entity == null)
                    break;

                if (entity.entityType == EntityType.WALL || entity.entityType == EntityType.GHOST)
                {
                    break;
                }

                if (entity.entityType == EntityType.PLAYER)
                {
                    info.IsPlayerVisible = true;
                }

                info.IsAvailable = true;
            }

            return info;
        }

        private class DirectionInfo
        {
            public Direction Direction { get; set; }
            public bool IsPlayerVisible { get; set; }
            public bool IsAvailable { get; set; }
        }
    }
}
