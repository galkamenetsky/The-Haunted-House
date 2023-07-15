using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ScrollWithSlider : MonoBehaviour
{
	public ScrollRect Rect;
	public Slider ScrollSlider;

	private void Update()
	{
		Rect.horizontalNormalizedPosition = ScrollSlider.value;
	}
}