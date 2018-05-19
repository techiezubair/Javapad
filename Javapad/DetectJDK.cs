using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace Javapad
{
    public class DetectJDK
    {
        List<string> list = new List<string>();
        private bool jdkFound = false;
        private string jdkpath = "";
        private string[] paths = {
            Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
            @"C:\Program Files\Java\",
            @"C:\Program Files (x86)\Java\",
            @"C:\users\",
            @"C:\"
        };
        
        public string javacpath
        {
            get { return jdkpath; }
        }
        public void Begin()
        {
            BeginSearch(paths);
        }
        public string JDKpath
        {
            get
            {
                return jdkpath = jdkpath.Replace("javac.exe", "");
            }
        }
        public bool JDKFound
        {
            get
            {
                return jdkFound;
            }
        }
        private void BeginSearch(string[] path)
        {
            RegistryManager.Init();
            if(!RegistryManager.JDKFound)
            {
                // first check if jdk has not been found
                if (!jdkFound)
                {
                    // first look if the path exists
                    try
                    {
                        Process proc = new Process();
                        proc.StartInfo.UseShellExecute = false;
                        proc.StartInfo.FileName = "javac";
                        proc.StartInfo.CreateNoWindow = true;
                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc.Start();
                        proc.Close();
                        jdkFound = true;
                    }
                    catch (System.ComponentModel.Win32Exception ex)
                    {
                        for (int i = 0; i < path.Length; i++)
                        {
                            if (Directory.Exists(path[i]))
                            {
                                if (list.Count > 0)
                                {
                                    string p = list[0].Replace("javac.exe", "");
                                    jdkFound = true;
                                    jdkpath = p;
                                }
                                else
                                {
                                    RecurseFind(path[i], list);
                                }

                            }
                        }
                    }
                }
                RegistryManager.UpdateJDK(jdkFound, jdkpath);
            }
        }
        private void RecurseFind(string path, List<string> list)
        {
            try
            {
                string[] fl = Directory.GetFiles(path);
                string[] dl = Directory.GetDirectories(path);


                if (list.Count < 2) // look for javac and java.exe and if found then stop the search!
                {
                    // loop for javac.exe first... then check for java in the same folder
                    foreach (string s in fl)
                    {
                        if (s.Contains("javac.exe"))
                        {
                            //string p = s.Replace("javac.exe", "");
                            ////list.Add(s);
                            //jdkpath = p;
                            //jdkFound = true;
                            if (File.Exists(s.Replace("javac.exe", "java.exe")))
                            {
                                string p = s.Replace("javac.exe", "");
                                jdkpath = p;
                                jdkFound = true;
                                list.Add(s);
                            }
                        }

                    }
                    foreach (string s in dl)
                    {
                        var str = s.Split('\\').Reverse().Take(1).ToArray();
                        if (s.Contains("All Users") || s.ToLower().Contains("default") || s.ToLower().Contains("public") || s.ToLower().Contains("syste") || str[0].Substring(0, 1).Contains(".") ||
                            s.Contains("Local") || s.Contains("Roaming") || s.ToLower().Contains("pictures") || s.ToLower().Contains("music") || s.ToLower().Contains("videos") ||
                            s.ToLower().Contains("windows") || s.ToLower().Contains("programdata") || s.ToLower().Contains("recovery")) { }
                        
                        else
                            RecurseFind(s, list);
                        
                    }

                }
            }

            catch (UnauthorizedAccessException ex)
            {

            }


        }
    }
}
