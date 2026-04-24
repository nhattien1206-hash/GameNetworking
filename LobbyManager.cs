using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public Button createRoomButton;
    public Button joinRoomButton;

    void Start()
    {
        // Gắn sự kiện cho nút
        createRoomButton.onClick.AddListener(CreateRoom);
        joinRoomButton.onClick.AddListener(JoinRoom);

        // Kết nối Photon Cloud
        PhotonNetwork.ConnectUsingSettings();
    }

    void CreateRoom()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        PhotonNetwork.CreateRoom("Room_" + Random.Range(1000, 9999), options);
    }

    void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Đã vào phòng: " + PhotonNetwork.CurrentRoom.Name);
        SceneManager.LoadScene("Play"); // Load sang scene Play
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Không tìm thấy phòng, tạo mới...");
        CreateRoom();
    }
}

