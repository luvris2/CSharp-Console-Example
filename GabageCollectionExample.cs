namespace CSharp_Console_Example
{
    public static class GabageCollectionExample
    {
        internal class SampleObject
        {
            public int Value { get; set; }
        }

        public static void Main()
        {
            Console.WriteLine($"### 가비지 컬렉터 사용해보기 ###\n빈 객체를 만 번 생성하여 사용하지 않는 객체를 가비지 컬렉터로 메모리 자원을 해제해보자.\n");
            // 메모리 사용량 측정을 위해 초기 메모리 사용량 출력
            Console.WriteLine("Initial memory usage: " + GC.GetTotalMemory(false) + " bytes");

            // 객체를 생성하여 메모리 사용량 증가
            CreateObjects();

            // 가비지 컬렉션 실행 전 메모리 사용량 출력
            Console.WriteLine("Memory usage before GC: " + GC.GetTotalMemory(false) + " bytes");

            // 가비지 컬렉션 강제 실행
            GC.Collect();
            GC.WaitForPendingFinalizers(); // 모든 Finalize 메서드가 호출될 때까지 기다림

            // 가비지 컬렉션 실행 후 메모리 사용량 출력
            Console.WriteLine("Memory usage after GC: " + GC.GetTotalMemory(false) + " bytes");
        }

        static void CreateObjects()
        {
            for (int i = 0; i < 10000; i++)
            {
                SampleObject obj = new SampleObject { Value = i };
                // 객체를 사용하지 않으므로 GC가 수집할 수 있음
            }
        }
    }
}
