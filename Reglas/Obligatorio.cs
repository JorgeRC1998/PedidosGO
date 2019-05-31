using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reglas
{
    public interface Obligatorio<cualquierclase>
    {
        void create(cualquierclase obj);


    }
}
