using CSharp_Console_Example;

bool state = true;
while (state)
{
    try
    {
        Console.WriteLine("========================================");
        Console.WriteLine("[1] 가비지 컬렉션 샘플 코드");
        Console.WriteLine("[2] 스트링과 스트링빌더 비교 샘플 코드");
        Console.WriteLine("[q] 종료");
        Console.WriteLine("========================================");
        Console.WriteLine("확인할 샘플 클래스의 번호를 입력해주세요. : ");
        string input = Console.ReadLine();
        Console.WriteLine("\r\n");

        switch (input)
        {
            case "1":
                GabageCollectionExample.Main();
                break;
            case "2":
                StringBuilderExample.Main();
                break;
            case "q":
                Environment.Exit(0);
                break;
            default:
                break;
        }

        Console.WriteLine("\r\n");
    }
    catch (Exception e)
    {
        continue;
    }

}
