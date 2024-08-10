using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tmp_dialogue : MonoBehaviour
{
    public TMP_Text tmp_text;
    private string sentences = ". . .";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDialogueCoroutine());
    }

    IEnumerator StartDialogueCoroutine()
    {
        tmp_text.text = "";
        for (int i = 0; i < sentences.Length; ++i)
        {
            tmp_text.text += sentences[i]; // 1글자씩 출력
            yield return new WaitForSeconds(0.5f);
        }
    }

}
