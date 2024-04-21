using UnityEngine;

namespace DefaultNamespace.golem
{
    public class golemcounter : MonoBehaviour
    {
        private int enemyCount = 0;

        public void IncreaseEnemyCount()
        {
            enemyCount++;
        }

        public int GetEnemyCount()
        {
            return enemyCount;
        }
        
        
    }
}