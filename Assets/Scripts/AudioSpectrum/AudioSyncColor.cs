using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class AudioSyncColorImage : AudioSyncer {
    public Color[] beatColors;
    public Color restColor;

    private int m_randomIndx;
    private Image m_img;

    private void Start()
    {
	m_img = GetComponent<Image>();
    }

    private IEnumerator MoveToColor(Color target)
    {
	Color current = m_img.color;
	Color initial_color = current;
	float timer = 0;
		
	while (current !=  target)
	{
	    current = Color.Lerp(initial_color,  target, timer / timeToBeat);
	    timer += Time.deltaTime;

	    m_img.color = current;

	    yield return null;
	}

	m_isBeat = false;
    }

    private Color ColorRanges()
    {
	if (beatColors == null || beatColors.Length == 0) return Color.white;
	m_randomIndx = Random.Range(0, beatColors.Length);
	return beatColors[m_randomIndx];
    }

    public override void OnUpdate()
    {
	base.OnUpdate();

	if (m_isBeat) return;

	m_img.color = Color.Lerp(m_img.color, restColor, resetSmoothTime * Time.deltaTime);
    }

    public override void OnBeat()
    {
	base.OnBeat();

	Color _c = ColorRanges();

	StopCoroutine("MoveToColor");
	StartCoroutine("MoveToColor", _c);
    }
}
