
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string areaTransitionName;
    private PlayerController pc; //I have it here to show the dependency

    private void Start() //need to call this after awake, otherwise player instance might be null
    {
        pc = PlayerController.instance;

        if (areaTransitionName == pc.areaTransitionName) {
                pc.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        PlayerController.UnFreeze(); //enable movement after load

    }

}
