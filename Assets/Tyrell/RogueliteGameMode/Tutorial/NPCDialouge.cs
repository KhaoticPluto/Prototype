using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]

public class NPCDialouge : MonoBehaviour
{
    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialougeSystem dialogueSystem;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Start()
    {
        dialogueSystem = FindObjectOfType<DialougeSystem>();
    }

    void Update()
    {
        Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        Pos.y += 175;
        ChatBackGround.position = Pos;
    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPCDialouge>().enabled = true;
        //FindObjectOfType<DialougeSystem>().EnterRangeOfNPC();
        if ((other.gameObject.tag == "Player")) // && Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<NPCDialouge>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialougeSystem>().NPCName();
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialougeSystem>().OutOfRange();
        this.gameObject.GetComponent<NPCDialouge>().enabled = false;
    }
}
