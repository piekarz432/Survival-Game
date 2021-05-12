using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Name { CollectSword, CollectShield, EnemyFight, None};

[System.Serializable]
public class Work
{
    [SerializeField]
    private Name name;

    [SerializeField]
    private string heading;

    [SerializeField]
    private string description;

    [SerializeField]
    private bool isFinished = false;

    public string Heading { get => heading;}
    public string Description { get => description;}
    public bool IsFinished { get => isFinished; set => isFinished = value; }
    public Name Name { get => name; set => name = value; }

    public Work(string heading, string description, Name name)
    {
        this.name = name;
        this.heading = heading;
        this.description = description;
    }
}
