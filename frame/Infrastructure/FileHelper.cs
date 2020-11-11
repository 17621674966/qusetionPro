using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class FileHelper
    {
        public static string GetFileType(string file)
        {
            string fileType = string.Empty;
            if (string.IsNullOrEmpty(file))
            {
                throw new Exception("文件名称不能为空！");
            }
            int index = file.LastIndexOf(".");
            return file.Substring(index);


        }
    }
}
