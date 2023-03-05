using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelect : MonoBehaviour
{
    public Button btnMeele;
    public Button btnGun0;
    public Button btnGun1;
    public PlayerStats ps;
    public MeeleWeapon meele = null;
    public Gun gun0 = null;
    public NullWeapon gun1 = null;

    void Start()
    {
        btnMeele.onClick.AddListener(SelectToMeele);
        btnGun0.onClick.AddListener(SelectToGun0);
        btnGun1.onClick.AddListener(SelectToGun1);
    }

    public void SelectToMeele()
    {
        if (meele != null)
        {
            ps.weapon.gameObject.SetActive(false);
            meele.gameObject.SetActive(true);
            ps.weapon = meele;
        }
    }

    public void SelectToGun0()
    {
        if (gun0 != null)
        {
            ps.weapon.gameObject.SetActive(false);
            gun0.gameObject.SetActive(true);
            ps.weapon = gun0;
        }
    }

    public void SelectToGun1()
    {
        if(gun1 != null)
        {
            ps.weapon.gameObject.SetActive(false);
            gun1.gameObject.SetActive(true);
            ps.weapon = gun1;
        }
    }
}
