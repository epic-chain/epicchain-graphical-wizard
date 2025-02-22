﻿using System;
using System.Collections.Generic;
using EpicChain.SmartContract;
using StackItem = EpicChain.VM.Types.StackItem;
using epicchainArray = EpicChain.VM.Types.Array;
using EpicChain;
using EpicChain.VM;
using System.Diagnostics.CodeAnalysis;

namespace EpicChainTraceVisualizer.EpicChain
{
    internal interface IApplicationEngine : IDisposable
    {
        event EventHandler<(UInt160 scriptHash, string scriptName, string eventName, epicchainArray state)>? DebugNotify;
        event EventHandler<(UInt160 scriptHash, string scriptName, string message)>? DebugLog;

        bool CatchBlockOnStack();

        bool ExecuteNextInstruction();
        bool ExecutePrevInstruction();
        bool TryGetContract(UInt160 scriptHash, [MaybeNullWhen(false)] out Script script);
        StorageContainerBase GetStorageContainer(UInt160 scriptHash);

        bool SupportsStepBack { get; }
        byte AddressVersion { get; }
        IReadOnlyCollection<IExecutionContext> InvocationStack { get; }
        IExecutionContext? CurrentContext { get; }
        IReadOnlyList<StackItem> ResultStack { get; }
        long GasConsumed { get; }
        Exception? FaultException { get; }
        VMState State { get; }
        bool AtStart { get; }
    }
}
