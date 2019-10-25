using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FunPlus.Common.Config;
using FunPlus.Common.GameConfig;

public class Test : MonoBehaviour
{
    public GameConfigManager m_GameConfigMgr;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            int skillID = 400100100;
            PBSkill skillEffectUnit = m_GameConfigMgr.GetISheetById<PBSkill>(skillID);
            Debug.LogError(skillEffectUnit.ToString());
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            PBChipDefinition skillEffectUnit = m_GameConfigMgr.GetXmlByName<PBChipDefinition>("chips_definition");
            Debug.LogError(skillEffectUnit.ToString());
        }
    }
}
