using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Chuwarka : MonoBehaviour
{
    [SerializeField] private QuQu _quQu;
    [SerializeField] private TMP_Text _qqq;
    [SerializeField] private VerticalLayoutGroup _urpaa;
    [SerializeField] private ChuwaShi _esumle;
    [SerializeField] private GameObject _ocsher;

    [SerializeField] private Color _da;
    [SerializeField] private Color _net;

    [SerializeField] private TMP_Text _shashmer;
    [SerializeField] private Image _ficher;
    
    private QuQu.Shumka[] _shumka;

    private List<ChuwaShi> _chuwaMashki = new();

    private int _jiml;
    private string _kuuuj;

    private float _hiba;
    private const float HibaOrig = 25;

    private void Start()
    {
        _ocsher.SetActive(false);
        var chud = _quQu.Chudat;
        _shumka = new QuQu.Shumka[chud.questions.Length];
        chud.questions.CopyTo(_shumka, 0);
        
        ShulumBulum(_shumka);
        Humbalusha();
    }

    private Coroutine _sharutinel;
    
    private void ShulumBulum<T>(T[] asdff)
    {
        var asdffLength = asdff.Length;
        while (asdffLength > 1)
        {
            var k = new Random().Next(asdffLength--);
            (asdff[asdffLength], asdff[k]) = (asdff[k], asdff[asdffLength]);
        }
    }

    private void Humbalusha()
    {
        if (_shashmer != null)
            _sharutinel = StartCoroutine(Sharlotka());
        
        var hlk = _shumka[_jiml];
        _kuuuj = hlk.correct_answer;
        _qqq.text = hlk.question;
        foreach (var option in hlk.options)
        {
            var chiki = Instantiate(_esumle, _urpaa.transform);
            chiki.Shka.text = option;
            
            if (option.Equals(_kuuuj))
                chiki.Shmut.onClick.AddListener(()=> Ura(chiki.Shmut));
            else
                chiki.Shmut.onClick.AddListener(()=> NotUra(chiki.Shmut));
            
            _chuwaMashki.Add(chiki);
        }
    }

    private void Ura(Button hipa)
    {
        if (_shashmer != null)
            StopCoroutine(_sharutinel);
        
        _jiml++;
        if (_jiml >= _shumka.Length)
            _jiml = 0;
        
        SwertAsjk(hipa, _da);
        _smotl = StartCoroutine(TicTak(false));
    }

    private void NotUra(Button hipa)
    {
        if (_shashmer != null)
            StopCoroutine(_sharutinel);
        
        SwertAsjk(hipa, _net);
        
        foreach (var chuwaShi in _chuwaMashki)
        {
            if (!chuwaShi.Shka.text.Equals(_kuuuj))
                continue;
            
            SwertAsjk(chuwaShi.Shmut, _da);
            break;
        }
        
        _smotl = StartCoroutine(TicTak(true));
    }

    private void SwertAsjk(Button hipa, Color hook)
    {
        var shmutColors = hipa.colors;
        shmutColors.disabledColor = hook;
        hipa.colors = shmutColors;
    }

    private Coroutine _smotl;
    
    private IEnumerator TicTak(bool vmer)
    {
        foreach (var chuwaShi in _chuwaMashki)
            chuwaShi.Shmut.interactable = false;

        yield return new WaitForSeconds(1.5f);
        
        if (vmer)
            _ocsher.SetActive(true);
        else
        {
            Prilk();
            Humbalusha();
        }
        
        StopCoroutine(_smotl);
    }
    
    private IEnumerator Sharlotka()
    {
        _hiba = HibaOrig;
        _ficher.fillAmount = 1;
        
        while (_hiba > 0)
        {
            _shashmer.text = Mathf.RoundToInt(_hiba).ToString();

            yield return new WaitForSeconds(0.1f);
            _hiba -= 0.1f;

            _ficher.fillAmount = _hiba / HibaOrig;
        }

        foreach (var chuwaShi in _chuwaMashki)
            chuwaShi.Shmut.interactable = false;
        
        _ocsher.SetActive(true);
        StopCoroutine(_smotl);
    }

    private void Prilk()
    {
        foreach (var chuwaShi in _chuwaMashki)
            Destroy(chuwaShi.gameObject);
        
        _chuwaMashki.Clear();
    }
}