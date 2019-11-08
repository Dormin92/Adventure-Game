using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    // List of child Nodes for this Sequence
    protected List<Node> childNodes = new List<Node>();

    public Sequence(List<Node> nodes)
    {
        childNodes = nodes;
    }

    // Evaluate needs to return FAILURE if any of it's children return FAILURE
    // Sequences only return SUCCESS if all of it's children return SUCCESS and none of it's children return RUNNING
    // it MUST wait untill all the nodes have run before returning SUCCESS
    public override NodeStates Evaluate()
    {
        bool anyChildRunning = false;
        foreach (Node n in childNodes)
        {
            switch (n.Evaluate())
            {
                case NodeStates.FAILURE:
                    state = NodeStates.FAILURE;
                    return state;
                case NodeStates.SUCCESS:
                    continue;
                case NodeStates.RUNNING:
                    anyChildRunning = true;
                    continue;
                default:
                    continue;
            }
        }
        if (anyChildRunning)
            state = NodeStates.RUNNING;
        else
            state = NodeStates.SUCCESS;
        return state;
    }
}
