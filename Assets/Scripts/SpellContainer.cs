using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Spell")]
    public class SpellContainer : ScriptableObject
    {
        public float damage;
        public float speed;
        public float lifeTime;
        public Sprite icon;
        public float spellradius = 0.5f;
    }
}