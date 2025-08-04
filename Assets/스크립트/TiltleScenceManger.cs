using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TiltleScenceManger : MonoBehaviour
{
    [SerializeField] private Button gameStartBtn;

    private void Awake()
    {
        gameStartBtn.onClick.AddListener(()=>{ SceneManager.LoadScene(1); });
        
    }
}
