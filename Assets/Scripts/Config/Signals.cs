using strange.extensions.signal.impl;
using UnityEngine;

public class StartSignal : Signal { }

public class MoveAxisSignal : Signal<Vector2> { }

public class LookAxisSignal : Signal<Vector2> { }

public class FireButtonSignal : Signal<bool> { }
