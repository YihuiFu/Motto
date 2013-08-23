using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dengzher.Common
{
   public abstract   class  FileHelper
    {
       /// <summary>
       /// 为文件生成唯一的名称
       /// </summary>
       /// <param name="fileName"></param>
       /// <param name="userName"></param>
       /// <returns></returns>
       public static string  GenerateUniqueName(string fileName,string userName)
       {
           string extension = Path.GetExtension(fileName);
           return userName + extension;
       }

       /// <summary>
       /// 验证图片格式
       /// </summary>
       /// <param name="fileName"></param>
       /// <param name="fileLimit"></param>
       /// <returns></returns>
       public static bool CheckImage(string fileName,string [] fileLimit)
       {
           bool flag = false;
           string extension = Path.GetExtension(fileName);
           if (fileLimit.Contains(extension.ToUpper()))
           {
               flag = true;
           }
           return flag;
       }
    }
}
