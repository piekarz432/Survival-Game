using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Works : MonoBehaviour
{
    [SerializeField]
    private Text shortDescription;

    [SerializeField]
    private Text longDescription;

    public List<Work> works = new List<Work>();

    // Update is called once per frame
    void Update()
    {
        foreach(Work w in works)
        {
            if(!w.IsFinished)
            {
                shortDescription.text = w.Heading;
                longDescription.text = w.Description;
                break;
            }
        }
    }
}
