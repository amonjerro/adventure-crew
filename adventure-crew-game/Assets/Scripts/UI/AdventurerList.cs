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
        int hp = rnd.Next(8, 16);
        int maxHP = hp;
        int damage = rnd.Next(1, 4);
        int agility = rnd.Next(1, 4);
        float range = UnityEngine.Random.Range(1, 5);
        Stats stats = new Stats(hp, maxHP, damage, agility, range);
        Adventurer adventurer = new Adventurer(stats);
        adventurer.Exhaustion = rnd.Next(15, 20);
        adventurer.XP = rnd.Next(0, 50);
        return adventurer;
    }
    public static void AddAnAdventurer()
    {
        Adventurers.Add(GenerateAnAdventurer());
        QuickSort(ref Adventurers, 0, Adventurers.Count - 1);
    }
    public static void RemoveAnAdventurer(int index)
    {
        Adventurers.RemoveAt(index);
        QuickSort(ref Adventurers, 0, Adventurers.Count - 1);
    }

    private static void QuickSort(ref List<Adventurer> list, int low, int high)
    {
        if (low >= high) return;
        int i = low - 1;
        int j = low;

        while (j < high)
        {
            if (list[j].XP > list[high].XP)
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
}
