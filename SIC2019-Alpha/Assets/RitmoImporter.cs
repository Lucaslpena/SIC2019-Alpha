using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitmoImporter : MonoBehaviour
{
    public BeatController BeatController;
    public TextAsset TextFile;
    private Beat Beat;

    private void Awake()
    {
        Beat = new Beat();
        readTextFileLines();
    }

    void readTextFileLines()
    {
        string[] linesInFile = TextFile.text.Split('\n');

        foreach (string line in linesInFile)
        {
            Beat.PopulateBeat(line);
        }
        BeatController.Beat = Beat;
    }
}
