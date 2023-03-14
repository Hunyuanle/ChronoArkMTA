using ChronoArkMod.ModData.Settings;
using ChronoArkMod.ModData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using I2.Loc;
using System.Reflection;
using UnityEngine.Experimental.PlayerLoop;
using Steamworks;
using System.Collections;

namespace ChronoArkMod
{
    public class ModUI:MonoBehaviour
    {
        //Todo UploadButton UploadMod();
        private readonly List<GameObject> _settingEntriesList = new List<GameObject>();
        private List<string> _originModIdList = new List<string>();

        public RectTransform SettingsHolder;///HorizontalLayoutGroup
        public GameObject ModPanel_SettingEntry_Toggle_Prefab;
        public GameObject ModPanel_SettingEntry_Slider_Prefab;
        public GameObject ModPanel_SettingEntry_Dropdown_Prefab;
        public GameObject ModPanel_SettingEntry_InputField_Prefab;
        public GameObject BasicInfo;
        private bool _hasChangedSetting;
        private bool _needRestart;
        private bool _hasChangedEnable;
        public Button ApplyBtn;
        public ScrollRect ModsScroll;//ToggleGroup,
                                     //item in it:
                                     //info -> ModsScrollItemInfoSet
                                     //click-> OnModsScrollItemClick
                                     //drag-> OnModsScrollItemDragAndMove
                                     //has a toggle on it,to show the mod is enabled or not

        public Button EnableBtn;
        public Button DisableBtn;
        private string _curModId;
        public TextMeshProUGUI NameValue;
        public TextMeshProUGUI AuthorValue;
        public TextMeshProUGUI VersionValue;
        public TextMeshProUGUI ModIDValue;
        public TextMeshProUGUI Description;
        public Image Cover;

        
        private void OnEnable()
        {
            
            ModManager.UpdateModList();
            _originModIdList = new List<string>(ModManager.EnabledMods);
            ClearChangeState();
            RefreshApplyButton();
        }
        private void ClearChangeState()
        {
            _hasChangedEnable = false;
            _hasChangedSetting = false;
            _needRestart = false;
        }
        public void ModsScrollItemInfoSet(string modId,GameObject scollitem)
        {
            ModInfo modInfo = ModManager.getModInfo(modId);
            scollitem.GetComponent<TextMeshProUGUI>().SetText(modInfo.Title);
            //set scollitem.GetComponent<...>().info = modInfo
            bool isModEnabled = ModManager.IsModEnabled(modId);
            Toggle modToggle = scollitem.GetComponent<Toggle>();
            Toggle isEnabledTog = scollitem.transform.GetChild(0).GetComponent<Toggle>();
            isEnabledTog.onValueChanged.RemoveAllListeners();
            isEnabledTog.isOn = isModEnabled;
            isEnabledTog.onValueChanged.AddListener(delegate (bool isOn)
            {
                this.SetModEnabled(modId, isOn);
            });
            //OnModsScrollItemDragAndMove
            //OnModsScrollItemClicked

        }


        public void OnModsScrollItemClicked(int index,string modid)
        {
            ModInfo modInfo = ModManager.getModInfo(modid);
            UpdateModInfo(modInfo);
            
        }
        public void OnModsScrollItemDragAndMove(string modId,int new_index)
        {
            
            ModManager.EnabledMods.Remove(modId);
            ModManager.EnabledMods.Insert(new_index, modId);
            RefreshEnableChangeState();
        }
        private void SetModEnabled(string modId, bool isEnabled)
        {
            ModManager.SetModEnabled(modId, isEnabled);
            EnableBtn.gameObject.SetActive(!isEnabled);
            DisableBtn.gameObject.SetActive(isEnabled);
            RefreshEnableChangeState();
        }
       
