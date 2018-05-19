using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Javapad
{
    public static class Points
    {
        public static int CORRECTPOINTS = 1000;
        public static int UserPoints = 1;
        private static void Init()
        {
            // create or get points from the registry

        }
        public static void Add(int num)
        {
            UserPoints = UserPoints + num;
            Update();
        }
        public static void remove(int num)
        {
            UserPoints = UserPoints - num;
            if (UserPoints < 1)
                UserPoints = 1;
            Update();
        }
        private static void Update()
        {
            // update entry in the Registry...
            RegistryManager.Write("UserPoints", UserPoints+"");
        }
    }
}
