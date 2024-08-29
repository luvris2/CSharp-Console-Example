using System.Diagnostics;
using System.Text;

namespace CSharp_Console_Example
{
    public static class StringBuilderExample
    {
        public static void Main()
        {
            Console.WriteLine("### StringBuilder로 문자열 조작하기 ###\n\"Eunbyeol\"이라는 문자열을 통해 문자열을 조작해보자.\n");
            ControlStringBuilder();

            Console.WriteLine($"### String 객체와 STringBuilder 객체 비교하기 ###\n각각 \"Hello Eunbyeol World!\"라는 글자를 만 번씩 반복하여 문자열을 추가하고 메모리 사용량을 비교해보자.\n");
            InputString();
            InputStringBuilder();
        }

        static void ControlStringBuilder()
        {
            StringBuilder sb = new StringBuilder("Eunbyeol");
            Console.WriteLine($"[StringBuilder 객체 생성 및 초기화]\t\t:\tsb = {sb}");

            sb.Append(" World!");
            Console.WriteLine($"[Append] 뒤에 글자 추가 \" World!\"\t\t:\tsb = {sb}");

            sb.Insert(0, "Hello ");
            Console.WriteLine($"[Insert] 인덱스 0번째에 글자 삽입\"Hello \"\t:\tsb = {sb}");

            sb.Replace("Eunbyeol", "Eunbyeol`s");
            Console.WriteLine($"[Replace] \"Eunbyeol\"글자를 \"Eunbyeol`s\"로 변경\t:\tsb = {sb}");

            sb.Remove(6, 11);
            string finalString = sb.ToString(); // string 문자열로 변경
            Console.WriteLine($"[Remove] 인덱스와 글자 길이로 \"Eunbyeol`s\" 제거\t:\tsb = {finalString}");

            sb.Clear();
            Console.WriteLine($"[Clear] 모든 내용 제거\t\t\t\t:\tsb = {sb}\n");

            StringBuilder sb2 = new StringBuilder();
            sb2.AppendLine("1");
            sb2.AppendLine("2");
            sb2.AppendLine("3");
            Console.WriteLine($"[AppendLine] 문자 1, 2, 3 각각 줄로 추가하기\nsb2\n===\n{sb2}===\n");

        }

        static void InputString()
        {
            // 메모리 사용량 및 시간 측정
            long initialMemory = GC.GetTotalMemory(true);
            Stopwatch stopwatch = Stopwatch.StartNew();

            string result = "";
            long checkMemory = GC.GetTotalMemory(true);

            // 10,000번의 반복으로 문자열에 내용을 추가
            for (int i = 0; i < 10000; i++)
            {
                result += "Hello Eunbyeol World!";  // 문자열 연결
            }

            stopwatch.Stop();
            long finalMemory = GC.GetTotalMemory(true);

            print("String", stopwatch, initialMemory, checkMemory, finalMemory);
        }

        static void InputStringBuilder()
        {
            // 메모리 사용량 및 시간 측정
            long initialMemory = GC.GetTotalMemory(true);
            Stopwatch stopwatch = Stopwatch.StartNew();

            StringBuilder result = new StringBuilder();
            long checkMemory = GC.GetTotalMemory(true);

            // 10,000번의 반복으로 문자열에 내용을 추가
            for (int i = 0; i < 10000; i++)
            {
                result.Append("Hello");  // 문자열 추가
            }

            stopwatch.Stop();
            long finalMemory = GC.GetTotalMemory(true);

            print("String", stopwatch, initialMemory, checkMemory, finalMemory);
        }

        static void print(string type, Stopwatch stopwatch, long initialMemory, long checkMemory, long finalMemory)
        {
            Console.WriteLine($"[{type} 사용 완료]");
            Console.WriteLine(" - 소요 시간: " + stopwatch.ElapsedMilliseconds + "ms");
            Console.WriteLine(" - 변수 생성에 사용된 메모리 : " + (checkMemory - initialMemory) + " bytes");
            Console.WriteLine(" - 메모리 사용량: " + (finalMemory - initialMemory) + " bytes");
        }
    }
}
