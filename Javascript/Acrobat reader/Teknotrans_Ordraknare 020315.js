if (app.viewerVariation == "Reader")
{
var aplalert1 = "";
var compversion = "\u002A Teknotrans AB\u002A";
var zozo = this.disclosed;
this.disclosed = true;
var TTActif = "event.rc = event.target != null";
this.disclosed = zozo;
//////////////////////////////////////////////////////////////////////////////////////////////
// LANGUAGE
if (app.language == "SVE")
	{
	var TT11 = "Aktuell sida...";
	var TT12 = "Dokument...";
	var TT20 = "Ordr\u00E4knare";
	var TT60 = "Om...";
	var comptalert1 = "";
	var comptalert21 = " ord pall denna sida.";
	var comptalert22 = " ord i detta dokument.";
	var comptalert33 = "Processing page ";
	var comptalert222 = "Genomsnitt: ";
	var comptalert223 = " ord\/sida.";
	var aboutAlert = compversion + "\r  Version " + "\n\nSvensk \u00F6vers\u00E4ttning av Teknotans";
	}
else {
	var TT11 = "Aktuell sida";
	var TT12 = "Dokument";
	var TT20 = "Ord\u00E4knare";
	var TT60 = "Om";
	var comptalert1 = "";
	var comptalert21 = " ord p\u00E5 denna sida.";
	var comptalert22 = " ord i dokumentet.";
	var comptalert33 = "Processing page ";
	var comptalert222 = "Cirka: ";
	var comptalert223 = " p\u00E5 sidan.";
	var aboutAlert = compversion + "\r  Version 1.0 ";
	}
//////////////////////////////////////////////////////////////////////////////////////////
// MENY
var menuParent = (app.viewerVersion<10)? "Tools":"Edit";
app.addMenuItem({ cName: "-", cParent: menuParent, cEnable: false, cExec:null});
app.addSubMenu({ cName: TT20, cParent: menuParent});
app.addMenuItem({ cName: TT11, cParent: TT20, cEnable: TTActif, cExec: "pageWordCountMenu()"});
app.addMenuItem({ cName: TT12, cParent: TT20, cEnable: TTActif, cExec: "documentWordCountMenu()"});
app.addMenuItem({ cName: "-", cParent: TT20, cEnable: false, cExec:null});
////////////////////////////////////////////////////////////////////////////////////////////////////
if (typeof app.formsVersion != 'undefined' && app.formsVersion >= 7)
{
////////////////////////////////////////////////////////////////////////////////////////////////////
var strData77WordCount = 
"FFE10000FFDE0000FFDD0000FFDE0001FFDF0000FFDE0000FFDD0000FFDD0000FFDE0000FFDE0000FFDE0000FFDE0000FFDE0000FFDE0000FFDE0000FFDE0000FFDE0000FFDE0000FFE10000FFE10000" + //0
"FFDF0100FFDC0001FFE10000FFE10000FFDE0100FFE10000FFDB0001FFD90002FFD30101FFD10101FFCF0101FFCF0101FFD20102FFD70002FFDD0001FFE10001FFDE0000FFDD0000FFDE0000FFDD0001" + //1
"FFDD0000FFDE0000FFDE0001FFDD0000FFDC0001FFD50100FFCC0202FFFEFFFFFFFFFFFFFFFFFFFFFFFEFFFFFFFEFFFFFFFEFFFFFFFEFFFFFFFFFFFFFFFFFFFFFFFEFEFEFFFFFFFFFFDF0000FFDE0000" + //2
"FFDE0001FFDC0001FFDE0001FFDF0000FFD40100FFC60202FFBE0203FFFFFEFFFFFEFFFFFFFEFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFDFFFFFFFDFFDE0001FFDE0000" + //3
"FFDE0000FFE10000FFDE0000FFFBFFFFFFFEFFFDFFFFFFFDFFAF0405FFFFFFFFFF827F80FF827F80FF808080FF808080FF808080FF808080FF808080FF808080FF808082FFDEE1E0FFDE0001FFE10000" + //4
"FFDE0002FFE20000FFD40001FFFFFFFFFFFFFFFFFFFFFEFFFFA10504FFFBFFFDFF808080FF808080FF808080FF808080FF808080FF827F80FF827F80FF827F80FF827F80FFE0E0E0FFD60001FFDE0000" + //5
"FFDE0000FFDC0000FFCF0202FFFFFFFFFF808080FF808080FF800506FFFFFFFDFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFFFEFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFDFEFFCD0202FFDC0000" + //6
"FFDE0000FFD50100FFC30202FFFFFFFDFF7F8082FF80807EFF750706FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFC60202FFD50102" + //7
"FFDD0000FFD00201FFC20204FFFEFFFFFFFFFEFFFFFFFFFFFF7C0C0DFFFFFFFFFF7E8180FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF808082FFE0E0DEFFC00202FFD20102" + //8
"FFDE0000FFCE0100FFBE0302FFFEFEFCFFFFFFFFFFFFFFFDFF770C0FFFFEFFFFFF81817FFF80807EFF80807EFF80807EFF808080FF808080FF7E8180FF7E8180FF808080FFE0E0E0FFBD0202FFCE0202" + //9
"FFDD0000FFCE0102FFBD0204FFFEFFFFFF7E8180FF80807EFF640D0AFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFFFFFFFFFFFFFFFFBC0202FFCC0202" + //10
"FFE10000FFCD0102FFBD0204FFFFFEFFFF807F7BFF808080FF64080CFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFFFFFDFFFFFFFDFFFFFFFFFFFFFFFFFFFFFFFDFFFFFFFFFFBD0204FFCF0101" + //11
"FFDE0000FFD20102FFBD0203FFFAFFFEFFFFFFFDFFFFFEFFFF7B0D0DFFFFFFFDFF808082FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF7E817EFFDFE0E2FFBF0202FFD00201" + //12
"FFE10000FFD20102FFC40203FFFFFFFFFFFFFFFFFFFEFEFCFF870C0AFFFFFEFFFF81807EFF827F80FF808080FF808080FF808080FF808080FF808080FF808080FF7F8082FFE2DFE2FFC50202FFD70100" + //13
"FFDE0000FFDA0101FFCC0202FFFFFFFBFF827F80FF81807EFF7F0506FFFFFFFDFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFDFFFFFFFDFFFFFEFFFFFFFFFDFFC80202FFDB0001" + //14
"FFDD0000FFDE0000FFD40001FFFEFFFDFF808082FF798282FF8B0404FF940709FF8D080AFF890809FF860A0BFF860A08FF8C0806FF960706FFA10506FFA70505FFB70303FFC50202FFD30002FFDE0000" + //15
"FFDE0000FFDE0000FFDD0000FFFFFFFFFFFFFDFEFFFEFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFDFFFFFFFFFFFFFEFFFFFFFFFFFFFFFFFFFFAF0304FFB50303FFC50202FFD00201FFDD0000FFDE0000" + //16
"FFE10000FFDE0000FFDE0000FFFFFFFFFFFFFEFFFFFEFFFFFFFFFEFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFFFEFFFFFFFFFFFFFFBD0203FFC60202FFD00201FFDB0001FFDE0000FFDE0000" + //17
"FFDD0000FFDE0001FFDE0000FFDE0001FFDC0000FFD50102FFCC0202FFC30202FFC00202FFBD0203FFBB0204FFBD0204FFBE0202FFC50202FFCB0202FFD30101FFDD0000FFDE0000FFDD0000FFDE0000" + //18
"FFDE0000FFE10000FFDE0000FFDD0000FFDE0000FFDE0000FFDA0000FFD40102FFD10102FFCC0202FFCC0202FFCE0202FFD20102FFD40102FFDC0001FFDE0000FFDE0000FFDE0000FFDE0000FFDE0000"; //19
}
//////////////////////////////////////////////////////////////////////////////////////////////
if (typeof app.formsVersion != 'undefined' && app.formsVersion >= 7)
{
//RÄKNARE
function WordCount()
{
	if(this.event.target!=null)
	{
	documentCible=this;
	choix=app.popUpMenuEx(
	{cName: TT20,bEnabled:false},
	{cName: "-",bEnabled:false},
	{cName: TT12,bEnabled:true},
	{cName: TT11,bEnabled:true},
	{cName: "-",bEnabled:false},
	{cName: TT60,bEnabled:true}
	)
		if(choix)
		{
		if(choix==TT12){documentWordCount();}
		if(choix==TT11){pageWordCount();}
		if(choix==TT60){TTPropo();}
		}
	}
}
////////////////////////////////////////////////////////////////////////////////////////////////////
//DOKUMENT
function documentWordCount()
{
	var t = app.thermometer;
	t.duration = documentCible.numPages;
	t.begin();
	var cnt=0;
	for ( var i = 0; i < documentCible.numPages; i++)
		{
		t.value = i;
		t.text = comptalert33 + (i + 1);
		cnt += documentCible.getPageNumWords(i);
		if (t.cancelled) break;
		}
	t.end();
	moyenne=Math.floor(cnt/documentCible.numPages);
	cMessage1=comptalert1 + cnt + comptalert22;
	cMessage2=comptalert222+moyenne+comptalert223;
	cMessage3=TT20;
	alerteTT3();
}
////////////////////////////////////////////////////////////////////////////////////////////////////
//  SIDAN
function pageWordCount()
{
	if(documentCible)
	{
	var cnt = 0;
	var number = 0;
	number = documentCible.pageNum;
	cnt += documentCible.getPageNumWords(number);
	cMessage1=comptalert1 + cnt + comptalert21;
	cMessage2="";
	cMessage3=TT20;
	alerteTT3();
	}
	else
	{
	cMessage1=comptalert34;
	alerteTT1();
	}
}
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//DOKUMENT MENY
function documentWordCountMenu()
{	documentCible=this;
	var t = app.thermometer;
	t.duration = documentCible.numPages;
	t.begin();
	var cnt=0;
	for ( var i = 0; i < documentCible.numPages; i++)
		{
		t.value = i;
		t.text = comptalert33 + (i + 1);
		cnt += documentCible.getPageNumWords(i);
		if (t.cancelled) break;
		}
	t.end();
	moyenne=Math.floor(cnt/documentCible.numPages);
	cMessage1=comptalert1 + cnt + comptalert22;
	cMessage2=comptalert222+moyenne+comptalert223;
	cMessage3=TT20;
	alerteTT3();
}
////////////////////////////////////////////////////////////////////////////////////////////////////
//SID MENY
function pageWordCountMenu()
{	documentCible=this;
	if(documentCible)
	{
	var cnt = 0;
	var number = 0;
	number = documentCible.pageNum;
	cnt += documentCible.getPageNumWords(number);
	cMessage1=comptalert1 + cnt + comptalert21;
	cMessage2="";
	cMessage3=TT20;
	alerteTT3();
	}
	else
	{
	cMessage1=comptalert34;
	alerteTT1();
	}
}
////////////////////////////////////////////////////////////////////////////////////////////////////
//UTSEENDE
	function alerteTT3()
	{
	var TTcadaDialogue =
	{
	result:"cancel",
	DoDialog: function(){return app.execDialog(this);},
	initialize: function(dialog)
	{

	dialog.load(dlgInit);
	},
	commit: function(dialog)
	{
	var oRslt = dialog.store();
	},
	description:
	{
	name: "JSADM Dialog",
	elements:
	[
	{
	type: "view",
	elements:
	[
	{
	type: "view",
	char_height: 10,
	elements:
	[
	{
	type: "image",
	item_id: "img1",
	width: 300,
	height: 40,
	char_width: 4,
	char_height: 4,
	},
	{
	type: "static_text",
	item_id: "stat",
	name: cMessage1,
	char_width: 15,
	alignment: "align_fill",
	font: "dialog",
	},
	{
	type: "static_text",
	item_id: "stat",
	name: cMessage2,
	char_width: 15,
	alignment: "align_fill",
	font: "dialog",
	},
	{
	type: "static_text",
	item_id: "stat",
	name: cMessage3,
	char_width: 15,
	alignment: "align_right",
	font: "dialog",
	},
	]
	},
	{
	type: "ok",
	},
	]
	},
	]
	}
	};
		if("ok" == TTcadaDialogue.DoDialog())
		{
		}
	}
//////////////////////////////////////////////////////////////////////////////////////////////
//MEDDELANDERUTA
function TTPropo()
{app.alert({cMsg: aboutAlert, cTitle: TT60, nIcon: 3});}
//////////////////////////////////////////////////////////////////////////////////////////////
if (typeof app.formsVersion != 'undefined' && app.formsVersion >= 7)
{
var oIconWordCountPag = null;
oIconWordCountPag = {count: 0, width: 20, height: 20,
read: function(nBytes){return strData77WordCount.slice(this.count, this.count += nBytes);}};
//////////////////////////////////////////////////////////////////////////////////////////////
var oButObjCountWordsPag = 
{cName: TT20 +  "  " + TT11,
cExec: "WordCount()",
cEnable: "event.rc = (app.doc != null)",
cMarked: "event.rc = false",
cTooltext: TT20 +  " : " + TT11,
nPos: 02,
cLabel: TT20};
//////////////////////////////////////////////////////////////////////////////////////////////
if(oIconWordCountPag != null)
    oButObjCountWordsPag.oIcon = oIconWordCountPag;
try{app.removeToolButton("docWordCount");}catch(e){}
try{app.addToolButton(oButObjCountWordsPag);}catch(e){}
}
}