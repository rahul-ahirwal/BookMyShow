using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.Utilities
{
    public class SD
    {
        //Roles
        public const string Role_Customer = "Customer";
        public const string Role_Admin = "Admin";
        public const string Role_Support = "Support";

        //Movie State
        public enum MovieState
        {
            Active = 0,
            Inactive = 1,
            Upcoming = 2,
            Banned = 3
        }

        //Show Type
        public const string ShowType_2D = "2D";
        public const string ShowType_3D = "3D";
        public const string ShowType_4D = "4D";
        public const string ShowType_4DX = "4DX";
        public const string ShowType_MX4D = "MX4D";
    }
}
