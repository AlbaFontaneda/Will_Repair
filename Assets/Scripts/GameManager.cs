using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    [SerializeField] private Camera _camera;

    [SerializeField] private Repair[] tumores;

    private FlyingCharacter2D m_character;

    private int currentRepair;

    void Awake()
    {
        m_character = GameObject.FindObjectOfType<FlyingCharacter2D>();
    }

    void Start()
    {
        foreach(Repair tumor in tumores) 
        {
            // Desactivar todos los tumores por defecto
            tumor.gameObject.SetActive(false);
        }

        // Activar el primer tumor y mantener tumorActivo
        currentRepair = 0;
        tumores[currentRepair].gameObject.SetActive(true);
    }

    public void ChangeScene(string scene, Vector2 spawnPoint, Vector2 cameraPosition)
    {
        if (!SceneManager.GetSceneByName(scene).isLoaded)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }

        _player.transform.position = spawnPoint;

        _camera.transform.position = cameraPosition;
    }

    public void RepairCurrentTumor()
    {
        // desactivar tumor actual
        tumores[currentRepair].gameObject.SetActive(false);
        
        if(++currentRepair == tumores.Length)
        {
            Debug.Log("YOU WIN!");
            Application.Quit();
        }
        else
        {
            // activar el siguiente 
            tumores[currentRepair].gameObject.SetActive(true);
        }

    }

    public Vector2 Direction(Zona zona)
    {
        Vector2 posicion = new Vector2(0f, 0f);

        if (zona == Zona.Cerebro)
        {
            posicion = new Vector2(-80f, -50f);
        }
        else if (zona == Zona.Corazon)
        {
            posicion = new Vector2(-80f, -150f);
        }
        else if (zona == Zona.Pulmones)
        {
            posicion = new Vector2(-150f, -150f);
        }
        else if (zona == Zona.Estomago)
        {
            posicion = new Vector2(-120f, -200f);
        }
        else if (zona == Zona.Intestinos)
        {
            posicion = new Vector2(-75f, -230f);
        }

        return posicion;
    }

}
