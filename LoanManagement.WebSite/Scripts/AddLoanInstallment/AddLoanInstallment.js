 
var ObservableUIElem;

////////////////////////////////
//Observer library declaration//
////////////////////////////////

////////////////////////////////
//Observer         declaration//
////////////////////////////////
function ObserverObj(elemId) {
    console.log("observer created " + elemId);
    this.elementId = elemId;
}
ObserverObj.prototype.notify = function () {
    console.log("observer notify")
}

////////////////////////////////
//Observable       declaration//
////////////////////////////////
function ObservableObj(elemId) {
    console.log("observable created " + elemId);
    this.elementId = elemId;
    this.observerList = new Array();
}

ObservableObj.prototype.addObserver = function (observerObj) {
    this.observerList.push(observerObj);

    console.log("observer added: " + observerObj.elementId);
};

ObservableObj.prototype.notifyObservers = function (elem) {

    for (var i = 0; i < elem.observerList.length; i++) {
        elem.observerList[i].notify();
    }
    console.log("notify observers");
};
ObservableObj.prototype.AttatchFocusOut = function () {
    $("#" + this.elementId).focusout(this.notifyObservers(this));
};
$(document).ready(function () {           
    
    //observer pattern setup
    //add observables considering their id's
    ObservableUIElem = new ObservableObj("CustomerNameTextBox");

    //add observers considering their id's
    observerElem = new ObserverObj("LoanDescriptionTextBox");

    //add observers to observables
    ObservableUIElem.addObserver(observerElem);

    //attatch focusout
    ObservableUIElem.AttatchFocusOut();
   

    //legacy attach
    //$("#CustomerNameTextBox").focusout(function (elm) {
    //    var textBoxText = $("#CustomerNameTextBox").val();
    //    $("#LoanDescriptionTextBox").val(textBoxText+"'s loan");
    //});
});
