using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bird", menuName = "Birds")]
public class Bird : ScriptableObject
{
    public new string name;
    public Sprite color;
    public Animation anim;
}
