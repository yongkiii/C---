using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 캠퍼스_생활
{
    internal class Student
    {
         string name;
         readonly int num;
         static int last_num;

        public override string ToString()
        {
           // Campus cp = new Campus();

            return string.Format("{0}:몇번 {1}:학생이름 ", Num,Name);
        }
       
        internal Student(string name)
        {
            this.name = name;
            last_num++;
            this.num = last_num;
        }
        internal string Name { get { return name; } private set {; } }

        internal int Num { get { return num; } private set {; } }

        int iq = 80; // 지력
        int min_iq = 60;
        int max_iq = 200;

        internal int IQ
        {
            get { return iq; }
             set
            {
                if(value<min_iq) 
                   value = min_iq;
                if(value>max_iq)
                  value = max_iq;
                iq = value;

            }

        }
//--------------------------
        int hp =50;// 초기값 체력
        int min_hp = 0;
        int max_hp = 100;

        internal int HP
        {
           
            get { return hp; }
            set 
            {
                if(value<min_hp)
                    value = min_hp;
                if(value>max_hp)
                    value=max_hp;
                hp = value;
            }
        }
        //-------------------

        internal int CP
        {
            get { return cp; }
            set
            {
                if(value< min_cp)
                    value = min_cp;
                if( value>max_cp)
                    value=max_cp;
                cp = value;
            }
        }
        int cp = 0; //대화 능력
        int min_cp = 0;
        int max_cp = 100;

        //internal Student(string name, int num)
        //{
        //    this.name = name;
        //    this.num = num;
        //}

        //판서
        internal void BoardStudy()
        {
            //전 능력
            Console.WriteLine("{0} 아이큐 {1} 체력 {2} 대화능력", ToString(),IQ,HP,CP);
            iq = iq + 5;
            hp = hp - 4;
            cp = cp - 1;
            //강의를 듣고 후 능력
            Console.WriteLine("{0} 아이큐 {1} 체력 {2} 대화능력", ToString(), IQ, HP, CP);
        }
     //   발표
        public void Presentation()
        {
            Console.WriteLine("{0} 아이큐 {1} 체력 {2} 대화능력", ToString(), IQ, HP, CP);

            cp = cp + 3;
            hp = hp - 2;
            Console.WriteLine("{0} 아이큐 {1} 체력 {2} 대화능력", ToString(), IQ, HP, CP);

        }
        //세미나
        public void Seminar()
        {
            Console.WriteLine("{0} 아이큐 {1} 체력 {2} 대화능력", ToString(), IQ, HP, CP);
            iq = iq + 5;
            hp = hp - 4;
            Console.WriteLine("{0} 아이큐 {1} 체력 {2} 대화능력", ToString(), IQ, HP, CP);

        }

        public virtual void ReadBook()
        {
            Console.WriteLine("{0} 아이큐 {1} 체력 {2} 대화능력", ToString(), IQ, HP, CP);
            iq = iq + 2;
            cp = cp + 2;
            Console.WriteLine("{0} 아이큐 {1} 체력 {2} 대화능력", ToString(), IQ, HP, CP);

        }
        public virtual void WatchTV()
        {
            Console.WriteLine("{0} 아이큐 {1} 체력 {2} 대화능력", ToString(), IQ, HP, CP);
            hp = hp - 2;
            Console.WriteLine("{0} 아이큐 {1} 체력 {2} 대화능력", ToString(), IQ, HP, CP);
        }

        public void Sleep()
        {
            Console.WriteLine("{0} 아이큐 {1} 체력 {2} 대화능력", ToString(), IQ, HP, CP);
            hp = hp + 2;
            Console.WriteLine("{0} 아이큐 {1} 체력 {2} 대화능력", ToString(), IQ, HP, CP);
        }

        internal void Discuss()
        {
            Console.WriteLine("{0} 자유토론을 하다", ToString());
        }

        //보수적인 학생

    }
    internal class MStudent : Student
    {

       internal MStudent(string name) : base(name)
        {

        }
        public override void WatchTV()
        {
            base.WatchTV();
            HP = HP - 2;
            CP = CP - 1;
            Console.WriteLine("보수적인 학생 , 추가 대화능력 {0}", CP);
        }
    }
    //도전적인 학생
    internal class CStudent : Student
    {
       
        public CStudent(string name) : base(name)
        {

        }
        public override void ReadBook()
        {
            base.ReadBook();
            IQ = IQ + 2;
            CP = CP + 3;
            Console.WriteLine("도전적인 학생, 추가로 대화능력에 변화; {0}",CP);
        }

        public void Question()
        {
            Console.WriteLine("{0} 아이큐 {1} 체력 {2} 대화능력", ToString(), IQ, HP, CP);
            IQ = IQ + 1;
            CP = CP + 1;
            Console.WriteLine("{0} 아이큐 {1} 체력 {2} 대화능력", ToString(), IQ, HP, CP);
        }
    }
    //수동적인 학생
    internal class PStudent : Student
    {
        public PStudent(string name) : base(name)
        {
        }

      

        public void SleepTalk()
        {
            Console.WriteLine("{0} 아이큐 {1} 체력 {2} 대화능력", ToString(), IQ, HP, CP);
            HP = HP - 1;
            IQ = IQ + 1;
            Console.WriteLine("{0} 아이큐 {1} 체력 {2} 대화능력", ToString(), IQ, HP, CP);
        }

    }
}
