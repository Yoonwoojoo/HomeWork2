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
                _instance = new GameObject("CharacterManager").AddComponent<CharacterManager>(); // ���� ��ũ��Ʈ�� ĳ���͸Ŵ��� ���ӿ�����Ʈ�� ��ȯ�ϰ� ���۳�Ʈ���� �߰�
            }
            return _instance; // �ٸ� ��ü�� ����� �� �ְ� ��ȯ
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
