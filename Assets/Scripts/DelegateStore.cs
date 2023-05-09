using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DelegateStore : MonoBehaviour
{
    public static Action<GameState> GameStateChange;
}
