using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Javapad
{
    public static class Profile
    {
        public static string UserName = "";
        public static string FullName = "";
        public static string BgColor = "";
        public static string Avatar = "";
        public static string Tag = "";
        public static bool CustomAvatar = false;
        public static string CustomAvatarPath = "";
        
        public static void Update(bool customAvatar, string customAvatarPath, string avatar, string tag, string fullName, string userName, string bgColor)
        {
            // initialize profile
            UserName = userName;
            FullName = fullName;
            BgColor = bgColor;
            Avatar = avatar;
            Tag = tag;
            CustomAvatar = customAvatar;
            CustomAvatarPath = customAvatarPath;
        }
        public static int[] Arbg()
        {
            int[] colors = new int[3];
            if (!String.IsNullOrEmpty(BgColor)) {
                string[] splitArray = BgColor.Split(',');
                colors[0] = Convert.ToInt16(splitArray[0].Trim());
                colors[1] = Convert.ToInt16(splitArray[1].Trim());
                colors[2] = Convert.ToInt16(splitArray[2].Trim());
            }
            return colors;
        }
        /*
        public static void GetProfile(out bool customAvatar, out string customAvatarPath,
                                        out string avatar, out string fullName,
                                        out string userName, out string bgColor)
        {
            customAvatar = CustomAvatar;
            customAvatarPath = CustomAvatarPath;
            avatar = Avatar;
            fullName = FullName;
            userName = UserName;
            bgColor = BgColor;
        }*/
    }
}
