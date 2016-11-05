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

        private Announcements _announcements; public Announcements Announcements { get { if (_announcements == null) _announcements = new Announcements(); return _announcements; } set { } }
        private Contracts _contracts; public Contracts Contracts { get { if (_contracts == null) _contracts = new Contracts(); return _contracts; } set { } }
        private Entities _entities; public Entities Entities { get { if (_entities == null) _entities = new Entities(); return _entities; } set { } }
    }
}
