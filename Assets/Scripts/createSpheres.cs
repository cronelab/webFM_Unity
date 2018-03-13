﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class createSpheres : MonoBehaviour
{
    public void Start()
    {

        //elecLocations
        double[,] mydoub = new double[128, 3]
        {
            {-62.6053122964152, -45.4712595461583, -15.2897696720780},
            {-64.7893245044940, -40.4219551020625, -16.9403325551749},
            {-66.1179971051586, -35.5397478989638, -18.5161166131349},
            {-66.4546945617553, -30.8513307510370, -20.0051763627669},
            {-66.1696595010247, -26.2843738831945, -21.4398805946699},
            {-65.8265148613960, -21.7287691732845, -22.8695045450080},
            {-65.4094524400541, -17.1876048766067, -24.2926661676048},
            {-64.6520966928825, -12.7129195262830, -25.6860773438445},
            {-63.6574147453342, -8.28459769397675, -27.0587400661548},
            {-62.3152054315226, -3.92416803405467, -28.4010198996957},
            {-60.6212224089911,  0.367539897476812, -29.7125456042052},
            {-58.4963163615518,  4.57506366646038, -30.9863974803923},
            {-55.9951913534533,  8.70909013707018, -32.2273580796777},
            {-52.9719385646049,  12.7411148871295, -33.4226711938270},
            {-49.8775243502683,  16.7592376995707, -34.6117629571269},
            {-46.0851523271235,  20.6410090287258, -35.7398351388647},
            {-63.6768417917206, -44.2114344658595, -11.2024367271063},
            {-65.5032677009568, -39.2033130815725, -12.8012528318348},
            {-66.4411721876042, -34.3687712638046, -14.3223891617532},
            {-66.6450310098761, -29.6776309724244, -15.7793508972729},
            {-66.3884736085787, -25.0764365692059, -17.1960603353728},
            {-66.1285344235765, -20.4759028237212, -18.6124741180277},
            {-65.8685952385744, -15.8753690782366, -20.0288879006826},
            {-65.3057103066930, -11.3340181392496, -21.4188163822530},
            {-64.6660869568731, -6.80765864670656, -22.8020359394540},
            {-63.9271488616305, -2.30070106167098, -24.1765728167964},
            {-63.0595632470664,  2.18112423046781, -25.5398625704604},
            {-61.2522198809977,  6.47936054096592, -26.8209931677359},
            {-58.5340920496632,   10.5996680265040, -28.0224976239146},
            {-55.5613009305311,   14.6702250592331, -29.2017379158924},
            {-52.0874452170003,   18.6428952285929, -30.3371721905151},
            {-48.1031270267475,   22.5158425852201, -31.4279788295707},
            {-64.4705358756376, -43.0058866928336, -7.09081377444055},
            {-65.8717884057284, -38.0521520298576, -8.63197424025501},
            {-66.7077138012126, -33.2088584170036, -10.1237104790402},
            {-66.8146744925993, -28.5079737254518, -11.5517163308935},
            {-66.5821831308365, -23.8734036310968, -12.9500452854011},
            {-66.3222848870251, -19.2441876841879, -14.3459781688950},
            {-65.9430993041956, -14.6382754461955, -15.7314822507899},
            {-65.3739923633431, -10.0694658217813, -17.1003822892168},
            {-64.7778191746266, -5.50594379927751, -18.4669160368762},
            {-64.1816459859100, -0.942421776773747, -19.8334497845355},
            {-63.5273119903269,   3.60973808001557, -21.1948987719794},
            {-61.6924289135827,   7.93126849720706, -22.4531372070994},
            {-59.5554899464778,   12.1937899482888, -23.6849681376316},
            {-57.3089814762765,   16.4349061452398, -24.9072198570044},
            {-54.0775051392635,   20.4836012130995, -26.0433598854893},
            {-49.9063483474614,   24.3487223998327, -27.0973475153197},
            {-64.9803730932781, -41.8557925650987, -2.95437438303725},
            {-66.2141847968215, -36.9060945658882, -4.46041170734067},
            {-66.9248165527960, -32.0586038361951, -5.92070955988889},
            {-66.9777318608130, -27.3396031271435, -7.32350596760139},
            {-66.7758926530943, -22.6703706929877, -8.70403023542943},
            {-66.5002084379735, -18.0155644550366, -10.0780985378750},
            {-65.9970322947085, -13.4052005335790, -11.4322781563787},
            {-65.4387432681550, -8.80560334227279, -12.7816394820938},
            {-64.8403076587127, -4.21384909799962, -14.1274909571301},
            {-64.1619814647614,   0.362297899587671, -15.4663579268338},
            {-62.7968607038199,   4.80427423995165, -16.7451812713099},
            {-61.3186204305257,   9.22415180428182, -18.0141150419133},
            {-59.2806932804890,   13.5346901867065, -19.2341176900425},
            {-57.1504536273915,   17.8271946040988, -20.4460498355730},
            {-54.7864041188772,   22.0740224487947, -21.6375409467566},
            {-51.3555606457404,   26.1124438001450, -22.7357666477496},
            {-65.1558873260395, -40.7710110312048,   -1.21129349236099},
            {-66.4566684075855, -35.7795558401938, -0.280114210834803},
            {-67.1110274215318, -30.9143842248284, -1.71500789043256},
            {-67.1372590378816, -26.1719221791162, -3.09498697421193},
            {-66.9696021753521, -21.4673377548786, -4.45801518545774},
            {-66.5738743851909, -16.8073087591849, -5.80110409321712},
            {-66.0509652852213, -12.1721256209625, -7.13307406196745},
            {-65.5034941729669, -7.54174086276431, -8.46289667497074},
            {-64.8106200177380, -2.93976171925184, -9.78000729775316},
            {-63.4442863900751,   1.53065188141465, -11.0382401277975},
            {-61.9997222228755,   5.98578253808436, -12.2896335834160},
            {-60.5551580556758,   10.4409131947541, -13.5410270390345},
            {-58.9218025064027,   14.8591619874307, -14.7759152403363},
            {-56.8470679775812,   19.1911839655447, -15.9722154921914},
            {-54.7058834895766,  23.5102244276062, -17.1627062973248},
            {-52.1854295128846,  27.7551716469315, -18.3200391304335},
            {-65.0497040415297, -39.7412612969889,   5.40158902349147},
            {-66.0394680630135, -34.7818915030010,   3.95785674158748},
            {-66.7985204803977, -29.8675930142315,   2.53429462665633},
            {-67.1148559488762, -25.0397827227389,   1.14943743433187},
            {-67.0464339908271, -20.2871377852982, -0.201781998126149},
            {-66.6266202808318, -15.6031399580234, -1.52228069446299},
            {-66.0966209325955, -10.9406677516692, -2.83314631347802},
            {-65.4699129422510, -6.29708833028228, -4.13555709353229},
            {-64.1139004201437, -1.79598421817363, -5.37420777691903},
            {-62.6582420810374,   2.68565330902174, -6.60414683622054},
            {-61.2025837419311,   7.16729083621707, -7.83408589552207},
            {-59.7469254028248,   11.6489283634124, -9.06402495482358},
            {-58.2912670637185,   16.1305658906078, -10.2939640141251},
            {-56.4986644728334,    20.5463787390977, -11.4944454228440},
            {-54.3915530048592,   24.9007498337214, -12.6674306135461},
            {-52.1766178491384,   29.2340567328135, -13.8309892225469},
            {-64.5062388349918, -38.7969379853021, 9.63011431517491},
            {-65.4466776051784, -33.8185300593237,   8.21117881567144},
            {-66.1193680537622, -28.8924288492201,   6.81565145107522},
            {-66.4831364090620, -24.0266779713393,   5.44713187495786},
            {-66.6326527563677, -19.2027828886347,  4.09734347099969},
            {-66.1826720687130, 14.4960042116940,   2.79996662796868},
            {-65.3823217992996, -9.85767295602745,  1.53322115692204},
            {-64.4288869066258, -5.24924797146564,  0.279859245077759},
            {-63.2635783989837, -0.682214144514674, -0.954979427730809},
            {-61.8713754404990,   3.84049408777809, -2.16998165158150},
            {-60.4054452609867,   8.34879913434981, -3.37853820762813},
            {-58.9386927499738,   12.8569435320708, -4.58702287061268},
            {-57.4719402389609,   17.3650879297918, -5.79550753359724},
            {-55.9744539876988,   21.8672282524569, -7.00130527203395},
            {-54.0518706779123,   26.2863225603932, -8.16993852243563},
            {-51.9141483623230,   30.6633877912368, -9.31976305410661},
            {-63.9461411198878, -37.8558639634507,   13.8600937186975},
            {-64.8486299652754, -32.8561956470282,   12.4649605035686},
            {-65.3360107170908, -27.9376219233853,   11.1061184823388},
            {-65.4599374224823, -23.0900517728965,   9.77905175404201},
            {-65.5514560611592, -18.2488127901535,   8.45481832977195},
            {-64.9510872429904, -13.5427394002548,   7.19107378115016},
            {-64.1331114022633, -8.87917723370645,   5.94635371981671},
            {-63.1525898055055, -4.24736964409230,   4.71584436562418},
            {-62.0630648445446,  0.363143291024545,  3.49486472739525},
            {-60.8776352499592,  4.95492051048108,   2.28226963697104},
            {-59.5973107863113,  9.52815927963359,   1.07797081478754},
            {-58.1304600971228,  14.0649587007292, -0.110020786401778},
            {-56.6526134142033,  18.5996099689758, -1.29705105306937},
            {-55.1747667312838,  23.1342612372224, -2.48408131973696},
            {-53.5491691263777,  27.6400482143679, -3.65819433077499},
            {-51.5761960850094,  32.0779726997968, -4.80193773564146}
            };

        print(new Vector3((float)mydoub[1, 0], (float)mydoub[1, 1], (float)mydoub[1, 2]));
        for (int i = 0; i < 128; i++)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = new Vector3((float)mydoub[i, 0], (float)mydoub[i, 1], (float)mydoub[i, 2]);
        }
    }

}
