myDoc=app.activeDocument;
myContainers=app.activeDocument.textFrames.everyItem().id;
myStoriesContainers=app.activeDocument.stories.everyItem().textContainers;
myStories=app.activeDocument.stories.everyItem().id;
myCheckTheseFramesList=[];
myRemovedFramesList=[];

for (i=0; i<myStoriesContainers.length; i++){
    for (y=0; y<myStoriesContainers[i].length; y++){

}  
    }

myPasteboardFramesList=[]; 
myPageFramesList=[];
myLockedLayerFramesList=[];
myIgnoreFramesList=[];
//~ //bygg upp en lista över alla textcontainers på pasteboard och en annan med alla textcontainers som ligger på en sida.
for(mySCC=0;mySCC<myStoriesContainers.length;mySCC++){
    myContainers=myStoriesContainers[mySCC];
    for (myCC=0;myCC<myContainers.length;myCC++){
        //text längs bana (textPath) har ingen parentpage. Istället har textens parent (polygon, textpath, textframe eller dylikt) en parentpage. Därför, leta efter dess parents parentpage.

        myContainerToCheck=myContainers[myCC];
//~                  //alert(myContainerToCheck.constructor.name + myContainers[myCC].id);
        if (myContainerToCheck.constructor.name!="TextFrame"){
            alert("hittat en sån därn: " + myContainerToCheck.constructor.name);
            myContainerToCheck=myContainerToCheck.parent;
//~             //alert("myContainerToCheck är nu" + myContainerToCheck.constructor.name + ", ID: " + myContainerToCheck.id);
        }

            if (myContainerToCheck.parentPage!=null){
                if (arrayContains(myPageFramesList, myContainerToCheck.id)){
                    alert("frame " + myContainerToCheck.id + " finns redan listad som sidobjekt. Är det en textFrame med textPath på sig, detta?");
                    selectIt(myContainerToCheck);
                    exit();
                }else{
                    myPageFramesList.push(myContainerToCheck.id);
                }
            }else{
                myExit=0;
                while (myExit==0){
                    
//~                     alert(myContainerToCheck.parent.constructor.name);
                    if (myContainerToCheck.parent.constructor.name=="Character"){   
//~                         alert("inline nånting");
                        myIgnoreFramesList.push(myContainerToCheck.id);

                        myExit=1;
                    }else if (myContainerToCheck.parent.constructor.name=="Spread"){
                        myExit=1;
                    }else{
                        myContainerToCheck=myContainerToCheck.parent;
                    }
                }
                if (!arrayContains(myIgnoreFramesList, myContainerToCheck.id)){
                   if (myContainerToCheck.itemLayer.locked){
                       myLockedLayerFramesList.push(myContainerToCheck.id);
                   }else{
                       if (!arrayContains(myPasteboardFramesList, myContainerToCheck.id)){
                       myPasteboardFramesList.push(myContainerToCheck.id);
                   }
               }
           }
       }
    }
}

if (myPasteboardFramesList.length<1){
    alert("det finns inga textramar på pasteboard.");
    exit();
    }

//~ alert("pasteboard:" + myPasteboardFramesList + " pages:" + myPageFramesList);
checkTheseFrames=[];
//Stega igenom listan över pasteboardframes. Varje frame har en pappastory. Om ingen av pappastoryns frames ligger på sidan (finns i pageFrames-listan), ta bort framen och ta bort storyn från listan. Annars, stanna.
for(myFC=0; myFC<myPasteboardFramesList.length; myFC++){
    selectIt(app.activeDocument.textFrames.itemByID(myPasteboardFramesList[myFC]));
    myStory=app.activeDocument.textFrames.itemByID(myPasteboardFramesList[myFC]).parentStory;
//~ exit();
//~     alert(myPasteboardFramesList[myFC]);
    myStoryFrames=myStory.textContainers;
//~     selectIt(myStoryFrames);
//~     alert("det finns " + myStoryFrames.length + " containers i denna");
    removeMe=1;
    for (myFC2=0; myFC2<myStoryFrames.length; myFC2++){
//~         selectIt(myStoryFrames[myFC2]);
//~         alert("frame " + (myFC2.valueOf()+1) + " id:" + myStoryFrames[myFC2].id + ", ramar på sidorna: " + myPageFramesList + ", constructor: " + myStoryFrames[myFC2].constructor.name);
        if (arrayContains(myPageFramesList, myStoryFrames[myFC2].id)){
            removeMe=0;
            
            if (!arrayContains(myCheckTheseFramesList, myPasteboardFramesList[myFC])){
                selectIt(app.activeDocument.textFrames.itemByID(myPasteboardFramesList[myFC]));
                alert("Kolla denna frame. Den är kopplad till en frame på sidan.");
                exit();
                myCheckTheseFramesList.push(myPasteboardFramesList[myFC]); //, myStoryFrames[myFC2].id
            }
        }
    }
if (removeMe){
    
    app.activeDocument.textFrames.itemByID(myPasteboardFramesList[myFC]).remove();
    myRemovedFramesList.push(myPasteboardFramesList[myFC]);
    }
}    

//~ #targetengine "session";
if (myLockedLayerFramesList.length>0){
        alert("pasteboard-textamar i låsta lager togs inte bort - i detta dokument var det " + myLockedLayerFramesList.length + " st. ID: " + myLockedLayerFramesList + "pasteboardramar som togs bort:" + myRemovedFramesList);
        }else{
        alert("alla " + myRemovedFramesList.length + " textramar som låg på pasteboard är borttagna. Inga var länkade in till någon sida, inga låg i låsta lager. Grattis!\n Borttagna textramar: " + myRemovedFramesList);
    }




exit();




function arrayContains(anArray, anItem) {
  for (var i = 0; anArray.length > i; i++) {
    if (anItem == anArray[i]) return true;
  }
  return false;
}

function selectIt(theObj) { 
  // Selects object, turns to page and zooms in on it 
  app.select(theObj,SelectionOptions.replaceWith); 
  app.activeWindow.zoom = ZoomOptions.fitPage; 
  app.activeWindow.zoomPercentage = 100 
}





 if (myTextFrame.parentStory.textContainers.length!=1){
        myOtherFrames=myTextFrame.parentStory.textContainers;
        alert("id: "+ myOtherFrames[1].id);
        for (myOFC=0; myOFC<myOtherFrames.length;myOFC++){
            if (!arrayContains(myPasteboardFramesList, myOtherFrames[myOFC].id)){
                selectIt(myTextFrame);
                alert("Länkad textram!\nden här textramen är länkad till en textram på en sida. \nKolla vad det är som händer i dokumentet och ta bort den manuellt.");
                exit();
            }else{
                myTextFrame.remove();
                exit();
            }
        }
    }else{
        myTextFrame.remove();
    }