﻿using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TNRD.Zeepkist.GTR.UI;

public class WorldRecordHolderUi : MonoBehaviour
{
    private Image _worldRecordImage;
    private TextMeshProUGUI _headerText;
    private TextMeshProUGUI _playerNameText;
    private TextMeshProUGUI _timeText;

    public void InitializeUi()
    {
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
        TextMeshProUGUI position
            = texts.First(x => string.Equals(x.name, "Position", StringComparison.OrdinalIgnoreCase));

        GameObject starHolder = new GameObject("Star", typeof(RectTransform));
        RectTransform starHolderTransform = starHolder.GetComponent<RectTransform>();
        starHolderTransform.SetParent(position.transform, false);
        starHolderTransform.anchorMin = Vector2.zero;
        starHolderTransform.anchorMax = Vector2.one;
        starHolderTransform.offsetMin = Vector2.zero;
        starHolderTransform.offsetMax = Vector2.zero;
        starHolderTransform.anchoredPosition = Vector2.zero;
        starHolderTransform.anchoredPosition3D = Vector3.zero;
        starHolderTransform.sizeDelta = Vector2.zero;
        _worldRecordImage = starHolder.AddComponent<Image>();
        _worldRecordImage.preserveAspect = true;
        _worldRecordImage.sprite = PlayerManager.Instance.youTriedMedal;
        Destroy(position);

        _headerText = texts.First(x => string.Equals(x.name, "Your Time Title", StringComparison.OrdinalIgnoreCase));
        _playerNameText = texts.First(x => string.Equals(x.name, "Player", StringComparison.OrdinalIgnoreCase));
        _timeText = texts.First(x => string.Equals(x.name, "Time", StringComparison.OrdinalIgnoreCase));
        _headerText.text = "World Record";
    }

    public void SetWorldRecordHolder(WorldRecordHolder worldRecordHolder)
    {
        if (worldRecordHolder == null)
        {
            _playerNameText.text = "be the first!";
            _timeText.text = "--:--.---";
        }
        else
        {
            _playerNameText.text
                = string.IsNullOrEmpty(worldRecordHolder.SteamName) ? "be the first!" : worldRecordHolder.SteamName;
            _timeText.text = worldRecordHolder.Time <= 0 ? "--:--.---" : worldRecordHolder.Time.GetFormattedTime();
        }
    }
}
