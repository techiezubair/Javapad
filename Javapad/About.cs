using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Javapad
{
    partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            string descText = "Bismillah" + Environment.NewLine + Environment.NewLine +
                "Facebook Profile: https://www.facebook.com/profile.php?id=100008730390533" + Environment.NewLine + Environment.NewLine +
                "- Alpha Version -" + Environment.NewLine +
                "I made this app for new Java programmers.Sometimes the new programmers find it difficult to make sure[javac.exe & java.exe] are properly added to the Windows Environment Variables.Although, the Java JDK is portable but its portable usage isn’t usually a teacher’s first priority.This app auto - detects the JDK and eliminates the new learner from overwhelming stress of writing and compiling your code using NOTEPAD and CMD.This app is designed to replace NOTEPAD." + Environment.NewLine + Environment.NewLine +
                "- Future Updates -" + Environment.NewLine +
                "This app will integrate offline books and games to help make the Java learning process breeze and fun.A lot of great features will be introduced in the BETA version of this app." + Environment.NewLine +
                "I developed this app using C#, BUILD .NET 4 client profile." + Environment.NewLine + Environment.NewLine +
                "Thank you for using my app.";

            this.textBoxDescription.Text = descText;//AssemblyDescription;
        }
        public void setLocation(int x, int y)
        {
            this.Location = new Point(x, y);
        }
        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
