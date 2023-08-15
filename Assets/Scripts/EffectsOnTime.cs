using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsOnTime : MonoBehaviour
{
    public Player player;

    public void EffectActivated(float time, int typeObjt)
    {
        StartCoroutine(Waiting(time, typeObjt));
    }
    IEnumerator Waiting(float time, int typeObjt)
    {
        switch (typeObjt)
        {
            case 3:
                yield return new WaitForSeconds(time);
                player.speed_of_player = player.speed_of_player / 1.5f;
                print("speed = " + player.speed_of_player);
                break;
            case 4:
                yield return new WaitForSeconds(time);
                player.jump_height = player.jump_height / 1.5f;
                print("junpheight = " + player.jump_height);
                break;
            case 5:
                yield return new WaitForSecondsRealtime(time);
                Time.timeScale = 1f;
                print("timeScale = " + Time.timeScale);
                break;
            case 6:
                yield return new WaitForSeconds(time);
                player.y_vel = false;
                player.GetComponent<Rigidbody2D>().gravityScale = 1;
                break;
        }
    }
}
