using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Conversation convo;
    private FinishedTriggerSet finishedTriggersSet;
    private string ID;

    private void Start()
    {
        finishedTriggersSet = FindObjectOfType<FinishedTriggerSet>();
        ID = GetComponent<UniqueID>().ID;
        if (finishedTriggersSet.finishedTriggers.Contains(ID)) 
        {
            gameObject.SetActive(false); //if already finished, set it inactive on start
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {

            finishedTriggersSet.AddTrigger(ID);
            DialogueSystem.instance.StartConversation(convo);
            gameObject.SetActive(false);
        }
    }


}
