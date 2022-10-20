using System;
using System.Collections.Generic;
using System.Text;

namespace Jinisys.Hotel.BusinessSharedClasses
{
    public interface ClassMaintenanceInterface
    {
  
        bool load();
        int insert();
        int update();
        int delete();
    }
    
}
