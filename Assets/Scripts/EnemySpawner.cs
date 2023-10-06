using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject Raider, Flock, Interceptor, Kamikaze;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    public void SpawnColumn(int _numberOfShips)
    {
        gameManager.CurrentNumberOfShips += _numberOfShips;
        StartCoroutine(ColumnSpawnCoroutine(_numberOfShips));
    }

    public void SpawnRandom(int _numberOfShips)
    {
        gameManager.CurrentNumberOfShips += _numberOfShips;
        StartCoroutine(RandomSpawnCoroutine(_numberOfShips));
    }

    public void SpawnKamikaze(int _numberOfShips)
    {
        gameManager.CurrentNumberOfShips += _numberOfShips;
        StartCoroutine(KamikazeSpawnCoroutine(_numberOfShips));
    }

    public void SpawnFlock()
    {
        gameManager.CurrentNumberOfShips += 5;

        //Transform randomPosition = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        Vector3 randomPosition = new Vector3(Random.Range(-20, 20), 80, 0);

        Instantiate(Flock, randomPosition, Flock.transform.rotation);
    }
    
    public void SpawnInterceptor(int _numberOfShips)
    {
        gameManager.CurrentNumberOfShips += _numberOfShips;
        StartCoroutine(InterceptorSpawnCoroutine(_numberOfShips));
    }

    IEnumerator ColumnSpawnCoroutine(int _numberOfShips)
    {
        Vector3 randomPosition = new Vector3(Random.Range(-20, 20), 60, 0);

        for (int i = 0; i < _numberOfShips; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(Raider, randomPosition, Raider.transform.rotation);
        }

        yield return null;
    }

    IEnumerator RandomSpawnCoroutine(int _numberOfShips)
    {

        for (int i = 0; i < _numberOfShips; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-20, 20), 60, 0);
            yield return new WaitForSeconds(0.5f);
            Instantiate(Raider, randomPosition, Raider.transform.rotation);
        }

        yield return null;
    }

    IEnumerator KamikazeSpawnCoroutine(int _numberOfShips)
    {
        //Vector3 randomPosition = new Vector3(Random.Range(-100, 100), 100f, 0);
        Transform randomPosition = SpawnPoints[Random.Range(0, SpawnPoints.Length)];


        for (int i = 0; i < _numberOfShips; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(Kamikaze, randomPosition.position, Kamikaze.transform.rotation);
        }

        yield return null;
    }

    IEnumerator InterceptorSpawnCoroutine(int _numberOfShips)
    {

        for (int i = 0; i < _numberOfShips; i++)
        {
            Transform randomPosition = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
            yield return new WaitForSeconds(0.5f);
            //Instantiate(Interceptor, randomPosition.position, Interceptor.transform.rotation);
            Instantiate(Interceptor, randomPosition.position, randomPosition.rotation);
        }

        yield return null;
    }

}