        public void UpdateModInfo(ModInfo modInfo)
        {
            _curModId = modInfo.id;
            NameValue.SetText(modInfo.Title);
            AuthorValue.SetText(modInfo.Author);
            VersionValue.SetText(modInfo.GetVersionString());
            ModIDValue.SetText(modInfo.id);
            if (string.IsNullOrEmpty(modInfo.Cover))
            {
                AddressableLoadManager.LoadAsyncAction("NoCover", AddressableLoadManager.ManageType.None, Cover);
            }
            else
            {
                
                AddressableLoadManager.LoadAsyncAction(modInfo.CoverKey, AddressableLoadManager.ManageType.None, Cover);
            }
            
         
            bool isEnabled = ModManager.IsModEnabled(modInfo.id);
            EnableBtn.gameObject.SetActive(!isEnabled);
            DisableBtn.gameObject.SetActive(isEnabled);
            Description.SetText(modInfo.Description);
            SettingsHolder.gameObject.SetActive(true);
            this.UpdateSettings(modInfo);
           
        }
        public void ClearModInfo()
        {
            this._curModId = "";
            NameValue.SetText("");
            AuthorValue.SetText("");
            VersionValue.SetText("");
            ModIDValue.SetText("");
            AddressableLoadManager.LoadAsyncAction("NoCover", AddressableLoadManager.ManageType.None, Cover);
            EnableBtn.gameObject.SetActive(false);
            DisableBtn.gameObject.SetActive(false);
            Description.SetText("");
            SettingsHolder.gameObject.SetActive(false);
            this.UpdateSettings(null);
        }
        private void UpdateSettings(ModInfo modInfo)
        {
            foreach (GameObject settingEntries in _settingEntriesList)
            {
                Destroy(settingEntries);
            }
            _settingEntriesList.Clear();
           
            if (modInfo == null || modInfo.ModSettingEntries.Count == 0)
            {
                return;
            }
            foreach (SettingEntry entry in modInfo.ModSettingEntries)
            {
                GameObject settingGameObject =null;
                if (entry is ToggleSetting)
                {
                    ToggleSetting toggleSettingEntry = entry as ToggleSetting;
                    settingGameObject = Instantiate<GameObject>(ModPanel_SettingEntry_Toggle_Prefab);
                    Toggle toggle = settingGameObject.GetComponent<Toggle>();
                    toggle.onValueChanged.RemoveAllListeners();
                    toggle.isOn = toggleSettingEntry.Value;
                    toggle.onValueChanged.AddListener(delegate (bool isOn)
                    {
                        if (isOn != toggleSettingEntry.Value)
                        {
                            SetSettingChangeState(true, modInfo);
                        }
                        toggleSettingEntry.Value = isOn;
                    });
                }
                else if (entry is SliderSetting)
                {
                    SliderSetting sliderSettingEntry = entry as SliderSetting;
                    settingGameObject = Instantiate<GameObject>(ModPanel_SettingEntry_Slider_Prefab);
                    Slider slider = settingGameObject.GetComponent<Slider>();
                    slider.onValueChanged.RemoveAllListeners();
                    slider.wholeNumbers = true;
                    slider.maxValue = sliderSettingEntry.MaxValue;
                    slider.minValue = sliderSettingEntry.MinValue;
                    slider.value = sliderSettingEntry.Value;
                    TextMeshProUGUI curValue = settingGameObject.GetComponent<TextMeshProUGUI>();
                    curValue.text = sliderSettingEntry.Value.ToString();
                    slider.onValueChanged.AddListener(delegate (float val)
                    {
                        int num = (int)val;
                        if (sliderSettingEntry.Value != num)
                        {
                            SetSettingChangeState(true, modInfo);
                        }
                        sliderSettingEntry.Value = num;
                        curValue.text = ((int)val).ToString();
                    });
                }
                else if (entry is DropdownSetting)
                {
                    DropdownSetting dropdownSettingEntry = entry as DropdownSetting;
                    settingGameObject = Instantiate<GameObject>(ModPanel_SettingEntry_Dropdown_Prefab);
                    Dropdown dropdown = settingGameObject.GetComponent<Dropdown>();
                    dropdown.onValueChanged.RemoveAllListeners();
                    dropdown.ClearOptions();
                    dropdown.AddOptions(dropdownSettingEntry.Options);
                    dropdown.value = dropdownSettingEntry.Value;
                    dropdown.onValueChanged.AddListener(delegate (int val)
                    {
                        if (val != dropdownSettingEntry.Value)
                        {
                            SetSettingChangeState(true, modInfo);
                        }
                        dropdownSettingEntry.Value = val;
                    });
                }
                else if(entry is InputFieldSetting)
                {
                    InputFieldSetting inputFieldSettingEntry = entry as InputFieldSetting;
                    settingGameObject = Instantiate<GameObject>(ModPanel_SettingEntry_InputField_Prefab);
                    InputField inputField = settingGameObject.GetComponent<InputField>();
                    inputField.onEndEdit.RemoveAllListeners();
                    inputField.text = inputFieldSettingEntry.Value;
                    
                    ((TextMeshProUGUI)inputField.placeholder).text = LocalizationManager.GetTranslation("");
                    inputField.onEndEdit.AddListener(delegate (string val)
                    {
                        if (inputFieldSettingEntry.Value != val)
                        {
                            SetSettingChangeState(true, modInfo);
                        }
                        inputFieldSettingEntry.Value = val;
                    });
                }
                if(settingGameObject!= null)
                {
                    TextMeshProUGUI label = settingGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                    label.SetText(entry.DisplayName);
                    //When Mouse Enter,   Tooltip text =  entry.Description;
                    _settingEntriesList.Add(settingGameObject);
                    Transform entryTransform = settingGameObject.transform;
                    entryTransform.SetParent(SettingsHolder);
                    entryTransform.SetAsLastSibling();
                    entryTransform.localScale = Vector3.one;
                }
               
            }
           

        }
        private void RefreshEnableChangeState()
        {
            _hasChangedEnable = false;

            
            if (ModManager.EnabledMods!=_originModIdList)
            {
                _hasChangedEnable = true;
            }
            else
            {
                for(int i = 0;i<ModManager.EnabledMods.Count;i++)
                {
                    if (ModManager.EnabledMods[i] != _originModIdList[i])
                    {
                        _hasChangedEnable= true;
                        break;
                    }
                }
            }
           
            this.RefreshApplyButton();
        }
        private void SetSettingChangeState(bool changed, ModInfo modInfo = null)
        {
            _hasChangedSetting = changed;
            if (_hasChangedSetting && modInfo != null)
            {
                if(modInfo.NeedRestartWhenSettingChanged)
                {
                    _needRestart = true;
                }
            }
            this.RefreshApplyButton();
        }
        private void RefreshApplyButton()
        {
            ApplyBtn.interactable = (this._hasChangedSetting || this._hasChangedEnable);
        }
        public void OnCloseBtnClick()
        {
            ModManager.EnabledMods= _originModIdList;
        }
        public void ShowRestart()
        {
            
        }
        public void ShowInvalidDenendency()
        {
            //Ask Player to Check Dependency
        }
        public void OnApplyBtnClick()
        {
            ModManager.CheckEnabled(out bool needReloadAll,out bool needrestart ,out bool invalid);
            if (invalid)
            {
                ShowInvalidDenendency();
            }
            else
            {
                ModManager.SaveModSettings();
                if (_needRestart||needrestart)
                {
                    ShowRestart();
                }
                else
                {
                    ModManager.ModStatChanged(needReloadAll);
                    this.ClearChangeState();
                }
               
            }
           
            
        }
        public void OnEnableBtnClick()
        {
            SetModEnabled(_curModId, true);
        }
        public void OnDisableBtnClick()
        {
            SetModEnabled(_curModId, false);
        }
       
        
       

    }
}
