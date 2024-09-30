using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelGiocoHanoi
{
    public class CDisco
    {
        public int size { get; private set; }
        public Color Color { get; }

        public CDisco(int size) 
        {
            this.size = size;

            Random random = new Random();
            Color = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }
    }
}
