using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [TextArea(1,2)]
    public string[] senteces;
    public Sprite[] sprites;
    public int[] player_or_not;
}