using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Camera _camera = null;

    // En lugar de arrastrar los tumores cada vez que se añada uno
    // los vamos a coger automaticamente de la escena
    List<Repair> enemies;

    private GameObject m_character;

    private int currentZone;

    void Awake()
    {
        m_character = GameObject.FindWithTag("Player");
        enemies = new List<Repair>();
    }

    void Start()
    {
        // primera zona de reparacion 0 = Cerebro
        currentZone = 0;

        // TODO prueba inicial, quitar luego
        activarTumores();
    }

    public void ChangeSceneAdditive(string scene, Vector3 spawnPoint, Vector3 cameraPosition)
    {
        if (!SceneManager.GetSceneByName(scene).isLoaded)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }

        m_character.transform.position = spawnPoint;

        _camera.transform.position = cameraPosition;

        // intenta activar los tumores si entramos en la zona de objetivo actual
        activarTumores();
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void RepairCurrentTumor(Repair repair)
    {
        // quitar tumor de la lista actual
        enemies.Remove(repair);
        // destruir el tumor
        Destroy(repair.gameObject);
        // si hemos reparado todos los tumores cambiar de zona objetivo
        if (enemies.Count == 0)
        {
            ++currentZone;
            Debug.Log("CAMBIAR DE ZONA OBJETIVO: " + currentZone);
            // Si hemos reparado la zona corazón nos hemos pasado el juego
            if (currentZone > 3)
            {
                Debug.Log("YOU WIN!");
            }
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
        /*
        else if (zona == Zona.Intestinos)
        {
            posicion = new Vector2(-75f, -230f);
        }
        */

        return posicion;
    }

    private void activarTumores()
    {
        // reseteamos la lista de enemigos
        enemies = new List<Repair>();
        // Comprobar si hay que activar los tumores de la escena
        // Obtenemos todos los tumores y nos quedamos con la escena actual
        Repair[] tumores = GameObject.FindObjectsOfType<Repair>();
        foreach (Repair tumor in tumores)
        {
            
            // Por defecto desactivar todos los tumores
            tumor.gameObject.SetActive(false);

            uint zonaInt = (uint) tumor.zona;
            Debug.Log("Tenemos un tumor de zona: "+ zonaInt);
            // Activar los tumores de la zona objetivo
            if (zonaInt == currentZone)
            {
                tumor.gameObject.SetActive(true);
                // añadir a la lista de tumores actual
                enemies.Add(tumor);
            }
        }
    }

}
