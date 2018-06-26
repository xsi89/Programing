//SampleXMLRule.jsx
//An InDesign CS5 JavaScript
//
//A Sample XML Rule
//<fragment>
function RuleName() {
	this.name = "RuleNameAsString";
	this.xpath = "ValidXPathSpecifier";
	this.apply = function (element, ruleSet, ruleProcessor){
		//Do something here.
		//Return true to stop further processing of the XML element
		return true;	 
	}; // end of Apply function
}
//</fragment>
