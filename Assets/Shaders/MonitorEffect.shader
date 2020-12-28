// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:True,dith:3,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:False,qofs:0,qpre:3,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|custl-6219-OUT,clip-1759-OUT;n:type:ShaderForge.SFN_Set,id:7135,x:32842,y:32838,varname:opacityClip,prsc:2|IN-6942-OUT;n:type:ShaderForge.SFN_Slider,id:9476,x:31748,y:32878,ptovrint:False,ptlb:Fresnel Power,ptin:_FresnelPower,varname:_FresnelPower,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:4;n:type:ShaderForge.SFN_Fresnel,id:4105,x:32098,y:32858,varname:node_4105,prsc:2|EXP-9476-OUT;n:type:ShaderForge.SFN_Get,id:1759,x:32981,y:32991,varname:node_1759,prsc:2|IN-7135-OUT;n:type:ShaderForge.SFN_OneMinus,id:611,x:32278,y:32858,varname:node_611,prsc:2|IN-4105-OUT;n:type:ShaderForge.SFN_Slider,id:8029,x:31991,y:32659,ptovrint:False,ptlb:Opacity Strength,ptin:_OpacityStrength,varname:_OpacityStrength,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_Lerp,id:6942,x:32689,y:32838,varname:node_6942,prsc:2|A-7118-OUT,B-5931-OUT,T-9723-OUT;n:type:ShaderForge.SFN_Multiply,id:5931,x:32490,y:32858,varname:node_5931,prsc:2|A-8029-OUT,B-611-OUT,C-3177-OUT,D-8655-OUT;n:type:ShaderForge.SFN_LightColor,id:1941,x:31982,y:33319,varname:node_1941,prsc:2;n:type:ShaderForge.SFN_Color,id:1074,x:31982,y:33122,ptovrint:False,ptlb:Light Color Mask,ptin:_LightColorMask,varname:_LightColorMask,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_ChannelBlend,id:9862,x:32238,y:33198,varname:node_9862,prsc:2,chbt:0|M-1074-RGB,R-1941-R,G-1941-G,B-1941-B;n:type:ShaderForge.SFN_Clamp01,id:9723,x:32490,y:33087,varname:node_9723,prsc:2|IN-9862-OUT;n:type:ShaderForge.SFN_Vector1,id:7118,x:32534,y:32715,varname:node_7118,prsc:2,v1:0;n:type:ShaderForge.SFN_Get,id:3177,x:32238,y:33005,varname:node_3177,prsc:2|IN-9626-OUT;n:type:ShaderForge.SFN_Get,id:8655,x:32238,y:33062,varname:node_8655,prsc:2|IN-5160-OUT;n:type:ShaderForge.SFN_Set,id:5160,x:33139,y:32147,varname:scanLineWorld,prsc:2|IN-6189-OUT;n:type:ShaderForge.SFN_Time,id:4548,x:31928,y:32158,varname:time,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:5945,x:31928,y:32385,ptovrint:False,ptlb:Animation Strength,ptin:_AnimationStrength,varname:_AnimationStrength,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_Multiply,id:435,x:32158,y:32263,varname:node_435,prsc:2|A-4548-TSL,B-5945-OUT;n:type:ShaderForge.SFN_Add,id:9267,x:32355,y:32234,varname:node_9267,prsc:2|A-6639-V,B-435-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6044,x:32355,y:32079,ptovrint:False,ptlb:Scanline Scale,ptin:_ScanlineScale,varname:_ScanlineScale,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:32;n:type:ShaderForge.SFN_Multiply,id:9518,x:32542,y:32164,varname:node_9518,prsc:2|A-6044-OUT,B-9267-OUT;n:type:ShaderForge.SFN_Sin,id:4153,x:32724,y:32164,varname:node_4153,prsc:2|IN-9518-OUT;n:type:ShaderForge.SFN_Lerp,id:6189,x:32952,y:32147,varname:node_6189,prsc:2|A-4888-OUT,B-4153-OUT,T-2998-OUT;n:type:ShaderForge.SFN_Vector1,id:4888,x:32724,y:32067,varname:node_4888,prsc:2,v1:10;n:type:ShaderForge.SFN_Slider,id:2998,x:32567,y:32320,ptovrint:False,ptlb:Scanline Strength,ptin:_ScanlineStrength,varname:_ScanlineStrength,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_FragmentPosition,id:1138,x:32135,y:32021,varname:node_1138,prsc:2;n:type:ShaderForge.SFN_Get,id:6219,x:32981,y:32922,varname:node_6219,prsc:2|IN-9682-OUT;n:type:ShaderForge.SFN_Tex2d,id:7163,x:31928,y:31432,ptovrint:False,ptlb:Texture Map,ptin:_TextureMap,varname:_TextureMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3aaa9cf201b52b547aad8f3b4c41f397,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:4622,x:31928,y:31633,ptovrint:False,ptlb:Colour,ptin:_Colour,varname:_Colour,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:1485,x:32196,y:31545,varname:node_1485,prsc:2|A-7163-RGB,B-4622-RGB,C-8125-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6705,x:32196,y:31744,ptovrint:False,ptlb:Emission Strength,ptin:_EmissionStrength,varname:_EmissionStrength,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:760,x:32440,y:31614,varname:node_760,prsc:2|A-1485-OUT,B-6705-OUT;n:type:ShaderForge.SFN_Abs,id:6857,x:32651,y:31614,varname:node_6857,prsc:2|IN-760-OUT;n:type:ShaderForge.SFN_Add,id:5009,x:32845,y:31541,varname:node_5009,prsc:2|A-1485-OUT,B-6857-OUT;n:type:ShaderForge.SFN_Lerp,id:2636,x:33057,y:31522,varname:node_2636,prsc:2|A-3515-OUT,B-5009-OUT,T-1897-OUT;n:type:ShaderForge.SFN_Vector1,id:3515,x:32893,y:31456,varname:node_3515,prsc:2,v1:0;n:type:ShaderForge.SFN_LightAttenuation,id:1897,x:32845,y:31701,varname:node_1897,prsc:2;n:type:ShaderForge.SFN_Set,id:9682,x:33279,y:31522,varname:mainColour,prsc:2|IN-2636-OUT;n:type:ShaderForge.SFN_TexCoord,id:6639,x:31782,y:31936,varname:node_6639,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:5184,x:31931,y:30720,ptovrint:False,ptlb:Ambient Occlusion,ptin:_AmbientOcclusion,varname:_AmbientOcclusion,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:59e20004ce9ac52499cd03eb7235a25a,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:3715,x:32173,y:30882,varname:node_3715,prsc:2|A-5184-R,B-1978-OUT;n:type:ShaderForge.SFN_OneMinus,id:1978,x:31931,y:30936,varname:node_1978,prsc:2|IN-8746-OUT;n:type:ShaderForge.SFN_Slider,id:8746,x:31597,y:30936,ptovrint:False,ptlb:Ambient Occlusion Strength,ptin:_AmbientOcclusionStrength,varname:_AmbientOcclusionStrength,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Clamp01,id:6820,x:32348,y:30882,varname:node_6820,prsc:2|IN-3715-OUT;n:type:ShaderForge.SFN_Set,id:9626,x:32514,y:30882,varname:ambientOcclusion,prsc:2|IN-6820-OUT;n:type:ShaderForge.SFN_Get,id:8125,x:31907,y:31826,varname:node_8125,prsc:2|IN-9626-OUT;proporder:9476-1074-8029-5945-6044-2998-4622-6705-5184-8746-7163;pass:END;sub:END;*/

