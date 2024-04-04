using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AdventurerList
{
    public static List<Adventurer> Adventurers = new List<Adventurer>();

    private static Adventurer GenerateAnAdventurer()
    {
        System.Random rnd = new System.Random();
        int rankInt = rnd.Next(0, 4);
        int hp = rnd.Next(75, 100) * (rankInt + 1);
        int maxHP = hp;
        int damage = rnd.Next(8, 15) * (rankInt + 1);
        int agility = rnd.Next(1, 4) * (rankInt + 1);
        float range = UnityEngine.Random.Range(1, 10);
        Stats stats = new Stats(hp, maxHP, damage, agility, range);
        Adventurer adventurer = new Adventurer(stats);
        adventurer.rank = (Adventurer.Rank)rankInt;
        adventurer.Exhaustion = 0;
        adventurer.XP = rnd.Next(0, 50);
        return adventurer;
    }
    public static void AddAnAdventurer()
    {
        Adventurers.Add(GenerateAnAdventurer());
        QuickSort(ref Adventurers, 0, Adventurers.Count - 1);
    }
    public static void AddAnAdventurerNoSort()
    {
        Adventurers.Add(GenerateAnAdventurer());
    }
    public static void RemoveAnAdventurer(int index)
    {
        Adventurers.RemoveAt(index);
        QuickSort(ref Adventurers, 0, Adventurers.Count - 1);
    }

    public static void QuickSort(ref List<Adventurer> list, int low, int high)
    {
        if (low >= high) return;
        int i = low - 1;
        int j = low;

        while (j < high)
        {
            if (list[j].rank > list[high].rank)
            {
                i++;
                Adventurer ad = list[j];
                list[j] = list[i];
                list[i] = ad;
            }
            j++;
        }
        i++;
        Adventurer temp = list[j];
        list[j] = list[i];
        list[i] = temp;

        QuickSort(ref list, low, i - 1);
        QuickSort(ref list, i + 1, high);
    }

    public static void ExhaustAdventurers()
    {
        for(int i = 0; i < Adventurers.Count; i++)
        {
            Adventurers[i].AdjustExhaustion();
        }
    }

    public static void ClearDeads()
    {
        List<Adventurer> list = new List<Adventurer>();
        foreach(Adventurer ad in Adventurers)
        {
            if(ad.GetStats().HP <= 0 || ad.Exhaustion >= 100)
            {
                list.Add(ad);
            }
        }

        foreach(Adventurer ad in list)
        {
            Adventurers.Remove(ad);
        }
    }

    public static void Reset()
    {
        Adventurers.Clear();
    }
}
