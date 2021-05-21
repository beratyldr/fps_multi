using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;
using System.IO;
public class EnemyManager : MonoBehaviourPunCallbacks
{
    PlayerCharacterController m_PlayerController;
    PhotonView PV;
    Vector3 a = new Vector3(-15.0f, 42.0f, 90.0f);
    public List<EnemyController> enemies { get; private set; }
    public int numberOfEnemiesTotal { get; private set; }
    public int numberOfEnemiesRemaining => enemies.Count;
    
    public UnityAction<EnemyController, int> onRemoveEnemy;
    Spawner spawner;
    private void Awake()
    {
        PV = this.GetComponent<PhotonView>();
        m_PlayerController = FindObjectOfType<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, EnemyManager>(m_PlayerController, this);

        enemies = new List<EnemyController>();
    }

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        PV.RPC("CreateEnemy" ,RpcTarget.AllBuffered);
       

    }

    [PunRPC]
    void CreateEnemy()
    {
          PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Enemy_HoverBot"), a, transform.rotation);
         
    }

    public void RegisterEnemy(EnemyController enemy)
    {
        enemies.Add(enemy);

        numberOfEnemiesTotal++;
       
    }

    public void UnregisterEnemy(EnemyController enemyKilled)
    {
        int enemiesRemainingNotification = numberOfEnemiesRemaining - 1;

        if (onRemoveEnemy != null)
        {
            onRemoveEnemy.Invoke(enemyKilled, enemiesRemainingNotification);
        }
        

        // removes the enemy from the list, so that we can keep track of how many are left on the map
        enemies.Remove(enemyKilled);
    }
}