Shader "Shader Forge/MonitorEffect" {
    Properties {
        _FresnelPower ("Fresnel Power", Range(0, 4)) = 1
        _LightColorMask ("Light Color Mask", Color) = (1,1,1,1)
        _OpacityStrength ("Opacity Strength", Range(0, 1)) = 0.8
        _AnimationStrength ("Animation Strength", Float ) = 3
        _ScanlineScale ("Scanline Scale", Float ) = 32
        _ScanlineStrength ("Scanline Strength", Range(0, 1)) = 1
        _Colour ("Colour", Color) = (0.5,0.5,0.5,1)
        _EmissionStrength ("Emission Strength", Float ) = 1
        _AmbientOcclusion ("Ambient Occlusion", 2D) = "white" {}
        _AmbientOcclusionStrength ("Ambient Occlusion Strength", Range(0, 1)) = 1
        _TextureMap ("Texture Map", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="Transparent"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 4x4 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither4x4( float value, float2 sceneUVs ) {
                float4x4 mtx = float4x4(
                    float4( 1,  9,  3, 11 )/17.0,
                    float4( 13, 5, 15,  7 )/17.0,
                    float4( 4, 12,  2, 10 )/17.0,
                    float4( 16, 8, 14,  6 )/17.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,4);
                int ySmp = fmod(px.y,4);
                float4 xVec = 1-saturate(abs(float4(0,1,2,3) - xSmp));
                float4 yVec = 1-saturate(abs(float4(0,1,2,3) - ySmp));
                float4 pxMult = float4( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec), dot(mtx[3],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            uniform sampler2D _TextureMap; uniform float4 _TextureMap_ST;
            uniform sampler2D _AmbientOcclusion; uniform float4 _AmbientOcclusion_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _FresnelPower)
                UNITY_DEFINE_INSTANCED_PROP( float, _OpacityStrength)
                UNITY_DEFINE_INSTANCED_PROP( float4, _LightColorMask)
                UNITY_DEFINE_INSTANCED_PROP( float, _AnimationStrength)
                UNITY_DEFINE_INSTANCED_PROP( float, _ScanlineScale)
                UNITY_DEFINE_INSTANCED_PROP( float, _ScanlineStrength)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Colour)
                UNITY_DEFINE_INSTANCED_PROP( float, _EmissionStrength)
                UNITY_DEFINE_INSTANCED_PROP( float, _AmbientOcclusionStrength)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 projPos : TEXCOORD3;
                LIGHTING_COORDS(4,5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float _OpacityStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _OpacityStrength );
                float _FresnelPower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FresnelPower );
                float4 _AmbientOcclusion_var = tex2D(_AmbientOcclusion,TRANSFORM_TEX(i.uv0, _AmbientOcclusion));
                float _AmbientOcclusionStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _AmbientOcclusionStrength );
                float ambientOcclusion = saturate((_AmbientOcclusion_var.r+(1.0 - _AmbientOcclusionStrength_var)));
                float _ScanlineScale_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ScanlineScale );
                float4 time = _Time;
                float _AnimationStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _AnimationStrength );
                float _ScanlineStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ScanlineStrength );
                float scanLineWorld = lerp(10.0,sin((_ScanlineScale_var*(i.uv0.g+(time.r*_AnimationStrength_var)))),_ScanlineStrength_var);
                float4 _LightColorMask_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LightColorMask );
                float opacityClip = lerp(0.0,(_OpacityStrength_var*(1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelPower_var))*ambientOcclusion*scanLineWorld),saturate((_LightColorMask_var.rgb.r*_LightColor0.r + _LightColorMask_var.rgb.g*_LightColor0.g + _LightColorMask_var.rgb.b*_LightColor0.b)));
                clip( BinaryDither4x4(opacityClip - 1.5, sceneUVs) );
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float node_3515 = 0.0;
                float4 _TextureMap_var = tex2D(_TextureMap,TRANSFORM_TEX(i.uv0, _TextureMap));
                float4 _Colour_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Colour );
                float3 node_1485 = (_TextureMap_var.rgb*_Colour_var.rgb*ambientOcclusion);
                float _EmissionStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _EmissionStrength );
                float3 mainColour = lerp(float3(node_3515,node_3515,node_3515),(node_1485+abs((node_1485*_EmissionStrength_var))),attenuation);
                float3 finalColor = mainColour;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 4x4 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither4x4( float value, float2 sceneUVs ) {
                float4x4 mtx = float4x4(
                    float4( 1,  9,  3, 11 )/17.0,
                    float4( 13, 5, 15,  7 )/17.0,
                    float4( 4, 12,  2, 10 )/17.0,
                    float4( 16, 8, 14,  6 )/17.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,4);
                int ySmp = fmod(px.y,4);
                float4 xVec = 1-saturate(abs(float4(0,1,2,3) - xSmp));
                float4 yVec = 1-saturate(abs(float4(0,1,2,3) - ySmp));
                float4 pxMult = float4( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec), dot(mtx[3],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            uniform sampler2D _TextureMap; uniform float4 _TextureMap_ST;
            uniform sampler2D _AmbientOcclusion; uniform float4 _AmbientOcclusion_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _FresnelPower)
                UNITY_DEFINE_INSTANCED_PROP( float, _OpacityStrength)
                UNITY_DEFINE_INSTANCED_PROP( float4, _LightColorMask)
                UNITY_DEFINE_INSTANCED_PROP( float, _AnimationStrength)
                UNITY_DEFINE_INSTANCED_PROP( float, _ScanlineScale)
                UNITY_DEFINE_INSTANCED_PROP( float, _ScanlineStrength)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Colour)
                UNITY_DEFINE_INSTANCED_PROP( float, _EmissionStrength)
                UNITY_DEFINE_INSTANCED_PROP( float, _AmbientOcclusionStrength)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 projPos : TEXCOORD3;
                LIGHTING_COORDS(4,5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float _OpacityStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _OpacityStrength );
                float _FresnelPower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FresnelPower );
                float4 _AmbientOcclusion_var = tex2D(_AmbientOcclusion,TRANSFORM_TEX(i.uv0, _AmbientOcclusion));
                float _AmbientOcclusionStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _AmbientOcclusionStrength );
                float ambientOcclusion = saturate((_AmbientOcclusion_var.r+(1.0 - _AmbientOcclusionStrength_var)));
                float _ScanlineScale_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ScanlineScale );
                float4 time = _Time;
                float _AnimationStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _AnimationStrength );
                float _ScanlineStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ScanlineStrength );
                float scanLineWorld = lerp(10.0,sin((_ScanlineScale_var*(i.uv0.g+(time.r*_AnimationStrength_var)))),_ScanlineStrength_var);
                float4 _LightColorMask_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LightColorMask );
                float opacityClip = lerp(0.0,(_OpacityStrength_var*(1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelPower_var))*ambientOcclusion*scanLineWorld),saturate((_LightColorMask_var.rgb.r*_LightColor0.r + _LightColorMask_var.rgb.g*_LightColor0.g + _LightColorMask_var.rgb.b*_LightColor0.b)));
                clip( BinaryDither4x4(opacityClip - 1.5, sceneUVs) );
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float node_3515 = 0.0;
                float4 _TextureMap_var = tex2D(_TextureMap,TRANSFORM_TEX(i.uv0, _TextureMap));
                float4 _Colour_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Colour );
                float3 node_1485 = (_TextureMap_var.rgb*_Colour_var.rgb*ambientOcclusion);
                float _EmissionStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _EmissionStrength );
                float3 mainColour = lerp(float3(node_3515,node_3515,node_3515),(node_1485+abs((node_1485*_EmissionStrength_var))),attenuation);
                float3 finalColor = mainColour;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 4x4 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither4x4( float value, float2 sceneUVs ) {
                float4x4 mtx = float4x4(
                    float4( 1,  9,  3, 11 )/17.0,
                    float4( 13, 5, 15,  7 )/17.0,
                    float4( 4, 12,  2, 10 )/17.0,
                    float4( 16, 8, 14,  6 )/17.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,4);
                int ySmp = fmod(px.y,4);
                float4 xVec = 1-saturate(abs(float4(0,1,2,3) - xSmp));
                float4 yVec = 1-saturate(abs(float4(0,1,2,3) - ySmp));
                float4 pxMult = float4( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec), dot(mtx[3],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            uniform sampler2D _AmbientOcclusion; uniform float4 _AmbientOcclusion_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _FresnelPower)
                UNITY_DEFINE_INSTANCED_PROP( float, _OpacityStrength)
                UNITY_DEFINE_INSTANCED_PROP( float4, _LightColorMask)
                UNITY_DEFINE_INSTANCED_PROP( float, _AnimationStrength)
                UNITY_DEFINE_INSTANCED_PROP( float, _ScanlineScale)
                UNITY_DEFINE_INSTANCED_PROP( float, _ScanlineStrength)
                UNITY_DEFINE_INSTANCED_PROP( float, _AmbientOcclusionStrength)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float4 projPos : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float _OpacityStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _OpacityStrength );
                float _FresnelPower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FresnelPower );
                float4 _AmbientOcclusion_var = tex2D(_AmbientOcclusion,TRANSFORM_TEX(i.uv0, _AmbientOcclusion));
                float _AmbientOcclusionStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _AmbientOcclusionStrength );
                float ambientOcclusion = saturate((_AmbientOcclusion_var.r+(1.0 - _AmbientOcclusionStrength_var)));
                float _ScanlineScale_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ScanlineScale );
                float4 time = _Time;
                float _AnimationStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _AnimationStrength );
                float _ScanlineStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ScanlineStrength );
                float scanLineWorld = lerp(10.0,sin((_ScanlineScale_var*(i.uv0.g+(time.r*_AnimationStrength_var)))),_ScanlineStrength_var);
                float4 _LightColorMask_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LightColorMask );
                float opacityClip = lerp(0.0,(_OpacityStrength_var*(1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelPower_var))*ambientOcclusion*scanLineWorld),saturate((_LightColorMask_var.rgb.r*_LightColor0.r + _LightColorMask_var.rgb.g*_LightColor0.g + _LightColorMask_var.rgb.b*_LightColor0.b)));
                clip( BinaryDither4x4(opacityClip - 1.5, sceneUVs) );
                float3 lightColor = _LightColor0.rgb;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
