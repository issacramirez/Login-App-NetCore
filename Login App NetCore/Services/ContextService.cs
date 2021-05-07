using Login_App_NetCore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_App_NetCore.Services {
    public class ContextService {
        protected NORTHWNDContext dataContext = new NORTHWNDContext();
    }
}
