using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float fieldOfView;

    public Selector AIState;
    public Sequence ChasePlayerSequence;
    public ActionNode CanSeePlayerNode;
    public ActionNode MoveToPlayerNode;
    public ActionNode AttackNode;
    public Sequence PatrolSequence;
    public ActionNode GetNextDestinationNode;
    public ActionNode MoveToPatrolDestinationNode;
    public ActionNode WaitAtPatrolDestinationNode;

    public delegate void NodePassed(string trigger);

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //ActionNode initializations;
        CanSeePlayerNode = new ActionNode(PlayerVisible);
        MoveToPlayerNode = new ActionNode(MoveToPlayer);
        AttackNode = new ActionNode(AttackPlayer);
        GetNextDestinationNode = new ActionNode(NextPatrolDestination);

        //TODO
        //make functions to handle patrol functionality
        //initialize GetNextDestinationNode, MoveToPatrolDestinationNode and WaitAtPatrolDestinationNode with those functions


        AIState = new Selector(new List<Node> {
            ChasePlayerSequence,
            PatrolSequence
        });

        ChasePlayerSequence = new Sequence(new List<Node> {
            CanSeePlayerNode,
            MoveToPlayerNode,
            AttackNode
        });

        PatrolSequence = new Sequence(new List<Node> {
            GetNextDestinationNode,
            MoveToPatrolDestinationNode,
            WaitAtPatrolDestinationNode
        });
    }

    void Update()
    {
        AIState.Evaluate();
        Execute();
    }

    private void Execute()
    {
        if (ChasePlayerSequence.NodeState == NodeStates.SUCCESS || ChasePlayerSequence.NodeState == NodeStates.RUNNING)
        {
            Debug.Log("The AI decided to chase and attack the player!");
            //chase the player
        }
        else
        {
            Debug.Log("The AI decided to patrol");
            //patrol the area
        }
    }

    private NodeStates PlayerVisible()
    {
        //Looking for player.. aha!!

        Vector3 playerDirection = (player.transform.position - transform.position).normalized;
        float angleToPlayer = Vector3.Angle(Vector3.forward, playerDirection);
        if(angleToPlayer < fieldOfView)
        {
            Debug.Log(name + " sees the player!!");
        }
        return NodeStates.SUCCESS;
    }

    private NodeStates MoveToPlayer()
    {


        // is actor 1 unit from player?
        // return success
        // else
        // then set NavAgent destination to player position
        // and return running
        return NodeStates.SUCCESS;
    }

    private NodeStates AttackPlayer()
    {
        //launch attack
        return NodeStates.SUCCESS;
    }

    private NodeStates NextPatrolDestination()
    {
        //get the position of the next patrol destination
        return NodeStates.SUCCESS;
    }

    public void GetHit(int damage)
    {
        Debug.Log("Alas! Brother I am hit for " + damage + " damage!!");
    }
}
