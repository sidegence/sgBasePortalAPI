using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgBasePortalAPI
{
    public class Api
    {
        public Api()
        { }

        private Contracts _contracts; public Contracts Contracts { get { if (_contracts == null) _contracts = new Contracts(); return _contracts; } set { } }
    }
}
