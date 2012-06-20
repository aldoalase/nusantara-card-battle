using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Reflection;
using System.IO;

namespace NCB.Library
{
    class ImageLibrary
    {
        public BitmapImage Load(string pathInApplication, Assembly assembly = null)
        {
            if (assembly == null)
            {
                assembly = Assembly.GetCallingAssembly();
            }

            if (pathInApplication[0] == '/')
            {
                pathInApplication = pathInApplication.Substring(1);
            }

            if(!File.Exists(pathInApplication)){
                pathInApplication = "kartu/default_card.png";
            }
            string s = @"pack://application:,,,/" + assembly.GetName().Name + ";component/" + pathInApplication;
            return new BitmapImage(new Uri(@"pack://application:,,,/" + assembly.GetName().Name + ";component/" + pathInApplication, UriKind.Absolute));
        }
    }
}
