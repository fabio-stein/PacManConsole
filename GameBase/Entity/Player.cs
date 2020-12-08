using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase
{
    public class Player : EntityBase
    {
        public override string name { get; set; } = "Player";
        public override char character { get; set; } = Constant.PlayerChar;

        public override void Start(Scene scene, int x, int y)
        {
            base.Start(scene, x, y);
            pixel.BackgroundColor = ConsoleColor.DarkYellow;
        }

        public override void Update()
        {
            var direction = GetInputs().Direction;
            var destX = x;
            var destY = y;
            if (direction == Direction.RIGHT)
                destX++;
            else if (direction == Direction.LEFT)
                destX--;
            else if (direction == Direction.UP)
                destY--;
            else if (direction == Direction.DOWN)
                destY++;

            var destEntity = GetEntityInDirection(direction, 1);

            if (destEntity.entityType != EntityType.SCORE && destEntity.entityType != EntityType.SPACE)
                return;

            if (destEntity.entityType == EntityType.SCORE)
                destEntity.Destroy();

            if (destX != x || destY != y)
                Move(destX, destY);
        }
    }
}
