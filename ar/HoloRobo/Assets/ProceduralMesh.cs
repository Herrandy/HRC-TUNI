﻿using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(MeshFilter))]
public class ProceduralMesh : MonoBehaviour
{

    Mesh mesh;
    MeshRenderer meshrender;
    Vector3[] vertices;
    int[] triangles;
    // public Vector3 markerOffset = new Vector3(0.375f, 0.0f, 0.375f);
    public float markerOffset = 0.375f;

    public SSListener connector;


    // for some reason the mesh is not automatically scaled
    public float scaleFactor = 5.405406f; // correct: 5.405406f    1.0f

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        meshrender = GetComponent<MeshRenderer>();
        // markerOffset = markerOffset * scaleFactor;
    }

    // Use this for initialization
    /*void Start()
    {
        MakeMeshData(quadSize, quadOffset);
        CreateMesh();
    }*/


    public void setMeshVisibility(bool visible)
    {
        if (visible)
        {
            meshrender.enabled = true;
        }
        else
        {
            meshrender.enabled = false;
        }
    }



    private void Update()
    {
        // gameObject.GetComponent<MeshRenderer>().enabled = false;
        //string latest_msg = connector.latestRecievedMsg;
        string latest_msg = "ABCD-0.18954843079495926:0.3240487021204836:-0.4507784307949593:0.16302870212048357:-0.4751617575396856:0.14531317826618942:-0.49713247058113885:0.12468130542288522:-0.5163440786499873:0.10145846055019356:-0.5324936032105273:0.07601088178441165:-0.5453263566131803:0.048739892644322665:-0.5546399586708715:0.020075572919565153:-0.5602875283154747:-0.009530023944567017:-0.56218:-0.039610000000000076:-0.5602875283154747:-0.06968997605543303:-0.5546399586708715:-0.0992955729195652:-0.5453263566131803:-0.12795989264432278:-0.5324936032105272:-0.1552308817844117:-0.5163440786499873:-0.1806784605501936:-0.4971324705811388:-0.2039013054228853:-0.4751617575396855:-0.22453317826618946:-0.45077843079495916:-0.24224870212048366:-0.4243670299756173:-0.25676849259184475:-0.39634407864998744:-0.2678635639108368:-0.2700940786499874:-0.3085435639108368:-0.2409015155005739:-0.3160389401748853:-0.21099972468703515:-0.31981641482278517:-0.1808602753129647:-0.31981641482278517:-0.15095848449942595:-0.31603894017488526:-0.12176592135001266:-0.30854356391083687:-0.09374297002438257:-0.2974484925918447:0.10218702997561742:-0.2171584925918447:0.12859843079495922:-0.20263870212048357:0.28306843079495925:-0.10701870212048357:0.30745175753968557:-0.08930317826618937:0.3294224705811388:-0.06867130542288517:0.34863407864998747:-0.04544846055019343:0.3647836032105273:-0.020000881784411673:0.3776163566131803:0.007270107355677319:0.38692995867087143:0.03593442708043492:0.39257752831547466:0.0655400239445671:0.39447:0.09562:0.39257752831547466:0.125699976055433:0.38692995867087143:0.15530557291956515:0.37761635661318027:0.1839698926443227:0.3647836032105273:0.21124088178441167:0.31108360321052725:0.31821088178441165:0.2949340786499874:0.34365846055019356:0.27572247058113875:0.3668813054228853:0.2537517575396855:0.3875131782661894:0.22936843079495917:0.40522870212048356:0.20295702997561743:0.41974849259184466:0.1749340786499874:0.43084356391083684:0.14574151550057388:0.4383389401748853:0.11583972468703518:0.4421164148227852:0.08570027531296479:0.4421164148227852:0.055798484499426045:0.4383389401748853:0.026605921350012593:0.43084356391083684:-0.0014170299756174481:0.41974849259184466:-0.16313702997561744:0.3385684925918447:-0.18954843079495926:0.3240487021204836:-0.1959198942095934:0.32012138504731286:-0.20229135762422754:0.3161940679741421:-0.2086628210388617:0.3122667509009714:-0.21503428445349584:0.30833943382780066:-0.22140574786813:0.3044121167546299:-0.22777721128276412:0.3004847996814592:-0.23414867469739828:0.29655748260828846:-0.24052013811203243:0.2926301655351177:-0.24689160152666656:0.288702848461947:-0.2532630649413007:0.28477553138877626:-0.25963452835593487:0.2808482143156055:-0.266005991770569:0.2769208972424348:-0.2723774551852032:0.27299358016926406:-0.2787489185998373:0.2690662630960933:-0.28512038201447143:0.2651389460229226:-0.2914918454291056:0.26121162894975186:-0.29786330884373974:0.25728431187658113:-0.3042347722583739:0.2533569948034104:-0.31060623567300805:0.24942967773023966:-0.3169776990876422:0.24550236065706893:-0.3233491625022763:0.2415750435838982:-0.3297206259169105:0.23764772651072746:-0.33609208933154466:0.23372040943755673:-0.3424635527461788:0.22979309236438603:-0.3488350161608129:0.2258657752912153:-0.35520647957544704:0.22193845821804456:-0.36157794299008117:0.21801114114487383:-0.36794940640471535:0.2140838240717031:-0.37432086981934953:0.21015650699853236:-0.38069233323398366:0.20622918992536163:-0.3870637966486178:0.2023018728521909:-0.3934352600632519:0.19837455577902016:-0.3998067234778861:0.19444723870584943:-0.4061781868925202:0.1905199216326787:-0.4125496503071544:0.18659260455950796:-0.41892111372178853:0.18266528748633723:-0.42529257713642266:0.1787379704131665:-0.4316640405510568:0.17481065333999576:-0.43803550396569096:0.17088333626682503:-0.4444069673803251:0.1669560191936543:-0.4507784307949593:0.16302870212048357:-0.4507784307949593:0.16302870212048357:-0.45890620637653473:0.1571235275023855:-0.46703398195811013:0.15121835288428748:-0.4751617575396856:0.14531317826618942:-0.4751617575396856:0.14531317826618942:-0.48248532855350335:0.13843588731842135:-0.4898088995673211:0.13155859637065329:-0.49713247058113885:0.12468130542288522:-0.49713247058113885:0.12468130542288522:-0.5035363399374216:0.116940357131988:-0.5099402092937045:0.10919940884109078:-0.5163440786499873:0.10145846055019356:-0.5163440786499873:0.10145846055019356:-0.5217272535035007:0.09297593429493292:-0.5271104283570139:0.08449340803967229:-0.5324936032105273:0.07601088178441165:-0.5324936032105273:0.07601088178441165:-0.5367711876780783:0.06692055207104866:-0.5410487721456293:0.05783022235768566:-0.5453263566131803:0.048739892644322665:-0.5453263566131803:0.048739892644322665:-0.5499831576420259:0.03440773278194391:-0.5546399586708715:0.020075572919565153:-0.5546399586708715:0.020075572919565153:-0.5574637434931731:0.005272774487499068:-0.5602875283154747:-0.009530023944567017:-0.5602875283154747:-0.009530023944567017:-0.5612337641577374:-0.024570011972283548:-0.56218:-0.039610000000000076:-0.56218:-0.039610000000000076:-0.5612337641577374:-0.054649988027716555:-0.5602875283154747:-0.06968997605543303:-0.5602875283154747:-0.06968997605543303:-0.5574637434931731:-0.08449277448749912:-0.5546399586708715:-0.0992955729195652:-0.5546399586708715:-0.0992955729195652:-0.5499831576420259:-0.11362773278194399:-0.5453263566131803:-0.12795989264432278:-0.5453263566131803:-0.12795989264432278:-0.5410487721456293:-0.13705022235768574:-0.5367711876780782:-0.14614055207104873:-0.5324936032105272:-0.1552308817844117:-0.5324936032105272:-0.1552308817844117:-0.5271104283570139:-0.16371340803967233:-0.5217272535035006:-0.17219593429493296:-0.5163440786499873:-0.1806784605501936:-0.5163440786499873:-0.1806784605501936:-0.5099402092937044:-0.18841940884109082:-0.5035363399374216:-0.19616035713198807:-0.4971324705811388:-0.2039013054228853:-0.4971324705811388:-0.2039013054228853:-0.48980889956732104:-0.21077859637065335:-0.48248532855350323:-0.2176558873184214:-0.4751617575396855:-0.22453317826618946:-0.4751617575396855:-0.22453317826618946:-0.46703398195811:-0.23043835288428752:-0.4589062063765346:-0.2363435275023856:-0.45077843079495916:-0.24224870212048366:-0.45077843079495916:-0.24224870212048366:-0.4419746305218452:-0.24708863227760403:-0.43317083024873126:-0.2519285624347244:-0.4243670299756173:-0.25676849259184475:-0.4243670299756173:-0.25676849259184475:-0.41035555431280235:-0.2623160282513408:-0.39634407864998744:-0.2678635639108368:-0.39634407864998744:-0.2678635639108368:-0.38792741198332076:-0.2705755639108368:-0.37951074531665413:-0.2732875639108368:-0.37109407864998745:-0.2759995639108368:-0.36267741198332076:-0.27871156391083685:-0.3542607453166541:-0.28142356391083684:-0.34584407864998745:-0.28413556391083683:-0.33742741198332077:-0.2868475639108368:-0.3290107453166541:-0.2895595639108368:-0.32059407864998746:-0.2922715639108368:-0.3121774119833208:-0.2949835639108368:-0.3037607453166541:-0.2976955639108368:-0.29534407864998746:-0.30040756391083684:-0.2869274119833208:-0.30311956391083683:-0.2785107453166541:-0.3058315639108368:-0.2700940786499874:-0.3085435639108368:-0.2700940786499874:-0.3085435639108368:-0.25549779707528064:-0.31229125204286107:-0.2409015155005739:-0.3160389401748853:-0.2409015155005739:-0.3160389401748853:-0.2259506200938045:-0.3179276774988352:-0.21099972468703515:-0.31981641482278517:-0.21099972468703515:-0.31981641482278517:-0.19592999999999994:-0.31981641482278517:-0.1808602753129647:-0.31981641482278517:-0.1808602753129647:-0.31981641482278517:-0.1659093799061953:-0.3179276774988352:-0.15095848449942595:-0.31603894017488526:-0.15095848449942595:-0.31603894017488526:-0.1363622029247193:-0.31229125204286107:-0.12176592135001266:-0.30854356391083687:-0.12176592135001266:-0.30854356391083687:-0.10775444568719761:-0.30299602825134075:-0.09374297002438257:-0.2974484925918447:-0.09374297002438257:-0.2974484925918447:-0.08620720079361334:-0.29436041566876775:-0.07867143156284412:-0.29127233874569086:-0.07113566233207488:-0.2881842618226139:-0.06359989310130565:-0.285096184899537:-0.05606412387053642:-0.2820081079764601:-0.04852835463976719:-0.27892003105338314:-0.04099258540899796:-0.27583195413030626:-0.03345681617822873:-0.2727438772072293:-0.025921046947459503:-0.26965580028415237:-0.018385277716690268:-0.2665677233610755:-0.010849508485921033:-0.26347964643799854:-0.0033137392551518124:-0.2603915695149216:0.004222029975617422:-0.2573034925918447:0.011757799206386657:-0.25421541566876776:0.019293568437155878:-0.2511273387456908:0.026829337667925113:-0.24803926182261393:0.034365106898694334:-0.244951184899537:0.04190087612946357:-0.24186310797646007:0.0494366453602328:-0.23877503105338316:0.05697241459100204:-0.23568695413030624:0.06450818382177127:-0.23259887720722933:0.07204395305254051:-0.22951080028415238:0.07957972228330971:-0.22642272336107547:0.08711549151407895:-0.22333464643799855:0.09465126074484818:-0.2202465695149216:0.10218702997561742:-0.2171584925918447:0.10218702997561742:-0.2171584925918447:0.11099083024873135:-0.21231856243472433:0.11979463052184529:-0.20747863227760394:0.12859843079495922:-0.20263870212048357:0.12859843079495922:-0.20263870212048357:0.13503468079495923:-0.1986545354538169:0.14147093079495923:-0.19467036878715024:0.14790718079495924:-0.19068620212048357:0.1543434307949592:-0.18670203545381692:0.16077968079495925:-0.18271786878715024:0.16721593079495922:-0.17873370212048356:0.17365218079495923:-0.1747495354538169:0.18008843079495923:-0.17076536878715023:0.18652468079495924:-0.16678120212048358:0.19296093079495924:-0.1627970354538169:0.19939718079495922:-0.15881286878715023:0.20583343079495925:-0.15482870212048358:0.21226968079495923:-0.1508445354538169:0.21870593079495923:-0.14686036878715025:0.22514218079495923:-0.14287620212048358:0.23157843079495924:-0.1388920354538169:0.23801468079495924:-0.13490786878715025:0.24445093079495925:-0.1309237021204836:0.25088718079495925:-0.12693953545381692:0.25732343079495923:-0.12295536878715024:0.26375968079495926:-0.11897120212048358:0.27019593079495924:-0.11498703545381692:0.2766321807949592:-0.11100286878715025:0.28306843079495925:-0.10701870212048357:0.28306843079495925:-0.10701870212048357:0.2911962063765347:-0.1011135275023855:0.2993239819581101:-0.09520835288428744:0.30745175753968557:-0.08930317826618937:0.30745175753968557:-0.08930317826618937:0.3147753285535033:-0.0824258873184213:0.3220988995673211:-0.07554859637065324:0.3294224705811388:-0.06867130542288517:0.3294224705811388:-0.06867130542288517:0.3358263399374217:-0.060930357131987925:0.34223020929370457:-0.05318940884109068:0.34863407864998747:-0.04544846055019343:0.34863407864998747:-0.04544846055019343:0.3540172535035007:-0.03696593429493284:0.359400428357014:-0.028483408039672257:0.3647836032105273:-0.020000881784411673:0.3647836032105273:-0.020000881784411673:0.3690611876780783:-0.010910552071048676:0.3733387721456293:-0.0018202223576856795:0.3776163566131803:0.007270107355677319:0.3776163566131803:0.007270107355677319:0.38227315764202585:0.02160226721805612:0.38692995867087143:0.03593442708043492:0.38692995867087143:0.03593442708043492:0.38975374349317304:0.05073722551250101:0.39257752831547466:0.0655400239445671:0.39257752831547466:0.0655400239445671:0.3935237641577373:0.08058001197228354:0.39447:0.09562:0.39447:0.09562:0.3935237641577373:0.11065998802771651:0.39257752831547466:0.125699976055433:0.39257752831547466:0.125699976055433:0.38975374349317304:0.1405027744874991:0.38692995867087143:0.15530557291956515:0.38692995867087143:0.15530557291956515:0.38227315764202585:0.16963773278194394:0.37761635661318027:0.1839698926443227:0.37761635661318027:0.1839698926443227:0.37333877214562927:0.1930602223576857:0.3690611876780783:0.20215055207104868:0.3647836032105273:0.21124088178441167:0.3647836032105273:0.21124088178441167:0.36120360321052725:0.218372215117745:0.3576236032105273:0.22550354845107834:0.35404360321052725:0.23263488178441166:0.3504636032105273:0.23976621511774499:0.34688360321052725:0.24689754845107834:0.3433036032105273:0.25402888178441163:0.33972360321052725:0.261160215117745:0.3361436032105273:0.26829154845107833:0.33256360321052725:0.27542288178441166:0.3289836032105273:0.282554215117745:0.32540360321052725:0.2896855484510783:0.3218236032105273:0.2968168817844117:0.31824360321052725:0.303948215117745:0.3146636032105272:0.3110795484510783:0.31108360321052725:0.31821088178441165:0.31108360321052725:0.31821088178441165:0.30570042835701394:0.3266934080396723:0.3003172535035007:0.3351759342949329:0.2949340786499874:0.34365846055019356:0.2949340786499874:0.34365846055019356:0.2885302092937045:0.3513994088410908:0.28212633993742164:0.35914035713198805:0.27572247058113875:0.3668813054228853:0.27572247058113875:0.3668813054228853:0.268398899567321:0.37375859637065334:0.26107532855350324:0.38063588731842135:0.2537517575396855:0.3875131782661894:0.2537517575396855:0.3875131782661894:0.24562398195811005:0.39341835288428745:0.2374962063765346:0.39932352750238553:0.22936843079495917:0.40522870212048356:0.22936843079495917:0.40522870212048356:0.22056463052184525:0.41006863227760393:0.21176083024873135:0.4149085624347243:0.20295702997561743:0.41974849259184466:0.20295702997561743:0.41974849259184466:0.1889455543128024:0.4252960282513407:0.1749340786499874:0.43084356391083684:0.1749340786499874:0.43084356391083684:0.16033779707528062:0.4345912520428611:0.14574151550057388:0.4383389401748853:0.14574151550057388:0.4383389401748853:0.13079062009380454:0.44022767749883523:0.11583972468703518:0.4421164148227852:0.11583972468703518:0.4421164148227852:0.10076999999999998:0.4421164148227852:0.08570027531296479:0.4421164148227852:0.08570027531296479:0.4421164148227852:0.07074937990619541:0.44022767749883523:0.055798484499426045:0.4383389401748853:0.055798484499426045:0.4383389401748853:0.04120220292471932:0.4345912520428611:0.026605921350012593:0.43084356391083684:0.026605921350012593:0.43084356391083684:0.012594445687197572:0.4252960282513407:-0.0014170299756174481:0.41974849259184466:-0.0014170299756174481:0.41974849259184466:-0.008448334323443534:0.4162189273744534:-0.01547963867126962:0.41268936215706203:-0.022510943019095706:0.40915979693967075:-0.029542247366921792:0.40563023172227947:-0.03657355171474788:0.4021006665048881:-0.043604856062573964:0.39857110128749684:-0.05063616041040005:0.39504153607010556:-0.057667464758226136:0.3915119708527142:-0.06469876910605223:0.38798240563532294:-0.07173007345387832:0.3844528404179316:-0.07876137780170439:0.3809232752005403:-0.08579268214953048:0.37739370998314903:-0.09282398649735657:0.3738641447657577:-0.09985529084518265:0.3703345795483664:-0.10688659519300873:0.3668050143309751:-0.11391789954083482:0.3632754491135838:-0.12094920388866091:0.3597458838961925:-0.127980508236487:0.3562163186788012:-0.1350118125843131:0.3526867534614099:-0.14204311693213917:0.3491571882440186:-0.14907442127996523:0.3456276230266273:-0.15610572562779135:0.34209805780923597:-0.16313702997561744:0.3385684925918447:-0.18954843079495926:0.3240487021204836:-0.1807446305218453:0.32888863227760395:-0.17194083024873139:0.3337285624347243:-0.16313702997561744:0.3385684925918447";
        // string latest_msg = "0.277:-0.740:0.210:0.116:0.102:0.217:-0.151:0.233:-0.289:0.178:-0.368:0.053:-0.310:-0.885:-0.247:-1.019:-0.117:-1.090:0.030:-1.072:0.231:-0.881:0.277:-0.740:0.275:-0.691:0.272:-0.642:0.270:-0.594:0.267:-0.545:0.265:-0.496:0.263:-0.448:0.260:-0.399:0.258:-0.350:0.255:-0.302:0.253:-0.253:0.250:-0.204:0.248:-0.156:0.245:-0.107:0.243:-0.058:0.240:-0.010:0.238:0.030:0.223:0.088:0.210:0.116:0.188:0.149:0.160:0.178:0.129:0.203:0.102:0.217:0.045:0.236:-0.000:0.240:-0.046:0.238:-0.099:0.235:-0.151:0.233:-0.195:0.225:-0.238:0.210:-0.273:0.190:-0.303:0.164:-0.330:0.134:-0.346:0.109:-0.364:0.067:-0.374:0.023:-0.375:-0.027:-0.372:-0.076:-0.370:-0.126:-0.367:-0.176:-0.365:-0.226:-0.362:-0.275:-0.360:-0.325:-0.357:-0.370:-0.354:-0.413:-0.349:-0.461:-0.345:-0.508:-0.341:-0.555:-0.336:-0.602:-0.332:-0.649:-0.327:-0.696:-0.323:-0.743:-0.319:-0.790:-0.314:-0.837:-0.310:-0.885:-0.300:-0.929:-0.282:-0.970:-0.266:-0.996:-0.239:-1.026:-0.209:-1.051:-0.174:-1.072:-0.131:-1.087:-0.087:-1.094:-0.027:-1.090:0.016:-1.077:0.057:-1.057:0.081:-1.039:0.108:-1.013:0.134:-0.986:0.160:-0.959:0.186:-0.931:0.212:-0.904:0.231:-0.881:0.252:-0.846:0.270:-0.799:0.276:-0.755";

        // string latest_msg = "0.00:0.00:0.00:0.01:0.01:0.01:0.01:0.00";

        // Debug.Log("moro");
        /*
        // parse the message
        string latest_msg = TCP_connector.Instance.latest_recieved_msg;
        // string latest_msg = "-0.18954843079495926:0.3240487021204836:-0.4507784307949593:0.16302870212048357:-0.4751617575396856:0.14531317826618942:-0.49713247058113885:0.12468130542288522:-0.5163440786499873:0.10145846055019356:-0.5324936032105273:0.07601088178441165:-0.5453263566131803:0.048739892644322665:-0.5546399586708715:0.020075572919565153:-0.5602875283154747:-0.009530023944567017:-0.56218:-0.039610000000000076:-0.5602875283154747:-0.06968997605543303:-0.5546399586708715:-0.0992955729195652:-0.5453263566131803:-0.12795989264432278:-0.5324936032105272:-0.1552308817844117:-0.5163440786499873:-0.1806784605501936:-0.4971324705811388:-0.2039013054228853:-0.4751617575396855:-0.22453317826618946:-0.45077843079495916:-0.24224870212048366:-0.4243670299756173:-0.25676849259184475:-0.39634407864998744:-0.2678635639108368:-0.2700940786499874:-0.3085435639108368:-0.2409015155005739:-0.3160389401748853:-0.21099972468703515:-0.31981641482278517:-0.1808602753129647:-0.31981641482278517:-0.15095848449942595:-0.31603894017488526:-0.12176592135001266:-0.30854356391083687:-0.09374297002438257:-0.2974484925918447:0.10218702997561742:-0.2171584925918447:0.12859843079495922:-0.20263870212048357:0.28306843079495925:-0.10701870212048357:0.30745175753968557:-0.08930317826618937:0.3294224705811388:-0.06867130542288517:0.34863407864998747:-0.04544846055019343:0.3647836032105273:-0.020000881784411673:0.3776163566131803:0.007270107355677319:0.38692995867087143:0.03593442708043492:0.39257752831547466:0.0655400239445671:0.39447:0.09562:0.39257752831547466:0.125699976055433:0.38692995867087143:0.15530557291956515:0.37761635661318027:0.1839698926443227:0.3647836032105273:0.21124088178441167:0.31108360321052725:0.31821088178441165:0.2949340786499874:0.34365846055019356:0.27572247058113875:0.3668813054228853:0.2537517575396855:0.3875131782661894:0.22936843079495917:0.40522870212048356:0.20295702997561743:0.41974849259184466:0.1749340786499874:0.43084356391083684:0.14574151550057388:0.4383389401748853:0.11583972468703518:0.4421164148227852:0.08570027531296479:0.4421164148227852:0.055798484499426045:0.4383389401748853:0.026605921350012593:0.43084356391083684:-0.0014170299756174481:0.41974849259184466:-0.16313702997561744:0.3385684925918447:-0.18954843079495926:0.3240487021204836:-0.1959198942095934:0.32012138504731286:-0.20229135762422754:0.3161940679741421:-0.2086628210388617:0.3122667509009714:-0.21503428445349584:0.30833943382780066:-0.22140574786813:0.3044121167546299:-0.22777721128276412:0.3004847996814592:-0.23414867469739828:0.29655748260828846:-0.24052013811203243:0.2926301655351177:-0.24689160152666656:0.288702848461947:-0.2532630649413007:0.28477553138877626:-0.25963452835593487:0.2808482143156055:-0.266005991770569:0.2769208972424348:-0.2723774551852032:0.27299358016926406:-0.2787489185998373:0.2690662630960933:-0.28512038201447143:0.2651389460229226:-0.2914918454291056:0.26121162894975186:-0.29786330884373974:0.25728431187658113:-0.3042347722583739:0.2533569948034104:-0.31060623567300805:0.24942967773023966:-0.3169776990876422:0.24550236065706893:-0.3233491625022763:0.2415750435838982:-0.3297206259169105:0.23764772651072746:-0.33609208933154466:0.23372040943755673:-0.3424635527461788:0.22979309236438603:-0.3488350161608129:0.2258657752912153:-0.35520647957544704:0.22193845821804456:-0.36157794299008117:0.21801114114487383:-0.36794940640471535:0.2140838240717031:-0.37432086981934953:0.21015650699853236:-0.38069233323398366:0.20622918992536163:-0.3870637966486178:0.2023018728521909:-0.3934352600632519:0.19837455577902016:-0.3998067234778861:0.19444723870584943:-0.4061781868925202:0.1905199216326787:-0.4125496503071544:0.18659260455950796:-0.41892111372178853:0.18266528748633723:-0.42529257713642266:0.1787379704131665:-0.4316640405510568:0.17481065333999576:-0.43803550396569096:0.17088333626682503:-0.4444069673803251:0.1669560191936543:-0.4507784307949593:0.16302870212048357:-0.4507784307949593:0.16302870212048357:-0.45890620637653473:0.1571235275023855:-0.46703398195811013:0.15121835288428748:-0.4751617575396856:0.14531317826618942:-0.4751617575396856:0.14531317826618942:-0.48248532855350335:0.13843588731842135:-0.4898088995673211:0.13155859637065329:-0.49713247058113885:0.12468130542288522:-0.49713247058113885:0.12468130542288522:-0.5035363399374216:0.116940357131988:-0.5099402092937045:0.10919940884109078:-0.5163440786499873:0.10145846055019356:-0.5163440786499873:0.10145846055019356:-0.5217272535035007:0.09297593429493292:-0.5271104283570139:0.08449340803967229:-0.5324936032105273:0.07601088178441165:-0.5324936032105273:0.07601088178441165:-0.5367711876780783:0.06692055207104866:-0.5410487721456293:0.05783022235768566:-0.5453263566131803:0.048739892644322665:-0.5453263566131803:0.048739892644322665:-0.5499831576420259:0.03440773278194391:-0.5546399586708715:0.020075572919565153:-0.5546399586708715:0.020075572919565153:-0.5574637434931731:0.005272774487499068:-0.5602875283154747:-0.009530023944567017:-0.5602875283154747:-0.009530023944567017:-0.5612337641577374:-0.024570011972283548:-0.56218:-0.039610000000000076:-0.56218:-0.039610000000000076:-0.5612337641577374:-0.054649988027716555:-0.5602875283154747:-0.06968997605543303:-0.5602875283154747:-0.06968997605543303:-0.5574637434931731:-0.08449277448749912:-0.5546399586708715:-0.0992955729195652:-0.5546399586708715:-0.0992955729195652:-0.5499831576420259:-0.11362773278194399:-0.5453263566131803:-0.12795989264432278:-0.5453263566131803:-0.12795989264432278:-0.5410487721456293:-0.13705022235768574:-0.5367711876780782:-0.14614055207104873:-0.5324936032105272:-0.1552308817844117:-0.5324936032105272:-0.1552308817844117:-0.5271104283570139:-0.16371340803967233:-0.5217272535035006:-0.17219593429493296:-0.5163440786499873:-0.1806784605501936:-0.5163440786499873:-0.1806784605501936:-0.5099402092937044:-0.18841940884109082:-0.5035363399374216:-0.19616035713198807:-0.4971324705811388:-0.2039013054228853:-0.4971324705811388:-0.2039013054228853:-0.48980889956732104:-0.21077859637065335:-0.48248532855350323:-0.2176558873184214:-0.4751617575396855:-0.22453317826618946:-0.4751617575396855:-0.22453317826618946:-0.46703398195811:-0.23043835288428752:-0.4589062063765346:-0.2363435275023856:-0.45077843079495916:-0.24224870212048366:-0.45077843079495916:-0.24224870212048366:-0.4419746305218452:-0.24708863227760403:-0.43317083024873126:-0.2519285624347244:-0.4243670299756173:-0.25676849259184475:-0.4243670299756173:-0.25676849259184475:-0.41035555431280235:-0.2623160282513408:-0.39634407864998744:-0.2678635639108368:-0.39634407864998744:-0.2678635639108368:-0.38792741198332076:-0.2705755639108368:-0.37951074531665413:-0.2732875639108368:-0.37109407864998745:-0.2759995639108368:-0.36267741198332076:-0.27871156391083685:-0.3542607453166541:-0.28142356391083684:-0.34584407864998745:-0.28413556391083683:-0.33742741198332077:-0.2868475639108368:-0.3290107453166541:-0.2895595639108368:-0.32059407864998746:-0.2922715639108368:-0.3121774119833208:-0.2949835639108368:-0.3037607453166541:-0.2976955639108368:-0.29534407864998746:-0.30040756391083684:-0.2869274119833208:-0.30311956391083683:-0.2785107453166541:-0.3058315639108368:-0.2700940786499874:-0.3085435639108368:-0.2700940786499874:-0.3085435639108368:-0.25549779707528064:-0.31229125204286107:-0.2409015155005739:-0.3160389401748853:-0.2409015155005739:-0.3160389401748853:-0.2259506200938045:-0.3179276774988352:-0.21099972468703515:-0.31981641482278517:-0.21099972468703515:-0.31981641482278517:-0.19592999999999994:-0.31981641482278517:-0.1808602753129647:-0.31981641482278517:-0.1808602753129647:-0.31981641482278517:-0.1659093799061953:-0.3179276774988352:-0.15095848449942595:-0.31603894017488526:-0.15095848449942595:-0.31603894017488526:-0.1363622029247193:-0.31229125204286107:-0.12176592135001266:-0.30854356391083687:-0.12176592135001266:-0.30854356391083687:-0.10775444568719761:-0.30299602825134075:-0.09374297002438257:-0.2974484925918447:-0.09374297002438257:-0.2974484925918447:-0.08620720079361334:-0.29436041566876775:-0.07867143156284412:-0.29127233874569086:-0.07113566233207488:-0.2881842618226139:-0.06359989310130565:-0.285096184899537:-0.05606412387053642:-0.2820081079764601:-0.04852835463976719:-0.27892003105338314:-0.04099258540899796:-0.27583195413030626:-0.03345681617822873:-0.2727438772072293:-0.025921046947459503:-0.26965580028415237:-0.018385277716690268:-0.2665677233610755:-0.010849508485921033:-0.26347964643799854:-0.0033137392551518124:-0.2603915695149216:0.004222029975617422:-0.2573034925918447:0.011757799206386657:-0.25421541566876776:0.019293568437155878:-0.2511273387456908:0.026829337667925113:-0.24803926182261393:0.034365106898694334:-0.244951184899537:0.04190087612946357:-0.24186310797646007:0.0494366453602328:-0.23877503105338316:0.05697241459100204:-0.23568695413030624:0.06450818382177127:-0.23259887720722933:0.07204395305254051:-0.22951080028415238:0.07957972228330971:-0.22642272336107547:0.08711549151407895:-0.22333464643799855:0.09465126074484818:-0.2202465695149216:0.10218702997561742:-0.2171584925918447:0.10218702997561742:-0.2171584925918447:0.11099083024873135:-0.21231856243472433:0.11979463052184529:-0.20747863227760394:0.12859843079495922:-0.20263870212048357:0.12859843079495922:-0.20263870212048357:0.13503468079495923:-0.1986545354538169:0.14147093079495923:-0.19467036878715024:0.14790718079495924:-0.19068620212048357:0.1543434307949592:-0.18670203545381692:0.16077968079495925:-0.18271786878715024:0.16721593079495922:-0.17873370212048356:0.17365218079495923:-0.1747495354538169:0.18008843079495923:-0.17076536878715023:0.18652468079495924:-0.16678120212048358:0.19296093079495924:-0.1627970354538169:0.19939718079495922:-0.15881286878715023:0.20583343079495925:-0.15482870212048358:0.21226968079495923:-0.1508445354538169:0.21870593079495923:-0.14686036878715025:0.22514218079495923:-0.14287620212048358:0.23157843079495924:-0.1388920354538169:0.23801468079495924:-0.13490786878715025:0.24445093079495925:-0.1309237021204836:0.25088718079495925:-0.12693953545381692:0.25732343079495923:-0.12295536878715024:0.26375968079495926:-0.11897120212048358:0.27019593079495924:-0.11498703545381692:0.2766321807949592:-0.11100286878715025:0.28306843079495925:-0.10701870212048357:0.28306843079495925:-0.10701870212048357:0.2911962063765347:-0.1011135275023855:0.2993239819581101:-0.09520835288428744:0.30745175753968557:-0.08930317826618937:0.30745175753968557:-0.08930317826618937:0.3147753285535033:-0.0824258873184213:0.3220988995673211:-0.07554859637065324:0.3294224705811388:-0.06867130542288517:0.3294224705811388:-0.06867130542288517:0.3358263399374217:-0.060930357131987925:0.34223020929370457:-0.05318940884109068:0.34863407864998747:-0.04544846055019343:0.34863407864998747:-0.04544846055019343:0.3540172535035007:-0.03696593429493284:0.359400428357014:-0.028483408039672257:0.3647836032105273:-0.020000881784411673:0.3647836032105273:-0.020000881784411673:0.3690611876780783:-0.010910552071048676:0.3733387721456293:-0.0018202223576856795:0.3776163566131803:0.007270107355677319:0.3776163566131803:0.007270107355677319:0.38227315764202585:0.02160226721805612:0.38692995867087143:0.03593442708043492:0.38692995867087143:0.03593442708043492:0.38975374349317304:0.05073722551250101:0.39257752831547466:0.0655400239445671:0.39257752831547466:0.0655400239445671:0.3935237641577373:0.08058001197228354:0.39447:0.09562:0.39447:0.09562:0.3935237641577373:0.11065998802771651:0.39257752831547466:0.125699976055433:0.39257752831547466:0.125699976055433:0.38975374349317304:0.1405027744874991:0.38692995867087143:0.15530557291956515:0.38692995867087143:0.15530557291956515:0.38227315764202585:0.16963773278194394:0.37761635661318027:0.1839698926443227:0.37761635661318027:0.1839698926443227:0.37333877214562927:0.1930602223576857:0.3690611876780783:0.20215055207104868:0.3647836032105273:0.21124088178441167:0.3647836032105273:0.21124088178441167:0.36120360321052725:0.218372215117745:0.3576236032105273:0.22550354845107834:0.35404360321052725:0.23263488178441166:0.3504636032105273:0.23976621511774499:0.34688360321052725:0.24689754845107834:0.3433036032105273:0.25402888178441163:0.33972360321052725:0.261160215117745:0.3361436032105273:0.26829154845107833:0.33256360321052725:0.27542288178441166:0.3289836032105273:0.282554215117745:0.32540360321052725:0.2896855484510783:0.3218236032105273:0.2968168817844117:0.31824360321052725:0.303948215117745:0.3146636032105272:0.3110795484510783:0.31108360321052725:0.31821088178441165:0.31108360321052725:0.31821088178441165:0.30570042835701394:0.3266934080396723:0.3003172535035007:0.3351759342949329:0.2949340786499874:0.34365846055019356:0.2949340786499874:0.34365846055019356:0.2885302092937045:0.3513994088410908:0.28212633993742164:0.35914035713198805:0.27572247058113875:0.3668813054228853:0.27572247058113875:0.3668813054228853:0.268398899567321:0.37375859637065334:0.26107532855350324:0.38063588731842135:0.2537517575396855:0.3875131782661894:0.2537517575396855:0.3875131782661894:0.24562398195811005:0.39341835288428745:0.2374962063765346:0.39932352750238553:0.22936843079495917:0.40522870212048356:0.22936843079495917:0.40522870212048356:0.22056463052184525:0.41006863227760393:0.21176083024873135:0.4149085624347243:0.20295702997561743:0.41974849259184466:0.20295702997561743:0.41974849259184466:0.1889455543128024:0.4252960282513407:0.1749340786499874:0.43084356391083684:0.1749340786499874:0.43084356391083684:0.16033779707528062:0.4345912520428611:0.14574151550057388:0.4383389401748853:0.14574151550057388:0.4383389401748853:0.13079062009380454:0.44022767749883523:0.11583972468703518:0.4421164148227852:0.11583972468703518:0.4421164148227852:0.10076999999999998:0.4421164148227852:0.08570027531296479:0.4421164148227852:0.08570027531296479:0.4421164148227852:0.07074937990619541:0.44022767749883523:0.055798484499426045:0.4383389401748853:0.055798484499426045:0.4383389401748853:0.04120220292471932:0.4345912520428611:0.026605921350012593:0.43084356391083684:0.026605921350012593:0.43084356391083684:0.012594445687197572:0.4252960282513407:-0.0014170299756174481:0.41974849259184466:-0.0014170299756174481:0.41974849259184466:-0.008448334323443534:0.4162189273744534:-0.01547963867126962:0.41268936215706203:-0.022510943019095706:0.40915979693967075:-0.029542247366921792:0.40563023172227947:-0.03657355171474788:0.4021006665048881:-0.043604856062573964:0.39857110128749684:-0.05063616041040005:0.39504153607010556:-0.057667464758226136:0.3915119708527142:-0.06469876910605223:0.38798240563532294:-0.07173007345387832:0.3844528404179316:-0.07876137780170439:0.3809232752005403:-0.08579268214953048:0.37739370998314903:-0.09282398649735657:0.3738641447657577:-0.09985529084518265:0.3703345795483664:-0.10688659519300873:0.3668050143309751:-0.11391789954083482:0.3632754491135838:-0.12094920388866091:0.3597458838961925:-0.127980508236487:0.3562163186788012:-0.1350118125843131:0.3526867534614099:-0.14204311693213917:0.3491571882440186:-0.14907442127996523:0.3456276230266273:-0.15610572562779135:0.34209805780923597:-0.16313702997561744:0.3385684925918447:-0.18954843079495926:0.3240487021204836:-0.1807446305218453:0.32888863227760395:-0.17194083024873139:0.3337285624347243:-0.16313702997561744:0.3385684925918447";
        // string latest_msg = "-0.18954843079495926:0.3240487021204836\n";
        */
        // Debug.Log(latest_msg);
        // return;
        if (String.IsNullOrEmpty(latest_msg))
        {
            // Debug.Log("Empty message");
            return;
        }

        // hull parameters are the final parts
        latest_msg = latest_msg.Substring(4, latest_msg.Length - 4);


        // if (latest_msg.Length > nBytes)
        //     latest_msg = latest_msg.Substring(0, nBytes);


        // latest_msg = latest_msg.Remove(latest_msg.Length - 1); // remove trailing \n    
        // Debug.Log("here 1");
        string[] words = latest_msg.Split(':');
        // Debug.Log(words.Length);
        // Array.Resize(ref words, words.Length - 1); // remove the appendix
        // Debug.Log(words.Length);
        // Debug.Log("here 2");
        // sanity check (we should recieve (x,y)  pairs
        if (words.Length % 2 != 0) {
            // Debug.Log("Invalid type");
            return;
        }

        if (MakeMeshData(words)) {
            // Debug.Log("Creating mesh!");
            CreateMesh();
        }
    }



    private bool MakeMeshData(string[] words)
    {

        // number of vectices must be dividable by 3 because to form a triangle
        // we exatcly 3 vertices

        vertices = new Vector3[words.Length];
        int modulo = (vertices.Length / 2) % 6;
        triangles = new int[(vertices.Length / 2) - modulo];

        // Debug.Log("Triangle size: " + triangles.Length);

        // there must be 
        //if (triangles.Length % 3 != 0) // TODO: fix me
        //    return false;


        for (int i = 0; i < vertices.Length / 2; ++i)
        {
            /*
            Vector3 floor_pt, ceiling_pt;
            floor_pt.x = Convert.ToSingle(words[i * 2]) + markerOffset.x;
            floor_pt.y = Convert.ToSingle(words[(i * 2) + 1]) + markerOffset.y;
            floor_pt.z = 0.0f;

            ceiling_pt.x = Convert.ToSingle(words[i * 2]) + markerOffset.x;
            ceiling_pt.y = Convert.ToSingle(words[(i * 2) + 1]) + markerOffset.y;
            ceiling_pt.z = 0.5f; // hull has one meter heigth
            */
            Vector3 floor_pt, ceiling_pt;
            floor_pt.x = Convert.ToSingle(words[i * 2]); // + markerOffset.x;
            floor_pt.y = 0.0f;
            floor_pt.z = Convert.ToSingle(words[(i * 2) + 1]); // + markerOffset.y;

            ceiling_pt.x = Convert.ToSingle(words[i * 2]); //  + markerOffset.x;
            ceiling_pt.y = 0.5f; // Convert.ToSingle(words[(i * 2) + 1]) + markerOffset.y;
            ceiling_pt.z = Convert.ToSingle(words[(i * 2) + 1]); // + markerOffset.y; // hull has one meter heigth


            floor_pt *= scaleFactor;
            ceiling_pt *= scaleFactor;
            
            floor_pt += markerOffset * new Vector3(1.0f, 0.0f, 0.0f) * scaleFactor;
            ceiling_pt += markerOffset * new Vector3(1.0f, 0.0f, 0.0f) * scaleFactor;

            vertices[i * 2] = floor_pt;
            vertices[(i * 2) + 1] = ceiling_pt;
        }

        int v = 0;
        for (int i = 0; i < triangles.Length / 6; i++) // Note: length / 6
        {
            triangles[i * 6] = 0 + v;
            triangles[(i * 6) + 1] = 1 + v;
            triangles[(i * 6) + 2] = 2 + v;
            triangles[(i * 6) + 3] = 2 + v;
            triangles[(i * 6) + 4] = 1 + v;
            triangles[(i * 6) + 5] = 3 + v;
            v += 2;
        }
        return true;

    }

    private void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        // mesh.RecalculateBounds();
    }
}