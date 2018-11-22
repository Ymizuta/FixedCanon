using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StageObject : MonoBehaviour {

    protected float life_;

    protected abstract void HitReaction(float damage);
}
