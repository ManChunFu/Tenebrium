using System.Collections;
using UnityEngine;

[ExecuteAlways]
public class CameraBlurEffect : MonoBehaviour
{
    //public Shader BlurShader;
    public Material ShaderEfx;
    //public float BlurIntens = 1.0f;

    //private void Start()
    //{
    //    if (!SystemInfo.supportsImageEffects)
    //    {
    //        enabled = false;
    //        return;
    //    }
    //    if (!BlurShader && !BlurShader.isSupported)
    //    {
    //        enabled = false;
    //    }
    //}

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //if (BlurShader != null)
       // {
           // material.SetFloat("_Radius", BlurIntens);
            Graphics.Blit(source, destination, ShaderEfx);
       // }
       // else
       // {
            //Graphics.Blit(source, destination);
       // }
    }

    //private void Update()
    //{
    //    BlurIntens = Mathf.Clamp(BlurIntens, 0.0f, 1.0f);
    //}

    //private void OnDisable()
    //{
    //    if (ShaderEfx)
    //    {
    //        DestroyImmediate(ShaderEfx);
    //    }
    //}

    //Material material
    //{
    //    get
    //    {
    //        if (ShaderEfx == null)
    //        {
    //            ShaderEfx = new Material(BlurShader);
    //            ShaderEfx.hideFlags = HideFlags.HideAndDontSave;
    //        }
    //        return ShaderEfx;
    //    }
    //}


}
