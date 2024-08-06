using Fusion;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Transformer : NetworkBehaviour
    {
        public Transform[] Transforms;

        public void Construct(Transform[] transforms)
        {
            Transforms = transforms;
            print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        }
    }
}