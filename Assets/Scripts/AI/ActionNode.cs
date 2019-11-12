using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNode : Node
{
    public delegate NodeStates ActionNodeDelegate();

    private ActionNodeDelegate actionDelegate;

    public ActionNode(ActionNodeDelegate action)
    {
        actionDelegate = action;
    }


    public override NodeStates Evaluate()
    {
        switch (actionDelegate())
        {
            case NodeStates.FAILURE:
                state = NodeStates.FAILURE;
                return state;
            case NodeStates.SUCCESS:
                state = NodeStates.SUCCESS;
                return state;
            case NodeStates.RUNNING:
                state = NodeStates.RUNNING;
                return state;
            default:
                state = NodeStates.FAILURE;
                return state;
        }
    }
}
