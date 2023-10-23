using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 캠퍼스_생활
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CampusLife cl = CampusLife.Singleton;
            cl.Init();
            cl.Run();
        }
    }
}