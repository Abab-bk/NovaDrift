﻿using System.Collections.Generic;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Systems;

public class BuffSystem
{
    public Actor Target;
    
    private readonly List<Buff> _buffs = new List<Buff>();
    
    public void AddBuff(Buff buff)
    {
        Buff checkBuff = HasBuffById(buff.Id);
        if (checkBuff != null)
        {
            RemoveBuff(checkBuff);
        }
        
        buff.Target = Target;
        buff.OnCreate();
        buff.OnDestroy += RemoveBuff;
        _buffs.Add(buff);
        Logger.Log("[Buff] Add buff: " + buff.Name);
    }

    public void RemoveBuff(Buff buff)
    {
        Logger.Log("[Buff] Remove buff: " + buff.Name);
        buff.OnDestroy -= RemoveBuff;
        buff.Destroy();
        _buffs.Remove(buff);
    }

    public bool HasBuff(Buff buff)
    {
        return _buffs.Contains(buff);
    }
    
    public Buff HasBuffById(int id)
    {
        foreach (var buff in _buffs)
        {
            if (buff.Id == id) return buff;
        }

        return null;
    }

    public void RemoveBuffById(int id)
    {
        List<Buff> removed = new List<Buff>();
        
        foreach (var buff in _buffs)
        {
            if (buff.Id != id) continue;
            
            removed.Add(buff);
            break;
        }

        foreach (var buff in removed)
        {
            RemoveBuff(buff);
        }
    }
    
    public void RemoveAllBuffs()
    {
        List<Buff> removed = new List<Buff>();
        foreach (var buff in _buffs)
        {
            removed.Add(buff);
        }

        foreach (var buff in removed)
        {
            RemoveBuff(buff);
        }
    }
}