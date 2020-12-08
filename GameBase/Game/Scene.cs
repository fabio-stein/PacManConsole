using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase
{
    public class Scene
    {
        public LinkedList<EntityBase>[,] grid;
        public int xSize;
        public int ySize;
        public Renderer renderer;
        public Input input;


        public Scene(int x, int y)
        {
            grid = new LinkedList<EntityBase>[y, x];
            xSize = x;
            ySize = y;

            renderer = new Renderer(x, y);
            input = new Input();
        }

        public void Load(string filePath)
        {
            var text = File.ReadAllText(filePath);
            //Remove \r to fix OS compatibility
            text = text.Replace("\r", "");
            var list = text.Split('\n');
            for (var y = 0; y < ySize; y++)
            {
                var line = list[y];
                for (int x = 0; x < xSize; x++)
                {
                    var character = line[x];
                    var linkedList = new LinkedList<EntityBase>();
                    grid[y, x] = linkedList;

                    linkedList.AddFirst(new Space());

                    if (character == Constant.PlayerChar)
                    {
                        var p = new Player();
                        p.Start(this, x, y);
                        linkedList.AddFirst(p);
                    }
                    else if (character == Constant.GhostChar)
                    {
                        var p = new Ghost();
                        p.Start(this, x, y);
                        linkedList.AddFirst(p);
                    }
                    else if (character == Constant.WallChar)
                    {
                        var p = new Wall();
                        p.Start(this, x, y);
                        linkedList.AddFirst(p);
                    }
                    else if (character == Constant.ScoreChar)
                    {
                        var p = new Score();
                        p.Start(this, x, y);
                        linkedList.AddFirst(p);
                    }

                }
            }
        }

        public void Tick()
        {
            //We use a queue to first get all jobs to be executed and then execute every single job just once
            //If we execute immediately without a queue, the object position can change within that execution and it's possible that the same object could be executed multiple times during same tick
            var executionQueue = new Queue<EntityBase>();
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    var entities = grid[y, x];
                    var item = entities.First;
                    while (item != null)
                    {
                        executionQueue.Enqueue(item.Value);
                        item = item.Next;
                    }
                }
            }

            while (executionQueue.Count > 0)
            {
                var item = executionQueue.Dequeue();
                if (!item.isDestroyed)
                    item.Update();
            }

            renderer.Render(grid);
        }

        public void DestroyEntity(EntityBase e)
        {
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    var entities = grid[y, x];
                    var item = entities.First;
                    while (item != null)
                    {
                        if (item.Value == e)
                        {
                            entities.Remove(item);
                            return;
                        }
                        item = item.Next;
                    }
                }
            }
        }


    }
}
