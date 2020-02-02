using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Camera _camera = null;
    [SerializeField] private AudioSource _audioSource = null;

    // En lugar de arrastrar los tumores cada vez que se añada uno
    // los vamos a coger automaticamente de la escena
    List<Repair> tumores;
    List<Repair> enemies;

    private GameObject m_character;

    public Zona currentTarget;
    public Zona currentLocation;

    private Blink blinkWarning;
    private Blink blinkPlayer;
    private ButtonSequencer buttonSquencer;

    private Repair currentRepair;

    void Awake()
    {
        m_character = GameObject.FindWithTag("Player");
        tumores = new List<Repair>();
        enemies = new List<Repair>();
        
        //blinkWarning = GameObject.FindObjectOfType<Blink>();

        GameObject warning = GameObject.FindGameObjectWithTag("Warning");
        
        if (warning == null)
        {
            Debug.Log("Warning is null.");
        }
        blinkWarning = warning.GetComponent<Blink>();
        if (blinkWarning == null)
        {
            Debug.Log("blinkWarning is null.");
        }

        //GameObject miniPlayer = GameObject.FindWithTag("MiniPlayer");
        GameObject miniPlayer = GameObject.FindGameObjectWithTag("MiniPlayer");
        if (miniPlayer == null)
        {
            Debug.Log("MiniPlayer is null.");
        }
        blinkPlayer = miniPlayer.GetComponent<Blink>();
        if (blinkPlayer == null)
        {
            Debug.Log("blinkPlayer is null.");
        }
        //blinkPlayer.StopBlink(false);

        buttonSquencer = GameObject.FindObjectOfType<ButtonSequencer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeScene("Menu");
        }
    }

    void Start()
    {
        // primera zona de reparacion 0 = Cerebro
        currentTarget = Zona.CEREBRO;
        currentLocation = Zona.CORAZON;

        // desactiva los tumores en corazon al arrancar
        activarTumores();

        actualizaWarning();

        actualizaPlayerLocation();
    }

    public void ChangeSceneAdditive(string scene, Vector3 spawnPoint, Vector3 cameraPosition)
    {
        Debug.Log("ChangeSceneAdditive: " + scene);

        Scene escena = SceneManager.GetSceneByName(scene);
        if (!escena.isLoaded)
        {
            var parameters = new LoadSceneParameters(LoadSceneMode.Additive);
            Scene sce = SceneManager.LoadScene(scene, parameters);
        }

        // muevo el personaje
        m_character.transform.position = spawnPoint;
        // muevo camara
        _camera.transform.position = cameraPosition;

        // actualizo la localizacion del personaje
        if (scene == "Corazon 1")
        {
            currentLocation = Zona.CORAZON;
        }
        else if (scene == "EstomagoScene 1")
        {
            currentLocation = Zona.ESTOMAGO;
        }
        else if (scene == "CerebroScene")
        {
            currentLocation = Zona.CEREBRO;
        }
        else if (scene == "PulmonScene")
        {
            currentLocation = Zona.PULMONES;
        }

        actualizaPlayerLocation();

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

    public void MiniGame(Repair repair)
    {
        // guardamos la referencia al tumor
        currentRepair = repair;
        // creamos secuencia de botones
        buttonSquencer.createSequence();
    }

    public void StopMiniGame(Repair repair)
    {
        Debug.Log("StopMiniGame");
        // creamos secuencia de botones
        buttonSquencer.hideSequence();
    }

    public void RepairCurrentTumor()
    {
        // quitar tumor de la lista actual
        enemies.Remove(currentRepair);
        tumores.Remove(currentRepair);
        // destruir el tumor
        Destroy(currentRepair.gameObject);
        // si hemos reparado todos los tumores cambiar de zona objetivo
        if (enemies.Count == 0)
        {
            ++currentTarget;
            actualizaWarning();
            Debug.Log("CAMBIAR DE ZONA OBJETIVO: " + currentTarget);

            // Si hemos reparado la zona corazón nos hemos pasado el juego
            if ((int)currentTarget > 3)
            {
                Debug.Log("YOU WIN!");
            }
        }
    }

    public Vector2 Direction(Zona zona)
    {
        Vector2 posicion = new Vector2(0f, 0f);

        if (zona == Zona.CEREBRO)
        {
            //posicion = new Vector2(-80f, -50f);
            posicion = new Vector2(-100f, -53f);
        }
        else if (zona == Zona.CORAZON)
        {
            //posicion = new Vector2(-80f, -150f);
            posicion = new Vector2(-100f, -160f);
        }
        else if (zona == Zona.PULMONES)
        {
            //posicion = new Vector2(-150f, -150f);
            posicion = new Vector2(-180f, -160f);
        }
        else if (zona == Zona.ESTOMAGO)
        {
            //posicion = new Vector2(-120f, -200f);
            posicion = new Vector2(-140f, -200f);
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
        Debug.Log("ACTIVAR TUMORES");
        // reseteamos la lista de enemigos
        //enemies = new List<Repair>();
        // Comprobar si hay que activar los tumores de la escena
        // Obtenemos todos los tumores y nos quedamos con la escena actual
        //Repair[] tumores = GameObject.FindObjectsOfType<Repair>();

        
        //Repair[] tumores = GameObject.FindGameObjectWithTag("Tumor");

        
        foreach (Repair tumor in tumores)
        {
            // Por defecto desactivar todos los tumores
            tumor.gameObject.SetActive(false);

            // Activar los tumores de la zona objetivo
            if (tumor.zona == currentTarget)
            {
                tumor.gameObject.SetActive(true);
                // añadir a la lista de tumores actual
                enemies.Add(tumor);
            }
        }

    }

    private void actualizaWarning()
    {
        // Test parpadeo de minimapa
        //Zona zona = (Zona)currentTarget;
        Vector2 position = Direction(currentTarget);
        blinkWarning.StopBlink(false);
        blinkWarning.StartBlink(position.x, position.y);
    }

    private void actualizaPlayerLocation()
    {
        // Test parpadeo de minimapa
        //Zona zona = (Zona)currentLocation;
        Vector2 position = Direction(currentLocation);
        blinkPlayer.StopBlink(false);
        blinkPlayer.StartBlink(position.x, position.y);
        blinkPlayer.StopBlink(true);
    }

    public void RegistraTumor(Repair tumor)
    {
        // por defecto desactivo el tumor
        tumor.gameObject.SetActive(false);

        if (tumor.zona == currentTarget)
        {
            tumor.gameObject.SetActive(true);
            // añadir a la lista de tumores actual
            enemies.Add(tumor);
        }

        tumores.Add(tumor);
    }
}
