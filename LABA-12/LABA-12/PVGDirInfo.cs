using System;
using System.IO;

namespace LABA12
{
    public static class PVGDirInfo
    {
        public static void GetDirInfo()
        {
            string path = Path.GetFullPath(@"D:\ООП\LABA-12");
            string DirInfoLog = "";

            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (dirInfo.Exists)
                DirInfoLog = "\n=========================================   PVGDirInfo   =================================================\n" +
                             "\nКоличество файлов:        " + dirInfo.GetFiles().Length +
                             "\nВремя создания:           " + dirInfo.LastWriteTime +
                             "\nКол-во поддиректориев:    " + dirInfo.GetDirectories().Length +
                             "\nРодительский директорий:  " + dirInfo.Parent.Name;

            PVGLog.WriteInLog(DirInfoLog);
        }
    }
}