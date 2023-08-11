using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float speed;
    public float waittime;
    public Transform[] points;
    bool canMoveUp = true;
    bool canMoveDown = true;
    bool canMoveLeft = true;
    bool canMoveRight = true;
    public Transform rand;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SwimingWithoutPlayer(waittime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SwimingWithoutPlayer(float waittime)
    {
        /*RaycastHit2D groundinfoDown = Physics2D.Raycast(transform.position, Vector2.down, 1f);
        RaycastHit2D groundinfoLeft = Physics2D.Raycast(transform.position, Vector2.left, 1f);
        RaycastHit2D groundinfoRight = Physics2D.Raycast(transform.position, Vector2.right, 1f);
        RaycastHit2D groundinfoUp = Physics2D.Raycast(transform.position, Vector2.up, 1f);*/
        
        //Проверка может ли рыба двигаться вверх
        if (transform.position.y <= points[0].position.y)
        {
            canMoveUp = true;
        }
        else
        {
            canMoveUp = false;
        }

        //Проверка может ли рыба двигаться вниз
        if (transform.position.y >= points[2].position.y)
        {
            canMoveDown = true;
        }
        else
        {
            canMoveDown = false;
        }

        //Проверка может ли рыба двигаться влево
        if (transform.position.x >= points[3].position.x)
        {
            canMoveLeft = true;
        }
        else
        {
            canMoveLeft = false;
        }

        //Проверка может ли рыба двигаться вправо
        if (transform.position.x <= points[2].position.x)
        {
            canMoveRight = true;
        }
        else
        {
            canMoveRight = false;
        }


        //Движение рыбы
        switch (canMoveDown,canMoveLeft,canMoveRight,canMoveUp)
        {
            case (true,true,true,true): // сработает если можем двигаться во все стороны
                do
                {
                    float a = Random.Range(-100f, 100f);
                    rand.position = new Vector3(transform.position.x + a, transform.position.y + Random.Range(-2f, 2f), transform.position.z);
                    //print("a equals " + a);
                }
                while (rand.position.x > points[0].position.x || rand.position.x < points[1].position.x || rand.position.y < points[2].position.y || rand.position.y > points[0].position.y);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(rand.position.y - transform.position.y, rand.position.x - transform.position.x) * Mathf.Rad2Deg - 180);
                transform.position = Vector3.Lerp(transform.position, rand.position, speed * Time.deltaTime);
                if (transform.position == rand.position)
                {
                    print("case 1");
                }
                break;

            case (false, true, true, true): // сработает если не можем двигаться вниз
                do
                {
                    rand.position = new Vector3(transform.position.x + Random.Range(-10f, 10f), transform.position.y + Random.Range(1f, 4f), transform.position.z);
                }
                while (rand.position.x > points[0].position.x || rand.position.x < points[1].position.x || rand.position.y < points[2].position.y || rand.position.y > points[0].position.y);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(rand.position.y - transform.position.y, rand.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
                transform.position = Vector3.Lerp(transform.position, rand.position, speed * Time.deltaTime);
                print("case 2");
                break;

            case (false, true, false, true): // сработает если не можем двигаться вниз и вправо
                do
                {
                    rand.position = new Vector3(transform.position.x + Random.Range(-20f, -10f), transform.position.y + Random.Range(1f, 4f), transform.position.z);
                }
                while (rand.position.x > points[0].position.x || rand.position.x < points[1].position.x || rand.position.y < points[2].position.y || rand.position.y > points[0].position.y);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(rand.position.y - transform.position.y, rand.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
                transform.position = Vector3.Lerp(transform.position, rand.position, speed * Time.deltaTime);
                print("case 3");
                break;  

            case (false, false, true, true): // сработает если не можем двигаться вниз и влево
                do
                {
                    rand.position = new Vector3(transform.position.x + Random.Range(10f, 20f), transform.position.y + Random.Range(1f, 4f), transform.position.z);
                }
                while (rand.position.x > points[0].position.x || rand.position.x < points[1].position.x || rand.position.y < points[2].position.y || rand.position.y > points[0].position.y);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(rand.position.y - transform.position.y, rand.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
                transform.position = Vector3.Lerp(transform.position, rand.position, speed * Time.deltaTime);
                print("case 4");
                break;

            case (true, true, true, false): // сработает если не можем двигаться вверх
                do
                {
                    rand.position = new Vector3(transform.position.x + Random.Range(-10f, 10f), transform.position.y + Random.Range(-4f, -1f), transform.position.z);
                }
                while (rand.position.x > points[0].position.x || rand.position.x < points[1].position.x || rand.position.y < points[2].position.y || rand.position.y > points[0].position.y);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(rand.position.y - transform.position.y, rand.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
                transform.position = Vector3.Lerp(transform.position, rand.position, speed * Time.deltaTime);
                print("case 5");
                break;

            case (true, true, false, false): // сработает если не можем двигаться вверх и вправо
                do
                {
                    rand.position = new Vector3(transform.position.x + Random.Range(-20f, -10f), transform.position.y + Random.Range(-4f, -1f), transform.position.z);
                }
                while (rand.position.x > points[0].position.x || rand.position.x < points[1].position.x || rand.position.y < points[2].position.y || rand.position.y > points[0].position.y);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(rand.position.y - transform.position.y, rand.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
                transform.position = Vector3.Lerp(transform.position, rand.position, speed * Time.deltaTime);
                print("case 6");
                break;

            case (true, false, true, false): // сработает если не можем двигаться вверх и влево
                do
                {
                    rand.position = new Vector3(transform.position.x + Random.Range(10f, 20f), transform.position.y + Random.Range(-4f, -1f), transform.position.z);
                }
                while (rand.position.x > points[0].position.x || rand.position.x < points[1].position.x || rand.position.y < points[2].position.y || rand.position.y > points[0].position.y);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(rand.position.y - transform.position.y, rand.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
                transform.position = Vector3.Lerp(transform.position, rand.position, speed * Time.deltaTime);
                print("case 7");
                break;

            case (true, false, true, true): // сработает если не можем двигаться влево
                do
                {
                    rand.position = new Vector3(transform.position.x + Random.Range(10f, 20f), transform.position.y + Random.Range(-2f, 2f), transform.position.z);
                }
                while (rand.position.x > points[0].position.x || rand.position.x < points[1].position.x || rand.position.y < points[2].position.y || rand.position.y > points[0].position.y);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(rand.position.y - transform.position.y, rand.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
                transform.position = Vector3.Lerp(transform.position, rand.position, speed * Time.deltaTime);
                print("case 8");
                break;

            case (true, true, false, true): // сработает если не можем двигаться вправо
                do
                {
                    rand.position = new Vector3(transform.position.x + Random.Range(-20f, -10f), transform.position.y + Random.Range(-2f, 2f), transform.position.z);
                }
                while (rand.position.x > points[0].position.x || rand.position.x < points[1].position.x || rand.position.y < points[2].position.y || rand.position.y > points[0].position.y);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(rand.position.y - transform.position.y, rand.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
                transform.position = Vector3.Lerp(transform.position, rand.position, speed * Time.deltaTime);
                print("case 9");
                break;
            default:
                print("Ошибка Case");
                break;

            
        }

        yield return new WaitForSeconds(waittime);
        StartCoroutine(SwimingWithoutPlayer(waittime));
    }
}
