using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuCar : MonoBehaviour
{
    [SerializeField]private List<GameObject> carModels;
    [SerializeField]private Transform initialPosition;
    private float x = 0f;
    private float Timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > 1f)
        {
            SpawnCar();
        }
    }
    private void SpawnCar()
    {
        int index = Random.Range(0, carModels.Count);
        float x = Random.Range(-3f, 3f);

        Vector3 pos = new Vector3(x, initialPosition.position.y, initialPosition.position.z);
        Instantiate(carModels[index], pos, Quaternion.Euler(0f, 180f, 0));
    }
}
