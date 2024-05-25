using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager _instance;
    public static CharacterManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameObject("CharacterManager").AddComponent<CharacterManager>(); // 현재 스크립트를 캐릭터매니저 게임오브젝트로 변환하고 컴퍼넌트까지 추가
            }
            return _instance; // 다른 객체도 사용할 수 있게 반환
        }
    }

    public Player _player;
    public Player player
    {
        get { return _player; }
        set { _player = value; }
    }

    private void Awake()
    {
        if(_instance != null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(_instance == this)
            {
                Destroy(gameObject);
            }
        }
    }
}
