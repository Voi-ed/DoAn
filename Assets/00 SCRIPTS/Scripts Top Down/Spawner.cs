using System.Collections;
using UnityEngine;
// Xin chào ?
// 
// N?u các th?y ??c ???c ?o?n này s? th?y em không dùng ObjectPooling do khi em dùng thì em ch?a bi?t
// cách reset l?i máu c?a enemy khi?n nó s? b? l?i là khi nó dùng l?i thì nó b?n 1 phát là enemy s? die
// và em làm ?o?n này thì ?ã g?n ??n th?i gian dateLine
// nên em c?ng ko k?p tìm cách khác ph?c ? ,hi v?ng các th?y n?u ??c ?o?n Comment này  dc thì thông c?m cho em ?
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
