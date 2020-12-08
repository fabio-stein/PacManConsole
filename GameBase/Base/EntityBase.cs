using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase
{
    public abstract class EntityBase
    {
        public int x { get; private set; }
        public int y { get; private set; }
        private Scene scene;
        public bool smoothRender = false;
        public Pixel pixel { get; private set; } = new Pixel()
        {
            BackgroundColor = ConsoleColor.Black,
            ForegroundColor = ConsoleColor.Gray
        };
        public bool isDestroyed { get; private set; } = false;
        public LinkedList<EntityBase>[,] gridView { get => (LinkedList<EntityBase>[,])scene.grid.Clone(); }
        public EntityType entityType { get => GetEntityByChar(character); }

        public Random random { get => Util.Random; }

        public abstract string name { get; set; }
        public abstract char character { get; set; }

        public virtual void Start(Scene scene, int x, int y)
        {
            this.scene = scene;
            this.x = x;
            this.y = y;
        }

        public abstract void Update();

        public void Move(int x, int y)
        {
            scene.grid[this.y, this.x].RemoveFirst();
            scene.grid[y, x].AddFirst(this);
            this.x = x;
            this.y = y;
        }

        public void Destroy()
        {
            isDestroyed = true;
            scene.DestroyEntity(this);
        }

        public EntityType GetEntityByChar(char c)
        {
            switch (c)
            {
                case Constant.PlayerChar:
                    return EntityType.PLAYER;
                case Constant.GhostChar:
                    return EntityType.GHOST;
                case Constant.FruitChar:
                    return EntityType.FRUIT;
                case Constant.WallChar:
                    return EntityType.WALL;
                case Constant.ScoreChar:
                    return EntityType.SCORE;
                case Constant.SpaceChar:
                    return EntityType.SPACE;
                default:
                    return EntityType.NONE;
            }
        }

        public InputStatus GetInputs()
        {
            return scene.input.GetInput();
        }

        public EntityBase GetEntityInDirection(Direction direction, int distance)
        {
            var destX = x;
            var destY = y;
            switch (direction)
            {
                case Direction.LEFT:
                    destX -= distance;
                    break;
                case Direction.RIGHT:
                    destX += distance;
                    break;
                case Direction.UP:
                    destY -= distance;
                    break;
                case Direction.DOWN:
                    destY += distance;
                    break;
            }

            //Out of range
            if (destY < 0 || destX < 0 || destY >= scene.ySize || destY >= scene.xSize)
                return null;

            return gridView[destY, destX].First.Value;
        }
    }
}
