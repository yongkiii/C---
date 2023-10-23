using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace 캠퍼스_생활
{
    abstract class Place
    {
        //Place[] places;
        Student[] studes ;
     
            internal Place()
            {


            studes = new Student[GameRule.max_students];
        }

        protected Student GetStudent(int snum)
        {
            int cnt = GetStuCount();
            if ((cnt>=0) && (snum<cnt))
            {
                return studes[snum];
            }
            return null;
        }

        // 학생 들어간다 함수
        internal void InStudent(Student student)
        {
            int empty_index = FindEmptyIndex();
            studes[empty_index] = student;
        }

        private int FindEmptyIndex()
        {
            int i;
            for(i = 0; i < studes.Length; i++)
            {
                if (studes[i] == null )
                {
                    break;
                }
                
            }
            return i;
        }

        // 학생 수 매서드
        internal int GetStuCount()
        {
            int cnt = 0;
            while (studes[cnt] != null)
            {
                cnt++;
            }
            return cnt;
        }
        //학생 정보
        internal string GetStuInfo(int snum)
        {
           
            int cnt = GetStuCount();
            if((cnt >=0) &&  (snum<cnt))
            {
                return studes[snum].ToString();
            }
            return "유령 학생";
        }  
        public override string ToString()
        {
            return GetType().ToString();
        }
       internal Student this[int snum]

        {
            get 
            {
                for(int i = 0; i < studes.Length; i++) 
                {
                    if (studes[i] == null)
                    {
                        return null;
                    }
                    if (studes[i].Num == snum)
                    {
                        return studes[i];
                    }
                }
                return null;
            } 
        }

        internal abstract void DoIt(int cmd);
        internal abstract void DoIt(int cmd, int num);
        //입력 student는 맨뒤에 있는 학생 swap
        internal void OutStudent(Student student)
        {
            int cnt = GetStuCount();
            for(int i=0; i<cnt; i++) 
            {
                if (studes[i]==null)
                {
                    break;
                }
                if (studes[i] == student)
                {
                    studes[i]  = studes[cnt-1];
                    studes[cnt -1 ] = null;
                    return;
                }
            }


        }
    }

    internal class Library: Place
    {
        internal Library()
        {
           
            Console.WriteLine("도서관 생성");
        }
        internal override void DoIt(int cmd)
        {
           switch(cmd)
            {
                case GameRule.CMD_LI_Seminar: StartSeminar(); break;
                default: return;
            }
        }

        private void StartSeminar()
        {
            int cnt = GetStuCount();
            Student student = null; 
            for (int i=0; i<cnt;i++)
            {
                student = GetStudent(i);
                student.Seminar();
            }
        }

        internal override void DoIt(int cmd, int num)
        {
            Student student = this[num];
            if(student== null)
            {
                Console.WriteLine("{0}번 학생은 없다",num);
                return;
            }
            switch(cmd)
            {
                case GameRule.CMD_LI_ReadBook:StartReadBook(student); break;    
                    default: return;
            }
        }

        private void StartReadBook(Student student)
        {
            student.ReadBook();
        }
        public override string ToString()
        {
            return "도서관";
        }
    }
    internal class LectureRoom : Place
    {
        internal LectureRoom()
        {
            Console.Write("강의실 생성|");
           
        }
        // CAMPUSLife에서 전달된 인자가 입력 인자로 받음
        internal override void DoIt(int cmd)
        {
           switch(cmd)
            {
                case GameRule.CMD_LR_BoardStudy: StartBoardStudy(); break;
                default: return;
            }
        }

        private void StartBoardStudy()
        {
            int cnt = GetStuCount();
            Student student = null;
            CStudent cstudent = null;
            for(int i=0; i < cnt; i++)
            {
                student = GetStudent(i);
                student.BoardStudy();
                cstudent = student as CStudent;
                if(cstudent != null) 
                {
                    cstudent.Question();
                }
            }
        }

        internal override void DoIt(int cmd, int num)
        {
            Student student = this[num];
            if(student==null)
            {
                Console.WriteLine("{0}번 학생은 유령",num);
                return;
            }
            switch(cmd)
            {
                case GameRule.CMD_LR_Presentation: StartPresentation(student); break;
                dafault: return;
            }
        }

        private void StartPresentation(Student student)
        {
            student.Presentation();
            int cnt = GetStuCount();
            Student stu = null;
            for(int i=0; i < cnt; i++)
            {
                stu = GetStudent(i);
                if(stu!= student)
                {
                    stu.Discuss();
                }
            }
        }
        public override string ToString()
        {
            return "강의실";
        }
    }

    internal class Dormitory:Place 
    {
        internal Dormitory()
        {
            Console.Write("기숙사 생성|");
        }
        internal override void DoIt(int cmd)
        {
           
            switch(cmd)
            {
                case GameRule.CMD_DO_Sleep: TurnOff(); break;
                case GameRule.CMD_DO_WatchTV: StartTV(); break;
                default: return;
            }
        }

        private void TurnOff()
        {
            int cnt = GetStuCount();
            Student student = null;
            PStudent pstudent = null;
            for(int i=0; i<cnt; i++)
            {
                student = GetStudent(i);
                student.Sleep();
                pstudent = student as PStudent;
                if (pstudent != null)
                {
                    pstudent.SleepTalk();
                }
            }
        }

        private void StartTV()
        {
            int cnt = GetStuCount();
            Student student = null;
            for(int i=0; i<cnt; i++)
            {
                student = GetStudent(i);
                student.WatchTV();
            }
        }

        internal override void DoIt(int cmd, int num)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return "기숙사";
        }
    }
}
