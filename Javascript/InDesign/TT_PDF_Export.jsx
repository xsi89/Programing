
app.scriptPreferences.userInteractionLevel = UserInteractionLevels.interactWithAll;
if( app.documents.length > 0 ) {
    chooseExportFormat();
    newfilename = app.activeDocument.name.replace(RegExp( "indd" ), "pdf" );
    app.scriptPreferences.userInteractionLevel = UserInteractionLevels.neverInteract;
    app.activeDocument.exportFile("Adobe PDF", File(app.activeDocument.filePath+ "/" + newfilename), false, myExportFormat);
    app.scriptPreferences.userInteractionLevel = UserInteractionLevels.interactWithAll;
    }else{
        chooseExportFormat();
        batchPDFExport();
        app.scriptPreferences.userInteractionLevel = UserInteractionLevels.interactWithAll;
    }
    
function batchPDFExport(){

myFolder= Folder.selectDialog ("Choose a folder for PDF export");

//Get array with files in export folder
var myFiles = Folder( myFolder ).getFiles( '*.indd' )
//alert(myFiles);

//Check if there are files in export folder				
if(myFiles.length == 0) {
	svar = confirm("Can't see any InDesign files in this folder, or you canceled the Folder Chooser dialog. Do you want to continue?");
	if(svar == false) {exit()}
}

// start file opener loop (open each file, then export all stories in each document to .incx text file			
for(myFileCounter = 0; myFileCounter < myFiles.length; myFileCounter++){
	app.scriptPreferences.userInteractionLevel = UserInteractionLevels.neverInteract;
	app.open(myFiles[myFileCounter], true);
  		newfilename = myFiles[myFileCounter].name.replace(RegExp( "indd" ), "pdf" );
//alert(newfilename);		
	// export all stories in each document to .incx text file	starts here--
	//Stop if there are no documents open

		//Stop if there are no documents
    if(myFolder != null){
        //Create a PDF file
        app.activeDocument.exportFile("Adobe PDF", File(myFolder + "/" + newfilename), false, myExportFormat);
		//app.activeDocument.exportFile("Adobe PDF", File(app.activeDocument.filePath+ "/" + newfilename), false, myExportFormat);
        }else{
        alert("We couldn't find any InDesign documents in the chosen folder. Please choose another folder. If you are sure there are InDesign documents in this folder, try unzipping the documents or make sure that they have the correct suffix (.indd)");
    }

	//--end of export of single file, any changes that need to be done to the document before it is saved and closed should be done now.

//... aaand close file
    app.activeDocument.close(SaveOptions.yes,myFiles[myFileCounter]);
	}
}

function chooseExportFormat(){
    pdfPresets = app.pdfExportPresets.everyItem().name;
//~ alert(pdfPresets.length);
//Dialog to choose export format
	with(myDialog = app.dialogs.add({name:"Export to PDF"})){
		myDialogColumn = dialogColumns.add()	
		with(myDialogColumn){
			with(borderPanels.add()){
				staticTexts.add({staticLabel:"Choose PDF Preset:"});
				with(myExportFormatButtons = radiobuttonGroups.add()){
                    myState=0;
                    for(myPrefsCounter = 0; myPrefsCounter < pdfPresets.length; myPrefsCounter++){
// om du vill lägga in en annan förinställning för PDF:en som default gör du det här nedanför, efter name==". Du måste skriva in den exakt så som den ser ut i dialogrutan och PDF-inställningarna. Eventuella klamrar ska med. Känslig för versaler och gemener. Undvik å ä ö och andra specialtecken i PDF-inställningar!
                        if (app.pdfExportPresets[myPrefsCounter].name=="[Smallest File Size]"){
                            myState=1;
                            }else{
                                myState=0;
                            }
                        radiobuttonControls.add({staticLabel:pdfPresets[myPrefsCounter], checkedState:myState});
                        
                   }
				}
			}
		}
	}
	myReturn = myDialog.show();
		
//Continue if a format have been chosen
    if (myReturn == true){
                    
        //Store selected format
        myExportFormat = app.pdfExportPresets[(myExportFormatButtons.selectedButton)];
        myDialog.destroy;
        }else{
            exit();
    }
}