using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ex13_LinQ
{
    class ProFile
    {
        private int age;
        public string Name { get; set; } // 자동 프로퍼티
        public int Height { get; set; } // 키에 -21억 ~ +21억까지
        public int Age
        {
            get => age;
            set
            {
                if (value >= 0 && value < 200)
                {
                    age = value;
                }
                else
                {
                    age = 20; // 잘못 넣었으면 20으로 Fix
                }
            }
        } // 나이 => -21억 ~ +21억까지

        class Product
        {
            public string Title { get; set; }
            public string star { get; set; }


        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("LinQ 테스트");

                ProFile[] profiles =
                {
                    new ProFile { Name = "정우성", Height = 186, Age = 49 },
                    new ProFile { Name = "이정재", Height = 184, Age = 50 },
                    new ProFile { Name = "김태희", Height = 160, Age = 48 },
                    new ProFile { Name = "전지현", Height = 172, Age = 44 },
                    new ProFile { Name = "이문세", Height = 180, Age = 65 },
                    new ProFile { Name = "장원영", Height = 165, Age = 24 },
                    new ProFile { Name = "RM", Height = 178, Age = 30 }

                };

                Product[] arrProducts =
                {
                    new Product{Title="Beat", star = "정우성"},
                    new Product{Title="오징어게임", star = "이정재"},
                    new Product{Title="엽기적인 그녀", star = "전지현"},
                    new Product{Title="도둑들", star = "전지현"},
                    new Product{Title="Dynamite", star = "RM"},
                    new Product{Title="Solo", star = "이문세"}
                };

                // LINQ 미사용
                List<ProFile> proFiles = new List<ProFile>();
                foreach (ProFile profile in profiles)
                {
                    if (profile.Height < 175)
                        proFiles.Add(profile);
                }
                proFiles.Sort((profile1, profile2) => profile1.Height - profile2.Height);

                // 결과 출력
                foreach (ProFile profile in proFiles)
                {
                    Console.WriteLine($"Name: {profile.Name}, (Height: {profile.Height}cm), Age: {profile.Age}세");
                }

                // LinQ사용한다면
                Console.WriteLine(" ");
                Console.WriteLine("LinQ 사용");
                var profiles2 = from proFile in proFiles
                                where proFile.Height < 175
                                orderby proFile.Height
                                select proFile;
                foreach (var profile in profiles2)
                {
                    Console.WriteLine($"Name: {profile.Name}, (Height: {profile.Height}cm), Age: {profile.Age}세");
                } // LinQ를 사용하면 8줄 코딩.

                // LinQ기본
                int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                var result = from n in numbers
                             where n % 2 == 0
                             orderby n descending
                             select n;
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }

                //GroupBy => DB의 gropby처럼 집계함수가 필요 하지 않음
                var groupProfiles = from p in profiles
                                    orderby p.Height ascending
                                    group p by p.Height < 175 into g
                                    select new { GroupKey = g.Key, ProFiles = g };

                foreach (var group in groupProfiles)
                {
                    Console.WriteLine($"-175cm 미만> : {group.GroupKey}");
                    foreach (var prof in group.ProFiles)
                    {
                        Console.WriteLine($">>> {prof.Name}, {prof.age}세, {prof.Height}cm");
                    }
                }
                Console.WriteLine(" ");
                // LinQ로 Join
                var innerJoinResult = from pf in profiles
                                      join pr in arrProducts
                                      on pf.Name equals pr.star
                                      select new
                                      {
                                          Name = pf.Name,
                                          Work = pr.Title,
                                          Height = pf.Height,
                                          Age = pf.Age
                                      };
                Console.WriteLine("내부조인 결과");
                foreach (var item in innerJoinResult)
                {
                    Console.WriteLine($"작품 = {item.Work}/ 이름 : {item.Name}/ 나이 = {item.Age}");
                }
                Console.WriteLine(" ");

                var outerJoinResult = from pf in profiles
                                      join pr in arrProducts
                                      on pf.Name equals pr.star 
                                      into ps // 외부조인시 내부조인 LinQ에 추가되는 부분
                                      from pr in ps.DefaultIfEmpty(new Product() { Title="작품없음"}) //외부조인시 내부조인 LinQ에 추가 되는 부분
                                      select new
                                      {
                                          Name = pf.Name,
                                          Work = pr.Title,
                                          Height = pf.Height,
                                          Age = pf.Age
                                      };
                Console.WriteLine("외부조인 결과");
                foreach (var item in outerJoinResult)
                {
                    Console.WriteLine($"작품 = {item.Work}/ 이름 : {item.Name}/ 나이 = {item.Age}");
                }
                Console.WriteLine(" ");

            }
        }
    }
}

