using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct bounds
{
    public float min;
    public float max;
}

public class Magnetism : MonoBehaviour
{
    [Range(0,2000)]
    public int filingCount;
    public GameObject filingPrefab;
    public float delayOfSprinkling = 100f;
    [SerializeField] AudioSource src;
    [SerializeField] public bounds boundX;
    [SerializeField] public bounds boundY;
    [SerializeField] public bounds boundZ;
    private void Start()
    {
        for (int i = 0; i < filingCount; i++)
        {
            SprinkleIt();
        }
    }
    public IEnumerator StartSprinkling()
    {
        while (filingCount <= 2000)
        {
            yield return new WaitForSeconds(delayOfSprinkling * Time.deltaTime);
            SprinkleIt();
            filingCount++;
            //Debug.Log(filingCount);
        }
        if (filingCount > 2000) src.Stop();
    }
    public void SprinkleIt()
    {
        float x = Random.Range(boundX.min, boundX.max);
        float y = Random.Range(boundY.min, boundY.max);
        float z = Random.Range(boundZ.min, boundZ.max);
        Instantiate(filingPrefab, new Vector3(x, y, z), Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
    }
}
