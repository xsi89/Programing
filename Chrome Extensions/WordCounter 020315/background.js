var text = "http://translate.google.com/#auto/fa/";
function onRequest(request, sender, sendResponse) {
   text = "http://translate.google.com/#auto/fa/";
   text = text + request.action.toString();

 sendResponse({});
};

chrome.extension.onRequest.addListener(onRequest);
chrome.contextMenus.onClicked.addListener(function(tab) {
  chrome.tabs.create({url:text});
});
chrome.contextMenus.create({title:"Translate '%s'",contexts: ["all"], "onclick": onRequest});
