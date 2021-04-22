
using UnityEngine;


public class AreaExit : MonoBehaviour
{
    public string areaToLoad;
    public string areaTransitionName;

    private PlayerController pc; 


    private void OnTriggerEnter2D(Collider2D other)
    {
        pc = PlayerController.instance;

        if (other.tag == "Player") {

            PlayerController.Freeze();//prevent movement during load

            GameMaster.instance.exitEnter(areaToLoad); //scene transitioner subscribes to this event

            pc.areaTransitionName = areaTransitionName;

        }
    }




}
