using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase
{
    public class Space : EntityBase
    {
        public override string name { get; set; } = "Space";
        public override char character { get; set; } = Constant.SpaceChar;

        public override void Update()
        {
        }
    }
}
