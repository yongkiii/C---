using EHLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 캠퍼스_생활
{
    internal class Campus
    {
        Student[] studes ; 
        internal Campus() 
        {
            Console.WriteLine("캠퍼스 생성");
            studes = new Student[GameRule.max_students];
        }
        
        //학생이 들어오게 해주는 라는 함수
        internal void InStudent(Student student)
        {
            int empty_index = FindEmptyIndex();
            studes[empty_index] = student;

        }
        //빈 공간 찾기
        private int FindEmptyIndex()
        {
            int index ;
            for ( index = 0; index < studes.Length; index++)
            {
                if (studes[index] == null)
                {
                    break;
                }

            }
            return index;



        }

        internal int StuCount
        {
            get { return FindEmptyIndex(); }
         
        }
        //해당하는 학생 반환
        internal Student this[int num]
        {
            get
            {
               for(int i =0; i < studes.Length; i++)
                {
                    if (studes[i].Num == num)
                    {
                        return studes[i];
                    }
                }
               return null;
            }
        }
        //학생 번호 입력 하는곳
        internal int SelectStudent()
        {
            return 0;
        }


        //학생 정보 입력 받는곳
        internal string GetStuInfo(int index)
        {
            if ((index >= 0) && index < FindEmptyIndex())
            {
                return studes[index].ToString();
            }
            return "해당 정보 학생 없음";

        }

        //학생 뺴기
        internal void OutStudent(Student std)
        {
            int index = FindStudent(std);
            if(index == -1)
            {
                return;
            }
            studes[index] = studes[studes.Length - 1]; // 먼저 학생을 한명 빼니 맨 뒤를 옮긴다 한칸 앞으로
            studes[studes.Length - 1] = null; // 그리고 다시 맨뒤를 null
        }

        private int FindStudent(Student std)
        {
            for(int i =0; i<studes.Length; i++)
            {
                if (studes[i] == std)
                {
                    return i;
                }
            }
            return -1;
        }
    }
     

        
        //private void ViewStuInfo(Student stu)
        //{
        //    Console.WriteLine("{0}", stu);
        //    Console.WriteLine("IQ {0} HP {1} CP {2}", stu.IQ, stu.HP, stu.CP);
        //}


    }


