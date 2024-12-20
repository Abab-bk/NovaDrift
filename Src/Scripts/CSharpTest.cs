﻿using System;
using AcidWallStudio.AcidUtilities;
using NovaDrift.addons.AcidUtilities;

namespace NovaDrift.Scripts;

public class CSharpTest
{
    public static void EncryptorTest()
    {
        var content = "[Coins][1000]";
        var code = Encryptor.Encode(content);
        Console.WriteLine($"加密: {code}");
        Console.WriteLine($"解密: {Encryptor.Decode(code)}");
    }

    public static void Test1()
    {
        for (int i = 1; i < 101; i++)
        {
            var exp = GetNextLevelExp(i);
            Console.WriteLine($"""
                               Level {i} exp: {exp}
                               需要击杀 {exp / (1.5 * MathF.Max(i - 1, 1))} 只怪物
                               """);
        }
    }
    
    public static float GetNextLevelExp(int level)
    {
        float nextLevelExp = 0;
        
        if (level == 1)
        {
            nextLevelExp = 5f;
        }
        else if (level <= 20)
        {
            nextLevelExp = level * 10;
        }
        else if (level <= 40)
        {
            nextLevelExp = level * 13;
        }
        else
        {
            nextLevelExp = level * 16;
        }

        return nextLevelExp;
    }
}
