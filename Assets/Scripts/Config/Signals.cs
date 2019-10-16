using strange.extensions.signal.impl;
using UnityEngine;

public class StartSignal : Signal { }

public class MoveAxisSignal : Signal<Vector2> { }

public class LookAxisSignal : Signal<Vector2> { }

public class FireButtonSignal : Signal<bool> { }

public class UltimateButtonSignal : Signal { }

public class EnemyKilledSignal : Signal<EnemyType> { }

public class PlayerKilledSignal : Signal { }

public class UltimateUsedSignal : Signal { }
