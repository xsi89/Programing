var sel = window.getSelection();
var selectedText = sel.toString();
chrome.extension.sendRequest({action: selectedText}, function(response) {
  console.log('Start action sent');  
});