﻿namespace NovaDrift.Scripts.Systems;

public interface IItemInfo
{
    public string Name { get; }
    public string Desc { get; }
    public string IconPath { get; }
    
    public void Use();
}