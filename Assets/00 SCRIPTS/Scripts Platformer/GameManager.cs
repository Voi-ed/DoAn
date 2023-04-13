using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instant;
        public static GameManager instant => _instant;
        private void Awake()
        {
            if (_instant == null)
            {
                _instant = this;
            }
            if (_instant.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
            {
                Destroy(this.gameObject);
            }
        }

        [SerializeField] PlayerController _Player;
        public PlayerController Player => _Player;
    }
}

