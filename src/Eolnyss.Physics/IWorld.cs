using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eolnyss.Physics
{
    public interface IWorld
    {
        IEnumerable<IBox> Boxes { get; }

        IBox Create(float x, float y, float width, float height);
    }
}
