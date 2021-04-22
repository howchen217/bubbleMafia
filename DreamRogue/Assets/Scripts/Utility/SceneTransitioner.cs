using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;


    private void Awake()
    {
        GameMaster.instance.onExitEnter += PlayAndLoad; //this is triggered by onExitEnter event
    }




    public void PlayAndLoad(string areaToLoad) {
        StartCoroutine(PlayAndLoadCoroutine(areaToLoad));
    }

    IEnumerator PlayAndLoadCoroutine(string areaToLoad)
    {
        //play animation (fading into black)
        transition.SetTrigger("Start");

        //wait for it to finish, return timescale..
        yield return new WaitForSeconds(transitionTime);

        //load the scene after we had faded out
        SceneManager.LoadScene(areaToLoad);
    }

    private void OnDestroy()
    {
        GameMaster.instance.onExitEnter -= PlayAndLoad;
    }
}
