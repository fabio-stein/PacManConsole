using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase
{
    public class Score : EntityBase
    {
        public override string name { get; set; } = "Score";
        public override char character { get; set; } = Constant.ScoreChar;

        public override void Update()
        {
        }
    }
}
