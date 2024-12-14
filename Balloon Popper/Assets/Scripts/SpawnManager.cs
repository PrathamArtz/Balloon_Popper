using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _ballon;
    public GameObject[] ballon;
    [SerializeField]
    private float _spawnTime = 3f;

    [SerializeField] private GameObject _PrefabContainer;


    private void Start()
    {
        StartCoroutine(spawnroutine());
    }

    IEnumerator spawnroutine()
    {
        while (true)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-2, 2), 0, 0);
            // GameObject newEnemy = Instantiate(_ballon, spawnPos, Quaternion.identity);
            int randomIndex = Random.Range(0, ballon.Length);
            GameObject newEnemy = Instantiate(ballon[randomIndex], spawnPos, Quaternion.identity);
            newEnemy.transform.parent = _PrefabContainer.transform;
            yield return new WaitForSeconds(_spawnTime);
        }

    }
}
