# DialogueSystem
A simple Dialogue System in Unity. Includes a Dialogue Resolver class and Dialogue Node class.

# Dialogue Node
* Id : the node's unique id
* charName : the character's name that speaks the text
* dialogueText : holds the actual text of the dialogue
* nextNode : integer of the Id of the next DialogueNode

# Dialogue Resolver
Loads the dialog texts from dialogues.xml, deserializes them into Dialogue Nodes and saves them in a Dictionary using the Id of the Node class as a key. 
When the user continues the conversation the resolver can quickly find the next node in the dictionary using the DialogueNode.nextNode property.
