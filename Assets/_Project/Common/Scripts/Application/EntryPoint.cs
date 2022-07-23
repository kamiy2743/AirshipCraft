using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockSystem;

namespace Application
{
    public class EntryPoint
    {
        [RuntimeInitializeOnLoadMethod]
        private void Entry()
        {
            MeshUpdateSystem.Instance.UpdateStart();
        }
    }
}
