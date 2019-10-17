using strange.extensions.context.impl;
using UnityEngine;
using strange.extensions.context.api;

public class GameContextView : ContextView
{
    [SerializeField] ObjectReferences objectReferences;

    private void Awake()
    {
        context = new GameContext(this, ContextStartupFlags.MANUAL_MAPPING, objectReferences);
        context.Start();
    }
}

