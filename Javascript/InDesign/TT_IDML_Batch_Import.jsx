//  Detta script är skrivet av Daniel Elmnäs 2016-02-09
var docSource=app.activeDocument;
var layer1 = MakeLayer("TT_IDML");
app.clipboardPreferences.pasteRemembersLayers = false;  
    function MakeLayer(name, layerColor) {
        var layer = docSource.layers.item(name);
        if (!layer.isValid) {
            layer = docSource.layers.add({name: name});
            if (layerColor != undefined) layer.layerColor = layerColor;
        }
        return layer;
    }
        var myFolder = Folder.selectDialog("Choose the folder")
        if(myFolder.length==0)
            {
                alert("No Folder Selected")
                exit(0)
            } 
                var myFiles = myFolder.getFiles("*.idml")
                         if(myFiles.length==0)
                        {
                        alert("No InDesign files in folder")
                        }
                            for(i=0; i<myFiles.length; i++)
                                {
                                    myFile = myFiles[i]
                                    app.open(myFile)
                                    var docTarget=app.activeDocument;
                                    var paletteObjects = app.activeDocument.layers[0].allPageItems;
                                    app.select(paletteObjects);  
                                    app.copy();  
                                    app.activeDocument=docSource;
                                    app.documents[0].activeLayer = app.documents[0].layers.itemByName("TT_IDML");  
                                    app.select(null); // Be careful what is selected, if you are using pasteInPlace()  
                                    app.pasteInPlace();  
                                    app.selection[0].move (app.activeDocument.pages[0]);
                                    app.activeDocument=docTarget;
                                    app.activeDocument.close(SaveOptions.no)  
                                }
    app.scriptPreferences.userInteractionLevel = UserInteractionLevels.NEVER_INTERACT;
    app.scriptPreferences.userInteractionLevel = UserInteractionLevels.INTERACT_WITH_ALL;

     