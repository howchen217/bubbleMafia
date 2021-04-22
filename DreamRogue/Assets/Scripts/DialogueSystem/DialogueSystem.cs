using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;
    public Image portrait;
    [SerializeField] private Animator anim;

    public static DialogueSystem instance;

    private int currentIndex;
    private Conversation currentConvo;
    private PlayerController pc;
    private Coroutine typing;

    private Inputs inputs;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Deactivate(); //we never want the dialogue panel to be active on set..
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        if (inputs != null)
        {
            inputs.Player.Nextline.Disable();
            inputs.Player.Nextline.canceled -= ctx => ReadNext(); //Always remember to close them dang inputs. 
        }
    }


    public void StartConversation(Conversation convo)
    {
        //freeze player
        PlayerController.Freeze();

        //activate box
        Activate();


        //initializing and housekeeping
        instance.currentConvo = convo;
        instance.currentIndex = 0;
        instance.dialogueText.text = "";
        instance.nameText.text = "";

        //then go to the next line immediately
        instance.ReadNext();
    }

    private void ReadNext()
    {
        if (currentIndex < currentConvo.GetLength())
        {
            if (typing == null) //if not typing, we start typing.
            {
                DialogueLine currentLine = currentConvo.GetLineByIndex(currentIndex);
                nameText.text = currentLine.speaker.GetName();
                portrait.sprite = currentLine.speaker.GetSprite(currentLine.mood);

                typing = StartCoroutine(TypeText(currentLine.dialogue, currentLine.typeSpeed));
            }
            else //if already is typing, we skip to the end of the text
            {
                StopCoroutine(typing);
                dialogueText.text = currentConvo.GetLineByIndex(currentIndex).dialogue;
                typing = null;
            }

            if (typing == null) //if not typing, we can go to next line. 
            {
                currentIndex++;
            }
        }
        else
        {
            Deactivate();
            PlayerController.UnFreeze();
        }
    }

    private void Activate()
    {
        inputs = new Inputs();
        inputs.Player.Nextline.Enable();
        inputs.Player.Nextline.canceled += ctx => ReadNext(); //basically it can do readNext with the button release event now

        anim.SetBool("isDialogueOpen", true);
    }

    private void Deactivate()
    {
        anim.SetBool("isDialogueOpen", false);
    }

    private IEnumerator TypeText(string text, float typeSpeed)
    {
        dialogueText.text = "";
        int i = 0;

        while (i < text.Length)
        {
            dialogueText.text += text[i];

            //play sound, if not a space
            if (!text[i].Equals(' ')) {
                PlayVoice();
            }

            i++;

            yield return new WaitForSeconds(typeSpeed);
        }
        typing = null;
        currentIndex++;
    }

    private void PlayVoice() 
    {
        DialogueLine currentLine = currentConvo.GetLineByIndex(currentIndex);
        SoundManager.instance.PlayOneShotRandom(currentLine.speaker.GetSpeakerVoice(),
            currentLine.speakingVolume, currentLine.speaker.GetSpeakerPitch());
    }












}
