using NUnit.Framework;
using UnityEngine;
using Packages.Player.Data;
using System.Collections.Generic;

namespace Packages.Player.Components
{
    public class AnimationComponent : MonoBehaviour
    {
        [SerializeField] private List<AnimationClipData> clips;

        public AnimationClipData GetClip(string name)
        {
            return clips.Find(clips => clips.name == name);
        }
    }
}
