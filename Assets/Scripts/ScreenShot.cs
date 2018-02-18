using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class ScreenShot : MonoBehaviour {

	public bool hideGUI = false;
	public bool logos = false;
	public Texture2D texture;
	public Text console;
	public CanvasGroup ui,uilogo;
	public Image screenshot;
	
	void OnEnable ()
	{
		// call backs
		ScreenshotManager.OnScreenshotTaken += ScreenshotTaken;
		ScreenshotManager.OnScreenshotSaved += ScreenshotSaved;	
		ScreenshotManager.OnImageSaved += ImageSaved;
		if(!logos) uilogo.alpha = 0;
	}

	void OnDisable ()
	{
		ScreenshotManager.OnScreenshotTaken -= ScreenshotTaken;
		ScreenshotManager.OnScreenshotSaved -= ScreenshotSaved;	
		ScreenshotManager.OnImageSaved -= ImageSaved;
	}

	public void OnSaveScreenshotPress()
	{
		ScreenshotManager.SaveScreenshot("MyScreenshot", "ScreenshotApp", "jpeg");
		ui.alpha = 0;
		uilogo.alpha = 1;
	}

	public void OnSaveImagePress()
	{
		ScreenshotManager.SaveImage(texture, "MyImage", "MyImages", "png");
	}

	void ScreenshotTaken(Texture2D image)
	{
		console.text += "\nScreenshot has been taken and is now saving...";
		screenshot.sprite = Sprite.Create(image, new Rect(0, 0, image.width, image.height), new Vector2(.5f, .5f));
		screenshot.color = Color.white;
		ui.alpha = 1;
		uilogo.alpha = 0;
	}
	
	void ScreenshotSaved(string path)
	{
		console.text += "\nScreenshot finished saving to " + path;
	}
	
	void ImageSaved(string path)
	{
		console.text += "\n" + texture.name + " finished saving to " + path;
	}
}