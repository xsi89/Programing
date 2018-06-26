// Set up context menu at install time.
chrome.runtime.onInstalled.addListener(function() {
  var context = "selection";
  var title = "Räkna orden";
  var id = chrome.contextMenus.create({"title": title, "contexts":[context],
                                         "id": "context" + context});  
});

// add click event
chrome.contextMenus.onClicked.addListener(onClickHandler);

// The onClicked callback function.
function onClickHandler(info, tab) {

  var sText = info.selectionText;
  
  alert("det är "+sText.length);
  
  
  
  
  
  //var url = "https://www.google.com/search?q=" + encodeURIComponent(sText);  
  //window.open(url, '_blank');
};

