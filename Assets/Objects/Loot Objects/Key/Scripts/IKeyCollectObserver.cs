using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKeyCollectObserver
{
    void OnKeyCollected(Key key);
}
