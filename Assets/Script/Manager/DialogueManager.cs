using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using tmp_textro;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    public tmp_text_Text tmp_text;
    public SpriteRenderer rendererSprite;
    public SpriteRenderer rendererDialogueWindow;

    public List<string> listSentences;
    public List<Sprite> listSprites;
    public List<Sprite> listDialogueWindow;

    private int count;

    public Animator animSprite;
    public Animator animDialogueWindow;

    public bool talking;

    #region Singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != null)
        {
            Destroy(this.gameObject);
        }
    }

    public static DialogueManager Instance
    {
        get
        {
            if (null == DialogueManager.instance)
            {
                return null;
            }
            return DialogueManager.instance;
        }
    }

    #endregion Singleton

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        tmp_text.text = "";
        listSentences = new List<string>();
        // listSprites = new List<Sprite>();
        // listDialogueWindow = new List<Sprite>();
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        talking = true;

        for (int i = 0; i < dialogue.senteces.Length; ++i)
        {
            listSentences.Add(dialogue.senteces[i]);
            // listSprites.Add(dialogue.sprites[i]);
            // listDialogueWindow.Add(dialogue.dialogueWindowns[i]);
        }
        // animSprite.SetBool("Appear", true);
        // animDialogueWindow.SetBool("Appear", true);
        StartCoroutine(StartDialogueCoroutine());
    }

    public void ExitDialogue()
    {
        tmp_text.text = "";
        count = 0;
        listSentences.Clear();
        // listSprites.Clear();
        // listDialogueWindow.Clear();
    //     animSprite.SetBool("Appear", false);
    //     animDialogueWindow.SetBool("Appear", false);
        talking = false;
    }

    IEnumerator StartDialogueCoroutine()
    {
        tmp_text.text = "";
        // if (listSprites[count] != listSprites[count - 1])
        // {
        //     // animSprite.SetBool("Change", true);
        //     // animDialogueWindow.SetBool("appear", true);
        //     yield return new WaitForSeconds(0.1f);
        //     // rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites[count];
        //     // animSprite.SetBool("Change", false);
        // }
        for (int i = 0; i < listSentences[count].Length; ++i)
        {
            tmp_text.text += listSentences[count][i]; // 1글자씩 출력
            yield return new WaitForSeconds(0.01f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (talking)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                count++;
                if (count == listSentences.Count)
                {
                    StopAllCoroutines();
                    ExitDialogue();
                }
                else
                {
                    StopAllCoroutines();
                    StartCoroutine(StartDialogueCoroutine());
                }
            }            
        }
    }
}