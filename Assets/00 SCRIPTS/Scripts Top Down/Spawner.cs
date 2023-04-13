using System.Collections;
using UnityEngine;
// Xin ch�o ?
// 
// N?u c�c th?y ??c ???c ?o?n n�y s? th?y em kh�ng d�ng ObjectPooling do khi em d�ng th� em ch?a bi?t
// c�ch reset l?i m�u c?a enemy khi?n n� s? b? l?i l� khi n� d�ng l?i th� n� b?n 1 ph�t l� enemy s? die
// v� em l�m ?o?n n�y th� ?� g?n ??n th?i gian dateLine
// n�n em c?ng ko k?p t�m c�ch kh�c ph?c ? ,hi v?ng c�c th?y n?u ??c ?o?n Comment n�y  dc th� th�ng c?m cho em ?
// em c?m ?n ? 


public class Spawner : MonoBehaviour
{
    public float startTimeBtwSpawn;
    private float timeBtwSpawn;
    float time = 1;

    public GameObject[] enemies;
    private void Start()
    {
        StartCoroutine(CalculatorTime());
    }

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int randEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[randEnemy], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn/time;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

    IEnumerator CalculatorTime()
    {
       
        yield return new WaitForSeconds(30f);
        time++;

    }
}
