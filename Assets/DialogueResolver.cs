using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class DialogueResolver : MonoBehaviour
{
    public Text textDisplay;
    //public List<DialogueNode> dialogueNodes;
    public Dictionary<int, DialogueNode> dialogueNodes;
    private int currentDialog = 1;
    public float typingSpeed;
    string dialoguesXML = "Assets/dialogues.xml";

    // Start is called before the first frame update
    void Start()
    {
        LoadXML();
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadXML()
    {
        string xmlString = File.ReadAllText(dialoguesXML);
        XmlSerializer serializer = new XmlSerializer(typeof(List<DialogueNode>), new XmlRootAttribute("nodes"));
        StringReader stringReader = new StringReader(xmlString);

        List<DialogueNode> dialogueUnsorted = serializer.Deserialize(stringReader) as List<DialogueNode>;
        dialogueNodes = dialogueUnsorted.ToDictionary(d => d.id);
        //dialogueNodes = dialogueUnsorted.OrderBy(q => q.id).ToList();

    }

    void WriteXML()
    {
        /*DialogueNode node = new DialogueNode();
        node.id = 10;
        node.dialogueText = "Testing serialization";
        dialogueNodes.Add(node);*/
        TextWriter writer = new StreamWriter(dialoguesXML);
        XmlSerializer serializer = new XmlSerializer(typeof(List<DialogueNode>), new XmlRootAttribute("nodes"));
        serializer.Serialize(writer, dialogueNodes);
        writer.Close();
    }

    IEnumerator Type()
    {
        foreach (char letter in dialogueNodes[currentDialog].dialogueText.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void nextSentence()
    {

        currentDialog = dialogueNodes[currentDialog].nextNode;
        textDisplay.text = "";
        if (currentDialog != 0)
        {
            StartCoroutine(Type());
        }

    }

}
