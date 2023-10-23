using EHLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 캠퍼스_생활
{
    internal class CampusLife
    {
        // Student[] studes = new Student[100];
        Campus cp;
        //단일체 접근 속성 private
        public static CampusLife Singleton
        {
            get;
            private set;
        }

        //단일체 생성
        static CampusLife()
        {
            Singleton = new CampusLife();
        }
        //단일체로 구현하기 위해 private 접근 지정
        private CampusLife()
        {

        }
        //Campus cp = new Campus();
        internal void Init()
        {

            MakePlaces();
            MakeStudents();

        }
        // 학생 유형 선택 함수
        private StuType SelectStuType()
        {

            Console.WriteLine("학생의 유형 {0} 도전적 {1} 보수적 {2} 수동적", (int)StuType.ST_CSTUDENT, (int)StuType.ST_MSTUDENT, (int)StuType.ST_PSTUDENT);
            Console.Write("학생 유형을 입력하세요 : ");
            string msg = Console.ReadLine();
            switch (EH.InputNum(msg))
            {
                case 0: return StuType.ST_CSTUDENT;
                case 1: return StuType.ST_MSTUDENT;
                case 2: return StuType.ST_PSTUDENT;
                default: return StuType.ST_CSTUDENT;
            }


        }
        private void MakeStudents()
        {
            Student[] studes = new Student[100];
            Student student = null;
            Console.Write("학생 수 입력 : ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                student = MakeStudent(i + 1);
                cp.InStudent(student);
            }
        }
        private Student MakeStudent(int nth)
        {

            Console.WriteLine("{0} 번째 학생  ", nth);
            //  int snum = int.Parse(Console.ReadLine());
            StuType stuType = SelectStuType();
            Console.Write("학생 이름 입력 : ");
            string name = Console.ReadLine();
            switch (stuType)
            {

                case StuType.ST_CSTUDENT: return new CStudent(name);
                case StuType.ST_MSTUDENT: return new MStudent(name);
                case StuType.ST_PSTUDENT: return new PStudent(name);
            }

            return null;

        }

        //campus null 초기화
        // Campus cp = null;
        //장소 생성 배열 
        Place[] places = new Place[(int)PlaceType.MAX_PLACES];
        //장소 생성
        private void MakePlaces()
        {
            cp = new Campus();
            MakePlace(PlaceType.PT_LECTUREROOM,new LectureRoom());
            MakePlace(PlaceType.PT_DORMITORY, new Dormitory());
            MakePlace(PlaceType.PT_LIBRARY,new Library());
        }
        private void MakePlace(PlaceType placeType, Place place)

        {
            places[(int)placeType] = place;
        }

        // cp.GetStuInfo();

        // cp.SelectStudent();

        internal void Run()
        {
           
           
            // Console.WriteLine("F1 : 학생이동 F2 : 초정 이동 F3 : 전체보기");
            ConsoleKey key = ConsoleKey.NoName;
            
           while ((key = SelectMenu())!=ConsoleKey.Escape)
            {
                switch (key)
                {
                    case ConsoleKey.F1: MoveStudent(); break;
                    case ConsoleKey.F2: MoveFocus(); break;
                    case ConsoleKey.F3: PrintAll(); break;
                    default: Console.WriteLine("종료 합니다."); break;
                }
                Console.WriteLine("아무키나 누르세요");
                Console.ReadKey(true);
            }
        }

        private ConsoleKey SelectMenu()
        {
            Console.Clear();
            Console.WriteLine("메뉴");
            Console.WriteLine("f1: 학생이동");
            Console.WriteLine("f2: 초점이동");
            Console.WriteLine("f3: 전체보기");
            return Console.ReadKey(true).Key;
        }

        private void ViewStuInfoInCampus()
        {
            int scnt = cp.StuCount;
            for (int i = 0; i < scnt; i++)
            {
                Console.WriteLine(cp.GetStuInfo(i));
            }
        }
        //전체 보기
        private void PrintAll()
        {
            Console.WriteLine("캠퍼스");
            ViewStuInfoInCampus();
            foreach(Place place in places)
            {
                Console.WriteLine(place.ToString());
                ViewStuInfoPlace(place);
            }
        }
        //사용자 선택으로 장소 이동
        private void MoveFocus()
        {
            Console.WriteLine("초점 이동 기능 선택");
            Place place = SelectPlace();
            if(place ==null)
            {
                Console.WriteLine("잘못 선택");
                return;
            }
            MoveFocusAt(place);
            ComeBack(place);
        }

        private void ComeBack(Place place)
        {
           while(true)
            {
                ViewStuInfoPlace(place);
                Console.WriteLine("복귀할 학생을 입력 default는 0");
                int num = EH.InputNum(Console.ReadLine().ToString());
                if(num == 0)
                {
                    return;
                }
                //그 장소에 있는 학생
                Student student = place[num];
                if(student ==null)
                {
                    Console.WriteLine("유령 학생");
                    return;
                }
                place.OutStudent(student);
                cp.InStudent(student);
                



            }
        }
        //해당 장소에 있는 학생 정보 출력 
        private void ViewStuInfoPlace(Place place)
        {
            int cnt = place.GetStuCount();
            for(int i = 0; i < cnt; i++)
            {
                Console.WriteLine(place.GetStuInfo(i));
            }
        }

        private void MoveFocusAt(Place place)
        {
           if(place is LectureRoom)
            {
                FocusAtLectureRoom(place as LectureRoom);
            }
           if(place is Library)
            {
                FocusAtLibrary(place as Library);
            }
           if(place is Dormitory)
            {
                FocusAtDormitory(place as Dormitory);
            }
        }

        private void FocusAtDormitory(Dormitory dormitory)
        {

            ConsoleKey key;
            while((key = SelectDormMenu()) != GameRule.ExitKey)
            {
                switch(key)
                {
                    case GameRule.DO_Sleep: StartSleep(dormitory); break;
                    case GameRule.DO_WatchTV: StartWatchTV(dormitory); break;
                    default:
                        Console.WriteLine( "잘못된 메뉴 선택"); break;
                }
                Console.WriteLine("아무키나 누루삼");
                Console.ReadKey();
            }
        }

        private ConsoleKey SelectDormMenu()
        {
            Console.Clear();
            Console.WriteLine("기숙사 메뉴");
            Console.WriteLine("{0} 잠자기", GameRule.DO_Sleep);
            Console.WriteLine("{0} TV 시청", GameRule.DO_WatchTV);
            Console.WriteLine("{0} 캠퍼스 생활로 돌아가기", GameRule.ExitKey);

            return Console.ReadKey().Key;
        }

        private void StartSleep(Dormitory dormitory)
        {
            dormitory.DoIt(GameRule.CMD_DO_Sleep);
        }

        private void StartWatchTV(Dormitory dormitory)
        {

            dormitory.DoIt(GameRule.CMD_DO_WatchTV);
        }

        private void FocusAtLibrary(Library library)
        {
            ConsoleKey key;
            while((key=SelectLibMenu())!=GameRule.ExitKey)
            {
                switch(key)
                {
                    case GameRule.LI_Seminar:StartSeminar(library); break;
                    case GameRule.LI_ReadBook: StartReadBook(library); break;
                    default:   Console.WriteLine("잘못된 거 선택"); break;
                }
                Console.WriteLine("아무키나 누르삼");
                Console.ReadKey();
            }
        }

        private ConsoleKey SelectLibMenu()
        {
            Console.Clear();
            Console.WriteLine("도서관 메뉴");
            Console.WriteLine("{0} 세미나", GameRule.LI_Seminar);
            Console.WriteLine("{0} 책 읽기", GameRule.LI_ReadBook);
            Console.WriteLine("{0} 캠퍼스 생활로 돌아가기", GameRule.ExitKey);
            return Console.ReadKey().Key;
        }

        private void StartReadBook(Library library)
        {
            ViewStuInfoPlace(library);
            Console.WriteLine("책 읽기 할 학생 번호 선택");
            int num = EH.InputNum(Console.ReadLine().ToString());
            library.DoIt(GameRule.CMD_LI_ReadBook, num);

        }

        private void StartSeminar(Library library)
        {
            library.DoIt(GameRule.CMD_LI_Seminar);
        }

        private void FocusAtLectureRoom(LectureRoom lectureRoom)
        {
            ConsoleKey key  = ConsoleKey.NoName;
            while ((key = SelectLRMenu()) != GameRule.ExitKey)
            {
                switch(key)
                {
                    case GameRule.LR_BoardStudy: StartBoardStudy(lectureRoom); break; 
                    case GameRule.LR_Presentation: StartPresentation(lectureRoom); break;
                    default:Console.WriteLine("잘못된 메뉴를 선택"); break;
                }
                Console.WriteLine("아무키나 누르세여");
                Console.ReadKey();
            }
           
        }
        // 강의실에서 할꺼 메뉴판
        private ConsoleKey SelectLRMenu()
        {
            Console.Clear();
            Console.WriteLine("강의실 메뉴");
            Console.WriteLine("{0} 판서 강의",GameRule.LR_BoardStudy);
            Console.WriteLine("{0} 발표 수업",GameRule.LR_Presentation);
            Console.WriteLine("{0} 캠퍼스 생활로 돌아가기", GameRule.ExitKey);
            return Console.ReadKey().Key;
        }

        private void StartPresentation(LectureRoom lectureRoom)
        {
            ViewStuInfoPlace(lectureRoom);
            Console.WriteLine("발표할 학생 번호를 입력");
            string snum = Console.ReadLine();
            int num = EH.InputNum(snum);
            lectureRoom.DoIt(GameRule.CMD_LR_Presentation,num);
        }

        private void StartBoardStudy(LectureRoom lectureRoom)
        {
           lectureRoom.DoIt(GameRule.CMD_LR_BoardStudy);
        }

        //학생 이동 캠퍼스에 있는 학생 중에 장소 이동
        private void MoveStudent()
        {
            ViewStuInfoInCampus();
            Console.WriteLine("이동할 학생 번호 입력");
            string snum = Console.ReadLine();
            int nnum = EH.InputNum(snum);
            Student std = cp[nnum];
           
            if (std == null)
            {
                Console.WriteLine("유령 학생");
                return;
            }
            Place place = SelectPlace();
            if (place==null)
            {
                Console.WriteLine("공동묘지 선택 ㅅㄱ링");
                return;
            }
            cp.OutStudent(std);
            place.InStudent(std);
        }
        private Place SelectPlace()
        {
            for (int i = 0; i < places.Length; i++)
            {
                Console.WriteLine("{0}.{1}", i, places[i].ToString());
            }
            // cp.GetStuInfo();
            Console.Write("장소를 선택하세요: ");
            string num_place = Console.ReadLine();
            int place = EH.InputNum(num_place);
            if ((place >= 0) && (place <= places.Length))
            {
                return places[place];
            }
            return null;
        }


      
    }
}
