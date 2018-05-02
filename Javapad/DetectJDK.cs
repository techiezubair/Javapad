using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Javapad
{
    public class DetectJDK
    {
        List<string> list = new List<string>();
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
            //Console.WriteLine("starting value: " + Properties.Settings.Default.jdkFound);
            BeginSearch(paths);
        }
        public string JDKpath
        {
            get
            {
                return jdkpath = jdkpath.Replace("javac.exe", "");
            }
        }
        private void BeginSearch(string[] path)
        {
            // first check if jdk has not been found
            if (!Properties.Settings.Default.jdkFound)
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
                    Properties.Settings.Default.jdkFound = true;
                    Properties.Settings.Default.Save();
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    for (int i = 0; i < path.Length; i++)
                    {
                        if (Directory.Exists(path[i]))
                        {
                            if (list.Count  > 0)
                            {
                                Properties.Settings.Default.jdkFound = true;
                                string p = list[0].Replace("javac.exe", "");
                                //Console.WriteLine("found path : " + p);
                                Properties.Settings.Default.jdkPath = p;
                                Properties.Settings.Default.Save();
                            }
                            else
                            {
                                RecurseFind(path[i], list);
                            }

                        }
                    }
                }
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
                        //Console.WriteLine(s);
                        if (s.Contains("javac.exe"))
                        {
                            list.Add(s);
                            jdkpath = s;
                            if (File.Exists(s.Replace("javac.exe", "java.exe")))
                            {
                                list.Add(s);
                            }
                        }

                    }
                    foreach (string s in dl)
                    {
                        //Console.WriteLine(s);
                        var str = s.Split('\\').Reverse().Take(1).ToArray();
                        if (s.Contains("All Users") || s.ToLower().Contains("default") || s.ToLower().Contains("public") || s.ToLower().Contains("syste") || str[0].Substring(0, 1).Contains(".") ||
                            s.Contains("Local") || s.Contains("Roaming") || s.ToLower().Contains("pictures") || s.ToLower().Contains("music") || s.ToLower().Contains("videos") ||
                            s.ToLower().Contains("windows") || s.ToLower().Contains("programdata") || s.ToLower().Contains("recovery"))
                        {

                        }
                        else
                        {
                            RecurseFind(s, list);
                        }
                    }

                }
            }

            catch (UnauthorizedAccessException ex)
            {

            }


        }
    }
}
