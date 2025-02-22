﻿using Microsoft.VisualStudio.Shared.VSCodeDebugProtocol.Messages;
using EpicChain.VM;
using EpicChainTraceVisualizer.VariableContainers;
using EpicChainFx.Models;



namespace EpicChainTraceVisualizer.ModelAdapters
{
    class WitnessAdapter : AdapterBase, IVariableProvider
    {
        public readonly Witness Item;

        public WitnessAdapter(in Witness value)
        {
            Item = value;
        }

        public static WitnessAdapter Create(in Witness value)
        {
            return new WitnessAdapter(value);
        }

        public bool GetVerificationScript(ExecutionEngine engine)
        {
            engine.CurrentContext.EvaluationStack.Push(Item.VerificationScript.ToArray());
            return true;
        }

        public Variable GetVariable(IVariableContainerSession session, string name)
        {
            return new Variable()
            {
                Name = name,
                Type = "Witness",
                Value = string.Empty
            };
        }
    }
}
