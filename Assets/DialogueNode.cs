using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UIElements;

public class DialogueNode
{
    public int id { get; set; }
    public string charName { get; set; }
    public string dialogueText { get; set; }
    public int nextNode { get; set; }

    
}
