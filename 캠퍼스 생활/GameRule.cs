using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 캠퍼스_생활
{
    static class GameRule
    {
        internal const ConsoleKey LR_BoardStudy = ConsoleKey.F1;
        internal const ConsoleKey LR_Presentation = ConsoleKey.F2;

        internal const ConsoleKey LI_Seminar = ConsoleKey.F1;
        internal const ConsoleKey LI_ReadBook = ConsoleKey.F2;

        internal const ConsoleKey DO_Sleep = ConsoleKey.F1;
        internal const ConsoleKey DO_WatchTV = ConsoleKey.F2;

        internal const ConsoleKey ExitKey = ConsoleKey.Escape;

        internal const int CMD_LR_BoardStudy = (int)LR_BoardStudy;
        internal const int CMD_LR_Presentation = (int)LR_Presentation;

        internal const int CMD_LI_Seminar = (int)LI_Seminar;
        internal const int CMD_LI_ReadBook = (int)LI_ReadBook;

        internal const int CMD_DO_Sleep = (int)DO_Sleep;
        internal const int CMD_DO_WatchTV = (int)DO_WatchTV;

        internal const int max_students = 100;

    }
}
