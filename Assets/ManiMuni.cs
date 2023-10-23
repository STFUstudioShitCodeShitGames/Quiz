using UnityEngine;

public class ManiMuni : MonoBehaviour
{
    [SerializeField] private GameObject ManiMuniObj;
    [SerializeField] private GameObject Sujictor;

    private void Start()
    {
        Himakasi(true);
        Application.targetFrameRate = 120;
    }

    public void Igrivi()
    {
        Himakasi(false);
    }

    public void UstavDomou()
    {
        Application.Quit();
    }

    private void Himakasi(bool valchok)
    {
        ManiMuniObj.SetActive(valchok);
        Sujictor.SetActive(!valchok);
    }
}
