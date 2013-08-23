using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Web;



namespace Dengzher.Common
{
   public abstract  class ValidateCode
    {
       /// <summary>
       /// Generate six random char.
       /// </summary>
       /// <returns></returns>
       public static  string GenerateValidateCode()
       {
           string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
           string[] charArray = allChar.Split(',');
           string validateCode = string.Empty;
           int temp = -1;
           Random rand = new Random();
           for (int i = 0; i < 6; i++)
           {
               if (temp!=-1)
               {
                   rand = new Random(i*temp*((int)DateTime.Now.Ticks));
               }
               int t = rand.Next(36);

               if (temp!=-1&&temp==t)
               {
                   return GenerateValidateCode();
               }
               temp = t;
               validateCode += allChar[t];
           }
           return validateCode;
       }

       public static byte[] CreateImage(string validateCode)
       {
           System.Drawing.Bitmap image = new System.Drawing.Bitmap(Convert.ToInt32(Math.Ceiling((decimal)(validateCode.Length*14))),22);
           Graphics g = Graphics.FromImage(image);
           try
           {
               Random rand = new Random();
               g.Clear(Color.AliceBlue);
               for (int i = 0; i < 25; i++)
               {
                   int x1 = rand.Next(image.Width);
                   int x2 = rand.Next(image.Width);
                   int y1 = rand.Next(image.Height);
                   int y2 = rand.Next(image.Height);
                   g.DrawLine(new Pen(Color.Silver),x1,y1,x2,y2);
               }
               Font font = new System.Drawing.Font("Comic Sans MS",12,System.Drawing.FontStyle.Bold);
               System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
               g.DrawString(validateCode,font,new SolidBrush(Color.Red),2,2);
               for (int i = 0; i < 100; i++)
               {
                   int x = rand.Next(image.Width);
                   int y = rand.Next(image.Height);
                   image.SetPixel(x,y,Color.FromArgb(rand.Next()));
               }
               g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
               MemoryStream ms = new MemoryStream();
               image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
               return ms.ToArray();
               
           }
           finally
           {
               g.Dispose();
               image.Dispose();
           }
       }

       /// <summary>
       /// 生成短信验证码
       /// </summary>
       /// <returns></returns>
       public static string GenerateMsgCode()
       {
           string allChar = "0,1,2,3,4,5,6,7,8,9";
           string[] charArray = allChar.Split(',');
           string validateCode = string.Empty;
           int temp = -1;
           Random rand = new Random();
           for (int i = 0; i < 6; i++)
           {
               if (temp != -1)
               {
                   rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
               }
               int t = rand.Next(10);

               if (temp != -1 && temp == t)
               {
                   return GenerateMsgCode();
               }
               temp = t;
               validateCode += allChar[t];
           }
           return validateCode;
       }


    }
}
