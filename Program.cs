using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication_IOdemo
{
    class Program
    {
        const int PORT_KEY = 0x0060;// 键盘输入值端口
        static void Main(string[] args)
        {
            UInt16 in_value;
            UInt16 in_value_old = '\0';
            uint info;
            while ((info = IOOperation.IsInpOutDriverOpen()) == 0) ;// 检查IO端口驱动是否已打开
            Console.WriteLine("IO端口驱动已打开，按ESC键退出");
            while (true)
            {
                in_value = IOOperation.Inp32(PORT_KEY);// 得到键盘扫描码
                //in_value ^= 0xFF7F;// 取反
                //in_value &= (char)0xFF00;// 只取8位
                if (in_value == 0x0001) break;
                if (in_value != in_value_old && in_value != 0x003F)
                {
                    Console.WriteLine("您按了扫描码为: " + in_value.ToString("x8") + " 的键");
                }
                in_value_old = in_value;
                Thread.Sleep(1);
            }
        }
    }
}
