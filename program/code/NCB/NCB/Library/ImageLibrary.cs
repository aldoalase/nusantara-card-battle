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
            
            String path = @"pack://application:,,,/" + assembly.GetName().Name + ";component/" + pathInApplication;
            if(!File.Exists(path)){
                path = @"pack://application:,,,/" + assembly.GetName().Name + ";component/images/default_card.png";
            }
            return new BitmapImage(new Uri(path, UriKind.Absolute));
        }

        public void Save()
        {
        }
    }
}
