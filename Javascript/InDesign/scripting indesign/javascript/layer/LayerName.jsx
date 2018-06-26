//LayerName.jsx
//An InDesign CS5 JavaScript
//
//Shows how to get a reference to a layer by name.
main();
function main(){
	mySetup();
	mySnippet();
	myTeardown();
}
function mySetup(){
	var myDocument = app.documents.add();
	myDocument.layers.add({name:"Text Layer"});
}
function mySnippet(){
	var myDocument = app.documents.item(0);
	//<fragment>
	//Given a document "myDocument"...
	var myLayer = myDocument.layers.item("Text Layer");
	//</fragment>
	alert("Text Layer ID: " + myLayer.id);
}
function myTeardown(){
}