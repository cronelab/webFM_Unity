using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialManager : MonoBehaviour
{

    Component[] renderers;
    public Shader shader;
    Renderer rend;

    void Awake()
    {

        Renderer[] childRends = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in childRends)
        {
            rend.material = new Material(shader);
            rend.gameObject.AddComponent<mouseOver_name>();
        }

        GameObject.Find("Left-Cerebral-White-Matter").GetComponent<Renderer>().material.color = new Color(245 / 255f, 245 / 255f, 245 / 255f);
        GameObject.Find("Left-Cerebral-Cortex").GetComponent<Renderer>().material.color = new Color(205 / 255f, 62 / 255f, 78 / 255f);
        GameObject.Find("Left-Lateral-Ventricle").GetComponent<Renderer>().material.color = new Color(120 / 255f, 18 / 255f, 134 / 255f);
        GameObject.Find("Left-Inf-Lat-Vent").GetComponent<Renderer>().material.color = new Color(196 / 255f, 58 / 255f, 250 / 255f);
        GameObject.Find("Left-Cerebellum-White-Matter").GetComponent<Renderer>().material.color = new Color(220 / 255f, 248 / 255f, 164 / 255f);
        GameObject.Find("Left-Cerebellum-Cortex").GetComponent<Renderer>().material.color = new Color(230 / 255f, 148 / 255f, 34 / 255f);
        GameObject.Find("Left-Thalamus-Proper").GetComponent<Renderer>().material.color = new Color(0 / 255f, 118 / 255f, 14 / 255f);
        GameObject.Find("Left-Caudate").GetComponent<Renderer>().material.color = new Color(122 / 255f, 186 / 255f, 220 / 255f);
        GameObject.Find("Left-Putamen").GetComponent<Renderer>().material.color = new Color(236 / 255f, 13 / 255f, 176 / 255f);
        GameObject.Find("Left-Pallidum").GetComponent<Renderer>().material.color = new Color(12 / 255f, 48 / 255f, 255 / 255f);
        GameObject.Find("3rd-Ventricle").GetComponent<Renderer>().material.color = new Color(204 / 255f, 182 / 255f, 142 / 255f);
        GameObject.Find("4th-Ventricle").GetComponent<Renderer>().material.color = new Color(42 / 255f, 204 / 255f, 164 / 255f);
        GameObject.Find("Brain-Stem").GetComponent<Renderer>().material.color = new Color(119 / 255f, 159 / 255f, 176 / 255f);
        GameObject.Find("Left-Hippocampus").GetComponent<Renderer>().material.color = new Color(220 / 255f, 216 / 255f, 20 / 255f);
        GameObject.Find("Left-Amygdala").GetComponent<Renderer>().material.color = new Color(103 / 255f, 255 / 255f, 255 / 255f);
        GameObject.Find("CSF").GetComponent<Renderer>().material.color = new Color(60 / 255f, 60 / 255f, 60 / 255f);
        GameObject.Find("Left-Accumbens-area").GetComponent<Renderer>().material.color = new Color(255 / 255f, 165 / 255f, 0 / 255f);
        GameObject.Find("Left-VentralDC").GetComponent<Renderer>().material.color = new Color(165 / 255f, 42 / 255f, 42 / 255f);
        GameObject.Find("Left-vessel").GetComponent<Renderer>().material.color = new Color(160 / 255f, 32 / 255f, 240 / 255f);
        GameObject.Find("Left-choroid-plexus").GetComponent<Renderer>().material.color = new Color(0 / 255f, 200 / 255f, 200 / 255f);
        GameObject.Find("Right-Cerebral-White-Matter").GetComponent<Renderer>().material.color = new Color(245 / 255f, 245 / 255f, 245 / 255f);
        GameObject.Find("Right-Cerebral-Cortex").GetComponent<Renderer>().material.color = new Color(205 / 255f, 62 / 255f, 78 / 255f);
        GameObject.Find("Right-Lateral-Ventricle").GetComponent<Renderer>().material.color = new Color(120 / 255f, 18 / 255f, 134 / 255f);
        GameObject.Find("Right-Inf-Lat-Vent").GetComponent<Renderer>().material.color = new Color(196 / 255f, 58 / 255f, 250 / 255f);
        GameObject.Find("Right-Cerebellum-White-Matter").GetComponent<Renderer>().material.color = new Color(220 / 255f, 248 / 255f, 164 / 255f);
        GameObject.Find("Right-Cerebellum-Cortex").GetComponent<Renderer>().material.color = new Color(230 / 255f, 148 / 255f, 34 / 255f);
        GameObject.Find("Right-Thalamus-Proper").GetComponent<Renderer>().material.color = new Color(0 / 255f, 118 / 255f, 14 / 255f);
        GameObject.Find("Right-Caudate").GetComponent<Renderer>().material.color = new Color(122 / 255f, 186 / 255f, 220 / 255f);
        GameObject.Find("Right-Putamen").GetComponent<Renderer>().material.color = new Color(236 / 255f, 13 / 255f, 176 / 255f);
        GameObject.Find("Right-Pallidum").GetComponent<Renderer>().material.color = new Color(13 / 255f, 48 / 255f, 255 / 255f);
        GameObject.Find("Right-Hippocampus").GetComponent<Renderer>().material.color = new Color(220 / 255f, 216 / 255f, 20 / 255f);
        GameObject.Find("Right-Amygdala").GetComponent<Renderer>().material.color = new Color(103 / 255f, 255 / 255f, 255 / 255f);
        GameObject.Find("Right-Accumbens-area").GetComponent<Renderer>().material.color = new Color(255 / 255f, 165 / 255f, 0 / 255f);
        GameObject.Find("Right-VentralDC").GetComponent<Renderer>().material.color = new Color(165 / 255f, 42 / 255f, 42 / 255f);
        GameObject.Find("Right-choroid-plexus").GetComponent<Renderer>().material.color = new Color(0 / 255f, 20 / 255f, 221 / 255f);
        GameObject.Find("WM-hypointensities").GetComponent<Renderer>().material.color = new Color(200 / 255f, 70 / 255f, 255 / 255f);
        GameObject.Find("Optic-Chiasm").GetComponent<Renderer>().material.color = new Color(234 / 255f, 169 / 255f, 30 / 255f);
        GameObject.Find("CC_Posterior").GetComponent<Renderer>().material.color = new Color(0 / 255f, 0 / 255f, 64 / 255f);
        GameObject.Find("CC_Mid_Posterior").GetComponent<Renderer>().material.color = new Color(0 / 255f, 0 / 255f, 112 / 255f);
        GameObject.Find("CC_Central").GetComponent<Renderer>().material.color = new Color(0 / 255f, 0 / 255f, 160 / 255f);
        GameObject.Find("CC_Mid_Anterior").GetComponent<Renderer>().material.color = new Color(0 / 255f, 0 / 255f, 208 / 255f);
        GameObject.Find("CC_Anterior").GetComponent<Renderer>().material.color = new Color(0 / 255f, 0 / 255f, 255 / 255f);



        GameObject.Find("rh.bankssts").GetComponent<Renderer>().material.color = new Color(25 / 255f, 100 / 255f, 40 / 255f);
        GameObject.Find("rh.bankssts").gameObject.tag = "gyri";
        GameObject.Find("rh.caudalanteriorcingulate").GetComponent<Renderer>().material.color = new Color(125 / 255f, 100 / 255f, 160 / 255f);
        GameObject.Find("rh.caudalanteriorcingulate").gameObject.tag = "gyri";
        GameObject.Find("rh.caudalmiddlefrontal").GetComponent<Renderer>().material.color = new Color(100 / 255f, 25 / 255f, 0 / 255f);
        GameObject.Find("rh.caudalmiddlefrontal").gameObject.tag = "gyri";
        GameObject.Find("rh.corpuscallosum").GetComponent<Renderer>().material.color = new Color(120 / 255f, 70 / 255f, 50 / 255f);
        GameObject.Find("rh.corpuscallosum").gameObject.tag = "gyri";
        GameObject.Find("rh.cuneus").GetComponent<Renderer>().material.color = new Color(220 / 255f, 20 / 255f, 100 / 255f);
        GameObject.Find("rh.cuneus").gameObject.tag = "gyri";
        GameObject.Find("rh.entorhinal").GetComponent<Renderer>().material.color = new Color(220 / 255f, 20 / 255f, 10 / 255f);
        GameObject.Find("rh.entorhinal").gameObject.tag = "gyri";
        GameObject.Find("rh.fusiform").GetComponent<Renderer>().material.color = new Color(180 / 255f, 220 / 255f, 140 / 255f);
        GameObject.Find("rh.fusiform").gameObject.tag = "gyri";
        GameObject.Find("rh.inferiorparietal").GetComponent<Renderer>().material.color = new Color(220 / 255f, 60 / 255f, 220 / 255f);
        GameObject.Find("rh.inferiorparietal").gameObject.tag = "gyri";
        GameObject.Find("rh.inferiortemporal").GetComponent<Renderer>().material.color = new Color(180 / 255f, 40 / 255f, 120 / 255f);
        GameObject.Find("rh.inferiortemporal").gameObject.tag = "gyri";
        GameObject.Find("rh.isthmuscingulate").GetComponent<Renderer>().material.color = new Color(140 / 255f, 20 / 255f, 140 / 255f);
        GameObject.Find("rh.isthmuscingulate").gameObject.tag = "gyri";
        GameObject.Find("rh.lateraloccipital").GetComponent<Renderer>().material.color = new Color(20 / 255f, 30 / 255f, 140 / 255f);
        GameObject.Find("rh.lateraloccipital").gameObject.tag = "gyri";
        GameObject.Find("rh.lateralorbitofrontal").GetComponent<Renderer>().material.color = new Color(35 / 255f, 75 / 255f, 50 / 255f);
        GameObject.Find("rh.lateralorbitofrontal").gameObject.tag = "gyri";
        GameObject.Find("rh.lingual").GetComponent<Renderer>().material.color = new Color(225 / 255f, 140 / 255f, 140 / 255f);
        GameObject.Find("rh.lingual").gameObject.tag = "gyri";
        GameObject.Find("rh.medialorbitofrontal").GetComponent<Renderer>().material.color = new Color(200 / 255f, 35 / 255f, 75 / 255f);
        GameObject.Find("rh.medialorbitofrontal").gameObject.tag = "gyri";
        GameObject.Find("rh.middletemporal").GetComponent<Renderer>().material.color = new Color(160 / 255f, 100 / 255f, 50 / 255f);
        GameObject.Find("rh.middletemporal").gameObject.tag = "gyri";
        GameObject.Find("rh.parahippocampal").GetComponent<Renderer>().material.color = new Color(20 / 255f, 220 / 255f, 60 / 255f);
        GameObject.Find("rh.parahippocampal").gameObject.tag = "gyri";
        GameObject.Find("rh.paracentral").GetComponent<Renderer>().material.color = new Color(60 / 255f, 220 / 255f, 60 / 255f);
        GameObject.Find("rh.paracentral").gameObject.tag = "gyri";
        GameObject.Find("rh.parsopercularis").GetComponent<Renderer>().material.color = new Color(220 / 255f, 180 / 255f, 140 / 255f);
        GameObject.Find("rh.parsopercularis").gameObject.tag = "gyri";
        GameObject.Find("rh.parsorbitalis").GetComponent<Renderer>().material.color = new Color(20 / 255f, 100 / 255f, 50 / 255f);
        GameObject.Find("rh.parsorbitalis").gameObject.tag = "gyri";
        GameObject.Find("rh.parstriangularis").GetComponent<Renderer>().material.color = new Color(220 / 255f, 60 / 255f, 20 / 255f);
        GameObject.Find("rh.parstriangularis").gameObject.tag = "gyri";
        GameObject.Find("rh.pericalcarine").GetComponent<Renderer>().material.color = new Color(120 / 255f, 100 / 255f, 60 / 255f);
        GameObject.Find("rh.pericalcarine").gameObject.tag = "gyri";
        GameObject.Find("rh.postcentral").GetComponent<Renderer>().material.color = new Color(220 / 255f, 20 / 255f, 20 / 255f);
        GameObject.Find("rh.postcentral").gameObject.tag = "gyri";
        GameObject.Find("rh.posteriorcingulate").GetComponent<Renderer>().material.color = new Color(220 / 255f, 180 / 255f, 220 / 255f);
        GameObject.Find("rh.posteriorcingulate").gameObject.tag = "gyri";
        GameObject.Find("rh.precentral").GetComponent<Renderer>().material.color = new Color(60 / 255f, 20 / 255f, 220 / 255f);
        GameObject.Find("rh.precentral").gameObject.tag = "gyri";
        GameObject.Find("rh.precuneus").GetComponent<Renderer>().material.color = new Color(160 / 255f, 140 / 255f, 180 / 255f);
        GameObject.Find("rh.precuneus").gameObject.tag = "gyri";
        GameObject.Find("rh.rostralanteriorcingulate").GetComponent<Renderer>().material.color = new Color(80 / 255f, 20 / 255f, 140 / 255f);
        GameObject.Find("rh.rostralanteriorcingulate").gameObject.tag = "gyri";
        GameObject.Find("rh.rostralmiddlefrontal").GetComponent<Renderer>().material.color = new Color(75 / 255f, 50 / 255f, 125 / 255f);
        GameObject.Find("rh.rostralmiddlefrontal").gameObject.tag = "gyri";
        GameObject.Find("rh.superiorfrontal").GetComponent<Renderer>().material.color = new Color(20 / 255f, 220 / 255f, 160 / 255f);
        GameObject.Find("rh.superiorfrontal").gameObject.tag = "gyri";
        GameObject.Find("rh.superiorparietal").GetComponent<Renderer>().material.color = new Color(20 / 255f, 180 / 255f, 140 / 255f);
        GameObject.Find("rh.superiorparietal").gameObject.tag = "gyri";
        GameObject.Find("rh.superiortemporal").GetComponent<Renderer>().material.color = new Color(140 / 255f, 220 / 255f, 220 / 255f);
        GameObject.Find("rh.superiortemporal").gameObject.tag = "gyri";
        GameObject.Find("rh.supramarginal").GetComponent<Renderer>().material.color = new Color(80 / 255f, 160 / 255f, 20 / 255f);
        GameObject.Find("rh.supramarginal").gameObject.tag = "gyri";
        GameObject.Find("rh.frontalpole").GetComponent<Renderer>().material.color = new Color(100 / 255f, 0 / 255f, 100 / 255f);
        GameObject.Find("rh.frontalpole").gameObject.tag = "gyri";
        GameObject.Find("rh.temporalpole").GetComponent<Renderer>().material.color = new Color(70 / 255f, 20 / 255f, 170 / 255f);
        GameObject.Find("rh.temporalpole").gameObject.tag = "gyri";
        GameObject.Find("rh.transversetemporal").GetComponent<Renderer>().material.color = new Color(150 / 255f, 150 / 255f, 200 / 255f);
        GameObject.Find("rh.transversetemporal").gameObject.tag = "gyri";
        GameObject.Find("rh.insula").GetComponent<Renderer>().material.color = new Color(255 / 255f, 192 / 255f, 32 / 255f);
        GameObject.Find("rh.insula").gameObject.tag = "gyri";

        GameObject.Find("lh.bankssts").GetComponent<Renderer>().material.color = new Color(25 / 255f, 100 / 255f, 40 / 255f);
        GameObject.Find("lh.bankssts").gameObject.tag = "gyri";
        GameObject.Find("lh.caudalanteriorcingulate").GetComponent<Renderer>().material.color = new Color(125 / 255f, 100 / 255f, 160 / 255f);
        GameObject.Find("lh.caudalanteriorcingulate").gameObject.tag = "gyri";
        GameObject.Find("lh.caudalmiddlefrontal").GetComponent<Renderer>().material.color = new Color(100 / 255f, 25 / 255f, 0 / 255f);
        GameObject.Find("lh.caudalmiddlefrontal").gameObject.tag = "gyri";
        GameObject.Find("lh.corpuscallosum").GetComponent<Renderer>().material.color = new Color(120 / 255f, 70 / 255f, 50 / 255f);
        GameObject.Find("lh.corpuscallosum").gameObject.tag = "gyri";
        GameObject.Find("lh.cuneus").GetComponent<Renderer>().material.color = new Color(220 / 255f, 20 / 255f, 100 / 255f);
        GameObject.Find("lh.cuneus").gameObject.tag = "gyri";
        GameObject.Find("lh.entorhinal").GetComponent<Renderer>().material.color = new Color(220 / 255f, 20 / 255f, 10 / 255f);
        GameObject.Find("lh.entorhinal").gameObject.tag = "gyri";
        GameObject.Find("lh.fusiform").GetComponent<Renderer>().material.color = new Color(180 / 255f, 220 / 255f, 140 / 255f);
        GameObject.Find("lh.fusiform").gameObject.tag = "gyri";
        GameObject.Find("lh.inferiorparietal").GetComponent<Renderer>().material.color = new Color(220 / 255f, 60 / 255f, 220 / 255f);
        GameObject.Find("lh.inferiorparietal").gameObject.tag = "gyri";
        GameObject.Find("lh.inferiortemporal").GetComponent<Renderer>().material.color = new Color(180 / 255f, 40 / 255f, 120 / 255f);
        GameObject.Find("lh.inferiortemporal").gameObject.tag = "gyri";
        GameObject.Find("lh.isthmuscingulate").GetComponent<Renderer>().material.color = new Color(140 / 255f, 20 / 255f, 140 / 255f);
        GameObject.Find("lh.isthmuscingulate").gameObject.tag = "gyri";
        GameObject.Find("lh.lateraloccipital").GetComponent<Renderer>().material.color = new Color(20 / 255f, 30 / 255f, 140 / 255f);
        GameObject.Find("lh.lateraloccipital").gameObject.tag = "gyri";
        GameObject.Find("lh.lateralorbitofrontal").GetComponent<Renderer>().material.color = new Color(35 / 255f, 75 / 255f, 50 / 255f);
        GameObject.Find("lh.lateralorbitofrontal").gameObject.tag = "gyri";
        GameObject.Find("lh.lingual").GetComponent<Renderer>().material.color = new Color(225 / 255f, 140 / 255f, 140 / 255f);
        GameObject.Find("lh.lingual").gameObject.tag = "gyri";
        GameObject.Find("lh.medialorbitofrontal").GetComponent<Renderer>().material.color = new Color(200 / 255f, 35 / 255f, 75 / 255f);
        GameObject.Find("lh.medialorbitofrontal").gameObject.tag = "gyri";
        GameObject.Find("lh.middletemporal").GetComponent<Renderer>().material.color = new Color(160 / 255f, 100 / 255f, 50 / 255f);
        GameObject.Find("lh.middletemporal").gameObject.tag = "gyri";
        GameObject.Find("lh.parahippocampal").GetComponent<Renderer>().material.color = new Color(20 / 255f, 220 / 255f, 60 / 255f);
        GameObject.Find("lh.parahippocampal").gameObject.tag = "gyri";
        GameObject.Find("lh.paracentral").GetComponent<Renderer>().material.color = new Color(60 / 255f, 220 / 255f, 60 / 255f);
        GameObject.Find("lh.paracentral").gameObject.tag = "gyri";
        GameObject.Find("lh.parsopercularis").GetComponent<Renderer>().material.color = new Color(220 / 255f, 180 / 255f, 140 / 255f);
        GameObject.Find("lh.parsopercularis").gameObject.tag = "gyri";
        GameObject.Find("lh.parsorbitalis").GetComponent<Renderer>().material.color = new Color(20 / 255f, 100 / 255f, 50 / 255f);
        GameObject.Find("lh.parsorbitalis").gameObject.tag = "gyri";
        GameObject.Find("lh.parstriangularis").GetComponent<Renderer>().material.color = new Color(220 / 255f, 60 / 255f, 20 / 255f);
        GameObject.Find("lh.parstriangularis").gameObject.tag = "gyri";
        GameObject.Find("lh.pericalcarine").GetComponent<Renderer>().material.color = new Color(120 / 255f, 100 / 255f, 60 / 255f);
        GameObject.Find("lh.pericalcarine").gameObject.tag = "gyri";
        GameObject.Find("lh.postcentral").GetComponent<Renderer>().material.color = new Color(220 / 255f, 20 / 255f, 20 / 255f);
        GameObject.Find("lh.postcentral").gameObject.tag = "gyri";
        GameObject.Find("lh.posteriorcingulate").GetComponent<Renderer>().material.color = new Color(220 / 255f, 180 / 255f, 220 / 255f);
        GameObject.Find("lh.posteriorcingulate").gameObject.tag = "gyri";
        GameObject.Find("lh.precentral").GetComponent<Renderer>().material.color = new Color(60 / 255f, 20 / 255f, 220 / 255f);
        GameObject.Find("lh.precentral").gameObject.tag = "gyri";
        GameObject.Find("lh.precuneus").GetComponent<Renderer>().material.color = new Color(160 / 255f, 140 / 255f, 180 / 255f);
        GameObject.Find("lh.precuneus").gameObject.tag = "gyri";
        GameObject.Find("lh.rostralanteriorcingulate").GetComponent<Renderer>().material.color = new Color(80 / 255f, 20 / 255f, 140 / 255f);
        GameObject.Find("lh.rostralanteriorcingulate").gameObject.tag = "gyri";
        GameObject.Find("lh.rostralmiddlefrontal").GetComponent<Renderer>().material.color = new Color(75 / 255f, 50 / 255f, 125 / 255f);
        GameObject.Find("lh.rostralmiddlefrontal").gameObject.tag = "gyri";
        GameObject.Find("lh.superiorfrontal").GetComponent<Renderer>().material.color = new Color(20 / 255f, 220 / 255f, 160 / 255f);
        GameObject.Find("lh.superiorfrontal").gameObject.tag = "gyri";
        GameObject.Find("lh.superiorparietal").GetComponent<Renderer>().material.color = new Color(20 / 255f, 180 / 255f, 140 / 255f);
        GameObject.Find("lh.superiorparietal").gameObject.tag = "gyri";
        GameObject.Find("lh.superiortemporal").GetComponent<Renderer>().material.color = new Color(140 / 255f, 220 / 255f, 220 / 255f);
        GameObject.Find("lh.superiortemporal").gameObject.tag = "gyri";
        GameObject.Find("lh.supramarginal").GetComponent<Renderer>().material.color = new Color(80 / 255f, 160 / 255f, 20 / 255f);
        GameObject.Find("lh.supramarginal").gameObject.tag = "gyri";
        GameObject.Find("lh.frontalpole").GetComponent<Renderer>().material.color = new Color(100 / 255f, 0 / 255f, 100 / 255f);
        GameObject.Find("lh.frontalpole").gameObject.tag = "gyri";
        GameObject.Find("lh.temporalpole").GetComponent<Renderer>().material.color = new Color(70 / 255f, 20 / 255f, 170 / 255f);
        GameObject.Find("lh.temporalpole").gameObject.tag = "gyri";
        GameObject.Find("lh.transversetemporal").GetComponent<Renderer>().material.color = new Color(150 / 255f, 150 / 255f, 200 / 255f);
        GameObject.Find("lh.transversetemporal").gameObject.tag = "gyri";
        GameObject.Find("lh.insula").GetComponent<Renderer>().material.color = new Color(255 / 255f, 192 / 255f, 32 / 255f);
        GameObject.Find("lh.insula").gameObject.tag = "gyri";

    }
    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
