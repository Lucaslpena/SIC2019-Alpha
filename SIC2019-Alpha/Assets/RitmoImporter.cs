using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitmoImporter : MonoBehaviour
{
    public TextAsset TextFile;

    private void Awake()
    {
        readTextFileLines();
    }

    void readTextFileLines()
    {
        string[] linesInFile = TextFile.text.Split('\n');

        foreach (string line in linesInFile)
        {
            Debug.Log(line);
        }

    }
}
