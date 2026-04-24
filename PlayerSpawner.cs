using UnityEngine;
using Photon.Pun;
using RedRunner;
using RedRunner.Characters;

public class PlayerSpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // danh sách vị trí spawn, gán trong Inspector

    void Start()
    {
        // Chỉ spawn khi đã kết nối và vào phòng
        if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom)
        {
            SpawnPlayer();
        }
    }

    void SpawnPlayer()
    {
        // Chọn vị trí spawn ngẫu nhiên hoặc theo index
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate nhân vật từ prefab trong Resources
        GameObject player = PhotonNetwork.Instantiate("RedRunner", spawnPoint.position, spawnPoint.rotation);

        // Gán nhân vật cho GameManager để quản lý
        RedRunner.GameManager gm = FindFirstObjectByType<RedRunner.GameManager>();
        if (gm != null)
        {
            gm.SetMainCharacter(player.GetComponent<RedRunner.Characters.RedCharacter>());
        }
    }
}



