#targetengine "session"

main();
myKABDocScriptPath=app.activeScript.parent.fullName;

function main(){
    mySetup();
    mySnippet();
    myTeardown();
}
function mySetup(){
}
function mySnippet(){
    //<fragment>
	var myEventListener = app.addEventListener("afterOpen", doEventStuff);
    alert("OK, event listener påsatt");
    
    //</fragment>
}
function myTeardown(){
//~     app.removeEventListener ("afterOpen", doEventStuff);
}
//<fragment>
function doEventStuff(myEvent){
	alert("This event is the " + myEvent.eventType + " event." + " " + myEvent.parent);
    myObject=myEvent.parent;
    if (myObject.constructor.name=="Document"){ 
            alert(myObject.name + " " + myObject.stories.everyItem());
//~             myPath="/Applications/Adobe InDesign 5.5/Scripts/Scripts panel/";
            alert(myKABDocScriptPath);
//~ 			myFileSeparator=toString(File.separator);
//~ 			alert("File.separator: "+myFileSeparator);
            myLastIndex=myKABDocScriptPath.lastIndexOf("/");
            alert(myLastIndex);
            myMotherPath=myKABDocScriptPath.substr(0,myLastIndex);
            alert(myMotherPath);
            myScriptsPath=myMotherPath+"/Scripts panel/KAB Document info local/Source1.jsx";
            alert(myScriptsPath);
            myFile = new File (myScriptsPath);
            if (myFile.exists){
                app.doScript(myFile ,ScriptLanguage.JAVASCRIPT)
            }
        }

    
//~     alert("currentTarget: "+ myEvent.currentTarget.name + "parent: "+  + myEvent.parent + "parent.name: "+ myEvent.parent.name);

}




//~     myPath=app.activeScript.parent.fsName;
//~     alert(myPath);
//~     myLastIndex=myPath.lastIndexOf("/");
//~     alert(myLastIndex);
//~     myMotherPath=myPath.substr(0,myLastIndex);
//~     alert(myMotherPath);
//~     myScriptsPath=myMotherPath+"/hello.jsx";
//~     alert(myScriptsPath);
//~     myFile = new File (myScriptsPath);
//~     if (myFile.exists){
//~         app.doScript(myFile ,ScriptLanguage.JAVASCRIPT)
//~     }