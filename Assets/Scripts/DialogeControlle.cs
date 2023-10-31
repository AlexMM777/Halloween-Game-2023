using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DialogeControlle : MonoBehaviour
{
    public TextDialogueCanvas textDialogueCanvas;
    bool hasPlayedParent;
    bool hasPlayedSquad;
    bool hasPlayedGiverHouse1;
    bool goToHouse1;
    bool goToPuzzleHouse1;
    string speaker = "me";
    public GameObject house1Target;
    public GameObject squadObject;
    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        if (hasPlayedSquad && !textDialogueCanvas.dialogueInUse && !goToHouse1)
        {
            goToHouse1 = true;
            squadObject.transform.GetChild(0).GetComponent<NavMeshAgent>().SetDestination(house1Target.transform.position);
            squadObject.transform.GetChild(1).GetComponent<NavMeshAgent>().SetDestination(house1Target.transform.position);
            squadObject.transform.GetChild(2).GetComponent<NavMeshAgent>().SetDestination(house1Target.transform.position);
        }

        if (hasPlayedGiverHouse1 && !textDialogueCanvas.dialogueInUse && !goToPuzzleHouse1)
        {
            goToPuzzleHouse1 = true;
            SceneManager.LoadScene("House1");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dad" && !hasPlayedParent)
        {
            speaker = "Dad";
            string[] sentences = { $"{speaker}: You look amazing in that costume!", "me: Thanks, Dad! I can't wait to go trick-or-treating with my friends!", $"{speaker}: Now go and have an incredible Halloween adventure with your friends!", "me: Thanks, Dad! I have to meet them near the park, and I'm running late!" };
            textDialogueCanvas.SaySomething(sentences);
            hasPlayedParent = true;
        }
        if (other.tag == "Squad" && !hasPlayedSquad)
        {
            speaker = "Squad";
            string[] sentences = { $"{speaker}: Hey, Jack! What took you so long?", "me: Sorry, squad! I had to make sure I was perfectly dressed", $"{speaker}: Well, you better be ready to score some candy!", "me: Let's do this, team!" };
            textDialogueCanvas.SaySomething(sentences);
            hasPlayedSquad = true;
        }
        if (other.tag == "House1Giver" && !hasPlayedGiverHouse1 && hasPlayedSquad)
        {
            speaker = "Neighbor";
            string[] sentences = { "Squad: Trick or Treat!", $"{speaker}: Great costumes! Here's some candy", $"{speaker}: Would yall want to try out the haunted house challenge?", "Squad: Go ahead Jack we dare you" };
            textDialogueCanvas.SaySomething(sentences);
            hasPlayedGiverHouse1 = true;
        }
    }
}
