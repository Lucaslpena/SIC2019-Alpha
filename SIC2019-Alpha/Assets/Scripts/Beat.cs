using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat
{
    public List<string[]> _beat = new List<string[]>();

    public void PopulateBeat(string line)
    {
        string[] instruments = line.Split(',');
        _beat.Add(instruments);
    }
}
