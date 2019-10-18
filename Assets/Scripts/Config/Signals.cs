using strange.extensions.signal.impl;
using UnityEngine;

public class StartSignal : Signal { }

public class MoveAxisSignal : Signal<Vector2> { }

public class LookAxisSignal : Signal<Vector2> { }

public class FireButtonSignal : Signal<bool> { }

public class UltimateButtonSignal : Signal { }

public class EnemyKilledSignal : Signal<EnemyType, bool> { }

public class PlayerKilledSignal : Signal { }

public class UltimateUsedSignal : Signal { }

public class PlayerTeleportedSignal : Signal { }

public class ShowGameOverSignal : Signal<int> { }

public class RestartButtonSignal : Signal { }
