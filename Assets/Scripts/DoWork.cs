using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoWork : MonoBehaviour
{
    [SerializeField]
    private Works works;

    [SerializeField]
    private Name names;

    public Works Works { get => works; set => works = value; }
    public Name Names { get => names; set => names = value; }

    public void finishWork(Name name)
    {
        foreach (Work w in works.works)
        {
            if (w.Name == name)
            {
                w.IsFinished = true;
            }
        }
    }
}
