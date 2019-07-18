using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatController : MonoBehaviour
{
    private const float TEMPO_CONSTANT = 0.6f; // considering 100 units of Unity as 1 meter

    public enum CubeType
    {
        HatO,
        Snare,
        Kick,
        HatC
    }

    public GameObject KickPrefab, HatOpenPrefab, HatClosedPrefab, SnarePrefab;
    public Transform Kick, HatO, HatC, Snare;

    public List<GameObject> _hatsO { get; private set; }
    public List<GameObject> _snares { get; private set; }
    public List<GameObject> _kicks { get; private set; }
    public List<GameObject> _hatsC { get; private set; }

    public Beat Beat;

    private int quartina;

    //private float UnityTempo;
    public float Tempo = 60;


    // Start is called before the first frame update
    void Start()
    {
        //UnityTempo =  Tempo / TEMPO_CONSTANT;
        quartina = 0;
        _hatsO = new List<GameObject>();
        _snares = new List<GameObject>();
        _kicks = new List<GameObject>();
        _hatsC = new List<GameObject>();

        StartCoroutine(SpawnCube());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void IstantiateCube(int instrument)
    {
        switch (instrument)
        {
            case (int)CubeType.HatO:
                GameObject gHO = CreateCube(HatO, HatOpenPrefab);
                gHO.GetComponent<CubeBehaviour>().SetCubeType((int)CubeType.HatO);
                _hatsO.Add(gHO);
                Debug.Log("Hat");
                break;
            case (int)CubeType.Snare:
                GameObject gS = CreateCube(Snare, SnarePrefab);
                gS.GetComponent<CubeBehaviour>().SetCubeType((int)CubeType.Snare);
                _snares.Add(gS);
                Debug.Log("Snare");
                break;
            case (int)CubeType.Kick:
                GameObject gC = CreateCube(Kick, KickPrefab);
                gC.GetComponent<CubeBehaviour>().SetCubeType((int)CubeType.Kick);
                _kicks.Add(gC);
                Debug.Log("Kick");
                break;
            case (int)CubeType.HatC:
                GameObject gHC = CreateCube(HatC, HatClosedPrefab);
                gHC.GetComponent<CubeBehaviour>().SetCubeType((int)CubeType.HatC);
                _hatsC.Add(gHC);
                Debug.Log("HC");
                break;
        }
    }

    private void IstantiateBeatCube()
    {
        if(quartina == Beat._beat.Count)
        {
            quartina = 0;
        }
        string[] instruments = Beat._beat[quartina];
        for(int i = 0; i<instruments.Length; i++)
        {
            Debug.Log("siamo con la I: " + i + " ---> " + instruments[i]);
            if (CheckInstruments(instruments[i]))
            {
                IstantiateCube(i);
            }
        }
        quartina++;
    }

    private bool CheckInstruments(string s)
    {
        if (s.Equals("1"))
        {
            return true;
        } else
        {
            return false;
        }

    }

    private GameObject CreateCube(Transform cubePosition, GameObject cube)
    {
        GameObject g = Instantiate(cube, cubePosition.position + new Vector3(0, 0, 60 * 2), Quaternion.identity, this.transform);
        g.transform.localScale = Vector3.one * 20f;
        return g;
    }

    private IEnumerator SpawnCube()
    {
        while (true)
        {
            yield return new WaitForSeconds(60/Tempo);
            IstantiateBeatCube();
        }
    }

    public void DisposeCube(GameObject cube, int cubeType)
    {
        switch (cubeType)
        {
            case (int)CubeType.HatO:
                _hatsO.Remove(cube);
                break;
            case (int)CubeType.Snare:
                _snares.Remove(cube);
                Debug.Log(_snares.Count);
                break;
            case (int)CubeType.Kick:
                _kicks.Remove(cube);
                Debug.Log(_kicks.Count);
                break;
            case (int)CubeType.HatC:
                _hatsC.Remove(cube);
                Debug.Log(_hatsC.Count);

                break;
        }
        Destroy(cube);
    }


}
