using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Javapad
{
    public class RegistryManager
    {
        public static bool JDKFound = false;
        public static string JDKPath = "";
        private static string keyPath = "SOFTWARE\\Javapad\\v2_alpha";
        private static int userStartingPoints = 0;
        public static void Init()
        {
            
            RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath, true);

            if (key != null)
            {
                Object jdkPath = key.GetValue("jdkPath");
                Object jdkFound = key.GetValue("jdkFound");
                Object userPoints = key.GetValue("UserPoints");
                Object projectEulerSolved = key.GetValue("PESolved");
                Object cA = key.GetValue("CustomAvatar");
                Object cAP = key.GetValue("CustomAvatarPath");
                Object a = key.GetValue("Avatar");
                Object t = key.GetValue("AvatarTag");
                Object fN = key.GetValue("UserFullName");
                Object uN = key.GetValue("Username");
                Object pbgC = key.GetValue("ProfileBgColor");
                if (jdkPath != null)
                {
                    JDKPath = jdkPath.ToString();
                }
                if(jdkFound != null)
                {
                    JDKFound = Convert.ToBoolean(jdkFound.ToString());
                }
                if(userPoints != null)
                {
                    Points.UserPoints = Convert.ToInt32(userPoints);
                }
                if(projectEulerSolved != null)
                {
                    if(projectEulerSolved.ToString().Length > 0)
                        ProjectEulerProgress.SolvedDictionary = ProjectEulerProgress.js.Deserialize<Dictionary<string, string>>(projectEulerSolved.ToString());
                    
                        
                }
                if (a != null && cA != null && cAP != null && a != null && t != null && fN != null && uN != null && pbgC != null)
                {
                    Console.WriteLine("updated prfile.");
                    Profile.Update(Convert.ToBoolean(cA), cAP.ToString(), a.ToString(), t.ToString(), fN.ToString(), uN.ToString(), pbgC.ToString());
                }

            }
            else
            {
                /*
                 * Initialize registry entries
                 */ 
                Write("jdkPath", "");
                Write("jdkFound", "false");
                Write("UserPoints", userStartingPoints.ToString());
                Write("PESolved", "");
                string userName = "Tdot Soldier";
                string fullName = "Zee Safi";
                string bgColor = "84, 168, 27";
                string avatar = "dexterslab";
                string tag = "dexterslab";
                Write("Username", userName);
                Write("UserFullName", fullName);
                // VidaLoca color in Hex
                Write("ProfileBgColor", bgColor);
                Write("CustomAvatar", "false");
                Write("CustomAvatarPath", "");
                Write("Avatar", avatar);
                Write("AvatarTag", tag);
                InitProfile(false, "", avatar, tag, fullName, userName, bgColor);
            }
                
        }
        private static void InitProfile(bool customAvatar, string customAvatarPath, string avatar, string tag, string fullName, string userName, string bgColor)
        {
            Profile.Update(customAvatar, customAvatarPath, avatar, tag, fullName, userName, bgColor);
        }
        public static void UpdateProfile(bool customAvatar, string customAvatarPath, string avatar, string tag, string fullName, string userName, string bgColor)
        {
            Write("CustomAvatar", customAvatar.ToString());
            Write("CustomAvatarPath", customAvatarPath);
            Write("Avatar", avatar);
            Write("AvatarTag", tag);
            Write("Username", userName);
            Write("UserFullName", fullName);
            Write("ProfileBgColor", bgColor);
            Profile.Update(customAvatar, customAvatarPath, avatar, tag, fullName, userName, bgColor);
        }
        public static void UpdateJDK(bool found, string path)
        {
            JDKFound = found;
            JDKPath = path;
            UpdateKeys("jdkFound", found + "");
            UpdateKeys("jdkPath", path);

        }
        private static void UpdateKeys(string keyName, string value)
        {
            RegistryKey sk1 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(keyPath);
            if (sk1 != null)
            {
                sk1.SetValue(keyName, value);
            }
        }
        /// <summary>
        /// This C# code reads a key from the windows registry.
        /// </summary>
        /// <param name="keyName">
        /// <returns></returns>
        public static string Read(string keyName)
        {
            RegistryKey sk = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyPath);
            if (sk == null)
            {
                return null;
            }
            else
            {
                string str = sk.GetValue(keyName).ToString();
                sk = null;
                return str;
            }
        }

        /// <summary>
        /// This C# code writes a key to the windows registry.
        /// </summary>
        /// <param name="keyName">
        /// <param name="value">
        public static void Write(string keyName, string value)
        {
            RegistryKey sk1 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(keyPath);
            sk1.SetValue(keyName, value);
        }
        
    }
}
