using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubes : MonoBehaviour {

    public FrostyPoolInstance CubeObject;
    private bool _started;
    private bool _running;
    private Coroutine createCubesCoroutine;
    public float Frequency;

    void Start()
    {
        if (!_started)
        {
            createCubesCoroutine = StartCoroutine(CreateCubesCoroutine());
        }
    }

    IEnumerator CreateCubesCoroutine()
    {
        while (CubeObject != null)
        {
            GameObject cube = null;
            if (Toolbox.Instance.pool.TryRetrieve(CubeObject, out cube))
            {
                cube.transform.position = new Vector3(0, 15, 0) + Vector3.Cross(Random.insideUnitSphere, new Vector3(Random.Range(-1f, 1f), 5f, Random.Range(-1f, 1f)));
                cube.transform.rotation = Quaternion.Euler(Random.insideUnitSphere * 360f);
                cube.transform.localScale = cube.transform.localScale + Random.insideUnitSphere * 0.65f * Random.Range(-1f, 1f);
            }
            yield return new WaitForSeconds(Mathf.Max(0.02f,Frequency));
        }
        _started = false;
    }
}
