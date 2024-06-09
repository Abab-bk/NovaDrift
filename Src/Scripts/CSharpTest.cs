using System;

namespace NovaDrift.Scripts;

public class CSharpTest
{
    private int _sawBossCount = 1;
    private int[] _bossIds = [1001, 1002, 1003];
    
    public void Test1()
    {
        for (int i = 0; i < 20; i++)
        {
            var index = (_sawBossCount - 1) % _bossIds.Length;

            Console.WriteLine($"""
                               目标索引：{index} 目标BossId: {_bossIds[index]} 当前_sawBossCount： {_sawBossCount}
                               """);
            _sawBossCount += 1;
        }
    }
}

public static class Tester
{
    public static void RunTest()
    {
        var t = new CSharpTest();
        t.Test1();
    }
}