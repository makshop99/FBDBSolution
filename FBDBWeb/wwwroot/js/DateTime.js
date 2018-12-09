

// This methode writes the 
function getSystate()
{
    var d = new Date();
    monthname = new Array("Januar", "Februar", "März", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember");
    var TODAY = d.getDate() + "." + monthname[d.getMonth()] + "  " + d.getFullYear();
    
    //document.write(TODAY);
    return TODAY;
}
 