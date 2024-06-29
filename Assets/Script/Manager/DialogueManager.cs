using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    public TMP_Text tmp_text; // 대화 상자를 출력할 
    public SpriteRenderer rendererSprite; // 일러스트를 출력함

    public List<string> listSentences;
    public List<Sprite> listSprites;
    public List<int> player_or_not;

    private int count;

    // public Animator animSprite;
    public Animator animDialogueWindow;

    public bool talking;

    public GameObject player_img_object;
    public GameObject NPC_img_object;

    private Image player_img;
    private Image NPC_img;

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
        animDialogueWindow = GetComponent<Animator>();
        player_img = player_img_object.GetComponent<Image>();
        NPC_img = NPC_img_object.GetComponent<Image>();
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

    // 초기화
    void Start()
    {
        count = 0;
        tmp_text.text = ""; // 현재 text 초기화
        listSentences = new List<string>(); // 변수 선언
        listSprites = new List<Sprite>();
        player_or_not = new List<int>();
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        talking = true;

        for (int i = 0; i < dialogue.senteces.Length; ++i)
        {
            listSentences.Add(dialogue.senteces[i]);
            listSprites.Add(dialogue.sprites[i]);
            player_or_not.Add(dialogue.player_or_not[i]);
        }
        animDialogueWindow.SetBool("IsDialogueBegin", true);
        StartCoroutine(StartDialogueCoroutine());
    }

    public void ExitDialogue()
    {
        tmp_text.text = "";
        count = 0;
        listSentences.Clear();
        listSprites.Clear();
        player_or_not.Clear();
        // animSprite.SetBool("Appear", false);
        talking = false;
        animDialogueWindow.SetBool("PlayerSaying", false);
        animDialogueWindow.SetBool("NPCSaying", false);
        animDialogueWindow.SetBool("IsDialogueBegin", false);
    }

    IEnumerator StartDialogueCoroutine()
    {
        tmp_text.text = "";
        if (player_or_not[count] == 1)
        {
            animDialogueWindow.SetBool("PlayerSaying", true);
            animDialogueWindow.SetBool("NPCSaying", false);
        }
        else
        {
            animDialogueWindow.SetBool("PlayerSaying", false);
            animDialogueWindow.SetBool("NPCSaying", true);
            if (listSprites[count] != listSprites[count - 1])
            {
                NPC_img.sprite = listSprites[count];
                // animSprite.SetBool("Change", false);
            }
            yield return new WaitForSeconds(0.1f);
        }
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