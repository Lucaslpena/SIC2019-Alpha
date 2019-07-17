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

    public Transform minBoundary;
    public Transform maxBoundary;

    public GameObject KickPrefab, HatOpenPrefab, HatClosedPrefab, SnarePrefab;
    public Transform Kick, HatO, HatC, Snare;

    public List<GameObject> _hatsO { get; private set; }
    public List<GameObject> _snares { get; private set; }
    public List<GameObject> _kicks { get; private set; }
    public List<GameObject> _hatsC { get; private set; }

    private float UnityTempo;
    public float Tempo = 60;


    // Start is called before the first frame update
    void Start()
    {
        UnityTempo =  Tempo / TEMPO_CONSTANT;

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

    private void IstantiateBeatCube()
    {
        int randomCube = (int)Random.Range(0, 4);
        switch (randomCube)
        {
            case (int)CubeType.HatO:
                GameObject gHO = CreateCube(HatO, HatOpenPrefab);
                gHO.GetComponent<CubeBehaviour>().SetCubeType((int)CubeType.HatO);
                _hatsO.Add(gHO);
                //Debug.Log(_hatsO.Count);
                break;
            case (int)CubeType.Snare:
                GameObject gS = CreateCube(Snare, SnarePrefab);
                gS.GetComponent<CubeBehaviour>().SetCubeType((int)CubeType.Snare);
                _snares.Add(gS);
                //Debug.Log(_snares.Count);
                break;
            case (int)CubeType.Kick:
                GameObject gC = CreateCube(Kick, KickPrefab);
                gC.GetComponent<CubeBehaviour>().SetCubeType((int)CubeType.Kick);
                _kicks.Add(gC);
                //Debug.Log(_kicks.Count);
                break;
            case (int)CubeType.HatC:
                GameObject gHC = CreateCube(HatC, HatClosedPrefab);
                gHC.GetComponent<CubeBehaviour>().SetCubeType((int)CubeType.HatC);
                _hatsC.Add(gHC);
                //Debug.Log(_hatsC.Count);
                break;
        }
    }

    private GameObject CreateCube(Transform cubePosition, GameObject cube)
    {
        Vector3 randomCubePosition = cubePosition.position + new Vector3(0, 0, Tempo * Random.Range(1,2));
        GameObject g = Instantiate(cube, randomCubePosition, Quaternion.identity, this.transform);
        g.transform.localScale = Vector3.one * 20f;
        return g;
    }

    private IEnumerator SpawnCube()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            IstantiateBeatCube();
        }
    }

    public void DisposeCube(GameObject cube, int cubeType)
    {
        Debug.Log("cubeType: " + cubeType);
        switch (cubeType)
        {
            case (int)CubeType.HatO:
                Debug.Log("before: " + _hatsO.Count + " name cube: " + cube.name);
                _hatsO.Remove(cube);
                Debug.Log("after " + _hatsO.Count);
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
